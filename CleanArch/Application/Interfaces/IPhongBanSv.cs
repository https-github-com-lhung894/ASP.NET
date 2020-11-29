using System.Collections.Generic;
using Application.DTOs;
using Domain.IActions;

namespace Application.Interfaces
{
    public interface IPhongBanSv : IGeneralAction<PhongBanDTO>
    {
        string AddPhongBan(PhongBanDTO phongBanDTO);
        List<PhongBanDTO> GetList();
        string UpdatePhongBan(PhongBanDTO phongBanDTO);
        string RemovePhongBan(PhongBanDTO phongBanDTO);
    }
}
