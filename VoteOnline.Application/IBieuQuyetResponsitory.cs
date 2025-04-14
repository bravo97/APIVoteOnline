using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;

namespace VoteOnline.Application
{
    public interface IBieuQuyetResponsitory
    {
        Task<List<BieuQuyet>> GetAllBieuQuyetAsync(string text, int pageIndex, int pageSize, string customCode);
        Task<BieuQuyet> AddBieuQuyetAsync(BieuQuyet bq);
        Task<BieuQuyet> UpdateBieuQuyetAsync(BieuQuyet bq);
        Task<BieuQuyet> DeleteBieuQuyetAsync(BieuQuyet bq);
    }
}
