using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class LoginMap
    {
        public static LoginDTO ToLoginDTO(this Account account, string NhanVienId)
        {
            return new LoginDTO()
            {
                email = account.TaiKhoan,
                pass = account.MatKhau,
                NhanVienId = NhanVienId,
                Quyen = account.Quyen
            };
        }
        public static List<LoginDTO> ToLoginList(this List<Account> accounts, List<NhanVien> nhanViens)
        {
            List<LoginDTO> logins = new List<LoginDTO>();
            foreach(Account account in accounts)
            {
                string NhanVienId = "";
                List<NhanVien> nhanViens1 = nhanViens.FindAll(x => x.AccountId == account.AccountId);
                if(nhanViens1.Count != 0)
                {
                    NhanVienId = nhanViens1[0].NhanVienId;
                }
                
                logins.Add(account.ToLoginDTO(NhanVienId));
            }
            return logins;
        }
    }
}
