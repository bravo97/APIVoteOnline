using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models;
using VoteOnline.Domain.Models.DTO;

namespace VoteOnline.Application
{
    public interface ISubAccountReponsitory
    {
        Task<List<SubAccountModel>> GetAllSubAccountAsync(string text, int pageIndex, int pageSize, int customCode,int vande);
        Task<TokenUserApiDTO> AddSubAccountAsync(SubAccount account);
        Task<bool> UpdateSubAccountAsync(SubAccount account);
        Task<bool> DeleteSubAccountAsync(SubAccountModel mainAccount);
    }
}
