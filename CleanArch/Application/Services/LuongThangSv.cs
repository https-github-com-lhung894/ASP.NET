using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class LuongThangSv : ILuongThangSv
    {
        private readonly ILuongThangAc luongThangAc;
        public LuongThangSv(ILuongThangAc luongThangAc)
        {
            this.luongThangAc = luongThangAc;
        }
        public string Add(LuongThangDTO obj)
        {
            return luongThangAc.Add(obj.ToLuongThang());
        }

        public LuongThangDTO FindById(string id)
        {
            return luongThangAc.FindById(id).ToDTO();
        }

        public string Remove(LuongThangDTO obj)
        {
            return luongThangAc.Remove(obj.ToLuongThang());
        }

        public List<LuongThangDTO> ToList()
        {
            return luongThangAc.ToList().ToListDTO();
        }

        public string Update(LuongThangDTO obj)
        {
            return luongThangAc.Update(obj.ToLuongThang());
        }
    }
}
