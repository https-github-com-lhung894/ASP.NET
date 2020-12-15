using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class NhanVienDuAnSv : INhanVienDuAnSv
    {
        private readonly INhanVienDuAnAc nhanVienDuAnAc;
        public NhanVienDuAnSv(INhanVienDuAnAc nhanVienDuAnAc)
        {
            this.nhanVienDuAnAc = nhanVienDuAnAc;
        }

        public string AddNVDA(NhanVienDuAnDTO nhanVienDuAnDTO)
        {
            string errorMessage;
            errorMessage = nhanVienDuAnAc.Add(nhanVienDuAnDTO.ToNhanVienDuAn());
            return errorMessage;
        }

        public List<NhanVienDuAnDTO> GetList()
        {
            return NhanVienDuAnMap.ToListDTO(nhanVienDuAnAc.ToList());
        }

        public string Add(NhanVienDuAnDTO obj)
        {
            return nhanVienDuAnAc.Add(obj.ToNhanVienDuAn());
        }

        public NhanVienDuAnDTO FindById(string id)
        {
            return nhanVienDuAnAc.FindById(id).ToDTO();
        }

        public string Remove(NhanVienDuAnDTO obj)
        {
            return nhanVienDuAnAc.Remove(obj.ToNhanVienDuAn());
        }

        public List<NhanVienDuAnDTO> ToList()
        {
            return nhanVienDuAnAc.ToList().ToListDTO();
        }

        public string Update(NhanVienDuAnDTO obj)
        {
            return nhanVienDuAnAc.Update(obj.ToNhanVienDuAn());
        }
    }
}
