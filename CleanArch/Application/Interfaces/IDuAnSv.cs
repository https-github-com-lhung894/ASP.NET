using System.Collections.Generic;
using Application.DTOs;
using Domain.IActions;

namespace Application.Interfaces
{
    public interface IDuAnSv : IGeneralAction<DuAnDTO>
    {
        List<DuAnDTO> GetList();
        string AddDuAn(DuAnDTO duAnDTO);
        string UpdateDuAn(DuAnDTO duAnDTO);
        string RemoveDuAn(DuAnDTO duAnDTO);
    }
}
