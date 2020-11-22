﻿using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("QuanLyNhanVien")]
    public class QuanLyNhanVienController : Controller
    {
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyNhanVienSv quanLyNhanVienSv;
        private readonly IPhongBanSv phongBanSv;
        private readonly ICongViecSv congViecSv;
        private readonly IChucVuSv chucVuSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public QuanLyNhanVienController(IQuanLyNhanVienSv quanLyNhanVienSv, INhanVienSv nhanVienSv,
           IPhongBanSv phongBanSv, ICongViecSv congViecSv, IChucVuSv chucVuSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc)
        {
            this.quanLyNhanVienSv = quanLyNhanVienSv;
            this.nhanVienSv = nhanVienSv;
            this.phongBanSv = phongBanSv;
            this.congViecSv = congViecSv;
            this.chucVuSv = chucVuSv;
            this.thongTinDuLieuCuoiAc = thongTinDuLieuCuoiAc;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Search = "no";
            List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>();
            quanLyNhanViens.AddRange(quanLyNhanVienSv.GetList());
            return View(quanLyNhanViens);
        }

        [HttpPost]
        [Route("")]
        [Route("Index")]
        public IActionResult Index(string id)
        {
            NhanVienDTO nhanVienDTO = nhanVienSv.FindById(id);
            if(nhanVienDTO != null)
            {
                nhanVienSv.Remove(nhanVienDTO);
            }
            
            List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>();
            quanLyNhanViens.AddRange(quanLyNhanVienSv.GetList());
            return View(quanLyNhanViens);
        }

        [HttpPost]
        [Route("")]
        [Route("Search")]
        public IActionResult Search(string id)
        {
            ViewBag.Search = "yes";
            List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>();
            QuanLyNhanVien quanLyNhanVien = quanLyNhanVienSv.GetList().Find(x => x.NhanVienId == id);
            quanLyNhanViens.Add( quanLyNhanVien == null ? new QuanLyNhanVien() : quanLyNhanVien);
            return View("Index", quanLyNhanViens);
            //return View(quanLyNhanViens);
        }

        [Route("")]
        [Route("AddNV")]
        public IActionResult AddNV()
        {
            (List<PhongBanDTO> phongBanDTOs, List<CongViecDTO> congViecDTOs, List<ChucVuDTO> chucVuDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois) objs;
            objs = new(phongBanSv.ToList(), congViecSv.ToList(), chucVuSv.ToList(), thongTinDuLieuCuoiAc.FindById("1"));
            return View(objs);
        }

        [HttpPost]
        [Route("")]
        [Route("AddNV")]
        public IActionResult AddNV(AddNhanVien addNhanVien)
        {
            ViewBag.error = quanLyNhanVienSv.AddNhanVien(addNhanVien);
            return RedirectToAction(actionName: "Index", controllerName: "QuanLyNhanVien");
        }
    }
}