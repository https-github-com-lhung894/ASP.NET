using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class LuongThangDTO
    {   
        [Required]
        public string LuongThangId { get; set; }
        public double? LuongCoBan { get; set; }
        public double? HSChucVu { get; set; }
        public double? HSCongViec { get; set; }
        public int? SoNgayLam { get; set; }
        public int? SoNgayNghiCoPhep { get; set; }
        public int? SoNgayNghiKhongPhep { get; set; }
        public int? SoNgayNghiOm { get; set; }
        public double? PhuCapNhanVien { get; set; }
        public double? ThuongLe { get; set; }
        public double? PhuCapChucVu { get; set; }
        public double? PhuCapThamNien { get; set; }
        public double? TienDa { get; set; }
        public DateTime? NgayTinhLuong { get; set; }
        public double? LuongThucLanh { get; set; }
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
    }
}
