using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PhuCapDTO
    {
        [Required]
        [StringLength(45)]
        public string PhuCapId { get; set; }
        [StringLength(45)]
        public string TenPhuCap { get; set; }
        public string TienPhuCap { get; set; }
        public int? TrangThai { get; set; }
    }
}
