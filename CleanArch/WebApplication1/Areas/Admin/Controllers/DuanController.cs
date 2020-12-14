using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    [Authorize(Roles = "0,1")]
    [Area("Admin")]
    [Route("DuAn")]
    public class DuAnController : Controller
    {
        private readonly IDuAnSv duAnSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyNhanVienDuAnSv quanLyNhanVienDuAnSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public DuAnController(IDuAnSv duAnSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc, IQuanLyNhanVienDuAnSv quanLyNhanVienDuAnSv,
            INhanVienSv nhanVienSv)
        {
            this.duAnSv = duAnSv;
            this.nhanVienSv = nhanVienSv;
            this.quanLyNhanVienDuAnSv = quanLyNhanVienDuAnSv;
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


        [Route("")]
        [Route("DuanDetail")]
        public IActionResult DuanDetail(string DuAnId)
        {
            (List<QuanLyNhanVienDuAn> nhanVienDuAns, DuAnDTO duAnDTO) objs;
            objs = new(quanLyNhanVienDuAnSv.GetList(NhanVienIdToken(), DuAnId), duAnSv.FindById(DuAnId));
            return View(objs);
        }

        public string NhanVienIdToken()
        {
            var jwt = HttpContext.Session.GetString("JWToken");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var claims = token.Claims.ToList();
            return claims[0].Value;
        }

        [HttpPost]
        [Route("")]
        [Route("AddDuAn")]
        public IActionResult AddDuAn(DuAnDTO duAnDTO)
        {
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
            duAnDTO.PhanTramDuAn = 100;
            duAnDTO.TrangThai = 1;
            Console.WriteLine(duAnDTO);
            DateTime dt = DateTime.Now;
            if (dt.Date > duAnDTO.NgayBatDau)
            {
                ViewBag.Error = "Ngày bắt đầu dự án phải lớn hơn ngày hiện tại!";
                return View("Index", objs);
            }
            if ((int)((DateTime)duAnDTO.NgayKetThuc - (DateTime)duAnDTO.NgayBatDau).Days < 15)
            {
                ViewBag.Error = "Ngày kết thúc dự án phải sau ngày bắt đầu 15 ngày!";
                return View("Index", objs);
            }
            string messerror = duAnSv.AddDuAn(duAnDTO);
            ViewBag.error = "Add " + messerror;
            if (messerror == null)
            {
                ThongTinDuLieuCuoi t = thongTinDuLieuCuoiAc.FindById("1");
                t.DuAnId = duAnDTO.DuAnId;
                thongTinDuLieuCuoiAc.Update(t);
            }
            return RedirectToAction(actionName: "Index", controllerName: "DuAn");
        }
    }

}
