using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class TrangThaiChamCongAc : ITrangThaiChamCongAc
    {
        private readonly MyData myData;
        public TrangThaiChamCongAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(TrangThaiChamCong obj)
        {
            //Kiểm tra khóa chính
            if (myData.TrangThaiChamCongs.Find(obj.TrangThaiChamCongId) != null)
            {
                return "Trạng thái chấm công id đã tồn tại";
            }

            myData.TrangThaiChamCongs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public TrangThaiChamCong FindById(string id)
        {
            return myData.TrangThaiChamCongs.Find(id);
        }

        public string Remove(TrangThaiChamCong obj)
        {
            //Kiểm tra quan hệ
            BangChamCong bangChamCong = myData.BangChamCongs.ToList().Find(x => x.TrangThaiChamCongId == obj.TrangThaiChamCongId);
            if (bangChamCong != null)
            {
                return "Bảng chấm công \"" + bangChamCong.BangChamCongId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            }

            myData.TrangThaiChamCongs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<TrangThaiChamCong> ToList()
        {
            return myData.TrangThaiChamCongs.ToList();
        }

        public string Update(TrangThaiChamCong obj)
        {
            myData.TrangThaiChamCongs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
