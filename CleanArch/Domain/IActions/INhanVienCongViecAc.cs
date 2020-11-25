using Domain.Entities;

namespace Domain.IActions
{
    public interface INhanVienCongViecAc : IGeneralAction<NhanVienCongViec>
    {
        string CheckForeignKey(string nhanVienId, string congViecId);
        string AutoUpdate(string nhanVienId, string congViecId);
        string AutoAdd(string nhanVienId, string congViecId);
    }
}
