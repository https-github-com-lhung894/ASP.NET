using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class HopDongAc : IHopDongAc
    {
        private readonly MyData myData;
        public HopDongAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(HopDong obj)
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
            myData.HopDongs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public HopDong FindById(string id)
        {
            return myData.HopDongs.Find(id);
        }

        public string Remove(HopDong obj)
        {
            myData.HopDongs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<HopDong> ToList()
        {
            return myData.HopDongs.ToList();
        }

        public string Update(HopDong obj)
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
            myData.HopDongs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
