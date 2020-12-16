using Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class SeedData
    {
        public static void Initialize(MyData context)
        {
            context.Database.EnsureCreated();
            if (context.NhanViens.Any())
            {
                return;
            }


            context.Accounts.AddRange(new List<Account>()
            {
                new Account()
                {
                    AccountId = "nv00000",
                    TaiKhoan = "nv00000@email.com",
                    MatKhau = "123",
                    Quyen = 0
                }
            });
            context.PhongBans.AddRange(new List<PhongBan>()
            {
                new PhongBan()
                {
                    PhongBanId = "null",
                    TenPhongBan = "Admin",
                    SDTPhongBan = "Admin",
                    TrangThai = 1
                },
                new PhongBan()
                {
                    PhongBanId = "pb00001",
                    TenPhongBan = "Phòng ban 1",
                    SDTPhongBan = "0935444555",
                    TrangThai = 1
                }
            });
            context.CongViecs.AddRange(new List<CongViec>()
            {
                new CongViec()
                {
                    CongViecId = "congviec1",
                    TenCongViec = "Phân tích dữ liệu"
                },
                new CongViec()
                {
                    CongViecId = "congviec2",
                    TenCongViec = "Lập trình"
                },
                new CongViec()
                {
                    CongViecId = "congviec3",
                    TenCongViec = "Kiểm thử phần mềm"
                },
                new CongViec()
                {
                    CongViecId = "congviec4",
                    TenCongViec = "Hỗ trợ kỹ thuật"
                },
            });
            context.TrangThaiChamCongs.AddRange(new List<TrangThaiChamCong>()
            {
                new TrangThaiChamCong()
                {
                    TrangThaiChamCongId = "tt1",
                    TenTrangThai = "Làm việc",
                    HSTrangThai = 0
                },
                new TrangThaiChamCong()
                {
                    TrangThaiChamCongId = "tt2",
                    TenTrangThai = "Nghỉ phép",
                    HSTrangThai = 0.7
                },
                new TrangThaiChamCong()
                {
                    TrangThaiChamCongId = "tt3",
                    TenTrangThai = "Nghỉ không phép",
                    HSTrangThai = 1
                },
                new TrangThaiChamCong()
                {
                    TrangThaiChamCongId = "tt4",
                    TenTrangThai = "Nghỉ bệnh",
                    HSTrangThai = 0.5
                },
            });
            context.DuAns.AddRange(new List<DuAn>()
            {
                new DuAn()
                {
                    DuAnId = "da00000",
                    TenDuAn = "",
                    PhanTramDuAn = 0,
                    ThuongDuAn = "0",
                    NgayBatDau = new DateTime(2000,1,1),
                    NgayKetThuc = new DateTime(2000,1,1),
                    TrangThai = 0,
                },
            });
            context.ChucVus.AddRange(new List<ChucVu>()
            {
                new ChucVu()
                {
                    ChucVuId = "chucvu1",
                    TenChucVu = "Trưởng phòng ban",
                    HSChucVu = 0.5,
                    TienPhuCapChucVu = "500000",
                },
                new ChucVu()
                {
                    ChucVuId = "chucvu2",
                    TenChucVu = "Phó phòng ban",
                    HSChucVu = 0.3,
                    TienPhuCapChucVu = "300000",
                },
                new ChucVu()
                {
                    ChucVuId = "chucvu3",
                    TenChucVu = "Nhân viên",
                    HSChucVu = 0.1,
                    TienPhuCapChucVu = "100000",
                },
            });
            context.PhuCaps.AddRange(new List<PhuCap>()
            {
                new PhuCap()
                {
                    PhuCapId = "pc00000",
                    TenPhuCap = "Admin",
                    TienPhuCap = "0",
                    TrangThai = 0,
                },
            });
            context.NhanViens.AddRange(new List<NhanVien>()
            {
                new NhanVien()
                {
                    NhanVienId = "nv00000",
                    HoNhanVien = "",
                    TenNhanVien = "Admin",
                    PhongBanId = "null",
                    ChucVuId = "chucvu1",
                    TrangThai = 1,
                    AccountId = "nv00000",
                },
            });
            context.NhanVienCongViecs.AddRange(new List<NhanVienCongViec>()
            {
                new NhanVienCongViec()
                {
                    NhanVienCongViecId = "0",
                    NhanVienId = "nv00000",
                    CongViecId = "congviec1",
                    HSCongViec = 0.5,
                    NgayBatDau = new DateTime(2000,1,1),
                    NgayKetThuc = new DateTime(2000,1,1),
                },
            });
            context.HopDongs.AddRange(new List<HopDong>()
            {
                new HopDong()
                {
                    HopDongId = "0",
                    NhanVienId = "nv00000",
                    CongViecId = "congviec1",
                    NgayKyHopDong = new DateTime(2000,1,1),
                    LuongCanBan = "0",
                    TrangThai = 0,
                },
            });
            context.ChiTietNhanViens.AddRange(new List<ChiTietNhanVien>()
            {
                new ChiTietNhanVien()
                {
                    ChiTietNhanVienId = "nv00000",
                    NhanVienId = "nv00000",
                    NgaySinh = new DateTime(2000,1,1),
                    NoiSinh = "",
                    TrinhDoHocVan = "",
                    GioiTinh = "Nam",
                    CMND = "",
                    NgayCapCMND = new DateTime(2000,1,1),
                    DiaChi = "",
                    SDT = "",
                    Email = "",
                    HinhAnh = null,
                },
            });
            context.NhanVienDuAns.AddRange(new List<NhanVienDuAn>()
            {
                new NhanVienDuAn()
                {
                    NhanVienDuAnId = "0",
                    NhanVienId = "nv00000",
                    DuAnId = "da00000",
                    PhanTramCV = 0,
                },
            });
            context.BangChamCongs.AddRange(new List<BangChamCong>()
            {
                new BangChamCong()
                {
                    BangChamCongId = "0",
                    NhanVienId = "nv00000",
                    TrangThaiChamCongId = "tt1",
                    NgayLamViec = new DateTime(2000,1,1),
                },
            });
            context.NhanVienPhuCaps.AddRange(new List<NhanVienPhuCap>()
            {
                new NhanVienPhuCap()
                {
                    NhanVienPhuCapId = "0",
                    NhanVienId = "nv00000",
                    PhuCapId = "pc00000",
                },
            });
            context.LuongThangs.AddRange(new List<LuongThang>()
            {
                new LuongThang()
                {
                    LuongThangId = "0",
                    NhanVienId = "nv00000",
                    LuongCoBan = "0",
                    HSChucVu = 0,
                    HSCongViec = 0,
                    SoNgayLam = 0,
                    SoNgayNghiCoPhep = 0,
                    SoNgayNghiKhongPhep = 0,
                    SoNgayNghiOm = 0,
                    PhuCapNhanVien = "0",
                    PhuCapChucVu = "0",
                    PhuCapThamNien = 0,
                    ThuongLe = "0",
                    TienDuAn = "0",
                    NgayTinhLuong = new DateTime(2000,1,1),
                    LuongThucLanh = "0",
                },
            });
            context.ThongTinDuLieuCuois.AddRange(new List<ThongTinDuLieuCuoi>()
            {
                new ThongTinDuLieuCuoi()
                {
                    ThongTinDuLieuCuoiId = "1",
                    NhanVienId = "nv00000",
                    DuAnId = "da00000",
                    PhongBanId = "pb00001",
                    PhuCapId = "pc00000",
                },
            });
            context.ThuongLes.AddRange(new List<ThuongLe>()
            {
                new ThuongLe()
                {
                    ThuongLeId = "0",
                    NgayLe = null,
                    TienThuongLe = "0",
                },
            });

            context.SaveChanges();
        }
    }
}
