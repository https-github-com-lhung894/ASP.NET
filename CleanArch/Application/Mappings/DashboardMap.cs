using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class DashboardMap
    {
        public static Dashboard ToDTO(this List<DuAnDTO> duAns, int TongNhanVien, string TongTienNhanVienThangTruoc, int SoNhanVienLamHomQua,
            int SoNhanVienNghiHomQua)
        {
            return new Dashboard()
            {
                DuAns = duAns,
                TongLuongNhanVienThangTruoc = TongTienNhanVienThangTruoc,
                TongNhanVien = TongNhanVien,
                SoNhanVienLamHomQua = SoNhanVienLamHomQua,
                SoNhanVienNghiHomQua = SoNhanVienNghiHomQua
            };
        }
    }
}
