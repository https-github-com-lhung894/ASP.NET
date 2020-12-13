using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class QuanLyHopDongMap
    {
        public static QuanLyHopDong ToDTO(NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien,
            ChucVu chucVu, CongViec congViec, NhanVienCongViec nhanVienCongViec, HopDong hopDong)
        {
            if (nhanVienCongViec == null)
            {
                nhanVienCongViec = new NhanVienCongViec();
            }
            if (chiTietNhanVien == null)
            {
                chiTietNhanVien = new ChiTietNhanVien();
            }
            if (chucVu == null)
            {
                chucVu = new ChucVu();
            }
            if (congViec == null)
            {
                congViec = new CongViec();
            }
            if (hopDong == null)
            {
                hopDong = new HopDong();
            }
            return new QuanLyHopDong()
            {
                NhanVienId = nhanVien.NhanVienId,
                HoNhanVien = nhanVien.HoNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,

                HopDongId = hopDong.HopDongId,
                NgayKyHopDong = hopDong.NgayKyHopDong,
                TrangThai = hopDong.TrangThai,
                LuongCanBan = hopDong.LuongCanBan,

                ChucVuId = chucVu.ChucVuId,
                TenChucVu = chucVu.TenChucVu,

                CongViecId = congViec.CongViecId,
                TenCongViec = congViec.TenCongViec,

                NgayBatDau = nhanVienCongViec.NgayBatDau,
                NgayKetThuc = nhanVienCongViec.NgayKetThuc,

                HinhAnh = chiTietNhanVien.HinhAnh,

            };
        }

        public static List<QuanLyHopDong> ToListNVHDDTOs(List<NhanVien> nhanViens, List<ChiTietNhanVien> chiTietNhanViens,
            List<ChucVu> chucVus, List<NhanVienCongViec> nhanVienCongViecs, List<CongViec> congViecs,
            List<HopDong> hopDongs)
        {
            List<QuanLyHopDong> listNVHD = new List<QuanLyHopDong>();
            foreach (HopDong hopDong in hopDongs)
            {
                ChucVu chucVu = null;
                NhanVienCongViec nhanVienCongViec = null;
                CongViec congViec = null;
                ChiTietNhanVien chiTietNhanVien = null;
                NhanVien nhanVien = nhanViens.Find(x => x.NhanVienId == hopDong.NhanVienId);
                if (nhanVien != null)
                {
                    chucVu = chucVus.Find(x => x.ChucVuId == nhanVien.ChucVuId);
                    //Tìm công việc hiện tại ứng với nhân viên
                    if(hopDong.TrangThai == 1)
                    {
                        nhanVienCongViec = nhanVienCongViecs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.NgayKetThuc == null);
                    }
                    else
                    {
                        nhanVienCongViec = nhanVienCongViecs.Find(x => x.NhanVienId == nhanVien.NhanVienId && x.NgayKetThuc != null);
                    }
                    if (nhanVienCongViec != null)
                    {
                        congViec = congViecs.Find(x => x.CongViecId == nhanVienCongViec.CongViecId);
                    }
                    chiTietNhanVien = chiTietNhanViens.Find(x => x.ChiTietNhanVienId == nhanVien.NhanVienId);
                }
                listNVHD.Add(ToDTO(nhanVien, chiTietNhanVien, chucVu, congViec, nhanVienCongViec, hopDong));
            }
            return listNVHD;
        }
    }
}
