using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class NhanVien
    {
        public NhanVien()
        {
            TrangThai = 1;
        }
        [Key]
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [StringLength(45)]
        public string HoNhanVien { get; set; }
        [StringLength(45)]
        public string TenNhanVien { get; set; }
        [DefaultValue(1)]
        public int? TrangThai { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string PhongBanId { get; set; }
        [Required]
        [StringLength(45)]
        public string ChucVuId { get; set; }
        [Required]
        [StringLength(45)]
        public string AccountId { get; set; }

        public PhongBan PhongBan { get; set; }
        public ChucVu ChucVu { get; set; }
        public Account Account { get; set; }

        //---
        public ICollection<LuongThang> LuongThangs { get; set; }
        public ICollection<NhanVienDuAn> NhanVienDuAns { get; set; }
        public ICollection<BangChamCong> BangChamCongs { get; set; }
        public ICollection<ChiTietNhanVien> ChiTietNhanViens { get; set; }
        public ICollection<NhanVienCongViec> nhanVienCongViecs { get; set; }
        public ICollection<HopDong> HopDongs { get; set; }
        public ICollection<NhanVienPhuCap> NhanVienPhuCaps { get; set; }
    }
}