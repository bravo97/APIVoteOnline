using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;

namespace VoteOnline.Application
{
    public interface IMainAccountRepository
    {
        Task<List<MainAccountModel>> GetAllMainAccountAsync(string text, int pageIndex, int pageSize, string customCode);
        Task<MainAccountModel> AddMainAccountAsync(MainAccountModel account);
        Task<MainAccountModel> UpdateMainAccountAsync(MainAccountModel account);
        Task<bool> DeleteMainAccountAsync(int ID);

    }
}
