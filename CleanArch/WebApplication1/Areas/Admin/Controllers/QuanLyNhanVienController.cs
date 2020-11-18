using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("QuanLyNhanVien")]
    public class QuanLyNhanVienController : Controller
    {
        private readonly IQuanLyNhanVienSv quanLyNhanVienSv;
        public QuanLyNhanVienController(IQuanLyNhanVienSv quanLyNhanVienSv)
        {
            this.quanLyNhanVienSv = quanLyNhanVienSv;
        }
        [Route("")]
        public IActionResult Index()
        {
            List<QuanLyNhanVien> quanLyNhanViens = quanLyNhanVienSv.GetList();
            return View(quanLyNhanViens);
        }
    }
}
