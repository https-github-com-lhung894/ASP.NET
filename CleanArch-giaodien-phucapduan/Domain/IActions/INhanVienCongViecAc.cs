using Domain.Entities;

namespace Domain.IActions
{
    public interface INhanVienCongViecAc : IGeneralAction<NhanVienCongViec>
    {
        string AutoAdd(string nhanVienId, string congViecId);
    }
}
