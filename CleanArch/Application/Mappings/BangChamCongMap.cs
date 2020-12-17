using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class BangChamCongMap
    {
        public static BangChamCongDTO ToDTO(this BangChamCong bangChamCong)
        {
            return new BangChamCongDTO()
            {
                BangChamCongId = bangChamCong.BangChamCongId,
                NgayLamViec = bangChamCong.NgayLamViec,
                TrangThaiChamCongId = bangChamCong.TrangThaiChamCongId,
                NhanVienId = bangChamCong.NhanVienId
            };
        }

        public static List<BangChamCongDTO> ToListDTO(this List<BangChamCong> bangChamCongs, string NhanVienId, 
            List<NhanVien> nhanViens, List<Account> accounts)
        {
            NhanVien nv = nhanViens.Find(x => x.NhanVienId == NhanVienId);
            Account ac = accounts.Find(x => x.AccountId == NhanVienId);

            List<BangChamCongDTO> bangChamCongDTOs = new List<BangChamCongDTO>();
            foreach (BangChamCong bangChamCong in bangChamCongs)
            {
                NhanVien nv1 = nhanViens.Find(x => x.NhanVienId == bangChamCong.NhanVienId);
                if(nv1.PhongBanId != nv.PhongBanId && ac.Quyen == 1)
                {
                    continue;
                }

                bangChamCongDTOs.Add(bangChamCong.ToDTO());
            }
            return bangChamCongDTOs;
        }
        public static List<BangChamCongDTO> ToListDTO(this List<BangChamCong> bangChamCongs, List<NhanVien> nhanViens)
        {
            List<BangChamCongDTO> bangChamCongDTOs = new List<BangChamCongDTO>();
            foreach (BangChamCong bangChamCong in bangChamCongs)
            {
                NhanVien nv1 = nhanViens.Find(x => x.NhanVienId == bangChamCong.NhanVienId);
                if (nv1.TrangThai != 1)
                {
                    continue;
                }

                bangChamCongDTOs.Add(bangChamCong.ToDTO());
            }
            return bangChamCongDTOs;
        }
        public static BangChamCong ToBangChamCong(this BangChamCongDTO bangChamCongDTO)
        {
            return new BangChamCong()
            {
                BangChamCongId = bangChamCongDTO.BangChamCongId,
                NgayLamViec = bangChamCongDTO.NgayLamViec,
                TrangThaiChamCongId = bangChamCongDTO.TrangThaiChamCongId,
                NhanVienId = bangChamCongDTO.NhanVienId,
            };
        }
    }
}
