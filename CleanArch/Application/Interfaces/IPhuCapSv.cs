using System.Collections.Generic;
using Application.DTOs;
using Domain.IActions;

namespace Application.Interfaces
{
    public interface IPhuCapSv : IGeneralAction<PhuCapDTO>
    {
        List<PhuCapDTO> GetList();
        string AddPhuCap(PhuCapDTO phuCapDTO);
        string UpdatePhuCap(PhuCapDTO phuCapDTO);
        string RemovePhuCap(PhuCapDTO phuCapDTO);
    }
}
