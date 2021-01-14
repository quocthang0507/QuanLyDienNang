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
	MaBangGia VARCHAR(30) PRIMARY KEY,
	TenBangGia NVARCHAR(150) NOT NULL,
	Thue DECIMAL(3,2) DEFAULT 0.1 NOT NULL,
	ApGia BIT DEFAULT 0 NOT NULL,
	KichHoat BIT DEFAULT 1 NOT NULL,
	CONSTRAINT constraint_Thue CHECK (THUE < 1 AND THUE >= 0)
)
GO

--DELETE FROM BangGia

-- MÃ BẢNG GIÁ TỰ ĐỊNH NGHĨA
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('SH-THUONG', N'Điện sinh hoạt (hộ thường)', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('SH-NGHEO', N'Điện sinh hoạt (hộ nghèo)', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('KDDV-TREN22KV', N'Điện kinh doanh - dịch vụ: Cấp điện áp từ 22kV trở lên', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('KDDV-6KV-22KV', N'Điện kinh doanh - dịch vụ: Cấp điện áp từ 6kV đến dưới 22kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('KDDV-DUOI6KV', N'Điện kinh doanh - dịch vụ: Cấp điện áp dưới 6kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('SX-TREN110KV', N'Điện sản xuất, cấp điện áp từ 110kV trở lên', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('SX-22KV-110KV', N'Điện sản xuất, cấp điện áp từ 22kV đến dưới 110kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('SX-6KV-22KV', N'Điện sản xuất, cấp điện áp từ 6kV đến dưới 22kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('SX-DUOI6KV', N'Điện sản xuất, cấp điện áp dưới 6kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('HCSN-BVTH-TREN6KV', N'Điện hành chính, sự nghiệp: Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông - Cấp điện áp từ 6kV trở lên', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('HCSN-BVTH-DUOI6KV', N'Điện hành chính, sự nghiệp: Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông - Cấp điện áp dưới 6kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('HCSN-CSCC-TREN6KV', N'Điện hành chính, sự nghiệp: Chiếu sáng công cộng; đơn vị hành chính sự nghiệp - Cấp điện áp từ 6kV trở lên', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('HCSN-CSCC-DUOI6KV', N'Điện hành chính, sự nghiệp: Chiếu sáng công cộng; đơn vị hành chính sự nghiệp - Cấp điện áp dưới 6kV', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('BV-TH', N'Điện cho bệnh viện, trường học', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('BN-TT', N'Điện cho bơm nước, tưới tiêu', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('CHIEUSANG', N'Điện chiếu sáng công cộng', 0);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('10SX-50SH-40KD', N'10% Sản xuất, 50% Sinh hoạt, 40% Kinh doanh', 1);
INSERT INTO BangGia (MaBangGia, TenBangGia, ApGia) VALUES ('50%BN-10KD-30SX-10SH', N'50% Bơm nước, 10% Kinh doanh, 30% Sản xuất, 10% Sinh hoạt', 1);
GO

CREATE PROCEDURE proc_GetAll_BangGia
--ALTER PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia ORDER BY KichHoat DESC, MaBangGia ASC
GO

CREATE PROCEDURE proc_IsDuplicated_MaBangGia
--ALTER PROCEDURE proc_IsDuplicated_MaBangGia
	@MaBangGia VARCHAR(30)
AS
	IF EXISTS (SELECT * FROM BangGia WHERE MaBangGia = @MaBangGia)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_BangGia
--ALTER PROCEDURE proc_Insert_BangGia
	@MaBangGia VARCHAR(30),
	@TenBangGia NVARCHAR(150),
	@Thue DECIMAL(3,2),
	@ApGia BIT
AS
	INSERT INTO BangGia (MaBangGia, TenBangGia, Thue, ApGia) VALUES (@MaBangGia, @TenBangGia, @Thue, @ApGia)
GO

CREATE PROCEDURE proc_Update_BangGia
--ALTER PROCEDURE proc_Update_BangGia
	@MaBangGia VARCHAR(30),
	@TenBangGia NVARCHAR(150),
	@Thue DECIMAL(3,2),
	@ApGia BIT,
	@KichHoat BIT
AS
	UPDATE BangGia
	SET TenBangGia = @TenBangGia, KichHoat = @KichHoat, Thue = @Thue, ApGia = @ApGia
	WHERE MaBangGia = @MaBangGia
GO

CREATE PROCEDURE proc_Delete_BangGia
--ALTER PROCEDURE proc_Delete_BangGia
	@MaBangGia VARCHAR(30)
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
	MaChiTiet VARCHAR(30) PRIMARY KEY,
	MaBangGia VARCHAR(30) REFERENCES BangGia(MaBangGia),
	BatDau INT DEFAULT 0 NOT NULL,
	KetThuc INT DEFAULT 0 NOT NULL,
	DonGia INT NOT NULL,
	MoTa NVARCHAR(250) NULL,
	KichHoat BIT DEFAULT 1 NOT NULL
)
GO

CREATE TRIGGER trigger_ChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
--ALTER TRIGGER trigger_ChiTietBangGia ON ChiTietBangGia FOR INSERT, UPDATE
AS
	IF UPDATE(BatDau) OR UPDATE(KetThuc) OR UPDATE(DonGia)
		BEGIN
			IF EXISTS (SELECT * FROM INSERTED WHERE KetThuc < BatDau AND KetThuc != 0) --Nếu kết thúc bằng 0 nghĩa là kéo dài vô tận!
				BEGIN
					RAISERROR (N'Trong phạm vi áp dụng bảng giá, vị trí kết thúc không được nhỏ hơn vị trí bắt đầu', 15, 1)
					ROLLBACK TRAN
				END
			IF EXISTS (SELECT * FROM INSERTED WHERE DonGia < 0)
				BEGIN
					RAISERROR (N'Đơn giá không được âm', 15, 1)
					ROLLBACK TRAN
				END
		END
GO

CREATE PROCEDURE proc_GetAll_ChiTietBangGia
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia ORDER BY KichHoat DESC, MaChiTiet ASC
GO

CREATE PROCEDURE proc_GetByBangGia_ChiTietBangGia
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
	@MaBangGia VARCHAR(30)
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = @MaBangGia ORDER BY KichHoat DESC, MaChiTiet ASC
GO

CREATE PROCEDURE proc_Insert_ChiTietBangGia
--ALTER PROCEDURE proc_Insert_ChiTietBangGia
	@MaChiTiet VARCHAR(30),
	@MaBangGia VARCHAR(30),
	@BatDau INT,
	@KetThuc INT,
	@DonGia INT,
	@MoTa NVARCHAR(250)
AS
	INSERT INTO ChiTietBangGia (MaChiTiet, MaBangGia, BatDau, KetThuc, DonGia, MoTa) 
	VALUES (@MaChiTiet, @MaBangGia, @BatDau, @KetThuc, @DonGia, @MoTa)
GO

--DELETE FROM ChiTietBangGia

EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC1', 'SH-THUONG', 0, 50, 1678, N'Bậc 1: Cho kWh từ 0 - 50'
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC2', 'SH-THUONG', 51, 100, 1734, N'Bậc 2: Cho kWh từ 51 - 100'
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC3', 'SH-THUONG', 101, 200, 2014, N'Bậc 3: Cho kWh từ 101 - 200'
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC4', 'SH-THUONG', 201, 300, 2536, N'Bậc 4: Cho kWh từ 201 - 300'
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC5', 'SH-THUONG', 301, 400, 2834, N'Bậc 5: Cho kWh từ 301 - 400'
EXEC proc_Insert_ChiTietBangGia 'SH-TH-BAC6', 'SH-THUONG', 401, 0, 2927, N'Bậc 6: Cho kWh từ 401 trở lên'
EXEC proc_Insert_ChiTietBangGia 'SX-TREN110KV-GBT', 'SX-TREN110KV', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX-TREN110KV-GTD', 'SX-TREN110KV', 0, 0, 970, N'Cấp điện áp 110kV trở lên: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-TREN110KV-GCD', 'SX-TREN110KV', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-22KV-110KV-GBT', 'SX-22KV-110KV', 0, 0, 1555, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX-22KV-110KV-GTD', 'SX-22KV-110KV', 0, 0, 1007, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-22KV-110KV-GCD', 'SX-22KV-110KV', 0, 0, 2871, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-6KV-22KV-GBT', 'SX-6KV-22KV', 0, 0, 1611, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX-6KV-22KV-GTD', 'SX-6KV-22KV', 0, 0, 1044, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-6KV-22KV-GCD', 'SX-6KV-22KV', 0, 0, 2964, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-DUOI6KV-GBT', 'SX-DUOI6KV', 0, 0, 1685, N'Cấp điện áp dưới 6kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'SX-DUOI6KV-GTD', 'SX-DUOI6KV', 0, 0, 1100, N'Cấp điện áp dưới 6kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'SX-DUOI6KV-GCD', 'SX-DUOI6KV', 0, 0, 3076, N'Cấp điện áp dưới 6kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'HCSN-BVTH-TREN6KV', 'HCSN-BVTH-TREN6KV', 0, 0, 1659, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp từ 6kV trở lên'
EXEC proc_Insert_ChiTietBangGia 'HCSN-BVTH-DUOI6KV', 'HCSN-BVTH-DUOI6KV', 0, 0, 1771, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp dưới 6kV'
EXEC proc_Insert_ChiTietBangGia 'HCSN-CSCC-TREN6KV', 'HCSN-CSCC-TREN6KV', 0, 0, 1827, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp từ 6kV trở lên'
EXEC proc_Insert_ChiTietBangGia 'HCSN-CSCC-DUOI6KV', 'HCSN-CSCC-DUOI6KV', 0, 0, 1902, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp dưới 6kV'
EXEC proc_Insert_ChiTietBangGia 'KDDV-TREN22KV-GBT', 'KDDV-TREN22KV', 0, 0, 2442, N'Cấp điện áp từ 22kV trở lên: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'KDDV-TREN22KV-GTD', 'KDDV-TREN22KV', 0, 0, 1361, N'Cấp điện áp từ 22kV trở lên: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'KDDV-TREN22KV-GCD', 'KDDV-TREN22KV', 0, 0, 4251, N'Cấp điện áp từ 22kV trở lên: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'KDDV-6KV-22KV-GBT', 'KDDV-6KV-22KV', 0, 0, 2629, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'KDDV-6KV-22KV-GTD', 'KDDV-6KV-22KV', 0, 0, 1547, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'KDDV-6KV-22KV-GCD', 'KDDV-6KV-22KV', 0, 0, 4400, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm'
EXEC proc_Insert_ChiTietBangGia 'KDDV-DUOI6KV-GBT', 'KDDV-DUOI6KV', 0, 0, 2666, N'Cấp điện áp dưới 6kV: Giờ bình thường'
EXEC proc_Insert_ChiTietBangGia 'KDDV-DUOI6KV-GTD', 'KDDV-DUOI6KV', 0, 0, 1622, N'Cấp điện áp dưới 6kV: Giờ thấp điểm'
EXEC proc_Insert_ChiTietBangGia 'KDDV-DUOI6KV-GCD', 'KDDV-DUOI6KV', 0, 0, 4587, N'Cấp điện áp dưới 6kV: Giờ cao điểm'
GO

CREATE PROCEDURE proc_Update_ChiTietBangGia
--ALTER PROCEDURE proc_Update_ChiTietBangGia
	@MaChiTiet VARCHAR(30),
	@MaBangGia VARCHAR(30),
	@BatDau INT,
	@KetThuc INT,
	@DonGia INT,
	@MoTa NVARCHAR(200),
	@KichHoat BIT
AS
	UPDATE ChiTietBangGia
	SET MaBangGia = @MaBangGia, BatDau = @BatDau, KetThuc = @KetThuc, DonGia = @DonGia, MoTa = @MoTa, KichHoat = @KichHoat
	WHERE MaChiTiet = @MaChiTiet
GO

CREATE PROCEDURE proc_Delete_ChiTietBangGia
--ALTER PROCEDURE proc_Delete_ChiTietBangGia
	@MaChiTiet VARCHAR(30)
AS
	UPDATE ChiTietBangGia
	SET KichHoat = 0
	WHERE MaChiTiet = @MaChiTiet
GO

--====================BẢNG ĐIỆN ÁP GIÁ====================
--DROP TABLE BangDienApGia
CREATE TABLE BangDienApGia
(
	MaApGia VARCHAR(30),
	MaBangGia VARCHAR(30) NOT NULL REFERENCES BangGia(MaBangGia),
	TyLe DECIMAL(3,2) NOT NULL DEFAULT 0.0,
	KichHoat BIT DEFAULT 1,
	CONSTRAINT pk_BangDienApGia PRIMARY KEY (MaApGia, MaBangGia)
)
GO

CREATE PROCEDURE proc_Reset_BangDienApGia
AS
	DELETE FROM BangDienApGia
	DBCC CHECKIDENT ('[BangDienApGia]', RESEED, 0);
GO

--EXEC proc_Reset_BangDienApGia

-- Đưa mã bảng giá làm mã bảng áp giá
CREATE PROCEDURE proc_CreateNew_BangDienApGia
--ALTER PROCEDURE proc_CreateNew_BangDienApGia
	@MaBangGia VARCHAR(30)
AS
	IF NOT EXISTS (SELECT * FROM BangDienApGia WHERE MaApGia = @MaBangGia)
	BEGIN
		DECLARE @Ma VARCHAR(30)
		DECLARE csrBangGia CURSOR FOR SELECT MaBangGia FROM BangGia WHERE ApGia = 0
		OPEN csrBangGia
		FETCH NEXT FROM csrBangGia INTO @Ma
		WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO BangDienApGia (MaApGia, MaBangGia) VALUES (@MaBangGia, @Ma)
			FETCH NEXT FROM csrBangGia INTO @Ma
		END
		CLOSE csrBangGia
		DEALLOCATE csrBangGia
	END
GO

--EXEC proc_CreateNew_BangDienApGia '10SX-50SH-40KD'

CREATE VIEW view_BangDienApGia
--ALTER VIEW view_BangDienApGia
AS
	SELECT MaApGia, B.MaBangGia, TenBangGia, TyLe, A.KichHoat 
	FROM BangGia B, BangDienApGia A
	WHERE B.MaBangGia = A.MaBangGia
GO

CREATE PROCEDURE proc_GetAll_BangDienApGia
--ALTER PROCEDURE proc_GetAll_BangDienApGia
	@MaApGia VARCHAR(30)
AS
	SELECT * FROM view_BangDienApGia WHERE MaApGia = @MaApGia
GO

CREATE PROCEDURE proc_Update_BangDienApGia
--ALTER PROCEDURE proc_Update_BangDienApGia
	@MaApGia VARCHAR(30),
	@MaBangGia VARCHAR(30),
	@TyLe DECIMAL(3,2),
	@KichHoat BIT
AS
	UPDATE BangDienApGia
	SET TyLe = @TyLe, KichHoat = @KichHoat
	WHERE MaApGia = @MaApGia AND MaBangGia = @MaBangGia
GO

CREATE TRIGGER trigger_BangDienApGia ON BangDienApGia FOR INSERT, UPDATE
--ALTER TRIGGER trigger_BangDienApGia ON BangDienApGia FOR INSERT, UPDATE
AS
	IF UPDATE(TyLe)
		BEGIN
			DECLARE @MaBangGia VARCHAR(30)
			DECLARE @TyLe DECIMAL(3,2)
			SET @MaBangGia = (SELECT @MaBangGia FROM INSERTED)
			SET @TyLe = (SELECT SUM(TyLe) FROM BangDienApGia WHERE MaBangGia = @MaBangGia)
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
	MaTram VARCHAR(30) PRIMARY KEY,
	TenTram NVARCHAR(150) NOT NULL,
	DiaChi NVARCHAR(250) NULL,
	NguoiPhuTrach NVARCHAR(100) NULL,
	MaSoCongTo VARCHAR(30) NULL,
	HeSoNhan TINYINT DEFAULT 1 NOT NULL,
	KichHoat BIT DEFAULT 1 NOT NULL
)
GO

CREATE TRIGGER trigger_TramBienAp ON TramBienAp FOR INSERT, UPDATE
AS
	IF UPDATE(HeSoNhan)
		BEGIN
			IF EXISTS (SELECT * FROM INSERTED WHERE HeSoNhan < 1)
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
	@MaTram VARCHAR(30)
AS
	IF EXISTS (SELECT * FROM TramBienAp WHERE MaTram = @MaTram)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_TramBienAp
--ALTER PROCEDURE proc_Insert_TramBienAp
	@MaTram VARCHAR(30),
	@TenTram NVARCHAR(150),
	@DiaChi NVARCHAR(250),
	@NguoiPhuTrach NVARCHAR(100),
	@MaSoCongTo VARCHAR(30),
	@HeSoNhan TINYINT
AS
	INSERT INTO TramBienAp (MaTram, TenTram, DiaChi, NguoiPhuTrach, MaSoCongTo, HeSoNhan) 
	VALUES (@MaTram, @TenTram, @DiaChi, @NguoiPhuTrach, @MaSoCongTo, @HeSoNhan)
GO

CREATE PROCEDURE proc_Update_TramBienAp
--ALTER PROCEDURE proc_Update_TramBienAp
	@MaTram VARCHAR(30),
	@TenTram NVARCHAR(150),
	@DiaChi NVARCHAR(250),
	@NguoiPhuTrach NVARCHAR(100),
	@MaSoCongTo VARCHAR(30),
	@HeSoNhan TINYINT,
	@KichHoat BIT
AS
	UPDATE TramBienAp
	SET TenTram = @TenTram, DiaChi = @DiaChi, NguoiPhuTrach = @NguoiPhuTrach, MaSoCongTo = @MaSoCongTo, HeSoNhan = @HeSoNhan, KichHoat = @KichHoat
	WHERE MaTram = @MaTram
GO

CREATE PROCEDURE proc_Delete_TramBienAp
--ALTER PROCEDURE proc_Delete_TramBienAp
	@MaTram VARCHAR(30)
AS
	UPDATE TramBienAp
	SET KichHoat = 0
	WHERE MaTram = @MaTram
GO

--====================NGƯỜI QUẢN LÝ KHÁCH HÀNG====================
--DROP TABLE NguoiQuanLy
CREATE TABLE NguoiQuanLy (
	MaQuanLy VARCHAR(30) PRIMARY KEY,
	TenQuanLy NVARCHAR(100) NOT NULL,
	SoDienThoai VARCHAR(30) NULL,
	DiaChi NVARCHAR(250) NOT NULL,
	Email NVARCHAR(100) NULL,
	KichHoat BIT DEFAULT 1 NOT NULL
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
	@MaQuanLy VARCHAR(10)
AS
	IF EXISTS (SELECT * FROM NguoiQuanLy WHERE MaQuanLy = @MaQuanLy)
		RETURN 1
	ELSE
		RETURN 0
GO

CREATE PROCEDURE proc_Insert_NguoiQuanLy
--ALTER PROCEDURE proc_Insert_NguoiQuanLy
	@MaQuanLy VARCHAR(30),
	@TenQuanLy NVARCHAR(100),
	@SoDienThoai NVARCHAR(30),
	@DiaChi NVARCHAR(250),
	@Email NVARCHAR(100)
AS
	INSERT INTO NguoiQuanLy VALUES (@MaQuanLy, @TenQuanLy, @SoDienThoai, @DiaChi, @Email, 1)
GO

CREATE PROCEDURE proc_Update_NguoiQuanLy
--ALTER PROCEDURE proc_Update_NguoiQuanLy
	@MaQuanLy VARCHAR(30),
	@TenQuanLy NVARCHAR(100),
	@SoDienThoai NVARCHAR(30),
	@DiaChi NVARCHAR(250),
	@Email NVARCHAR(100),
	@KichHoat BIT
AS
	UPDATE NguoiQuanLy
	SET TenQuanLy = @TenQuanLy, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email, KichHoat = @KichHoat
	WHERE MaQuanLy = @MaQuanLy
GO

CREATE PROCEDURE proc_Delete_NguoiQuanLy
--ALTER PROCEDURE proc_Delete_NguoiQuanLy
	@MaQuanLy VARCHAR(30)
AS
	UPDATE NguoiQuanLy
	SET KichHoat = 0
	WHERE MaQuanLy = @MaQuanLy
GO

--====================THÔNG TIN KHÁCH HÀNG====================
--DROP TABLE KhachHang
CREATE TABLE KhachHang (
	--KH00000001
	MaKhachHang CHAR(10) PRIMARY KEY,
	HoVaTen NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(250) NOT NULL,
	MaBangGia VARCHAR(30) REFERENCES BangGia(MaBangGia),
	MaTram VARCHAR(30) REFERENCES TramBienAp(MaTram),
	SoHo TINYINT NOT NULL DEFAULT 1,
	HeSoNhan TINYINT NOT NULL DEFAULT 1,
	MaSoThue NVARCHAR(30) NULL,
	SoDienThoai NVARCHAR(30) NULL,
	Email NVARCHAR(100) NULL,
	NgayTao DATETIME NOT NULL,
	NguoiTao VARCHAR(30) REFERENCES NguoiQuanLy(MaQuanLy),
	NgayCapNhat DATETIME NOT NULL,
	NguoiCapNhat VARCHAR(30) REFERENCES NguoiQuanLy(MaQuanLy),
	MaSoHopDong NVARCHAR(30) NULL,
	NgayHopDong DATETIME NULL,
	MaCongTo NVARCHAR(30) NULL,
	SoNganHang NVARCHAR(30) NULL,
	TenNganHang NVARCHAR(150) NULL,
	KichHoat BIT DEFAULT 1 NOT NULL
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
		SET @MA = 'KH' + RIGHT('00000000' + CAST (@ID AS NVARCHAR(8)), 8)
		RETURN @MA
	END
GO

/*
PRINT DBO.func_GenerateID_KhachHang()
*/

CREATE PROCEDURE proc_Insert_KhachHang
--ALTER PROCEDURE proc_Insert_KhachHang
	@HoVaTen NVARCHAR(100),
	@DiaChi NVARCHAR(250),
	@MaBangGia NVARCHAR(30),
	@MaTram VARCHAR(30),
	@SoHo TINYINT,
	@HeSoNhan TINYINT,
	@MaSoThue NVARCHAR(30),
	@SoDienThoai NVARCHAR(30),
	@Email NVARCHAR(100),
	@NgayTao DATETIME,
	@NguoiTao NVARCHAR(30),
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@MaSoHopDong NVARCHAR(30),
	@NgayHopDong DATETIME,
	@MaCongTo NVARCHAR(30),
	@SoNganHang NVARCHAR(30),
	@TenNganHang NVARCHAR(150)
AS
	DECLARE @MA CHAR(10)
	SET @MA = DBO.func_GenerateID_KhachHang()
	INSERT INTO KhachHang VALUES (@MA, @HoVaTen, @DiaChi, @MaBangGia, @MaTram, @SoHo, @HeSoNhan, @MaSoThue, 
		@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, @MaCongTo, @SoNganHang, @TenNganHang, 1)
GO

CREATE PROCEDURE proc_Update_KhachHang
--ALTER PROCEDURE proc_Update_KhachHang
	@MaKhachHang CHAR(10),
	@HoVaTen NVARCHAR(100),
	@DiaChi NVARCHAR(250),
	@MaBangGia VARCHAR(30),
	@MaTram VARCHAR(30),
	@SoHo TINYINT,
	@HeSoNhan TINYINT,
	@MaSoThue NVARCHAR(30),
	@SoDienThoai NVARCHAR(30),
	@Email NVARCHAR(100),
	@NgayTao DATETIME,
	@NguoiTao NVARCHAR(30),
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@MaSoHopDong NVARCHAR(30),
	@NgayHopDong DATETIME,
	@MaCongTo NVARCHAR(30),
	@SoNganHang NVARCHAR(30),
	@TenNganHang NVARCHAR(150)
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
	@MaKhachHang CHAR(10)
AS
	UPDATE KhachHang
	SET KichHoat = 0
	WHERE MaKhachHang = @MaKhachHang
GO

CREATE PROCEDURE proc_Insert_KhachHang_Test
--ALTER PROCEDURE proc_Insert_KhachHang_Test
	@HoVaTen NVARCHAR(100),
	@DiaChi NVARCHAR(250),
	@MaBangGia NVARCHAR(30),
	@MaTram VARCHAR(30),
	@SoHo TINYINT,
	@HeSoNhan TINYINT,
	@MaSoThue NVARCHAR(30),
	@SoDienThoai NVARCHAR(30),
	@Email NVARCHAR(100),
	@NgayTao DATETIME,
	@NguoiTao NVARCHAR(30),
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@MaSoHopDong NVARCHAR(30),
	@NgayHopDong DATETIME,
	@MaCongTo NVARCHAR(30),
	@SoNganHang NVARCHAR(30),
	@TenNganHang NVARCHAR(150)
AS
	BEGIN
		DECLARE @MA CHAR(10)
		DECLARE @KQ BIT
		SET @KQ = 1
		BEGIN TRANSACTION ADDCUSTOMER
			BEGIN TRY
				SET @MA = DBO.func_GenerateID_KhachHang()
				INSERT INTO KhachHang VALUES (@MA, @HoVaTen, @DiaChi, @MaBangGia, @MaTram, @SoHo, @HeSoNhan, @MaSoThue, 
					@SoDienThoai, @Email, @NgayTao, @NguoiTao, @NgayCapNhat, @NguoiCapNhat, @MaSoHopDong, @NgayHopDong, 
					@MaCongTo, @SoNganHang, @TenNganHang, 1)
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
	@MaKhachHang CHAR(10),
	@HoVaTen NVARCHAR(100),
	@DiaChi NVARCHAR(250),
	@MaBangGia NVARCHAR(30),
	@MaTram VARCHAR(30),
	@SoHo TINYINT,
	@HeSoNhan TINYINT,
	@MaSoThue NVARCHAR(30),
	@SoDienThoai NVARCHAR(30),
	@Email NVARCHAR(100),
	@NgayTao DATETIME,
	@NguoiTao NVARCHAR(30),
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@MaSoHopDong NVARCHAR(30),
	@NgayHopDong DATETIME,
	@MaCongTo NVARCHAR(30),
	@SoNganHang NVARCHAR(30),
	@TenNganHang NVARCHAR(150)
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
	ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	MaKhachHang CHAR(10) REFERENCES KhachHang(MaKhachHang) NOT NULL,
	NgayGhi DATETIME NULL,
	NguoiGhi VARCHAR(30) REFERENCES NguoiQuanLy(MaQuanLy),
	NgayBatDau DATETIME NULL,
	NgayKetThuc DATETIME NULL,
	NgayCapNhat DATETIME NULL,
	NguoiCapNhat VARCHAR(30) REFERENCES NguoiQuanLy(MaQuanLy),
	NgayHoaDon DATETIME NULL,
	NgayTraTien DATETIME NULL,
	ChiSoMoi INT DEFAULT 0 NULL, -- Chỉ số công tơ lúc ghi
	ChiSoCu INT DEFAULT 0 NULL, -- Chỉ số công tơ của kỳ trước
	ThapDiem INT DEFAULT 0 NULL, -- Số điện năng tiêu thụ trong giờ thấp điểm
	CaoDiem INT DEFAULT 0 NULL, -- Số điện năng tiêu thụ trong giờ cao điểm
	BinhThuong INT DEFAULT 0 NULL, -- Số điện năng tiêu thụ trong giờ bình thường
	TongTienTruocVAT MONEY NULL,
	TongTienSauVAT MONEY NULL,
	DaTra MONEY DEFAULT 0 NULL,
	ConLai MONEY NULL,
)
GO

CREATE VIEW View_DienNangTieuThu
--ALTER VIEW View_DienNangTieuThu
AS
	SELECT ID, D.MaKhachHang, HoVaTen, DiaChi, MaTram, MaBangGia, NgayGhi, NguoiGhi, NgayBatDau, NgayKetThuc, D.NgayCapNhat, 
	D.NguoiCapNhat, NgayHoaDon, NgayTraTien, ChiSoMoi, ChiSoCu, ThapDiem, CaoDiem, BinhThuong, TongTienTruocVAT, TongTienSauVAT, 
	DaTra, ConLai
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
	@MaKhachHang CHAR(10),
	@NgayGhi DATETIME,
	@NguoiGhi NVARCHAR(30),
	@NgayBatDau DATETIME,
	@NgayKetThuc DATETIME,
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@NgayHoaDon DATETIME,
	@NgayTraTien DATETIME,
	@ChiSoMoi INT,
	@ChiSoCu INT,
	@ThapDiem INT,
	@CaoDiem INT,
	@BinhThuong INT,
	@TongTienTruocVAT MONEY,
	@TongTienSauVAT MONEY,
	@DaTra MONEY,
	@ConLai MONEY
AS
	INSERT INTO DienNangTieuThu VALUES (@MaKhachHang, @NgayGhi, @NguoiGhi, @NgayBatDau, @NgayKetThuc, @NgayCapNhat, @NguoiCapNhat, 
	@NgayHoaDon, @NgayTraTien, @ChiSoMoi, @ChiSoCu, @ThapDiem, @CaoDiem, @BinhThuong, @TongTienTruocVAT, @TongTienSauVAT, @DaTra, @ConLai)
GO

CREATE PROCEDURE proc_Insert_DienNangTieuThu_Test
--ALTER PROCEDURE proc_Insert_DienNangTieuThu_Test
	@MaKhachHang CHAR(10),
	@NgayGhi DATETIME,
	@NguoiGhi NVARCHAR(30),
	@NgayBatDau DATETIME,
	@NgayKetThuc DATETIME,
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@NgayHoaDon DATETIME,
	@NgayTraTien DATETIME,
	@ChiSoMoi INT,
	@ChiSoCu INT,
	@ThapDiem INT,
	@CaoDiem INT,
	@BinhThuong INT,
	@TongTienTruocVAT MONEY,
	@TongTienSauVAT MONEY,
	@DaTra MONEY,
	@ConLai MONEY
AS
	BEGIN
		DECLARE @KQ BIT
		DECLARE @MAX_ID INT
		SET @KQ = 1
		SET @MAX_ID = IDENT_CURRENT('[DienNangTieuThu]')
		BEGIN TRANSACTION ADDDNTT
			BEGIN TRY
				INSERT INTO DienNangTieuThu VALUES (@MaKhachHang, @NgayGhi, @NguoiGhi, @NgayBatDau, @NgayKetThuc, @NgayCapNhat, @NguoiCapNhat, 
				@NgayHoaDon, @NgayTraTien, @ChiSoMoi, @ChiSoCu, @ThapDiem, @CaoDiem, @BinhThuong, @TongTienTruocVAT, @TongTienSauVAT, @DaTra, @ConLai)
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
	@ID INT,
	@MaKhachHang CHAR(10),
	@NgayGhi DATETIME,
	@NguoiGhi NVARCHAR(30),
	@NgayBatDau DATETIME,
	@NgayKetThuc DATETIME,
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@NgayHoaDon DATETIME,
	@NgayTraTien DATETIME,
	@ChiSoMoi INT,
	@ChiSoCu INT,
	@ThapDiem INT,
	@CaoDiem INT,
	@BinhThuong INT,
	@TongTienTruocVAT MONEY,
	@TongTienSauVAT MONEY,
	@DaTra MONEY,
	@ConLai MONEY
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
		ThapDiem = @ThapDiem,
		CaoDiem = @CaoDiem,
		BinhThuong = @BinhThuong,
		TongTienTruocVAT = @TongTienTruocVAT,
		TongTienSauVAT = @TongTienSauVAT,
		DaTra = @DaTra,
		ConLai = @ConLai
	WHERE ID = @ID
GO

CREATE PROCEDURE proc_Update_DienNangTieuThu_Test
--ALTER PROCEDURE proc_Update_DienNangTieuThu_Test
	@ID INT,
	@MaKhachHang CHAR(10),
	@NgayGhi DATETIME,
	@NguoiGhi NVARCHAR(30),
	@NgayBatDau DATETIME,
	@NgayKetThuc DATETIME,
	@NgayCapNhat DATETIME,
	@NguoiCapNhat NVARCHAR(30),
	@NgayHoaDon DATETIME,
	@NgayTraTien DATETIME,
	@ChiSoMoi INT,
	@ChiSoCu INT,
	@ThapDiem INT,
	@CaoDiem INT,
	@BinhThuong INT,
	@TongTienTruocVAT MONEY,
	@TongTienSauVAT MONEY,
	@DaTra MONEY,
	@ConLai MONEY
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
					ThapDiem = @ThapDiem,
					CaoDiem = @CaoDiem,
					BinhThuong = @BinhThuong,
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

--====================TÍNH TIỀN ĐIỆN CHƯA THUẾ THEO CÁC MỨC GIÁ TRONG BẢNG CHI TIẾT GIÁ ĐIỆN====================
CREATE VIEW view_BangDienSinhHoat
--ALTER VIEW view_BangDienSinhHoat
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = 'SH-THUONG' AND KichHoat = 1
GO

-- Bỏ qua bảng giá điện sinh hoạt và bảng giá điện áp giá
CREATE VIEW view_BangDienConLai
--ALTER VIEW view_BangDienConLai
AS
	SELECT * FROM ChiTietBangGia 
	WHERE MaBangGia NOT LIKE 'SH*' AND MaBangGia NOT LIKE 'APGIA' AND KichHoat = 1
GO

CREATE FUNCTION func_TinhTienDien_SinhHoat (@DienNangTieuThu INT, @SoHo TINYINT)
--ALTER FUNCTION func_TinhTienDien_SinhHoat (@DienNangTieuThu INT, @SoHo TINYINT)
RETURNS INT
AS
	BEGIN
		DECLARE @DonGia INT, @BatDau INT, @KetThuc INT, @PhamVi INT, @ThanhTien INT
		SET @ThanhTien = 0
		DECLARE csrChiTietBangGia CURSOR FOR SELECT DonGia, BatDau, KetThuc FROM view_BangDienSinhHoat ORDER BY BatDau
		OPEN csrChiTietBangGia
		FETCH NEXT FROM csrChiTietBangGia INTO @DonGia, @BatDau, @KetThuc
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @BatDau = 0
				SET @BatDau = 1
			IF @KetThuc = 0
				SET @KetThuc = 9999
			SET @PhamVi = (@KetThuc - @BatDau + 1) * @SoHo
			IF @DienNangTieuThu >= @PhamVi
				BEGIN
					SET @ThanhTien = @ThanhTien + @PhamVi * @DonGia
					SET @DienNangTieuThu = @DienNangTieuThu - @PhamVi
				END
			ELSE
				BEGIN
					SET @ThanhTien = @ThanhTien + @DienNangTieuThu * @DonGia
					SET @DienNangTieuThu = 0
				END
			FETCH NEXT FROM csrChiTietBangGia INTO @DonGia, @BatDau, @KetThuc
		END
		CLOSE csrChiTietBangGia
		DEALLOCATE csrChiTietBangGia
		RETURN @ThanhTien
	END
GO

--PRINT dbo.func_TinhTienDien_SinhHoat(0, 2)
--PRINT dbo.func_TinhTienDien_SinhHoat(50, 1)
--PRINT dbo.func_TinhTienDien_SinhHoat(50, 2)
--PRINT dbo.func_TinhTienDien_SinhHoat(100, 1)
--PRINT dbo.func_TinhTienDien_SinhHoat(100, 2)
--PRINT dbo.func_TinhTienDien_SinhHoat(250, 1)
--PRINT dbo.func_TinhTienDien_SinhHoat(250, 2)
--PRINT dbo.func_TinhTienDien_SinhHoat(453, 1)
--PRINT dbo.func_TinhTienDien_SinhHoat(453, 2)

-- LƯU Ý: Nếu điện năng tiêu thụ không theo giờ (thấp điểm, cao điểm) thì lấy @DNTT = @ChiSoMoi - @ChiSoCu
CREATE FUNCTION func_TinhTienDien_ConLai(@MaBangGia VARCHAR(30), @DNTT INT, @ThapDiem INT, @CaoDiem INT, @BinhThuong INT)
--ALTER FUNCTION func_TinhTienDien_ConLai(@MaBangGia VARCHAR(30), @DNTT INT, @ThapDiem INT, @CaoDiem INT, @BinhThuong INT)
RETURNS INT
AS
	BEGIN
		DECLARE @ThanhTien INT, @DonGia INT, @DonGia_BT INT, @DonGia_CD INT, @DonGia_TD INT
		SET @ThanhTien = 0
		-- Bảng giá với nhiều mức giá theo giờ
		IF (SELECT COUNT(MaChiTiet) FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia) > 1
			BEGIN
				SET @DonGia_TD = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia AND MaChiTiet LIKE '*GTD')
				SET @DonGia_CD = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia AND MaChiTiet LIKE '*GCD')
				SET @DonGia_BT = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia AND MaChiTiet LIKE '*GBT')
				SET @ThanhTien = @ThanhTien + @ThapDiem * @DonGia_TD
				SET @ThanhTien = @ThanhTien + @CaoDiem * @DonGia_CD
				SET @ThanhTien = @ThanhTien + @BinhThuong * @DonGia_BT
			END
		-- Bảng giá chỉ với một mức giá
		ELSE
			BEGIN
				SET @DonGia = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia)
				SET @ThanhTien = @ThanhTien + @DNTT * @DonGia
			END
		RETURN @ThanhTien
	END
GO

CREATE FUNCTION func_TinhTienDien_ApGia (@ID INT, @DienNangTieuThu INT, @SoHo TINYINT)
--ALTER FUNCTION func_TinhTienDien_ApGia (@MaChiTiet VARCHAR(30), @DienNangTieuThu INT, @SoHo TINYINT)
RETURNS INT
AS
	BEGIN
		DECLARE @ThanhTien INT, @ID INT
		SET @ThanhTien = 0
		SELECT * FROM view_BangDienApGia 
		RETURN @ThanhTien
	END
GO

CREATE VIEW view_BangDien
--ALTER VIEW view_BangDien
AS
	SELECT ID, D.MaKhachHang, B.MaBangGia, Thue, SoHo, NgayBatDau, NgayKetThuc, ChiSoMoi, ChiSoCu, ThapDiem, CaoDiem, BinhThuong
	FROM DienNangTieuThu D, KhachHang K, BangGia B
	WHERE D.MaKhachHang = K.MaKhachHang AND K.MaBangGia = B.MaBangGia
GO

CREATE PROCEDURE proc_TinhTienDien_DienNangTieuThu
--ALTER PROCEDURE proc_TinhTienDien_DienNangTieuThu
	@NgayBatDau DATETIME,
	@NgayKetThuc DATETIME,
	@MaQuanLy VARCHAR(30)
AS
	BEGIN
		DECLARE @DonGia INT, @ID INT, @MaBangGia VARCHAR(30), @ChiSoMoi INT, @ChiSoCu INT, @ThapDiem INT, @CaoDiem INT, @BinhThuong INT,
			@MaChiTiet VARCHAR(30), @TongTienTruocVAT INT, @VAT INT, @SoHo TINYINT, @Thue DECIMAL(3, 2)
		DECLARE csrDienNangTieuThu CURSOR FOR SELECT ID, MaBangGia, SoHo, Thue, ChiSoMoi, ChiSoCu, ThapDiem, CaoDiem, BinhThuong FROM view_BangDien WHERE NgayBatDau = @NgayBatDau AND NgayKetThuc = @NgayKetThuc
		OPEN csrDienNangTieuThu
		FETCH NEXT FROM csrDienNangTieuThu INTO @ID, @MaBangGia, @SoHo, @Thue, @ChiSoMoi, @ChiSoCu, @ThapDiem, @CaoDiem, @BinhThuong
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @MaBangGia = 'SH-THUONG'
				SET @TongTienTruocVAT = dbo.func_TinhTienDien_SinhHoat(@ChiSoMoi - @ChiSoCu, @SoHo);
			ELSE IF @MaBangGia = 'APGIA'
				SET @TongTienTruocVAT = dbo.func_TinhTienDien_ApGia(@ID, @ChiSoMoi - @ChiSoCu, @SoHo);
			ELSE
				SET @TongTienTruocVAT = dbo.func_TinhTienDien_ConLai(@MaBangGia, @ChiSoMoi - @ChiSoCu, @ThapDiem, @CaoDiem, @BinhThuong);
			SET @VAT = CONVERT(INT, ROUND(@TongTienTruocVAT * @Thue, 0));
			UPDATE DienNangTieuThu
			SET TongTienTruocVAT = @TongTienTruocVAT, TongTienSauVAT = @TongTienTruocVAT + @VAT, NgayCapNhat = GETDATE(), NguoiCapNhat = @MaQuanLy
			WHERE ID = @ID
			FETCH NEXT FROM csrDienNangTieuThu INTO @ID, @MaBangGia, @SoHo, @Thue, @ChiSoMoi, @ChiSoCu, @ThapDiem, @CaoDiem, @BinhThuong;
		END
		CLOSE csrDienNangTieuThu
		DEALLOCATE csrDienNangTieuThu
	END
GO

--EXEC proc_TinhTienDien_DienNangTieuThu '2020/12/13', '2021/01/13', 'GIAMDOC'