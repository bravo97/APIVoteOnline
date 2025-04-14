using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Application;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;
using VoteOnline.Domain.Models.DTO;

namespace VoteOnline.Infratructure
{
    public class UserResponsitory : IUserResponsitory
    {
        private readonly VoteOnlineContext _context;
        private readonly IConfiguration _configuration;
        public UserResponsitory(VoteOnlineContext context,IConfiguration configuration) {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task<TokenApiDTO?> AuthenticateAsync(UserModel user)
        {
            var _user = await _context.MainAccounts.FirstOrDefaultAsync(x => x.Email==user.UserName && x.Password==user.Password);
            if (_user == null) return null;

            _user.Token = CreateJwtAdmin(_user);
            _user.RefreshToken = createRefreshTokenAdmin();
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            _user.LastLogin = DateTime.Now;

            return new TokenApiDTO { 
                AccessToken = _user.Token,
                RefreshToken = _user.RefreshToken,
            };
        }

        public async Task<MainAccountModel> Register(MainAccountModel user)
        {
            var users = new MainAccount
            {
                Id = 0,
                UserName = user.UserName,
                Password = user.Password,
                Lock = false,
                LastLogin = DateTime.Now,
                DienThoai = user.DienThoai,
                Email= user.Email,
                HoTen = user.HoTen,
                CustomCode = "",
                Token = "",
                RefreshToken = "",
                RefreshTokenExpiryTime = DateTime.Now,
                DateCreate = DateTime.Now,
                ExpiryDate = DateAndTime.DateAdd(DateInterval.Day,10, DateTime.Now)
            };
            await _context.MainAccounts.AddAsync(users);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            var emails = await _context.MainAccounts.AnyAsync(u => u.Email == email);
            if (emails) { return true; }
            return false;
        }


        private string CreateJwtAdmin(MainAccount users)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,$"{users.UserName}"),
                new Claim(ClaimTypes.NameIdentifier,$"{users.HoTen}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private string CreateJwtUser(SubAccount users)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.SerialNumber,$"{users.Cmnd}"),
                new Claim(ClaimTypes.Name,$"{users.HoTen}"),
                new Claim(ClaimTypes.NameIdentifier,$"{users.IdmainAccountNavigation.CustomCode}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private string createRefreshTokenAdmin()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);
            var tokenInUser = _context.MainAccounts
                .Any(a => a.RefreshToken == refreshToken);
            if (tokenInUser)
            {
                return createRefreshTokenAdmin();
            }

            return refreshToken;
        }

        public async Task<TokenApiDTO> LoginAsync(UserModel user)
        {
            var _user = await _context.SubAccounts
                .Include(sc=> sc.IdmainAccountNavigation)
                .FirstOrDefaultAsync(x => (x.DienThoai == user.UserName || x.Cmnd == user.UserName) && x.KhoaBm == user.Password);
            if (_user == null) return null;

            var token = CreateJwtUser(_user);

            return new TokenApiDTO
            {
                AccessToken = token,
                RefreshToken = "",
            };
        }
    }
}
