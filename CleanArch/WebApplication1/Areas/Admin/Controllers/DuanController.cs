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
    [Route("Duan")]
    public class DuanController : Controller
    {
        private readonly IDuAnSv duAnSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyNhanVienDuAnSv quanLyNhanVienDuAnSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public DuanController(IDuAnSv duAnSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc, IQuanLyNhanVienDuAnSv quanLyNhanVienDuAnSv,
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
            objs = new(quanLyNhanVienDuAnSv.GetList(NhanVienIdToken(),DuAnId), duAnSv.FindById(DuAnId));
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
    }

}
