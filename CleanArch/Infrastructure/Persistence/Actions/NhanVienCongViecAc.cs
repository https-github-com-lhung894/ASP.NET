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

            //Tính ngày tháng
            int m = 0;
            int[] array = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            for (int i = 0; i < array.Length; i++)
            {
                if ((DateTime.Now.Month == array[i] && DateTime.Now.Day == 31) || (DateTime.Now.Month != array[i] && DateTime.Now.Day == 30))
                {
                    m = 1;
                }
            }
            if (DateTime.Now.Month == 2)
            {
                if (DateTime.Now.Year % 4 == 0)
                {
                    if(DateTime.Now.Day == 29)
                    {
                        m = 1;
                    }
                }
                else
                {
                    if (DateTime.Now.Day == 28)
                    {
                        m = 1;
                    }
                }
            }
            //Nếu tìm thấy => đặt lại ngày kết thúc bằng hiện tại
            if (nvcv != null)
            {
                nvcv.NgayKetThuc = System.DateTime.Now;

                myData.NhanVienCongViecs.Update(nvcv);
            }
            //Khởi tạo mới hợp đồng
            int max = 0;
            List<NhanVienCongViec> nhanVienCongViecs = myData.NhanVienCongViecs.ToList();
            foreach (NhanVienCongViec nvcv1 in nhanVienCongViecs)
            {
                if (int.Parse(nvcv1.NhanVienCongViecId) > max)
                {
                    max = int.Parse(nvcv1.NhanVienCongViecId);
                }
            }
            NhanVienCongViec nhanVienCongViec = new NhanVienCongViec()
            {
                //Tìm id cuối danh sách và tự tăng lên 1
                NhanVienCongViecId = (max + 1) + "",
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                HSCongViec = 0.5,

                //Lấy ngày hôm sau
                NgayBatDau = new System.DateTime((System.DateTime.Now.Month == 12 && System.DateTime.Now.Day == 31) ? System.DateTime.Now.Year + 1 : System.DateTime.Now.Year,
                    System.DateTime.Now.Month + m, m == 1 ? 1 : System.DateTime.Now.Day + 1),
                NgayKetThuc = null
            };

            myData.NhanVienCongViecs.Add(nhanVienCongViec);
            myData.SaveChanges();

            return null;
        }

        public string AutoUpdate(string nhanVienId, string congViecId)
        {
            NhanVienCongViec nvcv = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.CongViecId == congViecId && x.NgayKetThuc == null);

            //Tính ngày tháng
            int m = 0;
            int[] array = new int[] { 1, 3, 5, 7, 8, 10, 12 };
            for (int i = 0; i < array.Length; i++)
            {
                if ((System.DateTime.Now.Month == array[i] && System.DateTime.Now.Day == 31) || (System.DateTime.Now.Month != array[i] && System.DateTime.Now.Day == 30))
                {
                    m = 1;
                }
            }
            if (DateTime.Now.Month == 2)
            {
                if (DateTime.Now.Year % 4 == 0)
                {
                    if (DateTime.Now.Day == 29)
                    {
                        m = 1;
                    }
                }
                else
                {
                    if (DateTime.Now.Day == 28)
                    {
                        m = 1;
                    }
                }
            }
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
                //Ngày hiện tại
                nhanVienCongViec.NgayKetThuc = System.DateTime.Now;

                myData.NhanVienCongViecs.Update(nhanVienCongViec);
            }

            //Khởi tạo mới nhân viên - công việc
            int max = 0;
            List<NhanVienCongViec> nhanVienCongViecs = myData.NhanVienCongViecs.ToList();
            foreach(NhanVienCongViec nvcv1 in nhanVienCongViecs)
            {
                if(int.Parse(nvcv1.NhanVienCongViecId) > max)
                {
                    max = int.Parse(nvcv1.NhanVienCongViecId);
                }
            }
            nhanVienCongViec = new NhanVienCongViec()
            {
                //Tìm id cuối danh sách và tự tăng lên 1
                NhanVienCongViecId = ""+(max + 1),
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                HSCongViec = 0.5,
                //Lấy ngày 1 tháng sau của ngày hiện tại
                NgayBatDau = new DateTime((DateTime.Now.Month == 12 && DateTime.Now.Day == 31) ? DateTime.Now.Year + 1 : DateTime.Now.Year,
                    DateTime.Now.Month + m, m == 1 ? 1 : DateTime.Now.Day + 1),
                NgayKetThuc = null
            };

            //Add nhân viên - công việc

            //myData.Entry(nhanVienCongViec).State = EntityState.Detached;

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

            return myData.NhanVienCongViecs.ToList().FindAll(x => x.NgayBatDau == null || ((DateTime)x.NgayBatDau).AfterNow() == false);
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
