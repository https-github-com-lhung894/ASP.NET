using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class QuanLyHopDongSv : IQuanLyHopDongSv
    {
        private readonly INhanVienAc nhanVienAc;
        private readonly IChiTietNhanVienAc chiTietNhanVienAc;
        private readonly INhanVienCongViecAc nhanVienCongViecAc;
        private readonly IChucVuAc chucVuAc;
        private readonly ICongViecAc congViecAc;
        private readonly IHopDongAc hopDongAc;

        public QuanLyHopDongSv(INhanVienAc nhanVienAc, IChiTietNhanVienAc chiTietNhanVienAc,
            INhanVienCongViecAc nhanVienCongViecAc, IChucVuAc chucVuAc, ICongViecAc congViecAc,
            IHopDongAc hopDongAc)
        {
            this.nhanVienAc = nhanVienAc;
            this.chiTietNhanVienAc = chiTietNhanVienAc;
            this.nhanVienCongViecAc = nhanVienCongViecAc;
            this.chucVuAc = chucVuAc;
            this.congViecAc = congViecAc;
            this.hopDongAc = hopDongAc;
        }

        public List<QuanLyHopDong> GetListNVHD()
        {
            return QuanLyHopDongMap.ToListNVHDDTOs(nhanVienAc.ToList(), chiTietNhanVienAc.ToList(),
                chucVuAc.ToList(), nhanVienCongViecAc.ToList(), congViecAc.ToList(), hopDongAc.ToList());
        }
    
    }
}
