using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ChucVuDTO
    {
        [Required]
        [StringLength(45)]
        public string ChucVuId { get; set; }
        [StringLength(45)]
        public string TenChucVu { get; set; }
        public double? HSChucVu { get; set; }
        public double? TienPhuCapChucVu { get; set; }
    }
}
