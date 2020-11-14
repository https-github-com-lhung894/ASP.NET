using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class NhanVienCongViec
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string NhanVienCongViecId { get; set; }
        public double? HSCongViec { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string CongViecId { get; set; }

        public NhanVien NhanVien { get; set; }
        public CongViec CongViec { get; set; }
    }
}
