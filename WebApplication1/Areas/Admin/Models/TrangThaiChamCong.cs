using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class TrangThaiChamCong
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string TrangThaiChamCongId { get; set; }
        [StringLength(45)]
        public string TenTrangThai { get; set; }
        public double? HSTrangThai { get; set; }

        //----
        public ICollection<BangChamCong> BangChamCongs { get; set; }
    }
}
