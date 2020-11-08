using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class NhanVienPhuCap
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string NhanVienPhuCapId { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string PhuCapId { get; set; }

        public NhanVien NhanVien { get; set; }
        public PhuCap PhuCap { get; set; }
    }
}
