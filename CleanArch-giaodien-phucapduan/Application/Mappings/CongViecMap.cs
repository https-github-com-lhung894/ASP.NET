using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class CongViecMap
    {
        public static CongViecDTO ToDTO(this CongViec congViec)
        {
            return new CongViecDTO()
            {
                CongViecId = congViec.CongViecId,
                TenCongViec = congViec.TenCongViec
            };
        }
        public static List<CongViecDTO> ToListDTO(this List<CongViec> congViecs)
        {
            List<CongViecDTO> congViecDTOs = new List<CongViecDTO>();
            foreach (CongViec congViec in congViecs)
            {
                congViecDTOs.Add(congViec.ToDTO());
            }
            return congViecDTOs;
        }
        public static CongViec ToCongViec(this CongViecDTO congViecDTO)
        {
            return new CongViec()
            {
                CongViecId = congViecDTO.CongViecId,
                TenCongViec = congViecDTO.TenCongViec
            };
        }
    }
}
