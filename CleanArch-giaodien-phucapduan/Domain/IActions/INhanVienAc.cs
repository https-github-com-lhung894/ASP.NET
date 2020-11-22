using Domain.Entities;

namespace Domain.IActions
{
    public interface INhanVienAc : IGeneralAction<NhanVien>
    {
        string CheckRelationship(NhanVien nhanVien);
    }
}
