using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Application;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;

namespace VoteOnline.Infratructure
{
    public class MainAccountResponsitory : IMainAccountRepository
    {
        private readonly VoteOnlineContext _authContext;
        public MainAccountResponsitory(VoteOnlineContext context)
        {
            this._authContext = context;
        }
        public async Task AddMainAccountAsync(MainAccountModel account)
        {
            var mainAccountEntity = new MainAccount
            {
                UserName = account.UserName,
                Password = account.Password,
                LastLogin = DateTime.Now,
                Lock = false,
                DienThoai = account.DienThoai,
                Email = account.Email,
                HoTen = account.HoTen,
                DateCreate = DateTime.Now,
                CustomCode = Guid.NewGuid().ToString(),
                ExpiryDate = DateAndTime.DateAdd(DateInterval.Day,7, DateTime.Now)
            };

            await _authContext.MainAccounts.AddAsync(mainAccountEntity);
        }

        public async Task<bool> DeleteMainAccountAsync(int ID)
        {
            var account = await this.GetMainAccontByIDAsync(ID);
            if(account != null) { 
                _authContext.MainAccounts.Remove(account);
                await _authContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<MainAccountModel>> GetAllMainAccountAsync(string text, int pageIndex, int pageSize, string customCode)
        {
            var account = await _authContext.MainAccounts
                .Where(acc => acc.HoTen == text)
                .Select(acc => new MainAccountModel
                {
                    ID = acc.Id,
                    UserName = acc.UserName,
                    Password = acc.Password,
                    DienThoai = acc.DienThoai,
                    Email = acc.Email,
                    HoTen = acc.HoTen
                })
                .Take(pageSize)
                .Skip(pageIndex * pageSize).ToListAsync();

            return account;
        }

        public async Task<MainAccount?> GetMainAccontByIDAsync(int ID)
        {
            return await _authContext.MainAccounts
                .Include(c => c.Id)
                .FirstOrDefaultAsync(c => c.Id == ID);
        }

        public async Task<MainAccountModel?> UpdateMainAccountAsync(MainAccountModel account)
        {
            var mainAccountEntity = await GetMainAccontByIDAsync(account.ID);
            if (mainAccountEntity != null) { 
                mainAccountEntity.Password = account.Password;
                mainAccountEntity.HoTen = account.HoTen;
            }

            await _authContext.SaveChangesAsync();

            return mainAccountEntity == null ? null : new MainAccountModel { 
                ID = mainAccountEntity.Id,
                UserName = mainAccountEntity.UserName, 
                Password = mainAccountEntity.Password,
                Email = mainAccountEntity.Email,
                DienThoai = mainAccountEntity.DienThoai,
                HoTen = mainAccountEntity.HoTen
            };

        }

        Task<MainAccountModel> IMainAccountRepository.AddMainAccountAsync(MainAccountModel account)
        {
            throw new NotImplementedException();
        }

    }
}
