using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PhongBanSv : IPhongBanSv
    {
        private readonly IPhongBanAc phongBanAc;
        public PhongBanSv(IPhongBanAc phongBanAc)
        {
            this.phongBanAc = phongBanAc;
        }

        public string AddPhongBan(PhongBanDTO phongBanDTO)
        {
            string errorMessage;
            errorMessage = phongBanAc.Add(phongBanDTO.ToPhongBan());
            return errorMessage;
        }

        public string UpdatePhongBan(PhongBanDTO phongBanDTO)
        {
            string errorMessage;
            errorMessage = phongBanAc.Update(phongBanDTO.ToPhongBan());
            return errorMessage;
        }

        public string RemovePhongBan(PhongBanDTO phongBanDTO)
        {
            string errorMessage;
            errorMessage = phongBanAc.Remove(phongBanDTO.ToPhongBan());
            return errorMessage;
        }

        public List<PhongBanDTO> GetList()
        {
            return PhongBanMap.ToListDTO(phongBanAc.ToList());
        }

        public List<PhongBanDTO> GetListPb(string id)
        {
            return PhongBanMap.ToListDTOPb(phongBanAc.ToList(), id);
        }

        public string Add(PhongBanDTO obj)
        {
            return phongBanAc.Add(obj.ToPhongBan());
        }

        public PhongBanDTO FindById(string id)
        {
            return phongBanAc.FindById(id).ToDTO();
        }

        public string Remove(PhongBanDTO obj)
        {
            return phongBanAc.Remove(obj.ToPhongBan());
        }

        public List<PhongBanDTO> ToList()
        {
            return phongBanAc.ToList().ToListDTO();
        }

        public string Update(PhongBanDTO obj)
        {
            return phongBanAc.Update(obj.ToPhongBan());
        }
    }
}
