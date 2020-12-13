using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class PhongBanMap
    {
        public static PhongBanDTO ToDTO(this PhongBan phongBan)
        {
            return new PhongBanDTO()
            {
                PhongBanId = phongBan.PhongBanId,
                TenPhongBan = phongBan.TenPhongBan,
                SDTPhongBan = phongBan.SDTPhongBan
            };
        }
        public static List<PhongBanDTO> ToListDTO(this List<PhongBan> phongBans)
        {
            List<PhongBanDTO> phongBanDTOs = new List<PhongBanDTO>();
            foreach (PhongBan phongBan in phongBans)
            {
                if (phongBan.TrangThai == 0)
                {
                    continue;
                }
                phongBanDTOs.Add(phongBan.ToDTO());
            }
            return phongBanDTOs;
        }

        public static List<PhongBanDTO> ToListDTOPb(this List<PhongBan> phongBans, string id)
        {
            List<PhongBanDTO> phongBanDTOs = new List<PhongBanDTO>();
            foreach (PhongBan phongBan in phongBans)
            {
                if (phongBan.TrangThai == 0 || phongBan.PhongBanId != id)
                {
                    continue;
                }
                else
                {
                    phongBanDTOs.Add(phongBan.ToDTO());
                }
            }
            return phongBanDTOs;
        }

        public static PhongBan ToPhongBan(this PhongBanDTO phongBanDTO)
        {
            return new PhongBan()
            {
                PhongBanId = phongBanDTO.PhongBanId,
                TenPhongBan = phongBanDTO.TenPhongBan,
                SDTPhongBan = phongBanDTO.SDTPhongBan
            };
        }
        public static List<PhongBanDTO> ToListDTO(this List<PhongBan> phongBans, List<NhanVien> nhanViens, List<Account> accounts,
            string NhanVienIdToken)
        {
            NhanVien nv = nhanViens.Find(x => x.NhanVienId == NhanVienIdToken);
            Account ac = accounts.Find(x => x.AccountId == NhanVienIdToken);

            List<PhongBanDTO> phongBanDTOs = new List<PhongBanDTO>();
            foreach (PhongBan phongBan in phongBans)
            {
                //Quyền lấy ra các phòng ban
                if (nv.PhongBanId != phongBan.PhongBanId && ac.Quyen == 1)
                {
                    continue;
                }

                if (phongBan.TrangThai == 0)
                {
                    continue;
                }
                phongBanDTOs.Add(phongBan.ToDTO());
            }
            return phongBanDTOs;
        }
    }
}
