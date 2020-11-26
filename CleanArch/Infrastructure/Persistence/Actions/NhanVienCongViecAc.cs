using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
using System;
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
            //Kiểm tra khóa chính
            if (myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienCongViecId == obj.NhanVienCongViecId) != null)
            {
                return "Nhân viên - công việc id đã tồn tại";
            }

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

        public string AutoAdd(string nhanVienId, string congViecId)
        {
            //Tìm nhan vien - cong viec có ngày kết thúc == null
            NhanVienCongViec nvcv = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.NgayKetThuc == null);

            //Nếu tìm thấy => đặt lại ngày kết thúc bằng cuối tháng
            if(nvcv != null)
            {
                int d = 30;
                int[] array = new int[] { 1, 3, 5, 7, 8, 10, 12 };
                for (int i = 0; i < array.Length; i++)
                {
                   if(DateTime.Now.Month == array[i])
                    {
                        d = 31;
                    }
                }

                nvcv.NgayKetThuc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, d);

                myData.NhanVienCongViecs.Update(nvcv);
            }

            NhanVienCongViec nhanVienCongViec = new NhanVienCongViec()
            {
                //Tìm id cuối danh sách và tự tăng lên 1
                NhanVienCongViecId = AutoKey.AutoNumber(myData.NhanVienCongViecs.ToList()[myData.NhanVienCongViecs.ToList().Count - 1].NhanVienCongViecId),
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                HSCongViec = 0.5,
                //Lấy ngày 1 tháng sau của ngày hiện tại
                NgayBatDau = new DateTime((DateTime.Now.Month == 12 ? DateTime.Now.Year + 1 : DateTime.Now.Year), 
                    (DateTime.Now.Month == 12 ? 1 : DateTime.Now.Month + 1), 1),
                NgayKetThuc = null
            };

            myData.NhanVienCongViecs.Add(nhanVienCongViec);
            myData.SaveChanges();

            return null;
        }

        public string AutoUpdate(string nhanVienId, string congViecId)
        {
            NhanVienCongViec nvcv = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.CongViecId == congViecId && x.NgayKetThuc == null);

            //Nhân viên - công việc không thây đổi => không làm gì
            if (nvcv != null)
            {
                return null;
            }
            //Update nhân viên - công việc có ngày kết thúc bằng null

            //Tìm nhân viên - công việc có ngày kết thúc == null
            NhanVienCongViec nhanVienCongViec = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.NgayKetThuc == null);

            //Nếu tìm thấy nhân viên công việc == null =>  xét lại là ngày cuối cùng của tháng
            if (nhanVienCongViec != null)
            {
                int d = 30;
                int[] array = new int[] { 1, 3, 5, 7, 8, 10, 12 };
                for (int i = 0; i < array.Length; i++)
                {
                    if (DateTime.Now.Month == array[i])
                    {
                        d = 31;
                    }
                }
                //Ngày cuối cùng của tháng
                nhanVienCongViec.NgayKetThuc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, d);

                myData.NhanVienCongViecs.Update(nhanVienCongViec);
            }

            //Khởi tạo mới nhân viên - công việc
            nhanVienCongViec = new NhanVienCongViec()
            {
                //Tìm id cuối danh sách và tự tăng lên 1
                NhanVienCongViecId = AutoKey.AutoNumber(myData.NhanVienCongViecs.ToList()[myData.NhanVienCongViecs.ToList()
                    .Count - 1].NhanVienCongViecId),
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                HSCongViec = 0.5,
                //Lấy ngày 1 tháng sau của ngày hiện tại
                NgayBatDau = new DateTime((DateTime.Now.Month == 12 ? DateTime.Now.Year + 1 : DateTime.Now.Year),
                    (DateTime.Now.Month == 12 ? 1 : DateTime.Now.Month + 1), 1),
                NgayKetThuc = null
            };

            //Add nhân viên - công việc

            myData.Entry(nhanVienCongViec).State = EntityState.Detached;

            myData.NhanVienCongViecs.Add(nhanVienCongViec);
            myData.SaveChanges();

            return null;

        }

        public string CheckForeignKey(string nhanVienId, string congViecId)
        {
            //Kiểm tra quan hệ
            if (myData.CongViecs.ToList().Find(x => x.CongViecId == congViecId) == null)
            {
                return "Công việc id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == nhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

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
