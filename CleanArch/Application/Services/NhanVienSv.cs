using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class NhanVienSv : INhanVienSv
    {
        private readonly INhanVienAc nhanVienAc;
        public NhanVienSv(INhanVienAc nhanVienAc)
        {
            this.nhanVienAc = nhanVienAc;
        }
        public string Add(NhanVienDTO obj)
        {
            return nhanVienAc.Add(obj.ToNhanVien());
        }

        public NhanVienDTO FindById(string id)
        {
            return nhanVienAc.FindById(id).ToDTO();
        }

        public string Remove(NhanVienDTO obj)
        {
            return nhanVienAc.Remove(obj.ToNhanVien());
        }

        public List<NhanVienDTO> ToList()
        {
            return nhanVienAc.ToList().ToListDTO();
        }

        public string Update(NhanVienDTO obj)
        {
            return nhanVienAc.Update(obj.ToNhanVien());
        }
    }
}
