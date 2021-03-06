USE [master]
GO
/****** Object:  Database [TTN_QLTV]    Script Date: 9/5/2020 10:31:45 am ******/
CREATE DATABASE [TTN_QLTV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TTN_QLTV', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TTN_QLTV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TTN_QLTV_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TTN_QLTV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TTN_QLTV] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TTN_QLTV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TTN_QLTV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TTN_QLTV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TTN_QLTV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TTN_QLTV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TTN_QLTV] SET ARITHABORT OFF 
GO
ALTER DATABASE [TTN_QLTV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TTN_QLTV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TTN_QLTV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TTN_QLTV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TTN_QLTV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TTN_QLTV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TTN_QLTV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TTN_QLTV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TTN_QLTV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TTN_QLTV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TTN_QLTV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TTN_QLTV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TTN_QLTV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TTN_QLTV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TTN_QLTV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TTN_QLTV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TTN_QLTV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TTN_QLTV] SET RECOVERY FULL 
GO
ALTER DATABASE [TTN_QLTV] SET  MULTI_USER 
GO
ALTER DATABASE [TTN_QLTV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TTN_QLTV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TTN_QLTV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TTN_QLTV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TTN_QLTV] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TTN_QLTV', N'ON'
GO
ALTER DATABASE [TTN_QLTV] SET QUERY_STORE = OFF
GO
USE [TTN_QLTV]
GO
/****** Object:  Table [dbo].[CHITIETPHIEUMUON]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUMUON](
	[MaPhieuMuon] [int] NOT NULL,
	[MaSach] [int] NOT NULL,
 CONSTRAINT [PK_CHITIETPHIEUMUON] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DAUSACH]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DAUSACH](
	[MaDauSach] [int] IDENTITY(1,1) NOT NULL,
	[TenDauSach] [nvarchar](50) NULL,
	[MaKeSach] [int] NULL,
	[SoLuongHienTai] [int] NULL,
	[TongSo] [int] NULL,
 CONSTRAINT [PK_DAUSACH] PRIMARY KEY CLUSTERED 
(
	[MaDauSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCGIA]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCGIA](
	[MaDocGia] [int] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[CMND] [nchar](20) NULL,
	[SoDienThoai] [nchar](20) NULL,
 CONSTRAINT [PK_DOCGIA] PRIMARY KEY CLUSTERED 
(
	[MaDocGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_NHAXUATBAN]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_NHAXUATBAN](
	[MaDauSach] [int] NOT NULL,
	[MaNhaXuatBan] [int] NOT NULL,
 CONSTRAINT [PK_DS_NHAXUATBAN] PRIMARY KEY CLUSTERED 
(
	[MaDauSach] ASC,
	[MaNhaXuatBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_TACGIA]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_TACGIA](
	[MaDauSach] [int] NOT NULL,
	[MaTacGia] [int] NOT NULL,
 CONSTRAINT [PK_DS_TACGIA] PRIMARY KEY CLUSTERED 
(
	[MaDauSach] ASC,
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DS_THELOAI]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DS_THELOAI](
	[MaDauSach] [int] NOT NULL,
	[MaTheLoai] [int] NOT NULL,
 CONSTRAINT [PK_DS_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaDauSach] ASC,
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KESACH]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KESACH](
	[MaKeSach] [int] NOT NULL,
	[TenKeSach] [nvarchar](50) NULL,
 CONSTRAINT [PK_KESACH] PRIMARY KEY CLUSTERED 
(
	[MaKeSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNhanVien] [int] NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[SoDienThoai] [nchar](20) NULL,
	[CMND] [nchar](20) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAXUATBAN]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAXUATBAN](
	[MaNhaXuatBan] [int] NOT NULL,
	[TenNhaXuatBan] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHAXUATBAN] PRIMARY KEY CLUSTERED 
(
	[MaNhaXuatBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUMUON]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUON](
	[MaPhieuMuon] [int] NOT NULL,
	[MaNhanVien] [int] NULL,
	[MaDocGia] [int] NULL,
	[ThoiGian] [int] NULL,
	[NgayMuon] [datetime] NULL,
	[NgayTra] [datetime] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_PHIEUMUON] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MaSach] [int] NOT NULL,
	[MaDauSach] [int] NULL,
	[TenSach] [nvarchar](50) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_SACH] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TACGIA]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TACGIA](
	[MaTacGia] [int] NOT NULL,
	[TenTacGia] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
 CONSTRAINT [PK_TACGIA] PRIMARY KEY CLUSTERED 
(
	[MaTacGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 9/5/2020 10:31:45 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[MaTheLoai] [int] NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_THELOAI] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieuMuon], [MaSach]) VALUES (1, 1)
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieuMuon], [MaSach]) VALUES (1, 6)
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieuMuon], [MaSach]) VALUES (1, 11)
SET IDENTITY_INSERT [dbo].[DAUSACH] ON 

INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (1, N'One Piece tập 1', 1, 10, 10)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (2, N'One Piece tập 2', 1, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (3, N'Fairy Tail tập 1', 2, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (4, N'Fairy Tail tập 63', 2, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (5, N'Solo Leveling tập 1', 3, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (6, N'Solo Leveling tập 2', 3, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (7, N'Doraemon tập 1', 4, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (8, N'Doraemon tập 2', 4, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (9, N'Ajin tập 1', 1, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (10, N'Ajin tập 2', 1, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (11, N'Thi Trấn Mèo tập 1', 2, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (12, N'Thị Trấn Mèo tập 2', 2, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (13, N'Rave tập 1', 3, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (14, N'Rave tập 2', 3, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (15, N'Eden Zero tập 1', 4, 5, 5)
INSERT [dbo].[DAUSACH] ([MaDauSach], [TenDauSach], [MaKeSach], [SoLuongHienTai], [TongSo]) VALUES (16, N'Eden Zero tập 2', 4, 5, 5)
SET IDENTITY_INSERT [dbo].[DAUSACH] OFF
INSERT [dbo].[DOCGIA] ([MaDocGia], [HoTen], [NgaySinh], [CMND], [SoDienThoai]) VALUES (1, N'Nguyễn Văn A', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'012345678           ', N'0912345678          ')
INSERT [dbo].[DOCGIA] ([MaDocGia], [HoTen], [NgaySinh], [CMND], [SoDienThoai]) VALUES (2, N'Trần Thị B', CAST(N'2020-01-10T00:00:00.000' AS DateTime), N'012345678           ', N'0912345678          ')
INSERT [dbo].[DOCGIA] ([MaDocGia], [HoTen], [NgaySinh], [CMND], [SoDienThoai]) VALUES (3, N'Lê Văn C', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'012345678           ', N'0912345678          ')
INSERT [dbo].[DOCGIA] ([MaDocGia], [HoTen], [NgaySinh], [CMND], [SoDienThoai]) VALUES (4, N'Trần Bá D', CAST(N'2020-01-10T00:00:00.000' AS DateTime), N'012345678           ', N'0912345678          ')
INSERT [dbo].[DOCGIA] ([MaDocGia], [HoTen], [NgaySinh], [CMND], [SoDienThoai]) VALUES (5, N'Lê Thị E', CAST(N'2020-05-09T00:00:00.000' AS DateTime), N'012345678           ', N'0912345678          ')
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (1, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (2, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (3, 3)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (4, 4)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (7, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (8, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (9, 2)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (10, 2)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (11, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (12, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (13, 1)
INSERT [dbo].[DS_NHAXUATBAN] ([MaDauSach], [MaNhaXuatBan]) VALUES (14, 1)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (1, 2)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (2, 2)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (3, 3)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (4, 3)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (5, 4)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (6, 4)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (7, 1)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (8, 1)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (9, 6)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (10, 6)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (11, 5)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (12, 5)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (13, 3)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (14, 3)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (15, 3)
INSERT [dbo].[DS_TACGIA] ([MaDauSach], [MaTacGia]) VALUES (16, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (1, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (1, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (1, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (2, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (2, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (2, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (3, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (3, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (3, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (3, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (4, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (4, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (4, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (4, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (5, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (5, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (5, 4)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (5, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (6, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (6, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (6, 4)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (6, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (7, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (7, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (7, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (7, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (8, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (8, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (8, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (8, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (9, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (9, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (10, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (10, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (11, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (12, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (13, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (13, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (13, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (13, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (13, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (14, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (14, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (14, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (14, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (14, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (15, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (15, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (15, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (15, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (15, 8)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (16, 1)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (16, 2)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (16, 3)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (16, 5)
INSERT [dbo].[DS_THELOAI] ([MaDauSach], [MaTheLoai]) VALUES (16, 8)
INSERT [dbo].[KESACH] ([MaKeSach], [TenKeSach]) VALUES (1, N'K1_T1')
INSERT [dbo].[KESACH] ([MaKeSach], [TenKeSach]) VALUES (2, N'K2_T1')
INSERT [dbo].[KESACH] ([MaKeSach], [TenKeSach]) VALUES (3, N'K1_T2')
INSERT [dbo].[KESACH] ([MaKeSach], [TenKeSach]) VALUES (4, N'K2_T2')
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [HoTen], [NgaySinh], [SoDienThoai], [CMND]) VALUES (1, N'Hoàng Trung', CAST(N'1999-11-30T00:00:00.000' AS DateTime), N'0912345678          ', N'012345678           ')
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [HoTen], [NgaySinh], [SoDienThoai], [CMND]) VALUES (2, N'Sơn Nam', CAST(N'1999-11-30T00:00:00.000' AS DateTime), N'0912345678          ', N'012345678           ')
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [HoTen], [NgaySinh], [SoDienThoai], [CMND]) VALUES (3, N'Đức Dũng', CAST(N'1999-11-30T00:00:00.000' AS DateTime), N'0912345678          ', N'012345678           ')
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [HoTen], [NgaySinh], [SoDienThoai], [CMND]) VALUES (4, N'Văn Vũ', CAST(N'1999-11-30T00:00:00.000' AS DateTime), N'0912345678          ', N'012345678           ')
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [HoTen], [NgaySinh], [SoDienThoai], [CMND]) VALUES (5, N'Trung Hiếu', CAST(N'1999-11-30T00:00:00.000' AS DateTime), N'0912345678          ', N'012345678           ')
INSERT [dbo].[NHAXUATBAN] ([MaNhaXuatBan], [TenNhaXuatBan]) VALUES (1, N'Nhà Xuất Bản Kim Đồng')
INSERT [dbo].[NHAXUATBAN] ([MaNhaXuatBan], [TenNhaXuatBan]) VALUES (2, N'Nhà Xuất Bản Trẻ')
INSERT [dbo].[NHAXUATBAN] ([MaNhaXuatBan], [TenNhaXuatBan]) VALUES (3, N'TVM Comics')
INSERT [dbo].[NHAXUATBAN] ([MaNhaXuatBan], [TenNhaXuatBan]) VALUES (4, N'TA Books')
INSERT [dbo].[PHIEUMUON] ([MaPhieuMuon], [MaNhanVien], [MaDocGia], [ThoiGian], [NgayMuon], [NgayTra], [ThanhTien]) VALUES (1, 1, 1, 5, CAST(N'2020-05-04T00:00:00.000' AS DateTime), CAST(N'2020-05-10T00:00:00.000' AS DateTime), 0.0000)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (1, 1, N'One Piece tập 1', 1)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (2, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (3, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (4, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (5, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (6, 1, N'One Piece tập 1', 1)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (7, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (8, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (9, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (10, 1, N'One Piece tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (11, 2, N'One Piece tập 2', 1)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (12, 2, N'One Piece tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (13, 2, N'One Piece tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (14, 2, N'One Piece tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (15, 2, N'One Piece tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (16, 3, N'Fairy Tail tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (17, 3, N'Fairy Tail tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (18, 3, N'Fairy Tail tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (19, 3, N'Fairy Tail tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (20, 3, N'Fairy Tail tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (21, 4, N'Fairy Tail tập 63', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (22, 4, N'Fairy Tail tập 63', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (23, 4, N'Fairy Tail tập 63', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (24, 4, N'Fairy Tail tập 63', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (25, 4, N'Fairy Tail tập 63', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (26, 5, N'Solo Leveling tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (27, 5, N'Solo Leveling tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (28, 5, N'Solo Leveling tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (29, 5, N'Solo Leveling tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (30, 5, N'Solo Leveling tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (31, 6, N'Solo Leveling tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (32, 6, N'Solo Leveling tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (33, 6, N'Solo Leveling tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (34, 6, N'Solo Leveling tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (35, 6, N'Solo Leveling tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (36, 7, N'Doraemon tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (37, 7, N'Doraemon tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (38, 7, N'Doraemon tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (39, 7, N'Doraemon tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (40, 7, N'Doraemon tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (41, 8, N'Doraemon tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (42, 8, N'Doraemon tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (43, 8, N'Doraemon tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (44, 8, N'Doraemon tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (45, 8, N'Doraemon tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (46, 9, N'Ajin tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (47, 9, N'Ajin tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (48, 9, N'Ajin tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (49, 9, N'Ajin tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (50, 9, N'Ajin tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (51, 10, N'Ajin tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (52, 10, N'Ajin tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (53, 10, N'Ajin tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (54, 10, N'Ajin tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (55, 10, N'Ajin tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (56, 11, N'Thi Trấn Mèo tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (57, 11, N'Thi Trấn Mèo tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (58, 11, N'Thi Trấn Mèo tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (59, 11, N'Thi Trấn Mèo tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (60, 11, N'Thi Trấn Mèo tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (61, 12, N'Thị Trấn Mèo tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (62, 12, N'Thị Trấn Mèo tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (63, 12, N'Thị Trấn Mèo tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (64, 12, N'Thị Trấn Mèo tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (65, 12, N'Thị Trấn Mèo tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (66, 13, N'Rave tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (67, 13, N'Rave tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (68, 13, N'Rave tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (69, 13, N'Rave tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (70, 13, N'Rave tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (71, 14, N'Rave tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (72, 14, N'Rave tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (73, 14, N'Rave tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (74, 14, N'Rave tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (75, 14, N'Rave tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (76, 15, N'Eden Zero tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (77, 15, N'Eden Zero tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (78, 15, N'Eden Zero tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (79, 15, N'Eden Zero tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (80, 15, N'Eden Zero tập 1', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (81, 16, N'Eden Zero tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (82, 16, N'Eden Zero tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (83, 16, N'Eden Zero tập 2', 0)
INSERT [dbo].[SACH] ([MaSach], [MaDauSach], [TenSach], [TinhTrang]) VALUES (84, 16, N'Eden Zero tập 2', 0)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [NgaySinh]) VALUES (1, N'Fujiko F. Fujio', CAST(N'1933-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [NgaySinh]) VALUES (2, N'Eiichiro Oda', CAST(N'1975-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [NgaySinh]) VALUES (3, N'Hiro Mashima', CAST(N'1977-05-03T00:00:00.000' AS DateTime))
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [NgaySinh]) VALUES (4, N'Chu-Gong', NULL)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [NgaySinh]) VALUES (5, N'
Nekomaki ', NULL)
INSERT [dbo].[TACGIA] ([MaTacGia], [TenTacGia], [NgaySinh]) VALUES (6, N'	Gamon Sakurai', NULL)
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (1, N'Hành Động')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (2, N'Phiêu Lưu')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (3, N'Manga')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (4, N'Webtoon')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (5, N'Phép Thuật')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (6, N'Lãng Mạn')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (7, N'Truyện Chữ')
INSERT [dbo].[THELOAI] ([MaTheLoai], [TenTheLoai]) VALUES (8, N'Hài Hước')
ALTER TABLE [dbo].[CHITIETPHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUMUON_PHIEUMUON] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PHIEUMUON] ([MaPhieuMuon])
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON] CHECK CONSTRAINT [FK_CHITIETPHIEUMUON_PHIEUMUON]
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUMUON_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON] CHECK CONSTRAINT [FK_CHITIETPHIEUMUON_SACH]
GO
ALTER TABLE [dbo].[DAUSACH]  WITH CHECK ADD  CONSTRAINT [FK_DAUSACH_KESACH1] FOREIGN KEY([MaKeSach])
REFERENCES [dbo].[KESACH] ([MaKeSach])
GO
ALTER TABLE [dbo].[DAUSACH] CHECK CONSTRAINT [FK_DAUSACH_KESACH1]
GO
ALTER TABLE [dbo].[DS_NHAXUATBAN]  WITH CHECK ADD  CONSTRAINT [FK_DS_NHAXUATBAN_DAUSACH] FOREIGN KEY([MaDauSach])
REFERENCES [dbo].[DAUSACH] ([MaDauSach])
GO
ALTER TABLE [dbo].[DS_NHAXUATBAN] CHECK CONSTRAINT [FK_DS_NHAXUATBAN_DAUSACH]
GO
ALTER TABLE [dbo].[DS_NHAXUATBAN]  WITH CHECK ADD  CONSTRAINT [FK_DS_NHAXUATBAN_NHAXUATBAN] FOREIGN KEY([MaNhaXuatBan])
REFERENCES [dbo].[NHAXUATBAN] ([MaNhaXuatBan])
GO
ALTER TABLE [dbo].[DS_NHAXUATBAN] CHECK CONSTRAINT [FK_DS_NHAXUATBAN_NHAXUATBAN]
GO
ALTER TABLE [dbo].[DS_TACGIA]  WITH CHECK ADD  CONSTRAINT [FK_DS_TACGIA_DAUSACH] FOREIGN KEY([MaDauSach])
REFERENCES [dbo].[DAUSACH] ([MaDauSach])
GO
ALTER TABLE [dbo].[DS_TACGIA] CHECK CONSTRAINT [FK_DS_TACGIA_DAUSACH]
GO
ALTER TABLE [dbo].[DS_TACGIA]  WITH CHECK ADD  CONSTRAINT [FK_DS_TACGIA_TACGIA] FOREIGN KEY([MaTacGia])
REFERENCES [dbo].[TACGIA] ([MaTacGia])
GO
ALTER TABLE [dbo].[DS_TACGIA] CHECK CONSTRAINT [FK_DS_TACGIA_TACGIA]
GO
ALTER TABLE [dbo].[DS_THELOAI]  WITH CHECK ADD  CONSTRAINT [FK_DS_TheLoai_DAUSACH] FOREIGN KEY([MaDauSach])
REFERENCES [dbo].[DAUSACH] ([MaDauSach])
GO
ALTER TABLE [dbo].[DS_THELOAI] CHECK CONSTRAINT [FK_DS_TheLoai_DAUSACH]
GO
ALTER TABLE [dbo].[DS_THELOAI]  WITH CHECK ADD  CONSTRAINT [FK_DS_TheLoai_THELOAI] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[THELOAI] ([MaTheLoai])
GO
ALTER TABLE [dbo].[DS_THELOAI] CHECK CONSTRAINT [FK_DS_TheLoai_THELOAI]
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUON_DOCGIA] FOREIGN KEY([MaDocGia])
REFERENCES [dbo].[DOCGIA] ([MaDocGia])
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [FK_PHIEUMUON_DOCGIA]
GO
ALTER TABLE [dbo].[PHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUON_NHANVIEN] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PHIEUMUON] CHECK CONSTRAINT [FK_PHIEUMUON_NHANVIEN]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH_DAUSACH] FOREIGN KEY([MaDauSach])
REFERENCES [dbo].[DAUSACH] ([MaDauSach])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH_DAUSACH]
GO
USE [master]
GO
ALTER DATABASE [TTN_QLTV] SET  READ_WRITE 
GO
