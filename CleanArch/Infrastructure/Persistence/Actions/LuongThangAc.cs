using Domain.Entities;
using Domain.IActions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Actions
{
    public class LuongThangAc : ILuongThangAc
    {
        private readonly MyData myData;
        public LuongThangAc(MyData myData)
        {
            this.myData = myData;
        }
        public string Add(LuongThang obj)
        {
            //Kiểm tra khóa chính
            if (myData.LuongThangs.ToList().Find(x => x.LuongThangId == obj.LuongThangId) != null)
            {
                return "Lương tháng id đã tồn tại";
            }

            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Thêm nếu không có lỗi
            myData.LuongThangs.Add(obj);
            myData.SaveChanges();

            return null;
        }

        public void AutoAdd()
        {
            //Ngày đầu tiên của tháng mới bắt đầu tính lương
            if(DateTime.Now.IsFirstDayOfMonth() != false)
            {
                return;
            }
            foreach(NhanVienCongViec nhanVienCongViec in myData.NhanVienCongViecs.ToList())
            {
                bool add = true;
                //Không tính lương cho nhân viến quá 2 lần
                foreach(LuongThang lt in myData.LuongThangs.ToList())
                {
                    if (lt.NhanVienId == nhanVienCongViec.NhanVienId &&
                     ((DateTime)lt.NgayTinhLuong).EqualTo(DateTime.Now.FirstDayOfMonth()) == true)
                    {
                        add = false;
                        break;
                    }
                }
                if(add == false)
                {
                    break;
                }
                
                //Chỉ tính lương cho nhân viên có 
                //ngày bắt đầu trước hôm nay và
                //ngày kết thúc băng null hoặc sau ngày đầu tiên của tháng trước
                if (((DateTime)nhanVienCongViec.NgayBatDau).Before(DateTime.Now) &&
                    (nhanVienCongViec.NgayKetThuc == null || ((DateTime)nhanVienCongViec.NgayKetThuc).After(DateTime.Now.FirstDayOfPreviousMonth())))
                {
                    LuongThang luongThang = new LuongThang();

                    //Tao id
                    int max = 0;
                    List<LuongThang> luongThangs = myData.LuongThangs.ToList();
                    foreach (LuongThang lt in luongThangs)
                    {
                        if (int.Parse(lt.LuongThangId) > max)
                        {
                            max = int.Parse(lt.LuongThangId);
                        }
                    }

                    luongThang.LuongThangId = "" + (max + 1);
                    luongThang.NhanVienId = nhanVienCongViec.NhanVienId;
                    luongThang.LuongCoBan = myData.HopDongs.ToList().Find(x => x.NhanVienId == luongThang.NhanVienId && x.TrangThai == 1) != null ?
                        myData.HopDongs.ToList().Find(x => x.NhanVienId == luongThang.NhanVienId && x.TrangThai == 1).LuongCanBan : "0";
                    string chucVuId = myData.NhanViens.ToList().Find(x => x.NhanVienId == luongThang.NhanVienId).ChucVuId;
                    luongThang.HSChucVu = myData.ChucVus.ToList().Find(x => x.ChucVuId == chucVuId).HSChucVu;
                    luongThang.HSCongViec = nhanVienCongViec.HSCongViec;
                    DateTime ngayBatDauLamCuaThangTruoc = ((DateTime)nhanVienCongViec.NgayBatDau).After(DateTime.Now.FirstDayOfPreviousMonth()) ?
                        (DateTime)nhanVienCongViec.NgayBatDau : DateTime.Now.FirstDayOfPreviousMonth();
                    DateTime ngayKetThucLamCuaThangTruoc = nhanVienCongViec.NgayKetThuc == null ? DateTime.Now.FirstDayOfPreviousMonth().LastDayOfMonth() :
                        (DateTime)nhanVienCongViec.NgayKetThuc;
                    luongThang.SoNgayLam = 0;
                    luongThang.SoNgayNghiCoPhep = 0;
                    luongThang.SoNgayNghiKhongPhep = 0;
                    luongThang.SoNgayNghiOm = 0;
                    luongThang.ThuongLe = "0";
                    
                    foreach (BangChamCong bangChamCong in myData.BangChamCongs.ToList())
                    {
                        //Đếm số ngày làm việc của
                        //nhân viên đang xét và
                        //ngày làm việc phải nằm trong đoạn [ngayBatDauLamCuaThangTruoc, ngayKetThucLamCuaThangTruoc]
                        //nếu có trạng thái là tt1 => soNgayLam
                        //nếu có trạng thái là tt2 => SoNgayNghiCoPhep
                        //nếu có trạng thái là tt3 => SoNgayNghiKhongPhep
                        //nếu có trạng thái là tt4 => SoNgayNghiOm
                        //nếu có ngày làm trùng vs ngày lễ => có tiền thưởng
                        if (luongThang.NhanVienId == bangChamCong.NhanVienId &&(
                            bangChamCong.NgayLamViec.EqualTo(ngayBatDauLamCuaThangTruoc) ||
                            (bangChamCong.NgayLamViec.After(ngayBatDauLamCuaThangTruoc) && bangChamCong.NgayLamViec.Before(ngayKetThucLamCuaThangTruoc)) ||
                            bangChamCong.NgayLamViec.EqualTo(ngayKetThucLamCuaThangTruoc)))
                        {
                            //Tính số ngày làm, nghỉ
                            if(bangChamCong.TrangThaiChamCongId == "tt1")
                            {
                                luongThang.SoNgayLam++;
                            }
                            else
                            {
                                if(bangChamCong.TrangThaiChamCongId == "tt2")
                                {
                                    luongThang.SoNgayNghiCoPhep++;
                                }
                                else
                                {
                                    if(bangChamCong.TrangThaiChamCongId == "tt3")
                                    {
                                        luongThang.SoNgayNghiKhongPhep++;
                                    }
                                    else
                                    {
                                        if(bangChamCong.TrangThaiChamCongId == "tt4")
                                        {
                                            luongThang.SoNgayNghiOm++;
                                        }
                                    }
                                }
                            }
                            //Tính tiền thưởng
                            foreach(ThuongLe thuongLe in myData.ThuongLes.ToList())
                            {
                                if (((DateTime)thuongLe.NgayLe).EqualTo(bangChamCong.NgayLamViec))
                                {
                                    luongThang.ThuongLe = "" + (long.Parse(luongThang.ThuongLe) + long.Parse(thuongLe.TienThuongLe));
                                }
                            }
                        }
                    }
                    
                    luongThang.PhuCapNhanVien = "" + 0;
                    foreach (NhanVienPhuCap nhanVienPhuCap in myData.NhanVienPhuCaps.ToList())
                    {
                        if (nhanVienPhuCap.NhanVienId == luongThang.NhanVienId)
                        {
                            PhuCap phuCap = myData.PhuCaps.ToList().Find(x => x.PhuCapId == nhanVienPhuCap.PhuCapId);
                            luongThang.PhuCapNhanVien = "" + (long.Parse(luongThang.PhuCapNhanVien) + long.Parse(phuCap.TienPhuCap));
                        }
                    }

                    luongThang.PhuCapChucVu = myData.ChucVus.ToList().Find(x => x.ChucVuId == myData.NhanViens.ToList()
                        .Find(y => y.NhanVienId == luongThang.NhanVienId).ChucVuId).TienPhuCapChucVu;
                    //Tính hệ số thâm niên
                    DateTime ngayDauTienDiLam = DateTime.Now;
                    foreach(NhanVienCongViec nvcv in myData.NhanVienCongViecs.ToList())
                    {
                        if(luongThang.NhanVienId == nvcv.NhanVienId)
                        {
                            if (ngayDauTienDiLam.After((DateTime)nvcv.NgayBatDau))
                            {
                                ngayDauTienDiLam = (DateTime)nvcv.NgayBatDau;
                            }
                        }
                        
                    }
                    luongThang.PhuCapThamNien = ((int)(DateTime.Now - ngayDauTienDiLam).Days / 365) * 0.1;
                    luongThang.TienDuAn = "" + 0;
                    foreach(NhanVienDuAn nhanVienDuAn in myData.NhanVienDuAns.ToList())
                    {
                        if(nhanVienDuAn.NhanVienId == luongThang.NhanVienId)
                        {
                            DuAn duAn = myData.DuAns.ToList().Find(x => x.DuAnId == nhanVienDuAn.DuAnId);
                            if(((DateTime)duAn.NgayKetThuc).After(DateTime.Now.FirstDayOfPreviousMonth()) &&
                                ((DateTime)duAn.NgayKetThuc).Before(DateTime.Now.FirstDayOfPreviousMonth().LastDayOfMonth()))
                            {
                                luongThang.TienDuAn = "" + (long.Parse(luongThang.TienDuAn) + (nhanVienDuAn.PhanTramCV * long.Parse(duAn.ThuongDuAn) / 100));
                            }
                        }
                    }
                    luongThang.NgayTinhLuong = DateTime.Now.FirstDayOfMonth();
                    long luongMotNgay = long.Parse(luongThang.LuongCoBan) * (long)(1.0 + (double)luongThang.HSChucVu + (double)luongThang.HSCongViec + (double)luongThang.PhuCapThamNien) / 26;
                    luongThang.LuongThucLanh = "" + ((long)(luongMotNgay * (int)luongThang.SoNgayLam) + long.Parse(luongThang.ThuongLe) 
                        + long.Parse(luongThang.TienDuAn) + long.Parse(luongThang.PhuCapNhanVien));

                    //Lưu vào database
                    myData.LuongThangs.Add(luongThang);
                    myData.SaveChanges();
                }
            }
        }

        public List<LuongThang> Filter(string NhanVienId, string ThangChecked, int Thang, string NamChecked, int Nam, string optradio, string Tu, string Den)
        {
            List<LuongThang> luongThangs = new List<LuongThang>();
            bool Add = false;
            bool BThang = true;
            bool BNam = true;
            bool BLCB = true;
            bool BLTL = true;
            bool BTDA = true;
            
            foreach(LuongThang luongThang in myData.LuongThangs.ToList())
            {
                if(NhanVienId == null && ThangChecked == null && Thang == 0 && NamChecked == null && Nam == 0 && optradio == null && Tu == null && Den == null)
                {
                    continue;
                }
                if(luongThang.NhanVienId == NhanVienId)
                {
                    Add = true;
                    if(ThangChecked == "on")
                    {
                        if(((DateTime)luongThang.NgayTinhLuong).Month != Thang)
                        {
                            Add = false;
                        }
                    }
                    if (NamChecked == "on")
                    {
                        if (((DateTime)luongThang.NgayTinhLuong).Year != Nam)
                        {
                            Add = false;
                        }
                    }
                    if(optradio == "LCB")
                    {
                        if(long.Parse(Tu) > long.Parse(luongThang.LuongCoBan) || long.Parse(luongThang.LuongCoBan) > long.Parse(Den))
                        {
                            Add = false;
                        }
                    }
                    else
                    {
                        if (optradio == "LTL")
                        {
                            if (long.Parse(Tu) > long.Parse(luongThang.LuongThucLanh) || long.Parse(luongThang.LuongThucLanh) > long.Parse(Den))
                            {
                                Add = false;
                            }
                        }
                        else
                        {
                            if (optradio == "TDA")
                            {
                                if (long.Parse(Tu) > long.Parse(luongThang.TienDuAn) || long.Parse(luongThang.TienDuAn) > long.Parse(Den))
                                {
                                    Add = false;
                                }
                            }
                        }
                    }
                    if (Add)
                    {
                        luongThangs.Add(luongThang);
                        Add = false;
                    }
                }
                else
                {   if(NhanVienId == null)
                    {
                        if (ThangChecked == "on")
                        {
                            if (((DateTime)luongThang.NgayTinhLuong).Month != Thang)
                            {
                                BThang = false;
                            }
                        }
                        if (NamChecked == "on")
                        {
                            if (((DateTime)luongThang.NgayTinhLuong).Year != Nam)
                            {
                                BNam = false;
                            }
                        }
                        if (optradio == "LCB")
                        {
                            if (long.Parse(Tu) > long.Parse(luongThang.LuongCoBan) || long.Parse(luongThang.LuongCoBan) > long.Parse(Den))
                            {
                                BLCB = false;
                            }
                        }
                        else
                        {
                            if (optradio == "LTL")
                            {
                                if (long.Parse(Tu) > long.Parse(luongThang.LuongThucLanh) || long.Parse(luongThang.LuongThucLanh) > long.Parse(Den))
                                {
                                    BLTL = false;
                                }
                            }
                            else
                            {
                                if (optradio == "TDA")
                                {
                                    if (long.Parse(Tu) > long.Parse(luongThang.TienDuAn) || long.Parse(luongThang.TienDuAn) > long.Parse(Den))
                                    {
                                        BTDA = false;
                                    }
                                }
                            }
                        }
                        Add = BThang && BNam && BLCB && BLTL && BTDA;

                        if (Add)
                        {
                            luongThangs.Add(luongThang);
                        }
                        Add = false;
                        BThang = true;
                        BNam = true;
                        BLCB = true;
                        BLTL = true;
                        BTDA = true;
                    }
                }
            }
            return luongThangs;
        }

        public LuongThang FindById(string id)
        {
            return myData.LuongThangs.Find(id);
        }

        public string Remove(LuongThang obj)
        {
            myData.LuongThangs.Remove(obj);
            myData.SaveChanges();

            return null;
        }

        public List<LuongThang> ToList()
        {
            return myData.LuongThangs.ToList();
        }

        public List<LuongThang> ToListById(string NhanVienId)
        {
            return myData.LuongThangs.ToList().FindAll(x => x.NhanVienId == NhanVienId);
        }

        public string TotalSalaryOfPreviousMonth()
        {
            List<LuongThang> luongThangs = myData.LuongThangs.ToList().FindAll(x => x.NgayTinhLuong == DateTime.Now.FirstDayOfMonth());
            long totalSalary = 0;
            foreach (LuongThang luongThang in luongThangs)
            {
                totalSalary += long.Parse(luongThang.LuongThucLanh);
            }
            return "" + totalSalary;
        }

        public string Update(LuongThang obj)
        {
            //Kiểm tra quan hệ
            if (myData.NhanViens.ToList().Find(x => x.NhanVienId == obj.NhanVienId) == null)
            {
                return "Nhân viên id chưa tồn tại vui lòng khởi tạo trước khi sử dụng làm khóa ngoại";
            }

            //Sửa nếu không có lỗi
            myData.LuongThangs.Update(obj);
            myData.SaveChanges();

            return null;
        }
    }
}
