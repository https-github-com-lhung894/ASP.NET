using Domain.Entities;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class BangChamCongAc : IBangChamCongAc
    {
        private readonly MyData myData;
        public BangChamCongAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(BangChamCong obj)
        {
            //Kiểm tra khóa chính
            if (myData.BangChamCongs.ToList().Find(x => x.BangChamCongId == obj.BangChamCongId) != null)
            {
                return "Bảng chấm công id đã tồn tại";
            }

            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.BangChamCongs.ToList().Find(x => x.BangChamCongId == obj.BangChamCongId) == null)
            {
                return "Bảng chấm công id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.BangChamCongs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public BangChamCong FindById(string id)
        {
            return myData.BangChamCongs.Find(id);
        }

        public int NOEGTWY()
        {
            List<BangChamCong> bangChamCongs = myData.BangChamCongs.ToList().FindAll(x => x.TrangThaiChamCongId == "tt1" && 
                x.NgayLamViec == DateTime.Now.Yesterday());
            return bangChamCongs.Count;
        }

        public int NOEOY()
        {
            List<BangChamCong> bangChamCongs = myData.BangChamCongs.ToList().FindAll(x => x.TrangThaiChamCongId != "tt1" &&
                x.NgayLamViec == DateTime.Now.Yesterday());
            return bangChamCongs.Count;
        }

        public string Remove(BangChamCong obj)
        {
            myData.BangChamCongs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<BangChamCong> ToList()
        {
            return myData.BangChamCongs.ToList();
        }

        public string Update(BangChamCong obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.BangChamCongs.ToList().Find(x => x.BangChamCongId == obj.BangChamCongId) == null)
            {
                return "Bảng chấm công id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            myData.BangChamCongs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
