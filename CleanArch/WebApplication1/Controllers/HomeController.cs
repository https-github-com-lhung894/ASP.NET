using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Infrastructure.Persistence.Actions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
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
        //[HttpPost]
        //[Route("")]
        //[Route("~/")]
        //[Route("index")]
        //public IActionResult Index(LoginDTO login)
        //{
        //    var ac = this.loginSv.GetAllAccount().Find(x => x.email == login.email && x.pass == login.pass);

        //    if (ac != null)
        //    {
        //        return RedirectToAction(actionName: "Index", controllerName: "Dashboard");
        //    }
        //    ViewBag.error = "Sai thông tin đăng nhập!";
        //    return View();
        //}
        [HttpPost]
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public async Task<IActionResult> Index(LoginDTO login)
        {
            var ac = this.loginSv.GetAllAccount().Find(x => x.email == login.email && x.pass == login.pass);

            if (ac != null)
            {
                var claims = new[]
                {
                    new Claim("Email", login.email)
                };
                var tokenString = GenerateJSONWebToken(claims);

                HttpContext.Session.SetString("JWToken", tokenString);

                return Redirect("~/Dashboard/Index");
            }
            ViewBag.error = "Sai thông tin đăng nhập!";
            return View();
        }

        private string GenerateJSONWebToken(Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hft4GJ7YF3Gdseg7dejo4"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
