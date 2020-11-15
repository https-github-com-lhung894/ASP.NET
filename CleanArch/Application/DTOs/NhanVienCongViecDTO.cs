using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class NhanVienCongViecDTO
    {
        [Required]
        [StringLength(45)]
        public string NhanVienCongViecId { get; set; }
        public double? HSCongViec { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string CongViecId { get; set; }
    }
}
