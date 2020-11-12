using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class MyData : DbContext
    {
        public MyData(DbContextOptions<MyData> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BangChamCong> BangChamCongs { get; set; }
        public DbSet<ChiTietNhanVien> ChiTietNhanViens { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<CongViec> CongViecs { get; set; }
        public DbSet<DuAn> DuAns { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<LuongThang> LuongThangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhanVienCongViec> NhanVienCongViecs { get; set; }
        public DbSet<NhanVienDuAn> NhanVienDuAns { get; set; }
        public DbSet<NhanVienPhuCap> NhanVienPhuCaps { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<PhuCap> PhuCaps { get; set; }
        public DbSet<ThongTinDuLieuCuoi> ThongTinDuLieuCuois { get; set; }
        public DbSet<ThuongLe> ThuongLes { get; set; }
        public DbSet<TrangThaiChamCong> TrangThaiChamCongs { get; set; }
    }
}
