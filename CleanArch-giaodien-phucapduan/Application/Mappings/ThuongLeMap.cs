using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class ThuongLeMap
    {
        public static ThuongLeDTO ToDTO(this ThuongLe thuongLe)
        {
            return new ThuongLeDTO()
            {
                ThuongLeId = thuongLe.ThuongLeId,
                NgayLe = thuongLe.NgayLe,
                TienThuongLe = thuongLe.TienThuongLe
            };
        }
        public static List<ThuongLeDTO> ToListDTO(this List<ThuongLe> thuongLes)
        {
            List<ThuongLeDTO> thuongLeDTOs = new List<ThuongLeDTO>();
            foreach (ThuongLe thuongLe in thuongLes)
            {
                thuongLeDTOs.Add(thuongLe.ToDTO());
            }
            return thuongLeDTOs;
        }
        public static ThuongLe ToThuongLe(this ThuongLeDTO thuongLeDTO)
        {
            return new ThuongLe()
            {
                ThuongLeId = thuongLeDTO.ThuongLeId,
                NgayLe = thuongLeDTO.NgayLe,
                TienThuongLe = thuongLeDTO.TienThuongLe
            };
        }
    }
}
