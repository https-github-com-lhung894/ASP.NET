create database QLNS;
use QLNS;

INSERT INTO Accounts(AccountId, TaiKhoan, MatKhau, Quyen) VALUES
('nv00000', 'admin@email.com', '123', 1),
('nv00001', 'nv00001', 'nv00001', 2),
('nv00002', 'nv00002', 'nv00002', 2),
('nv00003', 'nv00003', 'nv00003', 2),
('nv00004', 'nv00004', 'nv00004', 2),
('nv00005', 'nv00005', 'nv00005', 2),
('nv00006', 'nv00006', 'nv00006', 2),
('nv00007', 'nv00007', 'nv00007', 2),
('nv00008', 'nv00008', 'nv00008', 2);

INSERT INTO PhongBans(PhongBanId, TenPhongBan, SDTPhongBan, TrangThai) VALUES
('null', 'Trống', 'Trống', 1),
('pb00001', 'Phòng Ban 1', '11111111', 1),
('pb00002', 'Phòng Ban 2', '22222222', 1),
('pb00003', 'Phòng Ban 3', '33333333', 1),
('pb00004', 'Phòng Ban 4', '44444444', 1),
('pb00005', 'Phòng Ban 5', '55555555', 1);

INSERT INTO CongViecs(CongViecId, TenCongViec) VALUES
('congviec1', 'Phân tích dữ liệu'),
('congviec2', 'Lập trình'),
('congviec3', 'Kiểm thử phần mềm'),
('congviec4', 'Hỗ trợ kỹ thuật');

INSERT INTO TrangThaiChamCongs(TrangThaiChamCongId, TenTrangThai, HSTrangThai) VALUES
('tt1', 'Làm việc', 0),
('tt2', 'Nghỉ phép', 0.7),
('tt3', 'Nghỉ không phép', 1),
('tt4', 'Nghỉ bệnh', 0.5);

INSERT INTO DuAns(DuAnId, TenDuAn, PhanTramDuAn, ThuongDuAn, NgayBatDau, NgayKetThuc, TrangThai) VALUES
('da00001', 'Dự Án 1', 77, 6000000, '2020-05-11', '2020-06-10', 1),
('da00002', 'Dự Án 2', 53, 8000000, '2020-06-09', '2020-07-14', 1),
('da00003', 'Dự Án 3', 20, 9000000, '2020-06-09', '2020-06-25', 1),
('da00004', 'Dự Án 4', 100, 8000000, '2020-06-18', '2020-07-21', 1);

INSERT INTO ChucVus(ChucVuId, TenChucVu, HSChucVu, TienPhuCapChuVu) VALUES
('chucvu1', 'Trường phòng ban', 0.5, 500000),
('chucvu2', 'Phó phòng ban', 0.3, 300000),
('chucvu3', 'Nhân viên', 0.1, 100000);

INSERT INTO PhuCaps(PhuCapId, TenPhuCap, TienPhuCap, TrangThai) VALUES
('pc00001', 'Đi lại', 100000, 1),
('pc00002', 'Ăn uống', 100000, 1),
('pc00003', 'Đoàn thể', 50000, 1),
('pc00004', 'Sức khỏe', 80000, 1);

INSERT INTO NhanViens(NhanVienId, HoNhanVien, TenNhanVien, PhongBanId, ChucVuId, TrangThai, AccountId) VALUES
('nv00000', 'Admin', 'Admin', 'pb00001', 'chucvu1', 1, 'nv00000'),
('nv00001', 'Nguyễn Văn', 'Aev', 'pb00001', 'chucvu1', 1, 'nv00001'),
('nv00002', 'Nguyễn Văn', 'B', 'pb00001', 'chucvu2', 1, 'nv00002'),
('nv00003', 'Nguyễn Văn', 'Cyt', 'pb00001', 'chucvu2', 1, 'nv00003'),
('nv00004', 'Nguyễn Văn', 'Deu', 'pb00001', 'chucvu3', 1, 'nv00004'),
('nv00005', 'Nguyễn Văn', 'Epp', 'pb00002', 'chucvu1', 1, 'nv00005'),
('nv00006', 'Nguyễn Văn ', 'PP', 'pb00002', 'chucvu2', 1, 'nv00006'),
('nv00007', 'Nguyễn Văn', 'W', 'pb00002', 'chucvu2', 1, 'nv00007');

INSERT INTO NhanVienCongViecs(NhanVienCongViecId,NhanVienId, CongViecId, HSCongViec, NgayBatDau, NgayKetThuc) VALUES
('1','nv00001', 'congviec1', 0.5, '2018-07-01', '2020-07-01'),
('2','nv00001', 'congviec3', 0.5, '2020-07-01', '2020-07-01'),
('3','nv00002', 'congviec2', 0.5, '2018-07-01', '2020-07-01'),
('4','nv00003', 'congviec2', 0.5, '2020-07-01', '2020-07-01'),
('5','nv00003', 'congviec3', 0.5, '2018-07-01', '2020-07-01'),
('6', 'nv00004', 'congviec4', 0.5, '2018-07-01', '2020-07-01');

INSERT INTO HopDongs(HopDongId, NhanVienId, CongViecId, NgayKyHopDong, LuongCanBo, TrangThai) VALUES
('45', 'nv00001', 'congviec1', '2018-06-22', 3000000, 0),
('46', 'nv00002', 'congviec2', '2018-06-22', 4000000, 1),
('47', 'nv00003', 'congviec3', '2018-06-22', 5000000, 0),
('48', 'nv00004', 'congviec4', '2018-06-22', 3500000, 1),
('49', 'nv00005', 'congviec1', '2018-06-22', 2000000, 0),
('50', 'nv00006', 'congviec2', '2018-06-22', 3800000, 1),
('51', 'nv00007', 'congviec3', '2018-06-22', 4300000, 1);

INSERT INTO ChiTietNhanViens(ChiTietNhanVienId,NhanVienId, NgaySinh, NoiSinh, TrinhDoHocVan, GioiTinh, CMND, NgayCapCMND, DiaChi, SDT, Email, HinhAnh) VALUES
('nv00001','nv00001', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '258258258', '2020-07-01', '23 Tô Hiệu', '0897647145', 'aev@gmail.com', 'nv00001.jpg'),
('nv00002','nv00002', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '11103031', '2020-07-01', '23 Tô Hiệu', '0897647145', 'x@gmail.com', 'nv00002.jpg'),
('nv00003','nv00003', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '888888888', '2020-07-01', '23 Tô Hiệu', '0897647145', 'cyt@gmail.com', 'nv00003.jpg'),
('nv00004','nv00004', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '999999999', '2020-07-01', '23 Tô Hiệu', '0897647145', 'deu@gmail.com', 'nv00004.jpg'),
('nv00005','nv00005', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '222222222', '2020-07-01', '23 Tô Hiệu', '0897647145', 'epp@gmail.com', 'nv00005.jpg'),
('nv00006','nv00006', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '11103031', '2020-07-01', '23 Tô Hiệu', '0897647145', 'x@gmail.com', 'nv00006.jpg'),
('nv00007','nv00007', '2000-01-07', 'Khánh Hòa', 'Đại Học', 'Nam', '11103031', '2020-07-01', '23 Tô Hiệu', '0897647145', 'x@gmail.com', 'nv00007.jpg');

INSERT INTO NhanVienDuAns(NhanVienDuAnId, NhanVienId, DuAnId, PhanTramCV) VALUES
('1', 'nv00001', 'da00001', 23),
('2', 'nv00002', 'da00002', 47),
('3', 'nv00002', 'da00003', 28),
('4', 'nv00003', 'da00003', 52);

INSERT INTO BangChamCongs(BangChamCongId, NhanVienId, TrangThaiChamCongId, NgayLamViec) VALUES
('1', 'nv00001', 'tt1', '2020-06-02'),
('2', 'nv00001', 'tt1', '2020-07-03'),
('3', 'nv00001', 'tt1', '2020-07-19'),
('4', 'nv00002', 'tt1', '2020-05-16'),
('5', 'nv00002', 'tt1', '2020-05-17'),
('6', 'nv00002', 'tt1', '2020-05-18'),
('7', 'nv00002', 'tt1', '2020-05-19'),
('8', 'nv00002', 'tt1', '2020-05-20');

INSERT INTO NhanVienPhuCaps(NhanVienPhuCapId, NhanVienId, PhuCapId) VALUES
('1', 'nv00001', 'pc00001'),
('2', 'nv00002', 'pc00002'),
('3', 'nv00003', 'pc00003'),
('4', 'nv00005', 'pc00001'),
('5', 'nv00006', 'pc00002'),
('6', 'nv00007', 'pc00003');

INSERT INTO LuongThangs(LuongThangId, NhanVienId, LuongCoBan, HSChucVu, HSCongViec, SoNgayLam, SoNgayNghiCoPhep, SoNgayNghiKhongPhep, SoNgayNghiOm, PhuCapNhanVien, PhuCapChucVu, PhuCapThamNien, ThuongLe, TienDa, NgayTinhLuong, LuongThucLanh) VALUES
('1', 'nv00002', 4000000, 0.3, 0.5, 0, 0, 0, 0, 100000, 300000, 0.1, 0, 0, '2020-02-29', 8000000),
('2', 'nv00002', 4000000, 0.3, 0.5, 0, 0, 0, 0, 100000, 300000, 0.1, 0, 0, '2020-03-31', 8000000),
('3', 'nv00002', 4000000, 0.3, 0.5, 0, 0, 0, 0, 100000, 300000, 0.1, 200000, 0, '2020-04-30', 8200000),
('4', 'nv00002', 4000000, 0.3, 0.5, 5, 0, 0, 0, 100000, 300000, 0.1, 200000, 0, '2020-05-31', 8200000),
('5', 'nv00004', 3500000, 0.1, 0.5, 0, 0, 0, 0, 0, 100000, 0.1, 0, 0, '2020-02-29', 6050000),
('6', 'nv00004', 3500000, 0.1, 0.5, 0, 0, 0, 0, 0, 100000, 0.1, 0, 0, '2020-03-31', 6050000);

INSERT INTO ThongTinDuLieuCuois(ThongTinDuLieuCuoiId, NhanVienId, DuAnId, PhongBanId, PhuCapId) VALUES
('1','nv00030', 'da00004', 'pb00005', 'pc00004');

INSERT INTO ThuongLes(ThuongLeId, NgayLe, TienThuongLe) VALUES
('tl00001', '2020-01-01', 200000),
('tl00002', '2020-04-30', 200000),
('tl00003', '2020-05-01', 200000),
('tl00004', '2020-09-02', 200000);
































