using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Application;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;
using VoteOnline.Domain.Models.DTO;

namespace VoteOnline.Infratructure
{
    public class SubAccountResponsitory : ISubAccountReponsitory
    {
        private readonly VoteOnlineContext _context;
        private readonly IConfiguration _configuration;
        public SubAccountResponsitory(VoteOnlineContext context,IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }

        public async Task<TokenUserApiDTO> AddSubAccountAsync(SubAccount account)
        {
            var token = CreateJwtUser(account);
            
            var acc = await GetSubAccountExistsAsync(account.Code, account.DienThoai, account.Email);
            if (acc == null)
            {
                //Create new account 
                var newSubAccount = new SubAccount
                {
                    Code = account.Code,
                    HoTen = account.HoTen,
                    DienThoai = account.DienThoai,
                    Email = account.Email,
                    Token = token,
                    RefreshToken = "",
                    LastLogin = DateTime.Now,
                    RefreshTokenExpiryTime = DateTime.Now,
                    DateCreate = DateTime.Now,
                    ExpiryDate = DateAndTime.DateAdd(DateInterval.Day, 1, DateTime.Now)
                };

                await this._context.SubAccounts.AddRangeAsync(newSubAccount);
                await this._context.SaveChangesAsync();
            }
            else
            {
                acc.LastLogin = DateTime.Now;
                acc.Token = token;
                acc.ExpiryDate = DateAndTime.DateAdd(DateInterval.Day, 1, DateTime.Now);

                this._context.Entry(acc).State = EntityState.Modified;
                await this._context.SaveChangesAsync();
            }

            var TokenUserAPI = new TokenUserApiDTO
            {
                AccessToken = token,
                Room = account.Code
            };

            return TokenUserAPI;
        }

        public Task<bool> DeleteSubAccountAsync(SubAccountModel mainAccount)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubAccountModel>> GetAllSubAccountAsync(string text, int pageIndex, int pageSize, int customCode, int vande)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubAccountAsync(SubAccount account)
        {
            throw new NotImplementedException();
        }

        public async Task<SubAccount?> GetSubAccountExistsAsync(string code,string dienthoai, string email)
        {
            return await this._context.SubAccounts
                .FirstOrDefaultAsync(ac => ac.Code == code && ac.DienThoai == dienthoai && ac.Email == email);
            
        }


        private string CreateJwtUser(SubAccount users)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.SerialNumber,$"{users.Code}"),
                new Claim(ClaimTypes.Name,$"{users.HoTen}")
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
    }
}
