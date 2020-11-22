using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class QuanLyNhanVienMap
    {
        public static (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, double? luongCanBan) ToObjs(this AddNhanVien addNhanVien)
        {
            return (
                new Account()
                {
                    AccountId = addNhanVien.NhanVienId,
                    TaiKhoan = addNhanVien.TaiKhoan,
                    MatKhau = addNhanVien.MatKhau,
                    Quyen = addNhanVien.Quyen,
                },
                new NhanVien()
                {
                    NhanVienId = addNhanVien.NhanVienId,
                    HoNhanVien = addNhanVien.HoNhanVien,
                    TenNhanVien = addNhanVien.TenNhanVien,
                    PhongBanId = addNhanVien.PhongBanId,
                    ChucVuId = addNhanVien.ChucVuId,
                    AccountId = addNhanVien.NhanVienId
                },
                new ChiTietNhanVien()
                {
                    ChiTietNhanVienId = addNhanVien.NhanVienId,
                    NhanVienId = addNhanVien.NhanVienId,
                    NgaySinh = DateTime.Parse(addNhanVien.NgaySinh),
                    NoiSinh = addNhanVien.NoiSinh,
                    TrinhDoHocVan = addNhanVien.TrinhDoHocVan,
                    GioiTinh = addNhanVien.GioiTinh,
                    CMND = addNhanVien.CMND,
                    NgayCapCMND = DateTime.Parse(addNhanVien.NgayCapCMND),
                    DiaChi = addNhanVien.DiaChi,
                    SDT = addNhanVien.SDT,
                    Email = addNhanVien.Email,
                    HinhAnh = addNhanVien.HinhAnh
                },
                addNhanVien.CongViecId,
                addNhanVien.LuongCanBan);
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
