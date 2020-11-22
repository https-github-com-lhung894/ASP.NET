using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CongViecSv : ICongViecSv
    {
        private readonly ICongViecAc congViecAc;
        public CongViecSv(ICongViecAc congViecAc)
        {
            this.congViecAc = congViecAc;
        }
        public string Add(CongViecDTO obj)
        {
            return congViecAc.Add(obj.ToCongViec());
        }

        public CongViecDTO FindById(string id)
        {
            return congViecAc.FindById(id).ToDTO();
        }

        public string Remove(CongViecDTO obj)
        {
            return congViecAc.Remove(obj.ToCongViec());
        }

        public List<CongViecDTO> ToList()
        {
            return congViecAc.ToList().ToListDTO();
        }

        public string Update(CongViecDTO obj)
        {
            return congViecAc.Update(obj.ToCongViec());
        }
    }
}
