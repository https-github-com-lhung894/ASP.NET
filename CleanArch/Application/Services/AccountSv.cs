using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.IActions;
using System.Collections.Generic;

namespace Application.Services
{
    public class AccountSv : IAccountSv
    {
        private readonly IAccountAc accountAc;
        public AccountSv(IAccountAc accountAc)
        {
            this.accountAc = accountAc;
        }
        public List<AccountDTO> ToList()
        {
            return accountAc.ToList().ToListDTO();
        }

        public AccountDTO FindById(string id)
        {
            return accountAc.FindById(id).ToDTO();
        }

        public string Add(AccountDTO obj)
        {
            return accountAc.Add(obj.ToAccount());
        }

        public string Remove(AccountDTO obj)
        {
            return accountAc.Remove(obj.ToAccount());
        }

        public string Update(AccountDTO obj)
        {
            return accountAc.Update(obj.ToAccount());
        }
    }
}
