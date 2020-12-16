using Application.DTOs;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INhanVienPhuCapSv : IGeneralAction<NhanVienPhuCapDTO>
    {
        List<NhanVienPhuCapDTO> GetList();
        string AddNVPC(NhanVienPhuCapDTO nhanVienPhuCapDTO);
    }
}
