using Domain.Entities;

namespace Domain.IActions
{
     public interface IHopDongAc : IGeneralAction<HopDong>
    {
        string CheckForeignKey(string nhanVienId, string congViecId);
        HopDong AutoUpdate(string nhanVienId, string congViecId, string luongCanBan);
        string AutoAdd(string nhanVienId, string congViecId, string luongCanBan);
    }
}
