using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PhuCapSv : IPhuCapSv
    {
        private readonly IPhuCapAc phuCapAc;

        public PhuCapSv(IPhuCapAc phuCapAc)
        {
            this.phuCapAc = phuCapAc;
        }
        public string AddPhuCap(PhuCapDTO phuCapDTO)
        {
            string errorMessage;
            errorMessage = phuCapAc.Add(phuCapDTO.ToPhuCap());
            return errorMessage;
        }

        public string UpdatePhuCap(PhuCapDTO phuCapDTO)
        {
            string errorMessage;
            errorMessage = phuCapAc.Update(phuCapDTO.ToPhuCap());
            return errorMessage;
        }

        public string RemovePhuCap(PhuCapDTO phuCapDTO)
        {
            string errorMessage;
            errorMessage = phuCapAc.Remove(phuCapDTO.ToPhuCap());
            return errorMessage;
        }

        public List<PhuCapDTO> GetList()
        {
            return PhuCapMap.ToListDTO(phuCapAc.ToList());
        }

        public string Add(PhuCapDTO obj)
        {
            return phuCapAc.Add(obj.ToPhuCap());
        }

        public PhuCapDTO FindById(string id)
        {
            return phuCapAc.FindById(id).ToDTO();
        }

        public string Remove(PhuCapDTO obj)
        {
            return phuCapAc.Remove(obj.ToPhuCap());
        }

        public List<PhuCapDTO> ToList()
        {
            return phuCapAc.ToList().ToListDTO();
        }

        public string Update(PhuCapDTO obj)
        {
            return phuCapAc.Update(obj.ToPhuCap());
        }
    }
}
