using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class ChucVuSv : IChucVuSv
    {
        private readonly IChucVuAc chucVuAc;
        public ChucVuSv(IChucVuAc chucVuAc)
        {
            this.chucVuAc = chucVuAc;
        }
        public string Add(ChucVuDTO obj)
        {
            return chucVuAc.Add(obj.ToChucVu());
        }

        public ChucVuDTO FindById(string id)
        {
            return chucVuAc.FindById(id).ToDTO();
        }

        public string Remove(ChucVuDTO obj)
        {
            return chucVuAc.Remove(obj.ToChucVu());
        }

        public List<ChucVuDTO> ToList()
        {
            return chucVuAc.ToList().ToListDTO();
        }

        public string Update(ChucVuDTO obj)
        {
            return chucVuAc.Update(obj.ToChucVu());
        }
    }
}
