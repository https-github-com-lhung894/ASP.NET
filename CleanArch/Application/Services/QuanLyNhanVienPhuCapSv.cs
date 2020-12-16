using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class QuanLyNhanVienPhuCapSv : IQuanLyNhanVienPhuCapSv
    {
        private readonly INhanVienAc nhanVienAc;
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        private readonly IPhongBanAc phongBanAc;
        private readonly IChucVuAc chucVuAc;
        private readonly IPhuCapAc phuCapAc;
        private readonly INhanVienPhuCapAc nhanVienPhuCapAc;
        private readonly IAccountAc accountAc;

        public QuanLyNhanVienPhuCapSv(INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc,
            IPhongBanAc phongBanAc, IChucVuAc chucVuAc, IPhuCapAc phuCapAc, INhanVienPhuCapAc nhanVienPhuCapAc,
            IHopDongAc hopDongAc, IAccountAc accountAc)
        {
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.phongBanAc = phongBanAc;
            this.chucVuAc = chucVuAc;
            this.phuCapAc = phuCapAc;
            this.nhanVienPhuCapAc = nhanVienPhuCapAc;
            this.accountAc = accountAc;
        }

        public List<QuanLyNhanVienPhuCap> GetList(string NhanVienIdToken, string PhuCapId)
        {
            return QuanLyNhanVienPhuCapMap.ToListNVPCDTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(),
                phongBanAc.ToList(), chucVuAc.ToList(), nhanVienPhuCapAc.ToList(),
                NhanVienIdToken, accountAc.ToList(), PhuCapId);
        }

    }
}
