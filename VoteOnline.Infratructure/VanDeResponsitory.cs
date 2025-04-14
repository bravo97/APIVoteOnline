using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoteOnline.Application;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models.Update;
using VoteOnline.Domain.Models.View;

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

        public async Task<VanDeModel> AddVanDeAsync(VanDeModelUpdate vanDe)
        {
            var newVD = new VanDe { 
                TenVd = vanDe.TenVD,
                MoTa = vanDe.Mota,
                NgayBatDau = vanDe.NgayBatDau,
                NgayKetThuc = vanDe.NgayKetThuc,
                IddinhDang = vanDe.DinhDang,
                IdMainAccount = vanDe.MainAccount
            };

            var vande = await _authcontext.VanDes.AddAsync(newVD);
            await _authcontext.SaveChangesAsync();

            var rVD = new VanDeModel
            {
                Id = newVD.Id,
                TenVD = newVD.TenVd,
                Mota = newVD.MoTa,
                NgayBatDau = newVD.NgayBatDau,
                NgayKetThuc = newVD.NgayKetThuc,
                DinhDang = "",
                MainAccount = ""
            };

            return rVD;
        }

        public async Task<bool> DeleteVanDeAsync(VanDeModelUpdate vanDe)
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

        public async Task<List<VanDeModel>> GetAllVanDeAsync( int pageIndex, int pageSize, int IdAccount)
        {
            var vande = await _authcontext.VanDes
            .GroupJoin(_authcontext.DinhDangs,
                vd => vd.IddinhDang,
                dd => dd.Id,
                (vd, dd) => new { vd, dd })
            .SelectMany(uo => uo.dd.DefaultIfEmpty(),
                (uo, o) => new { uo.vd, o })
            .GroupJoin(_authcontext.MainAccounts,
                uo => uo.vd.IdMainAccount,
                us => us.Id,
                (uo, MainAccount) => new { uo.vd, uo.o, MainAccount })
            .SelectMany(uod => uod.MainAccount.DefaultIfEmpty(),
                (uod, od) => new
                {
                    Id = uod.vd.Id,
                    TenVD = uod.vd.TenVd,
                    Mota = uod.vd.MoTa,
                    NgayBatdau = uod.vd.NgayBatDau,
                    NgayKetThuc = uod.vd.NgayKetThuc,
                    TenDinhDang = uod.o.Ma,
                    IdMainAccount = uod.vd.IdMainAccount,
                    IdDinhDang = uod.o.Id,
                    TaiKhoan = od.HoTen
                })
            .Where(vd => vd.IdMainAccount == IdAccount)
            .Select(s => new VanDeModel
            {
                Id = s.Id,
                TenVD = s.TenVD,
                Mota = s.Mota,
                NgayBatDau = s.NgayBatdau,
                NgayKetThuc = s.NgayKetThuc,
                DinhDang = s.TenDinhDang,
                MainAccount = s.TaiKhoan,
                IdDinhDang = s.IdDinhDang,
                IdMainAccount = s.IdMainAccount
            })
           
            .ToListAsync();

            return vande;
        }

        public async Task<bool> UpdateVanDeAsync(VanDeModelUpdate vanDe)
        {
            var exVD = await GetVanDeByIDAsync(vanDe.Id);
            if (exVD != null) { 
                exVD.TenVd = vanDe.TenVD;
                exVD.MoTa = vanDe.Mota;
                exVD.NgayBatDau = (DateTime)vanDe.NgayBatDau;
                exVD.NgayKetThuc = (DateTime)vanDe.NgayKetThuc;
                exVD.IddinhDang = vanDe.DinhDang;

                _authcontext.Entry(exVD).State = EntityState.Modified;
                await _authcontext.SaveChangesAsync();

                return true;
            }

            return false;

        }
    }
}
