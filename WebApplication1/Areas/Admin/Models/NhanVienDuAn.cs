using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class NhanVienDuAn
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string NhanVienDuAnId { get; set; }
        [StringLength(45)]
        public string PhanTramCV { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string DuAnId { get; set; }

        public NhanVien NhanVien { get; set; }
        public DuAn DuAn { get; set; }
    }
}
