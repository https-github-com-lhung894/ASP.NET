using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TrangThaiChamCongSv : ITrangThaiChamCongSv
    {
        private readonly ITrangThaiChamCongAc trangThaiChamCongAc;
        public TrangThaiChamCongSv(ITrangThaiChamCongAc trangThaiChamCongAc)
        {
            this.trangThaiChamCongAc = trangThaiChamCongAc;
        }
        public string Add(TrangThaiChamCongDTO obj)
        {
            return trangThaiChamCongAc.Add(obj.ToTrangThaiChamCong());
        }

        public TrangThaiChamCongDTO FindById(string id)
        {
            return trangThaiChamCongAc.FindById(id).ToDTO();
        }

        public string Remove(TrangThaiChamCongDTO obj)
        {
            return trangThaiChamCongAc.Remove(obj.ToTrangThaiChamCong());
        }

        public List<TrangThaiChamCongDTO> ToList()
        {
            return trangThaiChamCongAc.ToList().ToListDTO();
        }

        public string Update(TrangThaiChamCongDTO obj)
        {
            return trangThaiChamCongAc.Update(obj.ToTrangThaiChamCong());
        }
    }
}
