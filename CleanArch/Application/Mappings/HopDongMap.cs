using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class HopDongMap
    {
        public static HopDongDTO ToDTO(this HopDong hopDong)
        {
            return new HopDongDTO()
            {
                HopDongId = hopDong.HopDongId,
                NgayKyHopDong = hopDong.NgayKyHopDong,
                LuongCanBan = hopDong.LuongCanBan,
                NhanVienId = hopDong.NhanVienId,
                CongViecId = hopDong.CongViecId
            };
        }
        public static List<HopDongDTO> ToListDTO(this List<HopDong> hopDongs)
        {
            List<HopDongDTO> hopDongDTOs = new List<HopDongDTO>();
            foreach (HopDong hopDong in hopDongs)
            {
                hopDongDTOs.Add(hopDong.ToDTO());
            }
            return hopDongDTOs;
        }
        public static HopDong ToHopDong(this HopDongDTO hopDongDTO)
        {
            return new HopDong()
            {
                HopDongId = hopDongDTO.HopDongId,
                NgayKyHopDong = hopDongDTO.NgayKyHopDong,
                LuongCanBan = hopDongDTO.LuongCanBan,
                NhanVienId = hopDongDTO.NhanVienId,
                CongViecId = hopDongDTO.CongViecId
            };
        }
    }
}
