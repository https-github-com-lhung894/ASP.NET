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

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
