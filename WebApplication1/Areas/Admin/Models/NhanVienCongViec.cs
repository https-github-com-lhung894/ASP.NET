using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
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
