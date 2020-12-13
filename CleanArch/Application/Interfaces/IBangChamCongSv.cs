using Application.DTOs;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IBangChamCongSv : IGeneralAction<BangChamCongDTO>
    {
        List<BangChamCongDTO> ToList(string NhanVienId);
    }
}
