using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class QuanLyNhanVienMap
    {
        public static (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, string luongCanBan) ToObjs(this QuanLyNhanVien quanLyNhanVien)
        {
            return (
                new Account()
                {
                    AccountId = quanLyNhanVien.NhanVienId,
                    TaiKhoan = quanLyNhanVien.TaiKhoan,
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
                    NhanVienId = quanLyNhanVien.NhanVienId,
                    NgaySinh = DateTime.Parse(quanLyNhanVien.NgaySinh),
                    NoiSinh = quanLyNhanVien.NoiSinh,
                    TrinhDoHocVan = quanLyNhanVien.TrinhDoHocVan,
                    GioiTinh = quanLyNhanVien.GioiTinh,
                    CMND = quanLyNhanVien.CMND,
                    NgayCapCMND = DateTime.Parse(quanLyNhanVien.NgayCapCMND),
                    DiaChi = quanLyNhanVien.DiaChi,
                    SDT = quanLyNhanVien.SDT,
                    Email = quanLyNhanVien.Email,
                    HinhAnh = quanLyNhanVien.HinhAnh
                },
                quanLyNhanVien.CongViecId,
                quanLyNhanVien.LuongCanBan);
        }
        
        public static QuanLyNhanVien ToDTO(NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, PhongBan phongBan,
            ChucVu chucVu, CongViec congViec, HopDong hopDong, Account account)
        {
            if (account == null)
            {
                account = new Account();
            }
            if (chiTietNhanVien == null)
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
            if (hopDong == null)
            {
                hopDong = new HopDong();
            }
            return new QuanLyNhanVien()
            {
                NhanVienId = nhanVien.NhanVienId,
                HoNhanVien = nhanVien.HoNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,

                PhongBanId = phongBan.PhongBanId,
                TenPhongBan = phongBan.TenPhongBan,

                ChucVuId = chucVu.ChucVuId,
                TenChucVu = chucVu.TenChucVu,

                CongViecId = congViec.CongViecId,
                TenCongViec = congViec.TenCongViec,
                LuongCanBan = hopDong.LuongCanBan,

                NgaySinh = chiTietNhanVien.NgaySinh.ToString(),
                NoiSinh = chiTietNhanVien.NoiSinh,
                TrinhDoHocVan = chiTietNhanVien.TrinhDoHocVan,
                GioiTinh = chiTietNhanVien.GioiTinh,
                CMND = chiTietNhanVien.CMND,
                NgayCapCMND = chiTietNhanVien.NgayCapCMND.ToString(),
                DiaChi = chiTietNhanVien.DiaChi,
                SDT = chiTietNhanVien.SDT,
                Email = chiTietNhanVien.Email,
                HinhAnh = chiTietNhanVien.HinhAnh,

                TaiKhoan = account.TaiKhoan,
                Quyen = account.Quyen,
                MatKhau = account.MatKhau,
            };
        }
        
        public static List<QuanLyNhanVien> ToListDTOs(string NhanVienId, List<NhanVien> nhanViens, List<ChiTietNhanVien> chiTietNhanViens, 
            List<PhongBan> phongBans, List<ChucVu> chucVus, List<NhanVienCongViec> nhanVienCongViecs, List<CongViec> congViecs, 
            List<HopDong> hopDongs, List<Account> accounts)
        {
            //Dữ liệu kiểm tra phong ban
            Account ac = accounts.Find(x => x.AccountId == NhanVienId);
            NhanVien nv = nhanViens.Find(x => x.NhanVienId == NhanVienId);

            List<QuanLyNhanVien> listQLNV = new List<QuanLyNhanVien>();
            foreach(NhanVien nhanVien in nhanViens)
            {
                //Tìm từng đứa một để chuyển qua DTO đưa lên cho người dùng xem
                if(nhanVien.TrangThai == 0)
                {
                    continue;
                }
                PhongBan phongBan = phongBans.Find(x => x.PhongBanId == nhanVien.PhongBanId);
                if(phongBan.PhongBanId != nv.PhongBanId && ac.Quyen == 1)
                {
                    continue;
                }
                ChiTietNhanVien chiTietNhanVien = chiTietNhanViens.Find(x => x.ChiTietNhanVienId == nhanVien.NhanVienId);
                ChucVu chucVu = chucVus.Find(x => x.ChucVuId == nhanVien.ChucVuId);
                //Tìm công việc hiện tại ứng với nhân viên
                NhanVienCongViec nhanVienCongViec = nhanVienCongViecs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.NgayKetThuc == null);
                CongViec congViec = null;
                if (nhanVienCongViec != null)
                {
                    congViec = congViecs.Find(x => x.CongViecId == nhanVienCongViec.CongViecId);
                }
                //Tìm hợp đồng hiện tại ứng với nhân viên
                HopDong hopDong = hopDongs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.TrangThai == 1);
                Account account = accounts.Find(x => x.AccountId == nhanVien.NhanVienId);

                //Chuyển thành DTO
                listQLNV.Add(ToDTO(nhanVien, chiTietNhanVien, phongBan, chucVu, congViec, hopDong, account));
            }
            return listQLNV;
        }

        public static List<QuanLyNhanVien> ToListNVPBDTOs(List<NhanVien> nhanViens, List<ChiTietNhanVien> chiTietNhanViens,
            List<PhongBan> phongBans, List<ChucVu> chucVus, List<NhanVienCongViec> nhanVienCongViecs, List<CongViec> congViecs,
            List<HopDong> hopDongs, List<Account> accounts, string id)
        {
            List<QuanLyNhanVien> listNVPB = new List<QuanLyNhanVien>();
            foreach (NhanVien nhanVien in nhanViens)
            {
                //Tìm từng đứa một để chuyển qua DTO đưa lên cho người dùng xem
                if (nhanVien.TrangThai == 0 || nhanVien.PhongBanId != id)
                {
                    continue;
                }
                ChiTietNhanVien chiTietNhanVien = chiTietNhanViens.Find(x => x.ChiTietNhanVienId == nhanVien.NhanVienId);
                PhongBan phongBan = phongBans.Find(x => x.PhongBanId == nhanVien.PhongBanId);
                ChucVu chucVu = chucVus.Find(x => x.ChucVuId == nhanVien.ChucVuId);
                //Tìm công việc hiện tại ứng với nhân viên
                NhanVienCongViec nhanVienCongViec = nhanVienCongViecs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.NgayKetThuc == null);
                CongViec congViec = null;
                if (nhanVienCongViec != null)
                {
                    congViec = congViecs.Find(x => x.CongViecId == nhanVienCongViec.CongViecId);
                }
                //Tìm hợp đồng hiện tại ứng với nhân viên
                HopDong hopDong = hopDongs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.TrangThai == 1);
                Account account = accounts.Find(x => x.AccountId == nhanVien.NhanVienId);

                //Chuyển thành DTO
                listNVPB.Add(ToDTO(nhanVien, chiTietNhanVien, phongBan, chucVu, congViec, hopDong, account));
            }
            return listNVPB;
        }

    }
}
