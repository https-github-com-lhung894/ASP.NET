using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PhongBanDTO
    {   
        [Required]
        [StringLength(45)]
        public string PhongBanId { get; set; }
        [StringLength(45)]
        public string TenPhongBan { get; set; }
        [StringLength(45)]
        public string SDTPhongBan { get; set; }
        public int? TrangThai { get; set; }
    }
}
