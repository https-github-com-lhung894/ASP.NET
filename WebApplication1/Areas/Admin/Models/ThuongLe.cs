using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class ThuongLe
    {  
        [Key]
        [Required]
        [StringLength(45)]
        public string ThuongLeId { get; set; }
        public DateTime? NgayLe { get; set; }
        public double? TienThuongLe { get; set; }
    }
}
