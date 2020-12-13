using System.Collections.Generic;
using Application.DTOs;
using Domain.IActions;

namespace Application.Interfaces
{
    public interface IPhongBanSv : IGeneralAction<PhongBanDTO>
    {
        List<PhongBanDTO> ToListPermission(string NhanVienIdToken);
        string AddPhongBan(PhongBanDTO phongBanDTO);
        List<PhongBanDTO> GetList();
        List<PhongBanDTO> GetListPb(string id);
        string UpdatePhongBan(PhongBanDTO phongBanDTO);
        string RemovePhongBan(PhongBanDTO phongBanDTO);
    }
}
