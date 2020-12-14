using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DuAnDTO
    {
        [Required]
        [StringLength(45)]
        public string DuAnId { get; set; }
        [StringLength(45)]
        public string TenDuAn { get; set; }
        [StringLength(45)]
        public double? PhanTramDuAn { get; set; }
        [StringLength(45)]
        public string ThuongDuAn { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? SoLuongNhanVien { get; set; }
        public int? TrangThai { get; set; }
    }
}
