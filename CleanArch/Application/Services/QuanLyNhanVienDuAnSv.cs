using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class QuanLyNhanVienDuAnSv : IQuanLyNhanVienDuAnSv
    {
        private readonly INhanVienAc nhanVienAc;
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        private readonly IPhongBanAc phongBanAc;
        private readonly IChucVuAc chucVuAc;
        private readonly IDuAnAc duAnAc;
        private readonly INhanVienDuAnAc nhanVienDuAnAc;
        private readonly IAccountAc accountAc;

        public QuanLyNhanVienDuAnSv(INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc,
            IPhongBanAc phongBanAc, IChucVuAc chucVuAc, IDuAnAc duAnAc, INhanVienDuAnAc nhanVienDuAnAc,
            IHopDongAc hopDongAc, IAccountAc accountAc)
        {
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.phongBanAc = phongBanAc;
            this.chucVuAc = chucVuAc;
            this.duAnAc = duAnAc;
            this.nhanVienDuAnAc = nhanVienDuAnAc;
            this.accountAc = accountAc;
        }

        public List<QuanLyNhanVienDuAn> GetList(string NhanVienIdToken, string DuAnId)
        {
            return QuanLyNhanVienDuAnMap.ToListNVDADTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(),
                phongBanAc.ToList(), chucVuAc.ToList(), nhanVienDuAnAc.ToList(),
                NhanVienIdToken, accountAc.ToList(), DuAnId);
        }

    }
}
