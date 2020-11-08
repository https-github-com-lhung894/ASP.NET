using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
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
