using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class DuAnSv : IDuAnSv
    {
        private readonly IDuAnAc duAnAc;
        private readonly INhanVienDuAnAc nhanVienDuAnAc;
        public DuAnSv(IDuAnAc duAnAc, INhanVienDuAnAc nhanVienDuAnAc)
        {
            this.duAnAc = duAnAc;
            this.nhanVienDuAnAc = nhanVienDuAnAc;
        }
        public string Add(DuAnDTO obj)
        {
            return duAnAc.Remove(obj.ToDuAn());
        }

        public DuAnDTO FindById(string id)
        {
            DuAn duAn = duAnAc.FindById(id);
            
            return duAn.ToDTO(nhanVienDuAnAc.ToList().FindAll(x => x.DuAnId == duAn.DuAnId).Count);
        }

        public List<DuAnDTO> ProjectInProgress()
        {
            return duAnAc.ProjectInProgress().ToListDTO(nhanVienDuAnAc.ToList());
        }

        public string Remove(DuAnDTO obj)
        {
            return duAnAc.Remove(obj.ToDuAn());
        }

        public List<DuAnDTO> ToList()
        {
            return duAnAc.ToList().ToListDTO(nhanVienDuAnAc.ToList());
        }

        public string Update(DuAnDTO obj)
        {
            return duAnAc.Update(obj.ToDuAn());
        }
    }
}
