using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class ChiTietNhanVienAc : IChiTietNhanVienAc
    {
        private readonly MyData myData;
        public ChiTietNhanVienAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(ChiTietNhanVien obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.ChiTietNhanViens.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public ChiTietNhanVien FindById(string id)
        {
            
            return myData.ChiTietNhanViens.ToList().Find(x => x.ChiTietNhanVienId == id);
        }

        public string Remove(ChiTietNhanVien obj)
        {
            myData.ChiTietNhanViens.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<ChiTietNhanVien> ToList()
        {
            return myData.ChiTietNhanViens.ToList();
        }

        public string Update(ChiTietNhanVien obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            var local = myData.Set<ChiTietNhanVien>()
                .Local
                .FirstOrDefault(entry => entry.ChiTietNhanVienId.Equals(obj.ChiTietNhanVienId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Modified;

            //myData.ChiTietNhanViens.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
