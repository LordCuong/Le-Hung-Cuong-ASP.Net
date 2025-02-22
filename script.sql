USE [master]
GO
/****** Object:  Database [WebAspDb]    Script Date: 17/01/2025 7:21:06 CH ******/
CREATE DATABASE [WebAspDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebAspDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.CUONGLE\MSSQL\DATA\WebAspDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebAspDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.CUONGLE\MSSQL\DATA\WebAspDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WebAspDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebAspDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebAspDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebAspDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebAspDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebAspDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebAspDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebAspDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebAspDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebAspDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebAspDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebAspDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebAspDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebAspDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebAspDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebAspDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebAspDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WebAspDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebAspDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebAspDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebAspDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebAspDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebAspDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebAspDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebAspDb] SET RECOVERY FULL 
GO
ALTER DATABASE [WebAspDb] SET  MULTI_USER 
GO
ALTER DATABASE [WebAspDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebAspDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebAspDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebAspDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebAspDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebAspDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WebAspDb', N'ON'
GO
ALTER DATABASE [WebAspDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [WebAspDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WebAspDb]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 17/01/2025 7:21:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1255) NOT NULL,
	[Image] [varchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 17/01/2025 7:21:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Image] [varchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 17/01/2025 7:21:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[UserId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 17/01/2025 7:21:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17/01/2025 7:21:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Image] [varchar](100) NULL,
	[CategoryId] [int] NOT NULL,
	[BrandId] [int] NOT NULL,
	[ShortDes] [nvarchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[FullDescription] [nvarchar](1000) NULL,
	[Price] [float] NOT NULL,
	[PriceDiscount] [float] NULL,
	[TypeId] [int] NULL,
	[Slug] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17/01/2025 7:21:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsAdmin] [bit] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (1, N'Apple', N'apple-logo.png', N'apple', 1, 1, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (2, N'Samsung', N'samsung-logo.png', N'samsung', 1, 2, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (3, N'Sony', N'sony-logo.png', N'sony', 1, 3, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (4, N'LG', N'lg-logo.png', N'lg', 0, 4, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (5, N'Xiaomi', N'xiaomi-logo.png', N'xiaomi', 1, 5, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (6, N'Huawei', N'huawei-logo.png', N'huawei', 0, 6, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, NULL)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (7, N'Dell', N'dell-logo.png', N'dell', 0, 7, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (8, N'HP', N'hp-logo.png', N'hp', 0, 8, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (9, N'Asus', N'asus-logo.png', N'asus', 1, 9, CAST(N'2025-01-03T17:31:34.693' AS DateTime), NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (10, N'Acer', N'acer-logo.png', N'acer', 0, 10, CAST(N'2025-01-03T17:31:34.693' AS DateTime), CAST(N'2025-01-17T14:23:50.570' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (1, N'Điện thoại', N'phone-category.png', N'dien-thoai', 1, 1, CAST(N'2025-01-03T17:31:34.703' AS DateTime), NULL, 0)
INSERT [dbo].[Category] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (2, N'Laptop', N'laptop-category.png', N'laptop', 1, 2, CAST(N'2025-01-03T17:31:34.703' AS DateTime), NULL, 0)
INSERT [dbo].[Category] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (3, N'Máy tính bảng', N'tablet-category.png', N'may-tinh-bang', 1, 3, CAST(N'2025-01-03T17:31:34.703' AS DateTime), NULL, 0)
INSERT [dbo].[Category] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (5, N'Âm thanh', N'jblcharge5_20250117050241.png', N'am-thanh', 0, 5, CAST(N'2025-01-03T17:31:34.703' AS DateTime), CAST(N'2025-01-17T17:02:41.827' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (6, N'Tivi', N'lgoledc2_20250117051825.png', N'tivi', 0, 6, CAST(N'2025-01-03T17:31:34.703' AS DateTime), CAST(N'2025-01-17T17:18:25.493' AS DateTime), NULL)
INSERT [dbo].[Category] ([Id], [Name], [Image], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (7, N'Đồng hồ thông minh', N'7_20250117051657.jpg', N'dong-ho-thong-minh', 1, 7, CAST(N'2025-01-03T17:31:34.703' AS DateTime), CAST(N'2025-01-17T17:16:57.540' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (1, N'DonHang-20250115173659', 1, 79980000, 1, CAST(N'2025-01-15T17:36:59.963' AS DateTime), NULL)
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (2, N'DonHang-20250115173914', 1, 39990000, 0, CAST(N'2025-01-15T17:39:14.590' AS DateTime), CAST(N'2025-01-16T18:48:36.907' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (3, N'DonHang-20250116171408', 6, 39990000, 0, CAST(N'2025-01-16T17:14:08.477' AS DateTime), CAST(N'2025-01-17T19:00:15.647' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (5, N'DonHang-20250116185329', 6, 32990000, 0, CAST(N'2025-01-16T18:53:29.573' AS DateTime), CAST(N'2025-01-16T19:55:56.653' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (6, N'DonHang-20250116192402', 6, 39990000, 3, CAST(N'2025-01-16T19:24:02.463' AS DateTime), CAST(N'2025-01-17T12:29:07.140' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (7, N'DonHang-20250116192647', 6, 0, 0, CAST(N'2025-01-16T19:26:47.603' AS DateTime), CAST(N'2025-01-16T19:55:45.047' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (8, N'DonHang-20250116192919', 6, 39990000, 2, CAST(N'2025-01-16T19:29:19.900' AS DateTime), CAST(N'2025-01-17T14:37:04.570' AS DateTime))
INSERT [dbo].[Order] ([Id], [Name], [UserId], [Price], [Status], [CreatedAt], [UpdatedAt]) VALUES (13, N'DonHang-20250117191457', 10, 74980000, 1, CAST(N'2025-01-17T19:14:57.217' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (1, 1, 1, 0, 2, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (2, 2, 1, 1, 1, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (3, 3, 1, 6, 1, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (4, 4, 1, 6, 1, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (5, 5, 2, 6, 1, 32990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (6, 6, 1, 6, 1, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (7, 8, 1, 6, 1, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (8, 9, 2, 6, 1, 32990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (9, 10, 1, 6, 1, 39990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (10, 12, 3, 6, 1, 45990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (11, 13, 4, 10, 1, 28990000, 0, NULL)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [UserId], [Quantity], [Price], [TotalPrice], [CreatedAt]) VALUES (12, 13, 3, 10, 1, 45990000, 0, NULL)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (1, N'iPhone 15 Pro Max', N'iphone15promax.png', 1, 1, N'Siêu phẩm mơi nhất của Apple', 0, N'Sở hũu chip A17 Bionic và camera đỉnh cao.', 39990000, 36990000, 1, N'iphone-15-pro-max', CAST(N'2025-01-03T17:31:34.713' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (2, N'Samsung Galaxy S23 Ultra', N'galaxys23ultra.png', 1, 2, N'điện thoại cao cấp của Samsung', 0, N'Màn hình Dynamic AMOLED 2X và bút S Pen độc đáo.', 32990000, 29990000, 1, N'samsung-galaxy-s23-ultra', CAST(N'2025-01-03T17:31:34.713' AS DateTime), CAST(N'2025-01-17T17:27:50.367' AS DateTime), 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (3, N'Laptop Dell XPS 13', N'dellxps13.png', 2, 7, N'Laptop mỏng nhẹ cao cấp', 0, N'Màn hình InfinityEdge 4K và hiệu năng mạnh mẽ.', 45990000, 42990000, 2, N'laptop-dell-xps-13', CAST(N'2025-01-03T17:31:34.713' AS DateTime), CAST(N'2025-01-17T17:28:54.113' AS DateTime), 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (4, N'MacBook Air M2', N'macbookairm2.png', 2, 1, N'Laptop siêu mỏng của Apple', 0, N'Chip M2 vơi hiệu năng vượt trội và thời lượng pin lâu.', 28990000, 26990000, 2, N'macbook-air-m2', CAST(N'2025-01-03T17:31:34.713' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (5, N'Samsung Tab S9', N'tabs9.png', 3, 2, N'Máy tính b?ng Android t?t nh?t', 0, N'Màn hình AMOLED và khả năng làm việc hiệu quả.', 20990000, 18990000, 3, N'samsung-tab-s9', CAST(N'2025-01-03T17:31:34.713' AS DateTime), CAST(N'2025-01-17T17:27:39.907' AS DateTime), 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (6, N'iPad Pro M2', N'ipadpro-m2.png', 3, 1, N'Máy tính bảng mạnh mẽ của Apple', 0, N'Màn hình Liquid Retina XDR và chip M2 vượt trội.', 29990000, 27990000, 3, N'ipad-pro-m2', CAST(N'2025-01-03T17:31:34.713' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (7, N'Tai nghe AirPods Pro 2', N'airpodspro2.png', 5, 1, N'Tai nghe không dây cao cấp', 0, N'âm thanh không gian.', 5990000, 5490000, 5, N'airpods-pro-2', CAST(N'2025-01-03T17:31:34.713' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (8, N'Loa Bluetooth JBL Charge 5', N'jblcharge5.png', 5, 10, N'Loa di động chống nước', 0, N'Âm thanh mạnh mẽ và thời lượng pin lên tới 20 giờ.', 3990000, 3490000, 5, N'jbl-charge-5', NULL, CAST(N'2025-01-17T17:28:41.917' AS DateTime), 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (9, N'Tivi LG OLED C2', N'lgoledc2.png', 6, 4, N'Tivi OLED 4K cao cấp', 1, N'Màn hình OLED chất lượng vượt trội và AI Picture Pro.', 45990000, 42990000, 6, N'tivi-lg-oled-c2', NULL, CAST(N'2025-01-17T17:27:21.017' AS DateTime), 0)
INSERT [dbo].[Product] ([Id], [Name], [Image], [CategoryId], [BrandId], [ShortDes], [ShowOnHomePage], [FullDescription], [Price], [PriceDiscount], [TypeId], [Slug], [CreatedAt], [UpdatedAt], [Deleted]) VALUES (10, N'Camera Sony A7 IV', N'sonya7iv_20250115091212.png', 9, 3, N'Máy ảnh mirrorless chuyên nghiệp', 1, N'Cảm biến full-frame và khả năng quay phim 4K.', 66990000, 52990000, NULL, NULL, NULL, CAST(N'2025-01-17T17:27:09.147' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [CreatedAt]) VALUES (1, N'cuong', N'le', N'cuong1@gmail.com', N'141a85bb8ed911869b654efbd2f1e363', NULL, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [CreatedAt]) VALUES (2, N'Le', N'le', N'cuong2@gmail.com', N'1ef9c1ffe6765f19594ae5ffefb7d0a9', NULL, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [CreatedAt]) VALUES (6, N'admin', N'.', N'admin@gmail.com', N'21232f297a57a5a743894a0e4a801fc3', 1, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [CreatedAt]) VALUES (8, N'le', N'cuong', N'cuong3@gmail.com', N'0cd188222b72b051148444eb4bd3aa4a', 0, CAST(N'2025-01-17T19:03:20.290' AS DateTime))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [CreatedAt]) VALUES (9, N'le', N'cuong', N'cuong4@gmail.com', N'4fbfac085b4d710724df9543beeffd69', 0, CAST(N'2025-01-17T19:05:28.250' AS DateTime))
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [CreatedAt]) VALUES (10, N'cuong', N'le', N'cuongle11@gmail.com', N'00dfcf47f7934cdd2944c9e8a2615346', 0, CAST(N'2025-01-17T19:10:18.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__A9D1053422F8FC9D]    Script Date: 17/01/2025 7:21:06 CH ******/
ALTER TABLE [dbo].[User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT ((0)) FOR [ShowOnHomePage]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Brand] ADD  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [ShowOnHomePage]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[OrderDetail] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [ShowOnHomePage]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [PriceDiscount]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
USE [master]
GO
ALTER DATABASE [WebAspDb] SET  READ_WRITE 
GO
