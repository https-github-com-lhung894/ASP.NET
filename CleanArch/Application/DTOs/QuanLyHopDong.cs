using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class QuanLyHopDong
    {
        public string NhanVienId { get; set; }
        public string HoNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string HopDongId { get; set; }
        public DateTime? NgayKyHopDong { get; set; }
        public string LuongCanBan { get; set; }
        public int? TrangThai { get; set; }
        public string ChucVuId { get; set; }
        public string TenChucVu { get; set; }
        public string CongViecId { get; set; }
        public string TenCongViec { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string HinhAnh { get; set; }
    }
}
