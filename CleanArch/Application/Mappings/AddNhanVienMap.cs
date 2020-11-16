using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class AddNhanVienMap
    {
        public static (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien) ToObjs(this AddNhanVien addNhanVien)
        {
            return (
                new Account()
                {
                    AccountId = addNhanVien.NhanVienId,
                    TaiKhoan = addNhanVien.NhanVienId,
                    MatKhau = addNhanVien.MatKhau,
                    Quyen = addNhanVien.Quyen,
                },
                new NhanVien()
                {
                    NhanVienId = addNhanVien.NhanVienId,
                    HoNhanVien = addNhanVien.HoNhanVien,
                    TenNhanVien = addNhanVien.TenNhanVien,
                    PhongBanId = addNhanVien.PhongBanId,
                    ChucVuId = addNhanVien.ChucVuId,
                    AccountId = addNhanVien.NhanVienId
                },
                new ChiTietNhanVien()
                {
                    ChiTietNhanVienId = addNhanVien.NhanVienId,
                    NgaySinh = addNhanVien.NgaySinh,
                    NoiSinh = addNhanVien.NoiSinh,
                    TrinhDoHocVan = addNhanVien.TrinhDoHocVan,
                    GioiTinh = addNhanVien.GioiTinh,
                    CMNN = addNhanVien.CMNN,
                    NgayCapCMNN = addNhanVien.NgayCapCMNN,
                    DiaChi = addNhanVien.DiaChi,
                    SDT = addNhanVien.SDT,
                    Email = addNhanVien.Email,
                    HinhAnh = addNhanVien.HinhAnh
                });
        }
    }
}
