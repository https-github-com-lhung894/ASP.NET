using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class NhanVienDuAnMap
    {
        public static NhanVienDuAnDTO ToDTO(this NhanVienDuAn nhanVienDuAn)
        {
            return new NhanVienDuAnDTO()
            {
                NhanVienDuAnId = nhanVienDuAn.NhanVienDuAnId,
                PhanTramCV = nhanVienDuAn.PhanTramCV,
                NhanVienId = nhanVienDuAn.NhanVienId,
                DuAnId = nhanVienDuAn.DuAnId
            };
        }
        public static List<NhanVienDuAnDTO> ToListDTO(this List<NhanVienDuAn> nhanVienDuAns)
        {
            List<NhanVienDuAnDTO> nhanVienDuAnDTOs = new List<NhanVienDuAnDTO>();
            foreach (NhanVienDuAn nhanVienDuAn in nhanVienDuAns)
            {
                nhanVienDuAnDTOs.Add(nhanVienDuAn.ToDTO());
            }
            return nhanVienDuAnDTOs;
        }
        public static NhanVienDuAn ToNhanVienDuAn(this NhanVienDuAnDTO nhanVienDuAnDTO)
        {
            return new NhanVienDuAn()
            {
                NhanVienDuAnId = nhanVienDuAnDTO.NhanVienDuAnId,
                PhanTramCV = nhanVienDuAnDTO.PhanTramCV,
                NhanVienId = nhanVienDuAnDTO.NhanVienId,
                DuAnId = nhanVienDuAnDTO.DuAnId
            };
        }
    }
}
