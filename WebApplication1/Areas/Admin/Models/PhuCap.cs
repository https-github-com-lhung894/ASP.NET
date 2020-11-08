using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class PhuCap
    {
        public PhuCap()
        {
            TrangThai = 1;
        }
        [Key]
        [Required]
        [StringLength(45)]
        public string PhuCapId { get; set; }
        [StringLength(45)]
        public string TenPhuCap { get; set; }
        public double TienPhuCap { get; set; }
        public int? TrangThai { get; set; }

        //----
        public ICollection<NhanVienPhuCap> NhanVienPhuCaps { get; set; }
    }
}
