using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class NhanVienPhuCapSv : INhanVienPhuCapSv
    {
        private readonly INhanVienPhuCapAc nhanVienPhuCapAc;
        public NhanVienPhuCapSv(INhanVienPhuCapAc nhanVienPhuCapAc)
        {
            this.nhanVienPhuCapAc = nhanVienPhuCapAc;
        }

        public string AddNVPC(NhanVienPhuCapDTO nhanVienPhuCapDTO)
        {
            string errorMessage;
            errorMessage = nhanVienPhuCapAc.Add(nhanVienPhuCapDTO.ToNhanVienPhuCap());
            return errorMessage;
        }

        public List<NhanVienPhuCapDTO> GetList()
        {
            return NhanVienPhuCapMap.ToListDTO(nhanVienPhuCapAc.ToList());
        }

        public string Add(NhanVienPhuCapDTO obj)
        {
            return nhanVienPhuCapAc.Add(obj.ToNhanVienPhuCap());
        }

        public NhanVienPhuCapDTO FindById(string id)
        {
            return nhanVienPhuCapAc.FindById(id).ToDTO();
        }

        public string Remove(NhanVienPhuCapDTO obj)
        {
            return nhanVienPhuCapAc.Remove(obj.ToNhanVienPhuCap());
        }

        public List<NhanVienPhuCapDTO> ToList()
        {
            return nhanVienPhuCapAc.ToList().ToListDTO();
        }

        public string Update(NhanVienPhuCapDTO obj)
        {
            return nhanVienPhuCapAc.Update(obj.ToNhanVienPhuCap());
        }
    }
}
