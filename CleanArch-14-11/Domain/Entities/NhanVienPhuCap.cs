using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class NhanVienPhuCap
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string NhanVienPhuCapId { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string PhuCapId { get; set; }

        public NhanVien NhanVien { get; set; }
        public PhuCap PhuCap { get; set; }
    }
}
