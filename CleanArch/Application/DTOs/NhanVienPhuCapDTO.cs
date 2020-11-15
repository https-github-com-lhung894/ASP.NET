using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class NhanVienPhuCapDTO
    {
        [Required]
        [StringLength(45)]
        public string NhanVienPhuCapId { get; set; }
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string PhuCapId { get; set; }
    }
}
