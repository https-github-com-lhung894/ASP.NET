using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class HopDongDTO
    {
        [Required]
        [StringLength(45)]
        public string HopDongId { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public double? LuongCanBan { get; set; }
        public int? TrangThai { get; set; } = 1;
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string CongViecId { get; set; }
    }
}
