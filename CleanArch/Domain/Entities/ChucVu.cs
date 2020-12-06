using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ChucVu
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string ChucVuId { get; set; }
        [StringLength(45)]
        public string TenChucVu { get; set; }
        public double? HSChucVu { get; set; }
        public string TienPhuCapChucVu { get; set; }

        //----
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
