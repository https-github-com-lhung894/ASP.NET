﻿using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class LuongThangMap
    {
        public static LuongThangDTO ToDTO(this LuongThang luongThang, string hinhAnh, string hoTenNhanVien, string tenPhongBan)
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
                TienDuAn = luongThang.TienDuAn,
                NgayTinhLuong = luongThang.NgayTinhLuong,
                LuongThucLanh = luongThang.LuongThucLanh,
                NhanVienId = luongThang.NhanVienId,
                HinhAnh = hinhAnh,
                HoTenNhanVien = hoTenNhanVien,
                TenPhongBan = tenPhongBan
            };
        }
        public static List<LuongThangDTO> ToListDTO(this List<LuongThang> luongThangs, List<ChiTietNhanVien> chiTietNhanViens,
            List<NhanVien> nhanViens, List<PhongBan> phongBans, List<Account> accounts, string NhanVienId)
        {
            NhanVien nv = nhanViens.Find(x => x.NhanVienId == NhanVienId);
            Account ac = accounts.Find(x => x.AccountId == NhanVienId);

            List<LuongThangDTO> luongThangDTOs = new List<LuongThangDTO>();
            foreach (LuongThang luongThang in luongThangs)
            {
                NhanVien nv1 = nhanViens.Find(x => x.NhanVienId == luongThang.NhanVienId);
                if (nv1.PhongBanId != nv.PhongBanId && ac.Quyen == 1)
                {
                    continue;
                }

                ChiTietNhanVien chiTietNhanVien = chiTietNhanViens.Find(x => x.NhanVienId == luongThang.NhanVienId);
                NhanVien nhanVien = nhanViens.Find(x => x.NhanVienId == luongThang.NhanVienId);
                PhongBan phongBan = phongBans.Find(x => x.PhongBanId == nhanVien.PhongBanId);
                luongThangDTOs.Add(luongThang.ToDTO(chiTietNhanVien.HinhAnh,nhanVien.HoNhanVien + " " + nhanVien.TenNhanVien,phongBan.TenPhongBan));
            }
            return luongThangDTOs;
        }
        //Danh cho nhan vien
        public static List<LuongThangDTO> ToListDTO(this List<LuongThang> luongThangs, List<ChiTietNhanVien> chiTietNhanViens,
            List<NhanVien> nhanViens, List<PhongBan> phongBans, List<Account> accounts)
        {
            List<LuongThangDTO> luongThangDTOs = new List<LuongThangDTO>();
            foreach (LuongThang luongThang in luongThangs)
            {
                ChiTietNhanVien chiTietNhanVien = chiTietNhanViens.Find(x => x.NhanVienId == luongThang.NhanVienId);
                NhanVien nhanVien = nhanViens.Find(x => x.NhanVienId == luongThang.NhanVienId);
                PhongBan phongBan = phongBans.Find(x => x.PhongBanId == nhanVien.PhongBanId);
                luongThangDTOs.Add(luongThang.ToDTO(chiTietNhanVien.HinhAnh, nhanVien.HoNhanVien + " " + nhanVien.TenNhanVien, phongBan.TenPhongBan));
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
                TienDuAn = luongThangDTO.TienDuAn,
                NgayTinhLuong = luongThangDTO.NgayTinhLuong,
                LuongThucLanh = luongThangDTO.LuongThucLanh,
                NhanVienId = luongThangDTO.NhanVienId
            };
        }
    }
}
