using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Duan")]
    public class DuanController : Controller
    {
        private readonly IDuAnSv duAnSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyNhanVienSv quanLyNhanVienSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public DuanController(IDuAnSv duAnSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc, IQuanLyNhanVienSv quanLyNhanVienSv,
            INhanVienSv nhanVienSv)
        {
            this.duAnSv = duAnSv;
            this.nhanVienSv = nhanVienSv;
            this.quanLyNhanVienSv = quanLyNhanVienSv;
            this.thongTinDuLieuCuoiAc = thongTinDuLieuCuoiAc;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
            ViewBag.Update = "no";
            ViewBag.Find = "no";
            return View(objs);
        }

        [Route("DuanDetail")]
        public IActionResult DuanDetail()
        {
            return View();
        }
    }

}
