USE MASTER
GO 
CREATE DATABASE QuanLyDienNang
GO 
USE QuanLyDienNang
GO 

--====================BẢNG GIÁ ÁP DỤNG CHO KHÁCH HÀNG====================
CREATE TABLE BangGia (
	--BG001
	MaBangGia char(5) primary key,
	TenBangGia nvarchar(100) not null,
	KichHoat bit default 1 not null
)
GO 
INSERT INTO BangGia VALUES ('BG001', N'Điện sinh hoạt (hộ thường)')
INSERT INTO BangGia VALUES ('BG002', N'Điện sinh hoạt (hộ nghèo)')
INSERT INTO BangGia VALUES ('BG003', N'Điện kinh doanh - dịch vụ')
INSERT INTO BangGia VALUES ('BG004', N'Điện sản xuất')
INSERT INTO BangGia VALUES ('BG005', N'Điện hành chính, sự nghiệp')
INSERT INTO BangGia VALUES ('BG006', N'Điện cho bệnh viện, trường học')
INSERT INTO BangGia VALUES ('BG007', N'Điện cho bơm nước, tưới tiêu')
INSERT INTO BangGia VALUES ('BG008', N'Điện chiếu sáng công cộng')
GO

CREATE PROCEDURE proc_GetAll_BangGia
--ALTER PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia WHERE KichHoat = 1
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
--ALTER PROCEDURE proc_Delete_BangGia
	@MaBangGia char(5)
AS
	UPDATE BangGia
	SET KichHoat = 0
	WHERE MaBangGia = @MaBangGia
GO

--====================CHI TIẾT BẢNG GIÁ ĐIỆN====================
CREATE TABLE ChiTietBangGia
(
	ID int not null identity(1, 1) primary key,
	MaBangGia char(5) references BangGia(MaBangGia),
	BatDau int not null,
	KetThuc int not null,
	GiaTruocVAT int not null,
	VAT float not null,
	GiaSauVAT int null,
	MoTa nvarchar(200) null,
	KichHoat bit default 1 not null
)
GO

EXEC proc_Insert_ChiTietBangGia 'BG001', 0, 50, 1678, 0.1, N'Bậc 1: Cho kWh từ 0 - 50'
EXEC proc_Insert_ChiTietBangGia 'BG001', 51, 100, 1734, 0.1, N'Bậc 2: Cho kWh từ 51 - 100'
EXEC proc_Insert_ChiTietBangGia 'BG001', 101, 200, 2014, 0.1, N'Bậc 3: Cho kWh từ 101 - 200'
EXEC proc_Insert_ChiTietBangGia 'BG001', 201, 300, 2536, 0.1, N'Bậc 4: Cho kWh từ 201 - 300'
EXEC proc_Insert_ChiTietBangGia 'BG001', 301, 400, 2834, 0.1, N'Bậc 5: Cho kWh từ 301 - 400'
EXEC proc_Insert_ChiTietBangGia 'BG001', 401, 0, 2927, 0.1, N'Bậc 6: Cho kWh từ 401 trở lên'
GO

CREATE TRIGGER trg_CapNhatChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
--ALTER TRIGGER trg_CapNhatChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
AS
	IF UPDATE(GiaTruocVAT) or UPDATE(VAT)
		BEGIN
			DECLARE @GiaTruocVAT INT
			DECLARE @GiaSauVAT INT
			DECLARE @VAT FLOAT
			SET @GiaTruocVAT = (SELECT GiaTruocVAT FROM inserted)
			SET @VAT = (SELECT VAT FROM inserted)
			SET @GIASAUVAT = ROUND(@GiaTruocVAT + @GiaTruocVAT * @VAT, 0)
			UPDATE ChiTietBangGia
			SET GiaSauVAT = @GiaSauVAT
			WHERE ID = (SELECT ID FROM inserted)
		END
GO

CREATE PROCEDURE proc_GetAll_ChiTietBangGia
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia WHERE KichHoat = 1
GO

CREATE PROCEDURE proc_Insert_ChiTietBangGia
	@MaBangGia char(5),
	@BatDau int,
	@KetThuc int,
	@GiaTruocVAT int,
	@VAT float,
	@MoTa nvarchar(200)
AS
	INSERT INTO ChiTietBangGia (MaBangGia, BatDau, KetThuc, GiaTruocVAT, VAT, MoTa) VALUES (@MaBangGia, @BatDau, @KetThuc, @GiaTruocVAT, @VAT, @MoTa)
GO

CREATE PROCEDURE proc_Update_ChiTietBangGia
	@ID int,
	@MaBangGia char(5),
	@BatDau int,
	@KetThuc int,
	@GiaTruocVAT int,
	@VAT float,
	@MoTa nvarchar(200)
AS
	UPDATE ChiTietBangGia
	SET MaBangGia = @MaBangGia, BatDau = @BatDau, KetThuc = @KetThuc, GiaTruocVAT = @GiaTruocVAT, VAT = @VAT
	WHERE ID = @ID
GO

CREATE PROCEDURE proc_Delete_ChiTietBangGia
--ALTER PROCEDURE proc_Delete_ChiTietBangGia
	@ID int
AS
	UPDATE ChiTietBangGia
	SET KichHoat = 0
	WHERE ID = @ID
GO

CREATE PROCEDURE proc_Reset_ChiTietBangGia
AS
	DELETE FROM ChiTietBangGia
	DBCC CHECKIDENT ('[ChiTietBangGia]', RESEED, 0);
GO

--EXEC proc_Reset_ChiTietBangGia

--====================TRẠM BIẾN ÁP ÁP DỤNG CHO KHÁCH HÀNG====================
CREATE TABLE TramBienAp (
--ALTER TABLE TramBienAp (
	--BA001
	MaTram char(5) primary key,
	TenTram nvarchar(100) not null,
	DiaChi nvarchar(200) null,
	NguoiPhuTrach nvarchar(100) null,
	MaSoCongTo nvarchar(20) null,
	HeSoNhan tinyint default 1 not null,
	KichHoat bit default 1 not null
)
GO 

INSERT INTO TramBienAp VALUES ('BA001', N'Trạm biến áp 1')
INSERT INTO TramBienAp VALUES ('BA002', N'Trạm biến áp 2')
INSERT INTO TramBienAp VALUES ('BA003', N'Trạm biến áp 3')
GO

CREATE PROCEDURE proc_GetAll_TramBienAp
--ALTER PROCEDURE proc_GetAll_TramBienAp
AS
	SELECT * FROM TramBienAp WHERE KichHoat = 1
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
--ALTER PROCEDURE proc_Delete_TramBienAp
	@MaTram char(5)
AS
	UPDATE TramBienAp
	SET KichHoat = 0
	WHERE MaTram = @MaTram
GO

--====================NGƯỜI QUẢN LÝ KHÁCH HÀNG====================
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
		IF EXISTS (SELECT * FROM NguoiQuanLy WHERE MaQuanLy = (SELECT max(MaQuanLy) FROM NguoiQuanLy))
			SET @MA = (SELECT max(MaQuanLy) FROM NguoiQuanLy)
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

--====================THÔNG TIN KHÁCH HÀNG====================
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
	TenNganHang nvarchar(100) null,
	KichHoat bit default 1 not null
)
GO 

--DELETE FROM KHACHHANG

CREATE PROCEDURE proc_GetAll_KhachHang
--ALTER PROCEDURE proc_GetAll_KhachHang
AS
	SELECT * FROM KhachHang WHERE KichHoat = 0 ORDER BY MaKhachHang
GO

CREATE FUNCTION func_GenerateID_KhachHang()
--ALTER FUNCTION func_GenerateID_KhachHang()
RETURNS CHAR(9)
AS
	BEGIN
		DECLARE @ID INT
		DECLARE @MA CHAR(9)
		IF EXISTS (SELECT * FROM KhachHang WHERE MaKhachHang = (SELECT max(MaKhachHang) FROM KhachHang))
			SET @MA = (SELECT max(MaKhachHang) FROM KhachHang)
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
--ALTER PROCEDURE proc_Delete_KhachHang
	@MaKhachHang char(9)
AS
	UPDATE KhachHang
	SET KichHoat = 0
	WHERE MaKhachHang = @MaKhachHang
GO

CREATE PROCEDURE proc_Insert_KhachHang_Test
--ALTER PROCEDURE proc_Insert_KhachHang_Test
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
	BEGIN
		DECLARE @MA CHAR(9)
		DECLARE @KQ BIT
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
		RETURN @KQ
	END
GO

CREATE PROCEDURE proc_Update_KhachHang_Test
--ALTER PROCEDURE proc_Update_KhachHang_Test
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
	BEGIN
		DECLARE @KQ BIT
		SET @KQ = 1
		BEGIN TRANSACTION UPDATECUSTOMER
			BEGIN TRY
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
			END TRY
			BEGIN CATCH
				SET @KQ = 0
			END CATCH
		ROLLBACK TRANSACTION UPDATECUSTOMER
		RETURN @KQ
	END
GO

--====================THÔNG TIN ĐIỆN NĂNG TIÊU THỤ CỦA KHÁCH HÀNG====================
--DROP TABLE DienNangTieuThu
CREATE TABLE DienNangTieuThu (
--ALTER TABLE DienNangTieuThu (
	ID int not null identity(1, 1) primary key,
	MaKhachHang char(9) references KhachHang(MaKhachHang) not null,
	NgayGhi datetime null,
	NguoiGhi char(5) references NguoiQuanLy(MaQuanLy),
	ChuKyThang tinyint null,
	NgayCapNhat datetime null,
	NguoiCapNhat char(5) references NguoiQuanLy(MaQuanLy),
	NgayHoaDon datetime null,
	NgayTraTien datetime null,
	ChiSoMoi int default 0 null,
	ChiSoCu int default 0 null,
	TongTienTruocVAT money null,
	TongTienSauVAT money null,
	DaTra money default 0 null,
	ConLai money null,
)
GO

CREATE PROCEDURE proc_GetAll_DienNangTieuThu
AS
	SELECT * FROM DienNangTieuThu
GO

CREATE PROCEDURE DienNangTieuThu_Insert
--ALTER PROCEDURE DienNangTieuThu_Insert
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@ChuKyThang tinyint,
	@NgayCapNhat datetime,
	@NguoiCapNhat char(5),
	@NgayHoaDon datetime,
	@NgayTraTien datetime,
	@ChiSoMoi int,
	@ChiSoCu int,
	@TongTienTruocVAT money,
	@TongTienSauVAT money,
	@DaTra money,
	@ConLai money
AS
	INSERT INTO DienNangTieuThu VALUES (@MaKhachHang, @NgayGhi, @NguoiGhi, @ChuKyThang, @NgayCapNhat, @NguoiCapNhat, @NgayHoaDon, @NgayTraTien, @ChiSoMoi, @ChiSoCu, @TongTienTruocVAT, @TongTienSauVAT, @DaTra, @ConLai)
GO

CREATE PROCEDURE proc_Delete_DienNangTieuThu
	@ID INT
AS
	DELETE FROM DienNangTieuThu
	WHERE ID = @ID
GO

CREATE PROCEDURE proc_Reset_DienNangTieuThu
AS
	DELETE FROM DienNangTieuThu
	DBCC CHECKIDENT ('[DienNangTieuThu]', RESEED, 0);
GO

CREATE PROCEDURE proc_Update_DienNangTieuThu
	@ID int,
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@ChuKyThang tinyint,
	@NgayCapNhat datetime,
	@NguoiCapNhat char(5),
	@NgayHoaDon datetime,
	@NgayTraTien datetime,
	@ChiSoMoi int,
	@ChiSoCu int,
	@TongTienTruocVAT money,
	@TongTienSauVAT money,
	@DaTra money,
	@ConLai money
AS
	UPDATE DienNangTieuThu
	SET
		MaKhachHang = @MaKhachHang,
		NgayGhi = @NgayGhi,
		NguoiGhi = @NguoiGhi,
		ChuKyThang = @ChuKyThang,
		NgayCapNhat = @NgayCapNhat,
		NguoiCapNhat = @NguoiCapNhat,
		NgayHoaDon = @NgayHoaDon,
		NgayTraTien = @NgayTraTien,
		ChiSoMoi = @ChiSoMoi,
		ChiSoCu = @ChiSoCu,
		TongTienTruocVAT = @TongTienTruocVAT,
		TongTienSauVAT = @TongTienSauVAT,
		DaTra = @DaTra,
		ConLai = @ConLai
	Where ID = @ID
GO