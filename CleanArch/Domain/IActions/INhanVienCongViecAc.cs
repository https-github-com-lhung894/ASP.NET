using Domain.Entities;

namespace Domain.IActions
{
    public interface INhanVienCongViecAc : IGeneralAction<NhanVienCongViec>
    {
        NhanVienCongViec SetupForUpdate(string nhanVienId, string congViecId);
        string AutoAdd(string nhanVienId, string congViecId);
    }
}
