using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class ChiTietNhanVienSv : IChiTietNhanVienSv
    {
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        public ChiTietNhanVienSv(IChiTietNhanVienAc chiTietNhanVienAc)
        {
            this.chiTietNhanVienAc = chiTietNhanVienAc;
        }
        public string Add(ChiTietNhanVienDTO obj)
        {
            return chiTietNhanVienAc.Add(obj.ToChiTietNhanVien());
        }

        public ChiTietNhanVienDTO FindById(string id)
        {
            return chiTietNhanVienAc.FindById(id).ToDTO();
        }

        public string Remove(ChiTietNhanVienDTO obj)
        {
            return chiTietNhanVienAc.Remove(obj.ToChiTietNhanVien());
        }

        public List<ChiTietNhanVienDTO> ToList()
        {
            return chiTietNhanVienAc.ToList().ToListDTO();
        }

        public string Update(ChiTietNhanVienDTO obj)
        {
            return chiTietNhanVienAc.Update(obj.ToChiTietNhanVien());
        }
    }
}
