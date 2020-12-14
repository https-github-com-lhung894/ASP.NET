using Application.DTOs;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDuAnSv : IGeneralAction<DuAnDTO>
    {
        List<DuAnDTO> ProjectInProgress();
    }
}
