﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class QuanLyNhanVien
    {
        public string NhanVienId { get; set; }
        public string HoNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string PhongBanId { get; set; }
        public string TenPhongBan { get; set; }
        public string ChucVuId { get; set; }
        public string TenChucVu { get; set; }
        public string CongViecId { get; set; }
        public string TenCongViec { get; set; }
        public string NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
        public string NgayCapCMND { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TrinhDoHocVan { get; set; }
        public string HinhAnh { get; set; }
        public string LuongCanBan { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int? Quyen { get; set; }
    }
}
