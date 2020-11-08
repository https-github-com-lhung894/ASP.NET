using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class PhongBan
    {   
        public PhongBan()
        {
            TrangThai = 1;
        }
        [Key]
        [Required]
        [StringLength(45)]
        public string PhongBanId { get; set; }
        [StringLength(45)]
        public string TenPhongBan { get; set; }
        [StringLength(45)]
        public string SDTPhongBan { get; set; }
        public int? TrangThai { get; set; }

        //----
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
