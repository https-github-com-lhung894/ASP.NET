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
            objs = new(phongBanSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"));
            ViewBag.Update = "no";
            return View(objs);
        }

        [HttpPost]
        [Route("")]
        [Route("AddPB")]
        public IActionResult AddPB(PhongBanDTO phongBanDTO)
        {
            string messerror = phongBanSv.AddPhongBan(phongBanDTO);
            ViewBag.error = "Add " + messerror;
            if (messerror == null)
            {
                ThongTinDuLieuCuoi t = thongTinDuLieuCuoiAc.FindById("1");
                t.PhongBanId = phongBanDTO.PhongBanId;
                thongTinDuLieuCuoiAc.Update(t);
            }
            return RedirectToAction(actionName: "Index", controllerName: "PhongBan");
        }

        [Route("")]
        [Route("Update")]
        public IActionResult Update()
        {
            (List<PhongBanDTO> phongBanDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois) objs;
            objs = new(phongBanSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"));
            ViewBag.Update = "yes";
            return View("Index", objs);
        }

        [Route("")]
        [Route("Details")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
