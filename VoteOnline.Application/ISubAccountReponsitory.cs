using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;

namespace VoteOnline.Application
{
    public interface ISubAccountReponsitory
    {
        Task<List<SubAccountModel>> GetAllSubAccountAsync(string text, int pageIndex, int pageSize, int customCode,int vande);
        Task<bool> AddSubAccountAsync(SubAccountRequest account);
        Task<bool> UpdateSubAccountAsync(SubAccountRequest account);
        Task<bool> DeleteSubAccountAsync(SubAccountModel mainAccount);
    }
}
