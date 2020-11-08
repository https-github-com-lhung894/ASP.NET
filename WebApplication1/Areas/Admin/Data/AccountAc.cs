using System.Collections.Generic;
using System.Linq;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Data
{
    public class AccountAc : IAccountAc
    {
        private readonly MyData context;
        public AccountAc(MyData context)
        {
            this.context = context;
        }

        public void Add(Account obj)
        {
            context.Accounts.Add(obj);
            context.SaveChanges();
        }

        public void Update(Account obj)
        {
            context.Accounts.Update(obj);
            context.SaveChanges();
        }

        public void Remove(Account obj)
        {
            context.Accounts.Remove(obj);
            context.SaveChanges();
        }

        public List<Account> ToList()
        {
            return context.Accounts.ToList();
        }

        public Account FindById(string id)
        {
            return context.Accounts.Find(id);
        }
    }
}
