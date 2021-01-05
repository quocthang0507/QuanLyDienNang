USE [master]
GO
/****** Object:  Database [QuanLyDienNang]    Script Date: 1/5/2021 9:34:28 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[func_GenerateID_KhachHang]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[func_GenerateID_KhachHang]()
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
/****** Object:  UserDefinedFunction [dbo].[func_GenerateID_NguoiQuanLy]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[func_GenerateID_NguoiQuanLy]()
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [char](9) NOT NULL,
	[HoVaTen] [nvarchar](150) NOT NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[MaBangGia] [char](5) NULL,
	[MaTram] [char](5) NULL,
	[SoHo] [tinyint] NOT NULL,
	[HeSoNhan] [tinyint] NOT NULL,
	[MaSoThue] [varchar](20) NULL,
	[SoDienThoai] [varchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [char](5) NULL,
	[NgayCapNhat] [datetime] NOT NULL,
	[NguoiCapNhat] [char](5) NULL,
	[MaSoHopDong] [nvarchar](20) NULL,
	[NgayHopDong] [datetime] NULL,
	[MaCongTo] [nvarchar](20) NULL,
	[SoNganHang] [varchar](20) NULL,
	[TenNganHang] [nvarchar](100) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DienNangTieuThu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [char](9) NOT NULL,
	[NgayGhi] [datetime] NULL,
	[NguoiGhi] [char](5) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NguoiCapNhat] [char](5) NULL,
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
/****** Object:  View [dbo].[View_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_DienNangTieuThu]
AS
	SELECT ID, D.MaKhachHang, HoVaTen, DiaChi, MaTram, MaBangGia, NgayGhi, NguoiGhi, NgayBatDau, NgayKetThuc, D.NgayCapNhat, D.NguoiCapNhat, NgayHoaDon, NgayTraTien, ChiSoMoi, ChiSoCu, TongTienTruocVAT, TongTienSauVAT, DaTra, ConLai
	FROM DienNangTieuThu D, KhachHang K
	WHERE D.MaKhachHang = K.MaKhachHang
GO
/****** Object:  Table [dbo].[BangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangGia](
	[MaBangGia] [char](5) NOT NULL,
	[TenBangGia] [nvarchar](100) NOT NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBangGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietBangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBangGia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaBangGia] [char](5) NULL,
	[BatDau] [int] NOT NULL,
	[KetThuc] [int] NOT NULL,
	[GiaTruocVAT] [int] NOT NULL,
	[VAT] [float] NOT NULL,
	[GiaSauVAT] [int] NULL,
	[MoTa] [nvarchar](200) NULL,
	[KichHoat] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiQuanLy]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiQuanLy](
	[MaQuanLy] [char](5) NOT NULL,
	[TenQuanLy] [nvarchar](150) NOT NULL,
	[SoDienThoai] [varchar](20) NULL,
	[DiaChi] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuanLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TramBienAp]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TramBienAp](
	[MaTram] [char](5) NOT NULL,
	[TenTram] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
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
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG001', N'Điện sinh hoạt (hộ thường)', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG002', N'Điện sinh hoạt (hộ nghèo)', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG003', N'Điện kinh doanh - dịch vụ', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG004', N'Điện sản xuất', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG005', N'Điện hành chính, sự nghiệp', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG006', N'Điện cho bệnh viện, trường học', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG007', N'Điện cho bơm nước, tưới tiêu', 1)
INSERT [dbo].[BangGia] ([MaBangGia], [TenBangGia], [KichHoat]) VALUES (N'BG008', N'Điện chiếu sáng công cộng', 1)
GO
SET IDENTITY_INSERT [dbo].[ChiTietBangGia] ON 

INSERT [dbo].[ChiTietBangGia] ([ID], [MaBangGia], [BatDau], [KetThuc], [GiaTruocVAT], [VAT], [GiaSauVAT], [MoTa], [KichHoat]) VALUES (1, N'BG001', 0, 50, 1678, 0.1, 1846, N'Bậc 1: Cho kWh từ 0 - 50', 1)
INSERT [dbo].[ChiTietBangGia] ([ID], [MaBangGia], [BatDau], [KetThuc], [GiaTruocVAT], [VAT], [GiaSauVAT], [MoTa], [KichHoat]) VALUES (2, N'BG001', 51, 100, 1734, 0.1, 1907, N'Bậc 2: Cho kWh từ 51 - 100', 1)
INSERT [dbo].[ChiTietBangGia] ([ID], [MaBangGia], [BatDau], [KetThuc], [GiaTruocVAT], [VAT], [GiaSauVAT], [MoTa], [KichHoat]) VALUES (3, N'BG001', 101, 200, 2014, 0.1, 2215, N'Bậc 3: Cho kWh từ 101 - 200', 1)
INSERT [dbo].[ChiTietBangGia] ([ID], [MaBangGia], [BatDau], [KetThuc], [GiaTruocVAT], [VAT], [GiaSauVAT], [MoTa], [KichHoat]) VALUES (4, N'BG001', 201, 300, 2536, 0.1, 2790, N'Bậc 4: Cho kWh từ 201 - 300', 1)
INSERT [dbo].[ChiTietBangGia] ([ID], [MaBangGia], [BatDau], [KetThuc], [GiaTruocVAT], [VAT], [GiaSauVAT], [MoTa], [KichHoat]) VALUES (5, N'BG001', 301, 400, 2834, 0.1, 3117, N'Bậc 5: Cho kWh từ 301 - 400', 1)
INSERT [dbo].[ChiTietBangGia] ([ID], [MaBangGia], [BatDau], [KetThuc], [GiaTruocVAT], [VAT], [GiaSauVAT], [MoTa], [KichHoat]) VALUES (6, N'BG001', 401, 0, 2927, 0.1, 3220, N'Bậc 6: Cho kWh từ 401 trở lên', 1)
SET IDENTITY_INSERT [dbo].[ChiTietBangGia] OFF
GO
INSERT [dbo].[NguoiQuanLy] ([MaQuanLy], [TenQuanLy], [SoDienThoai], [DiaChi], [Email]) VALUES (N'QL001', N'La Quốc Thắng', N'0987610260', N'Đà Lạt - Lâm Đồng', N'quocthang_0507@yahoo.com.vn')
INSERT [dbo].[NguoiQuanLy] ([MaQuanLy], [TenQuanLy], [SoDienThoai], [DiaChi], [Email]) VALUES (N'QL002', N'Nguyễn Văn An', N'0123456789', N'Đà Lạt - Lâm Đồng', N'nvak@yahoo.com.vn')
INSERT [dbo].[NguoiQuanLy] ([MaQuanLy], [TenQuanLy], [SoDienThoai], [DiaChi], [Email]) VALUES (N'QL003', N'Trần Thị Bình', N'0987654321', N'Đà Lạt - Lâm Đồng', N'ttbm@yahoo.com.vn')
INSERT [dbo].[NguoiQuanLy] ([MaQuanLy], [TenQuanLy], [SoDienThoai], [DiaChi], [Email]) VALUES (N'QL004', N'Trịnh Thị Trân', N'0457398472', N'Đà Lạt - Lâm Đồng', N'ttt@yahoo.com.vn')
GO
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA001', N'Trạm biến áp 1', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA002', N'Trạm biến áp 2', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[TramBienAp] ([MaTram], [TenTram], [DiaChi], [NguoiPhuTrach], [MaSoCongTo], [HeSoNhan], [KichHoat]) VALUES (N'BA003', N'Trạm biến áp 3', NULL, NULL, NULL, 1, 1)
GO
ALTER TABLE [dbo].[BangGia] ADD  CONSTRAINT [DF_BangGia_KichHoat]  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[ChiTietBangGia] ADD  CONSTRAINT [DF_ChiTietBangGia_HoatDong]  DEFAULT ((1)) FOR [KichHoat]
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
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [DF_KhachHang_DaXoa]  DEFAULT ((1)) FOR [KichHoat]
GO
ALTER TABLE [dbo].[TramBienAp] ADD  CONSTRAINT [DF_TramBienAp_HeSoNhan]  DEFAULT ((1)) FOR [HeSoNhan]
GO
ALTER TABLE [dbo].[TramBienAp] ADD  CONSTRAINT [DF_TramBienAp_KichHoat]  DEFAULT ((1)) FOR [KichHoat]
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
/****** Object:  StoredProcedure [dbo].[proc_Delete_BangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_BangGia]
	@MaBangGia char(5)
AS
	UPDATE BangGia
	SET KichHoat = 0
	WHERE MaBangGia = @MaBangGia
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_ChiTietBangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_ChiTietBangGia]
	@ID int
AS
	UPDATE ChiTietBangGia
	SET KichHoat = 0
	WHERE ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_Delete_KhachHang]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_KhachHang]
	@MaKhachHang char(9)
AS
	UPDATE KhachHang
	SET KichHoat = 0
	WHERE MaKhachHang = @MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_NguoiQuanLy]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_NguoiQuanLy]
	@MaQuanLy char(5)
AS
	DELETE FROM NguoiQuanLy WHERE MaQuanLy = @MaQuanLy
GO
/****** Object:  StoredProcedure [dbo].[proc_Delete_TramBienAp]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Delete_TramBienAp]
	@MaTram char(5)
AS
	UPDATE TramBienAp
	SET KichHoat = 0
	WHERE MaTram = @MaTram
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_BangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_BangGia]
AS
	SELECT * FROM BangGia WHERE KichHoat = 1
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_ChiTietBangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_ChiTietBangGia]
AS
	SELECT * FROM ChiTietBangGia WHERE KichHoat = 1
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_DienNangTieuThu]
AS
	SELECT * FROM View_DienNangTieuThu
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_KhachHang]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_KhachHang]
AS
	SELECT * FROM KhachHang WHERE KichHoat = 0 ORDER BY MaKhachHang
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_NguoiQuanLy]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_NguoiQuanLy]
AS
	SELECT * FROM NguoiQuanLy ORDER BY MaQuanLy
GO
/****** Object:  StoredProcedure [dbo].[proc_GetAll_TramBienAp]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetAll_TramBienAp]
AS
	SELECT * FROM TramBienAp WHERE KichHoat = 1
GO
/****** Object:  StoredProcedure [dbo].[proc_GetByDate_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetByDate_DienNangTieuThu]
	@MONTH TINYINT,
	@YEAR INT
AS
	SELECT * FROM View_DienNangTieuThu WHERE MONTH(NgayKetThuc) = @MONTH AND YEAR(NgayKetThuc) = @YEAR
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_BangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_BangGia]
	@MaBangGia char(5),
	@TenBangGia nvarchar(100)
AS
	INSERT INTO BangGia VALUES (@MaBangGia, @TenBangGia)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_ChiTietBangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_ChiTietBangGia]
	@MaBangGia char(5),
	@BatDau int,
	@KetThuc int,
	@GiaTruocVAT int,
	@VAT float,
	@MoTa nvarchar(200)
AS
	INSERT INTO ChiTietBangGia (MaBangGia, BatDau, KetThuc, GiaTruocVAT, VAT, MoTa) VALUES (@MaBangGia, @BatDau, @KetThuc, @GiaTruocVAT, @VAT, @MoTa)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_DienNangTieuThu]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_DienNangTieuThu_Test]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_DienNangTieuThu_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_KhachHang]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_KhachHang]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_KhachHang_Test]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_KhachHang_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Insert_NguoiQuanLy]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_NguoiQuanLy]
	@TenQuanLy nvarchar(150),
	@SoDienThoai varchar(20),
	@DiaChi nvarchar(200),
	@Email nvarchar(100)
AS
	DECLARE @MA CHAR(5)
	SET @MA = DBO.func_GenerateID_NguoiQuanLy()
	INSERT INTO NguoiQuanLy VALUES (@MA, @TenQuanLy, @SoDienThoai, @DiaChi, @Email)
GO
/****** Object:  StoredProcedure [dbo].[proc_Insert_TramBienAp]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Insert_TramBienAp]
	@MaTram char(5),
	@TenTram nvarchar(100)
AS
	INSERT INTO TramBienAp VALUES (@MaTram, @TenTram)
GO
/****** Object:  StoredProcedure [dbo].[proc_Reset_ChiTietBangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Reset_ChiTietBangGia]
AS
	DELETE FROM ChiTietBangGia
	DBCC CHECKIDENT ('[CHITIETBANGGIA]', RESEED, 0);
GO
/****** Object:  StoredProcedure [dbo].[proc_Reset_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Reset_DienNangTieuThu]
AS
	DELETE FROM DienNangTieuThu
	DBCC CHECKIDENT ('[DienNangTieuThu]', RESEED, 0);
GO
/****** Object:  StoredProcedure [dbo].[proc_Update_BangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_BangGia]
	@MaBangGia char(5),
	@TenBangGia nvarchar(100)
AS
	UPDATE BangGia
	SET TenBangGia = @TenBangGia
	WHERE MaBangGia = @MaBangGia
GO
/****** Object:  StoredProcedure [dbo].[proc_Update_ChiTietBangGia]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_ChiTietBangGia]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_DienNangTieuThu]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_DienNangTieuThu]
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
	Where ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[proc_Update_DienNangTieuThu_Test]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_DienNangTieuThu_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_KhachHang]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_KhachHang]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_KhachHang_Test]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_KhachHang_Test]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_NguoiQuanLy]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_NguoiQuanLy]
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
/****** Object:  StoredProcedure [dbo].[proc_Update_TramBienAp]    Script Date: 1/5/2021 9:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Update_TramBienAp]
	@MaTram char(5),
	@TenTram nvarchar(100)
AS
	UPDATE TramBienAp
	SET TenTram = @TenTram
	WHERE MaTram = @MaTram
GO
USE [master]
GO
ALTER DATABASE [QuanLyDienNang] SET  READ_WRITE 
GO
