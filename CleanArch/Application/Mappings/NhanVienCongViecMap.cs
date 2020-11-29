using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class NhanVienCongViecMap
    {
        public static NhanVienCongViecDTO ToDTO(this NhanVienCongViec nhanVienCongViec)
        {
            return new NhanVienCongViecDTO()
            {
                NhanVienCongViecId = nhanVienCongViec.NhanVienCongViecId,
                HSCongViec = nhanVienCongViec.HSCongViec,
                NgayBatDau = nhanVienCongViec.NgayBatDau,
                NgayKetThuc = nhanVienCongViec.NgayKetThuc,
                NhanVienId = nhanVienCongViec.NhanVienId,
                CongViecId = nhanVienCongViec.CongViecId
            };
        }
        public static List<NhanVienCongViecDTO> ToListDTO(this List<NhanVienCongViec> nhanVienCongViecs)
        {
            List<NhanVienCongViecDTO> nhanVienCongViecDTOs = new List<NhanVienCongViecDTO>();
            foreach (NhanVienCongViec nhanVienCongViec in nhanVienCongViecs)
            {
                nhanVienCongViecDTOs.Add(nhanVienCongViec.ToDTO());
            }
            return nhanVienCongViecDTOs;
        }
        public static NhanVienCongViec ToNhanVienCongViec(this NhanVienCongViecDTO nhanVienCongViecDTO)
        {
            return new NhanVienCongViec()
            {
                NhanVienCongViecId = nhanVienCongViecDTO.NhanVienCongViecId,
                HSCongViec = nhanVienCongViecDTO.HSCongViec,
                NgayBatDau = nhanVienCongViecDTO.NgayBatDau,
                NgayKetThuc = nhanVienCongViecDTO.NgayKetThuc,
                NhanVienId = nhanVienCongViecDTO.NhanVienId,
                CongViecId = nhanVienCongViecDTO.CongViecId
            };
        }
    }
}
