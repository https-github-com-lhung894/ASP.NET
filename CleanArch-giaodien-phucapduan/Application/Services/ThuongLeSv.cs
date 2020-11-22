using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ThuongLeSv : IThuongLeSv
    {
        private readonly IThuongLeAc thuongLeAc;
        public ThuongLeSv(IThuongLeAc thuongLeAc)
        {
            this.thuongLeAc = thuongLeAc;
        }
        public string Add(ThuongLeDTO obj)
        {
            return thuongLeAc.Add(obj.ToThuongLe());
        }

        public ThuongLeDTO FindById(string id)
        {
            return thuongLeAc.FindById(id).ToDTO();
        }

        public string Remove(ThuongLeDTO obj)
        {
            return thuongLeAc.Remove(obj.ToThuongLe());
        }

        public List<ThuongLeDTO> ToList()
        {
            return thuongLeAc.ToList().ToListDTO();
        }

        public string Update(ThuongLeDTO obj)
        {
            return thuongLeAc.Update(obj.ToThuongLe());
        }
    }
}
