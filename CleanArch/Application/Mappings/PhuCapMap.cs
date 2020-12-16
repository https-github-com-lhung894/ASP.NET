using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class PhuCapMap
    {
        public static PhuCapDTO ToDTO(this PhuCap phuCap)
        {
            return new PhuCapDTO()
            {
                PhuCapId = phuCap.PhuCapId,
                TenPhuCap = phuCap.TenPhuCap,
                TienPhuCap = phuCap.TienPhuCap,
                TrangThai = phuCap.TrangThai
            };
        }
        public static List<PhuCapDTO> ToListDTO(this List<PhuCap> phuCaps)
        {
            List<PhuCapDTO> phuCapDTOs = new List<PhuCapDTO>();
            foreach (PhuCap phuCap in phuCaps)
            {
                if (phuCap.TrangThai == 0)
                {
                    continue;
                }
                phuCapDTOs.Add(phuCap.ToDTO());
            }
            return phuCapDTOs;
        }
        public static PhuCap ToPhuCap(this PhuCapDTO phuCapDTO)
        {
            return new PhuCap()
            {
                PhuCapId = phuCapDTO.PhuCapId,
                TenPhuCap = phuCapDTO.TenPhuCap,
                TienPhuCap = phuCapDTO.TienPhuCap,
                TrangThai = phuCapDTO.TrangThai
            };
        }
    }
}
