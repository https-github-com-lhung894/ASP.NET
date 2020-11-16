using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class BangChamCongSv : IBangChamCongSv
    {
        private readonly IBangChamCongAc bangChamCongAc;
        public BangChamCongSv(IBangChamCongAc bangChamCongAc)
        {
            this.bangChamCongAc = bangChamCongAc;
        }
        public string Add(BangChamCongDTO obj)
        {
            return bangChamCongAc.Add(obj.ToBangChamCong());
        }

        public BangChamCongDTO FindById(string id)
        {
            return bangChamCongAc.FindById(id).ToDTO();
        }

        public string Remove(BangChamCongDTO obj)
        {
            return bangChamCongAc.Remove(obj.ToBangChamCong());
        }

        public List<BangChamCongDTO> ToList()
        {
            return bangChamCongAc.ToList().ToListDTO();
        }

        public string Update(BangChamCongDTO obj)
        {
            return bangChamCongAc.Update(obj.ToBangChamCong());
        }
    }
}
