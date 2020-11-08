using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IAccountAc accounts;
        public HomeController(IAccountAc accounts)
        {
            this.accounts = accounts;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index(Login login)
        {
            var ac = this.accounts.ToList().Find(x => x.TaiKhoan == login.email && x.MatKhau == login.pass);

            if (ac != null)
            {
                return LocalRedirect("/Admin/dashboard");
            }
            ViewBag.error = "Lỗi: sai thông tin đăng nhập!";
            return View();
        }
    }
}
