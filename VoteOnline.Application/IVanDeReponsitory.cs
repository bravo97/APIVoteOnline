using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models.Update;
using VoteOnline.Domain.Models.View;

namespace VoteOnline.Application
{
    public interface IVanDeReponsitory
    {
        Task<List<VanDeModel>> GetAllVanDeAsync( int pageIndex, int pageSize, int IdAccount);
        Task<VanDeModel> AddVanDeAsync(VanDeModelUpdate vanDe);
        Task<bool> UpdateVanDeAsync(VanDeModelUpdate vanDe);
        Task<bool> DeleteVanDeAsync(VanDeModelUpdate vanDe);
    }
}
