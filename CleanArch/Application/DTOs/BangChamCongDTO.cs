using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class BangChamCongDTO
    {
        [Required]
        [StringLength(45)]
        public string BangChamCongId { get; set; }
        public DateTime NgayLamViec { get; set; }
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string TrangThaiChamCongId { get; set; }
    }
}
