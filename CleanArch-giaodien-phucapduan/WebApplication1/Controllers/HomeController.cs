using Application.DTOs;
using Application.Interfaces;
using Domain.IActions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILoginSv loginSv;
        private readonly INhanVienCongViecSv nhanVienCongViecSv;
        public HomeController(ILoginSv loginSv, INhanVienCongViecSv nhanVienCongViecSv)
        {
            this.loginSv = loginSv;
            this.nhanVienCongViecSv = nhanVienCongViecSv;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            NhanVienCongViecDTO nhanVienCongViecDTO = nhanVienCongViecSv.FindById("1");
            return View(nhanVienCongViecDTO);
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
