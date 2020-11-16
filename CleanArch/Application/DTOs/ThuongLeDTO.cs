using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ThuongLeDTO
    {  
        [Required]
        [StringLength(45)]
        public string ThuongLeId { get; set; }
        public DateTime? NgayLe { get; set; }
        public double? TienThuongLe { get; set; }
    }
}
