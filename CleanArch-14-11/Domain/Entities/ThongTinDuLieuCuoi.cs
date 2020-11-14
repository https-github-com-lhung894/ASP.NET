using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ThongTinDuLieuCuoi
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string ThongTinDuLieuCuoiId { get; set; }
        [StringLength(45)]
        public string NhanVienId { get; set; }
        [StringLength(45)]
        public string DuAnId { get; set; }
        [StringLength(45)]
        public string PhongBanId { get; set; }
        [StringLength(45)]
        public string PhuCapId { get; set; }
    }
}
