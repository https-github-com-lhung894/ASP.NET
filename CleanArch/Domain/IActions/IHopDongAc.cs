using Domain.Entities;

namespace Domain.IActions
{
     public interface IHopDongAc : IGeneralAction<HopDong>
    {
        string AutoAdd(string nhanVienId, string congViecId, double? luongCanBan);
    }
}
