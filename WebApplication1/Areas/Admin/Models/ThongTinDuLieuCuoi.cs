using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class ThongTinDuLieuCuoi
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string ThongTinDuLieuCuoiId { get; set; }
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [StringLength(45)]
        public string DuAnId { get; set; }
        [StringLength(45)]
        public string PhongBanId { get; set; }
        [StringLength(45)]
        public string PhuCapId { get; set; }
    }
}
