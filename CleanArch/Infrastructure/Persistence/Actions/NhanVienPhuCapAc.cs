﻿using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class NhanVienPhuCapAc : INhanVienPhuCapAc
    {
        private readonly MyData myData;
        public NhanVienPhuCapAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(NhanVienPhuCap obj)
        {
            obj.NhanVienPhuCapId = AutoKey.AutoNumber(myData.NhanVienPhuCaps.ToList()[myData.NhanVienPhuCaps.ToList().Count - 1].NhanVienPhuCapId);
            //Kiểm tra khóa chính
            if (myData.NhanVienPhuCaps.ToList().Find(x => x.NhanVienPhuCapId == obj.NhanVienPhuCapId) != null)
            {
                return "Nhân viên - phụ cấp id đã tồn tại";
            }

            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.PhuCaps.ToList().Find(x => x.PhuCapId == obj.PhuCapId) == null)
            {
                return "Phụ cấp id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.NhanVienPhuCaps.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public NhanVienPhuCap FindById(string id)
        {
            return myData.NhanVienPhuCaps.Find(id);
        }

        public string Remove(NhanVienPhuCap obj)
        {
            //myData.NhanVienPhuCaps.Remove(obj);
            var local = myData.Set<NhanVienPhuCap>()
                .Local
                .FirstOrDefault(entry => entry.NhanVienPhuCapId.Equals(obj.NhanVienPhuCapId));

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

        public List<NhanVienPhuCap> ToList()
        {
            return myData.NhanVienPhuCaps.ToList();
        }

        public string Update(NhanVienPhuCap obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.PhuCaps.ToList().Find(x => x.PhuCapId == obj.PhuCapId) == null)
            {
                return "Phụ cấp id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            myData.NhanVienPhuCaps.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
