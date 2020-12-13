using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize(Roles ="0,1")]
    [Area("Admin")]
    [Route("BangLuong")]
    public class BangLuongController : Controller
    {
        private readonly ILuongThangSv luongThangSv;
        public BangLuongController(ILuongThangSv luongThangSv)
        {
            this.luongThangSv = luongThangSv;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            luongThangSv.AutoAdd();

            (List<LuongThangDTO> luongThangDTOs, string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio,
                string Tu, string Den) objs = (luongThangSv.ToList(NhanVienIdToken()), null, null, 0, null, 0, null, null, null);

            return View(objs);
        }
        [HttpPost]
        [Route("")]
        [Route("Index")]
        public IActionResult Index(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio, string Tu, string Den)
        {
            List<LuongThangDTO> luongThangDTOs = luongThangSv.Filter(NhanVienId, ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den, NhanVienIdToken());

            (List<LuongThangDTO> luongThangDTOs, string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio,
                string Tu, string Den) objs = (luongThangDTOs, NhanVienId, ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den);

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
