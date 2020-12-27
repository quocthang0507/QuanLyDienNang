USE MASTER
GO 
CREATE DATABASE QuanLyDienNang
GO 
USE QuanLyDienNang
GO 

--BẢNG GIÁ ÁP DỤNG CHO KHÁCH HÀNG
CREATE TABLE BangGia (
	--BG001
	MaBangGia char(5) primary key,
	TenBangGia nvarchar(100) not null
)
GO 
INSERT INTO BangGia VALUES ('BG001', N'Điện sinh hoạt (hộ thường)')
INSERT INTO BangGia VALUES ('BG002', N'Điện sinh hoạt (hộ nghèo)')
INSERT INTO BangGia VALUES ('BG003', N'Điện kinh doanh - dịch vụ')
INSERT INTO BangGia VALUES ('BG004', N'Điện sản xuất')
GO

CREATE PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia
GO

CREATE PROCEDURE proc_Insert_BangGia
	@MaBangGia char(5),
	@TenBangGia nvarchar(100)
AS
	INSERT INTO BangGia VALUES (@MaBangGia, @TenBangGia)
GO

CREATE PROCEDURE proc_Update_BangGia
	@MaBangGia char(5),
	@TenBangGia nvarchar(100)
AS
	UPDATE BangGia
	SET TenBangGia = @TenBangGia
	WHERE MaBangGia = @MaBangGia
GO

CREATE PROCEDURE proc_Delete_BangGia
	@MaBangGia char(5)
AS
	DELETE FROM BangGia
	WHERE MaBangGia = @MaBangGia
GO

--TRẠM BIẾN ÁP ÁP DỤNG CHO KHÁCH HÀNG
CREATE TABLE TramBienAp (
	--BA001
	MaTram char(5) primary key,
	TenTram nvarchar(100) not null
)
GO 
INSERT INTO TramBienAp VALUES ('BA001', N'Trạm biến áp 1')
INSERT INTO TramBienAp VALUES ('BA002', N'Trạm biến áp 2')
INSERT INTO TramBienAp VALUES ('BA003', N'Trạm biến áp 3')
SELECT * FROM TramBienAp
GO

CREATE PROCEDURE proc_GetAll_TramBienAp
AS
	SELECT * FROM TramBienAp
GO

CREATE PROCEDURE proc_Insert_TramBienAp
	@MaTram char(5),
	@TenTram nvarchar(100)
AS
	INSERT INTO TramBienAp VALUES (@MaTram, @TenTram)
GO

CREATE PROCEDURE proc_Update_TramBienAp
	@MaTram char(5),
	@TenTram nvarchar(100)
AS
	UPDATE TramBienAp
	SET TenTram = @TenTram
	WHERE MaTram = @MaTram
GO

CREATE PROCEDURE proc_Delete_TramBienAp
	@MaTram char(5)
AS
	DELETE FROM TramBienAp
	WHERE MaTram = @MaTram
GO

--NGƯỜI QUẢN LÝ KHÁCH HÀNG
CREATE TABLE NguoiQuanLy (
	--QL001
	MaQuanLy char(5) primary key,
	TenQuanLy nvarchar(150) not null,
	SoDienThoai varchar(20) null,
	DiaChi nvarchar(200) not null,
	Email nvarchar(100) null
)
GO
INSERT INTO NguoiQuanLy VALUES ('QL001', N'La Quốc Thắng', '0987610260', N'Đà Lạt - Lâm Đồng', 'quocthang_0507@yahoo.com.vn')
INSERT INTO NguoiQuanLy VALUES ('QL002', N'Nguyễn Văn A', '0123456789', N'Đà Lạt - Lâm Đồng', 'nva@yahoo.com.vn')
INSERT INTO NguoiQuanLy VALUES ('QL003', N'Trần Thị B', '0987654321', N'Đà Lạt - Lâm Đồng', 'ttb@yahoo.com.vn')
GO

CREATE PROCEDURE proc_GetAll_NguoiQuanLy
--ALTER PROCEDURE proc_GetAll_NguoiQuanLy
AS
	SELECT * FROM NguoiQuanLy ORDER BY MaQuanLy
GO

CREATE FUNCTION func_GenerateID_NguoiQuanLy()
--ALTER FUNCTION func_GenerateID_NguoiQuanLy()
RETURNS CHAR(5)
AS
	BEGIN
		DECLARE @ID INT
		DECLARE @MA CHAR(5)
		IF EXISTS (SELECT MaQuanLy FROM NguoiQuanLy WHERE MaQuanLy=(SELECT max(MaQuanLy) FROM NguoiQuanLy))
			SET @MA = (SELECT MaQuanLy FROM NguoiQuanLy WHERE MaQuanLy=(SELECT max(MaQuanLy) FROM NguoiQuanLy))
		ELSE
			SET @MA = 'QL000'
		SET @ID = CAST (RIGHT(@MA, 3) AS INT) + 1
		SET @MA = 'QL' + RIGHT('000' + CAST (@ID AS VARCHAR(3)), 3)
		RETURN @MA
	END
GO

/*
PRINT DBO.func_GenerateID_NguoiQuanLy()
*/

CREATE PROCEDURE proc_Insert_NguoiQuanLy
	@TenQuanLy nvarchar(150),
	@SoDienThoai varchar(20),
	@DiaChi nvarchar(200),
	@Email nvarchar(100)
AS
	DECLARE @MA CHAR(5)
	SET @MA = DBO.func_GenerateID_NguoiQuanLy()
	INSERT INTO NguoiQuanLy VALUES (@MA, @TenQuanLy, @SoDienThoai, @DiaChi, @Email)
GO

CREATE PROCEDURE proc_Update_NguoiQuanLy
--ALTER PROCEDURE proc_Update_NguoiQuanLy
	@MaQuanLy char(5),
	@TenQuanLy nvarchar(150),
	@SoDienThoai varchar(20),
	@DiaChi nvarchar(200),
	@Email nvarchar(100)
AS
	UPDATE NguoiQuanLy
	SET TenQuanLy = @TenQuanLy, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email
	WHERE MaQuanLy = @MaQuanLy
GO

CREATE PROCEDURE proc_Delete_NguoiQuanLy
	@MaQuanLy char(5)
AS
	DELETE FROM NguoiQuanLy WHERE MaQuanLy = @MaQuanLy
GO

--THÔNG TIN KHÁCH HÀNG
CREATE TABLE KhachHang (
--ALTER TABLE KhachHang (
	--KH0000001
	MaKhachHang char(9) primary key,
	HoVaTen nvarchar(150) not null,
	DiaChi nvarchar(200) not null,
	MaBangGia char(5) references BangGia(MaBangGia),
	MaTram char(5) references TramBienAp(MaTram),
	SoHo tinyint not null default 1,
	HeSoNhan tinyint not null default 1,
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

CREATE PROCEDURE proc_GetAll_KhachHang
--ALTER PROCEDURE proc_GetAll_KhachHang
AS
	SELECT * FROM KhachHang ORDER BY MaKhachHang
GO

CREATE FUNCTION func_GenerateID_KhachHang()
--ALTER FUNCTION func_GenerateID_KhachHang()
RETURNS CHAR(9)
AS
	BEGIN
		DECLARE @ID INT
		DECLARE @MA CHAR(9)
		IF EXISTS (SELECT MaKhachHang FROM KhachHang WHERE MaKhachHang=(SELECT max(MaKhachHang) FROM KhachHang))
			SET @MA = (SELECT MaKhachHang FROM KhachHang WHERE MaKhachHang=(SELECT max(MaKhachHang) FROM KhachHang))
		ELSE
			SET @MA = 'KH0000000';
		SET @ID = CAST (RIGHT(@MA, 7) AS INT) + 1
		SET @MA = 'KH' + RIGHT('0000000' + CAST (@ID AS VARCHAR(7)), 7)
		RETURN @MA
	END
GO

/*
PRINT DBO.func_GenerateID_KhachHang()
*/

CREATE PROCEDURE proc_Insert_KhachHang
	@HoVaTen nvarchar(150),
	@DiaChi nvarchar(200),
	@MaBangGia char(5),
	@MaTram char(5),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao char(5),
	@NgayCapNhat datetime,
	@NguoiCapNhat char(5),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(100)
AS
	DECLARE @MA CHAR(9)
	SET @MA = DBO.func_GenerateID_KhachHang()
	INSERT INTO KhachHang VALUES (@MA, @HoVaTen, @DiaChi, @MaBangGia, @MaTram, @SoHo, @HeSoNhan, @MaSoThue, 
		@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, @MaCongTo, @SoNganHang, @TenNganHang)
GO

CREATE PROCEDURE proc_Update_KhachHang
	@MaKhachHang char(9),
	@HoVaTen nvarchar(150),
	@DiaChi nvarchar(200),
	@MaBangGia char(5),
	@MaTram char(5),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao char(5),
	@NgayCapNhat datetime,
	@NguoiCapNhat char(5),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(100)
AS
	UPDATE KhachHang
	SET
		HoVaTen = @HoVaTen,
		DiaChi = @DiaChi,
		MaBangGia = @MaBangGia,
		MaTram = @MaTram,
		SoHo = @SoHo,
		HeSoNhan = @HeSoNhan,
		MaSoThue = @MaSoThue,
		SoDienThoai = @SoDienThoai,
		Email = @Email,
		NgayTao = @NgayTao,
		NguoiTao = @NguoiTao,
		NgayCapNhat = @NgayCapNhat,
		NguoiCapNhat = @NguoiCapNhat,
		MaSoHopDong = @MaSoHopDong,
		NgayHopDong = @NgayHopDong,
		MaCongTo = @MaCongTo,
		SoNganHang = @SoNganHang,
		TenNganHang = @TenNganHang
	WHERE MaKhachHang = @MaKhachHang
GO

CREATE PROCEDURE proc_Delete_KhachHang
	@MaKhachHang char(9)
AS
	DELETE FROM KhachHang
	WHERE MaKhachHang = @MaKhachHang
GO

CREATE PROCEDURE proc_Insert_KhachHang_Test
	@HoVaTen nvarchar(150),
	@DiaChi nvarchar(200),
	@MaBangGia char(5),
	@MaTram char(5),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao char(5),
	@NgayCapNhat datetime,
	@NguoiCapNhat char(5),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(100),
	@KQ bit OUTPUT
AS
	BEGIN
		DECLARE @MA CHAR(9)
		SET @KQ = 1
		BEGIN TRANSACTION ADDCUSTOMER
			BEGIN TRY
				SET @MA = DBO.func_GenerateID_KhachHang()
				INSERT INTO KhachHang VALUES (@MA, @HoVaTen, @DiaChi, @MaBangGia, @MaTram, @SoHo, @HeSoNhan, @MaSoThue, 
					@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, @MaCongTo, @SoNganHang, @TenNganHang)
			END TRY
			BEGIN CATCH
				SET @KQ = 0
			END CATCH
		ROLLBACK TRANSACTION ADDCUSTOMER
	END
GO

--THÔNG TIN ĐIỆN NĂNG TIÊU THỤ CỦA KHÁCH HÀNG
CREATE TABLE DienNangTieuThu (
	ID int not null identity(1, 1) primary key,
	MaKhachHang char(9) references KhachHang(MaKhachHang) not null,
	NgayGhi datetime not null,
	NguoiGhi char(5) references NguoiQuanLy(MaQuanLy),
	NgayCapNhat datetime not null,
	NguoiCapNhat char(5) references NguoiQuanLy(MaQuanLy),
	ChiSoMoi int,
	ChiSoCu int,
	DaThanhToan bit default 0 not null
)
GO

CREATE PROCEDURE proc_GetAll_DienNangTieuThu
AS
	SELECT * FROM DienNangTieuThu
GO

CREATE PROCEDURE DienNangTieuThu_Insert
-- ALTER PROCEDURE DienNangTieuThu_Insert
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@NgayCapNhat datetime,
	@NguoiCapNhat char(5),
	@ChiSoMoi int,
	@ChiSoCu int,
	@DaThanhToan bit
AS
	INSERT INTO DienNangTieuThu VALUES (@MaKhachHang, @NgayGhi, @NguoiGhi, @NgayCapNhat, @NguoiCapNhat, @ChiSoMoi, @ChiSoCu, @DaThanhToan)
GO

CREATE PROCEDURE proc_Delete_DienNangTieuThu
	@ID INT
AS
	DELETE FROM DienNangTieuThu
	WHERE ID = @ID
GO
