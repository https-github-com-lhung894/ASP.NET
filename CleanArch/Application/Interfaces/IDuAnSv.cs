using Application.DTOs;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDuAnSv : IGeneralAction<DuAnDTO>
    {
        List<DuAnDTO> ProjectInProgress();
        List<DuAnDTO> GetList();
        string AddDuAn(DuAnDTO duAnDTO);
        string UpdateDuAn(DuAnDTO duAnDTO);
        string RemoveDuAn(DuAnDTO duAnDTO);
    }
}
