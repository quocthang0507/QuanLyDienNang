USE [master]
GO
/****** Object:  Database [QuanLyDienNang]    Script Date: 1/22/2021 9:34:07 PM ******/
CREATE DATABASE [QuanLyDienNang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyDienNang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyDienNang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyDienNang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyDienNang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyDienNang] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyDienNang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyDienNang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyDienNang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyDienNang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyDienNang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyDienNang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyDienNang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyDienNang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyDienNang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyDienNang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyDienNang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyDienNang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyDienNang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyDienNang] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyDienNang] SET QUERY_STORE = OFF
GO
USE [QuanLyDienNang]
GO
/****** Object:  UserDefinedFunction [dbo].[func_GenerateID_KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[func_GenerateID_KhachHang]()
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
/****** Object:  UserDefinedFunction [dbo].[func_TinhTienDien_ApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[func_TinhTienDien_ApGia] (@MaApGia VARCHAR(30), @DienNangTieuThu INT, @SoHo TINYINT)
RETURNS INT
AS
	BEGIN
		DECLARE @ThanhTien INT, @MaBangGia VARCHAR(30), @_TyLe_ DECIMAL(3,2), @_DienNangTieuThu_ INT
		SET @ThanhTien = 0
		DECLARE csrBangApGia CURSOR FOR SELECT MaBangGia, TyLe FROM view_BangDienApGia WHERE TyLe > 0 AND MaApGia = @MaApGia
		OPEN csrBangApGia
		FETCH NEXT FROM csrBangApGia INTO @MaBangGia, @_TyLe_
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @_DienNangTieuThu_ = @DienNangTieuThu * @_TyLe_;
			IF @MaBangGia = 'SH-THUONG'
				SET @ThanhTien = @ThanhTien + dbo.func_TinhTienDien_SinhHoat(@_DienNangTieuThu_, @SoHo);
			ELSE
				SET @ThanhTien = @ThanhTien + dbo.func_TinhTienDien_ConLai(@MaBangGia, @_DienNangTieuThu_, 0, 0, 0);
			FETCH NEXT FROM csrBangApGia INTO @MaBangGia, @_TyLe_
		END
		CLOSE csrBangApGia
		DEALLOCATE csrBangApGia
		RETURN @ThanhTien
	END
GO
/****** Object:  UserDefinedFunction [dbo].[func_TinhTienDien_ConLai]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
CREATE FUNCTION [dbo].[func_TinhTienDien_ConLai](@MaBangGia VARCHAR(30), @DNTT INT, @ThapDiem INT, @CaoDiem INT, @BinhThuong INT)
--ALTER FUNCTION func_TinhTienDien_ConLai(@MaBangGia VARCHAR(30), @DNTT INT, @ThapDiem INT, @CaoDiem INT, @BinhThuong INT)
RETURNS INT
AS
	BEGIN
		DECLARE @ThanhTien INT, @DonGia INT, @DonGia_BT INT, @DonGia_CD INT, @DonGia_TD INT
		SET @ThanhTien = 0
		-- Bảng giá với nhiều mức giá theo giờ
		IF (SELECT COUNT(MaChiTiet) FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia) > 1
			BEGIN
				SET @DonGia_TD = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia AND MaChiTiet LIKE '%GTD')
				SET @DonGia_CD = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia AND MaChiTiet LIKE '%GCD')
				SET @DonGia_BT = (SELECT DonGia FROM view_BangDienConLai WHERE MaBangGia = @MaBangGia AND MaChiTiet LIKE '%GBT')
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
/****** Object:  UserDefinedFunction [dbo].[func_TinhTienDien_SinhHoat]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[func_TinhTienDien_SinhHoat] (@DienNangTieuThu INT, @SoHo TINYINT)
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
/****** Object:  Table [dbo].[ChiTietBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBangGia](
	[MaChiTiet] [varchar](30) NOT NULL,
	[MaBangGia] [varchar](30) NULL,
	[BatDau] [int] NOT NULL,
	[KetThuc] [int] NOT NULL,
	[DonGia] [int] NOT NULL,
	[MoTa] [nvarchar](250) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_BangDienSinhHoat]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_BangDienSinhHoat]
--ALTER VIEW view_BangDienSinhHoat
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = 'SH-THUONG' AND KichHoat = 1
GO
/****** Object:  View [dbo].[view_BangDienConLai]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Bỏ qua bảng giá điện sinh hoạt và bảng giá điện áp giá
CREATE VIEW [dbo].[view_BangDienConLai]
--ALTER VIEW view_BangDienConLai
AS
	SELECT * FROM ChiTietBangGia 
	WHERE MaBangGia NOT LIKE 'SH%' AND MaBangGia NOT LIKE 'APGIA' AND KichHoat = 1
GO
/****** Object:  Table [dbo].[BangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangGia](
	[MaBangGia] [varchar](30) NOT NULL,
	[TenBangGia] [nvarchar](150) NOT NULL,
	[Thue] [decimal](3, 2) NOT NULL,
	[ApGia] [bit] NOT NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [char](10) NOT NULL,
	[HoVaTen] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[MaBangGia] [varchar](30) NULL,
	[MaTram] [varchar](30) NULL,
	[SoHo] [tinyint] NOT NULL,
	[HeSoNhan] [tinyint] NOT NULL,
	[MaSoThue] [nvarchar](30) NULL,
	[SoDienThoai] [nvarchar](30) NULL,
	[Email] [nvarchar](100) NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [varchar](30) NULL,
	[NgayCapNhat] [datetime] NOT NULL,
	[NguoiCapNhat] [varchar](30) NULL,
	[MaSoHopDong] [nvarchar](30) NULL,
	[NgayHopDong] [datetime] NULL,
	[MaCongTo] [nvarchar](30) NULL,
	[SoNganHang] [nvarchar](30) NULL,
	[TenNganHang] [nvarchar](150) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DienNangTieuThu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [char](10) NOT NULL,
	[NgayGhi] [datetime] NULL,
	[NguoiGhi] [varchar](30) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](30) NULL,
	[NgayHoaDon] [datetime] NULL,
	[NgayTraTien] [datetime] NULL,
	[ChiSoMoi] [int] NULL,
	[ChiSoCu] [int] NULL,
	[ThapDiem] [int] NULL,
	[CaoDiem] [int] NULL,
	[BinhThuong] [int] NULL,
	[TongTienTruocVAT] [money] NULL,
	[TongTienSauVAT] [money] NULL,
	[DaTra] [money] NULL,
	[ConLai] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_BangDien]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[view_BangDien]
--ALTER VIEW view_BangDien
AS
	SELECT ID, D.MaKhachHang, B.MaBangGia, Thue, SoHo, NgayBatDau, NgayKetThuc, ChiSoMoi, ChiSoCu, ThapDiem, CaoDiem, BinhThuong
	FROM DienNangTieuThu D, KhachHang K, BangGia B
	WHERE D.MaKhachHang = K.MaKhachHang AND K.MaBangGia = B.MaBangGia
GO
/****** Object:  Table [dbo].[BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDienApGia](
	[MaApGia] [varchar](30) NOT NULL,
	[MaBangGia] [varchar](30) NOT NULL,
	[TyLe] [decimal](3, 2) NOT NULL,
	[KichHoat] [bit] NULL,
 CONSTRAINT [pk_BangDienApGia] PRIMARY KEY CLUSTERED 
(
	[MaApGia] ASC,
	[MaBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC proc_CreateNew_BangDienApGia '10SX-50SH-40KD'

CREATE VIEW [dbo].[view_BangDienApGia]
--ALTER VIEW view_BangDienApGia
AS
	SELECT MaApGia, B.MaBangGia, TenBangGia, TyLe, A.KichHoat 
	FROM BangGia B, BangDienApGia A
	WHERE B.MaBangGia = A.MaBangGia
GO
/****** Object:  View [dbo].[View_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DienNangTieuThu]
--ALTER VIEW View_DienNangTieuThu
AS
	SELECT ID, D.MaKhachHang, HoVaTen, DiaChi, MaTram, MaBangGia, NgayGhi, NguoiGhi, NgayBatDau, NgayKetThuc, D.NgayCapNhat, 
	D.NguoiCapNhat, NgayHoaDon, NgayTraTien, ChiSoMoi, ChiSoCu, ThapDiem, CaoDiem, BinhThuong, TongTienTruocVAT, TongTienSauVAT, 
	DaTra, ConLai
	FROM DienNangTieuThu D, KhachHang K
	WHERE D.MaKhachHang = K.MaKhachHang
GO
/****** Object:  Table [dbo].[NguoiQuanLy]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiQuanLy](
	[MaQuanLy] [varchar](30) NOT NULL,
	[TenQuanLy] [nvarchar](100) NOT NULL,
	[SoDienThoai] [varchar](30) NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuanLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TramBienAp]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TramBienAp](
	[MaTram] [varchar](30) NOT NULL,
	[TenTram] [nvarchar](150) NOT NULL,
	[DiaChi] [nvarchar](250) NULL,
	[NguoiPhuTrach] [nvarchar](100) NULL,
	[MaSoCongTo] [varchar](30) NULL,
	[HeSoNhan] [tinyint] NOT NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'BN-TT', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'BV-TH', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'CHIEUSANG', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'HCSN-BVTH-DUOI6KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'HCSN-BVTH-TREN6KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'HCSN-CSCC-DUOI6KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'HCSN-CSCC-TREN6KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'KDDV-6KV-22KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'KDDV-DUOI6KV', CAST(0.40 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'KDDV-TREN22KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SH-NGHEO', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SH-THUONG', CAST(0.50 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SX-22KV-110KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SX-6KV-22KV', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SX-DUOI6KV', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaApGia], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SX-TREN110KV', CAST(0.00 AS Decimal(3, 2)), 1)
GO
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'10% Sản xuất, 50% Sinh hoạt, 40% Kinh doanh', CAST(0.10 AS Decimal(3, 2)), 1, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'50% Bơm nước, 10% Kinh doanh, 30% Sản xuất, 10% Sinh hoạt', CAST(0.10 AS Decimal(3, 2)), 1, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'BN-TT', N'Điện cho bơm nước, tưới tiêu', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'BV-TH', N'Điện cho bệnh viện, trường học', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'CHIEUSANG', N'Điện chiếu sáng công cộng', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'HCSN-BVTH-DUOI6KV', N'Điện hành chính, sự nghiệp: Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông - Cấp điện áp dưới 6kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'HCSN-BVTH-TREN6KV', N'Điện hành chính, sự nghiệp: Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông - Cấp điện áp từ 6kV trở lên', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'HCSN-CSCC-DUOI6KV', N'Điện hành chính, sự nghiệp: Chiếu sáng công cộng; đơn vị hành chính sự nghiệp - Cấp điện áp dưới 6kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'HCSN-CSCC-TREN6KV', N'Điện hành chính, sự nghiệp: Chiếu sáng công cộng; đơn vị hành chính sự nghiệp - Cấp điện áp từ 6kV trở lên', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'KDDV-6KV-22KV', N'Điện kinh doanh - dịch vụ: Cấp điện áp từ 6kV đến dưới 22kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'KDDV-DUOI6KV', N'Điện kinh doanh - dịch vụ: Cấp điện áp dưới 6kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'KDDV-TREN22KV', N'Điện kinh doanh - dịch vụ: Cấp điện áp từ 22kV trở lên', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'SH-NGHEO', N'Điện sinh hoạt (hộ nghèo)', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'SH-THUONG', N'Điện sinh hoạt (hộ thường)', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'SX-22KV-110KV', N'Điện sản xuất, cấp điện áp từ 22kV đến dưới 110kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'SX-6KV-22KV', N'Điện sản xuất, cấp điện áp từ 6kV đến dưới 22kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'SX-DUOI6KV', N'Điện sản xuất, cấp điện áp dưới 6kV', CAST(0.10 AS Decimal(3, 2)), 0, 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [ApGia], [KichHoat]) VALUES (N'SX-TREN110KV', N'Điện sản xuất, cấp điện áp từ 110kV trở lên', CAST(0.10 AS Decimal(3, 2)), 0, 1)
GO
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'HCSN-BVTH-DUOI6KV', N'HCSN-BVTH-DUOI6KV', 0, 0, 1771, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp dưới 6kV', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'HCSN-BVTH-TREN6KV', N'HCSN-BVTH-TREN6KV', 0, 0, 1659, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp từ 6kV trở lên', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'HCSN-CSCC-DUOI6KV', N'HCSN-CSCC-DUOI6KV', 0, 0, 1902, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp dưới 6kV', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'HCSN-CSCC-TREN6KV', N'HCSN-CSCC-TREN6KV', 0, 0, 1827, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp từ 6kV trở lên', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-6KV-22KV-GBT', N'KDDV-6KV-22KV', 0, 0, 2629, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-6KV-22KV-GCD', N'KDDV-6KV-22KV', 0, 0, 4400, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-6KV-22KV-GTD', N'KDDV-6KV-22KV', 0, 0, 1547, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-DUOI6KV-GBT', N'KDDV-DUOI6KV', 0, 0, 2666, N'Cấp điện áp dưới 6kV: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-DUOI6KV-GCD', N'KDDV-DUOI6KV', 0, 0, 4587, N'Cấp điện áp dưới 6kV: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-DUOI6KV-GTD', N'KDDV-DUOI6KV', 0, 0, 1622, N'Cấp điện áp dưới 6kV: Giờ thấp điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-TREN22KV-GBT', N'KDDV-TREN22KV', 0, 0, 2442, N'Cấp điện áp từ 22kV trở lên: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-TREN22KV-GCD', N'KDDV-TREN22KV', 0, 0, 4251, N'Cấp điện áp từ 22kV trở lên: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'KDDV-TREN22KV-GTD', N'KDDV-TREN22KV', 0, 0, 1361, N'Cấp điện áp từ 22kV trở lên: Giờ thấp điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SH-TH-BAC1', N'SH-THUONG', 0, 50, 1678, N'Bậc 1: Cho kWh từ 0 - 50', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SH-TH-BAC2', N'SH-THUONG', 51, 100, 1734, N'Bậc 2: Cho kWh từ 51 - 100', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SH-TH-BAC3', N'SH-THUONG', 101, 200, 2014, N'Bậc 3: Cho kWh từ 101 - 200', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SH-TH-BAC4', N'SH-THUONG', 201, 300, 2536, N'Bậc 4: Cho kWh từ 201 - 300', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SH-TH-BAC5', N'SH-THUONG', 301, 400, 2834, N'Bậc 5: Cho kWh từ 301 - 400', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SH-TH-BAC6', N'SH-THUONG', 401, 0, 2927, N'Bậc 6: Cho kWh từ 401 trở lên', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-22KV-110KV-GBT', N'SX-22KV-110KV', 0, 0, 1555, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-22KV-110KV-GCD', N'SX-22KV-110KV', 0, 0, 2871, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-22KV-110KV-GTD', N'SX-22KV-110KV', 0, 0, 1007, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ thấp điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-6KV-22KV-GBT', N'SX-6KV-22KV', 0, 0, 1611, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-6KV-22KV-GCD', N'SX-6KV-22KV', 0, 0, 2964, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-6KV-22KV-GTD', N'SX-6KV-22KV', 0, 0, 1044, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-DUOI6KV-GBT', N'SX-DUOI6KV', 0, 0, 1685, N'Cấp điện áp dưới 6kV: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-DUOI6KV-GCD', N'SX-DUOI6KV', 0, 0, 3076, N'Cấp điện áp dưới 6kV: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-DUOI6KV-GTD', N'SX-DUOI6KV', 0, 0, 1100, N'Cấp điện áp dưới 6kV: Giờ thấp điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-TREN110KV-GBT', N'SX-TREN110KV', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ bình thường', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-TREN110KV-GCD', N'SX-TREN110KV', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ cao điểm', 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [KichHoat]) VALUES (N'SX-TREN110KV-GTD', N'SX-TREN110KV', 0, 0, 970, N'Cấp điện áp 110kV trở lên: Giờ thấp điểm', 1)
GO
INSERT [dbo].[NguoiQuanLy] ([MaQuanLy], [TenQuanLy], [SoDienThoai], [DiaChi], [Email], [KichHoat]) VALUES (N'GIAMDOC', N'La Quốc Thắng', N'0987610260', N'Đà Lạt - Lâm Đồng', N'quocthang_0507@yahoo.com.vn', 1)
GO
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA001', N'Trạm biến áp 1', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA002', N'Trạm biến áp 2', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA003', N'Trạm biến áp 3', NULL, NULL, NULL, 1, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BangGia__F6D5C621BF7EF508]    Script Date: 1/22/2021 9:34:07 PM ******/
ALTER TABLE [dbo].[BangGia] ADD UNIQUE NONCLUSTERED 
(
	[TenBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TramBien__E339A6EF27177231]    Script Date: 1/22/2021 9:34:07 PM ******/
ALTER TABLE [dbo].[TramBienAp] ADD UNIQUE NONCLUSTERED 
(
	[TenTram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BangDienApGia] ADD  DEFAULT ((0.0)) FOR [TyLe]
GO
ALTER TABLE [dbo].[BangDienApGia] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[BangGia] ADD  DEFAULT ((0.1)) FOR [Thue]
GO
ALTER TABLE [dbo].[BangGia] ADD  DEFAULT ((0)) FOR [ApGia]
GO
ALTER TABLE [dbo].[BangGia] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((0)) FOR [BatDau]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((0)) FOR [KetThuc]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [ChiSoMoi]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [ChiSoCu]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [ThapDiem]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [CaoDiem]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [BinhThuong]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [DaTra]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((1)) FOR [SoHo]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((1)) FOR [HeSoNhan]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[NguoiQuanLy] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[TramBienAp] ADD  DEFAULT ((1)) FOR [HeSoNhan]
GO
ALTER TABLE [dbo].[TramBienAp] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[BangDienApGia]  WITH CHECK ADD FOREIGN KEY([MaBangGia])
REFERENCES [dbo].[BangGia] ([MaBangGia])
GO
ALTER TABLE [dbo].[ChiTietBangGia]  WITH CHECK ADD FOREIGN KEY([MaBangGia])
REFERENCES [dbo].[BangGia] ([MaBangGia])
GO
ALTER TABLE [dbo].[DienNangTieuThu]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[DienNangTieuThu]  WITH CHECK ADD FOREIGN KEY([NguoiGhi])
REFERENCES [dbo].[NguoiQuanLy] ([MaQuanLy])
GO
ALTER TABLE [dbo].[DienNangTieuThu]  WITH CHECK ADD FOREIGN KEY([NguoiCapNhat])
REFERENCES [dbo].[NguoiQuanLy] ([MaQuanLy])
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([MaBangGia])
REFERENCES [dbo].[BangGia] ([MaBangGia])
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([MaTram])
REFERENCES [dbo].[TramBienAp] ([MaTram])
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[NguoiQuanLy] ([MaQuanLy])
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([NguoiCapNhat])
REFERENCES [dbo].[NguoiQuanLy] ([MaQuanLy])
GO
ALTER TABLE [dbo].[BangGia]  WITH CHECK ADD  CONSTRAINT [constraint_Thue] CHECK  (([THUE]<(1) AND [THUE]>=(0)))
GO
ALTER TABLE [dbo].[BangGia] CHECK CONSTRAINT [constraint_Thue]
GO
/****** Object:  StoredProcedure [dbo].[proc_CreateNew_BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC proc_Reset_BangDienApGia

-- Đưa mã bảng giá làm mã bảng áp giá
CREATE PROCEDURE [dbo].[proc_CreateNew_BangDienApGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Delete_BangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Delete_BangGia]
--ALTER PROCEDURE proc_Delete_BangGia
	@MaBangGia VARCHAR(30)
AS
	UPDATE BangGia
	SET KichHoat = 0
	WHERE MaBangGia = @MaBangGia
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_ChiTietBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Delete_ChiTietBangGia]
--ALTER PROCEDURE proc_Delete_ChiTietBangGia
	@MaChiTiet VARCHAR(30)
AS
	UPDATE ChiTietBangGia
	SET KichHoat = 0
	WHERE MaChiTiet = @MaChiTiet
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Delete_DienNangTieuThu]
	@ID INT
AS
	DELETE FROM DienNangTieuThu
	WHERE ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Delete_KhachHang]
--ALTER PROCEDURE proc_Delete_KhachHang
	@MaKhachHang CHAR(10)
AS
	UPDATE KhachHang
	SET KichHoat = 0
	WHERE MaKhachHang = @MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_NguoiQuanLy]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Delete_NguoiQuanLy]
--ALTER PROCEDURE proc_Delete_NguoiQuanLy
	@MaQuanLy VARCHAR(30)
AS
	UPDATE NguoiQuanLy
	SET KichHoat = 0
	WHERE MaQuanLy = @MaQuanLy
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_TramBienAp]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Delete_TramBienAp]
--ALTER PROCEDURE proc_Delete_TramBienAp
	@MaTram VARCHAR(30)
AS
	UPDATE TramBienAp
	SET KichHoat = 0
	WHERE MaTram = @MaTram
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetAll_BangDienApGia]
--ALTER PROCEDURE proc_GetAll_BangDienApGia
	@MaApGia VARCHAR(30)
AS
	SELECT * FROM view_BangDienApGia WHERE MaApGia = @MaApGia
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_BangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetAll_BangGia]
--ALTER PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia ORDER BY KichHoat DESC, MaBangGia ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_ChiTietBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetAll_ChiTietBangGia]
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia ORDER BY KichHoat DESC, MaChiTiet ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetAll_DienNangTieuThu]
--ALTER PROCEDURE proc_GetAll_DienNangTieuThu
AS
	SELECT * FROM View_DienNangTieuThu
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_KhachHang]
--ALTER PROCEDURE proc_GetAll_KhachHang
AS
	SELECT * FROM KhachHang WHERE KichHoat = 1 ORDER BY MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_NguoiQuanLy]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetAll_NguoiQuanLy]
--ALTER PROCEDURE proc_GetAll_NguoiQuanLy
AS
	SELECT * FROM NguoiQuanLy ORDER BY KichHoat DESC, MaQuanLy ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_TramBienAp]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetAll_TramBienAp]
--ALTER PROCEDURE proc_GetAll_TramBienAp
AS
	SELECT * FROM TramBienAp WHERE KichHoat = 1
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByBangGia_ChiTietBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetByBangGia_ChiTietBangGia]
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
	@MaBangGia VARCHAR(30)
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = @MaBangGia ORDER BY KichHoat DESC, MaChiTiet ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByDate_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetByDate_DienNangTieuThu]
--ALTER PROCEDURE proc_GetByDate_DienNangTieuThu
	@MONTH TINYINT,
	@YEAR INT
AS
	SELECT * FROM View_DienNangTieuThu WHERE MONTH(NgayKetThuc) = @MONTH AND YEAR(NgayKetThuc) = @YEAR
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByID_KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetByID_KhachHang]
--ALTER PROCEDURE proc_GetByID_KhachHang
	@MaKhachHang CHAR(10)
AS
	SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByName_BangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetByName_BangGia]
--ALTER PROCEDURE proc_GetByName_BangGia
	@TenBangGia NVARCHAR(150)
AS
	SELECT * FROM BangGia WHERE TenBangGia = @TenBangGia
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByName_TramBienAp]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_GetByName_TramBienAp]
--ALTER PROCEDURE proc_GetByName_TramBienAp
	@TenTram NVARCHAR(150)
AS
	SELECT * FROM TramBienAp WHERE TenTram = @TenTram
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_BangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_BangGia]
--ALTER PROCEDURE proc_Insert_BangGia
	@MaBangGia VARCHAR(30),
	@TenBangGia NVARCHAR(150),
	@Thue DECIMAL(3,2),
	@ApGia BIT
AS
	INSERT INTO BangGia (MaBangGia, TenBangGia, Thue, ApGia) VALUES (@MaBangGia, @TenBangGia, @Thue, @ApGia)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_ChiTietBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_ChiTietBangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_DienNangTieuThu]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_DienNangTieuThu_Test]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_DienNangTieuThu_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
PRINT DBO.func_GenerateID_KhachHang()
*/

CREATE PROCEDURE [dbo].[proc_Insert_KhachHang]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_KhachHang_Test]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_KhachHang_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_NguoiQuanLy]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_NguoiQuanLy]
--ALTER PROCEDURE proc_Insert_NguoiQuanLy
	@MaQuanLy VARCHAR(30),
	@TenQuanLy NVARCHAR(100),
	@SoDienThoai NVARCHAR(30),
	@DiaChi NVARCHAR(250),
	@Email NVARCHAR(100)
AS
	INSERT INTO NguoiQuanLy VALUES (@MaQuanLy, @TenQuanLy, @SoDienThoai, @DiaChi, @Email, 1)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_TramBienAp]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Insert_TramBienAp]
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
/****** Object:  StoredProcedure [dbo].[proc_IsDuplicated_MaBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_IsDuplicated_MaBangGia]
--ALTER PROCEDURE proc_IsDuplicated_MaBangGia
	@MaBangGia VARCHAR(30)
AS
	IF EXISTS (SELECT * FROM BangGia WHERE MaBangGia = @MaBangGia)
		RETURN 1
	ELSE
		RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[proc_IsDuplicated_MaQuanLy]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_IsDuplicated_MaQuanLy]
--ALTER PROCEDURE proc_IsDuplicated_MaQuanLy
	@MaQuanLy VARCHAR(10)
AS
	IF EXISTS (SELECT * FROM NguoiQuanLy WHERE MaQuanLy = @MaQuanLy)
		RETURN 1
	ELSE
		RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[proc_IsDuplicated_MaTram]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_IsDuplicated_MaTram]
--ALTER PROCEDURE proc_IsDuplicated_MaTram
	@MaTram VARCHAR(30)
AS
	IF EXISTS (SELECT * FROM TramBienAp WHERE MaTram = @MaTram)
		RETURN 1
	ELSE
		RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[proc_Reset_BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Reset_BangDienApGia]
AS
	DELETE FROM BangDienApGia
	DBCC CHECKIDENT ('[BangDienApGia]', RESEED, 0);
GO
/****** Object:  StoredProcedure [dbo].[proc_Reset_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Reset_DienNangTieuThu]
AS
	DELETE FROM DienNangTieuThu
	DBCC CHECKIDENT ('[DienNangTieuThu]', RESEED, 0);
GO
/****** Object:  StoredProcedure [dbo].[proc_TinhTienDien_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_TinhTienDien_DienNangTieuThu]
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
				SET @TongTienTruocVAT = dbo.func_TinhTienDien_ApGia(@MaBangGia, @ChiSoMoi - @ChiSoCu, @SoHo);
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
/****** Object:  StoredProcedure [dbo].[proc_Update_BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_BangDienApGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_BangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_BangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_ChiTietBangGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_ChiTietBangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_DienNangTieuThu]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC proc_Reset_DienNangTieuThu

CREATE PROCEDURE [dbo].[proc_Update_DienNangTieuThu]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_DienNangTieuThu_Test]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_DienNangTieuThu_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_KhachHang]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_KhachHang]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_KhachHang_Test]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_KhachHang_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_NguoiQuanLy]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_NguoiQuanLy]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_TramBienAp]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Update_TramBienAp]
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
/****** Object:  Trigger [dbo].[trigger_BangDienApGia]    Script Date: 1/22/2021 9:34:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trigger_BangDienApGia] ON [dbo].[BangDienApGia] FOR INSERT, UPDATE
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
ALTER TABLE [dbo].[BangDienApGia] ENABLE TRIGGER [trigger_BangDienApGia]
GO
/****** Object:  Trigger [dbo].[trigger_ChiTietBangGia]    Script Date: 1/22/2021 9:34:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trigger_ChiTietBangGia] ON [dbo].[ChiTietBangGia] FOR INSERT, UPDATE
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
ALTER TABLE [dbo].[ChiTietBangGia] ENABLE TRIGGER [trigger_ChiTietBangGia]
GO
/****** Object:  Trigger [dbo].[trigger_TramBienAp]    Script Date: 1/22/2021 9:34:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trigger_TramBienAp] ON [dbo].[TramBienAp] FOR INSERT, UPDATE
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
ALTER TABLE [dbo].[TramBienAp] ENABLE TRIGGER [trigger_TramBienAp]
GO
USE [master]
GO
ALTER DATABASE [QuanLyDienNang] SET  READ_WRITE 
GO
