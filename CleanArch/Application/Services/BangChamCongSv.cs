using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class BangChamCongSv : IBangChamCongSv
    {
        private readonly INhanVienAc nhanVienAc;
        private readonly IAccountAc accountAc;
        private readonly IBangChamCongAc bangChamCongAc;
        public BangChamCongSv(IBangChamCongAc bangChamCongAc, INhanVienAc nhanVienAc, IAccountAc accountAc)
        {
            this.bangChamCongAc = bangChamCongAc;
            this.nhanVienAc = nhanVienAc;
            this.accountAc = accountAc;
        }

        public string UpdateChamCong(BangChamCongDTO bangChamCongDTO)
        {
            string errorMessage;
            errorMessage = bangChamCongAc.Update(bangChamCongDTO.ToBangChamCong());
            return errorMessage;
        }

        public string Add(BangChamCongDTO obj)
        {
            return bangChamCongAc.Add(obj.ToBangChamCong());
        }

        public BangChamCongDTO FindById(string id)
        {
            return bangChamCongAc.FindById(id).ToDTO();
        }

        public string Remove(BangChamCongDTO obj)
        {
            return bangChamCongAc.Remove(obj.ToBangChamCong());
        }

        public List<BangChamCongDTO> ToList()
        {
            return null;
        }
        public List<BangChamCongDTO> ToList(string NhanVienId)
        {
            List<NhanVien> nhanViens = nhanVienAc.ToList();
            List<Account> accounts = accountAc.ToList();
            return bangChamCongAc.ToList().ToListDTO(NhanVienId, nhanViens, accounts);
        }

        public string Update(BangChamCongDTO obj)
        {
            return bangChamCongAc.Update(obj.ToBangChamCong());
        }
    }
}
