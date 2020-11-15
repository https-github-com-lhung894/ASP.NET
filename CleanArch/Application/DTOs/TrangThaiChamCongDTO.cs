using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class TrangThaiChamCongDTO
    {
        [Required]
        [StringLength(45)]
        public string TrangThaiChamCongId { get; set; }
        [StringLength(45)]
        public string TenTrangThai { get; set; }
        public double? HSTrangThai { get; set; }
    }
}
