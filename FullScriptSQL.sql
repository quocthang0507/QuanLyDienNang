USE [master]
GO
/****** Object:  Database [QuanLyDienNang]    Script Date: 1/11/2021 7:40:21 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[func_GenerateID_KhachHang]    Script Date: 1/11/2021 7:40:22 PM ******/
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
		SET @MA = 'KH' + RIGHT('00000000' + CAST (@ID AS VARCHAR(8)), 8)
		RETURN @MA
	END
GO
/****** Object:  Table [dbo].[BangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangGia](
	[MaBangGia] [varchar](20) NOT NULL,
	[TenBangGia] [nvarchar](150) NOT NULL,
	[Thue] [decimal](3, 2) NOT NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBangGia](
	[MaChiTiet] [varchar](30) NOT NULL,
	[MaBangGia] [varchar](20) NULL,
	[BatDau] [int] NOT NULL,
	[KetThuc] [int] NOT NULL,
	[DonGia] [int] NOT NULL,
	[MoTa] [nvarchar](250) NULL,
	[ApGia] [bit] NOT NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangDienApGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDienApGia](
	[MaChiTiet] [varchar](30) NOT NULL,
	[MaBangGia] [varchar](20) NOT NULL,
	[TyLe] [decimal](3, 2) NOT NULL,
	[KichHoat] [bit] NULL,
 CONSTRAINT [PK_BangDienApGia] PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC,
	[MaBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_BangDienApGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_BangDienApGia]
AS
	SELECT BG.MaBangGia, CT.MaChiTiet, TenBangGia, TyLe, AG.KichHoat FROM BangGia BG, ChiTietBangGia CT, BangDienApGia AG WHERE BG.MaBangGia = AG.MaBangGia AND CT.MaChiTiet = AG.MaChiTiet
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [char](10) NOT NULL,
	[HoVaTen] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[MaChiTietBangGia] [varchar](30) NULL,
	[MaTram] [varchar](20) NULL,
	[SoHo] [tinyint] NOT NULL,
	[HeSoNhan] [tinyint] NOT NULL,
	[MaSoThue] [varchar](20) NULL,
	[SoDienThoai] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [varchar](20) NULL,
	[NgayCapNhat] [datetime] NOT NULL,
	[NguoiCapNhat] [varchar](20) NULL,
	[MaSoHopDong] [nvarchar](20) NULL,
	[NgayHopDong] [datetime] NULL,
	[MaCongTo] [nvarchar](20) NULL,
	[SoNganHang] [varchar](20) NULL,
	[TenNganHang] [nvarchar](150) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DienNangTieuThu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [char](10) NOT NULL,
	[NgayGhi] [datetime] NULL,
	[NguoiGhi] [varchar](20) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [varchar](20) NULL,
	[NgayHoaDon] [datetime] NULL,
	[NgayTraTien] [datetime] NULL,
	[ChiSoMoi] [int] NULL,
	[ChiSoCu] [int] NULL,
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
/****** Object:  View [dbo].[View_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DienNangTieuThu]
--ALTER VIEW View_DienNangTieuThu
AS
	SELECT ID, D.MaKhachHang, HoVaTen, DiaChi, MaTram, MaChiTietBangGia, NgayGhi, NguoiGhi, NgayBatDau, NgayKetThuc, D.NgayCapNhat, D.NguoiCapNhat, NgayHoaDon, NgayTraTien, ChiSoMoi, ChiSoCu, TongTienTruocVAT, TongTienSauVAT, DaTra, ConLai
	FROM DienNangTieuThu D, KhachHang K
	WHERE D.MaKhachHang = K.MaKhachHang
GO
/****** Object:  Table [dbo].[NguoiQuanLy]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiQuanLy](
	[MaQuanLy] [varchar](20) NOT NULL,
	[TenQuanLy] [nvarchar](100) NOT NULL,
	[SoDienThoai] [varchar](20) NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuanLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TramBienAp]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TramBienAp](
	[MaTram] [varchar](20) NOT NULL,
	[TenTram] [nvarchar](150) NOT NULL,
	[DiaChi] [nvarchar](250) NULL,
	[NguoiPhuTrach] [nvarchar](100) NULL,
	[MaSoCongTo] [nvarchar](20) NULL,
	[HeSoNhan] [tinyint] NOT NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'APGIA', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'BN-TT', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'BV-TH', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'CHIEUSANG', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'HC-SN', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'KD-DV', CAST(0.40 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SH-NGHEO', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SH-THUONG', CAST(0.50 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'SX', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'APGIA', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'BN-TT', CAST(0.50 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'BV-TH', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'CHIEUSANG', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'HC-SN', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'KD-DV', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'SH-NGHEO', CAST(0.00 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'SH-THUONG', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangDienApGia] ([MaChiTiet], [MaBangGia], [TyLe], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'SX', CAST(0.30 AS Decimal(3, 2)), 1)
GO
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'APGIA', N'Bảng điện áp giá phần trăm', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'BN-TT', N'Điện cho bơm nước, tưới tiêu', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'BV-TH', N'Điện cho bệnh viện, trường học', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'CHIEUSANG', N'Điện chiếu sáng công cộng', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'HC-SN', N'Điện hành chính, sự nghiệp', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'KD-DV', N'Điện kinh doanh - dịch vụ', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'SH-NGHEO', N'Điện sinh hoạt (hộ nghèo)', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'SH-THUONG', N'Điện sinh hoạt (hộ thường)', CAST(0.10 AS Decimal(3, 2)), 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [Thue], [KichHoat]) VALUES (N'SX', N'Điện sản xuất', CAST(0.10 AS Decimal(3, 2)), 1)
GO
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'10SX-50SH-40KD', N'APGIA', 0, 0, 0, N'10% Sản xuất, 50% Sinh hoạt, 40% Kinh doanh', 1, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'50%BN-10KD-30SX-10SH', N'APGIA', 0, 0, 0, N'50% Bơm nước, 10% Kinh doanh, 30% Sản xuất, 10% Sinh hoạt', 1, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'HCSN-CS-DUOI6KV', N'HC-SN', 0, 0, 1902, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp dưới 6kV', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'HCSN-CS-TREN6KV', N'HC-SN', 0, 0, 1827, N'Chiếu sáng công cộng; đơn vị hành chính sự nghiệp: Cấp điện áp từ 6kV trở lên', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'HCSN-TH-DUOI6KV', N'HC-SN', 0, 0, 1771, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp dưới 6kV', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'HCSN-TH-TREN6KV', N'HC-SN', 0, 0, 1659, N'Bệnh viện, nhà trẻ, mẫu giáo, trường phổ thông: Cấp điện áp từ 6kV trở lên', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-6KV-22KV-GBT', N'KD-DV', 0, 0, 2629, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-6KV-22KV-GCD', N'KD-DV', 0, 0, 4400, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-6KV-22KV-GTD', N'KD-DV', 0, 0, 1547, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-DUOI6KV-GBT', N'KD-DV', 0, 0, 2666, N'Cấp điện áp dưới 6kV: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-DUOI6KV-GCD', N'KD-DV', 0, 0, 4587, N'Cấp điện áp dưới 6kV: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-DUOI6KV-GTD', N'KD-DV', 0, 0, 1622, N'Cấp điện áp dưới 6kV: Giờ thấp điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-TREN22KV-GBT', N'KD-DV', 0, 0, 2442, N'Cấp điện áp từ 22kV trở lên: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-TREN22KV-GCD', N'KD-DV', 0, 0, 4251, N'Cấp điện áp từ 22kV trở lên: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'KDDV-TREN22KV-GTD', N'KD-DV', 0, 0, 1361, N'Cấp điện áp từ 22kV trở lên: Giờ thấp điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SH-TH-BAC1', N'SH-THUONG', 0, 50, 1678, N'Bậc 1: Cho kWh từ 0 - 50', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SH-TH-BAC2', N'SH-THUONG', 51, 100, 1734, N'Bậc 2: Cho kWh từ 51 - 100', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SH-TH-BAC3', N'SH-THUONG', 101, 200, 2014, N'Bậc 3: Cho kWh từ 101 - 200', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SH-TH-BAC4', N'SH-THUONG', 201, 300, 2536, N'Bậc 4: Cho kWh từ 201 - 300', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SH-TH-BAC5', N'SH-THUONG', 301, 400, 2834, N'Bậc 5: Cho kWh từ 301 - 400', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SH-TH-BAC6', N'SH-THUONG', 401, 0, 2927, N'Bậc 6: Cho kWh từ 401 trở lên', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-22KV-110KV-GBT', N'SX', 0, 0, 1555, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-22KV-110KV-GCD', N'SX', 0, 0, 2871, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-22KV-110KV-GTD', N'SX', 0, 0, 1007, N'Cấp điện áp từ 22kV đến dưới 110kV: Giờ thấp điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-6KV-22KV-GBT', N'SX', 0, 0, 1611, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-6KV-22KV-GCD', N'SX', 0, 0, 2964, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-6KV-22KV-GTD', N'SX', 0, 0, 1044, N'Cấp điện áp từ 6kV đến dưới 22kV: Giờ thấp điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-DUOI6KV-GBT', N'SX', 0, 0, 1685, N'Cấp điện áp dưới 6kV: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-DUOI6KV-GCD', N'SX', 0, 0, 3076, N'Cấp điện áp dưới 6kV: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-DUOI6KV-GTD', N'SX', 0, 0, 1100, N'Cấp điện áp dưới 6kV: Giờ thấp điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-TREN110KV-GBT', N'SX', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ bình thường', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-TREN110KV-GCD', N'SX', 0, 0, 1536, N'Cấp điện áp 110kV trở lên: Giờ cao điểm', 0, 1)
INSERT [dbo].[ChiTietBangGia] ([MaChiTiet], [MaBangGia], [BatDau], [KetThuc], [DonGia], [MoTa], [ApGia], [KichHoat]) VALUES (N'SX-TREN110KV-GTH', N'SX', 0, 0, 970, N'Cấp điện áp 110kV trở lên: Giờ thấp điểm', 0, 1)
GO
INSERT [dbo].[NguoiQuanLy] ([MaQuanLy], [TenQuanLy], [SoDienThoai], [DiaChi], [Email], [KichHoat]) VALUES (N'GIAMDOC', N'La Quốc Thắng', N'0987610260', N'Đà Lạt - Lâm Đồng', N'quocthang_0507@yahoo.com.vn', 1)
GO
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA001', N'Trạm biến áp 1', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA002', N'Trạm biến áp 2', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA003', N'Trạm biến áp 3', NULL, NULL, NULL, 1, 1)
GO
ALTER TABLE [dbo].[BangDienApGia] ADD  DEFAULT ((0.0)) FOR [TyLe]
GO
ALTER TABLE [dbo].[BangDienApGia] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[BangGia] ADD  DEFAULT ((0.1)) FOR [Thue]
GO
ALTER TABLE [dbo].[BangGia] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((0)) FOR [BatDau]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((0)) FOR [KetThuc]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((0)) FOR [ApGia]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [ChiSoMoi]
GO
ALTER TABLE [dbo].[DienNangTieuThu] ADD  DEFAULT ((0)) FOR [ChiSoCu]
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
ALTER TABLE [dbo].[BangDienApGia]  WITH CHECK ADD FOREIGN KEY([MaChiTiet])
REFERENCES [dbo].[ChiTietBangGia] ([MaChiTiet])
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
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([MaChiTietBangGia])
REFERENCES [dbo].[ChiTietBangGia] ([MaChiTiet])
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
/****** Object:  StoredProcedure [dbo].[proc_CreateNew_BangDienApGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_CreateNew_BangDienApGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Delete_BangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_BangGia]
--ALTER PROCEDURE proc_Delete_BangGia
	@MaBangGia varchar(20)
AS
	UPDATE BangGia
	SET KichHoat = 0
	WHERE MaBangGia = @MaBangGia
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_ChiTietBangGia]
--ALTER PROCEDURE proc_Delete_ChiTietBangGia
	@MaChiTiet varchar(30)
AS
	UPDATE ChiTietBangGia
	SET KichHoat = 0
	WHERE MaChiTiet = @MaChiTiet
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_Delete_KhachHang]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_KhachHang]
--ALTER PROCEDURE proc_Delete_KhachHang
	@MaKhachHang char(10)
AS
	UPDATE KhachHang
	SET KichHoat = 0
	WHERE MaKhachHang = @MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_NguoiQuanLy]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_NguoiQuanLy]
--ALTER PROCEDURE proc_Delete_NguoiQuanLy
	@MaQuanLy varchar(10)
AS
	UPDATE NguoiQuanLy
	SET KichHoat = 0
	WHERE MaQuanLy = @MaQuanLy
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_TramBienAp]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_TramBienAp]
--ALTER PROCEDURE proc_Delete_TramBienAp
	@MaTram varchar(20)
AS
	UPDATE TramBienAp
	SET KichHoat = 0
	WHERE MaTram = @MaTram
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_BangDienApGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_BangDienApGia]
	@MaChiTiet varchar(30)
AS
	SELECT * FROM view_BangDienApGia WHERE MaChiTiet = @MaChiTiet
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_BangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_BangGia]
--ALTER PROCEDURE proc_GetAll_BangGia
AS
	SELECT * FROM BangGia ORDER BY KichHoat DESC, MaBangGia ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_ChiTietBangGia]
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
AS
	SELECT * FROM ChiTietBangGia ORDER BY KichHoat DESC, ApGia ASC, MaChiTiet ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_DienNangTieuThu]
--ALTER PROCEDURE proc_GetAll_DienNangTieuThu
AS
	SELECT * FROM View_DienNangTieuThu
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_KhachHang]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_KhachHang]
--ALTER PROCEDURE proc_GetAll_KhachHang
AS
	SELECT * FROM KhachHang WHERE KichHoat = 1 ORDER BY MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_NguoiQuanLy]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_NguoiQuanLy]
--ALTER PROCEDURE proc_GetAll_NguoiQuanLy
AS
	SELECT * FROM NguoiQuanLy ORDER BY KichHoat DESC, MaQuanLy ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_TramBienAp]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_TramBienAp]
--ALTER PROCEDURE proc_GetAll_TramBienAp
AS
	SELECT * FROM TramBienAp WHERE KichHoat = 1
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByBangGia_ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetByBangGia_ChiTietBangGia]
--ALTER PROCEDURE proc_GetAll_ChiTietBangGia
	@MaBangGia varchar(20)
AS
	SELECT * FROM ChiTietBangGia WHERE MaBangGia = @MaBangGia ORDER BY KichHoat DESC, MaChiTiet ASC
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByDate_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_BangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_BangGia]
--ALTER PROCEDURE proc_Insert_BangGia
	@MaBangGia varchar(20),
	@TenBangGia nvarchar(150),
	@Thue decimal(3,2)
AS
	INSERT INTO BangGia (MaBangGia, TenBangGia, Thue) VALUES (@MaBangGia, @TenBangGia, @Thue)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_ChiTietBangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_DienNangTieuThu]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_DienNangTieuThu_Test]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_DienNangTieuThu_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_KhachHang]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_KhachHang]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_KhachHang_Test]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_KhachHang_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_NguoiQuanLy]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_NguoiQuanLy]
--ALTER PROCEDURE proc_Insert_NguoiQuanLy
	@MaQuanLy varchar(20),
	@TenQuanLy nvarchar(100),
	@SoDienThoai varchar(20),
	@DiaChi nvarchar(250),
	@Email nvarchar(100)
AS
	INSERT INTO NguoiQuanLy VALUES (@MaQuanLy, @TenQuanLy, @SoDienThoai, @DiaChi, @Email, 1)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_TramBienAp]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_TramBienAp]
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
/****** Object:  StoredProcedure [dbo].[proc_IsDuplicated_MaBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_IsDuplicated_MaBangGia]
--ALTER PROCEDURE proc_IsDuplicated_MaBangGia
	@MaBangGia varchar(20)
AS
	IF EXISTS (SELECT * FROM BangGia WHERE MaBangGia = @MaBangGia)
		RETURN 1
	ELSE
		RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[proc_IsDuplicated_MaQuanLy]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_IsDuplicated_MaQuanLy]
--ALTER PROCEDURE proc_IsDuplicated_MaQuanLy
	@MaQuanLy varchar(10)
AS
	IF EXISTS (SELECT * FROM NguoiQuanLy WHERE MaQuanLy = @MaQuanLy)
		RETURN 1
	ELSE
		RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[proc_IsDuplicated_MaTram]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_IsDuplicated_MaTram]
--ALTER PROCEDURE proc_IsDuplicated_MaTram
	@MaTram varchar(20)
AS
	IF EXISTS (SELECT * FROM TramBienAp WHERE MaTram = @MaTram)
		RETURN 1
	ELSE
		RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[proc_Reset_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Reset_DienNangTieuThu]
AS
	DELETE FROM DienNangTieuThu
	DBCC CHECKIDENT ('[DienNangTieuThu]', RESEED, 0);
GO
/****** Object:  StoredProcedure [dbo].[proc_Update_BangDienApGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_BangDienApGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_BangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_BangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_ChiTietBangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_DienNangTieuThu]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_DienNangTieuThu]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_DienNangTieuThu_Test]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_DienNangTieuThu_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_KhachHang]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_KhachHang]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_KhachHang_Test]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_KhachHang_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_NguoiQuanLy]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_NguoiQuanLy]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_TramBienAp]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_TramBienAp]
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
/****** Object:  Trigger [dbo].[trigger_BangDienApGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trigger_BangDienApGia] ON [dbo].[BangDienApGia] FOR INSERT, UPDATE
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
ALTER TABLE [dbo].[BangDienApGia] ENABLE TRIGGER [trigger_BangDienApGia]
GO
/****** Object:  Trigger [dbo].[trigger_BangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trigger_BangGia] ON [dbo].[BangGia] FOR INSERT, UPDATE
AS
	IF UPDATE(Thue)
		IF EXISTS (SELECT * FROM inserted WHERE Thue > 1 OR Thue < 0)
		BEGIN
			RAISERROR (N'Thuế GTGT (VAT) trên một bảng giá không được quá 1 hoặc nhỏ hơn 0', 15, 1)
			ROLLBACK TRAN
		END
GO
ALTER TABLE [dbo].[BangGia] ENABLE TRIGGER [trigger_BangGia]
GO
/****** Object:  Trigger [dbo].[trigger_ChiTietBangGia]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trigger_ChiTietBangGia] ON [dbo].[ChiTietBangGia] FOR INSERT, UPDATE
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
ALTER TABLE [dbo].[ChiTietBangGia] ENABLE TRIGGER [trigger_ChiTietBangGia]
GO
/****** Object:  Trigger [dbo].[trigger_TramBienAp]    Script Date: 1/11/2021 7:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trigger_TramBienAp] ON [dbo].[TramBienAp] FOR INSERT, UPDATE
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
ALTER TABLE [dbo].[TramBienAp] ENABLE TRIGGER [trigger_TramBienAp]
GO
USE [master]
GO
ALTER DATABASE [QuanLyDienNang] SET  READ_WRITE 
GO
