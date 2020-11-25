using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class ChucVuAc : IChucVuAc
    {
        private readonly MyData myData;
        public ChucVuAc(MyData myData)
        {
            this.myData = myData;
        }

        public string Add(ChucVu obj)
        {
            //Kiểm tra khóa chính
            if (myData.ChucVus.ToList().Find(x => x.ChucVuId == obj.ChucVuId) != null)
            {
                return "Chức vụ id đã tồn tại";
            }

            myData.ChucVus.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public ChucVu FindById(string id)
        {
            return myData.ChucVus.Find(id);
        }

        public string Remove(ChucVu obj)
        {
            //Kiểm tra quan hệ
            NhanVien nhanVien = myData.NhanViens.ToList().Find(x => x.ChucVuId == obj.ChucVuId);
            if (nhanVien != null)
            {
                return "Nhân viên \"" + nhanVien.NhanVienId + "\" đang tham chiếu tới khóa này vui lòng điều hướng sang khóa khác rồi tiếp tục";
            }

            myData.ChucVus.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<ChucVu> ToList()
        {
            return myData.ChucVus.ToList();
        }

        public string Update(ChucVu obj)
        {
            myData.ChucVus.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
