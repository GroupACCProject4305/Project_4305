# Đề tài môn học Phát triển phần mềm mã nguồn mở

# Phần mềm quản lý phòng khám tư nhân
<p align="center">
  <img width="350" height="300" src="https://github.com/GroupACCProject4305/Project_4305/blob/master/92052logohuunghi.png">
</p>   

Ngày nay, CNTT đã và đang đóng vai trò quan trọng trong đời sống kinh tế, xã hội của nhiều quốc gia trên thế giới, là một phần không thể thiếu trong xã hội năng động, ngày càng hiện đại hoá. Vì vậy, việc tin học hoá vào một số lĩnh vực là hoàn toàn có thể và phù hợp với xu hướng hiện nay. Xuất phát từ nhu cầu thực tế đó, trong công việc kinh doanh, việc quản lý hệ thống thông tin phong kham là một việc không thể thiếu. Nhằm thay thế một số công việc mà trước đó phải thao tác bằng tay trên giấy tờ đạt hiệu quả không cao, mất nhiều thời gian. Vì vậy, chúng em đã chọn thực hiện xây dựng một phần mềm được viết bằng ngôn ngữ C# kết nối với hệ quản trị CSDL MS SQL Server với đề tài “Xây dựng phần mềm quản lý quán phòng khám”.

## Quản lý phiên bản

Chúng tôi dùng [Git](https://git-scm.com/) để tổ chức quản lý phiên bản theo hướng phân tán.

## Tác giả

- Lê Hoàng Ngọc Ấn|01668118011|lehoangngocan4@gmail.com

- Nguyễn Quốc Cường|01696249463|niiallstyle196@gmail.com

- Nguyễn Lê Phú Cường||nguyenlephucuong112@gmail.com 
## Giấy phép

Đồ án này được cấp phép theo giấy phép của General Public License - xem file [LICENSE.md](https://github.com/GroupACCProject4305/Project_4305/blob/master/Document/LICENSE.md) để biết thêm chi tiết.

## Kiến thức áp dụng

Sử dụng các control cơ bản và nâng cao trong Winform.
DataGridView, DataSet, DataTable, DataRow.
Phân tích thiết kế hệ thống cơ sở dữ liệu.
Phân tích thiết kế giao diện.
Trigger SQL.
Procedure, function SQL.
Kết nối SQL server với ứng dụng winform
Chuyển data giữa các form.
Phân quyền người dùng trên ứng dụng.
Thêm, xóa, sửa dữ liệu từ trang quản trị.
## Chuẩn Lập Trình

- Mục đích: Đưa ra các quy ước khi coding với ngôn ngữ lập trình C#, với các quy tắc này giúp tiết kiệm thời gian rất lớn trong tiến trình phát triển phần mềm và cả trong quá trình bảo trì sản phẩm. Giúp sinh viên quen với làm việc theo nhóm. Tài liệu này chủ yếu hướng dẫn sinh viên với ngôn ngữ lập trình C#, nhưng có rất nhiều quy tắc được sử dụng trong nhiều ngôn ngữ lập trình khác tích hợp trong bộ công cụ Visual Studio .NET.

- Phạm vi áp dụng: Những lập trình viên tham gia dự án phát triển bằng ngôn ngữ C# và công cụ Visual Studio .Net.

## Nền tảng xây dựng

C# .NET - Nền tảng hệ thống phần mềm
C # là một ngôn ngữ lập trình hiện đại được phát triển bởi Microsoft và được phê duyệt bởi European Computer Manufacturers Association (ECMA) và International Standards Organization (ISO).

C # được phát triển bởi Anders Hejlsberg và nhóm của ông trong việc phát triển .Net Framework.

C # được thiết kế cho các ngôn ngữ chung cơ sở hạ tầng (Common Language Infrastructure – CLI), trong đó bao gồm các mã (Executable Code) và môi trường thực thi (Runtime Environment) cho phép sử dụng các ngôn ngữ cấp cao khác nhau trên đa nền tảng máy tính và kiến trúc khác nhau.

Ngôn ngữ ra đời cùng với .NET

Kết hợp C++ và Java. Hướng đối tượng. Hướng thành phần. Mạnh mẽ (robust) và bền vững (durable). Mọi thứ trong C# đều Object oriented. Kể cả kiểu dữ liệu cơ bản. Chỉ cho phép đơn kế thừa. Dùng interface để khắc phục. Lớp Object là cha của tất cả các lớp. Mọi lớp đều dẫn xuất từ Object. Cho phép chia chương trình thành các thành phần nhỏ độc lập nhau. Mỗi lớp gói gọn trong một file, không cần file header như C/C++. Bổ sung khái niệm namespace để gom nhóm các lớp. Bổ sung khái niệm “property” cho các lớp. Khái niệm delegate & event

Vai trò C# trong .NET Framework

.NET runtime sẽ phổ biến và được cài trong máy client. Việc cài đặt App C# như là tái phân phối các thành phần .NET Nhiều App thương mại sẽ được cài đặt bằng C#.

C# tạo cơ hội cho tổ chức xây dựng các App Client/Server n-tier. Kết nối ADO.NET cho phép truy cập nhanh chóng & dễ dàng với SQL Server, Oracle… Cách tổ chức .NET cho phép hạn chế những vấn đề phiên bản.

MS SQL Server - Nền tảng cơ sở dữ liệu
SQL Server là một hệ quản trị cơ sở dữ liệu quan hệ (Relational Database Management System (RDBMS) ) sử dụng câu lệnh SQL (Transact-SQL) để trao đổi dữ liệu giữa máy Client và máy cài SQL Server. Một RDBMS bao gồm databases, database engine và các ứng dụng dùng để quản lý dữ liệu và các bộ phận khác nhau trong RDBMS.

SQL Server được tối ưu để có thể chạy trên môi trường cơ sở dữ liệu rất lớn (Very Large Database Environment) lên đến Tera-Byte và có thể phục vụ cùng lúc cho hàng ngàn user. SQL Server có thể kết hợp “ăn ý” với các server khác như Microsoft Internet Information Server (IIS), E-Commerce Server, Proxy Server….

## Tài liệu cho nhà phát triển

Mời các bạn [Click xem tài liệu cho nhà phát triển](https://github.com/GroupACCProject4305/Project_4305/blob/master/Document/TLphattrien.md)

## Lời cảm ơn

Chúng em xin cảm ơn thầy Mai Cường Thọ cùng các thầy cô bộ môn Kỹ thuật phần mềm đã tạo điều kiện cho chúng em nghiên cứu và hoàn thành đề tài. Xin trân trọng cảm ơn thầy Mai Cường Thọ một lần nữa đã tận tình giúp đỡ, hướng dẫn chúng em trong suốt quá trình thực hiện đề tài.
