USE [master]
GO
/****** Object:  Database [QL_SHOP_FASHION]    Script Date: 22/11/2024 3:28:57 SA ******/
CREATE DATABASE [QL_SHOP_FASHION]
GO
USE [QL_SHOP_FASHION]
GO
/****** Object:  Table [dbo].[chi_tiet_hoa_don]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chi_tiet_hoa_don](
	[ma_hoa_don] [int] NOT NULL,
	[ma_thuoc_tinh] [int] NOT NULL,
	[so_luong] [int] NOT NULL,
	[gia] [decimal](10, 2) NOT NULL,
	[giagiam] [decimal](10, 2) NULL,
	[thanh_tien]  AS ([giagiam]*[so_luong]) PERSISTED,
	[trang_thai] [nvarchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hoa_don] ASC,
	[ma_thuoc_tinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chi_tiet_hoa_don_doi_tra]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chi_tiet_hoa_don_doi_tra](
	[ma_hoa_don] [int] NOT NULL,
	[ma_thuoc_tinh] [int] NOT NULL,
	[trang_thai] [nvarchar](50) NOT NULL,
	[so_luong] [int] NOT NULL,
	[gia] [decimal](18, 0) NOT NULL,
	[giagiam] [decimal](18, 0) NOT NULL,
	[thanh_tien] [decimal](18, 0) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hoa_don] ASC,
	[ma_thuoc_tinh] ASC,
	[trang_thai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chi_tiet_nhap_hang]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chi_tiet_nhap_hang](
	[ma_nhap_hang] [int] NOT NULL,
	[ma_san_pham] [int] NOT NULL,
	[so_luong] [int] NOT NULL,
	[gia_nhap] [decimal](18, 0) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nhap_hang] ASC,
	[ma_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hinh_anh_san_pham]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hinh_anh_san_pham](
	[ma_hinh_anh] [int] IDENTITY(1,1) NOT NULL,
	[ma_san_pham] [int] NULL,
	[hinh_anh] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hinh_anh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoa_don]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoa_don](
	[ma_hoa_don] [int] IDENTITY(1,1) NOT NULL,
	[ma_khach_hang] [int] NULL,
	[ma_nhan_vien] [int] NULL,
	[ngay_lap] [datetime] NULL,
	[ma_khuyen_mai] [int] NULL,
	[trang_thai_giao_hang] [nvarchar](50) NULL,
	[ma_phuong_thuc] [int] NULL,
	[tong_so_luong_mua] [int] NULL,
	[tien_giam] [decimal](10, 2) NULL,
	[tong_tien] [decimal](10, 2) NULL,
	[tien_doi_diem] [decimal](10, 2) NULL,
	[doi_diem] [bit] NULL,
	[tong_gia_tri] [decimal](10, 2) NULL,
	[tong_don_hang] [decimal](10, 2) NOT NULL,
	[hinh_thuc_ban] [bit] NOT NULL,
	[trang_thai_doi_tra] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hoa_don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoa_don_doi_tra]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoa_don_doi_tra](
	[ma_hoa_don] [int] NOT NULL,
	[ma_nhan_vien] [int] NULL,
	[ma_phuong_thuc] [int] NULL,
	[tong_so_luong] [int] NULL,
	[ngay_doi_tra] [datetime] NULL,
	[tien_doi_diem] [decimal](10, 2) NULL,
	[tien_hang_tra] [decimal](10, 2) NULL,
	[tien_mua_them] [decimal](10, 2) NULL,
	[tien_hoan] [decimal](10, 2) NULL,
	[tien_khach_tra] [decimal](10, 2) NULL,
	[tong_tien_sau_khi_doi] [decimal](10, 2) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_hoa_don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[khach_hang]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khach_hang](
	[ma_khach_hang] [int] IDENTITY(1,1) NOT NULL,
	[ten_khach_hang] [nvarchar](255) NOT NULL,
	[dien_thoai] [varchar](20) NOT NULL,
	[dia_chi] [nvarchar](255) NULL,
	[diem_thuong] [int] NULL,
	[diem_da_doi] [int] NULL,
	[tai_khoan_id] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_khach_hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khuyen_mai]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khuyen_mai](
	[ma_khuyen_mai] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](255) NULL,
	[gia_tri] [decimal](10, 2) NOT NULL,
	[thoi_gian_bat_dau] [date] NULL,
	[thoi_gian_ket_thuc] [date] NULL,
	[so_luong_toi_da] [int] NULL,
	[so_luong_da_dung] [int] NULL,
	[tinh_trang] [nvarchar](50) NULL,
	[ghi_chu] [nvarchar](255) NULL,
	[gia_tri_hoa_don_toi_thieu] [decimal](10, 2) NOT NULL,
	[ma_nhan_vien] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_khuyen_mai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kich_thuoc]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kich_thuoc](
	[ma_kich_thuoc] [int] IDENTITY(1,1) NOT NULL,
	[ten_kich_thuoc] [nvarchar](50) NOT NULL,
	[phu_phi_size] [decimal](18, 2) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_kich_thuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loai_san_pham]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loai_san_pham](
	[ma_loai] [int] IDENTITY(1,1) NOT NULL,
	[ten_loai] [nvarchar](255) NOT NULL,
	[ma_nhom_loai] [int] NULL,
	[chi_tiet] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[man_hinh]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[man_hinh](
	[id_man_hinh] [int] NOT NULL,
	[ten_man_hinh] [nvarchar](255) NOT NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_man_hinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mau_sac]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mau_sac](
	[ma_mau_sac] [int] IDENTITY(1,1) NOT NULL,
	[ten_mau_sac] [nvarchar](50) NOT NULL,
	[phu_phi_mausac] [decimal](18, 2) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_mau_sac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nha_cung_cap]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nha_cung_cap](
	[ma_nha_cung_cap] [int] IDENTITY(1,1) NOT NULL,
	[ten_nha_cung_cap] [nvarchar](255) NOT NULL,
	[dia_chi] [nvarchar](255) NULL,
	[dien_thoai] [varchar](20) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nha_cung_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nha_cung_cap_san_pham]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nha_cung_cap_san_pham](
	[ma_nha_cung_cap] [int] NOT NULL,
	[ma_san_pham] [int] NOT NULL,
	[gia_cung_cap] [decimal](18, 0) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nha_cung_cap] ASC,
	[ma_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhan_vien]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhan_vien](
	[ma_nhan_vien] [int] IDENTITY(1,1) NOT NULL,
	[ten_nhan_vien] [nvarchar](255) NOT NULL,
	[chuc_vu] [nvarchar](50) NULL,
	[sdt] [varchar](20) NOT NULL,
	[dia_chi] [nvarchar](255) NULL,
	[ngay_vao_lam] [date] NULL,
	[tai_khoan_id] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nhan_vien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhap_hang]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhap_hang](
	[ma_nhap_hang] [int] IDENTITY(1,1) NOT NULL,
	[ma_nhan_vien] [int] NULL,
	[ma_nha_cung_cap] [int] NULL,
	[ngay_nhap] [datetime] NULL,
	[trang_thai] [nvarchar](50) NULL,
	[ghi_chu] [nvarchar](255) NULL,
	[tong_so_luong] [int] NOT NULL,
	[tong_gia_tien] [decimal](18, 0) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nhap_hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhom_loai]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhom_loai](
	[ma_nhom_loai] [int] IDENTITY(1,1) NOT NULL,
	[ten_nhom_loai] [nvarchar](255) NOT NULL,
	[chi_tiet] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nhom_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhom_quyen]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhom_quyen](
	[id_nhom_quyen] [int] IDENTITY(1,1) NOT NULL,
	[ten_nhom] [nvarchar](255) NOT NULL,
	[mo_ta] [nvarchar](255) NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_nhom_quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[phan_quyen]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phan_quyen](
	[id_man_hinh] [int] NOT NULL,
	[id_nhom_quyen] [int] NOT NULL,
	[co_quyen] [bit] NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_man_hinh] ASC,
	[id_nhom_quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phuong_thuc_thanh_toan]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phuong_thuc_thanh_toan](
	[ma_phuong_thuc] [int] IDENTITY(1,1) NOT NULL,
	[ten_phuong_thuc] [nvarchar](255) NOT NULL,
	[mo_ta] [nvarchar](255) NULL,
	[trang_thai] [nvarchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_phuong_thuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[san_pham]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[san_pham](
	[ma_san_pham] [int] IDENTITY(1,1) NOT NULL,
	[ten_san_pham] [nvarchar](255) NOT NULL,
	[ma_loai] [int] NULL,
	[ma_thuong_hieu] [int] NULL,
	[giam_gia] [decimal](5, 2) NULL,
	[so_luong_kich_thuoc] [int] NULL,
	[so_luong_mau_sac] [int] NULL,
	[so_luong] [int] NULL,
	[mo_ta] [nvarchar](max) NULL,
	[gia_binh_quan] [decimal](18, 0) NULL,
	[hinh_thuc_ban] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tai_khoan]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tai_khoan](
	[tai_khoan_id] [int] IDENTITY(1,1) NOT NULL,
	[ten_dang_nhap] [nvarchar](255) NOT NULL,
	[mat_khau_hash] [nvarchar](max) NULL,
	[hoat_dong] [bit] NULL,
	[is_oauth] [bit] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[tai_khoan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tai_khoan_nhom_quyen]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tai_khoan_nhom_quyen](
	[tai_khoan_id] [int] NOT NULL,
	[id_nhom_quyen] [int] NOT NULL,
	[create_at] [datetime] NULL,
	[update_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[tai_khoan_id] ASC,
	[id_nhom_quyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thong_tin_san_pham]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thong_tin_san_pham](
	[ma_thong_tin_san_pham] [int] IDENTITY(1,1) NOT NULL,
	[ma_san_pham] [int] NULL,
	[key_attribute] [nvarchar](255) NOT NULL,
	[value_attribute] [nvarchar](max) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_thong_tin_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thuoc_tinh_san_pham]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thuoc_tinh_san_pham](
	[ma_thuoc_tinh] [int] IDENTITY(1,1) NOT NULL,
	[ma_san_pham] [int] NULL,
	[ma_kich_thuoc] [int] NULL,
	[ma_mau_sac] [int] NULL,
	[so_luong_ton] [int] NULL,
	[gia_ban] [decimal](18, 0) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_thuoc_tinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thuong_hieu]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thuong_hieu](
	[ma_thuong_hieu] [int] IDENTITY(1,1) NOT NULL,
	[ten_thuong_hieu] [nvarchar](255) NOT NULL,
	[mo_ta] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_thuong_hieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (1, 4, 5, CAST(250.00 AS Decimal(10, 2)), CAST(212.50 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (1, 16, 2, CAST(472.50 AS Decimal(10, 2)), CAST(283.50 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (2, 3, 3, CAST(234.00 AS Decimal(10, 2)), CAST(210.60 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (2, 6, 2, CAST(285.00 AS Decimal(10, 2)), CAST(242.25 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (3, 1, 1, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (3, 2, 1, CAST(216.00 AS Decimal(10, 2)), CAST(194.40 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (3, 6, 2, CAST(285.00 AS Decimal(10, 2)), CAST(242.25 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (4, 1, 1, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (5, 1, 1, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (6, 1, 1, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (6, 2, 1, CAST(216.00 AS Decimal(10, 2)), CAST(194.40 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (6, 3, 2, CAST(234.00 AS Decimal(10, 2)), CAST(210.60 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (7, 1, 3, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (9, 6, 1, CAST(285.00 AS Decimal(10, 2)), CAST(242.25 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (10, 3, 2, CAST(234.00 AS Decimal(10, 2)), CAST(210.60 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (11, 3, 2, CAST(234.00 AS Decimal(10, 2)), CAST(210.60 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (12, 3, 3, CAST(234.00 AS Decimal(10, 2)), CAST(210.60 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (14, 2, 1, CAST(216.00 AS Decimal(10, 2)), CAST(194.40 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (16, 1, 1, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (16, 4, 1, CAST(250.00 AS Decimal(10, 2)), CAST(212.50 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (17, 1, 2, CAST(210.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (17, 16, 2, CAST(472.50 AS Decimal(10, 2)), CAST(283.50 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (18, 3, 3, CAST(234.00 AS Decimal(10, 2)), CAST(210.60 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (18, 5, 2, CAST(262.50 AS Decimal(10, 2)), CAST(223.13 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (18, 6, 2, CAST(285.00 AS Decimal(10, 2)), CAST(242.25 AS Decimal(10, 2)), NULL, NULL, NULL)
INSERT [dbo].[chi_tiet_hoa_don] ([ma_hoa_don], [ma_thuoc_tinh], [so_luong], [gia], [giagiam], [trang_thai], [created_at], [updated_at]) VALUES (19, 2, 1, CAST(216.00 AS Decimal(10, 2)), CAST(194.40 AS Decimal(10, 2)), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[hoa_don] ON 

INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (1, NULL, 1, CAST(N'2024-11-19T16:38:09.353' AS DateTime), NULL, NULL, 3, 0, CAST(0.00 AS Decimal(10, 2)), CAST(1629.50 AS Decimal(10, 2)), NULL, 0, CAST(1629.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (2, NULL, 1, CAST(N'2024-11-19T16:40:06.397' AS DateTime), NULL, NULL, 3, 0, CAST(0.00 AS Decimal(10, 2)), CAST(1116.30 AS Decimal(10, 2)), NULL, 0, CAST(1116.30 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (3, NULL, 1, CAST(N'2024-11-19T16:40:59.150' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(867.90 AS Decimal(10, 2)), NULL, 0, CAST(867.90 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (4, NULL, 1, CAST(N'2024-11-22T00:49:08.347' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, 0, CAST(189.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (5, NULL, 1, CAST(N'2024-11-22T00:49:32.320' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(189.00 AS Decimal(10, 2)), NULL, 0, CAST(189.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (6, NULL, 1, CAST(N'2024-11-22T00:56:55.333' AS DateTime), NULL, NULL, 3, 0, CAST(0.00 AS Decimal(10, 2)), CAST(804.60 AS Decimal(10, 2)), NULL, 0, CAST(804.60 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (7, 7, 1, CAST(N'2024-11-22T01:11:18.850' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(567.00 AS Decimal(10, 2)), NULL, 0, CAST(567.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (9, 4, 1, CAST(N'2024-11-22T01:12:29.783' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(242.25 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), 1, CAST(192.25 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (10, NULL, 1, CAST(N'2024-11-22T02:10:50.657' AS DateTime), 3, NULL, 3, 0, CAST(42.12 AS Decimal(10, 2)), CAST(421.20 AS Decimal(10, 2)), NULL, 0, CAST(379.08 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (11, NULL, 1, CAST(N'2024-11-22T02:11:26.583' AS DateTime), 2, NULL, 3, 0, CAST(84.24 AS Decimal(10, 2)), CAST(421.20 AS Decimal(10, 2)), NULL, 0, CAST(336.96 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (12, NULL, 1, CAST(N'2024-11-22T03:09:55.357' AS DateTime), 3, NULL, 1, 0, CAST(63.18 AS Decimal(10, 2)), CAST(631.80 AS Decimal(10, 2)), NULL, 0, CAST(568.62 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (14, NULL, 1, CAST(N'2024-11-22T03:15:22.797' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(194.40 AS Decimal(10, 2)), NULL, 0, CAST(194.40 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (16, NULL, 1, CAST(N'2024-11-22T03:20:11.603' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(401.50 AS Decimal(10, 2)), NULL, 0, CAST(401.50 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (17, NULL, 1, CAST(N'2024-11-22T03:20:31.450' AS DateTime), NULL, NULL, 3, 0, CAST(0.00 AS Decimal(10, 2)), CAST(945.00 AS Decimal(10, 2)), NULL, 0, CAST(945.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (18, NULL, 1, CAST(N'2024-11-22T03:22:53.987' AS DateTime), NULL, NULL, 3, 0, CAST(0.00 AS Decimal(10, 2)), CAST(1562.56 AS Decimal(10, 2)), NULL, 0, CAST(1562.56 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
INSERT [dbo].[hoa_don] ([ma_hoa_don], [ma_khach_hang], [ma_nhan_vien], [ngay_lap], [ma_khuyen_mai], [trang_thai_giao_hang], [ma_phuong_thuc], [tong_so_luong_mua], [tien_giam], [tong_tien], [tien_doi_diem], [doi_diem], [tong_gia_tri], [tong_don_hang], [hinh_thuc_ban], [trang_thai_doi_tra], [created_at], [updated_at]) VALUES (19, 1, 1, CAST(N'2024-11-22T03:24:30.840' AS DateTime), NULL, NULL, 1, 0, CAST(0.00 AS Decimal(10, 2)), CAST(194.40 AS Decimal(10, 2)), NULL, 0, CAST(194.40 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 0, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[hoa_don] OFF
GO
SET IDENTITY_INSERT [dbo].[khach_hang] ON 

INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (1, N'Nguyễn Văn Hòa', N'0931234567', N'789 Đường PQR, TP.HCM', 102, 0, 6, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (2, N'Trần Thị Mai', N'0937654321', N'123 Đường STU, TP.HCM', 200, 0, 7, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (3, N'Lê Văn Nam', N'0942345678', N'456 Đường VWX, TP.HCM', 150, 0, 8, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (4, N'Phạm Thị Oanh', N'0948765432', N'654 Đường YZ, TP.HCMM', 2, 50, 9, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (5, N'Nguyễn Minh Quân', N'0953456789', N'321 Đường ABCD, TP.HCM', 300, 0, 10, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (7, N'Nguyễn Văn Phú', N'0377985411', NULL, 6, 0, 15, CAST(N'2024-11-21T06:57:32.917' AS DateTime), CAST(N'2024-11-21T06:57:32.917' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (8, N'Nguyễn Văn Phú', N'0377985409', N'Sài Gòn', 0, 0, 16, CAST(N'2024-11-21T10:09:45.550' AS DateTime), CAST(N'2024-11-21T10:09:45.550' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (9, N'Nguyễn Văn Phú', N'0377985123', NULL, 0, 0, 17, CAST(N'2024-11-21T16:05:22.417' AS DateTime), CAST(N'2024-11-21T16:05:22.417' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (10, N'Nguyễn Văn Phú', N'0377985478', NULL, 0, 0, 18, CAST(N'2024-11-21T16:14:14.437' AS DateTime), CAST(N'2024-11-21T16:14:14.437' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (11, N'Nguyễn Phú', N'0377985112', NULL, 0, 0, 19, CAST(N'2024-11-21T21:22:33.817' AS DateTime), CAST(N'2024-11-21T21:22:33.817' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (12, N'thanh truc', N'0379466568', NULL, 0, 0, 20, CAST(N'2024-11-21T23:32:27.253' AS DateTime), CAST(N'2024-11-21T23:32:27.253' AS DateTime))
INSERT [dbo].[khach_hang] ([ma_khach_hang], [ten_khach_hang], [dien_thoai], [dia_chi], [diem_thuong], [diem_da_doi], [tai_khoan_id], [created_at], [updated_at]) VALUES (38, N'Thanh Trúc', N'0943854885', N'133 BGH', 0, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[khach_hang] OFF
GO
SET IDENTITY_INSERT [dbo].[khuyen_mai] ON 

INSERT [dbo].[khuyen_mai] ([ma_khuyen_mai], [code], [gia_tri], [thoi_gian_bat_dau], [thoi_gian_ket_thuc], [so_luong_toi_da], [so_luong_da_dung], [tinh_trang], [ghi_chu], [gia_tri_hoa_don_toi_thieu], [ma_nhan_vien], [created_at], [updated_at]) VALUES (1, N'KM01', CAST(15.00 AS Decimal(10, 2)), CAST(N'2024-11-01' AS Date), CAST(N'2024-12-01' AS Date), 100, 10, N'Active', N'Khuy?n mãi tháng 11', CAST(200.00 AS Decimal(10, 2)), 3, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khuyen_mai] ([ma_khuyen_mai], [code], [gia_tri], [thoi_gian_bat_dau], [thoi_gian_ket_thuc], [so_luong_toi_da], [so_luong_da_dung], [tinh_trang], [ghi_chu], [gia_tri_hoa_don_toi_thieu], [ma_nhan_vien], [created_at], [updated_at]) VALUES (2, N'KM02', CAST(20.00 AS Decimal(10, 2)), CAST(N'2024-11-15' AS Date), CAST(N'2024-12-15' AS Date), 50, 50, N'Active', N'Gi?m giá d?p l?', CAST(150.00 AS Decimal(10, 2)), 4, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[khuyen_mai] ([ma_khuyen_mai], [code], [gia_tri], [thoi_gian_bat_dau], [thoi_gian_ket_thuc], [so_luong_toi_da], [so_luong_da_dung], [tinh_trang], [ghi_chu], [gia_tri_hoa_don_toi_thieu], [ma_nhan_vien], [created_at], [updated_at]) VALUES (3, N'KM03', CAST(10.00 AS Decimal(10, 2)), CAST(N'2024-10-01' AS Date), CAST(N'2024-11-20' AS Date), 200, 52, N'h?t h?n', N'Gi?m giá cu?i nam', CAST(100.00 AS Decimal(10, 2)), 5, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[khuyen_mai] OFF
GO
SET IDENTITY_INSERT [dbo].[kich_thuoc] ON 

INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (1, N'S', CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (2, N'M', CAST(0.05 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (3, N'L', CAST(0.10 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (4, N'XL', CAST(0.15 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (5, N'XXL', CAST(0.20 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (6, N'3XL', CAST(0.25 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (7, N'4XL', CAST(0.30 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (8, N'5XL', CAST(0.35 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[kich_thuoc] ([ma_kich_thuoc], [ten_kich_thuoc], [phu_phi_size], [created_at], [updated_at]) VALUES (9, N'Freesize', CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
SET IDENTITY_INSERT [dbo].[kich_thuoc] OFF
GO
SET IDENTITY_INSERT [dbo].[loai_san_pham] ON 

INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (1, N'Áo Thun Nam', 1, N'Áo thun dành cho nam với chất liệu cotton thoáng mát.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (2, N'Áo Thun Nữ', 1, N'Áo thun dành cho nữ với nhiều màu sắc thời trang.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (3, N'Áo Sơ Mi Nam', 2, N'Áo sơ mi nam thích hợp cho công sở.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (4, N'Áo Sơ Mi Nữ', 2, N'Áo sơ mi nữ với thiết kế thanh lịch, tinh tế.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (5, N'Áo Khoác Gió', 3, N'Áo khoác gió phù hợp cho mọi thời tiết.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (6, N'Áo Khoác Dạ', 3, N'Áo khoác dạ cao cấp cho mùa đông.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (7, N'Quần Jeans Nam', 4, N'Quần jeans nam phong cách và bền bỉ.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (8, N'Quần Jeans Nữ', 4, N'Quần jeans nữ với thiết kế tôn dáng.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (9, N'Quần Short Nam', 5, N'Quần short nam thoải mái cho mùa hè.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (10, N'Quần Short Nữ', 5, N'Quần short nữ phong cách thời trang.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (11, N'Váy Ngắn', 6, N'Váy ngắn nữ phù hợp cho dịp đi chơi.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (12, N'Váy Dài', 6, N'Váy dài nữ cho dịp lễ hội, sang trọng.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (13, N'Đầm ôm', 7, N'Đầm ôm nữ thời trang, mang đến sự thanh lịch.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (14, N'Đầm dài', 7, N'Đầm dài nữ thời trang, mang đến phong cách lịch sự.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (15, N'Áo len nam', 8, N'Áo len nam thích hợp cho công sở.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (16, N'Áo len nữ', 8, N'Áo len nữ với thiết kế thanh lịch, tinh tế.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (17, N'Quần ống rộng', 9, N'Quần ống rộng phù hợp cho cả nam và nữ', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (18, N'Quần jogger túi hộp', 9, N'Quần jogger túi hộp phù hợp cho nam trong những ngày hè', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (19, N'Bộ đồ thời trang', 10, N'Bộ đồ thời trang phù hợp với phong cách trẻ trung, năng động', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[loai_san_pham] ([ma_loai], [ten_loai], [ma_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (20, N'Bộ đồ thể thao', 10, N'Bộ đồ thể thao phù hợp cho tập thể thao', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[loai_san_pham] OFF
GO
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (1, N'Màn Hình Chính', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (2, N'Danh Mục', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (3, N'Sản Phẩm', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (4, N'Bán Hàng', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (5, N'Nhập Hàng', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (6, N'Hóa Đơn', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (7, N'Kiểm Duyệt Sản Phẩm', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (8, N'Nhà Cung Cấp', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (9, N'Báo Cáo Thống Kê', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (10, N'Hệ Thống Quản Lý', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (11, N'Nhân Viên', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (12, N'Khách Hàng', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (13, N'Tài Khoản', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (14, N'Quyền', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (15, N'Thông Tin Cá Nhân', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[man_hinh] ([id_man_hinh], [ten_man_hinh], [create_at], [update_at]) VALUES (16, N'Đăng Xuất', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[mau_sac] ON 

INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (1, N'Đỏ', CAST(0.05 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (2, N'Xanh', CAST(0.03 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (3, N'Vàng', CAST(0.07 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (4, N'Đen', CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (5, N'Trắng', CAST(0.00 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (6, N'Hồng', CAST(0.04 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (7, N'Xám', CAST(0.02 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (8, N'Nâu', CAST(0.03 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (9, N'Be', CAST(0.06 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
INSERT [dbo].[mau_sac] ([ma_mau_sac], [ten_mau_sac], [phu_phi_mausac], [created_at], [updated_at]) VALUES (10, N'Xanh lá', CAST(0.05 AS Decimal(10, 2)), CAST(N'2024-11-19T16:35:49.913' AS DateTime), CAST(N'2024-11-19T16:35:49.913' AS DateTime))
SET IDENTITY_INSERT [dbo].[mau_sac] OFF
GO
SET IDENTITY_INSERT [dbo].[nha_cung_cap] ON 

INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (1, N'Công Ty TNHH Thời Trang ABC', N'123 Đường A, Quận 1, TP.HCM', N'0901234567', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (2, N'Nhà Cung Cấp Thời Trang XYZ', N'456 Đường B, Quận 2, TP.HCM', N'0909876543', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (3, N'Công Ty TNHH Thời Trang DEF', N'789 Đường C, Quận 3, TP.HCM', N'0912345678', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (4, N'Công Ty Thời Trang GHI', N'321 Đường D, Quận 4, TP.HCM', N'0923456789', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (5, N'Công Ty TNHH Thời Trang JKL', N'654 Đường E, Quận 5, TP.HCM', N'0934567890', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (6, N'Nhà Cung Cấp Mặc Đẹp', N'987 Đường F, Quận 6, TP.HCM', N'0945678901', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (7, N'Công Ty TNHH Thời Trang MNO', N'135 Đường G, Quận 7, TP.HCM', N'0956789012', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (8, N'Nhà Cung Cấp Thời Trang PQR', N'246 Đường H, Quận 8, TP.HCM', N'0967890123', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (9, N'Công Ty Thời Trang STU', N'357 Đường I, Quận 9, TP.HCM', N'0978901234', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [dien_thoai], [created_at], [updated_at]) VALUES (10, N'Công Ty TNHH Thời Trang VWX', N'468 Đường J, Quận 10, TP.HCM', N'0989012345', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[nha_cung_cap] OFF
GO
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (1, 1, CAST(180000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (1, 2, CAST(250000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (1, 3, CAST(320000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (2, 4, CAST(350000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (2, 5, CAST(560000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (2, 6, CAST(450000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (3, 7, CAST(220000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (3, 8, CAST(180000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (3, 9, CAST(150000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (4, 10, CAST(310000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (4, 11, CAST(190000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (4, 12, CAST(260000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (5, 13, CAST(400000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (5, 14, CAST(550000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (5, 15, CAST(300000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (6, 2, CAST(250000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (6, 11, CAST(160000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (6, 1, CAST(280000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (7, 9, CAST(120000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (7, 6, CAST(340000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (8, 1, CAST(200000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (8, 3, CAST(290000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (8, 5, CAST(600000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (9, 7, CAST(210000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (9, 9, CAST(155000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (9, 10, CAST(320000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (10, 12, CAST(270000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (10, 14, CAST(580000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
INSERT [dbo].[nha_cung_cap_san_pham] ([ma_nha_cung_cap], [ma_san_pham], [gia_cung_cap], [created_at], [updated_at]) VALUES (10, 15, CAST(310000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:35:54.850' AS DateTime), CAST(N'2024-11-19T16:35:54.850' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[nhan_vien] ON 

INSERT [dbo].[nhan_vien] ([ma_nhan_vien], [ten_nhan_vien], [chuc_vu], [sdt], [dia_chi], [ngay_vao_lam], [tai_khoan_id], [created_at], [updated_at]) VALUES (1, N'Nguyễn Văn An', N'Admin', N'0901234567', N'123 Đường ABC, TP.HCM', CAST(N'2023-01-01' AS Date), 1, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[nhan_vien] ([ma_nhan_vien], [ten_nhan_vien], [chuc_vu], [sdt], [dia_chi], [ngay_vao_lam], [tai_khoan_id], [created_at], [updated_at]) VALUES (2, N'Trần Thị Bình', N'Nhân viên bán hàng', N'0907654321', N'456 Ðu?ng DEF, TP.HCM', CAST(N'2023-02-01' AS Date), 2, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[nhan_vien] ([ma_nhan_vien], [ten_nhan_vien], [chuc_vu], [sdt], [dia_chi], [ngay_vao_lam], [tai_khoan_id], [created_at], [updated_at]) VALUES (3, N'Lê Văn Cường', N'Nhân viên bán hàng', N'0912345678', N'789 Ðu?ng GHI, TP.HCM', CAST(N'2023-03-01' AS Date), 3, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[nhan_vien] ([ma_nhan_vien], [ten_nhan_vien], [chuc_vu], [sdt], [dia_chi], [ngay_vao_lam], [tai_khoan_id], [created_at], [updated_at]) VALUES (4, N'Phạm Thị Duyên', N'Admin', N'0918765432', N'321 Đường JKL, TP.HCM', CAST(N'2023-04-01' AS Date), 4, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[nhan_vien] ([ma_nhan_vien], [ten_nhan_vien], [chuc_vu], [sdt], [dia_chi], [ngay_vao_lam], [tai_khoan_id], [created_at], [updated_at]) VALUES (5, N'Nguyễn Thị Hương', N'Nhân viên bán hàng', N'0923456789', N'654 Đường MNO, TP.HCM', CAST(N'2023-05-01' AS Date), 5, CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[nhan_vien] OFF
GO
SET IDENTITY_INSERT [dbo].[nhom_loai] ON 

INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (1, N'Áo Thun', N'Nhóm các loại áo thun', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (2, N'Áo Sơ Mi', N'Nhóm các loại áo sơ mi', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (3, N'Áo Khoác', N'Nhóm các loại áo khoác', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (4, N'Quần Jeans', N'Nhóm các loại quần jeans', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (5, N'Quần Short', N'Nhóm các loại quần short', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (6, N'Váy', N'Nhóm các loại váy nữ', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (7, N'Đầm', N'Nhóm các loại đầm', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (8, N'Áo len', N'Nhóm các loại áo len', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (9, N'Quần dài', N'Nhóm các loại quần dài', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
INSERT [dbo].[nhom_loai] ([ma_nhom_loai], [ten_nhom_loai], [chi_tiet], [created_at], [updated_at]) VALUES (10, N'Đồ theo bộ', N'Nhóm các loại đồ mặc theo bộ', CAST(N'2024-11-19T16:35:49.887' AS DateTime), CAST(N'2024-11-19T16:35:49.887' AS DateTime))
SET IDENTITY_INSERT [dbo].[nhom_loai] OFF
GO
SET IDENTITY_INSERT [dbo].[nhom_quyen] ON 

INSERT [dbo].[nhom_quyen] ([id_nhom_quyen], [ten_nhom], [mo_ta], [create_at], [update_at]) VALUES (1, N'Admin', N'Admin', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[nhom_quyen] ([id_nhom_quyen], [ten_nhom], [mo_ta], [create_at], [update_at]) VALUES (2, N'NV', N'Nhân viên', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[nhom_quyen] ([id_nhom_quyen], [ten_nhom], [mo_ta], [create_at], [update_at]) VALUES (3, N'QL', N'Quản Lí', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[nhom_quyen] OFF
GO
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (1, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (1, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (1, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (2, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (2, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (2, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (3, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (3, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (3, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (4, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (4, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (4, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (5, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (5, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (5, 3, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (6, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (6, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (6, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (7, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (7, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (7, 3, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (8, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (8, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (8, 3, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (9, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (9, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (9, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (10, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (10, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (10, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (11, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (11, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (11, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (12, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (12, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (12, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (13, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (13, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (13, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (14, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (14, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (14, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (15, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (15, 2, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (15, 3, 0, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (16, 1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (16, 2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[phan_quyen] ([id_man_hinh], [id_nhom_quyen], [co_quyen], [create_at], [update_at]) VALUES (16, 3, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[phuong_thuc_thanh_toan] ON 

INSERT [dbo].[phuong_thuc_thanh_toan] ([ma_phuong_thuc], [ten_phuong_thuc], [mo_ta], [trang_thai], [created_at], [updated_at]) VALUES (1, N'Tiền mặt', N'Thanh toán khi nhận hàng', N'Active', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
INSERT [dbo].[phuong_thuc_thanh_toan] ([ma_phuong_thuc], [ten_phuong_thuc], [mo_ta], [trang_thai], [created_at], [updated_at]) VALUES (3, N'Chuyển khoản', N'Chuyển khoản ngân hàng', N'Inactive', CAST(N'2024-11-19T16:36:19.580' AS DateTime), CAST(N'2024-11-19T16:36:19.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[phuong_thuc_thanh_toan] OFF
GO
SET IDENTITY_INSERT [dbo].[san_pham] ON 

INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (1, N'Áo thun Basic', 1, 1, CAST(10.00 AS Decimal(5, 2)), 5, 4, 79, N'Áo thun basic thoải mái, phù hợp cho mọi dịp.', CAST(200000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (2, N'Quần jean Skinny', 7, 2, CAST(15.00 AS Decimal(5, 2)), 3, 3, 44, N'Quần jean skinny thời trang, tôn dáng.', CAST(250000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (3, N'Váy maxi hoa', 11, 3, CAST(20.00 AS Decimal(5, 2)), 4, 2, 28, N'Váy maxi hoa nhẹ nhàng, thích hợp cho mùa hè.', CAST(320000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (4, N'Áo khoác denim', 6, 4, CAST(25.00 AS Decimal(5, 2)), 2, 3, 40, N'Áo khoác denim cá tính, phong cách trẻ trung.', CAST(350000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (5, N'Bộ đồ thể thao', 19, 7, CAST(35.00 AS Decimal(5, 2)), 5, 3, 25, N'Bộ đồ thể thao thoải mái, lý tưởng cho việc tập luyện.', CAST(220000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (6, N'Áo sơ mi nam', 4, 8, CAST(22.00 AS Decimal(5, 2)), 2, 4, 45,  N'Áo sơ mi nữ thanh lịch, phù hợp cho công sở.', CAST(180000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (7, N'Quần shorts nam', 9, 9, CAST(18.00 AS Decimal(5, 2)), 3, 3, 55, N'Quần shorts nam thoải mái, thích hợp cho mùa hè.', CAST(155000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (8, N'Đầm ôm', 13, 10, CAST(28.00 AS Decimal(5, 2)), 4, 2, 35, N'Đầm ôm tôn dáng, lý tưởng cho các bữa tiệc.', CAST(320000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (9, N'Áo len nữ', 16, 1, CAST(15.00 AS Decimal(5, 2)), 2, 3, 50, N'Áo len nữ ấm áp, thích hợp cho mùa đông.', CAST(190000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (10, N'Quần ống rộng', 17, 2, CAST(20.00 AS Decimal(5, 2)), 4, 2, 30, N'Quần ống rộng thời trang, dễ phối đồ.', CAST(270000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (11, N'Áo khoác bomber', 6, 3, CAST(35.00 AS Decimal(5, 2)), 3, 4, 40, N'Áo khoác bomber trẻ trung, phong cách.', CAST(400000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (12, N'Váy công chúa', 12, 5, CAST(50.00 AS Decimal(5, 2)), 1, 2, 15, N'Váy công chúa xinh xắn cho bé.', CAST(310000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (13, N'Áo thun dài tay', 1, 7, CAST(12.00 AS Decimal(5, 2)), 4, 5, 60, N'Áo thun dài tay thoải mái cho mùa lạnh.', CAST(160000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (14, N'Quần jogger', 18, 8, CAST(22.00 AS Decimal(5, 2)), 3, 4, 55, N'Quần jogger năng động, lý tưởng cho việc tập luyện.', CAST(280000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [ma_loai], [ma_thuong_hieu], [giam_gia], [so_luong_kich_thuoc], [so_luong_mau_sac], [so_luong], [mo_ta], [gia_binh_quan], [hinh_thuc_ban], [created_at], [updated_at]) VALUES (15, N'Đầm suông', 14, 10, CAST(30.00 AS Decimal(5, 2)), 2, 3, 35, N'Đầm suông dễ chịu, phù hợp cho đi làm.', CAST(340000 AS Decimal(18, 0)), 1, CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[san_pham] OFF
GO
SET IDENTITY_INSERT [dbo].[hinh_anh_san_pham] ON 
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (1, 1, N'/Content/assets/images/sp1.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (2, 2, N'/Content/assets/images/sp2.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (3, 3, N'/Content/assets/images/sp3.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (4, 4, N'/Content/assets/images/sp4.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (5, 5, N'/Content/assets/images/sp5.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (6, 6, N'/Content/assets/images/sp6.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (7, 7, N'/Content/assets/images/sp7.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (8, 8, N'/Content/assets/images/sp8.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (9, 9, N'/Content/assets/images/sp9.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (10, 10, N'/Content/assets/images/sp10.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (11, 11, N'/Content/assets/images/sp11.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (12, 12, N'/Content/assets/images/sp12.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (13, 13, N'/Content/assets/images/sp13.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (14, 14, N'/Content/assets/images/sp14.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[hinh_anh_san_pham] ([ma_hinh_anh], [ma_san_pham], [hinh_anh], [created_at], [updated_at]) VALUES (15, 15, N'/Content/assets/images/sp15.png', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[hinh_anh_san_pham] OFF
GO
SET IDENTITY_INSERT [dbo].[tai_khoan] ON 

INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (1, N'admin', N'$2a$11$WBKFBAIWSq1bUKI7KckMeupwTzWwBsrAZTqklxBb8cExaZP9ggL4.', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (2, N'admin2', N'hashed_password_admin2', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (3, N'nv_banhang1', N'hashed_password_nv1', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (4, N'nv_banhang2', N'hashed_password_nv2', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (5, N'nv_banhang3', N'hashed_password_nv3', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (6, N'ql_nhanvien', N'hashed_password_ql1', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (7, N'khachhang1', N'hashed_password_kh1', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (8, N'khachhang2', N'hashed_password_kh2', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (9, N'khachhang3', N'hashed_password_kh3', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (10, N'khachhang4', N'hashed_password_kh4', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (11, N'khachhang5', N'hashed_password_kh5', 1, 0, CAST(N'2024-11-19T16:36:19.577' AS DateTime), CAST(N'2024-11-19T16:36:19.577' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (14, N'vuonggiaphu', N'$2b$10$1Wklr0YJOzxuuTsKWvyvzeOAMAzYyejQRevD7DhwGSoiKwr1o0xBa', NULL, 0, CAST(N'2024-11-21T06:55:14.680' AS DateTime), CAST(N'2024-11-21T06:55:14.680' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (15, N'nguyenvanphu.hufi@gmail.com', N'$2b$10$ViDObwBGHLxkhZzb6hUp7OLwtI5FnNMdF2ub9v3zy/W2DvDSgSK0i', 1, 0, CAST(N'2024-11-21T06:57:32.907' AS DateTime), CAST(N'2024-11-21T06:57:32.907' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (16, N'vanphudev.aws', N'$2b$10$gRm88ATI/hejTjosu1CksO3h.ulal7WlVn5R6UIWKCRXL0U.rb4Qu', 1, 0, CAST(N'2024-11-21T10:09:45.540' AS DateTime), CAST(N'2024-11-21T10:09:45.540' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (17, N'vuonggiaphu123', N'$2b$10$0ar7JQInGT2AOfYEGjnLJOmt2MRp9dOp89eR1zcGq91DqfGVCArHC', 1, 0, CAST(N'2024-11-21T16:05:22.410' AS DateTime), CAST(N'2024-11-21T16:05:22.410' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (18, N'vanphudev.aws123', N'$2b$10$ouewG06LQfo7bAEDEcydEuwLx0/5IOaOoeIiPtx6bHaDYbM5d0qg6', 1, 0, CAST(N'2024-11-21T16:14:14.430' AS DateTime), CAST(N'2024-11-21T16:14:14.430' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (19, N'phuphu', N'$2b$10$nRLjKomrJNZchSc5oaCwi.sj4uZ0s/TYNVQF9zSl4he9tuKedRN76', 1, 0, CAST(N'2024-11-21T21:22:33.807' AS DateTime), CAST(N'2024-11-21T21:22:33.807' AS DateTime))
INSERT [dbo].[tai_khoan] ([tai_khoan_id], [ten_dang_nhap], [mat_khau_hash], [hoat_dong], [is_oauth], [created_at], [updated_at]) VALUES (20, N'TrucTTT8', N'$2b$10$rFl8mtraPzoP9ZbBGdRxtO9gyEAgXOGnoker65IH46XcARrRNQAb6', 1, 0, CAST(N'2024-11-21T23:32:27.247' AS DateTime), CAST(N'2024-11-21T23:32:27.247' AS DateTime))
SET IDENTITY_INSERT [dbo].[tai_khoan] OFF
GO
INSERT [dbo].[tai_khoan_nhom_quyen] ([tai_khoan_id], [id_nhom_quyen], [create_at], [update_at]) VALUES (1, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[tai_khoan_nhom_quyen] ([tai_khoan_id], [id_nhom_quyen], [create_at], [update_at]) VALUES (2, 1, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[tai_khoan_nhom_quyen] ([tai_khoan_id], [id_nhom_quyen], [create_at], [update_at]) VALUES (3, 2, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[tai_khoan_nhom_quyen] ([tai_khoan_id], [id_nhom_quyen], [create_at], [update_at]) VALUES (4, 2, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[tai_khoan_nhom_quyen] ([tai_khoan_id], [id_nhom_quyen], [create_at], [update_at]) VALUES (5, 2, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
INSERT [dbo].[tai_khoan_nhom_quyen] ([tai_khoan_id], [id_nhom_quyen], [create_at], [update_at]) VALUES (6, 3, CAST(N'2024-11-19T16:36:19.650' AS DateTime), CAST(N'2024-11-19T16:36:19.650' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[thong_tin_san_pham] ON 

INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (1, 1, N'Kích thước', N'S, M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (2, 1, N'Màu sắc', N'Đỏ, Xanh, Đen', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (3, 1, N'Chất liệu', N'Len cao cấp', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (4, 1, N'Phong cách', N'Thời trang công sở', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (5, 1, N'Hướng dẫn bảo quản', N'Giặt tay, không dùng chất tẩy', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (6, 1, N'Đối tượng sử dụng', N'Nữ giới, tuổi từ 18-35', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (7, 1, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (8, 1, N'Thời gian bảo hành', N'6 tháng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (9, 2, N'Kích thước', N'S, M, L', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (10, 2, N'Màu sắc', N'Trắng, Đen', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (11, 2, N'Chất liệu', N'Cotton thoáng khí', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (12, 2, N'Phong cách', N'Thời trang hàng ngày', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (13, 2, N'Hướng dẫn bảo quản', N'Giặt máy, phơi nắng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (14, 2, N'Đối tượng sử dụng', N'Nữ giới, mọi lứa tuổi', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (15, 2, N'Xuất xứ', N'Thái Lan', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (16, 2, N'Thời gian bảo hành', N'1 năm', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (17, 3, N'Kích thước', N'M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (18, 3, N'Màu sắc', N'Đen, Xanh, Cam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (19, 3, N'Chất liệu', N'Nylon chống thấm', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (20, 3, N'Phong cách', N'Thể thao, đường phố', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (21, 3, N'Hướng dẫn bảo quản', N'Giặt tay, không ủi', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (22, 3, N'Đối tượng sử dụng', N'Nam giới, tuổi từ 18-30', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (23, 3, N'Xuất xứ', N'Hàn Quốc', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (24, 3, N'Thời gian bảo hành', N'3 tháng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (25, 4, N'Kích thước', N'36, 37, 38, 39, 40', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (26, 4, N'Màu sắc', N'Đen, Đỏ, Vàng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (27, 4, N'Chất liệu', N'Da thật, đế cao su', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (28, 4, N'Phong cách', N'Dự tiệc, sang trọng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (29, 4, N'Hướng dẫn bảo quản', N'Dùng chất bảo vệ da, không đi mưa', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (30, 4, N'Đối tượng sử dụng', N'Nữ giới, các buổi tiệc, sự kiện', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (31, 4, N'Xuất xứ', N'Ý', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (32, 4, N'Thời gian bảo hành', N'6 tháng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (33, 5, N'Kích thước', N'2-3 tuổi, 4-5 tuổi, 6-7 tuổi', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (34, 5, N'Màu sắc', N'Hồng, Trắng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (35, 5, N'Chất liệu', N'Cotton mềm mại', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (36, 5, N'Phong cách', N'Dễ thương, ngọt ngào', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (37, 5, N'Hướng dẫn bảo quản', N'Giặt tay, không dùng chất tẩy', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (38, 5, N'Đối tượng sử dụng', N'Trẻ em, từ 2-7 tuổi', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (39, 5, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (40, 5, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (41, 6, N'Kích thước', N'30cm x 40cm', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (42, 6, N'Màu sắc', N'Đen, Xanh dương', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (43, 6, N'Chất liệu', N'Vải dù chống thấm nước', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (44, 6, N'Phong cách', N'Thời trang năng động', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (45, 6, N'Hướng dẫn bảo quản', N'Vệ sinh bằng khăn ướt, không ngâm nước', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (46, 6, N'Đối tượng sử dụng', N'Sinh viên, giới trẻ', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (47, 6, N'Xuất xứ', N'Trung Quốc', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (48, 6, N'Thời gian bảo hành', N'1 năm', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (49, 7, N'Kích thước', N'S, M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (50, 7, N'Màu sắc', N'Trắng, Đen, Xám', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (51, 7, N'Chất liệu', N'Cotton mềm mịn', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (52, 7, N'Phong cách', N'Thể thao, thường ngày', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (53, 7, N'Hướng dẫn bảo quản', N'Giặt máy, không phơi nắng trực tiếp', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (54, 7, N'Đối tượng sử dụng', N'Nam giới, nữ giới', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (55, 7, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (56, 7, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (57, 8, N'Kích thước', N'M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (58, 8, N'Màu sắc', N'Xám, Đen', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (59, 8, N'Chất liệu', N'Polyester, co giãn', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (60, 8, N'Phong cách', N'Thời trang thể thao', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (61, 8, N'Hướng dẫn bảo quản', N'Giặt máy, không dùng chất tẩy', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (62, 8, N'Đối tượng sử dụng', N'Nam giới, nữ giới', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (63, 8, N'Xuất xứ', N'Hàn Quốc', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (64, 8, N'Thời gian bảo hành', N'6 tháng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (65, 9, N'Kích thước', N'150cm x 50cm', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (66, 9, N'Màu sắc', N'Đỏ, Xám', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (67, 9, N'Chất liệu', N'Len cao cấp', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (68, 9, N'Phong cách', N'Thời trang mùa đông', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (69, 9, N'Hướng dẫn bảo quản', N'Giặt khô, không ngâm nước', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (70, 9, N'Đối tượng sử dụng', N'Mọi lứa tuổi', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (71, 9, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (72, 9, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (73, 10, N'Kích thước', N'S, M, L', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (74, 10, N'Màu sắc', N'Xanh navy, Đen', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (75, 10, N'Chất liệu', N'Vải tổng hợp, mềm mại', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (76, 10, N'Phong cách', N'Thời trang công sở, dạo phố', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (77, 10, N'Hướng dẫn bảo quản', N'Giặt tay, không sử dụng chất tẩy', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (78, 10, N'Đối tượng sử dụng', N'Nữ giới, tuổi từ 18-40', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (79, 10, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (80, 10, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (81, 11, N'Kích thước', N'S, M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (82, 11, N'Màu sắc', N'Xám, Đỏ, Trắng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (83, 11, N'Chất liệu', N'Acrylic, giữ ấm tốt', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (84, 11, N'Phong cách', N'Thời trang mùa đông', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (85, 11, N'Hướng dẫn bảo quản', N'Giặt tay, không vắt mạnh', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (86, 11, N'Đối tượng sử dụng', N'Nữ giới', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (87, 11, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (88, 11, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (89, 12, N'Kích thước', N'S, M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (90, 12, N'Màu sắc', N'Trắng, Đen, Xanh', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (91, 12, N'Chất liệu', N'Cotton, thoáng mát', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (92, 12, N'Phong cách', N'Thời trang công sở, dạo phố', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (93, 12, N'Hướng dẫn bảo quản', N'Giặt máy, không dùng chất tẩy mạnh', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (94, 12, N'Đối tượng sử dụng', N'Nữ giới', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (95, 12, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (96, 12, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (97, 13, N'Kích thước', N'M, L, XL', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (98, 13, N'Màu sắc', N'Đen, Xanh rêu', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (99, 13, N'Chất liệu', N'Polyester, bền và thời trang', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
GO
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (100, 13, N'Phong cách', N'Thể thao, cá tính', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (101, 13, N'Hướng dẫn bảo quản', N'Giặt tay, không ngâm lâu trong nước', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (102, 13, N'Đối tượng sử dụng', N'Nam và nữ', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (103, 13, N'Xuất xứ', N'Hàn Quốc', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (104, 13, N'Thời gian bảo hành', N'3 tháng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (105, 14, N'Kích thước', N'36, 37, 38, 39, 40', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (106, 14, N'Màu sắc', N'Đen, Đỏ, Trắng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (107, 14, N'Chất liệu', N'Da tổng hợp, đế cao su', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (108, 14, N'Phong cách', N'Dự tiệc, thời trang công sở', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (109, 14, N'Hướng dẫn bảo quản', N'Dùng chất bảo vệ giày, tránh ẩm ướt', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (110, 14, N'Đối tượng sử dụng', N'Nữ giới', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (111, 14, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (112, 14, N'Thời gian bảo hành', N'1 năm', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (113, 15, N'Kích thước', N'S, M, L', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (114, 15, N'Màu sắc', N'Hồng, Trắng', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (115, 15, N'Chất liệu', N'Vải voan, mềm mại', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (116, 15, N'Phong cách', N'Thời trang tiệc tùng, trẻ em', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (117, 15, N'Hướng dẫn bảo quản', N'Giặt tay, không ủi', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (118, 15, N'Đối tượng sử dụng', N'Trẻ em', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (119, 15, N'Xuất xứ', N'Việt Nam', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
INSERT [dbo].[thong_tin_san_pham] ([ma_thong_tin_san_pham], [ma_san_pham], [key_attribute], [value_attribute], [created_at], [updated_at]) VALUES (120, 15, N'Thời gian bảo hành', N'Không bảo hành', CAST(N'2024-11-19T16:35:49.910' AS DateTime), CAST(N'2024-11-19T16:35:49.910' AS DateTime))
SET IDENTITY_INSERT [dbo].[thong_tin_san_pham] OFF
GO
SET IDENTITY_INSERT [dbo].[thuoc_tinh_san_pham] ON 

INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (1, 1, 1, 1, 42, CAST(210000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (2, 1, 2, 2, 25, CAST(216000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (3, 1, 3, 3, 8, CAST(234000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (4, 2, 1, 4, 33, CAST(250000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (5, 2, 2, 5, 22, CAST(262500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (6, 2, 3, 6, 3, CAST(285000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (7, 3, 1, 1, 58, CAST(336000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (8, 3, 2, 4, 15, CAST(336000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (9, 3, 3, 3, 5, CAST(374400 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (10, 4, 1, 2, 45, CAST(360500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (11, 4, 2, 5, 35, CAST(367500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (12, 4, 3, 6, 25, CAST(399000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (13, 5, 1, 1, 80, CAST(630000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (14, 5, 2, 4, 70, CAST(630000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (15, 5, 3, 3, 40, CAST(702000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (16, 6, 1, 1, 96, CAST(472500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (17, 6, 2, 2, 80, CAST(486000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (18, 6, 3, 4, 60, CAST(495000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (19, 7, 1, 3, 90, CAST(235400 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (20, 7, 2, 5, 70, CAST(231000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (21, 7, 3, 6, 50, CAST(250800 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (22, 8, 1, 1, 60, CAST(189000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (23, 8, 2, 2, 50, CAST(194400 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (24, 8, 3, 4, 30, CAST(198000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (25, 9, 1, 1, 40, CAST(162750 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (26, 9, 2, 5, 30, CAST(162750 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (27, 9, 3, 6, 20, CAST(176700 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (28, 10, 1, 2, 35, CAST(329600 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (29, 10, 2, 3, 25, CAST(358400 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (30, 10, 3, 4, 15, CAST(352000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (31, 11, 1, 1, 20, CAST(199500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (32, 11, 2, 2, 15, CAST(205200 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (33, 11, 3, 3, 10, CAST(222300 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (34, 12, 1, 4, 50, CAST(270000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (35, 12, 2, 5, 25, CAST(283500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (36, 12, 3, 6, 15, CAST(307800 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (37, 13, 1, 1, 30, CAST(420000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (38, 13, 2, 2, 20, CAST(432000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (39, 13, 3, 4, 10, CAST(440000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (40, 14, 1, 5, 40, CAST(580000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (41, 14, 2, 6, 30, CAST(632200 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (42, 14, 3, 3, 20, CAST(678600 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (43, 15, 1, 1, 70, CAST(325500 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (44, 15, 2, 2, 60, CAST(334800 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
INSERT [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh], [ma_san_pham], [ma_kich_thuoc], [ma_mau_sac], [so_luong_ton], [gia_ban], [created_at], [updated_at]) VALUES (45, 15, 3, 4, 50, CAST(341000 AS Decimal(18, 0)), CAST(N'2024-11-19T16:36:04.627' AS DateTime), CAST(N'2024-11-19T16:36:04.627' AS DateTime))
SET IDENTITY_INSERT [dbo].[thuoc_tinh_san_pham] OFF
GO
SET IDENTITY_INSERT [dbo].[thuong_hieu] ON 

INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (1, N'Zara', N'Thương hiệu thời trang nổi tiếng với các mẫu thiết kế hiện đại và phong cách.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (2, N'H&M', N'Thương hiệu thời trang bình dân, cung cấp quần áo phong cách cho mọi lứa tuổi.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (3, N'Uniqlo', N'Thương hiệu thời trang Nhật Bản, nổi bật với các sản phẩm cơ bản chất lượng cao.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (4, N'Mango', N'Thương hiệu thời trang Tây Ban Nha với thiết kế thanh lịch và nữ tính.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (5, N'Pull&Bear', N'Thương hiệu thời trang dành cho giới trẻ, kết hợp giữa sự thoải mái và phong cách.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (6, N'Forever 21', N'Thương hiệu thời trang trẻ trung, cung cấp quần áo trendy và giá cả phải chăng.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (7, N'Bershka', N'Thương hiệu thời trang hiện đại dành cho giới trẻ, với nhiều lựa chọn thời trang đa dạng.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (8, N'Gap', N'Thương hiệu thời trang nổi tiếng với các sản phẩm quần áo hàng ngày và giản dị.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (9, N'Nike', N'Thương hiệu thể thao nổi tiếng, cũng cung cấp các dòng sản phẩm thời trang.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
INSERT [dbo].[thuong_hieu] ([ma_thuong_hieu], [ten_thuong_hieu], [mo_ta], [created_at], [updated_at]) VALUES (10, N'Adidas', N'Thương hiệu thể thao hàng đầu, nổi bật với các sản phẩm quần áo và giày dép thời trang.', CAST(N'2024-11-19T16:35:49.890' AS DateTime), CAST(N'2024-11-19T16:35:49.890' AS DateTime))
SET IDENTITY_INSERT [dbo].[thuong_hieu] OFF
GO
/****** Object:  Index [UQ__khach_ha__1576C0F2A8147B04]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[khach_hang] ADD UNIQUE NONCLUSTERED 
(
	[dien_thoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__khuyen_m__357D4CF97E7A14EC]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[khuyen_mai] ADD UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__khuyen_m__357D4CF993D5E5EC]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[khuyen_mai] ADD UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__kich_thu__06BE2795D4DEF2A5]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[kich_thuoc] ADD UNIQUE NONCLUSTERED 
(
	[ten_kich_thuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__kich_thu__06BE2795DA203D23]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[kich_thuoc] ADD UNIQUE NONCLUSTERED 
(
	[ten_kich_thuoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__loai_san__5FFB310C0DD9EF59]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[loai_san_pham] ADD UNIQUE NONCLUSTERED 
(
	[ten_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__loai_san__5FFB310C1F3CF8B3]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[loai_san_pham] ADD UNIQUE NONCLUSTERED 
(
	[ten_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__man_hinh__6DC35B1B24AD74EE]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[man_hinh] ADD UNIQUE NONCLUSTERED 
(
	[ten_man_hinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__man_hinh__6DC35B1B2930A393]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[man_hinh] ADD UNIQUE NONCLUSTERED 
(
	[ten_man_hinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__mau_sac__25764485575028D2]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[mau_sac] ADD UNIQUE NONCLUSTERED 
(
	[ten_mau_sac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__mau_sac__25764485FF31D031]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[mau_sac] ADD UNIQUE NONCLUSTERED 
(
	[ten_mau_sac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nha_cung__8247486E1BE84E67]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nha_cung_cap] ADD UNIQUE NONCLUSTERED 
(
	[ten_nha_cung_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nha_cung__8247486E3DD98D20]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nha_cung_cap] ADD UNIQUE NONCLUSTERED 
(
	[ten_nha_cung_cap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__nhan_vie__1284327D151A3558]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhan_vien] ADD UNIQUE NONCLUSTERED 
(
	[tai_khoan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__nhan_vie__1284327D15A2E3A9]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhan_vien] ADD UNIQUE NONCLUSTERED 
(
	[tai_khoan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhan_vie__DDDFB4836247D3F2]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhan_vien] ADD UNIQUE NONCLUSTERED 
(
	[sdt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhan_vie__DDDFB483E529326F]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhan_vien] ADD UNIQUE NONCLUSTERED 
(
	[sdt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhom_loa__1F5A299726B0DDED]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhom_loai] ADD UNIQUE NONCLUSTERED 
(
	[ten_nhom_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhom_loa__1F5A2997327D09F5]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhom_loai] ADD UNIQUE NONCLUSTERED 
(
	[ten_nhom_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhom_quy__CA147C690C4101D6]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhom_quyen] ADD UNIQUE NONCLUSTERED 
(
	[ten_nhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhom_quy__CA147C693AFBD785]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[nhom_quyen] ADD UNIQUE NONCLUSTERED 
(
	[ten_nhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__phuong_t__76259E863C55A5A4]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[phuong_thuc_thanh_toan] ADD UNIQUE NONCLUSTERED 
(
	[ten_phuong_thuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__phuong_t__76259E865BCF3A2E]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[phuong_thuc_thanh_toan] ADD UNIQUE NONCLUSTERED 
(
	[ten_phuong_thuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__san_pham__BA66C0311A252E36]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[san_pham] ADD UNIQUE NONCLUSTERED 
(
	[ten_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__san_pham__BA66C031904AF2B3]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[san_pham] ADD UNIQUE NONCLUSTERED 
(
	[ten_san_pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tai_khoa__363698B3A24CD5C4]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[tai_khoan] ADD UNIQUE NONCLUSTERED 
(
	[ten_dang_nhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tai_khoa__363698B3D211B5BC]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[tai_khoan] ADD UNIQUE NONCLUSTERED 
(
	[ten_dang_nhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__thuong_h__2A54B3504B052CBA]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[thuong_hieu] ADD UNIQUE NONCLUSTERED 
(
	[ten_thuong_hieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__thuong_h__2A54B350FA367DB8]    Script Date: 22/11/2024 3:28:57 SA ******/
ALTER TABLE [dbo].[thuong_hieu] ADD UNIQUE NONCLUSTERED 
(
	[ten_thuong_hieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ADD  DEFAULT ((0)) FOR [giagiam]
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ADD  DEFAULT (getdate()) FOR [updated_at]
Go
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[hinh_anh_san_pham] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[hinh_anh_san_pham] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT (getdate()) FOR [ngay_lap]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT ((0)) FOR [tien_giam]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT ((0)) FOR [doi_diem]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT ((0)) FOR [hinh_thuc_ban]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT ((0)) FOR [trang_thai_doi_tra]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[hoa_don] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT ((0)) FOR [tien_doi_diem]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT ((0)) FOR [tien_hang_tra]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT ((0)) FOR [tien_mua_them]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT ((0)) FOR [tien_hoan]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT ((0)) FOR [tien_khach_tra]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT (NULL) FOR [tong_tien_sau_khi_doi]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[khach_hang] ADD  DEFAULT ((0)) FOR [diem_thuong]
GO
ALTER TABLE [dbo].[khach_hang] ADD  DEFAULT ((0)) FOR [diem_da_doi]
GO
ALTER TABLE [dbo].[khach_hang] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[khach_hang] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[khuyen_mai] ADD  DEFAULT ((0)) FOR [so_luong_da_dung]
GO
ALTER TABLE [dbo].[khuyen_mai] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[khuyen_mai] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[kich_thuoc] ADD  DEFAULT ((0)) FOR [phu_phi_size]
GO
ALTER TABLE [dbo].[kich_thuoc] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[kich_thuoc] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[loai_san_pham] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[loai_san_pham] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[man_hinh] ADD  DEFAULT (getdate()) FOR [create_at]
GO
ALTER TABLE [dbo].[man_hinh] ADD  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[mau_sac] ADD  DEFAULT ((0)) FOR [phu_phi_mausac]
GO
ALTER TABLE [dbo].[mau_sac] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[mau_sac] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[nha_cung_cap] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[nha_cung_cap] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[nha_cung_cap_san_pham] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[nha_cung_cap_san_pham] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[nhan_vien] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[nhan_vien] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[nhap_hang] ADD  DEFAULT (getdate()) FOR [ngay_nhap]
GO
ALTER TABLE [dbo].[nhap_hang] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[nhap_hang] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[nhom_loai] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[nhom_loai] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[nhom_quyen] ADD  DEFAULT (getdate()) FOR [create_at]
GO
ALTER TABLE [dbo].[nhom_quyen] ADD  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[phan_quyen] ADD  DEFAULT (getdate()) FOR [create_at]
GO
ALTER TABLE [dbo].[phan_quyen] ADD  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[phuong_thuc_thanh_toan] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[phuong_thuc_thanh_toan] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[san_pham] ADD  DEFAULT ((0)) FOR [giam_gia]
GO
ALTER TABLE [dbo].[san_pham] ADD  DEFAULT ((0)) FOR [hinh_thuc_ban]
GO
ALTER TABLE [dbo].[san_pham] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[san_pham] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tai_khoan] ADD  DEFAULT ((0)) FOR [is_oauth]
GO
ALTER TABLE [dbo].[tai_khoan] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[tai_khoan] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[tai_khoan_nhom_quyen] ADD  DEFAULT (getdate()) FOR [create_at]
GO
ALTER TABLE [dbo].[tai_khoan_nhom_quyen] ADD  DEFAULT (getdate()) FOR [update_at]
GO
ALTER TABLE [dbo].[thong_tin_san_pham] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[thong_tin_san_pham] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham] ADD  DEFAULT ((0)) FOR [so_luong_ton]
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[thuong_hieu] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[thuong_hieu] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoa_don] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoa_don] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_thuoc_tinh])
REFERENCES [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_thuoc_tinh])
REFERENCES [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoa_don_doi_tra] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoa_don_doi_tra] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_thuoc_tinh])
REFERENCES [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_thuoc_tinh])
REFERENCES [dbo].[thuoc_tinh_san_pham] ([ma_thuoc_tinh])
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang]  WITH CHECK ADD FOREIGN KEY([ma_nhap_hang])
REFERENCES [dbo].[nhap_hang] ([ma_nhap_hang])
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang]  WITH CHECK ADD FOREIGN KEY([ma_nhap_hang])
REFERENCES [dbo].[nhap_hang] ([ma_nhap_hang])
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[hinh_anh_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[hinh_anh_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[hinh_anh_san_pham]  WITH CHECK ADD  CONSTRAINT [FK_hinh_anh_san_pham_ma_san_pham] FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[hinh_anh_san_pham] CHECK CONSTRAINT [FK_hinh_anh_san_pham_ma_san_pham]
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_khach_hang])
REFERENCES [dbo].[khach_hang] ([ma_khach_hang])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_khach_hang])
REFERENCES [dbo].[khach_hang] ([ma_khach_hang])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_khuyen_mai])
REFERENCES [dbo].[khuyen_mai] ([ma_khuyen_mai])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_khuyen_mai])
REFERENCES [dbo].[khuyen_mai] ([ma_khuyen_mai])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_phuong_thuc])
REFERENCES [dbo].[phuong_thuc_thanh_toan] ([ma_phuong_thuc])
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD FOREIGN KEY([ma_phuong_thuc])
REFERENCES [dbo].[phuong_thuc_thanh_toan] ([ma_phuong_thuc])
GO
ALTER TABLE [dbo].[hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoa_don] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_hoa_don])
REFERENCES [dbo].[hoa_don] ([ma_hoa_don])
GO
ALTER TABLE [dbo].[hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_phuong_thuc])
REFERENCES [dbo].[phuong_thuc_thanh_toan] ([ma_phuong_thuc])
GO
ALTER TABLE [dbo].[hoa_don_doi_tra]  WITH CHECK ADD FOREIGN KEY([ma_phuong_thuc])
REFERENCES [dbo].[phuong_thuc_thanh_toan] ([ma_phuong_thuc])
GO
ALTER TABLE [dbo].[khach_hang]  WITH CHECK ADD FOREIGN KEY([tai_khoan_id])
REFERENCES [dbo].[tai_khoan] ([tai_khoan_id])
GO
ALTER TABLE [dbo].[khach_hang]  WITH CHECK ADD FOREIGN KEY([tai_khoan_id])
REFERENCES [dbo].[tai_khoan] ([tai_khoan_id])
GO
ALTER TABLE [dbo].[khuyen_mai]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[khuyen_mai]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[loai_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_nhom_loai])
REFERENCES [dbo].[nhom_loai] ([ma_nhom_loai])
GO
ALTER TABLE [dbo].[nha_cung_cap_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_nha_cung_cap])
REFERENCES [dbo].[nha_cung_cap] ([ma_nha_cung_cap])
GO
ALTER TABLE [dbo].[nha_cung_cap_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[nhan_vien]  WITH CHECK ADD FOREIGN KEY([tai_khoan_id])
REFERENCES [dbo].[tai_khoan] ([tai_khoan_id])
GO
ALTER TABLE [dbo].[nhap_hang]  WITH CHECK ADD FOREIGN KEY([ma_nha_cung_cap])
REFERENCES [dbo].[nha_cung_cap] ([ma_nha_cung_cap])
GO
ALTER TABLE [dbo].[nhap_hang]  WITH CHECK ADD FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[phan_quyen]  WITH CHECK ADD FOREIGN KEY([id_man_hinh])
REFERENCES [dbo].[man_hinh] ([id_man_hinh])
GO
ALTER TABLE [dbo].[phan_quyen]  WITH CHECK ADD FOREIGN KEY([id_nhom_quyen])
REFERENCES [dbo].[nhom_quyen] ([id_nhom_quyen])
GO
ALTER TABLE [dbo].[san_pham]  WITH CHECK ADD FOREIGN KEY([ma_loai])
REFERENCES [dbo].[loai_san_pham] ([ma_loai])
GO
ALTER TABLE [dbo].[san_pham]  WITH CHECK ADD FOREIGN KEY([ma_thuong_hieu])
REFERENCES [dbo].[thuong_hieu] ([ma_thuong_hieu])
GO
ALTER TABLE [dbo].[tai_khoan_nhom_quyen]  WITH CHECK ADD FOREIGN KEY([id_nhom_quyen])
REFERENCES [dbo].[nhom_quyen] ([id_nhom_quyen])
GO
ALTER TABLE [dbo].[tai_khoan_nhom_quyen]  WITH CHECK ADD FOREIGN KEY([tai_khoan_id])
REFERENCES [dbo].[tai_khoan] ([tai_khoan_id])
GO
ALTER TABLE [dbo].[thong_tin_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_kich_thuoc])
REFERENCES [dbo].[kich_thuoc] ([ma_kich_thuoc])
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_mau_sac])
REFERENCES [dbo].[mau_sac] ([ma_mau_sac])
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham]  WITH CHECK ADD FOREIGN KEY([ma_san_pham])
REFERENCES [dbo].[san_pham] ([ma_san_pham])
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don]  WITH CHECK ADD CHECK  (([so_luong]>=(0)))
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don]  WITH CHECK ADD CHECK  (([gia]>=(0)))
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang]  WITH CHECK ADD CHECK  (([gia_nhap]>=(0)))
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang]  WITH CHECK ADD CHECK  (([so_luong]>=(0)))
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD CHECK  (([hinh_thuc_ban]=(1) OR [hinh_thuc_ban]=(0)))
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD CHECK  (([tien_giam]>=(0)))
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD CHECK  (([tong_don_hang]>=(0)))
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD CHECK  (([tong_gia_tri]>=(0)))
GO
ALTER TABLE [dbo].[hoa_don]  WITH CHECK ADD CHECK  (([trang_thai_doi_tra]=(2) OR [trang_thai_doi_tra]=(1) OR [trang_thai_doi_tra]=(0)))
GO
ALTER TABLE [dbo].[khach_hang]  WITH CHECK ADD CHECK  (([diem_thuong]>=(0)))
GO
ALTER TABLE [dbo].[khach_hang]  WITH CHECK ADD CHECK  ((len([dien_thoai])>(0)))
GO
ALTER TABLE [dbo].[khach_hang]  WITH CHECK ADD CHECK  ((len([ten_khach_hang])>(0)))
GO
ALTER TABLE [dbo].[khach_hang]  WITH CHECK ADD CHECK  ((len([ten_khach_hang])>(0)))
GO
ALTER TABLE [dbo].[khuyen_mai]  WITH CHECK ADD CHECK  (([gia_tri]>=(0) AND [gia_tri]<=(100000)))
GO
ALTER TABLE [dbo].[khuyen_mai]  WITH CHECK ADD CHECK  (([gia_tri_hoa_don_toi_thieu]>=(0)))
GO
ALTER TABLE [dbo].[khuyen_mai]  WITH CHECK ADD CHECK  (([so_luong_da_dung]<=[so_luong_toi_da]))
GO
ALTER TABLE [dbo].[loai_san_pham]  WITH CHECK ADD CHECK  ((len([ten_loai])>(0)))
GO
ALTER TABLE [dbo].[nha_cung_cap]  WITH CHECK ADD  CONSTRAINT [chk_dien_thoai] CHECK  (([dien_thoai] like '[0-9]%'))
GO
ALTER TABLE [dbo].[nha_cung_cap] CHECK CONSTRAINT [chk_dien_thoai]
GO
ALTER TABLE [dbo].[nhan_vien]  WITH CHECK ADD CHECK  ((len([sdt])>(0)))
GO
ALTER TABLE [dbo].[nhan_vien]  WITH CHECK ADD CHECK  ((len([ten_nhan_vien])>(0)))
GO
ALTER TABLE [dbo].[nhap_hang]  WITH CHECK ADD CHECK  (([tong_so_luong]>=(0)))
GO
ALTER TABLE [dbo].[nhap_hang]  WITH CHECK ADD CHECK  (([tong_gia_tien]>=(0)))
GO
ALTER TABLE [dbo].[nhom_loai]  WITH CHECK ADD CHECK  ((len([ten_nhom_loai])>(0)))
GO
ALTER TABLE [dbo].[nhom_quyen]  WITH CHECK ADD CHECK  ((len([ten_nhom])>(0)))
GO
ALTER TABLE [dbo].[san_pham]  WITH CHECK ADD CHECK  (([hinh_thuc_ban]=(2) OR [hinh_thuc_ban]=(1) OR [hinh_thuc_ban]=(0)))
GO
ALTER TABLE [dbo].[tai_khoan]  WITH CHECK ADD CHECK  (([is_oauth]=(1) OR len([mat_khau_hash])>(0)))
GO
ALTER TABLE [dbo].[tai_khoan]  WITH CHECK ADD CHECK  ((len([ten_dang_nhap])>(0)))
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham]  WITH CHECK ADD CHECK  (([gia_ban]>=(0)))
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham]  WITH CHECK ADD CHECK  (([so_luong_ton]>=(0)))
GO
ALTER TABLE [dbo].[thuong_hieu]  WITH CHECK ADD CHECK  ((len([ten_thuong_hieu])>(0)))
GO
/****** Object:  Trigger [dbo].[trg_tang_diem_thuong]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_tang_diem_thuong]
ON [dbo].[chi_tiet_hoa_don]
AFTER INSERT
AS
BEGIN
    -- Kiểm tra xem đã có dữ liệu trong bảng chi_tiet_hoa_don chưa
    DECLARE @ma_hoa_don INT;
    DECLARE @ma_khach_hang INT;
	DECLARE @soluongMua INT;
	DECLARE @gia DECIMAL(10,2);

    -- Lấy ma_hoa_don từ bảng chi_tiet_hoa_don mới thêm
    SELECT @ma_hoa_don = ma_hoa_don,@soluongMua = so_luong,@gia=gia FROM inserted;

    -- Lấy ma_khach_hang từ bảng hoa_don dựa vào ma_hoa_don
    SELECT @ma_khach_hang = ma_khach_hang FROM hoa_don WHERE ma_hoa_don = @ma_hoa_don;

    -- Kiểm tra nếu ma_khach_hang không NULL, thì tăng diem_thuong lên 1
    IF @ma_khach_hang IS NOT NULL
    BEGIN
        UPDATE khach_hang
        SET diem_thuong = diem_thuong + (@gia*@soluongMua)/100
        WHERE ma_khach_hang = @ma_khach_hang;
    END
END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ENABLE TRIGGER [trg_tang_diem_thuong]
GO
/****** Object:  Trigger [dbo].[trg_UpdateGiaGiam]    Script Date: 22/11/2024 3:28:57 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Trigger cập nhật giá giảm của chi tiết hóa đơn
CREATE TRIGGER [dbo].[trg_UpdateGiaGiam]
ON [dbo].[chi_tiet_hoa_don]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật giá giảm cho các bản ghi đã được thêm hoặc cập nhật
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE cthd
        SET cthd.giagiam = cthd.gia - (cthd.gia * sp.giam_gia / 100)
        FROM chi_tiet_hoa_don cthd,
             san_pham sp,
             thuoc_tinh_san_pham tts
        WHERE cthd.ma_hoa_don IN (SELECT ma_hoa_don FROM inserted)
          AND cthd.ma_thuoc_tinh = tts.ma_thuoc_tinh
		   AND tts.ma_san_pham= sp.ma_san_pham   
    END

    -- Cập nhật giá giảm cho các bản ghi đã bị xóa
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE cthd
        SET cthd.giagiam = cthd.gia - (cthd.gia * sp.giam_gia / 100)
        FROM chi_tiet_hoa_don cthd,
             san_pham sp,
             thuoc_tinh_san_pham tts
        WHERE cthd.ma_hoa_don IN (SELECT ma_hoa_don FROM inserted)
          AND cthd.ma_thuoc_tinh = tts.ma_thuoc_tinh
		   AND tts.ma_san_pham= sp.ma_san_pham   
    END
END;

GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ENABLE TRIGGER [trg_UpdateGiaGiam]
GO
/****** Object:  Trigger [dbo].[trg_UpdateSoLuongTon]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateSoLuongTon]
ON [dbo].[chi_tiet_hoa_don]
AFTER INSERT
AS
BEGIN
    -- Cập nhật lại số lượng tồn khi thêm chi tiết hóa đơn
    DECLARE @ma_thuoc_tinh INT, @so_luong INT;

    -- Lấy ma_thuoc_tinh và so_luong từ bảng inserted
    SELECT @ma_thuoc_tinh = ma_thuoc_tinh, @so_luong = so_luong
    FROM inserted;

    -- Cập nhật số lượng tồn trong bảng thuoc_tinh_san_pham
    UPDATE tts
    SET tts.so_luong_ton = tts.so_luong_ton - @so_luong
    FROM thuoc_tinh_san_pham tts
    WHERE tts.ma_thuoc_tinh = @ma_thuoc_tinh;



	----
	UPDATE sp
	SET sp.so_luong = sp.so_luong - @so_luong
	FROM san_pham sp,thuoc_tinh_san_pham tts
    WHERE sp.ma_san_pham=tts.ma_san_pham
	AND tts.ma_thuoc_tinh = @ma_thuoc_tinh;

END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ENABLE TRIGGER [trg_UpdateSoLuongTon]
GO
/****** Object:  Trigger [dbo].[trg_UpdateTongTien]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateTongTien]
ON [dbo].[chi_tiet_hoa_don]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật tổng tiền cho hóa đơn khi có thay đổi trong chi tiết hóa đơn (INSERT, UPDATE)
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        -- Cập nhật tổng tiền cho hóa đơn sau khi có thay đổi chi tiết
        UPDATE hd
        SET hd.tong_tien = (
            SELECT SUM(ct.thanh_tien)
            FROM chi_tiet_hoa_don ct
            WHERE ct.ma_hoa_don = hd.ma_hoa_don
            GROUP BY ct.ma_hoa_don
        ), 
        -- Sử dụng ISNULL để xử lý khi tien_giam hoặc tien_doi_diem là NULL
        hd.tong_gia_tri = hd.tong_tien - (ISNULL(hd.tien_giam, 0) + ISNULL(hd.tien_doi_diem, 0))
        FROM hoa_don hd
        INNER JOIN inserted i ON hd.ma_hoa_don = i.ma_hoa_don;
    END

    -- Cập nhật tổng tiền cho hóa đơn bị xóa (DELETE)
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Cập nhật tổng tiền cho hóa đơn sau khi xóa chi tiết
        UPDATE hd
        SET hd.tong_tien = (
            SELECT SUM(ct.thanh_tien)
            FROM chi_tiet_hoa_don ct
            WHERE ct.ma_hoa_don = hd.ma_hoa_don
            GROUP BY ct.ma_hoa_don
        ), 
        -- Sử dụng ISNULL để xử lý khi tien_giam hoặc tien_doi_diem là NULL
        hd.tong_gia_tri = hd.tong_tien - (ISNULL(hd.tien_giam, 0) + ISNULL(hd.tien_doi_diem, 0))
        FROM hoa_don hd
        INNER JOIN deleted d ON hd.ma_hoa_don = d.ma_hoa_don;
    END
END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don] ENABLE TRIGGER [trg_UpdateTongTien]
GO
/****** Object:  Trigger [dbo].[trg_Tongsoluong_hoa_don_doi_tra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Tongsoluong_hoa_don_doi_tra]
ON [dbo].[chi_tiet_hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    DECLARE @ma_hoa_don INT;
    DECLARE @tong_so_luong INT;

  
    SELECT @ma_hoa_don = ma_hoa_don
    FROM inserted;

 
    SELECT @tong_so_luong = SUM(so_luong)
    FROM chi_tiet_hoa_don_doi_tra
    WHERE ma_hoa_don = @ma_hoa_don;

    UPDATE hoa_don_doi_tra
    SET tong_so_luong = @tong_so_luong
    WHERE ma_hoa_don = @ma_hoa_don;
END;

GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ENABLE TRIGGER [trg_Tongsoluong_hoa_don_doi_tra]
GO
/****** Object:  Trigger [dbo].[trg_update_hoa_don_doi_tra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_update_hoa_don_doi_tra]
ON [dbo].[chi_tiet_hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Declare variables for calculations
    DECLARE @ma_hoa_don INT;
    DECLARE @tien_hang_tra DECIMAL(18, 0);
    DECLARE @tien_mua_them DECIMAL(18, 0);
    DECLARE @tien_hoan DECIMAL(18, 0);
    DECLARE @tien_khach_tra DECIMAL(18, 0);

    -- Retrieve ma_hoa_don from the inserted row
    SELECT @ma_hoa_don = ma_hoa_don
    FROM inserted;

    -- Calculate tien_hang_tra (sum of "trả hàng" items)
    SELECT @tien_hang_tra = COALESCE(SUM(thanh_tien), 0)
    FROM chi_tiet_hoa_don_doi_tra
    WHERE ma_hoa_don = @ma_hoa_don
      AND trang_thai = N'trả hàng';

    -- Calculate tien_mua_them (sum of "đổi hàng" items)
    SELECT @tien_mua_them = COALESCE(SUM(thanh_tien), 0)
    FROM chi_tiet_hoa_don_doi_tra
    WHERE ma_hoa_don = @ma_hoa_don
      AND trang_thai = N'đổi hàng';

    -- Calculate tien_hoan and tien_khach_tra
    SET @tien_hoan = @tien_hang_tra - @tien_mua_them;
    IF @tien_hoan < 0 SET @tien_hoan = 0;

    SET @tien_khach_tra = @tien_mua_them - @tien_hang_tra;
    IF @tien_khach_tra < 0 SET @tien_khach_tra = 0;

    -- Update hoa_don_doi_tra with the calculated values
    UPDATE hoa_don_doi_tra
    SET tien_hang_tra = @tien_hang_tra,
        tien_mua_them = @tien_mua_them,
        tien_hoan = @tien_hoan,
        tien_khach_tra = @tien_khach_tra
    WHERE ma_hoa_don = @ma_hoa_don;
END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ENABLE TRIGGER [trg_update_hoa_don_doi_tra]
GO
/****** Object:  Trigger [dbo].[trg_UpdateChiTietHoaDonDoiTra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateChiTietHoaDonDoiTra]
ON [dbo].[chi_tiet_hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Cập nhật trạng thái chi tiết hóa đơn là 'trả hàng' khi trạng thái của chi tiết hóa đơn là 'trả hàng'
    UPDATE cthd
    SET cthd.trang_thai = N'trả hàng'
    FROM chi_tiet_hoa_don cthd
    INNER JOIN inserted i ON cthd.ma_hoa_don = i.ma_hoa_don AND cthd.ma_thuoc_tinh = i.ma_thuoc_tinh
    WHERE i.trang_thai = N'trả hàng';
END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ENABLE TRIGGER [trg_UpdateChiTietHoaDonDoiTra]
GO
/****** Object:  Trigger [dbo].[trg_UpdateGiaGiamChiTietHoaDonDoiTra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateGiaGiamChiTietHoaDonDoiTra]
ON [dbo].[chi_tiet_hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Cập nhật giá giảm của chi tiết hóa đơn đổi trả khi trạng thái là 'trả hàng', 'bình thường' hoặc NULL
    UPDATE cthddt
    SET cthddt.giagiam = 
        (SELECT cthd.giagiam 
         FROM chi_tiet_hoa_don cthd
         WHERE cthd.ma_hoa_don = cthddt.ma_hoa_don
           AND cthd.ma_thuoc_tinh = cthddt.ma_thuoc_tinh)
    FROM chi_tiet_hoa_don_doi_tra cthddt
    WHERE EXISTS 
        (SELECT 1 
         FROM inserted i 
         WHERE i.ma_hoa_don = cthddt.ma_hoa_don
           AND i.ma_thuoc_tinh = cthddt.ma_thuoc_tinh
		    AND i.trang_thai = cthddt.trang_thai
           AND (i.trang_thai = N'trả hàng' OR i.trang_thai = N'bình thường' OR i.trang_thai IS NULL));

    -- Cập nhật giá giảm của chi tiết hóa đơn đổi trả khi trạng thái là 'đổi hàng'
   UPDATE cthddt
    SET cthddt.giagiam = cthddt.gia - (cthddt.gia * sp.giam_gia / 100)
    FROM chi_tiet_hoa_don_doi_tra cthddt
    INNER JOIN inserted i ON cthddt.ma_hoa_don = i.ma_hoa_don AND cthddt.ma_thuoc_tinh = i.ma_thuoc_tinh
	INNER JOIN thuoc_tinh_san_pham ttsp ON ttsp.ma_thuoc_tinh = i.ma_thuoc_tinh 
	 INNER JOIN san_pham sp ON  ttsp.ma_san_pham= sp.ma_san_pham
    WHERE i.trang_thai = N'đổi hàng';
END;

GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ENABLE TRIGGER [trg_UpdateGiaGiamChiTietHoaDonDoiTra]
GO
/****** Object:  Trigger [dbo].[trg_UpdateSoLuongTonKho]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateSoLuongTonKho]
ON [dbo].[chi_tiet_hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Cập nhật số lượng tồn khi trạng thái là 'trả hàng'
    UPDATE thuoc_tinh_san_pham
    SET so_luong_ton = so_luong_ton + (
        SELECT so_luong 
        FROM inserted 
        WHERE inserted.ma_thuoc_tinh = thuoc_tinh_san_pham.ma_thuoc_tinh
    )
    WHERE EXISTS (
        SELECT 1 
        FROM inserted 
        WHERE inserted.ma_thuoc_tinh = thuoc_tinh_san_pham.ma_thuoc_tinh
        AND inserted.trang_thai = N'trả hàng' 
        AND inserted.so_luong > 0
    );

    -- Cập nhật số lượng tồn trong bảng san_pham khi trạng thái là 'trả hàng'
    UPDATE sp
    SET sp.so_luong = sp.so_luong + (
        SELECT SUM(ins.so_luong)
        FROM inserted ins
        WHERE ins.ma_thuoc_tinh IN (
            SELECT tts.ma_thuoc_tinh
            FROM thuoc_tinh_san_pham tts
            WHERE tts.ma_san_pham = sp.ma_san_pham
            AND ins.trang_thai = N'trả hàng'
        )
    )
    FROM san_pham sp
    WHERE EXISTS (
        SELECT 1
        FROM inserted ins
        INNER JOIN thuoc_tinh_san_pham tts ON ins.ma_thuoc_tinh = tts.ma_thuoc_tinh
        WHERE tts.ma_san_pham = sp.ma_san_pham
        AND ins.trang_thai = N'trả hàng'
        AND ins.so_luong > 0
    );

    -- Cập nhật số lượng tồn khi trạng thái là 'đổi hàng'
    UPDATE thuoc_tinh_san_pham
    SET so_luong_ton = so_luong_ton - (
        SELECT so_luong 
        FROM inserted 
        WHERE inserted.ma_thuoc_tinh = thuoc_tinh_san_pham.ma_thuoc_tinh
    )
    WHERE EXISTS (
        SELECT 1 
        FROM inserted 
        WHERE inserted.ma_thuoc_tinh = thuoc_tinh_san_pham.ma_thuoc_tinh
        AND inserted.trang_thai = N'đổi hàng'
        AND inserted.so_luong > 0
    );

    -- Cập nhật số lượng tồn trong bảng san_pham khi trạng thái là 'đổi hàng'
    UPDATE sp
    SET sp.so_luong = sp.so_luong - (
        SELECT SUM(ins.so_luong)
        FROM inserted ins
        WHERE ins.ma_thuoc_tinh IN (
            SELECT tts.ma_thuoc_tinh
            FROM thuoc_tinh_san_pham tts
            WHERE tts.ma_san_pham = sp.ma_san_pham
            AND ins.trang_thai = N'đổi hàng'
        )
    )
    FROM san_pham sp
    WHERE EXISTS (
        SELECT 1
        FROM inserted ins
        INNER JOIN thuoc_tinh_san_pham tts ON ins.ma_thuoc_tinh = tts.ma_thuoc_tinh
        WHERE tts.ma_san_pham = sp.ma_san_pham
        AND ins.trang_thai = N'đổi hàng'
        AND ins.so_luong > 0
    );
END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ENABLE TRIGGER [trg_UpdateSoLuongTonKho]
GO
/****** Object:  Trigger [dbo].[trg_UpdateThanhTienChiTietHoaDonDoiTra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateThanhTienChiTietHoaDonDoiTra]
ON [dbo].[chi_tiet_hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Cập nhật thành tiền khi thêm mới chi tiết hóa đơn đổi trả
    UPDATE cthddt
    SET cthddt.thanh_tien = cthddt.giagiam * cthddt.so_luong
    FROM chi_tiet_hoa_don_doi_tra cthddt
    INNER JOIN inserted i ON cthddt.ma_hoa_don = i.ma_hoa_don 
	AND cthddt.ma_thuoc_tinh = i.ma_thuoc_tinh 
	AND cthddt.trang_thai = i.trang_thai;
	
END;
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_doi_tra] ENABLE TRIGGER [trg_UpdateThanhTienChiTietHoaDonDoiTra]
GO
/****** Object:  Trigger [dbo].[trg_UpdateNhapHang]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateNhapHang]
ON [QL_SHOP_FASHION].[dbo].[chi_tiet_nhap_hang]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Bảng tạm chứa các mã nhập hàng bị ảnh hưởng
    DECLARE @AffectedMaNhapHang TABLE (ma_nhap_hang INT);

    -- Lấy các mã nhập hàng bị ảnh hưởng từ INSERTED và DELETED
    INSERT INTO @AffectedMaNhapHang(ma_nhap_hang)
    SELECT DISTINCT ma_nhap_hang
    FROM (
        SELECT ma_nhap_hang FROM INSERTED
        UNION
        SELECT ma_nhap_hang FROM DELETED
    ) AS A;

    -- Cập nhật tổng số lượng và tổng giá tiền trong bảng `nhap_hang`
    UPDATE nh
    SET 
        nh.tong_so_luong = ISNULL((
            SELECT SUM(ctnh.so_luong)
            FROM [QL_SHOP_FASHION].[dbo].[chi_tiet_nhap_hang] ctnh
            WHERE ctnh.ma_nhap_hang = nh.ma_nhap_hang
        ), 0),
        nh.tong_gia_tien = ISNULL((
            SELECT SUM(ctnh.so_luong * ctnh.gia_nhap)
            FROM [QL_SHOP_FASHION].[dbo].[chi_tiet_nhap_hang] ctnh
            WHERE ctnh.ma_nhap_hang = nh.ma_nhap_hang
        ), 0)
    FROM [QL_SHOP_FASHION].[dbo].[nhap_hang] nh
    WHERE nh.ma_nhap_hang IN (SELECT ma_nhap_hang FROM @AffectedMaNhapHang);
END;
GO
ALTER TABLE [dbo].[chi_tiet_nhap_hang] ENABLE TRIGGER [trg_UpdateNhapHang]
GO
/****** Object:  Trigger [dbo].[trg_check_doi_diem]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_check_doi_diem]
ON [dbo].[hoa_don]
AFTER INSERT
AS
BEGIN
    -- Kiểm tra nếu có hóa đơn mới với doi_diem = 1
    IF EXISTS (SELECT 1 FROM inserted WHERE doi_diem = 1)
    BEGIN
        -- Cập nhật tiền đổi điểm và tổng giá trị trong bảng hoa_don
        UPDATE hoa_don
        SET hoa_don.tien_doi_diem = kh.diem_thuong      
        FROM hoa_don hd
        JOIN khach_hang kh ON hd.ma_khach_hang = kh.ma_khach_hang
        JOIN inserted i ON hd.ma_hoa_don = i.ma_hoa_don
        WHERE i.doi_diem = 1;
        
        -- Cập nhật điểm của khách hàng về 0 và lưu điểm đã đổi vào diem_da_doi trong bảng khach_hang
        UPDATE khach_hang
        SET diem_da_doi = diem_thuong,  -- Lưu điểm đã đổi
            diem_thuong = 0             -- Đặt điểm hiện tại của khách hàng về 0
        FROM khach_hang kh
        JOIN inserted i ON kh.ma_khach_hang = i.ma_khach_hang
        WHERE i.doi_diem = 1;
    END
END;
GO
ALTER TABLE [dbo].[hoa_don] ENABLE TRIGGER [trg_check_doi_diem]
GO
/****** Object:  Trigger [dbo].[trg_Check_KhuyenMai_Expiration]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Check_KhuyenMai_Expiration]
ON [dbo].[hoa_don]
AFTER INSERT
AS
BEGIN
    -- Khai báo biến để lưu trữ mã khuyến mãi và thời gian kết thúc
    DECLARE @ma_khuyen_mai INT;
    DECLARE @thoi_gian_ket_thuc DATETIME;

    -- Lấy ma_khuyen_mai từ bảng inserted
    SELECT @ma_khuyen_mai = ma_khuyen_mai
    FROM inserted;

    -- Nếu mã khuyến mãi có giá trị
    IF @ma_khuyen_mai IS NOT NULL
    BEGIN
        -- Lấy thời gian kết thúc của mã khuyến mãi
        SELECT @thoi_gian_ket_thuc = thoi_gian_ket_thuc
        FROM khuyen_mai
        WHERE ma_khuyen_mai = @ma_khuyen_mai;

        -- Kiểm tra nếu thời gian kết thúc nhỏ hơn ngày hiện tại
        IF @thoi_gian_ket_thuc < GETDATE()
        BEGIN
            -- Đưa ra thông báo lỗi và hủy giao dịch
            RAISERROR ('Mã khuyến mãi đã hết hạn và không thể sử dụng.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
GO
ALTER TABLE [dbo].[hoa_don] ENABLE TRIGGER [trg_Check_KhuyenMai_Expiration]
GO
/****** Object:  Trigger [dbo].[trg_CheckDoiDiem]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_CheckDoiDiem]
ON [dbo].[hoa_don]
AFTER INSERT
AS
BEGIN
    -- Kiểm tra điều kiện điểm thưởng < 50 và doi_diem = 1
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN khach_hang kh ON i.ma_khach_hang = kh.ma_khach_hang
        WHERE i.doi_diem = 1
          AND i.tien_doi_diem < 50
		  AND i.hinh_thuc_ban =0
    )
    BEGIN
        -- Thông báo lỗi và hủy giao dịch
        RAISERROR('Không thể thêm hóa đơn vì điểm thưởng của khách hàng nhỏ hơn 50 (không áp dụng đổi điểm).', 16, 5);
        ROLLBACK TRANSACTION;
    END
END;
GO
ALTER TABLE [dbo].[hoa_don] ENABLE TRIGGER [trg_CheckDoiDiem]
GO
/****** Object:  Trigger [dbo].[trg_UpdateSoLuongDaDung]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateSoLuongDaDung]
ON [dbo].[hoa_don]
AFTER INSERT
AS
BEGIN
    -- Khai báo biến để lưu trữ mã khuyến mãi
    DECLARE @ma_khuyen_mai INT;

    -- Lấy ma_khuyen_mai từ bảng inserted (chứa các bản ghi mới được thêm vào hoa_don)
    SELECT @ma_khuyen_mai = ma_khuyen_mai
    FROM inserted;

    -- Kiểm tra nếu mã khuyến mãi có giá trị
    IF @ma_khuyen_mai IS NOT NULL
    BEGIN
        -- Kiểm tra nếu số lượng đã dùng không vượt quá số lượng tối đa
        IF EXISTS (
            SELECT 1
            FROM khuyen_mai
            WHERE ma_khuyen_mai = @ma_khuyen_mai
            AND so_luong_da_dung < so_luong_toi_da
        )
        BEGIN
            -- Cập nhật so_luong_da_dung của khuyến mãi
            UPDATE khuyen_mai
            SET so_luong_da_dung = so_luong_da_dung + 1
            WHERE ma_khuyen_mai = @ma_khuyen_mai;
        END
        ELSE
        BEGIN
            -- Nếu số lượng đã dùng đã đạt tối đa, đưa ra thông báo lỗi và hủy giao dịch
            RAISERROR ('Mã khuyến mãi đã đạt số lượng tối đa và không thể sử dụng thêm.', 16, 123);
            ROLLBACK TRANSACTION;
        END
    END
END;
GO
ALTER TABLE [dbo].[hoa_don] ENABLE TRIGGER [trg_UpdateSoLuongDaDung]
GO
/****** Object:  Trigger [dbo].[trg_UpdateTienGiam_HoaDon]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateTienGiam_HoaDon]
ON [dbo].[hoa_don]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật tien_giam cho các bản ghi đã được thêm hoặc cập nhật
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE hd
        SET hd.tien_giam = 
            CASE 
                WHEN km.gia_tri IS NOT NULL 
                THEN hd.tong_tien * km.gia_tri / 100
                ELSE 0
            END
        FROM hoa_don hd
        LEFT JOIN inserted i ON hd.ma_hoa_don = i.ma_hoa_don
        LEFT JOIN khuyen_mai km ON hd.ma_khuyen_mai = km.ma_khuyen_mai
        WHERE i.ma_hoa_don IS NOT NULL;  -- Chỉ cập nhật cho các hóa đơn mới hoặc được sửa
    END


END;
GO
ALTER TABLE [dbo].[hoa_don] ENABLE TRIGGER [trg_UpdateTienGiam_HoaDon]
GO
/****** Object:  Trigger [dbo].[trg_after_insert_or_update_hoa_don_doi_tra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_after_insert_or_update_hoa_don_doi_tra]
ON [dbo].[hoa_don_doi_tra]
AFTER INSERT, UPDATE
AS
BEGIN
    -- Declare variables for tien_hoan calculation
    DECLARE @ma_hoa_don INT;
    DECLARE @tien_hang_tra DECIMAL(18, 0);
    DECLARE @tien_mua_them DECIMAL(18, 0);
    DECLARE @tien_hoan DECIMAL(18, 0);

    -- Retrieve the values from the inserted/updated row
    SELECT 
        @ma_hoa_don = ma_hoa_don,
        @tien_hang_tra = tien_hang_tra,
        @tien_mua_them = tien_mua_them
    FROM inserted;

    -- Calculate tien_hoan
    SET @tien_hoan = @tien_hang_tra - @tien_mua_them;

    -- Ensure tien_hoan is not negative
    IF @tien_hoan < 0
    BEGIN
        SET @tien_hoan = 0;
    END

    -- Update the tien_hoan in the hoa_don_doi_tra table
    UPDATE hoa_don_doi_tra
    SET tien_hoan = @tien_hoan
    WHERE ma_hoa_don = @ma_hoa_don;
END;
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ENABLE TRIGGER [trg_after_insert_or_update_hoa_don_doi_tra]
GO
/****** Object:  Trigger [dbo].[trg_CheckDieuKienDoiTra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Trigger kiểm tra điều kiện đởi trả
CREATE TRIGGER [dbo].[trg_CheckDieuKienDoiTra]
ON [dbo].[hoa_don_doi_tra]
INSTEAD OF INSERT
AS
BEGIN
    -- Kiểm tra nếu bất kỳ hóa đơn nào trong inserted có ngày lập quá 7 ngày
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE DATEDIFF(DAY, hd.ngay_lap, GETDATE()) > 7
    )
    BEGIN
        RAISERROR ('Không thể thêm hóa đơn đổi trả vì hóa đơn đã quá 7 ngày!!', 16, 199);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra nếu mã khuyến mãi khác NULL trong các bản ghi mới
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE hd.ma_khuyen_mai IS NOT NULL
    )
    BEGIN
        RAISERROR('Hóa đơn không đủ điều kiện đổi trả vì đã áp dụng khuyến mãi!', 16, 29);
        ROLLBACK TRANSACTION;
        RETURN;
    END
	-- Kiểm tra nếu trạng thái đổi trả của hóa đơn là 1 (đã đổi trả)
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE hd.trang_thai_doi_tra = 1
    )
    BEGIN
        RAISERROR('Hóa đơn này đã được đổi trả, không thể thực hiện thêm lần nữa!', 16, 18);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Nếu không vi phạm điều kiện, thực hiện INSERT như bình thường
    INSERT INTO hoa_don_doi_tra (ma_hoa_don, ma_nhan_vien, ma_phuong_thuc, tong_so_luong, ngay_doi_tra, tien_doi_diem,  created_at, updated_at)
    SELECT ma_hoa_don, ma_nhan_vien, ma_phuong_thuc, tong_so_luong, ngay_doi_tra, tien_doi_diem,  created_at, updated_at
    FROM inserted;
END;
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ENABLE TRIGGER [trg_CheckDieuKienDoiTra]
GO
/****** Object:  Trigger [dbo].[trg_tiendoitra_hoadondoitra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_tiendoitra_hoadondoitra]
ON [dbo].[hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Declare a variable to store the tien_doi_diem value
    DECLARE @ma_hoa_don INT;
    DECLARE @tien_doi_diem DECIMAL(18, 0);

    -- Retrieve the ma_hoa_don from the inserted row
    SELECT @ma_hoa_don = ma_hoa_don
    FROM inserted;

    -- Retrieve the tien_doi_diem from the hoa_don table
    SELECT @tien_doi_diem = tien_doi_diem
    FROM hoa_don
    WHERE ma_hoa_don = @ma_hoa_don;

    -- Update the hoa_don_doi_tra table with the tien_doi_diem value
    UPDATE hoa_don_doi_tra
    SET tien_doi_diem = @tien_doi_diem
    WHERE ma_hoa_don = @ma_hoa_don;
END;



GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ENABLE TRIGGER [trg_tiendoitra_hoadondoitra]
GO
/****** Object:  Trigger [dbo].[trg_UpdateTrangThaiDoiTra]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateTrangThaiDoiTra]
ON [dbo].[hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Cập nhật cột trang_thai_doi_tra của hoa_don thành 1 khi thêm hoa_don_doi_tra thành công
    UPDATE hd
    SET hd.trang_thai_doi_tra = 1
    FROM hoa_don hd
    INNER JOIN inserted i ON hd.ma_hoa_don = i.ma_hoa_don;
END;
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ENABLE TRIGGER [trg_UpdateTrangThaiDoiTra]
GO
/****** Object:  Trigger [dbo].[trg_UpdateTrangThaiDoiTra_HoaDon]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateTrangThaiDoiTra_HoaDon]
ON [dbo].[hoa_don_doi_tra]
AFTER INSERT
AS
BEGIN
    -- Cập nhật trang_thai_doi_tra của bảng hoa_don thành 1 sau khi thêm bản ghi vào hoa_don_doi_tra
    UPDATE hoa_don
    SET trang_thai_doi_tra = 1
    WHERE EXISTS (
        SELECT 1
        FROM inserted i
        WHERE i.ma_hoa_don = hoa_don.ma_hoa_don
    );
END;
GO
ALTER TABLE [dbo].[hoa_don_doi_tra] ENABLE TRIGGER [trg_UpdateTrangThaiDoiTra_HoaDon]
GO
/****** Object:  Trigger [dbo].[tr_Update_TinhTrang_Khuyen_Mai]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_Update_TinhTrang_Khuyen_Mai]
ON [dbo].[khuyen_mai]
AFTER UPDATE
AS
BEGIN
    UPDATE khuyen_mai
    SET tinh_trang = 'hết hạn'
    WHERE ma_khuyen_mai IN (SELECT ma_khuyen_mai FROM inserted)
    AND thoi_gian_ket_thuc < GETDATE();
END;
GO
ALTER TABLE [dbo].[khuyen_mai] ENABLE TRIGGER [tr_Update_TinhTrang_Khuyen_Mai]
GO
/****** Object:  Trigger [dbo].[trg_UpdateGiaBinhQuan]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateGiaBinhQuan]
ON [dbo].[nha_cung_cap_san_pham]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật gia_binh_quan cho các sản phẩm bị ảnh hưởng bởi thao tác INSERT, UPDATE, DELETE
    UPDATE san_pham
    SET gia_binh_quan = (
        SELECT MAX(gia_cung_cap)
        FROM nha_cung_cap_san_pham
        WHERE nha_cung_cap_san_pham.ma_san_pham = san_pham.ma_san_pham
    )
    WHERE san_pham.ma_san_pham IN (
        SELECT DISTINCT ma_san_pham
        FROM inserted
        UNION
        SELECT DISTINCT ma_san_pham
        FROM deleted
    );
END;
GO
ALTER TABLE [dbo].[nha_cung_cap_san_pham] ENABLE TRIGGER [trg_UpdateGiaBinhQuan]
GO
/****** Object:  Trigger [dbo].[trg_TinhGiaBan]    Script Date: 22/11/2024 3:28:58 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_TinhGiaBan]
ON [dbo].[thuoc_tinh_san_pham]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Tính giá bán
    UPDATE ttp
    SET gia_ban = sp.gia_binh_quan * (1 + kt.phu_phi_size + ms.phu_phi_mausac)
    FROM thuoc_tinh_san_pham ttp
    JOIN san_pham sp ON ttp.ma_san_pham = sp.ma_san_pham
    JOIN kich_thuoc kt ON ttp.ma_kich_thuoc = kt.ma_kich_thuoc
    JOIN mau_sac ms ON ttp.ma_mau_sac = ms.ma_mau_sac
    WHERE ttp.ma_thuoc_tinh IN (SELECT ma_thuoc_tinh FROM inserted);
END;
GO
ALTER TABLE [dbo].[thuoc_tinh_san_pham] ENABLE TRIGGER [trg_TinhGiaBan]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Trigger tự động cập nhật giá bán khi thay đổi phụ phí màu sắc hoặc kích thước ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_CapNhatGiaBan_MauSac]
ON [dbo].[mau_sac]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật giá bán cho sản phẩm có liên quan đến màu sắc được cập nhật
    UPDATE ttp
    SET gia_ban = sp.gia_binh_quan * (1 + kt.phu_phi_size + ms.phu_phi_mausac)
    FROM thuoc_tinh_san_pham ttp
    JOIN san_pham sp ON ttp.ma_san_pham = sp.ma_san_pham
    JOIN kich_thuoc kt ON ttp.ma_kich_thuoc = kt.ma_kich_thuoc
    JOIN mau_sac ms ON ttp.ma_mau_sac = ms.ma_mau_sac
    WHERE ttp.ma_mau_sac IN (SELECT ma_mau_sac FROM inserted);
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_CapNhatGiaBan_KichThuoc]
ON [dbo].[kich_thuoc]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật giá bán cho sản phẩm có liên quan đến kích thước được cập nhật
    UPDATE ttp
    SET gia_ban = sp.gia_binh_quan * (1 + kt.phu_phi_size + ms.phu_phi_mausac)
    FROM thuoc_tinh_san_pham ttp
    JOIN san_pham sp ON ttp.ma_san_pham = sp.ma_san_pham
    JOIN kich_thuoc kt ON ttp.ma_kich_thuoc = kt.ma_kich_thuoc
    JOIN mau_sac ms ON ttp.ma_mau_sac = ms.ma_mau_sac
    WHERE ttp.ma_kich_thuoc IN (SELECT ma_kich_thuoc FROM inserted);
END;
GO


-- Trigger kiểm tra điều kiện đổi trả
ALTER TRIGGER [dbo].[trg_CheckDieuKienDoiTra]
ON [dbo].[hoa_don_doi_tra]
INSTEAD OF INSERT
AS
BEGIN
    -- Kiểm tra nếu bất kỳ hóa đơn nào trong inserted có ngày lập quá 7 ngày
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE DATEDIFF(DAY, hd.ngay_lap, GETDATE()) > 7
    )
    BEGIN
        RAISERROR ('Không thể thêm hóa đơn đổi trả vì hóa đơn đã quá 7 ngày!!', 16, 199);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra nếu mã khuyến mãi khác NULL trong các bản ghi mới
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE hd.ma_khuyen_mai IS NOT NULL
    )
    BEGIN
        RAISERROR('Hóa đơn không đủ điều kiện đổi trả vì đã áp dụng khuyến mãi!', 16, 29);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra nếu trạng thái đổi trả của hóa đơn là 1 (đã đổi trả)
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE hd.trang_thai_doi_tra = 1
    )
    BEGIN
        RAISERROR('Hóa đơn này đã được đổi trả, không thể thực hiện thêm lần nữa!', 16, 18);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Kiểm tra nếu hình thức thanh toán của hóa đơn khác 1
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN hoa_don hd ON i.ma_hoa_don = hd.ma_hoa_don
        WHERE hd.ma_phuong_thuc <> 1
    )
    BEGIN
        RAISERROR('Hóa đơn không được đổi trả vì hình thức thanh toán không hợp lệ!', 16, 20);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Nếu không vi phạm điều kiện, thực hiện INSERT như bình thường
    INSERT INTO hoa_don_doi_tra (ma_hoa_don, ma_nhan_vien, ma_phuong_thuc, tong_so_luong, ngay_doi_tra, tien_doi_diem, created_at, updated_at)
    SELECT ma_hoa_don, ma_nhan_vien, ma_phuong_thuc, tong_so_luong, ngay_doi_tra, tien_doi_diem, created_at, updated_at
    FROM inserted;
END;
GO
/****** Object:  Trigger [dbo].[trg_UpdateNhapHang]    Script Date: 11/30/2024 1:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trg_UpdateNhapHang]
ON [QL_SHOP_FASHION].[dbo].[chi_tiet_nhap_hang]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Bảng tạm chứa các mã nhập hàng bị ảnh hưởng
    DECLARE @AffectedMaNhapHang TABLE (ma_nhap_hang INT);

    -- Lấy các mã nhập hàng bị ảnh hưởng từ INSERTED và DELETED
    INSERT INTO @AffectedMaNhapHang(ma_nhap_hang)
    SELECT DISTINCT ma_nhap_hang
    FROM (
        SELECT ma_nhap_hang FROM INSERTED
        UNION
        SELECT ma_nhap_hang FROM DELETED
    ) AS A;

    -- Cập nhật tổng số lượng và tổng giá tiền trong bảng `nhap_hang`
    UPDATE nh
    SET 
        nh.tong_so_luong = ISNULL((
            SELECT SUM(ctnh.so_luong)
            FROM [QL_SHOP_FASHION].[dbo].[chi_tiet_nhap_hang] ctnh
            WHERE ctnh.ma_nhap_hang = nh.ma_nhap_hang
        ), 0),
        nh.tong_gia_tien = ISNULL((
            SELECT SUM(ctnh.gia_nhap)
            FROM [QL_SHOP_FASHION].[dbo].[chi_tiet_nhap_hang] ctnh
            WHERE ctnh.ma_nhap_hang = nh.ma_nhap_hang
        ), 0)
    FROM [QL_SHOP_FASHION].[dbo].[nhap_hang] nh
    WHERE nh.ma_nhap_hang IN (SELECT ma_nhap_hang FROM @AffectedMaNhapHang);
END;
GO
USE [master]
GO
ALTER DATABASE [QL_SHOP_FASHION] SET  READ_WRITE 
GO
