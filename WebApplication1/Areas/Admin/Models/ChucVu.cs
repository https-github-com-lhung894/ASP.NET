using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class ChucVu
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string ChucVuId { get; set; }
        [StringLength(45)]
        public string TenChucVu { get; set; }
        public double? HSChucVu { get; set; }
        public double? TienPhuCapChuVu { get; set; }

        //----
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
