using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.IActions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize(Roles = "0")]
    [Area("Admin")]
    [Route("PhongBan")]
    public class PhongBanController : Controller
    {
        private readonly IPhongBanSv phongBanSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly IQuanLyNhanVienSv quanLyNhanVienSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public PhongBanController(IPhongBanSv phongBanSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc, IQuanLyNhanVienSv quanLyNhanVienSv,
            INhanVienSv nhanVienSv)
        {
            this.phongBanSv = phongBanSv;
            this.nhanVienSv = nhanVienSv;
            this.quanLyNhanVienSv = quanLyNhanVienSv;
            this.thongTinDuLieuCuoiAc = thongTinDuLieuCuoiAc;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List<PhongBanDTO> phongBanDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhongBanDTO PhongBanDTO) objs;
            objs = new(phongBanSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phongBanSv.FindById("null"));
            ViewBag.Update = "no";
            ViewBag.Find = "no";
            return View(objs);
        }

        [Route("")]
        [Route("FindIdPb")]
        public IActionResult FindIdPb(string PhongBanId)
        {
            //PhongBanDTO phongBanDTO = phongBanSv.FindById(PhongBanId);
            (List<PhongBanDTO> phongBanDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhongBanDTO PhongBanDTO) objs;
            objs = new(phongBanSv.GetListPb(PhongBanId), thongTinDuLieuCuoiAc.FindById("1"), phongBanSv.FindById("null"));
            ViewBag.Find = "yes";
            ViewBag.Update = "no";
            return View("Index",objs);
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

        //Giao diện update
        [Route("")]
        [Route("UpdateId")]
        public IActionResult UpdateId(string id)
        {
            PhongBanDTO phongBanDTO = phongBanSv.FindById(id);
            if (phongBanDTO == null)
            {
                ViewBag.Update = "Kiểm tra lại mã phòng ban";
                return RedirectToAction(actionName: "Index", controllerName: "PhongBan");
            }
            ViewBag.Update = "yes";
            (List<PhongBanDTO> phongBanDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhongBanDTO phongBanDTO) objs;
            objs = new(phongBanSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phongBanSv.FindById(id));
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("Update")]
        public IActionResult Update(PhongBanDTO phongBanDTO)
        {
            string a = phongBanDTO.PhongBanId;
            ViewBag.error = "Update" + phongBanSv.UpdatePhongBan(phongBanDTO);
            ViewBag.Update = "no";
            return RedirectToAction(actionName: "Index", controllerName: "PhongBan");
        }

        [Route("")]
        [Route("Details")]
        public IActionResult Details(string id)
        {
            (List<QuanLyNhanVien> quanLyNhanViens, PhongBanDTO phongBanDTO) objs;
            objs = new(quanLyNhanVienSv.GetListNVPB(id), phongBanSv.FindById(id));
            return View(objs);
        }

        [HttpPost]
        [Route("")]
        [Route("Remove")]
        public IActionResult Remove(string id)
        {
            PhongBanDTO phongBanDTO = phongBanSv.FindById(id);
            (List<PhongBanDTO> phongBanDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhongBanDTO PhongBanDTO) objs;
            objs = new(phongBanSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phongBanSv.FindById("null"));
            if (phongBanDTO == null)
            {
                ViewBag.Remove = "Kiểm tra lại mã phòng ban";
                ViewBag.ErrorRemove = "yes";
                return View("Index", objs);
            }
            //List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>(quanLyNhanVienSv.GetListNVPB(id));
            List<QuanLyNhanVien> quanLyNhanViens = quanLyNhanVienSv.GetListNVPB(id);
            if (quanLyNhanViens.Count != 0)
            {
                ViewBag.Remove = "Xoá phòng ban thất bại! Phòng ban " + phongBanDTO.TenPhongBan + " vẫn còn nhân viên.";
                ViewBag.ErrorRemove = "yes";
                return View("Index", objs);
            }
            string messerror = phongBanSv.RemovePhongBan(phongBanDTO);
            if (messerror == null)
            {
                objs = new(phongBanSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phongBanSv.FindById("null"));
                ViewBag.Remove = "Xoá phòng ban " + phongBanDTO.TenPhongBan + " thành công.";
                ViewBag.ErrorRemove = "no";
                return View("Index", objs);
            }
            ViewBag.Remove = "Xoá phòng ban thất bại! Lỗi " + messerror;
            ViewBag.ErrorRemove = "yes";
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("RemoveNVPB")]
        public IActionResult RemoveNVPB(string id)
        {
            NhanVienDTO nhanVienDTO = nhanVienSv.FindById(id);
            nhanVienDTO.PhongBanId = "null";
            string messerror = nhanVienSv.Update(nhanVienDTO);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            return RedirectToAction(actionName: "Index", controllerName: "PhongBan");
        }

        [HttpPost]
        [Route("")]
        [Route("RemoveMultiNVPB")]
        public ActionResult RemoveMultiNVPB(IFormCollection formCollection)
        {
            string[] ids = formCollection["NhanVienId"];
            string messerror = null;
            foreach (string id in ids)
            {
                NhanVienDTO nhanVienDTO = nhanVienSv.FindById(id);
                nhanVienDTO.PhongBanId = "null";
               messerror += nhanVienSv.Update(nhanVienDTO);
            }
            return RedirectToAction(actionName: "Index", controllerName: "PhongBan");
        }
    }
}
