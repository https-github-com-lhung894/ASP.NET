using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class DuAnAc : IDuAnAc
    {
        private readonly MyData myData;
        public DuAnAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(DuAn obj)
        {
            //Kiểm tra khóa chính
            if (myData.DuAns.ToList().Find(x => x.DuAnId == obj.DuAnId) != null)
            {
                return "Dự án id đã tồn tại";
            }

            myData.DuAns.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public DuAn FindById(string id)
        {
            return myData.DuAns.Find(id);
        }

        public List<DuAn> ProjectInProgress()
        {
            return myData.DuAns.ToList().FindAll(x => ((DateTime)x.NgayKetThuc).AfterNow());
        }

        public string Remove(DuAn obj)
        {
            ////Kiểm tra quan hệ
            //NhanVienDuAn nhanVienDuAn = myData.NhanVienDuAns.ToList().Find(x => x.DuAnId == obj.DuAnId);
            //if (nhanVienDuAn != null)
            //{
            //    return "Nhân viên - dự án \"" + nhanVienDuAn.NhanVienDuAnId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}

            //myData.DuAns.Remove(obj);

            //Đoạn trên dùng để xóa

            //Lấy dự án dựa vào id
            obj = myData.DuAns.Find(obj.DuAnId);

            //Cập nhật trạng thái
            obj.TrangThai = 0;
            myData.DuAns.Update(obj);
            myData.SaveChanges();

            return null;
        }

        public List<DuAn> ToList()
        {
            return myData.DuAns.ToList();
        }

        public string Update(DuAn obj)
        {
            var local = myData.Set<DuAn>()
                .Local
                .FirstOrDefault(entry => entry.DuAnId.Equals(obj.DuAnId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Modified;
            //myData.DuAns.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
