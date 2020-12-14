using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class Dashboard
    {
        public string TongLuongNhanVienThangTruoc { get; set; }
        public int TongNhanVien { get; set; }
        public int SoNhanVienLamHomQua { get; set; }
        public int SoNhanVienNghiHomQua { get; set; }
        public List<DuAnDTO> DuAns { get; set; }
    }
}
