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
        private readonly ILuongThangAc luongThangAc;
        private readonly IHopDongAc hopDongAc;
        public QuanLyNhanVienSv(IAccountAc accountAc, INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc, 
            INhanVienCongViecAc nhanVienCongViecAc, IPhongBanAc phongBanAc, IChucVuAc chucVuAc, ICongViecAc congViecAc, 
            ILuongThangAc luongThangAc, IHopDongAc hopDongAc)
        {
            this.accountAc = accountAc;
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.nhanVienCongViecAc = nhanVienCongViecAc;
            this.phongBanAc = phongBanAc;
            this.chucVuAc = chucVuAc;
            this.congViecAc = congViecAc;
            this.luongThangAc = luongThangAc;
            this.hopDongAc = hopDongAc;
        }
        public string AddNhanVien(AddNhanVien addNhanVien)
        {
            string errorMessage;
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien, string congViecId, double? luongCanBan) objs 
                = addNhanVien.ToObjs();
            errorMessage = nhanVienAc.CheckRelationship(objs.nhanVien);
            if(errorMessage == null)
            {
                accountAc.Add(objs.account);
                nhanVienAc.Add(objs.nhanVien);
                chiTietNhanVienAc.Add(objs.chiTietNhanVien);
                nhanVienCongViecAc.AutoAdd(objs.nhanVien.NhanVienId, objs.congViecId);
                hopDongAc.AutoAdd(objs.nhanVien.NhanVienId, objs.congViecId, objs.luongCanBan);
            }
            return errorMessage;
        }

        public List<QuanLyNhanVien> GetList()
        {
            return QuanLyNhanVienMap.ToListDTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(), phongBanAc.ToList(), 
                chucVuAc.ToList(), nhanVienCongViecAc.ToList(), congViecAc.ToList(), luongThangAc.ToList());
        }
    }
}
