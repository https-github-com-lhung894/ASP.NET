using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("PhongBan")]
    public class PhongBanController : Controller
    {
        private readonly IPhongBanSv phongBanSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public PhongBanController(IPhongBanSv phongBanSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc)
        {
            this.phongBanSv = phongBanSv;
            this.thongTinDuLieuCuoiAc = thongTinDuLieuCuoiAc;
        }
        
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List <PhongBanDTO> phongBanDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois) objs;
            objs = new(phongBanSv.ToList(), thongTinDuLieuCuoiAc.FindById("1"));
            return View(objs);
        }

        [HttpPost]
        [Route("")]
        [Route("AddPB")]
        public IActionResult AddPB(PhongBanDTO phongBanDTO)
        {
            ViewBag.error = "Add " + phongBanSv.Add(phongBanDTO);
            return RedirectToAction(actionName: "Index", controllerName: "PhongBan");
        }

        [Route("")]
        [Route("Details")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
