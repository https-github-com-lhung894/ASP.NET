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
    [Authorize(Roles = "0,1")]
    [Area("Admin")]
    [Route("DuAn")]
    public class DuAnController : Controller
    {
        private readonly IDuAnSv duAnSv;
        private readonly INhanVienSv nhanVienSv;
        private readonly INhanVienDuAnSv nhanVienDuAnSv;
        private readonly IQuanLyNhanVienDuAnSv quanLyNhanVienDuAnSv;
        private readonly IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc;
        public DuAnController(IDuAnSv duAnSv, IThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc, IQuanLyNhanVienDuAnSv quanLyNhanVienDuAnSv,
            INhanVienSv nhanVienSv, INhanVienDuAnSv nhanVienDuAnSv)
        {
            this.duAnSv = duAnSv;
            this.nhanVienSv = nhanVienSv;
            this.nhanVienDuAnSv = nhanVienDuAnSv;
            this.quanLyNhanVienDuAnSv = quanLyNhanVienDuAnSv;
            this.thongTinDuLieuCuoiAc = thongTinDuLieuCuoiAc;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
            ViewBag.Update = "no";
            ViewBag.Find = "no";
            return View(objs);
        }

        [Route("")]
        [Route("DuanDetail")]
        public IActionResult DuanDetail(string DuAnId)
        {
            (List<QuanLyNhanVienDuAn> nhanVienDuAns, DuAnDTO duAnDTO) objs;
            objs = new(quanLyNhanVienDuAnSv.GetList(NhanVienIdToken(), DuAnId), duAnSv.FindById(DuAnId));
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
        [Route("AddDuAn")]
        public IActionResult AddDuAn(DuAnDTO duAnDTO)
        {
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
            duAnDTO.PhanTramDuAn = 100;
            duAnDTO.TrangThai = 1;
            DateTime dt = DateTime.Now;
            if (dt.Date > duAnDTO.NgayBatDau)
            {
                ViewBag.Error = "Ngày bắt đầu dự án phải lớn hơn ngày hiện tại!";
                return View("Index", objs);
            }
            if ((int)((DateTime)duAnDTO.NgayKetThuc - (DateTime)duAnDTO.NgayBatDau).Days < 15)
            {
                ViewBag.Error = "Ngày kết thúc dự án phải sau ngày bắt đầu 15 ngày!";
                return View("Index", objs);
            }
            string messerror = duAnSv.AddDuAn(duAnDTO);
            ViewBag.error = "Add " + messerror;
            if (messerror == null)
            {
                ThongTinDuLieuCuoi t = thongTinDuLieuCuoiAc.FindById("1");
                t.DuAnId = duAnDTO.DuAnId;
                thongTinDuLieuCuoiAc.Update(t);
            }
            return RedirectToAction(actionName: "Index", controllerName: "DuAn");
        }

        [Route("")]
        [Route("UpdateId")]
        public IActionResult UpdateId(string DuAnId)
        {
            DuAnDTO duAnDTO = duAnSv.FindById(DuAnId);
            if (duAnDTO == null)
            {
                ViewBag.Update = "Kiểm tra lại mã dự án";
                return RedirectToAction(actionName: "Index", controllerName: "DuAn");
            }
            ViewBag.Update = "yes";
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById(DuAnId));
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("Update")]
        public IActionResult Update(DuAnDTO duAnDTO)
        {
            DuAnDTO duAnDTOtemp = duAnSv.FindById(duAnDTO.DuAnId);
            duAnDTO.PhanTramDuAn = duAnDTOtemp.PhanTramDuAn;
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById(duAnDTO.DuAnId));
            if (duAnDTO.NgayBatDau < duAnDTOtemp.NgayBatDau)
            {
                ViewBag.Update = "yes";
                ViewBag.Error = "Ngày bắt đầu dự án phải bằng hoặc sau ngày bắt đầu cũ!";
                return View("Index", objs);
            }
            if ((int)((DateTime)duAnDTO.NgayKetThuc - (DateTime)duAnDTO.NgayBatDau).Days < 15)
            {
                ViewBag.Update = "yes";
                ViewBag.Error = "Ngày kết thúc dự án phải sau ngày bắt đầu 15 ngày!";
                return View("Index", objs);
            }
            ViewBag.error = "Update" + duAnSv.UpdateDuAn(duAnDTO);
            ViewBag.Update = "no";
            return RedirectToAction(actionName: "Index", controllerName: "DuAn");
        }

        [HttpPost]
        [Route("")]
        [Route("Remove")]
        public IActionResult Remove(string DuAnId)
        {
            DuAnDTO duAnDTO = duAnSv.FindById(DuAnId);
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
            if (duAnDTO == null)
            {
                ViewBag.Remove = "Kiểm tra lại mã dự án";
                ViewBag.ErrorRemove = "yes";
                return View("Index", objs);
            }
            //List<QuanLyNhanVien> quanLyNhanViens = new List<QuanLyNhanVien>(quanLyNhanVienSv.GetListNVPB(id));
            List<QuanLyNhanVienDuAn> nhanVienDuAns = quanLyNhanVienDuAnSv.GetList(NhanVienIdToken(), DuAnId);
            if (nhanVienDuAns.Count != 0)
            {
                ViewBag.Remove = "Xoá dự án thất bại! Dự án " + duAnDTO.TenDuAn + " vẫn còn nhân viên.";
                ViewBag.ErrorRemove = "yes";
                return View("Index", objs);
            }
            duAnDTO.TrangThai = 0;
            string messerror = duAnSv.UpdateDuAn(duAnDTO);
            if (messerror == null)
            {
                objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
                ViewBag.Remove = "Xoá dự án " + duAnDTO.TenDuAn + " thành công.";
                ViewBag.ErrorRemove = "no";
                return View("Index", objs);
            }
            ViewBag.Remove = "Xoá dự án thất bại! Lỗi " + messerror;
            ViewBag.ErrorRemove = "yes";
            return View("Index", objs);
        }

        [HttpPost]
        [Route("")]
        [Route("AddNVDA")]
        public IActionResult AddNVDA(string NhanVienId, string DuAnId, string PhanTramCV)
        {
            NhanVienDuAnDTO nhanVienDuAnDTO = new NhanVienDuAnDTO();
            nhanVienDuAnDTO.DuAnId = DuAnId;
            nhanVienDuAnDTO.NhanVienId = NhanVienId;
            nhanVienDuAnDTO.PhanTramCV = Convert.ToDouble(PhanTramCV);
            List<NhanVienDuAnDTO> nhanVienDuAn = nhanVienDuAnSv.GetList();
            (List<DuAnDTO> duAnDTOs, ThongTinDuLieuCuoi thongTinDuLieuCuois, DuAnDTO duAnDTO) objs;
            objs = new(duAnSv.GetList(), thongTinDuLieuCuoiAc.FindById("1"), duAnSv.FindById("da00001"));
            DuAnDTO duAnDTO = duAnSv.FindById(nhanVienDuAnDTO.DuAnId);
            DateTime dt = DateTime.Now;
            if (duAnDTO.TrangThai == 0)
            {
                ViewBag.ErrorNVDA = "Không thể thêm. Dự án " + nhanVienDuAnDTO.DuAnId + " không tồn tại!";
                return View("Index", objs);
            }
            if (duAnDTO.NgayKetThuc < dt)
            {
                ViewBag.ErrorNVDA = "Dự án đã kết thúc. Không thể thêm nhân viên vào nữa!";
                return View("Index", objs);
            }
            foreach(NhanVienDuAnDTO nvda in nhanVienDuAn)
            {
                if (nvda.DuAnId == nhanVienDuAnDTO.DuAnId && nvda.NhanVienId == nhanVienDuAnDTO.NhanVienId)
                {
                    ViewBag.ErrorNVDA = "Không thể thêm. Nhân viên " + nhanVienDuAnDTO.NhanVienId + " đã trong dự án " + nhanVienDuAnDTO.DuAnId + "!";
                    return View("Index", objs);
                }
            }
            if (duAnDTO.PhanTramDuAn < nhanVienDuAnDTO.PhanTramCV)
            {
                ViewBag.ErrorNVDA = "Phần trăm tham dự lớn hơn phần trăm còn lại của dự án!";
                return View("Index", objs);
            }
            string messerror = nhanVienDuAnSv.AddNVDA(nhanVienDuAnDTO);
            ViewBag.error = "Add " + messerror;
            if (messerror == null)
            {
                duAnDTO.PhanTramDuAn -= nhanVienDuAnDTO.PhanTramCV;
                ViewBag.error = "Update" + duAnSv.UpdateDuAn(duAnDTO);
            }
            return RedirectToAction(actionName: "Index", controllerName: "DuAn");
        }

        [HttpPost]
        [Route("")]
        [Route("UpdateNVDA")]
        public IActionResult UpdateNVDA(string NhanVienDuAnId, string NhanVienId, string DuAnId, string PhanTramCV)
        {
            NhanVienDuAnDTO nhanVienDuAnDTO = new NhanVienDuAnDTO();
            nhanVienDuAnDTO.NhanVienDuAnId = NhanVienDuAnId;
            nhanVienDuAnDTO.DuAnId = DuAnId;
            nhanVienDuAnDTO.NhanVienId = NhanVienId;
            nhanVienDuAnDTO.PhanTramCV = Convert.ToDouble(PhanTramCV);
            List<NhanVienDuAnDTO> nhanVienDuAns = nhanVienDuAnSv.GetList();
            (List<QuanLyNhanVienDuAn> nhanVienDuAns, DuAnDTO duAnDTO) objs;
            objs = new(quanLyNhanVienDuAnSv.GetList(NhanVienIdToken(), DuAnId), duAnSv.FindById(DuAnId));
            DuAnDTO duAnDTO = duAnSv.FindById(nhanVienDuAnDTO.DuAnId);
            double ptHienco = 0;
            DateTime dt = DateTime.Now;
            if (duAnDTO.NgayKetThuc < dt)
            {
                ViewBag.ErrorNVDA = "Dự án đã kết thúc. Không thể sửa phần trăm tham dự nữa!";
                return View("DuanDetail", objs);
            }
            foreach (NhanVienDuAnDTO nvda in nhanVienDuAns)
            {
                if (nvda.DuAnId == nhanVienDuAnDTO.DuAnId && nvda.NhanVienId == nhanVienDuAnDTO.NhanVienId)
                {
                    ptHienco = (double)nvda.PhanTramCV + (double)duAnDTO.PhanTramDuAn;
                    if ((nvda.PhanTramCV + duAnDTO.PhanTramDuAn) < nhanVienDuAnDTO.PhanTramCV)
                    {
                        //ViewBag.ErrorNVDA = "Không thể thêm. Nhân viên " + nhanVienDuAnDTO.NhanVienId + " đã trong dự án " + nhanVienDuAnDTO.DuAnId + "!";
                        ViewBag.ErrorNVDA = "Phần trăm tham dự lớn hơn phần trăm còn lại của dự án!";
                        return View("DuanDetail", objs);
                    }
                }
            }
            string messerror = nhanVienDuAnSv.UpdateNVDA(nhanVienDuAnDTO);
            ViewBag.error = "Update " + messerror;
            if (messerror == null)
            {
                duAnDTO.PhanTramDuAn = ptHienco - nhanVienDuAnDTO.PhanTramCV;
                ViewBag.error = "Update" + duAnSv.UpdateDuAn(duAnDTO);
            }
            return RedirectToAction(actionName: "Index", controllerName: "DuAn");
        }

        [HttpPost]
        [Route("")]
        [Route("RemoveMultiNVDA")]
        public ActionResult RemoveMultiNVDA(IFormCollection formCollection)
        {
            string[] ids = formCollection["NhanVienDuAnId"];
            string messerror = null;
            foreach (string id in ids)
            {
                NhanVienDuAnDTO nhanVienDuAnDTO = nhanVienDuAnSv.FindById(id);
                DuAnDTO duAnDTO = duAnSv.FindById(nhanVienDuAnDTO.DuAnId);
                duAnDTO.PhanTramDuAn += nhanVienDuAnDTO.PhanTramCV;
                messerror += nhanVienDuAnSv.Remove(nhanVienDuAnDTO);
                ViewBag.error = "Update" + duAnSv.UpdateDuAn(duAnDTO);
            }
            return RedirectToAction(actionName: "Index", controllerName: "DuAn");
        }
    }
}
