using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;

namespace VoteOnline.Application
{
    public interface IPhuongAnReponsitory
    {
        Task<List<PhuongAn>> GetAllTypeAsync(string text, int pageIndex, int pageSize, string customCode);
        Task<PhuongAn> AddTypeAsync(PhuongAn type);
        Task<PhuongAn> UpdateTypeAsync(PhuongAn type);
        Task<PhuongAn> DeleteTypeAsync(PhuongAn type);
    }
}
