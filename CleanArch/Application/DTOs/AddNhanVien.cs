using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class AddNhanVien
    {
        public string NhanVienId { get; set; }
        public string HoNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string PhongBanId { get; set; }
        public string ChucVuId { get; set; }
        public string CongViecId { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string CMNN { get; set; }
        public DateTime? NgayCapCMNN { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string HinhAnh { get; set; }
        public string MatKhau { get; set; }
        public int? Quyen { get; set; }
    }
}
