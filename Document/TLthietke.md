# PHÂN TÍCH VÀ THIẾT KẾ HỆ THỐNG

	Mô hình DFD mức 0:

![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/h%C3%ACnhDFD.png)

	Mô hình DFD mức 1: Các chức năng của hệ thống quản lý phòng khám
•	Module 1: Quản lý bệnh nhân
-	Tiếp nhận bệnh nhân vào khám bệnh
-	Tìm kiếm bệnh nhân
-	Cập nhập thông tin bệnh nhân
![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modu1.png)

•	Module 2: Quản lý khám bệnh
-	Tiếp nhận bệnh nhân vào khám bệnh
[](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modu2.png)
-	Lập phiếu khám
-	Tìm phiếu khám
-	Cập nhập phiếu khám
![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modu2-2.png)

•	Module 3: Quản lý tình hình khám chữa bệnh
-	Lập Toa Thuốc
-	In Toa Thuốc
![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modu3.png)
-	Lập Hóa Đơn Thuốc
-	In Hóa Đơn Thuốc
![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modu3-2.png)
-	Lập báo cáo doanh thu theo ngày
![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modu3-3.png)
-	Lập báo cáo sự dụng thuốc
![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/modul3-4.png)

Mô hình ERD

![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/hinhERL.png)

Chuyển từ mô hình ERD sang mô hình quan hệ
BENHNHAN (MaBN, TenBN, NgaySinh, GioiTinh, DiaChi, SDT)
PHIEUKHAM (MaPK, NgayKham, TrieuChung, ChuanDoan, TienKham, MaBN)
TOATHUOC (Matoa, Bsketoa, Ngayketoa, MaBN, MaPK)
HOADONTHUOC (MaHD, Ngayban, TienThuoc, Matoa)
THUOC ( MaThuoc, TenThuoc, DonVi, DonGia, Ngaysx, Hansudung)
CHITIETOATHUOC (MaToa, MaThuoc, Sluong, Cdung)
-	Kí hiệu:
ABC : Khóa chính.
ABC : Khóa ngoại.
-	Thuộc tính Soluong: số lượng mỗi loại thuốc có trong toa thuốc.
-	Thuộc tính Cachdung: cách dùng của mỗi loại thuốc ứng với toa thuốc hiện hành.
-	Bảng CSDL CHITIETHOADON: Diễn tả chi tiết hóa đơn gồm số lượng và cách dùng ứng với mỗi loại thuốc có trong Toa Thuoc.

MÔ HÌNH QUAN HỆ

![](https://github.com/GroupACCProject4305/Project_4305/blob/master/image/hinhqh.png)
