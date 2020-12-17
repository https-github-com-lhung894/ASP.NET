using Domain.IActions;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("ChamCong")]
    public class ChamCongController : Controller
    {
        private readonly IBangChamCongSv bccSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly IBangChamCongAc bangChamCongAc;
        public ChamCongController(IBangChamCongSv bccSv, INhanVienSv nhanVienSv, IBangChamCongAc bangChamCongAc)
        {
            this.bccSv = bccSv;
            this.nhanVienSv = nhanVienSv;
            this.bangChamCongAc = bangChamCongAc;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List<BangChamCongDTO> bangChamCongDTOs, BangChamCongDTO bangChamCongDTO) objs;
            objs = new(bccSv.ToList(), bccSv.FindById("1"));
            ViewBag.Update = "no";
            DateTime dateTime = DateTime.Now;
            ViewBag.Datetime = dateTime;
            return View(objs);
        }

        [HttpPost]
        [Route("")]
        [Route("CapPhat")]
        public IActionResult CapPhat()
        {
            bangChamCongAc.TuCapPhat();
            return RedirectToAction(actionName: "Index", controllerName: "ChamCong");
        }

        [Route("")]
        [Route("UpdateId")]
        public IActionResult UpdateId(string id)
        {
            BangChamCongDTO bccDTO = bccSv.FindById(id);
            if (bccDTO == null)
            {
                ViewBag.Update = "Kiểm tra lại mã chấm công";
                return RedirectToAction(actionName: "Index", controllerName: "ChamCong");
            }
            ViewBag.Update = "yes";
            DateTime dateTime = DateTime.Now;
            ViewBag.Datetime = dateTime;
            (List<BangChamCongDTO> bangChamCongDTOs, BangChamCongDTO bangChamCongDTO) objs;
            objs = new(bccSv.ToList(), bccSv.FindById(id));
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("Update")]
        public IActionResult Update(BangChamCongDTO bangChamCongDTO)
        {
            //ViewBag.a = bangChamCongDTO.BangChamCongId;
            //ViewBag.b = bangChamCongDTO.NgayLamViec;
            //ViewBag.c = bangChamCongDTO.NhanVienId;
            //ViewBag.d = bangChamCongDTO.TrangThaiChamCongId;

            bccSv.UpdateChamCong(bangChamCongDTO);
            //ViewBag.Update = "no";
            //return RedirectToAction(actionName: "Index", controllerName: "ChamCong");
            (List<BangChamCongDTO> bangChamCongDTOs, BangChamCongDTO bangChamCongDTO) objs;
            objs = new(bccSv.ToList(), bccSv.FindById("1"));
            ViewBag.Update = "no";
            DateTime dateTime = DateTime.Now;
            ViewBag.Datetime = dateTime;
            return View("Index", objs);
        }
    }
}