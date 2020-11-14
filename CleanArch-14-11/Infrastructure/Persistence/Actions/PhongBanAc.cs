using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class PhongBanAc : IPhongBanAc
    {
        private readonly MyData myData;
        public PhongBanAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(PhongBan obj)
        {
            myData.PhongBans.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public PhongBan FindById(string id)
        {
            return myData.PhongBans.Find(id);
        }

        public string Remove(PhongBan obj)
        {
            ////Kiểm tra quan hệ
            //NhanVien nhanVien = myData.NhanViens.ToList().Find(x => x.PhongBanId == obj.PhongBanId);
            //if (nhanVien != null)
            //{
            //    return "Nhân viên \"" + nhanVien.NhanVienId + "\" đang tham chiếu tới khóa này vui lòng điều hướng sang khóa khác rồi tiếp tục";
            //}

            //myData.PhongBans.Remove(obj);
            //Đoạn trên dùng để xóa

            //Lấy phòng ban dựa vào id
            obj = myData.PhongBans.Find(obj.PhongBanId);

            //Cập nhật trạng thái
            obj.TrangThai = 0;
            myData.PhongBans.Update(obj);
            myData.SaveChanges();

            return null;
        }

        public List<PhongBan> ToList()
        {
            return myData.PhongBans.ToList();
        }

        public string Update(PhongBan obj)
        {
            myData.PhongBans.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
