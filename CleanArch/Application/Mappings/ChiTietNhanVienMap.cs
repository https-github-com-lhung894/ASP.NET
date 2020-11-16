using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class ChiTietNhanVienMap
    {
        public static ChiTietNhanVienDTO ToDTO(this ChiTietNhanVien chiTietNhanVien)
        {
            return new ChiTietNhanVienDTO()
            {
                ChiTietNhanVienId = chiTietNhanVien.ChiTietNhanVienId,
                NgaySinh = chiTietNhanVien.NgaySinh,
                NoiSinh = chiTietNhanVien.NoiSinh,
                TrinhDoHocVan = chiTietNhanVien.TrinhDoHocVan,
                GioiTinh = chiTietNhanVien.GioiTinh,
                CMNN = chiTietNhanVien.CMNN,
                NgayCapCMNN = chiTietNhanVien.NgayCapCMNN,
                DiaChi = chiTietNhanVien.DiaChi,
                SDT = chiTietNhanVien.SDT,
                Email = chiTietNhanVien.Email,
                HinhAnh = chiTietNhanVien.HinhAnh,
                NhanVienId = chiTietNhanVien.NhanVienId
            };
        }
        public static List<ChiTietNhanVienDTO> ToListDTO(this List<ChiTietNhanVien> chiTietNhanViens)
        {
            List<ChiTietNhanVienDTO> chiTietNhanVienDTOs = new List<ChiTietNhanVienDTO>();
            foreach (ChiTietNhanVien chiTietNhanVien in chiTietNhanViens)
            {
                chiTietNhanVienDTOs.Add(chiTietNhanVien.ToDTO());
            }
            return chiTietNhanVienDTOs;
        }
        public static ChiTietNhanVien ToChiTietNhanVien(this ChiTietNhanVienDTO chiTietNhanVienDTO)
        {
            return new ChiTietNhanVien()
            {
                ChiTietNhanVienId = chiTietNhanVienDTO.ChiTietNhanVienId,
                NgaySinh = chiTietNhanVienDTO.NgaySinh,
                NoiSinh = chiTietNhanVienDTO.NoiSinh,
                TrinhDoHocVan = chiTietNhanVienDTO.TrinhDoHocVan,
                GioiTinh = chiTietNhanVienDTO.GioiTinh,
                CMNN = chiTietNhanVienDTO.CMNN,
                NgayCapCMNN = chiTietNhanVienDTO.NgayCapCMNN,
                DiaChi = chiTietNhanVienDTO.DiaChi,
                SDT = chiTietNhanVienDTO.SDT,
                Email = chiTietNhanVienDTO.Email,
                HinhAnh = chiTietNhanVienDTO.HinhAnh,
                NhanVienId = chiTietNhanVienDTO.NhanVienId
            };
        }
    }
}
