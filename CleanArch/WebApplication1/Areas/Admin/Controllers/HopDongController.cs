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
    [Route("HopDong")]
    public class HopDongController : Controller
    {
        private readonly IHopDongSv hopDongSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyHopDongSv quanLyHopDongSv;
        public HopDongController(IHopDongSv hopDongSv, IQuanLyHopDongSv quanLyHopDongSv, INhanVienSv nhanVienSv)
        {
            this.hopDongSv = hopDongSv;
            this.nhanVienSv = nhanVienSv;
            this.quanLyHopDongSv = quanLyHopDongSv;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            List<QuanLyHopDong> quanLyHopDongs = quanLyHopDongSv.GetListNVHD(NhanVienIdToken());
            return View(quanLyHopDongs);
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
