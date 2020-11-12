using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class NhanVienCongViecAc : INhanVienCongViecAc
    {
        private readonly MyData myData;
        public NhanVienCongViecAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(NhanVienCongViec obj)
        {
            //Kiểm tra quan hệ
            if (myData.CongViecs.ToList().Find(x => x.CongViecId == obj.CongViecId) == null)
            {
                return "Công việc id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.NhanVienCongViecs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public NhanVienCongViec FindById(string id)
        {
            return myData.NhanVienCongViecs.Find(id);
        }

        public string Remove(NhanVienCongViec obj)
        {
            myData.NhanVienCongViecs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<NhanVienCongViec> ToList()
        {
            return myData.NhanVienCongViecs.ToList();
        }

        public string Update(NhanVienCongViec obj)
        {
            //Kiểm tra quan hệ
            if (myData.CongViecs.ToList().Find(x => x.CongViecId == obj.CongViecId) == null)
            {
                return "Công việc id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            myData.NhanVienCongViecs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
