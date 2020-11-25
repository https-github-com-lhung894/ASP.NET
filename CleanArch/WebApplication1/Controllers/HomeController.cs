using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILoginSv loginSv;
        private readonly INhanVienAc nhanVienAc;
        public HomeController(ILoginSv loginSv, INhanVienAc nhanVienAc)
        {
            this.loginSv = loginSv;
            this.nhanVienAc = nhanVienAc;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            //NhanVien nhan = new NhanVien()
            //{
            //    NhanVienId = "nv00032",
            //    HoNhanVien = "Nguyễn",
            //    TenNhanVien = "Trung Anh 1",
            //    PhongBanId = "pb00001",
            //    ChucVuId = "chucvu1",
            //    AccountId = "nv00032"
            //};
            //nhanVienAc.Update(nhan);
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
