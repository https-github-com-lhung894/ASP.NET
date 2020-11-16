using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class AccountMap
    {
        public static AccountDTO ToDTO(this Account account)
        {
            return new AccountDTO()
            {
                AccountId = account.AccountId,
                TaiKhoan = account.TaiKhoan,
                MatKhau = account.MatKhau,
                Quyen = account.Quyen
            };
        }

        public static List<AccountDTO> ToListDTO(this List<Account> accounts)
        {
            List<AccountDTO> accountDTOs = new List<AccountDTO>();
            foreach(Account account in accounts)
            {
                accountDTOs.Add(account.ToDTO());
            }
            return accountDTOs;
        }
        public static Account ToAccount(this AccountDTO accountDTO)
        {
            return new Account()
            {
                AccountId = accountDTO.AccountId,
                TaiKhoan = accountDTO.TaiKhoan,
                MatKhau = accountDTO.MatKhau,
                Quyen = accountDTO.Quyen
            };
        }
    }
}
