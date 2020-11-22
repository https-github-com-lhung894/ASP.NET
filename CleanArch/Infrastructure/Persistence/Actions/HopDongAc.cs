using Domain.Entities;
using Domain.IActions;
using System;
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
            //Kiểm tra khóa chính
            if (myData.HopDongs.ToList().Find(x => x.HopDongId == obj.HopDongId) != null)
            {
                return "Hợp đồng id đã tồn tại";
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
            myData.HopDongs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public string AutoAdd(string nhanVienId, string congViecId, double? luongCanBan)
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

            HopDong hopDong = new HopDong()
            {
                //Tìm hợp đồng cuối danh sách rồi tự tăng lên 1
                HopDongId = AutoKey.AutoNumber(myData.HopDongs.ToList()[myData.HopDongs.ToList().Count - 1].HopDongId),
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                NgayKyHopDong = DateTime.Now,
                LuongCanBan = luongCanBan
            };

            myData.HopDongs.Add(hopDong);
            myData.SaveChanges();

            return null;
        }

        public HopDong SetupForUpdate(string nhanVienId, string congViecId, double? luongCanBan)
        {
            HopDong hd = myData.HopDongs.ToList().Find(x => x.NhanVienId == nhanVienId && x.CongViecId == congViecId);

            if(hd == null)
            {
                //Khởi tạo hợp đồng mới nếu chưa tồn tại
                HopDong hopDong = new HopDong()
                {
                    //Tìm hợp đồng cuối danh sách rồi tự tăng lên 1
                    HopDongId = AutoKey.AutoNumber(myData.HopDongs.ToList()[myData.HopDongs.ToList().Count - 1].HopDongId),
                    NhanVienId = nhanVienId,
                    CongViecId = congViecId,
                    NgayKyHopDong = DateTime.Now,
                    LuongCanBan = luongCanBan
                };

                return hopDong;
            }

            hd.LuongCanBan = luongCanBan;

            return hd;
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
