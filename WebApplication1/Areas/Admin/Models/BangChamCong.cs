using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
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
