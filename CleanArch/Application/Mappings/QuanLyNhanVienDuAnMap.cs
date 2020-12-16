using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class QuanLyNhanVienDuAnMap
    {
        public static QuanLyNhanVienDuAn ToDTO(NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien,
            PhongBan phongBan, ChucVu chucVu, NhanVienDuAn nhanVienDuAn)
        {
            if (nhanVienDuAn == null)
            {
                nhanVienDuAn = new NhanVienDuAn();
            }
            if (chiTietNhanVien == null)
            {
                chiTietNhanVien = new ChiTietNhanVien();
            }
            if (chucVu == null)
            {
                chucVu = new ChucVu();
            }
            if (phongBan == null)
            {
                phongBan = new PhongBan();
            }
            return new QuanLyNhanVienDuAn()
            {
                NhanVienId = nhanVien.NhanVienId,
                HoNhanVien = nhanVien.HoNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,

                PhongBanId = phongBan.PhongBanId,
                TenPhongBan = phongBan.TenPhongBan,

                ChucVuId = chucVu.ChucVuId,
                TenChucVu = chucVu.TenChucVu,

                NhanVienDuAnId = nhanVienDuAn.NhanVienDuAnId,
                PhanTramCV = nhanVienDuAn.PhanTramCV,

                HinhAnh = chiTietNhanVien.HinhAnh,
            };
        }

        public static List<QuanLyNhanVienDuAn> ToListNVDADTOs(List<NhanVien> nhanViens, List<ChiTietNhanVien> chiTietNhanViens,
            List<PhongBan> phongBans, List<ChucVu> chucVus, List<NhanVienDuAn> nhanVienDuAns,
            string NhanVienIdToKen, List<Account> accounts, string DuAnId)
        {
            NhanVien nv = nhanViens.Find(x => x.NhanVienId == NhanVienIdToKen);
            Account ac = accounts.Find(x => x.AccountId == NhanVienIdToKen);

            List<QuanLyNhanVienDuAn> listNVDA = new List<QuanLyNhanVienDuAn>();
            foreach (NhanVienDuAn nhanVienDuAn in nhanVienDuAns)
            {
                if (nhanVienDuAn.DuAnId != DuAnId)
                {
                    continue;
                }
                PhongBan phongBan = null;
                ChucVu chucVu = null;
                ChiTietNhanVien chiTietNhanVien = null;
                NhanVien nhanVien = nhanViens.Find(x => x.NhanVienId == nhanVienDuAn.NhanVienId);
                //Quyền của nhân viên được xem hay ko
                if (nhanVien.PhongBanId != nv.PhongBanId && ac.Quyen == 1)
                {
                    continue;
                }
                if (nhanVien != null)
                {
                    phongBan = phongBans.Find(x => x.PhongBanId == nhanVien.PhongBanId);
                    chucVu = chucVus.Find(x => x.ChucVuId == nhanVien.ChucVuId);
                    chiTietNhanVien = chiTietNhanViens.Find(x => x.ChiTietNhanVienId == nhanVien.NhanVienId);
                }
                listNVDA.Add(ToDTO(nhanVien, chiTietNhanVien, phongBan, chucVu, nhanVienDuAn));
            }
            return listNVDA;
        }
    }
}
