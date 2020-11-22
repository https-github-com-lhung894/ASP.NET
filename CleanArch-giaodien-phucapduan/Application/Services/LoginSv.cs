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
        private readonly IAccountAc _accountAc;

        public LoginSv(IAccountAc _accountAc)
        {
            this._accountAc = _accountAc;
        }
        public List<LoginDTO> GetAllAccount()
        {
            List<Account> accounts = _accountAc.ToList();
            return accounts.ToLoginList();
        }
    }
}
