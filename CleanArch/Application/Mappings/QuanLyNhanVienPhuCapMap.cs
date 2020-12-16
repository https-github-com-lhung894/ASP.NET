using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class QuanLyNhanVienPhuCapMap
    {
        
        public static QuanLyNhanVienPhuCap ToDTO(NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, 
            PhongBan phongBan,ChucVu chucVu, NhanVienPhuCap nhanVienPhuCap)
        {
            if (nhanVienPhuCap == null)
            {
                nhanVienPhuCap = new NhanVienPhuCap();
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
            return new QuanLyNhanVienPhuCap()
            {
                NhanVienId = nhanVien.NhanVienId,
                HoNhanVien = nhanVien.HoNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,

                PhongBanId = phongBan.PhongBanId,
                TenPhongBan = phongBan.TenPhongBan,

                ChucVuId = chucVu.ChucVuId,
                TenChucVu = chucVu.TenChucVu,
                HinhAnh = chiTietNhanVien.HinhAnh,
                NhanVienPhuCapId = nhanVienPhuCap.NhanVienPhuCapId,
            };
        }

        public static List<QuanLyNhanVienPhuCap> ToListNVPCDTOs(List<NhanVien> nhanViens, List<ChiTietNhanVien> chiTietNhanViens,
             List<PhongBan> phongBans, List<ChucVu> chucVus, List<NhanVienPhuCap> nhanVienPhuCaps,
             string NhanVienIdToKen, List<Account> accounts, string PhuCapId)
        {
            NhanVien nv = nhanViens.Find(x => x.NhanVienId == NhanVienIdToKen);
            Account ac = accounts.Find(x => x.AccountId == NhanVienIdToKen);

            List<QuanLyNhanVienPhuCap> listNVDA = new List<QuanLyNhanVienPhuCap>();
            foreach (NhanVienPhuCap nhanVienPhuCap in nhanVienPhuCaps)
            {
                if (nhanVienPhuCap.PhuCapId != PhuCapId)
                {
                    continue;
                }
                PhongBan phongBan = null;
                ChucVu chucVu = null;
                ChiTietNhanVien chiTietNhanVien = null;
                NhanVien nhanVien = nhanViens.Find(x => x.NhanVienId == nhanVienPhuCap.NhanVienId);
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
                listNVDA.Add(ToDTO(nhanVien, chiTietNhanVien, phongBan, chucVu, nhanVienPhuCap));
            }
            return listNVDA;
        }

    }
}
