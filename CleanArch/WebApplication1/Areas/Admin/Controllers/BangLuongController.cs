using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("BangLuong")]
    public class BangLuongController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
