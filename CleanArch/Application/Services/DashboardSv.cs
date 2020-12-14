using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DashboardSv : IDashboardSv
    {
        private readonly IDuAnSv duAnSv;
        private readonly IBangChamCongAc bangChamCongAc;
        private readonly INhanVienAc nhanVienAc;
        private readonly ILuongThangAc luongThangAc;
        public DashboardSv(IDuAnSv duAnSv, IBangChamCongAc bangChamCongAc, INhanVienAc nhanVienAc, ILuongThangAc luongThangAc)
        {
            this.duAnSv = duAnSv;
            this.bangChamCongAc = bangChamCongAc;
            this.nhanVienAc = nhanVienAc;
            this.luongThangAc = luongThangAc;
        }
        public Dashboard Get()
        {
            return duAnSv.ProjectInProgress().ToDTO(nhanVienAc.Count(), luongThangAc.TotalSalaryOfPreviousMonth(),
                bangChamCongAc.NOEGTWY(), bangChamCongAc.NOEOY());
        }
    }
}
