using Domain.Entities;

namespace Domain.IActions
{
     public interface IHopDongAc : IGeneralAction<HopDong>
    {
        HopDong SetupForUpdate(string nhanVienId, string congViecId, double? luongCanBan);
        string AutoAdd(string nhanVienId, string congViecId, double? luongCanBan);
    }
}
