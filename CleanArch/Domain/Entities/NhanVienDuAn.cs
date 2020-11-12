using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class NhanVienDuAn
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string NhanVienDuAnId { get; set; }
        [StringLength(45)]
        public string PhanTramCV { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string DuAnId { get; set; }

        public NhanVien NhanVien { get; set; }
        public DuAn DuAn { get; set; }
    }
}
