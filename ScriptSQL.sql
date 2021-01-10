USE MASTER
GO 
CREATE DATABASE QuanLyDienNang
GO 
USE QuanLyDienNang
GO 

--====================BẢNG GIÁ ÁP DỤNG CHO KHÁCH HÀNG====================
--DROP TABLE BangGia
CREATE TABLE BangGia (
	--BG001
	MaBangGia varchar(10) primary key,
	TenBangGia nvarchar(100) not null,
	Thue float default 0.1 not null,
	KichHoat bit default 1 not null
)
GO

-- MÃ BẢNG GIÁ TỰ ĐỊNH NGHĨA
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('SH-THUONG', N'Điện sinh hoạt (hộ thường)')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('SH-NGHEO', N'Điện sinh hoạt (hộ nghèo)')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('KD-DV', N'Điện kinh doanh - dịch vụ')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('SX', N'Điện sản xuất')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('HC-SN', N'Điện hành chính, sự nghiệp')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('BV-TH', N'Điện cho bệnh viện, trường học')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('BN-TT', N'Điện cho bơm nước, tưới tiêu')
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('CHIEUSANG', N'Điện chiếu sáng công cộng')
GO

CREATE PROCEDURE proc_GetAll_BangGia
--ALTER PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia ORDER BY KichHoat DESC, MaBangGia ASC
GO

CREATE PROCEDURE proc_IsDuplicated_MaBangGia
	@MaBangGia varchar(10)
AS
	IF EXISTS (SELECT * FROM BangGia WHERE MaBangGia = @MaBangGia)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_BangGia
--ALTER PROCEDURE proc_Insert_BangGia
	@MaBangGia varchar(10),
	@TenBangGia nvarchar(100),
	@Thue float
AS
	INSERT INTO BangGia (MaBangGia, TenBangGia, Thue) VALUES (@MaBangGia, @TenBangGia, @Thue)
GO

CREATE PROCEDURE proc_Update_BangGia
--ALTER PROCEDURE proc_Update_BangGia
	@MaBangGia varchar(10),
	@TenBangGia nvarchar(100),
	@Thue float,
	@KichHoat bit
AS
	UPDATE BangGia
	SET TenBangGia = @TenBangGia, KichHoat = @KichHoat, Thue = @Thue
	WHERE MaBangGia = @MaBangGia
GO

CREATE PROCEDURE proc_Delete_BangGia
--ALTER PROCEDURE proc_Delete_BangGia
	@MaBangGia varchar(10)
AS
	UPDATE BangGia
	SET KichHoat = 0
	WHERE MaBangGia = @MaBangGia
GO

--EXEC proc_Delete_BangGia 'SH-NGHEO'

--====================CHI TIẾT BẢNG GIÁ ĐIỆN====================
CREATE TABLE ChiTietBangGia
(
	ID int not null identity(1, 1) primary key,
	MaBangGia varchar(10) references BangGia(MaBangGia),
	BatDau int not null,
	KetThuc int not null,
	DonGia int not null,
	MoTa nvarchar(200) null,
	KichHoat bit default 1 not null
)
GO

--CREATE TRIGGER trg_CapNhatChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
----ALTER TRIGGER trg_CapNhatChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
--AS
--	IF UPDATE(GiaTruocVAT) or UPDATE(VAT)
--		BEGIN
--			DECLARE @GiaTruocVAT INT
--			DECLARE @GiaSauVAT INT
--			DECLARE @VAT FLOAT
--			SET @GiaTruocVAT = (SELECT GiaTruocVAT FROM inserted)
--			SET @VAT = (SELECT VAT FROM inserted)
--			SET @GIASAUVAT = ROUND(@GiaTruocVAT + @GiaTruocVAT * @VAT, 0)
--			UPDATE ChiTietBangGia
--			SET GiaSauVAT = @GiaSauVAT
--			WHERE ID = (SELECT ID FROM inserted)
--		END
--GO

CREATE PROCEDURE proc_GetAll_ChiTietBangGia
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia ORDER BY KichHoat DESC, ID ASC
GO

CREATE PROCEDURE proc_GetByBangGia_ChiTietBangGia
	@MaBangGia varchar(10)
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = @MaBangGia ORDER BY KichHoat DESC, ID ASC
GO

CREATE PROCEDURE proc_Insert_ChiTietBangGia
--ALTER PROCEDURE proc_Insert_ChiTietBangGia
	@MaBangGia varchar(10),
	@BatDau int,
	@KetThuc int,
	@DonGia int,
	@MoTa nvarchar(200)
AS
	INSERT INTO ChiTietBangGia (MaBangGia, BatDau, KetThuc, DonGia, MoTa) VALUES (@MaBangGia, @BatDau, @KetThuc, @DonGia, @MoTa)
GO

EXEC proc_Insert_ChiTietBangGia 'SH-THUONG', 0, 50, 1678, N'Bậc 1: Cho kWh từ 0 - 50'
EXEC proc_Insert_ChiTietBangGia 'SH-THUONG', 51, 100, 1734, N'Bậc 2: Cho kWh từ 51 - 100'
EXEC proc_Insert_ChiTietBangGia 'SH-THUONG', 101, 200, 2014, N'Bậc 3: Cho kWh từ 101 - 200'
EXEC proc_Insert_ChiTietBangGia 'SH-THUONG', 201, 300, 2536, N'Bậc 4: Cho kWh từ 201 - 300'
EXEC proc_Insert_ChiTietBangGia 'SH-THUONG', 301, 400, 2834, N'Bậc 5: Cho kWh từ 301 - 400'
EXEC proc_Insert_ChiTietBangGia 'SH-THUONG', 401, 0, 2927, N'Bậc 6: Cho kWh từ 401 trở lên'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 970, N'Cấp điện áp 110kV trở lên: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1555, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1007, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 2871, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1611, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1044, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 2964, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1685, N'Cấp điện áp dưới 6kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 1100, N'Cấp điện áp dưới 6kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX', 0, 0, 3076, N'Cấp điện áp dưới 6kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'HC-SN', 0, 0, 1659, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp từ 6kV trở lên'
EXEC proc_Insert_ChiTietBangGia 'HC-SN', 0, 0, 1771, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp dưới 6kV'
EXEC proc_Insert_ChiTietBangGia 'HC-SN', 0, 0, 1827, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp từ 6kV trở lên'
EXEC proc_Insert_ChiTietBangGia 'HC-SN', 0, 0, 1902, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp dưới 6kV'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 2442, N'Cấp điện áp từ 22kV trở lên: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 1361, N'Cấp điện áp từ 22kV trở lên: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 4251, N'Cấp điện áp từ 22kV trở lên: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 2629, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 1547, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 4400, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 2666, N'Cấp điện áp dưới 6kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 1622, N'Cấp điện áp dưới 6kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'KD-DV', 0, 0, 4587, N'Cấp điện áp dưới 6kV: Giờ cao điểm'
GO

CREATE PROCEDURE proc_Update_ChiTietBangGia
	@ID int,
	@MaBangGia char(5),
	@BatDau int,
	@KetThuc int,
	@DonGia int,
	@MoTa nvarchar(200),
	@KichHoat bit
AS
	UPDATE ChiTietBangGia
	SET MaBangGia = @MaBangGia, BatDau = @BatDau, KetThuc = @KetThuc, DonGia = @DonGia, MoTa = @MoTa, KichHoat = @KichHoat
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
	MaTram varchar(10) primary key,
	TenTram nvarchar(100) not null,
	DiaChi nvarchar(200) null,
	NguoiPhuTrach nvarchar(100) null,
	MaSoCongTo nvarchar(20) null,
	HeSoNhan tinyint default 1 not null,
	KichHoat bit default 1 not null
)
GO 

INSERT INTO TramBienAp (MaTram, TenTram) VALUES ('BA001', N'Trạm biến áp 1')
INSERT INTO TramBienAp (MaTram, TenTram) VALUES ('BA002', N'Trạm biến áp 2')
INSERT INTO TramBienAp (MaTram, TenTram) VALUES ('BA003', N'Trạm biến áp 3')
GO

CREATE PROCEDURE proc_GetAll_TramBienAp
--ALTER PROCEDURE proc_GetAll_TramBienAp
AS
	SELECT * FROM TramBienAp WHERE KichHoat = 1
GO

CREATE PROCEDURE proc_IsDuplicated_MaTram
	@MaTram varchar(10)
AS
	IF EXISTS (SELECT * FROM TramBienAp WHERE MaTram = @MaTram)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_TramBienAp
	@MaTram char(5),
	@TenTram nvarchar(100),
	@DiaChi nvarchar(200),
	@NguoiPhuTrach nvarchar(100),
	@MaSoCongTo nvarchar(20),
	@HeSoNhan tinyint
AS
	INSERT INTO TramBienAp (MaTram, TenTram, DiaChi, NguoiPhuTrach, MaSoCongTo, HeSoNhan) VALUES (@MaTram, @TenTram, @DiaChi, @NguoiPhuTrach, @MaSoCongTo, @HeSoNhan)
GO

CREATE PROCEDURE proc_Update_TramBienAp
	@MaTram char(5),
	@TenTram nvarchar(100),
	@DiaChi nvarchar(200),
	@NguoiPhuTrach nvarchar(100),
	@MaSoCongTo nvarchar(20),
	@HeSoNhan tinyint,
	@KichHoat bit
AS
	UPDATE TramBienAp
	SET TenTram = @TenTram, DiaChi = @DiaChi, NguoiPhuTrach = @NguoiPhuTrach, MaSoCongTo = @MaSoCongTo, HeSoNhan = @HeSoNhan, KichHoat = @KichHoat
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
	SELECT * FROM KhachHang WHERE KichHoat = 1 ORDER BY MaKhachHang
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
--ALTER PROCEDURE proc_Insert_KhachHang
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
		@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, @MaCongTo, @SoNganHang, @TenNganHang, 1)
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
					@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, @MaCongTo, @SoNganHang, @TenNganHang, 1)
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
	NgayBatDau datetime null,
	NgayKetThuc datetime null,
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
--ALTER PROCEDURE proc_GetAll_DienNangTieuThu
AS
	SELECT * FROM View_DienNangTieuThu
GO

CREATE PROCEDURE proc_GetByDate_DienNangTieuThu
--ALTER PROCEDURE proc_GetByDate_DienNangTieuThu
	@MONTH TINYINT,
	@YEAR INT
AS
	SELECT * FROM View_DienNangTieuThu WHERE MONTH(NgayKetThuc) = @MONTH AND YEAR(NgayKetThuc) = @YEAR
GO

CREATE PROCEDURE proc_Insert_DienNangTieuThu
--ALTER PROCEDURE proc_Insert_DienNangTieuThu
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
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
	INSERT INTO DienNangTieuThu VALUES (@MaKhachHang, @NgayGhi, @NguoiGhi, @NgayBatDau, @NgayKetThuc, @NgayCapNhat, @NguoiCapNhat, @NgayHoaDon, @NgayTraTien, @ChiSoMoi, @ChiSoCu, @TongTienTruocVAT, @TongTienSauVAT, @DaTra, @ConLai)
GO

CREATE PROCEDURE proc_Insert_DienNangTieuThu_Test
--ALTER PROCEDURE proc_Insert_DienNangTieuThu_Test
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
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
	BEGIN
		DECLARE @KQ BIT
		DECLARE @MAX_ID INT
		SET @KQ = 1
		SET @MAX_ID = IDENT_CURRENT('[DienNangTieuThu]')
		BEGIN TRANSACTION ADDDNTT
			BEGIN TRY
				INSERT INTO DienNangTieuThu VALUES (@MaKhachHang, @NgayGhi, @NguoiGhi, @NgayBatDau, @NgayKetThuc, @NgayCapNhat, @NguoiCapNhat, @NgayHoaDon, @NgayTraTien, @ChiSoMoi, @ChiSoCu, @TongTienTruocVAT, @TongTienSauVAT, @DaTra, @ConLai)
			END TRY
			BEGIN CATCH
				SET @KQ = 0
			END CATCH
		ROLLBACK TRANSACTION ADDDNTT
		DBCC CHECKIDENT ('[DienNangTieuThu]', RESEED, @MAX_ID)
		RETURN @KQ
	END
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

--EXEC proc_Reset_DienNangTieuThu

CREATE PROCEDURE proc_Update_DienNangTieuThu
--ALTER PROCEDURE proc_Update_DienNangTieuThu
	@ID int,
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
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
		NgayBatDau = @NgayBatDau,
		NgayKetThuc = @NgayKetThuc,
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
	WHERE ID = @ID
GO

CREATE PROCEDURE proc_Update_DienNangTieuThu_Test
--ALTER PROCEDURE proc_Update_DienNangTieuThu_Test
	@ID int,
	@MaKhachHang char(9),
	@NgayGhi datetime,
	@NguoiGhi char(5),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
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
	BEGIN
		DECLARE @KQ BIT
		SET @KQ = 1
		BEGIN TRANSACTION UPDATEDNTT
			BEGIN TRY
				UPDATE DienNangTieuThu
				SET
					MaKhachHang = @MaKhachHang,
					NgayGhi = @NgayGhi,
					NguoiGhi = @NguoiGhi,
					NgayBatDau = @NgayBatDau,
					NgayKetThuc = @NgayKetThuc,
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
				WHERE ID = @ID
			END TRY
			BEGIN CATCH
				SET @KQ = 0
			END CATCH
		ROLLBACK TRANSACTION UPDATEDNTT
		RETURN @KQ
	END
GO

CREATE VIEW View_DienNangTieuThu
--ALTER VIEW View_DienNangTieuThu
AS
	SELECT ID, D.MaKhachHang, HoVaTen, DiaChi, MaTram, MaBangGia, NgayGhi, NguoiGhi, NgayBatDau, NgayKetThuc, D.NgayCapNhat, D.NguoiCapNhat, NgayHoaDon, NgayTraTien, ChiSoMoi, ChiSoCu, TongTienTruocVAT, TongTienSauVAT, DaTra, ConLai
	FROM DienNangTieuThu D, KhachHang K
	WHERE D.MaKhachHang = K.MaKhachHang
GO
