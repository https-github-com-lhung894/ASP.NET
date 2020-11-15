using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class NhanVienDuAnDTO
    {
        [Required]
        [StringLength(45)]
        public string NhanVienDuAnId { get; set; }
        [StringLength(45)]
        public string PhanTramCV { get; set; }
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [Required]
        [StringLength(45)]
        public string DuAnId { get; set; }
    }
}
