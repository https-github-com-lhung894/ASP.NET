using System.Collections.Generic;
using Application.DTOs;
using Domain.IActions;

namespace Application.Interfaces
{
    public interface INhanVienDuAnSv : IGeneralAction<NhanVienDuAnDTO>
    {
        List<NhanVienDuAnDTO> GetList();
        string AddNVDA(NhanVienDuAnDTO nhanVienDuAnDTO);
    }
}
