using Domain.Entities;
using Domain.IActions;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class NhanVienAc : INhanVienAc
    {
        private readonly MyData myData;
        public NhanVienAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(NhanVien obj)
        {
            //Kiểm tra khóa chính
            NhanVien nhanVien = myData.NhanViens.Find(obj.NhanVienId);
            if (nhanVien != null)
            {
                if(nhanVien.TrangThai == 0)
                {
                    return "Nhân viên này đã tồn tại trước đó và đã bị xóa";
                }
                return "Nhân viên id đã tồn tại";
            }

            //Kiểm tra quan hệ
            if (myData.PhongBans.Find(obj.PhongBanId) == null)
            {
                return "Phòng ban id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if(myData.ChucVus.Find(obj.ChucVuId) == null)
            {
                return "Chức vụ id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.Accounts.Find(obj.AccountId) == null)
            {
                return "Account id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            ////Tự động tạo khóa chính cho nhân viên

            ////Lấy dữ liệu từ database
            //ThongTinDuLieuCuoiAc thongTinDuLieuCuoiAc = new ThongTinDuLieuCuoiAc(myData);

            ////Lấy trường có khóa chính là "1", hàm FindById() đã truyền tham số mặc định là "1"
            //ThongTinDuLieuCuoi thongTinDuLieuCuoi = thongTinDuLieuCuoiAc.FindById();

            ////Lấy mã nhân viên đã cập nhật vào database lần cuối rồi tăng lên 1
            //string nhanVienId = thongTinDuLieuCuoi.NhanVienId;
            //nhanVienId = AutoKey.InCreasedByOne(nhanVienId);

            //obj.NhanVienId = nhanVienId;



            myData.NhanViens.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public string CheckRelationship(NhanVien nhanVien)
        {
            //Kiểm tra khóa chính
            NhanVien nhanVienT = myData.NhanViens.Find(nhanVien.NhanVienId);
            if (nhanVienT != null)
            {
                if (nhanVienT.TrangThai == 0)
                {
                    return "Nhân viên này đã tồn tại trước đó và đã bị xóa";
                }
                return "Nhân viên id đã tồn tại";
            }

            //Kiểm tra quan hệ trước khi thêm nhân viên
            if (myData.PhongBans.Find(nhanVien.PhongBanId) == null)
            {
                return "Phòng ban id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.ChucVus.Find(nhanVien.ChucVuId) == null)
            {
                return "Chức vụ id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            return null;
        }

        public NhanVien FindById(string id)
        {
            return myData.NhanViens.Find(id);
        }

        public string Remove(NhanVien obj)
        {
            ////Kiểm tra quan hệ
            //NhanVienCongViec nhanVienCongViec = myData.NhanVienCongViecs.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (nhanVienCongViec != null)
            //{
            //    return "Nhân viên - công việc \"" + nhanVienCongViec.NhanVienCongViecId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}
            //HopDong hopDong = myData.HopDongs.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (hopDong != null)
            //{
            //    return "Hợp đồng \"" + hopDong.HopDongId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}
            //ChiTietNhanVien chiTietNhanVien = myData.ChiTietNhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (chiTietNhanVien != null)
            //{
            //    return "Chi tiết nhân viên \"" + chiTietNhanVien.ChiTietNhanVienId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}
            //NhanVienDuAn nhanVienDuAn = myData.NhanVienDuAns.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (nhanVienDuAn != null)
            //{
            //    return "Nhân viên - dự án \"" + nhanVienDuAn.NhanVienDuAnId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}
            //NhanVienPhuCap nhanVienPhuCap = myData.NhanVienPhuCaps.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (nhanVienPhuCap != null)
            //{
            //    return "Nhân viên - phụ cấp \"" + nhanVienPhuCap.NhanVienPhuCapId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}
            //BangChamCong bangChamCong = myData.BangChamCongs.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (bangChamCong != null)
            //{
            //    return "Bảng chấm công \"" + bangChamCong.BangChamCongId + "\" đang tham chiếu tới khóa này vui lòng xóa hoặc điều hướng sang khóa khác rồi tiếp tục";
            //}
            //LuongThang luongThang = myData.LuongThangs.ToList().Find(x => x.NhanVienId == obj.NhanVienId);
            //if (luongThang != null)
            //{
            //    return "Lương tháng \"" + luongThang.LuongThangId + "\" đang tham chiếu tới khóa này vui lòng điều hướng sang khóa khác rồi tiếp tục xóa";
            //}

            //myData.NhanViens.Remove(obj);


            //Đoan trên dùng để xóa

            //Lấy nhân viên dựa vào id
            obj = myData.NhanViens.Find(obj.NhanVienId);

            //Cập nhật trạng thái
            obj.TrangThai = 0;
            myData.NhanViens.Update(obj);
            myData.SaveChanges();
            return null;
        }

        public List<NhanVien> ToList()
        {
            return myData.NhanViens.ToList();
        }

        public string Update(NhanVien obj)
        {
            //Kiểm tra quan hệ
            if (myData.PhongBans.Find(obj.PhongBanId) == null)
            {
                return "Phòng ban id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.ChucVus.Find(obj.ChucVuId) == null)
            {
                return "Chức vụ id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }
            if (myData.Accounts.Find(obj.AccountId) == null)
            {
                return "Account id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            myData.NhanViens.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
