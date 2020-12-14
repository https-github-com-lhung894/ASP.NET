using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IQuanLyNhanVienDuAnSv
    {
        List<QuanLyNhanVienDuAn> GetList(string NhanVienIdToken, string DuAnId);
        //string UpdateNhanVienDuAn(QuanLyNhanVienDuAn quanLyNhanVienDuAn);
    }
}