using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class ThuongLeAc : IThuongLeAc
    {
        private readonly MyData myData;
        public ThuongLeAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(ThuongLe obj)
        {
            //Kiểm tra khóa chính
            if (myData.ThuongLes.ToList().Find(x => x.ThuongLeId == obj.ThuongLeId) != null)
            {
                return "Thưởng lễ id đã tồn tại";
            }

            myData.ThuongLes.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public ThuongLe FindById(string id)
        {
            return myData.ThuongLes.Find(id);
        }

        public string Remove(ThuongLe obj)
        {
            myData.ThuongLes.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<ThuongLe> ToList()
        {
            return myData.ThuongLes.ToList();
        }

        public string Update(ThuongLe obj)
        {
            myData.ThuongLes.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
