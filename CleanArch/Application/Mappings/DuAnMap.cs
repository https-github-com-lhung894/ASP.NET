using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class DuAnMap
    {
        public static DuAnDTO ToDTO(this DuAn duAn)
        {
            return new DuAnDTO()
            {
                DuAnId = duAn.DuAnId,
                TenDuAn = duAn.TenDuAn,
                PhanTramDuAn = duAn.PhanTramDuAn,
                ThuongDuAn = duAn.ThuongDuAn,
                NgayBatDau = duAn.NgayBatDau,
                NgayKetThuc = duAn.NgayKetThuc
            };
        }
        public static List<DuAnDTO> ToListDTO(this List<DuAn> duAns)
        {
            List<DuAnDTO> duAnDTOs = new List<DuAnDTO>();
            foreach (DuAn duAn in duAns)
            {
                duAnDTOs.Add(duAn.ToDTO());
            }
            return duAnDTOs;
        }
        public static DuAn ToDuAn(this DuAnDTO duAnDTO)
        {
            return new DuAn()
            {
                DuAnId = duAnDTO.DuAnId,
                TenDuAn = duAnDTO.TenDuAn,
                PhanTramDuAn = duAnDTO.PhanTramDuAn,
                ThuongDuAn = duAnDTO.ThuongDuAn,
                NgayBatDau = duAnDTO.NgayBatDau,
                NgayKetThuc = duAnDTO.NgayKetThuc
            };
        }
    }
}
