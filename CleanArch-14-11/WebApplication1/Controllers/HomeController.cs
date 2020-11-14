using Domain.Entities;
using Domain.IActions;
using Domain.ValueObject;
using Infrastructure.Persistence.Actions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly INhanVienAc _nhanVien;
        private readonly IAccountAc _account;
        public HomeController(IAccountAc _account, INhanVienAc _nhanVien)
        {
            this._nhanVien = _nhanVien;
            this._account = _account;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            NhanVien nhanVien = new NhanVien()
            {
                NhanVienId = AutoKey.InCreasedByOne("nv00009"),
                HoNhanVien = "Lê",
                TenNhanVien = "Tèo",
                PhongBanId = "pb00001",
                ChucVuId = "chucvu1",
                AccountId = "nv00000"
            };
            ViewBag.error = _nhanVien.Add(nhanVien);
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index(Login login)
        {
            var ac = this._account.ToList().Find(x => x.TaiKhoan == login.email && x.MatKhau == login.pass);

            if (ac != null)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Dashboard");
            }
            ViewBag.error = "Sai thông tin đăng nhập!";
            return View();
        }
    }
}
