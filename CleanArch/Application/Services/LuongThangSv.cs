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
        private readonly IAccountAc accountAc;
        public LuongThangSv(ILuongThangAc luongThangAc, IChiTietNhanVienAc chiTietNhanVienAc, INhanVienAc nhanVienAc, 
            IPhongBanAc phongBanAc, IAccountAc accountAc)
        {
            this.luongThangAc = luongThangAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.nhanVienAc = nhanVienAc;
            this.phongBanAc = phongBanAc;
            this.accountAc = accountAc;
        }
        public string Add(LuongThangDTO obj)
        {
            return luongThangAc.Add(obj.ToLuongThang());
        }

        public void AutoAdd()
        {
            luongThangAc.AutoAdd();
        }

        public List<LuongThangDTO> Filter(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, 
            string optradio, string Tu, string Den, string NhanVienIdToKen)
        {


            return luongThangAc.Filter(NhanVienId, ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den)
                .ToListDTO(chiTietNhanVienAc.ToList(), nhanVienAc.ToList(), phongBanAc.ToList(), accountAc.ToList(), NhanVienIdToKen);
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
            return null;
        }
        public List<LuongThangDTO> ToList(string NhanVienId)
        {
            return luongThangAc.ToList().ToListDTO(chiTietNhanVienAc.ToList(), nhanVienAc.ToList(), phongBanAc.ToList(),
                accountAc.ToList(),NhanVienId);
        }

        public List<LuongThangDTO> ToListById(string NhanVienId)
        {
            return luongThangAc.ToListById(NhanVienId).ToListDTO(chiTietNhanVienAc.ToList(), nhanVienAc.ToList(), phongBanAc.ToList(),
                accountAc.ToList());
        }

        public string Update(LuongThangDTO obj)
        {
            return luongThangAc.Update(obj.ToLuongThang());
        }
    }
}
