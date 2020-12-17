using Domain.Entities;
using Domain.IActions;
using Microsoft.EntityFrameworkCore;
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

        public string TuCapPhat()
        {
            //Khởi tạo mới
            int max = 0;
            foreach (BangChamCong bcc in myData.BangChamCongs.ToList())
            {
                if (int.Parse(bcc.BangChamCongId) > max)
                {
                    max = int.Parse(bcc.BangChamCongId);
                }
            }
            List<BangChamCong> bangChamCongs = new List<BangChamCong>();
            BangChamCong bangChamCong = null;
            NhanVienCongViec nhanVienCongViec;
            foreach (NhanVien nhanVien in myData.NhanViens.ToList())
            {
                bangChamCong = new BangChamCong();
                nhanVienCongViec = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == nhanVien.NhanVienId &&
                    (x.NgayKetThuc == null || ((DateTime)x.NgayKetThuc).After((DateTime)x.NgayBatDau)) &&
                    ((((DateTime)x.NgayBatDau).Before(DateTime.Now)) || ((DateTime)x.NgayBatDau).EqualTo(DateTime.Now)) &&
                    (x.NgayKetThuc == null || (((DateTime)x.NgayKetThuc).After(DateTime.Now)) || ((DateTime)x.NgayKetThuc).EqualTo(DateTime.Now)));
                if (nhanVienCongViec != null && myData.BangChamCongs.ToList().Find(x => x.NhanVienId == nhanVien.NhanVienId &&
                    x.NgayLamViec.EqualTo(DateTime.Now)) == null)
                {
                    max++;
                    bangChamCong.BangChamCongId = max + "";
                    bangChamCong.NgayLamViec = DateTime.Now;
                    bangChamCong.NhanVienId = nhanVien.NhanVienId;
                    bangChamCong.TrangThaiChamCongId = "tt1";

                    bangChamCongs.Add(bangChamCong);
                }
            }
            myData.BangChamCongs.AddRange(bangChamCongs);
            myData.SaveChanges();
            return null;
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
            var local = myData.Set<BangChamCong>()
                .Local
                .FirstOrDefault(entry => entry.BangChamCongId.Equals(obj.BangChamCongId));

            // check if local is not null 
            if (local != null)
            {
                // detach
                myData.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            myData.Entry(obj).State = EntityState.Modified;
            //myData.BangChamCongs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
