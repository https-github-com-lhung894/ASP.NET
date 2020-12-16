using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class PhuCapAc : IPhuCapAc
    {
        private readonly MyData myData;
        public PhuCapAc(MyData myData)
        {
            this.myData = myData;
        }

        public string Add(PhuCap obj)
        {
            //Kiểm tra khóa chính
            if (myData.PhuCaps.ToList().Find(x => x.PhuCapId == obj.PhuCapId) != null)
            {
                return "Phụ cấp id đã tồn tại";
            }

            myData.PhuCaps.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public PhuCap FindById(string id)
        {
            return myData.PhuCaps.Find(id);
        }

        public string Remove(PhuCap obj)
        {
            ////Kiểm tra quan hệ
            //NhanVienPhuCap nhanVienPhuCap = myData.NhanVienPhuCaps.ToList().Find(x => x.PhuCapId == obj.PhuCapId);
            //if (nhanVienPhuCap != null)
            //{
            //    return "Nhân viên - phụ cấp \"" + nhanVienPhuCap.NhanVienPhuCapId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}

            //myData.PhuCaps.Remove(obj);

            //Đoạn trên dùng để xóa

            //Lấy phụ cấp dựa vào id
            obj = myData.PhuCaps.Find(obj.PhuCapId);

            //Cập nhật trạng thái
            obj.TrangThai = 0;
            myData.PhuCaps.Update(obj);
            myData.SaveChanges();

            return null;
        }

        public List<PhuCap> ToList()
        {
            return myData.PhuCaps.ToList();
        }

        public string Update(PhuCap obj)
        {
            var local = myData.Set<PhuCap>()
                .Local
                .FirstOrDefault(entry => entry.PhuCapId.Equals(obj.PhuCapId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Modified;
            //myData.PhuCaps.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
