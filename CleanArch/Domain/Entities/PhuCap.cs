using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PhuCap
    {
        public PhuCap()
        {
            TrangThai = 1;
        }
        [Key]
        [Required]
        [StringLength(45)]
        public string PhuCapId { get; set; }
        [StringLength(45)]
        public string TenPhuCap { get; set; }
        public double TienPhuCap { get; set; }
        public int? TrangThai { get; set; }

        //----
        public ICollection<NhanVienPhuCap> NhanVienPhuCaps { get; set; }
    }
}
