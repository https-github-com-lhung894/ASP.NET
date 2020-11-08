using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class Account
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string AccountId { get; set; }
        [StringLength(45)]
        public string TaiKhoan { get; set; }
        [StringLength(45)]
        public string MatKhau { get; set; }
        [StringLength(45)]
        public int? Quyen { get; set; }
        
        //----
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}