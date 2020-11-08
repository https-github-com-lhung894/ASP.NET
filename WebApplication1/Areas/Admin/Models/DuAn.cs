using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class DuAn
    {
        public DuAn()
        {
            TrangThai = 1;
        }
        [Key]
        [Required]
        [StringLength(45)]
        public string DuAnId { get; set; }
        [StringLength(45)]
        public string TenDuAn { get; set; }
        [StringLength(45)]
        public string PhanTramDuAn { get; set; }
        [StringLength(45)]
        public string ThuongDuAn { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int? TrangThai { get; set; }

        //----
        public ICollection<NhanVienDuAn> NhanVienDuAns { get; set; }
    }
}
