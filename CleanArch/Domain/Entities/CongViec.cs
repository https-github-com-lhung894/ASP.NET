using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CongViec
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string CongViecId { get; set; }
        [StringLength(45)]
        public string TenCongViec { get; set; }

        //----
        public ICollection<HopDong> HopDongs { get; set; }
    }
}
