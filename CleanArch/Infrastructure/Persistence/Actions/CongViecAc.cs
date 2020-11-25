using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class CongViecAc : ICongViecAc
    {
        private readonly MyData myData;
        public CongViecAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(CongViec obj)
        {
            //Kiểm tra khóa chính
            if (myData.CongViecs.ToList().Find(x => x.CongViecId == obj.CongViecId) != null)
            {
                return "Công việc id đã tồn tại";
            }

            myData.CongViecs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public CongViec FindById(string id)
        {
            return myData.CongViecs.Find(id) ;
        }

        public string Remove(CongViec obj)
        {
            //Kiểm tra quan hệ
            NhanVienCongViec nhanVienCongViec = myData.NhanVienCongViecs.ToList().Find(x => x.CongViecId == obj.CongViecId);
            if (nhanVienCongViec != null)
            {
                return "Nhân viên - công việc \"" + nhanVienCongViec.NhanVienCongViecId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            }
            HopDong hopDong = myData.HopDongs.ToList().Find(x => x.CongViecId == obj.CongViecId);
            if (hopDong != null)
            {
                return "Hợp đồng \"" + hopDong.HopDongId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            }

            myData.CongViecs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<CongViec> ToList()
        {
            return myData.CongViecs.ToList();
        }

        public string Update(CongViec obj)
        {
            myData.CongViecs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
