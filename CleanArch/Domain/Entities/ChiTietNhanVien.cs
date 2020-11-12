using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ChiTietNhanVien
    {
        [Key]
        [Required]
        [StringLength(45)]
        public string ChiTietNhanVienId { get; set; }
        public DateTime? NgaySinh { get; set; }
        [StringLength(45)]
        public string NoiSinh { get; set; }
        [StringLength(45)]
        public string TrinhDoHocVan { get; set; }
        [StringLength(45)]
        public string GioiTinh { get; set; }
        [StringLength(45)]
        public string CMNN { get; set; }
        public DateTime? NgayCapCMNN { get; set; }
        [StringLength(45)]
        public string DiaChi { get; set; }
        [StringLength(45)]
        public string SDT { get; set; }
        [StringLength(45)]
        public string Email { get; set; }
        [StringLength(45)]
        public string HinhAnh { get; set; }

        //Foreign key----
        [Required]
        [StringLength(45)]
        public string NhanVienId { get; set; }

        public NhanVien NhanVien { get; set; }

    }
}
