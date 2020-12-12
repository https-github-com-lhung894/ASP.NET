using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize]
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
                string Tu, string Den) objs = (luongThangSv.ToList(), null, null, 0, null, 0, null, null, null);

            return View(objs);
        }
        [HttpPost]
        [Route("")]
        [Route("Index")]
        public IActionResult Index(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio, string Tu, string Den)
        {
            List<LuongThangDTO> luongThangDTOs = luongThangSv.Filter(NhanVienId, ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den);

            (List<LuongThangDTO> luongThangDTOs, string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio,
                string Tu, string Den) objs = (luongThangDTOs, NhanVienId, ThangChecked, Thang, NamChecked, Nam, optradio, Tu, Den);

            return View(objs);
        }
    }
}
