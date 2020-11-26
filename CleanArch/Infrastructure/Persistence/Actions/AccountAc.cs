using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class AccountAc : IAccountAc
    {
        private MyData myData;
        public AccountAc(MyData myData)
        {
            this.myData = myData;
        }

        public string Add(Account obj)
        {
            //Kiểm tra khóa chính
            if(myData.Accounts.ToList().Find(x => x.AccountId == obj.AccountId) != null)
            {
                return "Account id đã tồn tại";
            }

            myData.Accounts.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public string Update(Account obj)
        {
            // 
            var local = myData.Set<Account>()
                .Local
                .FirstOrDefault(entry => entry.AccountId.Equals(obj.AccountId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Modified;

            // save 
            //_context.SaveChanges();
            //myData.Accounts.
            //myData.Accounts.Update(obj);
            //myData.Entry(obj).State = EntityState.Modified;

            myData.SaveChanges();

            return null;
        }

        public string Remove(Account obj)
        {
            //Kiểm tra quan hệ
            NhanVien nhanVien = myData.NhanViens.ToList().Find(x => x.AccountId == obj.AccountId);
            if (nhanVien != null)
            {
                return "Nhân viên \""+ nhanVien.NhanVienId + "\" đang tham chiếu tới khóa này vui lòng điều hướng sang khóa khác rồi tiếp tục";
            }

            myData.Accounts.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<Account> ToList()
        {
            return myData.Accounts.ToList();
        }

        public Account FindById(string id)
        {
            return myData.Accounts.Find(id);
        }
    }
}
