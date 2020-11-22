using Domain.Entities;
using Domain.IActions;
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
            //Kiểm tra quan hệ
            if (myData.CongViecs.ToList().Find(x => x.CongViecId == congViecId) == null)
            {
                return "Công việc id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == nhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Tìm nhan vien - cong viec có ngày kết thúc == null
            NhanVienCongViec nhanVienCongViec = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.NgayKetThuc == null);
            DateTime? ngayKetThuc = DateTime.Now;

            //Nếu không tìm thấy => nhân viên chưa có công việc
            if(nhanVienCongViec == null)
            {
                //Điều kiện để nhân viên có công việc vô thời hạn
                ngayKetThuc = null;
            }
            nhanVienCongViec = new NhanVienCongViec()
            {
                //Tìm id cuối danh sách và tự tăng lên 1
                NhanVienCongViecId = AutoKey.AutoNumber(myData.NhanVienCongViecs.ToList()[myData.NhanVienCongViecs.ToList().Count - 1].NhanVienCongViecId),
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                HSCongViec = 0.5,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = ngayKetThuc
            };

            myData.NhanVienCongViecs.Add(nhanVienCongViec);
            myData.SaveChanges();

            return null;
        }

        public NhanVienCongViec SetupForUpdate(string nhanVienId, string congViecId)
        {
            NhanVienCongViec nvcv = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.CongViecId == congViecId);
            if(nvcv == null)
            {
                //Khởi tạo mới nếu nhân vien - công việc chưa tồn tại 
                //Tìm nhan vien - cong viec có ngày kết thúc == null
                NhanVienCongViec nhanVienCongViec = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVienId && x.NgayKetThuc == null);
                DateTime? ngayKetThuc = DateTime.Now;

                //Nếu không tìm thấy => nhân viên chưa có công việc
                if (nhanVienCongViec == null)
                {
                    //Điều kiện để nhân viên có công việc vô thời hạn
                    ngayKetThuc = null;
                }
                nhanVienCongViec = new NhanVienCongViec()
                {
                    //Tìm id cuối danh sách và tự tăng lên 1
                    NhanVienCongViecId = AutoKey.AutoNumber(myData.NhanVienCongViecs.ToList()[myData.NhanVienCongViecs.ToList()
                        .Count - 1].NhanVienCongViecId),
                    NhanVienId = nhanVienId,
                    CongViecId = congViecId,
                    HSCongViec = 0.5,
                    NgayBatDau = DateTime.Now,
                    NgayKetThuc = ngayKetThuc
                };

                return nhanVienCongViec;
            }

            return nvcv;
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
