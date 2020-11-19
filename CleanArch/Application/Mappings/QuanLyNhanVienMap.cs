using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class QuanLyNhanVienMap
    {
        public static (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien) ToObjs(this DTOs.QuanLyNhanVien quanLyNhanVien)
        {
            return (
                new Account()
                {
                    AccountId = quanLyNhanVien.NhanVienId,
                    TaiKhoan = quanLyNhanVien.NhanVienId,
                    MatKhau = quanLyNhanVien.MatKhau,
                    Quyen = quanLyNhanVien.Quyen,
                },
                new NhanVien()
                {
                    NhanVienId = quanLyNhanVien.NhanVienId,
                    HoNhanVien = quanLyNhanVien.HoNhanVien,
                    TenNhanVien = quanLyNhanVien.TenNhanVien,
                    PhongBanId = quanLyNhanVien.PhongBanId,
                    ChucVuId = quanLyNhanVien.ChucVuId,
                    AccountId = quanLyNhanVien.NhanVienId
                },
                new ChiTietNhanVien()
                {
                    ChiTietNhanVienId = quanLyNhanVien.NhanVienId,
                    NgaySinh = quanLyNhanVien.NgaySinh,
                    NoiSinh = quanLyNhanVien.NoiSinh,
                    TrinhDoHocVan = quanLyNhanVien.TrinhDoHocVan,
                    GioiTinh = quanLyNhanVien.GioiTinh,
                    CMND = quanLyNhanVien.CMND,
                    NgayCapCMND = quanLyNhanVien.NgayCapCMND,
                    DiaChi = quanLyNhanVien.DiaChi,
                    SDT = quanLyNhanVien.SDT,
                    Email = quanLyNhanVien.Email,
                    HinhAnh = quanLyNhanVien.HinhAnh
                });
        }
        public static QuanLyNhanVien ToDTO(NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien,PhongBan phongBan,
            ChucVu chucVu, CongViec congViec, LuongThang luongThang)
        {
            if(chiTietNhanVien == null)
            {
                chiTietNhanVien = new ChiTietNhanVien();
            }
            if(phongBan == null)
            {
                phongBan = new PhongBan();
            }
            if(chucVu == null)
            {
                chucVu = new ChucVu();
            }
            if(congViec == null)
            {
                congViec = new CongViec();
            }
            if(luongThang == null)
            {
                luongThang = new LuongThang();
            }
            return (new QuanLyNhanVien() 
            {
                NhanVienId = nhanVien.NhanVienId,
                HoNhanVien = nhanVien.HoNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,

                PhongBanId = phongBan.PhongBanId,
                TenPhongBan = phongBan.TenPhongBan,

                ChucVuId = chucVu.ChucVuId,
                TenChuVu = chucVu.TenChucVu,

                CongViecId = congViec.CongViecId,
                TenCongViec = congViec.TenCongViec,

                NgaySinh = chiTietNhanVien.NgaySinh,
                NoiSinh = chiTietNhanVien.NoiSinh,
                TrinhDoHocVan = chiTietNhanVien.TrinhDoHocVan,
                GioiTinh = chiTietNhanVien.GioiTinh,
                CMND = chiTietNhanVien.CMND,
                NgayCapCMND = chiTietNhanVien.NgayCapCMND,
                DiaChi = chiTietNhanVien.DiaChi,
                SDT = chiTietNhanVien.SDT,
                Email = chiTietNhanVien.Email,
                HinhAnh = chiTietNhanVien.HinhAnh,

                LuongCanBan = luongThang.LuongThucLanh
            });
        }
        public static List<QuanLyNhanVien> ToListDTOs(List<NhanVien> nhanViens, List<ChiTietNhanVien> chiTietNhanViens, List<PhongBan> phongBans, 
            List<ChucVu> chucVus, List<NhanVienCongViec> nhanVienCongViecs, List<CongViec> congViecs, List<LuongThang> luongThangs)
        {
            List<QuanLyNhanVien> listQLNV = new List<QuanLyNhanVien>();
            foreach(NhanVien nhanVien in nhanViens)
            {
                if(nhanVien.TrangThai == 0)
                {
                    continue;
                }
                ChiTietNhanVien chiTietNhanVien = chiTietNhanViens.Find(x => x.ChiTietNhanVienId == nhanVien.NhanVienId);
                PhongBan phongBan = phongBans.Find(x => x.PhongBanId == nhanVien.PhongBanId);
                ChucVu chucVu = chucVus.Find(x => x.ChucVuId == nhanVien.ChucVuId);
                NhanVienCongViec nhanVienCongViec = nhanVienCongViecs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.NgayKetThuc == null);
                CongViec congViec = null;
                if (nhanVienCongViec != null)
                {
                    congViec = congViecs.Find(x => x.CongViecId == nhanVienCongViec.CongViecId);
                }
                LuongThang luongThang = luongThangs.Find(x => x.NhanVienId == nhanVien.NhanVienId);

                listQLNV.Add(ToDTO(nhanVien, chiTietNhanVien, phongBan, chucVu, congViec, luongThang));
            }
            return listQLNV;
        }
    }
}
