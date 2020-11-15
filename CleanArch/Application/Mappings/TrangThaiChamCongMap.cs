using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class TrangThaiChamCongMap
    {
        public static TrangThaiChamCongDTO ToDTO(this TrangThaiChamCong trangThaiChamCong)
        {
            return new TrangThaiChamCongDTO()
            {
                TrangThaiChamCongId = trangThaiChamCong.TrangThaiChamCongId,
                TenTrangThai = trangThaiChamCong.TenTrangThai,
                HSTrangThai = trangThaiChamCong.HSTrangThai
            };
        }
        public static List<TrangThaiChamCongDTO> ToListDTO(this List<TrangThaiChamCong> trangThaiChamCongs)
        {
            List<TrangThaiChamCongDTO> trangThaiChamCongDTOs = new List<TrangThaiChamCongDTO>();
            foreach (TrangThaiChamCong trangThaiChamCong in trangThaiChamCongs)
            {
                trangThaiChamCongDTOs.Add(trangThaiChamCong.ToDTO());
            }
            return trangThaiChamCongDTOs;
        }
        public static TrangThaiChamCong ToTrangThaiChamCong(this TrangThaiChamCongDTO trangThaiChamCongDTO)
        {
            return new TrangThaiChamCong()
            {
                TrangThaiChamCongId = trangThaiChamCongDTO.TrangThaiChamCongId,
                TenTrangThai = trangThaiChamCongDTO.TenTrangThai,
                HSTrangThai = trangThaiChamCongDTO.HSTrangThai
            };
        }
    }
}
