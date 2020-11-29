using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILoginSv loginSv;
        private readonly INhanVienCongViecAc nhanVienCongViecAc;
        public HomeController(ILoginSv loginSv, INhanVienCongViecAc nhanVienCongViecAc)
        {
            this.loginSv = loginSv;
            this.nhanVienCongViecAc = nhanVienCongViecAc;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            List<NhanVienCongViec> li = nhanVienCongViecAc.ToList();
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index(LoginDTO login)
        {
            var ac = this.loginSv.GetAllAccount().Find(x => x.email == login.email && x.pass == login.pass);

            if (ac != null)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Dashboard");
            }
            ViewBag.error = "Sai thông tin đăng nhập!";
            return View();
        }
    }
}
