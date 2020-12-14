using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class DuAnSv : IDuAnSv
    {
        private readonly IDuAnAc duAnAc;
        public DuAnSv(IDuAnAc duAnAc)
        {
            this.duAnAc = duAnAc;
        }

        public List<DuAnDTO> GetList()
        {
            return DuAnMap.ToListDTO(duAnAc.ToList());
        }

        public string Add(DuAnDTO obj)
        {
            return duAnAc.Remove(obj.ToDuAn());
        }

        public DuAnDTO FindById(string id)
        {
            return duAnAc.FindById(id).ToDTO();
        }

        public string Remove(DuAnDTO obj)
        {
            return duAnAc.Remove(obj.ToDuAn());
        }

        public List<DuAnDTO> ToList()
        {
            return duAnAc.ToList().ToListDTO();
        }

        public string Update(DuAnDTO obj)
        {
            return duAnAc.Update(obj.ToDuAn());
        }
    }
}
