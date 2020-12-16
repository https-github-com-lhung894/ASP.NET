using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    [Area("Admin")]
    [Route("Phucap")]
    public class PhucapController : Controller
    {
        private readonly IPhuCapSv phuCapSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly INhanVienPhuCapSv nhanVienPhuCapSv;
        private readonly IQuanLyNhanVienPhuCapSv quanLyNhanVienPhuCapSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public PhucapController(IPhuCapSv phuCapSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc, IQuanLyNhanVienPhuCapSv quanLyNhanVienPhuCapSv,
            INhanVienSv nhanVienSv, INhanVienPhuCapSv nhanVienPhuCapSv)
        {
            this.phuCapSv = phuCapSv;
            this.nhanVienSv = nhanVienSv;
            this.nhanVienPhuCapSv = nhanVienPhuCapSv;
            this.quanLyNhanVienPhuCapSv = quanLyNhanVienPhuCapSv;
            this.thongTinDuLieuCuoiAc = thongTinDuLieuCuoiAc;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List<PhuCapDTO> phuCapDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhuCapDTO phuCapDTO) objs;
            objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById("pc00001"));
            ViewBag.Update = "no";
            ViewBag.Find = "no";
            return View(objs);
        }




        [Route("")]
        [Route("PhucapDetail")]
        public IActionResult PhucapDetail(string PhuCapId)
        {
            (List<QuanLyNhanVienPhuCap> nhanVienPhucaps, PhuCapDTO phuCapDTO) objs;
            objs = new(quanLyNhanVienPhuCapSv.GetList(NhanVienIdToken(), PhuCapId), phuCapSv.FindById(PhuCapId));
            return View(objs);
        }

        public string NhanVienIdToken()
        {
            var jwt = HttpContext.Session.GetString("JWToken");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            var claims = token.Claims.ToList();
            return claims[0].Value;
        }

        [HttpPost]
        [Route("")]
        [Route("AddPhuCap")]
        public IActionResult AddPhuCap(PhuCapDTO phuCapDTO)
        {
            (List<PhuCapDTO> phuCapDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhuCapDTO phuCapDTO) objs;
            objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById("pc00001"));
            
            string messerror = phuCapSv.AddPhuCap(phuCapDTO);
            ViewBag.error = "Add " + messerror;
            
            return RedirectToAction(actionName: "Index", controllerName: "Phucap");
        }

        [Route("")]
        [Route("UpdateId")]
        public IActionResult UpdateId(string PhuCapId)
        {
            PhuCapDTO phuCapDTO = phuCapSv.FindById(PhuCapId);
            if (phuCapDTO == null)
            {
                ViewBag.Update = "Kiểm tra lại mã dự án";
                return RedirectToAction(actionName: "Index", controllerName: "Phucap");
            }
            ViewBag.Update = "yes";
            (List<PhuCapDTO> phuCapDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhuCapDTO phuCapDTO) objs;
            objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById(PhuCapId));
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("Update")]
        public IActionResult Update(PhuCapDTO phuCapDTO)
        {
            (List<PhuCapDTO> phuCapDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhuCapDTO phuCapDTO) objs;
            objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById(phuCapDTO.PhuCapId));
            ViewBag.error = "Update" + phuCapSv.UpdatePhuCap(phuCapDTO);
            ViewBag.Update = "no";
            return RedirectToAction(actionName: "Index", controllerName: "Phucap");
        }

        [HttpPost]
        [Route("")]
        [Route("Remove")]
        public IActionResult Remove(string PhuCapId)
        {
            PhuCapDTO phuCapDTO = phuCapSv.FindById(PhuCapId);
            (List<PhuCapDTO> phuCapDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhuCapDTO phuCapDTO) objs;
            objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById("pc00001"));
            if (phuCapDTO == null)
            {
                ViewBag.Remove = "Kiểm tra lại mã dự án";
                ViewBag.ErrorRemove = "yes";
                return View("Index", objs);
            }
            //List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>(quanLyNhanVienSv.GetListNVPB(id));
            List<QuanLyNhanVienPhuCap> nhanVienPhuCaps = quanLyNhanVienPhuCapSv.GetList(NhanVienIdToken(), PhuCapId);
            if (nhanVienPhuCaps.Count != 0)
            {
                ViewBag.Remove = "Xoá dự án thất bại! Dự án " + phuCapDTO.TenPhuCap + " vẫn còn nhân viên.";
                ViewBag.ErrorRemove = "yes";
                return View("Index", objs);
            }
            string messerror = phuCapSv.RemovePhuCap(phuCapDTO);
            if (messerror == null)
            {
                objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById("pc00001"));
                ViewBag.Remove = "Xoá dự án " + phuCapDTO.TenPhuCap + " thành công.";
                ViewBag.ErrorRemove = "no";
                return View("Index", objs);
            }
            ViewBag.Remove = "Xoá dự án thất bại! Lỗi " + messerror;
            ViewBag.ErrorRemove = "yes";
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("AddNVPC")]
        public IActionResult AddNVPC(string NhanVienId, string PhuCapId)
        {
            NhanVienPhuCapDTO nhanVienPhuCapDTO = new NhanVienPhuCapDTO();
            nhanVienPhuCapDTO.PhuCapId = PhuCapId;
            nhanVienPhuCapDTO.NhanVienId = NhanVienId;
            List<NhanVienPhuCapDTO> nhanVienPhuCap = nhanVienPhuCapSv.GetList();
            (List<PhuCapDTO> phuCapDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, PhuCapDTO phuCapDTO) objs;
            objs = new(phuCapSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), phuCapSv.FindById("pc00001"));
            foreach (NhanVienPhuCapDTO nvpc in nhanVienPhuCap)
            {
                if (nvpc.PhuCapId == nhanVienPhuCapDTO.PhuCapId && nvpc.NhanVienId == nhanVienPhuCapDTO.NhanVienId)
                {
                    ViewBag.ErrorNVPC = "Không thể thêm. Nhân viên " + nhanVienPhuCapDTO.NhanVienId + " đã trong dự án " + nhanVienPhuCapDTO.PhuCapId + "!";
                    return View("Index", objs);
                }
            }
            //string messerror = nhanVienDuAnSv.AddNVDA(nhanVienDuAnDTO);
            //ViewBag.error = "Add " + messerror;
            return RedirectToAction(actionName: "Index", controllerName: "Phucap");
        }

        [HttpPost]
        [Route("")]
        [Route("RemoveMultiNVPC")]
        public ActionResult RemoveMultiNVPC(IFormCollection formCollection)
        {
            string[] ids = formCollection["NhanVienPhuCapId"];
            string messerror = null;
            foreach (string id in ids)
            {
                NhanVienPhuCapDTO nhanVienPhuCapDTO = nhanVienPhuCapSv.FindById(id);
                messerror += nhanVienPhuCapSv.Remove(nhanVienPhuCapDTO);
            }
            return RedirectToAction(actionName: "Index", controllerName: "Phucap");
        }
    }

}
