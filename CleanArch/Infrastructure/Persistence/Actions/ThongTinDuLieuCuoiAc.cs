using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class ThongTinDuLieuCuoiAc : IThongTinDuLieuCuoiAc
    {
        //Chỉ chứa 1 row trên database

        private readonly MyData myData;
        public ThongTinDuLieuCuoiAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(ThongTinDuLieuCuoi obj)
        {
            //Không được phép thêm mới

            //myData.ThongTinDuLieuCuois.Add(obj);
            //myData.SaveChanges();

            return "Không được phép thêm";
        }

        public ThongTinDuLieuCuoi FindById(string id = "1")
        {
            //Mặc định khóa chính trên database là 1
            return myData.ThongTinDuLieuCuois.Find(id);
        }

        public string Remove(ThongTinDuLieuCuoi obj)
        {
            //Không được phép xóa

            //myData.ThongTinDuLieuCuois.Remove(obj);
            //myData.SaveChanges();

            return "Không được phép xóa";
        }

        public List<ThongTinDuLieuCuoi> ToList()
        {
            return myData.ThongTinDuLieuCuois.ToList();
        }

        public string Update(ThongTinDuLieuCuoi obj)
        {
            myData.ThongTinDuLieuCuois.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
