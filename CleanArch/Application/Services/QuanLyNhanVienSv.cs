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
        public QuanLyNhanVienSv(IAccountAc accountAc, INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc, 
            INhanVienCongViecAc nhanVienCongViecAc, IPhongBanAc phongBanAc, IChucVuAc chucVuAc, ICongViecAc congViecAc, ILuongThangAc luongThangAc)
        {
            this.accountAc = accountAc;
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.nhanVienCongViecAc = nhanVienCongViecAc;
            this.phongBanAc = phongBanAc;
            this.chucVuAc = chucVuAc;
            this.congViecAc = congViecAc;
            this.luongThangAc = luongThangAc;
        }
        public string AddNhanVien(QuanLyNhanVien quanLyNhanVien)
        {
            string errorMessage;
            (Account account, NhanVien nhanVien, ChiTietNhanVien chiTietNhanVien) objs = quanLyNhanVien.ToObjs();
            errorMessage = nhanVienAc.CheckRelationship(objs.nhanVien);
            if(errorMessage == null)
            {
                accountAc.Add(objs.account);
                nhanVienAc.Add(objs.nhanVien);
                chiTietNhanVienAc.Add(objs.chiTietNhanVien);
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
