using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class DuAnMap
    {
        public static DuAnDTO ToDTO(this DuAn duAn, int soLuongNhanVien)
        {
            return new DuAnDTO()
            {
                DuAnId = duAn.DuAnId,
                TenDuAn = duAn.TenDuAn,
                PhanTramDuAn = duAn.PhanTramDuAn,
                ThuongDuAn = duAn.ThuongDuAn,
                NgayBatDau = duAn.NgayBatDau,
                NgayKetThuc = duAn.NgayKetThuc,
                SoLuongNhanVien = soLuongNhanVien
            };
        }
        public static List<DuAnDTO> ToListDTO(this List<DuAn> duAns, List<NhanVienDuAn> nhanVienDuAns)
        {
            List<DuAnDTO> duAnDTOs = new List<DuAnDTO>();
            foreach (DuAn duAn in duAns)
            {
                List<NhanVienDuAn> nvdas = nhanVienDuAns.FindAll(x => x.DuAnId == duAn.DuAnId);

                duAnDTOs.Add(duAn.ToDTO(nvdas.Count));
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
