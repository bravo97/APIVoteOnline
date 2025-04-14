using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;

namespace VoteOnline.Application
{
    public interface IDinhDangReponsitory
    {
        Task<List<DinhDang>> GetAllTypeAsync(string text, int pageIndex, int pageSize, string customCode);
        Task<DinhDang> AddTypeAsync(DinhDang type);
        Task<DinhDang> UpdateTypeAsync(DinhDang type);
        Task<DinhDang> DeleteTypeAsync(DinhDang type);
    }
}
