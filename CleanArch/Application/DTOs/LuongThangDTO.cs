using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class LuongThangDTO
    {   
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
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        public string HinhAnh { get; set; }
        public string HoTenNhanVien { get; set; }
        public string TenPhongBan { get; set; }
    }
}
