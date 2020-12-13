using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class HopDongSv : IHopDongSv
    {
        private readonly IHopDongAc hopDongAc;
        public HopDongSv(IHopDongAc hopDongAc)
        {
            this.hopDongAc = hopDongAc;
        }

        public string Add(HopDongDTO obj)
        {
            return hopDongAc.Add(obj.ToHopDong());
        }

        public HopDongDTO FindById(string id)
        {
            return hopDongAc.FindById(id).ToDTO();
        }

        public string Remove(HopDongDTO obj)
        {
            return hopDongAc.Remove(obj.ToHopDong());
        }

        public List<HopDongDTO> ToList()
        {
            return hopDongAc.ToList().ToListDTO();
        }

        public string Update(HopDongDTO obj)
        {
            return hopDongAc.Update(obj.ToHopDong());
        }
    }
}
