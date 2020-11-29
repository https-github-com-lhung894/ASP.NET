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

            //Tìm hợp đồng có trạng thái bằng 1 xét về 0
            HopDong hd = myData.HopDongs.ToList().Find(x => x.NhanVienId == nhanVienId && x.CongViecId == congViecId && x.TrangThai == 1);
            if(hd != null)
            {
                hd.TrangThai = 0;
                myData.HopDongs.Update(hd);
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

        public HopDong AutoUpdate(string nhanVienId, string congViecId, double? luongCanBan)
        {
            //Kiểm tra xem hợp đồng có thay đổi ko
            HopDong hd = myData.HopDongs.ToList().Find(x => x.NhanVienId == nhanVienId && x.CongViecId == congViecId && x.TrangThai == 1);
            if(hd != null)
            {
                return null;
            }

            //Tìm hợp đồng hiện tại của nhân viên xét trạng thái về 0
            hd = myData.HopDongs.ToList().Find(x => x.NhanVienId == nhanVienId && x.TrangThai == 1);
            if (hd != null)
            {
                hd.TrangThai = 0;
                myData.HopDongs.Update(hd);
            }

            //Khởi tạo hợp đồng mới
            int max = 0;
            List<HopDong> hopDongs = myData.HopDongs.ToList();
            foreach (HopDong hopDong1 in hopDongs)
            {
                if (int.Parse(hopDong1.HopDongId) > max)
                {
                    max = int.Parse(hopDong1.HopDongId);
                }
            }
            HopDong hopDong = new HopDong()
            {
                //Tìm hợp đồng cuối danh sách rồi tự tăng lên 1
                HopDongId = ""+(max+1),
                NhanVienId = nhanVienId,
                CongViecId = congViecId,
                NgayKyHopDong = DateTime.Now,
                LuongCanBan = luongCanBan
            };

            myData.HopDongs.Add(hopDong);

            
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
