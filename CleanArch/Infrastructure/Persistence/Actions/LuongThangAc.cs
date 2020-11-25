using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class LuongThangAc : ILuongThangAc
    {
        private readonly MyData myData;
        public LuongThangAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(LuongThang obj)
        {
            //Kiểm tra khóa chính
            if (myData.LuongThangs.ToList().Find(x => x.LuongThangId == obj.LuongThangId) != null)
            {
                return "Lương tháng id đã tồn tại";
            }

            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.LuongThangs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public LuongThang FindById(string id)
        {
            return myData.LuongThangs.Find(id);
        }

        public string Remove(LuongThang obj)
        {
            myData.LuongThangs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<LuongThang> ToList()
        {
            return myData.LuongThangs.ToList();
        }

        public string Update(LuongThang obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            myData.LuongThangs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
