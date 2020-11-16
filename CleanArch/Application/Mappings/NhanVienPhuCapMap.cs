using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class NhanVienPhuCapMap
    {
        public static NhanVienPhuCapDTO ToDTO(this NhanVienPhuCap nhanVienPhuCap)
        {
            return new NhanVienPhuCapDTO()
            {
                NhanVienPhuCapId = nhanVienPhuCap.NhanVienPhuCapId,
                NhanVienId = nhanVienPhuCap.NhanVienId,
                PhuCapId = nhanVienPhuCap.PhuCapId
            };
        }
        public static List<NhanVienPhuCapDTO> ToListDTO(this List<NhanVienPhuCap> nhanVienPhuCaps)
        {
            List<NhanVienPhuCapDTO> nhanVienPhuCapDTOs = new List<NhanVienPhuCapDTO>();
            foreach (NhanVienPhuCap nhanVienPhuCap in nhanVienPhuCaps)
            {
                nhanVienPhuCapDTOs.Add(nhanVienPhuCap.ToDTO());
            }
            return nhanVienPhuCapDTOs;
        }
        public static NhanVienPhuCap ToNhanVienPhuCap(this NhanVienPhuCapDTO nhanVienPhuCapDTO)
        {
            return new NhanVienPhuCap()
            {
                NhanVienPhuCapId = nhanVienPhuCapDTO.NhanVienPhuCapId,
                NhanVienId = nhanVienPhuCapDTO.NhanVienId,
                PhuCapId = nhanVienPhuCapDTO.PhuCapId
            };
        }
    }
}
