using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class QuanLyNhanVienSv : IQuanLyNhanVienSv
    {
        private readonly IAccountAc accountAc;
        private readonly INhanVienAc nhanVienAc;
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        private readonly INhanVienCongViecAc nhanVienCongViecAc;
        private readonly IPhongBanAc phongBanAc;
        private readonly IChucVuAc chucVuAc;
        private readonly ICongViecAc congViecAc;
        private readonly IHopDongAc hopDongAc;
        public QuanLyNhanVienSv(IAccountAc accountAc, INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc, 
            INhanVienCongViecAc nhanVienCongViecAc, IPhongBanAc phongBanAc, IChucVuAc chucVuAc, ICongViecAc congViecAc, 
            IHopDongAc hopDongAc)
        {
            this.accountAc = accountAc;
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.nhanVienCongViecAc = nhanVienCongViecAc;
            this.phongBanAc = phongBanAc;
            this.chucVuAc = chucVuAc;
            this.congViecAc = congViecAc;
            this.hopDongAc = hopDongAc;
        }
        public string AddNhanVien(QuanLyNhanVien quanLyNhanVien)
        {
            string errorMessage = "";
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, string luongCanBan) objs 
                = quanLyNhanVien.ToObjs();
            errorMessage += nhanVienAc.CheckRelationship(objs.nhanVien);
            if (errorMessage == "")
            {
                errorMessage += accountAc.Add(objs.account);
                errorMessage += nhanVienAc.Add(objs.nhanVien);
                errorMessage += chiTietNhanVienAc.Add(objs.chiTietNhanVien);

                errorMessage += nhanVienCongViecAc.AutoAdd(objs.nhanVien.NhanVienId, objs.congViecId);
                errorMessage += hopDongAc.AutoAdd(objs.nhanVien.NhanVienId, objs.congViecId, objs.luongCanBan);
            }
            return errorMessage;
        }

        public string UpdateNhanVien(QuanLyNhanVien quanLyNhanVien)
        {
            string errorMessage = "";
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, string luongCanBan) objs
                = quanLyNhanVien.ToObjs();

            errorMessage += nhanVienCongViecAc.CheckForeignKey(objs.nhanVien.NhanVienId, objs.congViecId);
            errorMessage += hopDongAc.CheckForeignKey(objs.nhanVien.NhanVienId, objs.congViecId);
            if (errorMessage == "")
            {
                errorMessage += nhanVienAc.Update(objs.nhanVien);
                errorMessage += chiTietNhanVienAc.Update(objs.chiTietNhanVien);
                
                errorMessage += accountAc.Update(objs.account);
                
                errorMessage += nhanVienCongViecAc.AutoUpdate(objs.nhanVien.NhanVienId, objs.congViecId);
                errorMessage += hopDongAc.AutoUpdate(objs.nhanVien.NhanVienId, objs.congViecId, objs.luongCanBan);
            }
            return errorMessage;
        }

        public List<QuanLyNhanVien> GetList(string NhanVienId)
        {
            return QuanLyNhanVienMap.ToListDTOs(NhanVienId,nhanVienAc.ToList(), chiTietNhanVienAc.ToList(), phongBanAc.ToList(), 
                chucVuAc.ToList(), nhanVienCongViecAc.ToList(), congViecAc.ToList(), hopDongAc.ToList(), accountAc.ToList());
        }

        public List<QuanLyNhanVien> GetListNVPB(string id)
        {
            return QuanLyNhanVienMap.ToListNVPBDTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(), phongBanAc.ToList(),
                chucVuAc.ToList(), nhanVienCongViecAc.ToList(), congViecAc.ToList(), hopDongAc.ToList(), accountAc.ToList(), id);
        }

        public QuanLyNhanVien GetByNhanVienId(string nhanVienId)
        {
            NhanVien nhanVien = nhanVienAc.FindById(nhanVienId);
            PhongBan phongBan = phongBanAc.ToList().Find(x => x.PhongBanId == nhanVien.PhongBanId);
            ChiTietNhanVien chiTietNhanVien = chiTietNhanVienAc.ToList().Find(x => x.ChiTietNhanVienId == nhanVien.NhanVienId);
            ChucVu chucVu = chucVuAc.ToList().Find(x => x.ChucVuId == nhanVien.ChucVuId);
            //Tìm công việc hiện tại ứng với nhân viên
            NhanVienCongViec nhanVienCongViec = nhanVienCongViecAc.ToList().Find(x => x.NhanVienId == nhanVien.NhanVienId && x.NgayKetThuc == null);
            CongViec congViec = null;
            if (nhanVienCongViec != null)
            {
                congViec = congViecAc.ToList().Find(x => x.CongViecId == nhanVienCongViec.CongViecId);
            }
            //Tìm hợp đồng hiện tại ứng với nhân viên
            HopDong hopDong = hopDongAc.ToList().Find(x => x.NhanVienId == nhanVien.NhanVienId && x.TrangThai == 1);
            Account account = accountAc.ToList().Find(x => x.AccountId == nhanVien.NhanVienId);

            return nhanVien.ToDTO(chiTietNhanVien, phongBan, chucVu, congViec, hopDong, account);
        }
    }
}
