-- Create database
USE master;
GO
DROP DATABASE IF EXISTS QLDSV_HTC;
GO
CREATE DATABASE QLDSV_HTC;
GO

-- Khoa
USE QLDSV_HTC;
DROP TABLE IF EXISTS Khoa;
CREATE TABLE Khoa (
    MAKHOA          NCHAR(10),
    TENKHOA         NVARCHAR(50) NOT NULL UNIQUE,

    CONSTRAINT PK_Khoa                  PRIMARY KEY (MAKHOA),
);
GO

-- Lop
USE QLDSV_HTC;
DROP TABLE IF EXISTS Lop;
CREATE TABLE Lop (
    MALOP           NCHAR(10),
    TENLOP          NVARCHAR(50) NOT NULL UNIQUE,
    KHOAHOC         NVARCHAR(9) NOT NULL,
    MAKHOA          NCHAR(10) NOT NULL,

    CONSTRAINT PK_Lop                  PRIMARY KEY (MALOP),
    CONSTRAINT FK_Lop_Khoa             FOREIGN KEY (MAKHOA)    REFERENCES Khoa(MAKHOA),
);
GO

-- Sinh vien
USE QLDSV_HTC;
DROP TABLE IF EXISTS Sinhvien;
CREATE TABLE Sinhvien (
    MASV            NCHAR(10),
    HO              NVARCHAR(50) NOT NULL,
    TEN             NVARCHAR(10) NOT NULL,
    MALOP           NCHAR(10) NOT NULL,
    PHAI            BIT DEFAULT 0,
    NGAYSINH        DATETIME,
    DIACHI          NVARCHAR(100),
    DANGHIHOC       BIT DEFAULT 0,
    [PASSWORD]      NVARCHAR(40) DEFAULT 123456,

    CONSTRAINT PK_Sinhvien             PRIMARY KEY (MASV),
    CONSTRAINT FK_Sinhvien_Lop         FOREIGN KEY (MALOP)     REFERENCES Lop(MALOP)
);
GO

-- Mon hoc
USE QLDSV_HTC;
DROP TABLE IF EXISTS Monhoc;
CREATE TABLE Monhoc (
    MAMH            NCHAR(10),
    TENMH           NVARCHAR(50) NOT NULL UNIQUE,
    SOTIET_LT       INT NOT NULL,
    SOTIET_TH       INT NOT NULL,

    CONSTRAINT PK_Monhoc               PRIMARY KEY (MAMH),
);
GO

-- Giang vien
USE QLDSV_HTC;
DROP TABLE IF EXISTS Giangvien;
CREATE TABLE Giangvien (
    MAGV            NCHAR(10),
    HO              NVARCHAR(50) NOT NULL,
    TEN             NVARCHAR(10) NOT NULL,
    HOCVI           NVARCHAR(20),
    HOCHAM          NVARCHAR(20),
    CHUYENMON       NVARCHAR(50),
    MAKHOA          NCHAR(10) NOT NULL,
    [PASSWORD]      NVARCHAR(40) DEFAULT 123456,

    CONSTRAINT PK_Giangvien            PRIMARY KEY (MAGV),
    CONSTRAINT FK_Giangvien_Khoa       FOREIGN KEY (MAKHOA) REFERENCES Khoa(MAKHOA),
);
GO

-- Lop tin chi
USE QLDSV_HTC;
DROP TABLE IF EXISTS Loptinchi;
CREATE TABLE Loptinchi (
    MALTC           INT IDENTITY,
    NIENKHOA        NCHAR(9) NOT NULL,
    HOCKY           INT NOT NULL CHECK (HOCKY BETWEEN 1 AND 3),
    MAMH            NCHAR(10) NOT NULL,
    NHOM            INT NOT NULL CHECK (NHOM >= 1),
    MAGV            NCHAR(10) NOT NULL,
    MAKHOA          NCHAR(10) NOT NULL,
    SOSVTOITHIEU    SMALLINT NOT NULL CHECK (SOSVTOITHIEU > 0),
    HUYLOP          BIT DEFAULT 0,

    CONSTRAINT PK_Loptinchi            PRIMARY KEY (MALTC),
    CONSTRAINT UQ_Loptinchi            UNIQUE (NIENKHOA, HOCKY, MAMH, NHOM),
    CONSTRAINT FK_Loptinchi_Monhoc     FOREIGN KEY (MAMH) REFERENCES Monhoc(MAMH),
    CONSTRAINT FK_Loptinchi_Giangvien  FOREIGN KEY (MAGV) REFERENCES Giangvien(MAGV),
    CONSTRAINT FK_Loptinchi_Khoa       FOREIGN KEY (MAKHOA) REFERENCES Khoa(MAKHOA),
);
GO

-- Dang ky
USE QLDSV_HTC;
DROP TABLE IF EXISTS Dangky;
CREATE TABLE Dangky (
    MALTC           INT NOT NULL,
    MASV            NCHAR(10) NOT NULL,
    DIEM_CC         INT CHECK (DIEM_CC BETWEEN 0 AND 10),
    DIEM_GK         FLOAT CHECK (DIEM_GK BETWEEN 0 AND 10),
    DIEM_CK         FLOAT CHECK (DIEM_CK BETWEEN 0 AND 10),
    HUYDANGKY       BIT DEFAULT 0,

    CONSTRAINT PK_Dangky               PRIMARY KEY (MALTC, MASV),
    CONSTRAINT FK_Dangky_Loptinchi     FOREIGN KEY (MALTC) REFERENCES Loptinchi(MALTC),
    CONSTRAINT FK_Dangky_Sinhvien      FOREIGN KEY (MASV) REFERENCES Sinhvien(MASV)
);
GO

-- Add computed column for DiemHetMon
ALTER TABLE Dangky
ADD DiemHetMon AS (Diem_CC * 0.1 + Diem_GK * 0.3 + Diem_CK * 0.6);
GO

-- Insert sample data
-- Insert Khoa
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('CNTT', N'Công nghệ thông tin');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('VT', N'Viễn thông');
INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('ATTT', N'An toàn thông tin');
GO

-- Insert Lop
INSERT INTO Lop (MaLop, TenLop, KhoaHoc, MaKhoa) VALUES ('D20CQCN01', N'Đại học chính quy Công nghệ thông tin 1', '2020-2024', 'CNTT');
INSERT INTO Lop (MaLop, TenLop, KhoaHoc, MaKhoa) VALUES ('D20CQCN02', N'Đại học chính quy Công nghệ thông tin 2', '2020-2024', 'CNTT');
INSERT INTO Lop (MaLop, TenLop, KhoaHoc, MaKhoa) VALUES ('D20CQVT01', N'Đại học chính quy Viễn thông 1', '2020-2024', 'VT');
INSERT INTO Lop (MaLop, TenLop, KhoaHoc, MaKhoa) VALUES ('D21CQAT01', N'Đại học chính quy An toàn thông tin 1', '2021-2025', 'ATTT');
GO

-- Insert GiangVien
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV001', N'Nguyễn Văn', N'Hùng', N'TS', N'PGS', N'Lập trình', 'CNTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV002', N'Trần', N'Bình', N'GS', NULL, N'Mạng máy tính', 'CNTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV003', N'Lê', N'Cường', N'PGS', N'Th.S', N'Cấu trúc dữ liệu', 'VT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV004', N'Phạm', N'Duy', N'TS', N'GS', N'Công nghệ phần mềm', 'ATTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV005', N'Hoàng', N'Hà', N'Th.S', N'Th.S', N'Hệ điều hành', 'CNTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV006', N'Vũ', N'Khoa', N'GS', N'PGS', N'Mạng viễn thông', 'VT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV007', N'Đỗ', N'Linh', N'PGS', N'TS', N'Trí tuệ nhân tạo', 'CNTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV008', N'Bùi', N'Minh', N'TS', NULL, N'Học máy', 'ATTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV009', N'Ngô', N'Nam', N'Th.S', N'PGS', N'Phát triển web', 'CNTT');
INSERT INTO Giangvien (MaGV, Ho, Ten, HocVi, HocHam, ChuyenMon, MaKhoa) 
VALUES ('GV010', N'Dương', N'Phú', N'PGS', N'GS', N'Cơ sở dữ liệu', 'CNTT');
GO

-- Insert MonHoc
INSERT INTO Monhoc (MaMH, TenMH, SoTiet_LT, SoTiet_TH) VALUES ('MMTT', N'Mạng máy tính', 30, 15);
INSERT INTO Monhoc (MaMH, TenMH, SoTiet_LT, SoTiet_TH) VALUES ('CSDL', N'Cơ sở dữ liệu', 45, 30);
INSERT INTO Monhoc (MaMH, TenMH, SoTiet_LT, SoTiet_TH) VALUES ('CTDL', N'Cấu trúc dữ liệu và giải thuật', 45, 30);
INSERT INTO Monhoc (MaMH, TenMH, SoTiet_LT, SoTiet_TH) VALUES ('LTJV', N'Lập trình Java', 30, 45);
INSERT INTO Monhoc (MaMH, TenMH, SoTiet_LT, SoTiet_TH) VALUES ('ATTT', N'An toàn thông tin', 45, 15);
GO

-- Insert SinhVien
INSERT INTO Sinhvien (MaSV, Ho, Ten, Phai, NgaySinh, DiaChi, MaLop, DaNghiHoc, PASSWORD)
VALUES ('SV001', N'Nguyễn Văn', N'Nam', 0, '2002-05-15', N'Hà Nội', 'D20CQCN01', 0, '123456');
INSERT INTO Sinhvien (MaSV, Ho, Ten, Phai, NgaySinh, DiaChi, MaLop, DaNghiHoc, PASSWORD)
VALUES ('SV002', N'Trần Thị', N'Hoa', 1, '2002-08-20', N'Hải Phòng', 'D20CQCN01', 0, '123456');
INSERT INTO Sinhvien (MaSV, Ho, Ten, Phai, NgaySinh, DiaChi, MaLop, DaNghiHoc, PASSWORD)
VALUES ('SV003', N'Lê Văn', N'Tùng', 0, '2002-03-10', N'Đà Nẵng', 'D20CQCN02', 0, '123456');
INSERT INTO Sinhvien (MaSV, Ho, Ten, Phai, NgaySinh, DiaChi, MaLop, DaNghiHoc, PASSWORD)
VALUES ('SV004', N'Phạm Thị', N'Lan', 1, '2002-11-25', N'TP. Hồ Chí Minh', 'D20CQVT01', 0, '123456');
INSERT INTO Sinhvien (MaSV, Ho, Ten, Phai, NgaySinh, DiaChi, MaLop, DaNghiHoc, PASSWORD)
VALUES ('SV005', N'Hoàng Văn', N'Minh', 0, '2003-01-05', N'Cần Thơ', 'D21CQAT01', 0, '123456');
GO

-- Insert LopTinChi
INSERT INTO Loptinchi (NienKhoa, HocKy, MaMH, Nhom, MaGV, MaKhoa, SoSVToiThieu, HuyLop)
VALUES ('2023-2024', 1, 'MMTT', 1, 'GV003', 'VT', 15, 0);
INSERT INTO Loptinchi (NienKhoa, HocKy, MaMH, Nhom, MaGV, MaKhoa, SoSVToiThieu, HuyLop)
VALUES ('2023-2024', 1, 'CSDL', 1, 'GV001', 'CNTT', 15, 0);
INSERT INTO Loptinchi (NienKhoa, HocKy, MaMH, Nhom, MaGV, MaKhoa, SoSVToiThieu, HuyLop)
VALUES ('2023-2024', 1, 'CTDL', 1, 'GV002', 'CNTT', 15, 0);
INSERT INTO Loptinchi (NienKhoa, HocKy, MaMH, Nhom, MaGV, MaKhoa, SoSVToiThieu, HuyLop)
VALUES ('2023-2024', 1, 'LTJV', 1, 'GV002', 'CNTT', 15, 0);
INSERT INTO Loptinchi (NienKhoa, HocKy, MaMH, Nhom, MaGV, MaKhoa, SoSVToiThieu, HuyLop)
VALUES ('2023-2024', 1, 'ATTT', 1, 'GV004', 'ATTT', 15, 0);
GO

-- Insert DangKy
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (1, 'SV001', 10, 8.5, 7.5, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (2, 'SV001', 9, 7.5, 8.0, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (3, 'SV001', 8, 7.0, 7.5, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (1, 'SV002', 10, 9.0, 8.5, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (2, 'SV002', 9, 8.0, 8.5, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (3, 'SV003', 8, 7.5, 8.0, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (4, 'SV003', 9, 8.0, 7.5, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (5, 'SV004', 10, 9.5, 9.0, 0);
INSERT INTO Dangky (MaLTC, MaSV, Diem_CC, Diem_GK, Diem_CK, HuyDangKy)
VALUES (5, 'SV005', 9, 8.5, 8.0, 0);
GO
