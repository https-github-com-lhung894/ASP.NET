using System;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
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
