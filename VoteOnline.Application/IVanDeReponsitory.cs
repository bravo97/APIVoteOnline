using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models.DTO;
using VoteOnline.Domain.Models.Update;

namespace VoteOnline.Application
{
    public interface IVanDeReponsitory
    {
        Task<List<VanDeDTO>> GetAllVanDeAsync( int pageIndex, int pageSize, int IdAccount);
        Task<List<VanDeDTO>> GetVanDeByCodeAsync(string vanDe);
        Task<VanDeDTO> AddVanDeAsync(VanDeDTO vanDe);
        Task<bool> UpdateVanDeAsync(VanDeDTO vanDe);
        Task<bool> CreateLinkAsync(VanDeID vanDe);
        Task<bool> DeleteVanDeAsync(VanDeDTO vanDe);
    }
}
