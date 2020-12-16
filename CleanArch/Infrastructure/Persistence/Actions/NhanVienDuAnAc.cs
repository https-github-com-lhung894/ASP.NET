using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
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
            obj.NhanVienDuAnId = AutoKey.AutoNumber(myData.NhanVienDuAns.ToList()[myData.NhanVienDuAns.ToList().Count - 1].NhanVienDuAnId);
            //Kiểm tra khóa chính
            if (myData.NhanVienDuAns.ToList().Find(x => x.NhanVienDuAnId == obj.NhanVienDuAnId) != null)
            {
                return "Nhân viên - dự án id đã tồn tại";
            }

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
            var local = myData.Set<NhanVienDuAn>()
                .Local
                .FirstOrDefault(entry => entry.NhanVienDuAnId.Equals(obj.NhanVienDuAnId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Deleted;
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
            //myData.NhanVienDuAns.Update(obj);
            var local = myData.Set<NhanVienDuAn>()
                .Local
                .FirstOrDefault(entry => entry.NhanVienDuAnId.Equals(obj.NhanVienDuAnId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Modified;
            myData.SaveChanges();

            return null;
        }
    }
}
