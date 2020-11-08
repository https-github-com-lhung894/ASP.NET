using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class HopDong
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string HopDongId { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public double? LuongCanBo { get; set; }
        public int? TrangThai { get; set; } = 1;

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
