# Quản lý điểm sinh viên - Hệ tín chỉ

Ứng dụng quản lý điểm sinh viên theo hệ tín chỉ được phát triển bằng C# và SQL Server.

## Tính năng

- Đăng nhập với các vai trò: Phòng giáo vụ (PGV), Khoa, Sinh viên (SV), Giảng viên (GV)
- Quản lý danh mục: Khoa, Lớp, Sinh viên, Giảng viên, Môn học
- Quản lý lớp tín chỉ: Mở lớp, đăng ký, nhập điểm
- Báo cáo: Danh sách lớp tín chỉ, danh sách sinh viên đăng ký, bảng điểm môn học, phiếu điểm, danh sách học phí, bảng điểm tổng kết
- Quản trị: Tạo tài khoản, sao lưu và phục hồi cơ sở dữ liệu

## Cấu trúc cơ sở dữ liệu

- Khoa: Thông tin về các khoa
- Lop: Thông tin về các lớp
- Sinhvien: Thông tin về sinh viên
- Giangvien: Thông tin về giảng viên
- Monhoc: Thông tin về môn học
- Loptinchi: Thông tin về lớp tín chỉ
- Dangky: Thông tin đăng ký lớp tín chỉ của sinh viên

## Yêu cầu hệ thống

- Windows 7 trở lên
- .NET Framework 4.5 trở lên
- SQL Server 2012 trở lên

## Cài đặt

1. Tạo cơ sở dữ liệu QLDSV_HTC bằng script SQL đi kèm
2. Cấu hình chuỗi kết nối trong file App.config
3. Build và chạy ứng dụng

## Tác giả

- Threde

## Giấy phép

Dự án này được phân phối dưới giấy phép MIT. Xem file `LICENSE` để biết thêm chi tiết.
