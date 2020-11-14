using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class NhanVienDuAnAc : INhanVienDuAnAc
    {
        private readonly MyData myData;
        public NhanVienDuAnAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(NhanVienDuAn obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.DuAns.ToList().Find(x => x.DuAnId == obj.DuAnId) == null)
            {
                return "Dự án id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.NhanVienDuAns.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public NhanVienDuAn FindById(string id)
        {
            return myData.NhanVienDuAns.Find(id);
        }

        public string Remove(NhanVienDuAn obj)
        {
            myData.NhanVienDuAns.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<NhanVienDuAn> ToList()
        {
            return myData.NhanVienDuAns.ToList();
        }

        public string Update(NhanVienDuAn obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.DuAns.ToList().Find(x => x.DuAnId == obj.DuAnId) == null)
            {
                return "Dự án id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            myData.NhanVienDuAns.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
