using Domain.Entities;

namespace Domain.IActions
{
    public interface INhanVienAc : IGeneralAction<NhanVien>
    {
        string CheckForeignKey(string accountId, string phongBanId, string chucVuId);
        string CheckRelationship(NhanVien nhanVien);
        int Count();
    }
}
