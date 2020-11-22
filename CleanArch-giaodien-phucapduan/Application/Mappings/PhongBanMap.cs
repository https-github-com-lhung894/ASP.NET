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
                phongBanDTOs.Add(phongBan.ToDTO());
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
    }
}
