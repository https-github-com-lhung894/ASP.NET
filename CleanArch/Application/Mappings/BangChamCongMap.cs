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

        public static List<BangChamCongDTO> ToListDTO(this List<BangChamCong> bangChamCongs)
        {
            List<BangChamCongDTO> bangChamCongDTOs = new List<BangChamCongDTO>();
            foreach (BangChamCong bangChamCong in bangChamCongs)
            {
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
