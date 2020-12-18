USE MASTER
GO
CREATE DATABASE QuanLyDienNang
GO
USE QuanLyDienNang
GO

--BẢNG GIÁ ÁP DỤNG CHO KHÁCH HÀNG
CREATE TABLE BangGia
(
	--BG001
	MaBangGia char(5) primary key,
	TenBangGia nvarchar(100) not null
) 
GO

--TRẠM BIẾN ÁP ÁP DỤNG CHO KHÁCH HÀNG
CREATE TABLE TramBienAp
(
	--BA001
	MaTram char(5) primary key,
	TenTram nvarchar(100) not null
) 
GO

--NGƯỜI QUẢN LÝ KHÁCH HÀNG
CREATE TABLE NguoiQuanLy
(
	--QL001
	MaQuanLy char(5) primary key,
	TenQuanLy nvarchar(150) not null,
	SoDienThoai varchar(20) null,
	DiaChi nvarchar(200) not null,
	Email nvarchar(100) null
) 
GO

--THÔNG TIN KHÁCH HÀNG
CREATE TABLE KhachHang
(
	--KH000001
	MaKhachHang char(8) primary key,
	HoVaTen nvarchar(150) not null,
	DiaChi nvarchar(200) not null,
	MaBangGia char(5) references BangGia(MaBangGia),
	MaTram char(5) references TramBienAp(MaTram),
	SoHo tinyint not null default 1,
	HeSo tinyint not null default 1,
	MaSoThue varchar(20) null,
	SoDienThoai varchar(20) null,
	Email nvarchar(100) null,
	NgayTao datetime not null,
	NguoiTao char(5) references NguoiQuanLy(MaQuanLy),
	NgayCapNhat datetime not null,
	NguoiCapNhat char(5) references NguoiQuanLy(MaQuanLy),
	MaSoHopDong nvarchar(20) null,
	NgayHopDong datetime null,
	MaCongTo nvarchar(20) null,
	SoNganHang varchar(20) null,
	TenNganHang nvarchar(100) null
) 
GO

--THÔNG TIN ĐIỆN NĂNG TIÊU THỤ CỦA KHÁCH HÀNG
CREATE TABLE DienNangTieuThu
(
	ID int not null identity(1,1) primary key,
	MaKhachHang char(8) references KhachHang(MaKhachHang) not null,
	NgayGhi datetime not null,
	NguoiGhi char(5) references NguoiQuanLy(MaQuanLy),
	NgayCapNhat datetime not null,
	NguoiCapNhat char(5) references NguoiQuanLy(MaQuanLy),
	ChiSoMoi int,
	ChiSoCu int,
	DaThanhToan bit default 0 not null
) 
GO