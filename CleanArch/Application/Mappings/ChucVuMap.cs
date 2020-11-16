using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class ChucVuMap
    {
        public static ChucVuDTO ToDTO(this ChucVu chucVu)
        {
            return new ChucVuDTO()
            {
                ChucVuId = chucVu.ChucVuId,
                TenChucVu = chucVu.TenChucVu,
                HSChucVu = chucVu.HSChucVu,
                TienPhuCapChuVu = chucVu.TienPhuCapChuVu
            };
        }
        public static List<ChucVuDTO> ToListDTO(this List<ChucVu> chucVus)
        {
            List<ChucVuDTO> chucVuDTOs = new List<ChucVuDTO>();
            foreach (ChucVu chucVu in chucVus)
            {
                chucVuDTOs.Add(chucVu.ToDTO());
            }
            return chucVuDTOs;
        }
        public static ChucVu ToChucVu(this ChucVuDTO chucVuDTO)
        {
            return new ChucVu()
            {
                ChucVuId = chucVuDTO.ChucVuId,
                TenChucVu = chucVuDTO.TenChucVu,
                HSChucVu = chucVuDTO.HSChucVu,
                TienPhuCapChuVu = chucVuDTO.TienPhuCapChuVu
            };
        }
    }
}
