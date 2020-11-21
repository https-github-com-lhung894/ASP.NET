using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IQuanLyNhanVienSv
    {
        string AddNhanVien(AddNhanVien addNhanVien);
        List<QuanLyNhanVien> GetList();
    }
}
