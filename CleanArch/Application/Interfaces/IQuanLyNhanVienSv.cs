using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IQuanLyNhanVienSv
    {
        string AddNhanVien(QuanLyNhanVien quanLyNhanVien);
        List<QuanLyNhanVien> GetList();
        string UpdateNhanVien(QuanLyNhanVien quanLyNhanVien);
        List<QuanLyNhanVien> GetListNVPB(string id);
        
    }
}
