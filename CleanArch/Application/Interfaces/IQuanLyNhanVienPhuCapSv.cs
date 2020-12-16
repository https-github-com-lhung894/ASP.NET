using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IQuanLyNhanVienPhuCapSv
    {
        List<QuanLyNhanVienPhuCap> GetList(string NhanVienIdToken, string PhuCapId);
        //string UpdateNhanVienDuAn(QuanLyNhanVienDuAn quanLyNhanVienDuAn);
    }
}