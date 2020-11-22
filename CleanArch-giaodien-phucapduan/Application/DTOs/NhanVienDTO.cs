using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class NhanVienDTO
    {
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [StringLength(45)]
        public string HoNhanVien { get; set; }
        [StringLength(45)]
        public string TenNhanVien { get; set; }
        public int? TrangThai { get; set; }
        [Required]
        [StringLength(45)]
        public string PhongBanId { get; set; }
        [Required]
        [StringLength(45)]
        public string ChucVuId { get; set; }
        [Required]
        [StringLength(45)]
        public string AccountId { get; set; }
    }
}