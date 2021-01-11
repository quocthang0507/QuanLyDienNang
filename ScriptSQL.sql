USE MASTER
GO
--DROP DATABASE QuanLyDienNang
CREATE DATABASE QuanLyDienNang
GO
USE QuanLyDienNang
GO

--====================BẢNG GIÁ ÁP DỤNG CHO KHÁCH HÀNG====================
--DROP TABLE BangGia
CREATE TABLE BangGia (
	--BG001
	MaBangGia varchar(20) primary key,
	TenBangGia nvarchar(150) not null,
	Thue decimal(3,2) default 0.1 not null,
	KichHoat bit default 1 not null
)
GO

CREATE TRIGGER trigger_BangGia ON BangGia FOR INSERT, UPDATE
AS
	IF UPDATE(Thue)
		IF EXISTS (SELECT * FROM inserted WHERE Thue > 1 OR Thue < 0)
		BEGIN
			RAISERROR (N'Thuế GTGT (VAT) trên một bảng giá không được quá 1 hoặc nhỏ hơn 0', 15, 1)
			ROLLBACK TRAN
		END
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
INSERT INTO BangGia (MaBangGia, TenBangGia) VALUES ('APGIA', N'Bảng điện áp giá phần trăm')
GO

CREATE PROCEDURE proc_GetAll_BangGia
--ALTER PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia ORDER BY KichHoat DESC, MaBangGia ASC
GO

CREATE PROCEDURE proc_IsDuplicated_MaBangGia
--ALTER PROCEDURE proc_IsDuplicated_MaBangGia
	@MaBangGia varchar(20)
AS
	IF EXISTS (SELECT * FROM BangGia WHERE MaBangGia = @MaBangGia)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_BangGia
--ALTER PROCEDURE proc_Insert_BangGia
	@MaBangGia varchar(20),
	@TenBangGia nvarchar(150),
	@Thue decimal(3,2)
AS
	INSERT INTO BangGia (MaBangGia, TenBangGia, Thue) VALUES (@MaBangGia, @TenBangGia, @Thue)
GO

CREATE PROCEDURE proc_Update_BangGia
--ALTER PROCEDURE proc_Update_BangGia
	@MaBangGia varchar(20),
	@TenBangGia nvarchar(150),
	@Thue decimal(3,2),
	@KichHoat bit
AS
	UPDATE BangGia
	SET TenBangGia = @TenBangGia, KichHoat = @KichHoat, Thue = @Thue
	WHERE MaBangGia = @MaBangGia
GO

CREATE PROCEDURE proc_Delete_BangGia
--ALTER PROCEDURE proc_Delete_BangGia
	@MaBangGia varchar(20)
AS
	UPDATE BangGia
	SET KichHoat = 0
	WHERE MaBangGia = @MaBangGia
GO

--EXEC proc_Delete_BangGia 'SH-NGHEO'

--====================CHI TIẾT BẢNG GIÁ ĐIỆN====================
--DROP TABLE ChiTietBangGia
CREATE TABLE ChiTietBangGia
(
	MaChiTiet varchar(30) primary key,
	MaBangGia varchar(20) references BangGia(MaBangGia),
	BatDau int DEFAULT 0 not null,
	KetThuc int DEFAULT 0 not null,
	DonGia int not null,
	MoTa nvarchar(250) null,
	ApGia bit default 0 not null,
	KichHoat bit default 1 not null
)
GO

CREATE TRIGGER trigger_ChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
--ALTER TRIGGER trigger_ChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
AS
	IF UPDATE(BatDau) OR UPDATE(KetThuc) OR UPDATE(DonGia)
		BEGIN
			IF EXISTS (SELECT * FROM inserted WHERE KetThuc < BatDau AND KetThuc != 0) --Nếu kết thúc bằng 0 nghĩa là kéo dài vô tận!
				BEGIN
					RAISERROR (N'Trong phạm vi áp dụng bảng giá, vị trí kết thúc không được nhỏ hơn vị trí bắt đầu', 15, 1)
					ROLLBACK TRAN
				END
			IF EXISTS (SELECT * FROM inserted WHERE DonGia < 0)
				BEGIN
					RAISERROR (N'Đơn giá không được âm', 15, 1)
					ROLLBACK TRAN
				END
		END
GO

CREATE PROCEDURE proc_GetAll_ChiTietBangGia
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia ORDER BY KichHoat DESC, ApGia ASC, MaChiTiet ASC
GO

CREATE PROCEDURE proc_GetByBangGia_ChiTietBangGia
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
	@MaBangGia varchar(20)
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = @MaBangGia ORDER BY KichHoat DESC, MaChiTiet ASC
GO

CREATE PROCEDURE proc_Insert_ChiTietBangGia
--ALTER PROCEDURE proc_Insert_ChiTietBangGia
	@MaChiTiet varchar(30),
	@MaBangGia varchar(20),
	@BatDau int,
	@KetThuc int,
	@DonGia int,
	@MoTa nvarchar(250),
	@ApGia bit
AS
	INSERT INTO ChiTietBangGia (MaChiTiet, MaBangGia, BatDau, KetThuc, DonGia, MoTa, ApGia) VALUES (@MaChiTiet, @MaBangGia, @BatDau, @KetThuc, @DonGia, @MoTa, @ApGia)
GO

--DELETE FROM ChiTietBangGia

EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC1', 'SH-THUONG', 0, 50, 1678, N'Bậc 1: Cho kWh từ 0 - 50', 0
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC2', 'SH-THUONG', 51, 100, 1734, N'Bậc 2: Cho kWh từ 51 - 100', 0
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC3', 'SH-THUONG', 101, 200, 2014, N'Bậc 3: Cho kWh từ 101 - 200', 0
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC4', 'SH-THUONG', 201, 300, 2536, N'Bậc 4: Cho kWh từ 201 - 300', 0
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC5', 'SH-THUONG', 301, 400, 2834, N'Bậc 5: Cho kWh từ 301 - 400', 0
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC6', 'SH-THUONG', 401, 0, 2927, N'Bậc 6: Cho kWh từ 401 trở lên', 0
EXEC proc_Insert_ChiTietBangGia 'SX-TREN110KV-GBT', 'SX', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'SX-TREN110KV-GTH', 'SX', 0, 0, 970, N'Cấp điện áp 110kV trở lên: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-TREN110KV-GCD', 'SX', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-22KV-110KV-GBT', 'SX', 0, 0, 1555, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'SX-22KV-110KV-GTD', 'SX', 0, 0, 1007, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-22KV-110KV-GCD', 'SX', 0, 0, 2871, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-6KV-22KV-GBT', 'SX', 0, 0, 1611, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'SX-6KV-22KV-GTD', 'SX', 0, 0, 1044, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-6KV-22KV-GCD', 'SX', 0, 0, 2964, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-DUOI6KV-GBT', 'SX', 0, 0, 1685, N'Cấp điện áp dưới 6kV: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'SX-DUOI6KV-GTD', 'SX', 0, 0, 1100, N'Cấp điện áp dưới 6kV: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'SX-DUOI6KV-GCD', 'SX', 0, 0, 3076, N'Cấp điện áp dưới 6kV: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia 'HCSN-TH-TREN6KV', 'HC-SN', 0, 0, 1659, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp từ 6kV trở lên', 0
EXEC proc_Insert_ChiTietBangGia 'HCSN-TH-DUOI6KV', 'HC-SN', 0, 0, 1771, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp dưới 6kV', 0
EXEC proc_Insert_ChiTietBangGia 'HCSN-CS-TREN6KV', 'HC-SN', 0, 0, 1827, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp từ 6kV trở lên', 0
EXEC proc_Insert_ChiTietBangGia 'HCSN-CS-DUOI6KV', 'HC-SN', 0, 0, 1902, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp dưới 6kV', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-TREN22KV-GBT', 'KD-DV', 0, 0, 2442, N'Cấp điện áp từ 22kV trở lên: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-TREN22KV-GTD', 'KD-DV', 0, 0, 1361, N'Cấp điện áp từ 22kV trở lên: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-TREN22KV-GCD', 'KD-DV', 0, 0, 4251, N'Cấp điện áp từ 22kV trở lên: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-6KV-22KV-GBT', 'KD-DV', 0, 0, 2629, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-6KV-22KV-GTD', 'KD-DV', 0, 0, 1547, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-6KV-22KV-GCD', 'KD-DV', 0, 0, 4400, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-DUOI6KV-GBT', 'KD-DV', 0, 0, 2666, N'Cấp điện áp dưới 6kV: Giờ bình thường', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-DUOI6KV-GTD', 'KD-DV', 0, 0, 1622, N'Cấp điện áp dưới 6kV: Giờ thấp điểm', 0
EXEC proc_Insert_ChiTietBangGia 'KDDV-DUOI6KV-GCD', 'KD-DV', 0, 0, 4587, N'Cấp điện áp dưới 6kV: Giờ cao điểm', 0
EXEC proc_Insert_ChiTietBangGia '10SX-50SH-40KD', 'APGIA', 0, 0, 0, N'10% Sản xuất, 50% Sinh hoạt, 40% Kinh doanh', 1
EXEC proc_Insert_ChiTietBangGia '50%BN-10KD-30SX-10SH', 'APGIA', 0, 0, 0, N'50% Bơm nước, 10% Kinh doanh, 30% Sản xuất, 10% Sinh hoạt', 1
GO

CREATE PROCEDURE proc_Update_ChiTietBangGia
--ALTER PROCEDURE proc_Update_ChiTietBangGia
	@MaChiTiet varchar(30),
	@MaBangGia varchar(20),
	@BatDau int,
	@KetThuc int,
	@DonGia int,
	@MoTa nvarchar(200),
	@ApGia bit,
	@KichHoat bit
AS
	UPDATE ChiTietBangGia
	SET MaBangGia = @MaBangGia, BatDau = @BatDau, KetThuc = @KetThuc, DonGia = @DonGia, MoTa = @MoTa, KichHoat = @KichHoat, ApGia = @ApGia
	WHERE MaChiTiet = @MaChiTiet
GO

CREATE PROCEDURE proc_Delete_ChiTietBangGia
--ALTER PROCEDURE proc_Delete_ChiTietBangGia
	@MaChiTiet varchar(30)
AS
	UPDATE ChiTietBangGia
	SET KichHoat = 0
	WHERE MaChiTiet = @MaChiTiet
GO

--====================BẢNG ĐIỆN ÁP GIÁ====================
--DROP TABLE BangDienApGia
CREATE TABLE BangDienApGia
(
	MaChiTiet varchar(30) not null references ChiTietBangGia(MaChiTiet),
	MaBangGia varchar(20) not null references BangGia(MaBangGia),
	TyLe decimal(3,2) not null default 0.0,
	KichHoat bit default 1,
	Constraint PK_BangDienApGia primary key (MaChiTiet, MaBangGia)
)
GO

--DELETE FROM BangDienApGia

CREATE PROCEDURE proc_CreateNew_BangDienApGia
--ALTER PROCEDURE proc_CreateNew_BangDienApGia
	@MaChiTiet varchar(30)
AS
	IF NOT EXISTS (SELECT * FROM BangDienApGia WHERE MaChiTiet = @MaChiTiet)
	BEGIN
		DECLARE @MaBangGia varchar(20)
		DECLARE csrBangGia CURSOR FOR SELECT MaBangGia FROM BangGia
		OPEN csrBangGia
		FETCH NEXT FROM csrBangGia INTO @MaBangGia
		WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO BangDienApGia (MaChiTiet, MaBangGia) VALUES (@MaChiTiet, @MaBangGia)
			FETCH NEXT FROM csrBangGia INTO @MaBangGia
		END
		CLOSE csrBangGia
		DEALLOCATE csrBangGia
	END
GO

CREATE VIEW view_BangDienApGia
AS
	SELECT BG.MaBangGia, CT.MaChiTiet, TenBangGia, TyLe, AG.KichHoat FROM BangGia BG, ChiTietBangGia CT, BangDienApGia AG WHERE BG.MaBangGia = AG.MaBangGia AND CT.MaChiTiet = AG.MaChiTiet
GO

CREATE PROCEDURE proc_GetAll_BangDienApGia
	@MaChiTiet varchar(30)
AS
	SELECT * FROM view_BangDienApGia WHERE MaChiTiet = @MaChiTiet
GO

CREATE PROCEDURE proc_Update_BangDienApGia
--ALTER PROCEDURE proc_Update_BangDienApGia
	@MaChiTiet varchar(30),
	@MaBangGia varchar(20),
	@TyLe decimal(3,2),
	@KichHoat bit
AS
	UPDATE BangDienApGia
	SET TyLe = @TyLe, KichHoat = @KichHoat
	WHERE MaChiTiet = @MaChiTiet AND MaBangGia = @MaBangGia
GO

--EXEC proc_Update_BangDienApGia '10SX-50SH-40KD', 'SX', 0.1, 1

CREATE TRIGGER trigger_BangDienApGia ON BangDienApGia FOR INSERT, UPDATE
--ALTER TRIGGER trigger_BangDienApGia ON BangDienApGia FOR INSERT, UPDATE
AS
	IF UPDATE(TyLe)
		BEGIN
			DECLARE @MaChiTiet varchar(30)
			DECLARE @TyLe decimal(3,2)
			SET @MaChiTiet = (SELECT MaChiTiet FROM inserted)
			SET @TyLe = (SELECT SUM(TyLe) FROM BangDienApGia WHERE MaChiTiet = @MaChiTiet)
			IF @TyLe > 1.00 OR @TyLe < 0.00
				BEGIN
					RAISERROR (N'Tổng tỷ lệ phần trăm trên một bảng giá áp giá không được quá 1 hoặc nhỏ hơn 0', 15, 1)
					ROLLBACK TRAN
				END
		END
GO

--====================TRẠM BIẾN ÁP ÁP DỤNG CHO KHÁCH HÀNG====================
--DROP TABLE TramBienAp
CREATE TABLE TramBienAp (
	--BA001
	MaTram varchar(20) primary key,
	TenTram nvarchar(150) not null,
	DiaChi nvarchar(250) null,
	NguoiPhuTrach nvarchar(100) null,
	MaSoCongTo nvarchar(20) null,
	HeSoNhan tinyint default 1 not null,
	KichHoat bit default 1 not null
)
GO

CREATE TRIGGER trigger_TramBienAp ON TramBienAp FOR INSERT, UPDATE
AS
	IF UPDATE(HeSoNhan)
		BEGIN
			IF EXISTS (SELECT * FROM inserted WHERE HeSoNhan < 1)
				BEGIN
					RAISERROR (N'Hệ số nhân phải lớn hơn hoặc bằng 1', 15, 1)
					ROLLBACK TRAN
				END
		END
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
--ALTER PROCEDURE proc_IsDuplicated_MaTram
	@MaTram varchar(20)
AS
	IF EXISTS (SELECT * FROM TramBienAp WHERE MaTram = @MaTram)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_TramBienAp
--ALTER PROCEDURE proc_Insert_TramBienAp
	@MaTram varchar(20),
	@TenTram nvarchar(150),
	@DiaChi nvarchar(250),
	@NguoiPhuTrach nvarchar(100),
	@MaSoCongTo nvarchar(20),
	@HeSoNhan tinyint
AS
	INSERT INTO TramBienAp (MaTram, TenTram, DiaChi, NguoiPhuTrach, MaSoCongTo, HeSoNhan) VALUES (@MaTram, @TenTram, @DiaChi, @NguoiPhuTrach, @MaSoCongTo, @HeSoNhan)
GO

CREATE PROCEDURE proc_Update_TramBienAp
--ALTER PROCEDURE proc_Update_TramBienAp
	@MaTram varchar(20),
	@TenTram nvarchar(150),
	@DiaChi nvarchar(250),
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
	@MaTram varchar(20)
AS
	UPDATE TramBienAp
	SET KichHoat = 0
	WHERE MaTram = @MaTram
GO

--====================NGƯỜI QUẢN LÝ KHÁCH HÀNG====================
--DROP TABLE NguoiQuanLy
CREATE TABLE NguoiQuanLy (
	MaQuanLy varchar(20) primary key,
	TenQuanLy nvarchar(100) not null,
	SoDienThoai varchar(20) null,
	DiaChi nvarchar(250) not null,
	Email nvarchar(100) null,
	KichHoat bit default 1 not null
)
GO

INSERT INTO NguoiQuanLy VALUES ('GIAMDOC', N'La Quốc Thắng', '0987610260', N'Đà Lạt - Lâm Đồng', 'quocthang_0507@yahoo.com.vn', 1)
GO

CREATE PROCEDURE proc_GetAll_NguoiQuanLy
--ALTER PROCEDURE proc_GetAll_NguoiQuanLy
AS
	SELECT * FROM NguoiQuanLy ORDER BY KichHoat DESC, MaQuanLy ASC
GO

CREATE PROCEDURE proc_IsDuplicated_MaQuanLy
--ALTER PROCEDURE proc_IsDuplicated_MaQuanLy
	@MaQuanLy varchar(10)
AS
	IF EXISTS (SELECT * FROM NguoiQuanLy WHERE MaQuanLy = @MaQuanLy)
		RETURN 1
	ELSE
		RETURN 0
GO

--CREATE FUNCTION func_GenerateID_NguoiQuanLy()
----ALTER FUNCTION func_GenerateID_NguoiQuanLy()
--RETURNS CHAR(5)
--AS
--	BEGIN
--		DECLARE @ID INT
--		DECLARE @MA CHAR(5)
--		IF EXISTS (SELECT * FROM NguoiQuanLy WHERE MaQuanLy = (SELECT max(MaQuanLy) FROM NguoiQuanLy))
--			SET @MA = (SELECT max(MaQuanLy) FROM NguoiQuanLy)
--		ELSE
--			SET @MA = 'QL000'
--		SET @ID = CAST (RIGHT(@MA, 3) AS INT) + 1
--		SET @MA = 'QL' + RIGHT('000' + CAST (@ID AS VARCHAR(3)), 3)
--		RETURN @MA
--	END
--GO

/*
PRINT DBO.func_GenerateID_NguoiQuanLy()
*/

CREATE PROCEDURE proc_Insert_NguoiQuanLy
--ALTER PROCEDURE proc_Insert_NguoiQuanLy
	@MaQuanLy varchar(20),
	@TenQuanLy nvarchar(100),
	@SoDienThoai varchar(20),
	@DiaChi nvarchar(250),
	@Email nvarchar(100)
AS
	INSERT INTO NguoiQuanLy VALUES (@MaQuanLy, @TenQuanLy, @SoDienThoai, @DiaChi, @Email, 1)
GO

CREATE PROCEDURE proc_Update_NguoiQuanLy
--ALTER PROCEDURE proc_Update_NguoiQuanLy
	@MaQuanLy varchar(20),
	@TenQuanLy nvarchar(100),
	@SoDienThoai varchar(20),
	@DiaChi nvarchar(250),
	@Email nvarchar(100),
	@KichHoat bit
AS
	UPDATE NguoiQuanLy
	SET TenQuanLy = @TenQuanLy, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email, KichHoat = @KichHoat
	WHERE MaQuanLy = @MaQuanLy
GO

CREATE PROCEDURE proc_Delete_NguoiQuanLy
--ALTER PROCEDURE proc_Delete_NguoiQuanLy
	@MaQuanLy varchar(10)
AS
	UPDATE NguoiQuanLy
	SET KichHoat = 0
	WHERE MaQuanLy = @MaQuanLy
GO

--====================THÔNG TIN KHÁCH HÀNG====================
CREATE TABLE KhachHang (
--ALTER TABLE KhachHang (
	--KH00000001
	MaKhachHang char(10) primary key,
	HoVaTen nvarchar(100) not null,
	DiaChi nvarchar(250) not null,
	MaChiTietBangGia varchar(30) references ChiTietBangGia(MaChiTiet),
	MaTram varchar(20) references TramBienAp(MaTram),
	SoHo tinyint not null default 1,
	HeSoNhan tinyint not null default 1,
	MaSoThue varchar(20) null,
	SoDienThoai varchar(20) null,
	Email nvarchar(100) null,
	NgayTao datetime not null,
	NguoiTao varchar(20) references NguoiQuanLy(MaQuanLy),
	NgayCapNhat datetime not null,
	NguoiCapNhat varchar(20) references NguoiQuanLy(MaQuanLy),
	MaSoHopDong nvarchar(20) null,
	NgayHopDong datetime null,
	MaCongTo nvarchar(20) null,
	SoNganHang varchar(20) null,
	TenNganHang nvarchar(150) null,
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
RETURNS CHAR(10)
AS
	BEGIN
		DECLARE @ID INT
		DECLARE @MA CHAR(10)
		IF EXISTS (SELECT * FROM KhachHang WHERE MaKhachHang = (SELECT max(MaKhachHang) FROM KhachHang))
			SET @MA = (SELECT max(MaKhachHang) FROM KhachHang)
		ELSE
			SET @MA = 'KH00000000';
		SET @ID = CAST (RIGHT(@MA, 8) AS INT) + 1
		SET @MA = 'KH' + RIGHT('00000000' + CAST (@ID AS VARCHAR(8)), 8)
		RETURN @MA
	END
GO

/*
PRINT DBO.func_GenerateID_KhachHang()
*/

CREATE PROCEDURE proc_Insert_KhachHang
--ALTER PROCEDURE proc_Insert_KhachHang
	@HoVaTen nvarchar(100),
	@DiaChi nvarchar(250),
	@MaChiTietBangGia varchar(20),
	@MaTram varchar(20),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao varchar(20),
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(150)
AS
	DECLARE @MA CHAR(10)
	SET @MA = DBO.func_GenerateID_KhachHang()
	INSERT INTO KhachHang VALUES (@MA, @HoVaTen, @DiaChi, @MaChiTietBangGia, @MaTram, @SoHo, @HeSoNhan, @MaSoThue, 
		@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, @MaCongTo, @SoNganHang, @TenNganHang, 1)
GO

CREATE PROCEDURE proc_Update_KhachHang
	@MaKhachHang char(10),
	@HoVaTen nvarchar(100),
	@DiaChi nvarchar(250),
	@MaChiTietBangGia varchar(20),
	@MaTram varchar(20),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao varchar(20),
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(150)
AS
	UPDATE KhachHang
	SET
		HoVaTen = @HoVaTen,
		DiaChi = @DiaChi,
		MaChiTietBangGia = @MaChiTietBangGia,
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
	@MaKhachHang char(10)
AS
	UPDATE KhachHang
	SET KichHoat = 0
	WHERE MaKhachHang = @MaKhachHang
GO

CREATE PROCEDURE proc_Insert_KhachHang_Test
--ALTER PROCEDURE proc_Insert_KhachHang_Test
	@HoVaTen nvarchar(100),
	@DiaChi nvarchar(250),
	@MaChiTietBangGia varchar(20),
	@MaTram varchar(20),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao varchar(20),
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(150)
AS
	BEGIN
		DECLARE @MA CHAR(10)
		DECLARE @KQ BIT
		SET @KQ = 1
		BEGIN TRANSACTION ADDCUSTOMER
			BEGIN TRY
				SET @MA = DBO.func_GenerateID_KhachHang()
				INSERT INTO KhachHang VALUES (@MA, @HoVaTen, @DiaChi, @MaChiTietBangGia, @MaTram, @SoHo, @HeSoNhan, @MaSoThue, 
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
	@MaKhachHang char(10),
	@HoVaTen nvarchar(100),
	@DiaChi nvarchar(250),
	@MaChiTietBangGia varchar(30),
	@MaTram varchar(20),
	@SoHo tinyint,
	@HeSoNhan tinyint,
	@MaSoThue varchar(20),
	@SoDienThoai varchar(20),
	@Email nvarchar(100),
	@NgayTao datetime,
	@NguoiTao varchar(20),
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
	@MaSoHopDong nvarchar(20),
	@NgayHopDong datetime,
	@MaCongTo nvarchar(20),
	@SoNganHang varchar(20),
	@TenNganHang nvarchar(150)
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
					MaChiTietBangGia = @MaChiTietBangGia,
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
	MaKhachHang char(10) references KhachHang(MaKhachHang) not null,
	NgayGhi datetime null,
	NguoiGhi varchar(20) references NguoiQuanLy(MaQuanLy),
	NgayBatDau datetime null,
	NgayKetThuc datetime null,
	NgayCapNhat datetime null,
	NguoiCapNhat varchar(20) references NguoiQuanLy(MaQuanLy),
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

CREATE VIEW View_DienNangTieuThu
--ALTER VIEW View_DienNangTieuThu
AS
	SELECT ID, D.MaKhachHang, HoVaTen, DiaChi, MaTram, MaChiTietBangGia, NgayGhi, NguoiGhi, NgayBatDau, NgayKetThuc, D.NgayCapNhat, D.NguoiCapNhat, NgayHoaDon, NgayTraTien, ChiSoMoi, ChiSoCu, TongTienTruocVAT, TongTienSauVAT, DaTra, ConLai
	FROM DienNangTieuThu D, KhachHang K
	WHERE D.MaKhachHang = K.MaKhachHang
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
	@MaKhachHang char(10),
	@NgayGhi datetime,
	@NguoiGhi varchar(20),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
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
	@MaKhachHang char(10),
	@NgayGhi datetime,
	@NguoiGhi varchar(20),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
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
	@MaKhachHang char(10),
	@NgayGhi datetime,
	@NguoiGhi varchar(20),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
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
	@MaKhachHang char(10),
	@NgayGhi datetime,
	@NguoiGhi varchar(20),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@NgayCapNhat datetime,
	@NguoiCapNhat varchar(20),
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
