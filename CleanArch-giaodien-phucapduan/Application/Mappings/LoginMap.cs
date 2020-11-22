using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class LoginMap
    {
        public static LoginDTO ToLoginDTO(this Account account)
        {
            return new LoginDTO()
            {
                email = account.TaiKhoan,
                pass = account.MatKhau
            };
        }
        public static List<LoginDTO> ToLoginList(this List<Account> accounts)
        {
            List<LoginDTO> logins = new List<LoginDTO>();
            foreach(Account account in accounts)
            {
                logins.Add(account.ToLoginDTO());
            }
            return logins;
        }
    }
}
