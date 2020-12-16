using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Staff.Controllers
{
    [Authorize]
    [Area("Staff")]
    [Route("NhanVien")]
    public class NhanVienController : Controller
    {
        private readonly IQuanLyNhanVienSv quanLyNhanVienSv;
        private readonly IAccountSv accountSv;
        private readonly IChiTietNhanVienSv chiTietNhanVienSv;
        public NhanVienController(IQuanLyNhanVienSv quanLyNhanVienSv, IAccountSv accountSv, IChiTietNhanVienSv chiTietNhanVienSv)
        {
            this.quanLyNhanVienSv = quanLyNhanVienSv;
            this.accountSv = accountSv;
            this.chiTietNhanVienSv = chiTietNhanVienSv;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            QuanLyNhanVien quanLyNhanVien = quanLyNhanVienSv.GetByNhanVienId(NhanVienIdToken());
            return View(quanLyNhanVien);
        }
        [Route("")]
        [Route("UpdateNV")]
        public IActionResult UpdateNV()
        {
            QuanLyNhanVien quanLyNhanVien = quanLyNhanVienSv.GetByNhanVienId(NhanVienIdToken());
            return View(quanLyNhanVien);
        }
        [HttpPost]
        [Route("")]
        [Route("UpdateNV")]
        public IActionResult UpdateNV(string MatKhau, string HinhAnh)
        {
            string NhanVienId = NhanVienIdToken();
            AccountDTO accountDTO = accountSv.FindById(NhanVienId);
            ChiTietNhanVienDTO chiTietNhanVienDTO = chiTietNhanVienSv.FindById(NhanVienId);

            if(MatKhau != null)
            {
                accountDTO.MatKhau = MatKhau;
                accountSv.Update(accountDTO);
            }
            if(HinhAnh != null)
            {
                chiTietNhanVienDTO.HinhAnh = HinhAnh;
                chiTietNhanVienSv.Update(chiTietNhanVienDTO);
            }

            QuanLyNhanVien quanLyNhanVien = quanLyNhanVienSv.GetByNhanVienId(NhanVienIdToken());
            return View("Index",quanLyNhanVien);
        }
        private string NhanVienIdToken()
        {
            var jwt = HttpContext.Session.GetString("JWToken");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var claims = token.Claims.ToList();
            return claims[0].Value;
        }
    }
}
