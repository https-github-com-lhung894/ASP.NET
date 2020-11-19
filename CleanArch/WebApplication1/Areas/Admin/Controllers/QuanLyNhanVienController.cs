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
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyNhanVienSv quanLyNhanVienSv;
        public QuanLyNhanVienController(IQuanLyNhanVienSv quanLyNhanVienSv, INhanVienSv nhanVienSv)
        {
            this.quanLyNhanVienSv = quanLyNhanVienSv;
            this.nhanVienSv = nhanVienSv;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>();
            quanLyNhanViens.AddRange(quanLyNhanVienSv.GetList());
            return View(quanLyNhanViens);
        }
        [HttpPost]
        [Route("")]
        [Route("Index")]
        public IActionResult Index(string id)
        {
            NhanVienDTO nhanVienDTO = nhanVienSv.FindById(id);
            if(nhanVienDTO != null)
            {
                nhanVienSv.Remove(nhanVienDTO);
            }
            
            List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>();
            quanLyNhanViens.AddRange(quanLyNhanVienSv.GetList());
            return View(quanLyNhanViens);
        }
        [HttpPost]
        [Route("")]
        [Route("Search")]
        public IActionResult Search(string id)
        {
            List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>();
            QuanLyNhanVien quanLyNhanVien = quanLyNhanVienSv.GetList().Find(x => x.NhanVienId == id);
            quanLyNhanViens.Add( quanLyNhanVien == null ? new QuanLyNhanVien() : quanLyNhanVien);
            return View(quanLyNhanViens);
        }
    }
}
