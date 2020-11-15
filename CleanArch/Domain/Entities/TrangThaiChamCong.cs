using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TrangThaiChamCong
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string TrangThaiChamCongId { get; set; }
        [StringLength(45)]
        public string TenTrangThai { get; set; }
        public double? HSTrangThai { get; set; }

        //----
        public ICollection<BangChamCong> BangChamCongs { get; set; }
    }
}
