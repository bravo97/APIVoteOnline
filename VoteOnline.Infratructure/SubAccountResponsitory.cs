using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Application;
using VoteOnline.Application.Helpers;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;

namespace VoteOnline.Infratructure
{
    public class SubAccountResponsitory : ISubAccountReponsitory
    {
        private readonly VoteOnlineContext _context;
        public SubAccountResponsitory(VoteOnlineContext context) {
            _context = context; 
        }
        public async Task<bool> AddSubAccountAsync(SubAccountRequest account)
        {
            var xml = Extension.SerializeListToXml(account.subAccountModels);
            var subacc = await _context.SubAccounts.FromSqlRaw("SP_SubAccount_Update @p0,@p1,@p2", account.IdVanDe, account.IdMainAccount,xml)
                .ToListAsync();
            if (subacc != null)
            {
                return true;
            }

            return false;
        }

        public Task<bool> DeleteSubAccountAsync(SubAccountModel mainAccount)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SubAccountModel>> GetAllSubAccountAsync(string text, int pageIndex, int pageSize, int customCode,int vande)
        {
            var account = await _context.SubAccounts
                .Where(acc => acc.IdmainAccount == customCode && acc.IdvanDe==vande)
                .Select(acc => new SubAccountModel
                {
                    Id = acc.Id,
                    HoTen = acc.HoTen,
                    DienThoai = acc.DienThoai,
                    CMND = acc.Cmnd,
                    KhoaBM = acc.KhoaBm
                })
                .ToListAsync();

            return account;
        }

        public Task<bool> UpdateSubAccountAsync(SubAccountRequest account)
        {
            throw new NotImplementedException();
        }
    }
}
