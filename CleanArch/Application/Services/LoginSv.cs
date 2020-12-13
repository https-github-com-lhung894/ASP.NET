using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class LoginSv : ILoginSv
    {
        private readonly INhanVienAc nhanVienAc;
        private readonly IAccountAc accountAc;

        public LoginSv(IAccountAc accountAc, INhanVienAc nhanVienAc)
        {
            this.accountAc = accountAc;
            this.nhanVienAc = nhanVienAc;
        }
        public List<LoginDTO> GetAllAccount()
        {
            List<NhanVien> nhanViens = nhanVienAc.ToList();
            List<Account> accounts = accountAc.ToList();
            return accounts.ToLoginList(nhanViens);
        }
    }
}
