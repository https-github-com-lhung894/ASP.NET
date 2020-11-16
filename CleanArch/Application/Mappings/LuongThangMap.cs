using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class LuongThangMap
    {
        public static LuongThangDTO ToDTO(this LuongThang luongThang)
        {
            return new LuongThangDTO()
            {
                LuongThangId = luongThang.LuongThangId,
                LuongCoBan = luongThang.LuongCoBan,
                HSChucVu = luongThang.HSChucVu,
                HSCongViec = luongThang.HSCongViec,
                SoNgayLam = luongThang.SoNgayLam,
                SoNgayNghiCoPhep = luongThang.SoNgayNghiCoPhep,
                SoNgayNghiKhongPhep = luongThang.SoNgayNghiKhongPhep,
                SoNgayNghiOm = luongThang.SoNgayNghiOm,
                PhuCapNhanVien = luongThang.PhuCapNhanVien,
                ThuongLe = luongThang.ThuongLe,
                PhuCapChucVu = luongThang.PhuCapChucVu,
                PhuCapThamNien = luongThang.PhuCapThamNien,
                TienDa = luongThang.TienDa,
                LuongThucLanh = luongThang.LuongThucLanh,
                NhanVienId = luongThang.NhanVienId
            };
        }
        public static List<LuongThangDTO> ToListDTO(this List<LuongThang> luongThangs)
        {
            List<LuongThangDTO> luongThangDTOs = new List<LuongThangDTO>();
            foreach (LuongThang luongThang in luongThangs)
            {
                luongThangDTOs.Add(luongThang.ToDTO());
            }
            return luongThangDTOs;
        }
        public static LuongThang ToLuongThang(this LuongThangDTO luongThangDTO)
        {
            return new LuongThang()
            {
                LuongThangId = luongThangDTO.LuongThangId,
                LuongCoBan = luongThangDTO.LuongCoBan,
                HSChucVu = luongThangDTO.HSChucVu,
                HSCongViec = luongThangDTO.HSCongViec,
                SoNgayLam = luongThangDTO.SoNgayLam,
                SoNgayNghiCoPhep = luongThangDTO.SoNgayNghiCoPhep,
                SoNgayNghiKhongPhep = luongThangDTO.SoNgayNghiKhongPhep,
                SoNgayNghiOm = luongThangDTO.SoNgayNghiOm,
                PhuCapNhanVien = luongThangDTO.PhuCapNhanVien,
                ThuongLe = luongThangDTO.ThuongLe,
                PhuCapChucVu = luongThangDTO.PhuCapChucVu,
                PhuCapThamNien = luongThangDTO.PhuCapThamNien,
                TienDa = luongThangDTO.TienDa,
                LuongThucLanh = luongThangDTO.LuongThucLanh,
                NhanVienId = luongThangDTO.NhanVienId
            };
        }
    }
}
