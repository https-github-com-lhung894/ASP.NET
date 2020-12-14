using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class QuanLyNhanVienDuAn
    {
        public string NhanVienId { get; set; }
        public string HoNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string PhongBanId { get; set; }
        public string TenPhongBan { get; set; }
        public string NhanVienDuAnId { get; set; }
        public double? PhanTramCV { get; set; }
        public string ChucVuId { get; set; }
        public string TenChucVu { get; set; }
        public string HinhAnh { get; set; }
    }
}
