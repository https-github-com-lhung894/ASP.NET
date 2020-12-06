using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Infrastructure.Persistence.Actions;

namespace WebApplication1.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILoginSv loginSv;
        private readonly ILuongThangSv luongThangSv;
        public HomeController(ILoginSv loginSv, ILuongThangSv luongThangSv)
        {
            this.loginSv = loginSv;
            this.luongThangSv = luongThangSv;
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
