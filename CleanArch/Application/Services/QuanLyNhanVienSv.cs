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
            string errorMessage;
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, double? luongCanBan) objs 
                = quanLyNhanVien.ToObjs();
            errorMessage = nhanVienAc.CheckRelationship(objs.nhanVien);
            if(errorMessage == null)
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
            string errorMessage = null;
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, double? luongCanBan) objs
                = quanLyNhanVien.ToObjs();
            
            if (errorMessage == null)
            {
                errorMessage += accountAc.Update(objs.account);
                errorMessage += nhanVienAc.Update(objs.nhanVien);
                errorMessage += chiTietNhanVienAc.Update(objs.chiTietNhanVien);

                errorMessage += nhanVienCongViecAc.Update(nhanVienCongViecAc.SetupForUpdate(objs.nhanVien.NhanVienId, objs.congViecId));
                errorMessage += hopDongAc.Update(hopDongAc.SetupForUpdate(objs.nhanVien.NhanVienId, objs.congViecId, objs.luongCanBan));
            }
            return errorMessage;
        }

        public List<QuanLyNhanVien> GetList()
        {
            return QuanLyNhanVienMap.ToListDTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(), phongBanAc.ToList(), 
                chucVuAc.ToList(), nhanVienCongViecAc.ToList(), congViecAc.ToList(), hopDongAc.ToList(), accountAc.ToList());
        }

        public List<QuanLyNhanVien> GetListNVPB(string id)
        {
            return QuanLyNhanVienMap.ToListNVPBDTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(), phongBanAc.ToList(),
                chucVuAc.ToList(), nhanVienCongViecAc.ToList(), congViecAc.ToList(), hopDongAc.ToList(), accountAc.ToList(), id);
        }

    }
}
