using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LuongThang
    {   
        [Key]
        [Required]
        public string LuongThangId { get; set; }
        public string LuongCoBan { get; set; }
        public double? HSChucVu { get; set; }
        public double? HSCongViec { get; set; }
        public int? SoNgayLam { get; set; }
        public int? SoNgayNghiCoPhep { get; set; }
        public int? SoNgayNghiKhongPhep { get; set; }
        public int? SoNgayNghiOm { get; set; }
        public string PhuCapNhanVien { get; set; }
        public string ThuongLe { get; set; }
        public string PhuCapChucVu { get; set; }
        public double? PhuCapThamNien { get; set; }
        public string TienDuAn { get; set; }
        public DateTime? NgayTinhLuong { get; set; }
        public string LuongThucLanh { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }

        public NhanVien NhanVien { get; set; }
    }
}
