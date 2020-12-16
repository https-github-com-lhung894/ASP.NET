using Application.DTOs;
using Application.Interfaces;
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
    [Route("LuongNhanVien")]
    public class LuongNhanVienController : Controller
    {
        private readonly ILuongThangSv luongThangSv;
        public LuongNhanVienController(ILuongThangSv luongThangSv)
        {
            this.luongThangSv = luongThangSv;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List<LuongThangDTO> luongThangDTOs, string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio,
                string Tu, string Den) objs = (luongThangSv.ToListById(NhanVienIdToken()), null, null, 0, null, 0, null, null, null);

            return View(objs);
        }
        [HttpPost]
        [Route("")]
        [Route("Index")]
        public IActionResult Index(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio, string Tu, string Den)
        {
            List<LuongThangDTO> luongThangDTOs = luongThangSv.Filter(NhanVienIdToken(), ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den, NhanVienIdToken());

            (List<LuongThangDTO> luongThangDTOs, string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio,
                string Tu, string Den) objs = (luongThangDTOs, NhanVienIdToken(), ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den);

            return View(objs);
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
