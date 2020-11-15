using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
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