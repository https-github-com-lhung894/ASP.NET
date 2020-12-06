using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class LuongThangSv : ILuongThangSv
    {
        private readonly ILuongThangAc luongThangAc;
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        private readonly INhanVienAc nhanVienAc;
        private readonly IPhongBanAc phongBanAc;
        public LuongThangSv(ILuongThangAc luongThangAc, IChiTietNhanVienAc chiTietNhanVienAc, INhanVienAc nhanVienAc, IPhongBanAc phongBanAc)
        {
            this.luongThangAc = luongThangAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.nhanVienAc = nhanVienAc;
            this.phongBanAc = phongBanAc;
        }
        public string Add(LuongThangDTO obj)
        {
            return luongThangAc.Add(obj.ToLuongThang());
        }

        public void AutoAdd()
        {
            luongThangAc.AutoAdd();
        }

        public LuongThangDTO FindById(string id)
        {
            //Hàm này không dùng tới
            return null;
            //return luongThangAc.FindById(id).ToDTO();
        }

        public string Remove(LuongThangDTO obj)
        {
            return luongThangAc.Remove(obj.ToLuongThang());
        }

        public List<LuongThangDTO> ToList()
        {
            return luongThangAc.ToList().ToListDTO(chiTietNhanVienAc.ToList(),nhanVienAc.ToList(),phongBanAc.ToList());
        }

        public string Update(LuongThangDTO obj)
        {
            return luongThangAc.Update(obj.ToLuongThang());
        }
    }
}
