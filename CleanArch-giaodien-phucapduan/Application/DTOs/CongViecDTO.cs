using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CongViecDTO
    {
        [Required]
        [StringLength(45)]
        public string CongViecId { get; set; }
        [StringLength(45)]
        public string TenCongViec { get; set; }
    }
}
