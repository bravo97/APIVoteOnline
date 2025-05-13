using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Application;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models.DTO;
using VoteOnline.Domain.Models.Update;

namespace VoteOnline.Infratructure
{
    public class VanDeResponsitory : IVanDeReponsitory
    {
        private readonly VoteOnlineContext _authcontext;

        public VanDeResponsitory(VoteOnlineContext authcontext)
        {
            _authcontext = authcontext;
        }

        public async Task<VanDe?> GetVanDeByIDAsync(int ID)
        {
            return await _authcontext.VanDes
                .FirstOrDefaultAsync(c => c.Id == ID);
        }

        public async Task<VanDeDTO> AddVanDeAsync(VanDeDTO vanDe)
        {
            var newVD = new VanDe { 
                TenVd = vanDe.TenVD,
                MoTa = vanDe.Mota,
                NgayBatDau = vanDe.NgayBatDau,
                NgayKetThuc = vanDe.NgayKetThuc,
                IdMainAccount = vanDe.IdMainAccount,
                PhuongAns = vanDe.PhuongAns.Select(pA => new PhuongAn
                {
                    Ten = pA.Ten
                }).ToList()
            };

            var vande = await _authcontext.VanDes.AddAsync(newVD);
            await _authcontext.SaveChangesAsync();

            
            var rVD = new VanDeDTO
            {
                Id = newVD.Id,
                TenVD = newVD.TenVd,
                Mota = newVD.MoTa,
                NgayBatDau = newVD.NgayBatDau,
                NgayKetThuc = newVD.NgayKetThuc,
                PhuongAns = newVD.PhuongAns.Select(pA => new PhuongAnDTO
                {
                    Id = pA.Id,
                    Ten = pA.Ten
                }).ToList(),
            };

            return rVD;
        }

        public async Task<bool> DeleteVanDeAsync(VanDeDTO vanDe)
        {
            var exVD = await GetVanDeByIDAsync(vanDe.Id);
            if (exVD != null) { 
                _authcontext.Entry(exVD).State = EntityState.Detached;
                _authcontext.Remove(exVD);
                await _authcontext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<VanDeDTO>> GetAllVanDeAsync( int pageIndex, int pageSize, int IdAccount)
        {
            var vande = await _authcontext.VanDes
                    .Select(v => new VanDeDTO
                    {
                        Id = v.Id,
                        TenVD = v.TenVd,
                        Mota = v.MoTa,
                        NgayBatDau = v.NgayBatDau,
                        NgayKetThuc = v.NgayKetThuc,
                        Code = v.Code,
                        PhuongAns = v.PhuongAns.Select(p => new PhuongAnDTO
                        {
                            Id = p.Id,
                            Ten = p.Ten
                        }).ToList()
                    })
                    .ToListAsync();

            return vande;
        }

        public async Task<bool> UpdateVanDeAsync(VanDeDTO vanDe)
        {
            var exVD = await GetVanDeByIDAsync(vanDe.Id);
            if (exVD != null) { 
                exVD.TenVd = vanDe.TenVD;
                exVD.MoTa = vanDe.Mota;
                exVD.NgayBatDau = (DateTime)vanDe.NgayBatDau;
                exVD.NgayKetThuc = (DateTime)vanDe.NgayKetThuc;

                _authcontext.Entry(exVD).State = EntityState.Modified;
                await _authcontext.SaveChangesAsync();

                return true;
            }

            return false;

        }

        public async Task<bool> CreateLinkAsync(VanDeID vanDe)
        {
            var ListID = await _authcontext.VanDes
                .Where(vd => vanDe.ListID.Contains(vd.Id))
                .ExecuteUpdateAsync(ballots => ballots.SetProperty(v => v.Code, vanDe.Code));

            return true;
        }

        public async Task<List<VanDeDTO>> GetVanDeByCodeAsync(string vanDe)
        {
            var vande = await _authcontext.VanDes
                    .Select(v => new VanDeDTO
                    {
                        Id = v.Id,
                        TenVD = v.TenVd,
                        Mota = v.MoTa,
                        NgayBatDau = v.NgayBatDau,
                        NgayKetThuc = v.NgayKetThuc,
                        Code = v.Code,
                        PhuongAns = v.PhuongAns.Select(p => new PhuongAnDTO
                        {
                            Id = p.Id,
                            Ten = p.Ten
                        }).ToList()
                    })
                    .Where(v => v.Code == vanDe)
                    .ToListAsync();

            return vande;
        }
    }
}
