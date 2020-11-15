using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class NhanVienCongViecSv : INhanVienCongViecSv
    {
        private readonly INhanVienCongViecAc nhanVienCongViecAc;
        public NhanVienCongViecSv(INhanVienCongViecAc nhanVienCongViecAc)
        {
            this.nhanVienCongViecAc = nhanVienCongViecAc;
        }

        public string Add(NhanVienCongViecDTO obj)
        {
            return nhanVienCongViecAc.Add(obj.ToNhanVienCongViec());
        }

        public NhanVienCongViecDTO FindById(string id)
        {
            return nhanVienCongViecAc.FindById(id).ToDTO();
        }

        public string Remove(NhanVienCongViecDTO obj)
        {
            return nhanVienCongViecAc.Remove(obj.ToNhanVienCongViec());
        }

        public List<NhanVienCongViecDTO> ToList()
        {
            return nhanVienCongViecAc.ToList().ToListDTO();
        }

        public string Update(NhanVienCongViecDTO obj)
        {
            return nhanVienCongViecAc.Update(obj.ToNhanVienCongViec());
        }
    }
}
