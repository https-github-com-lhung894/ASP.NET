using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class NhanVienMap
    {
        public static NhanVienDTO ToDTO(this NhanVien nhanVien)
        {
            return nhanVien == null ? null : new NhanVienDTO()
            {
                NhanVienId = nhanVien.NhanVienId,
                HoNhanVien = nhanVien.HoNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,
                PhongBanId = nhanVien.PhongBanId,
                ChucVuId = nhanVien.ChucVuId,
                AccountId = nhanVien.AccountId
            };
        }
        public static List<NhanVienDTO> ToListDTO(this List<NhanVien> nhanViens)
        {
            List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();
            foreach (NhanVien nhanVien in nhanViens)
            {
                nhanVienDTOs.Add(nhanVien.ToDTO());
            }
            return nhanVienDTOs;
        }
        public static NhanVien ToNhanVien(this NhanVienDTO nhanVienDTO)
        {
            return nhanVienDTO == null ? null : new NhanVien()
            {
                NhanVienId = nhanVienDTO.NhanVienId,
                HoNhanVien = nhanVienDTO.HoNhanVien,
                TenNhanVien = nhanVienDTO.TenNhanVien,
                PhongBanId = nhanVienDTO.PhongBanId,
                ChucVuId = nhanVienDTO.ChucVuId,
                AccountId = nhanVienDTO.AccountId
            };
        }
    }
}
