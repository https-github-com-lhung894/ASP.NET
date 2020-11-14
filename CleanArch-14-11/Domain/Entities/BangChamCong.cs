using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BangChamCong
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string BangChamCongId { get; set; }
        public DateTime NgayLamViec { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string TrangThaiChamCongId { get; set; }

        public NhanVien NhanVien { get; set; }
        public TrangThaiChamCong TrangThaiChamCong { get; set; }
    }
}
