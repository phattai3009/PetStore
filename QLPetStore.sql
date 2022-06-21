CREATE DATABASE QL_PetStore
GO
USE QL_PetStore
GO
ALTER DATABASE QL_PetStore SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE QL_PetStore SET ANSI_NULLS OFF 
GO
ALTER DATABASE QL_PetStore SET ANSI_PADDING OFF 
GO
ALTER DATABASE QL_PetStore SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE QL_PetStore SET ARITHABORT OFF 
GO
ALTER DATABASE QL_PetStore SET AUTO_CLOSE OFF 
GO
ALTER DATABASE QL_PetStore SET AUTO_SHRINK OFF 
GO
ALTER DATABASE QL_PetStore SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE QL_PetStore SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE QL_PetStore SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE QL_PetStore SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE QL_PetStore SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE QL_PetStore SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE QL_PetStore SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE QL_PetStore SET  ENABLE_BROKER 
GO
ALTER DATABASE QL_PetStore SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE QL_PetStore SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE QL_PetStore SET TRUSTWORTHY OFF 
GO
ALTER DATABASE QL_PetStore SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE QL_PetStore SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE QL_PetStore SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE QL_PetStore SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE QL_PetStore SET RECOVERY FULL 
GO
ALTER DATABASE QL_PetStore SET  MULTI_USER 
GO
ALTER DATABASE QL_PetStore SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE QL_PetStore SET DB_CHAINING OFF 
GO
ALTER DATABASE QL_PetStore SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE QL_PetStore SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE QL_PetStore SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QL_PetStore', N'ON'
GO
ALTER DATABASE QL_PetStore SET QUERY_STORE = OFF
GO
USE QL_PetStore
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50)NOT NULL,
	[Password] [varchar](32)NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[CMND] [varchar](50) NULL,
	[NgaySinh] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](15) NULL,
	[CreateDate] [datetime] NULL,
	[MaQuyen] [int] NOT NULL,
	[TienLuong] [decimal](18, 0) NULL,
	[TimeLogout] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giong](
	[MaLoai] [int] NOT NULL,
	[MaGiong] [int] IDENTITY(1,1) NOT NULL,
	[TenGiong] [nvarchar](50) NULL,
	[SoLuongTon] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_Giong] PRIMARY KEY CLUSTERED 
(
	[MaGiong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[Phone] [nvarchar](12) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [int] IDENTITY(1,1) NOT NULL,
	[MaDDM] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayNhap] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[TongSLNhap] [int] NULL,
	[TongTienNhap] [decimal](18, 0) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPN](
	[MaPN] [int] NOT NULL,
	[MaGiong] [int] NOT NULL,
	[MaTC] [int] NOT NULL,
	[GiaNhap] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietPN] PRIMARY KEY CLUSTERED 
(
	[MaTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatMua](
	[MaDDM] [int] IDENTITY(1,1) NOT NULL,
	[MaNCC] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[TongSLMua] [int] NULL,
	[TongTienMua] [decimal](18, 0) NULL,
 CONSTRAINT [PK_DonDatMua] PRIMARY KEY CLUSTERED 
(
	[MaDDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDDM](
	[MaDDM] [int] NOT NULL,
	[MaGiong] [int] NOT NULL,
	[GiaMua] [decimal](18, 0) NULL,
	[SoLuongMua] [int] NULL,
	[ThanhTien] [decimal](18, 0) NULL,
	[MoTa] [int] NULL,
 CONSTRAINT [PK_ChiTietDDM] PRIMARY KEY CLUSTERED 
(
	[MaDDM] ASC,
	[MaGiong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoiTra](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[MaDH] [int] NOT NULL,
	[MaNV] [int] NOT NULL,
	[NgayDoi] [datetime] NULL,
	[LyDo] [nvarchar](max) NULL,
	[TinhTrangThuCung] [nvarchar](max) NULL,
 CONSTRAINT [PK_DoiTra] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuCung](
	[MaTC] [int] IDENTITY(1,1) NOT NULL,
	[TenTC] [nvarchar](50) NULL,
	[GiaBan] [decimal](18, 0) NULL,
	[MoTa] [nvarchar](max) NULL,
	[Anh] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[NgayCapNhat] [datetime] NULL,
	[NgayBan] [datetime] NULL,
	[MaGiong] [int] NOT NULL,
	[MaLoai] [int] NOT NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_ThuCung] PRIMARY KEY CLUSTERED 
(
	[MaTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[MaKH] [int] NULL,
	[NguoiNhan] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [varchar](12) NULL,
	[Address] [nvarchar](max) NULL,
	[TongTien] [decimal](18, 0) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[MaDH] [int] NOT NULL,
	[MaTC] [int] NOT NULL,
	[ThanhTien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[MaTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50)NOT NULL,
	[TaiKhoan] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](12) NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[NgaySinh] [date] NULL,
	[CreatedDate] [datetime] NULL,	
	[TimeLogout] [datetime] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuCungReview](
	[MaReview] [int]IDENTITY(1,1) NOT NULL,
	[MaTC] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[TieuDe] [nvarchar](Max) NULL,
	[DanhGia] [int] NULL,
	[NoiDung] [nvarchar](Max) NULL,
	[CreatedDate] [datetime] NULL,
	[TrangThai] [int] NULL,
	[NgayDang] [datetime] NULL,
 CONSTRAINT [PK_ThuCungReview] PRIMARY KEY CLUSTERED 
(
	[MaReview] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng chi tiết đơn hàng
CREATE TRIGGER CapNhapThanhTien
on ChiTietDonHang
after insert, update
as
	update ChiTietDonHang
	set THANHTIEN =(select ThuCung.GiaBan from ThuCung where ChiTietDonHang.MaTC = ThuCung.MaTC )
	where MaDH = (select MaDH from inserted)
go

/*====================================================================================*/
--Cập nhập TrangThai trong bảng ThuCung
CREATE TRIGGER CapNhapTrangThai
on ChiTietDonHang
after insert
as
	update ThuCung
	set TrangThai = 1
	From ThuCung
	where ThuCung.MaTC = (select MaTC from inserted)
go

CREATE TRIGGER CapNhapTrangThai2
on ChiTietDonHang
for DELETE
as
	update ThuCung
	set TrangThai = 0
	From ThuCung
	where ThuCung.MaTC = (select MaTC from deleted)
go

/*====================================================================================*/
--Cập nhập SoLuongTon trong bảng Giong
CREATE TRIGGER CapNhapSoLuongTon
on ThuCung
after insert
as
	update Giong
	set SoLuongTon = (Giong.SoLuongTon + (select COUNT(*) from inserted where inserted.MaGiong = Giong.MaGiong))
	where Giong.MaGiong = (select MaGiong from inserted)
go

CREATE TRIGGER CapNhapSoLuongTon1
on ThuCung
for delete
as
	update Giong
	set SoLuongTon = (Giong.SoLuongTon - (select COUNT(*) from deleted where deleted.MaGiong = Giong.MaGiong))
	where Giong.MaGiong = (select MaGiong from deleted)
go

CREATE TRIGGER CapNhapSoLuongTon2
on ThuCung
after update
as
	update Giong
	set SoLuongTon = (Giong.SoLuongTon - (select COUNT(*) from deleted where deleted.MaGiong = Giong.MaGiong) + (select COUNT(*) from inserted where inserted.MaGiong = Giong.MaGiong))
	where Giong.MaGiong = (select MaGiong from deleted) AND Giong.MaGiong = (select MaGiong from inserted)
go


/*====================================================================================*/
--Cập nhập SoLuongTon trong bảng Giong
CREATE TRIGGER CapNhapSoLuongTon3
on ChiTietDonHang
after insert
as
	update Giong
	set SoLuongTon = (Giong.SoLuongTon - (select COUNT(*) from inserted ins, ThuCung TC where ins.MaTC = TC.MaTC AND TC.MaGiong = Giong.MaGiong))
	where Giong.MaGiong = (select MaGiong from inserted)
go


CREATE TRIGGER CapNhapSoLuongTon4
on ChiTietDonHang
for Delete
as
	update Giong
	set SoLuongTon = (Giong.SoLuongTon + (select COUNT(*) from deleted del, ThuCung TC where del.MaTC = TC.MaTC AND TC.MaGiong = Giong.MaGiong))
	where Giong.MaGiong = (select MaGiong from deleted)
go

/*====================================================================================*/

--Cập nhập trang thai trong bảng đơn hàng
CREATE TRIGGER CapNhapTrangThaiDonHang
on DoiTra
after insert, update
as
	update DonHang
	set TrangThai = 2
	where MaDH = (select MaDH from inserted)
go

CREATE TRIGGER CapNhapTrangThaiDonHang2
on DoiTra
for delete
as
	update DonHang
	set TrangThai = 1
	where MaDH = (select MaDH from deleted)
go


/*====================================================================================*/
--Cập nhập tổng tiền trong bảng đơn hàng
CREATE TRIGGER CapNhapTongTien5
on DonHang
after insert, update
as
	update DonHang
	set TongTien = (select sum(ThanhTien) from ChiTietDonHang where MaDH = (select MaDH from inserted))
	where MaDH = (select MaDH from inserted)
go	

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng đơn hàng
create trigger CapNhapTongTien
on ChiTietDonHang
after insert
as
	update DonHang
	set TongTien = (select sum(ThanhTien) from ChiTietDonHang where MaDH = (select MaDH from inserted))
	where MaDH = (select MaDH from inserted)
go
--Cập nhập tổng tiền trong bảng đơn hàng
CREATE TRIGGER CapNhapTongTien2
ON ChiTietDonHang 
FOR DELETE
AS
	UPDATE DonHang
	set TongTien = (select sum(ThanhTien) from ChiTietDonHang where MaDH = (select MaDH from deleted))
	where MaDH = (select MaDH from deleted)
GO
--Cập nhập tổng tiền trong bảng đơn hàng
create trigger CapNhapTongTien3
on ChiTietDonHang
after update
as
	update DonHang
	set TongTien = TongTien + (select sum(ThanhTien) from inserted where MaDH = DonHang.MaDH) 
					- (select sum(ThanhTien) from deleted where MaDH = DonHang.MaDH)
	from DonHang join deleted on DonHang.MaDH = deleted.MaDH
go

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng Phiếu nhập
create trigger CapNhapTongTienNhap
on ChiTietPN
after insert
as
	update PhieuNhap
	set TongTienNhap = (select sum(GiaNhap) from ChiTietPN where MaPN = (select MaPN from inserted))
	where MaPN = (select MaPN from inserted)
go

--Cập nhập tổng tiền trong bảng Phiếu nhập
CREATE TRIGGER CapNhapTongTienNhap2
ON ChiTietPN 
FOR DELETE
AS
	UPDATE PhieuNhap
	set TongTienNhap = (select sum(GiaNhap) from ChiTietPN where MaPN = (select MaPN from deleted))
	where MaPN = (select MaPN from deleted)
GO

--Cập nhập tổng tiền trong bảng Phiếu nhập
create trigger CapNhapTongTienNhap3
on ChiTietPN
after update
as
	update PhieuNhap
	set TongTienNhap = TongTienNhap + (select sum(GiaNhap) from inserted where MaPN = PhieuNhap.MaPN) 
					- (select sum(GiaNhap) from deleted where MaPN = PhieuNhap.MaPN)
	from PhieuNhap join deleted on PhieuNhap.MaPN = deleted.MaPN
go

/*====================================================================================*/
--Cập nhập số lượng trong bảng Phiếu nhập
create trigger CapNhapSLNhap
on ChiTietPN
after insert
as
	update PhieuNhap
	set TongSLNhap = (select Count(*) from ChiTietPN where MaPN = (select MaPN from inserted))
	where MaPN = (select MaPN from inserted)
go
--Cập nhập số lượng trong bảng Phiếu nhập
CREATE TRIGGER CapNhapSLNhap2
ON ChiTietPN 
FOR DELETE
AS
	UPDATE PhieuNhap
	set TongSLNhap = (select Count(*) from ChiTietPN where MaPN = (select MaPN from deleted))
	where MaPN = (select MaPN from deleted)
GO
--Cập nhập số lượng trong bảng Phiếu nhập
create trigger CapNhapSLNhap3
on ChiTietPN
after update
as
	update PhieuNhap
	set TongSLNhap = TongSLNhap + (select Count(*) from inserted where MaPN = PhieuNhap.MaPN) 
					- (select Count(*) from deleted where MaPN = PhieuNhap.MaPN)
	from PhieuNhap join deleted on PhieuNhap.MaPN = deleted.MaPN
go

/*====================================================================================*/
--Cập nhập thành tiền trong bảng ChiTietDDM
CREATE TRIGGER CapNhapThanhTien2
on ChiTietDDM
after insert, update
as
	update ChiTietDDM
	set ThanhTien = (select SoLuongMua*GiaMua from ChiTietDDM where MaGiong = (select MaGiong from inserted) AND MaDDM = (select MaDDM from inserted))
	where MaGiong = (select MaGiong from inserted) AND MaDDM = (select MaDDM from inserted)
go

/*====================================================================================*/
--Cập nhập tổng tiền trong bảng DonDatMua
create trigger CapNhapTongTienDDM
on ChiTietDDM
after insert
as
	update DonDatMua
	set TongTienMua = (select sum(ThanhTien) from ChiTietDDM where MaDDM = (select MaDDM from inserted))
	where MaDDM = (select MaDDM from inserted)
go

--Cập nhập tổng tiền trong bảng DonDatMua
CREATE TRIGGER CapNhapTongTienDDM2
ON ChiTietDDM 
FOR DELETE
AS
	UPDATE DonDatMua
	set TongTienMua = (select sum(ThanhTien) from ChiTietDDM where MaDDM = (select MaDDM from deleted))
	where MaDDM = (select MaDDM from deleted)
GO

--Cập nhập tổng tiền trong bảng DonDatMua
create trigger CapNhapTongTienDDM3
on ChiTietDDM
after update
as
	update DonDatMua
	set TongTienMua = TongTienMua + (select sum(ThanhTien) from inserted where MaDDM = DonDatMua.MaDDM) 
					- (select sum(ThanhTien) from deleted where MaDDM = DonDatMua.MaDDM)
	from DonDatMua join deleted on DonDatMua.MaDDM = deleted.MaDDM
go
/*====================================================================================*/
----Cập nhập Tong so luong mua trong bảng DonDatMua
create trigger CapNhapSLMua
on ChiTietDDM
after insert
as
	update DonDatMua
	set TongSLMua = (select sum(SoLuongMua) from ChiTietDDM where MaDDM = (select MaDDM from inserted))
	where MaDDM = (select MaDDM from inserted)
go

----Cập nhập Tong so luong mua trong bảng DonDatMua
CREATE TRIGGER CapNhapSLMua2
on ChiTietDDM
for delete
as
	update DonDatMua
	set TongSLMua = (select sum(SoLuongMua) from ChiTietDDM where MaDDM = (select MaDDM from deleted))
	where MaDDM = (select MaDDM from deleted)
go

----Cập nhập Tong so luong mua trong bảng DonDatMua
CREATE TRIGGER CapNhapSLMua3
on ChiTietDDM
after Update
as
	update DonDatMua
	set TongSLMua = TongSLMua + (select sum(SoLuongMua) from inserted where MaDDM = DonDatMua.MaDDM) 
					- (select sum(SoLuongMua) from deleted where MaDDM = DonDatMua.MaDDM)
	from DonDatMua join deleted on DonDatMua.MaDDM = deleted.MaDDM
go

/*====================================================================================*/
--Cập nhập tiền lương trong bảng nhân viên
CREATE TRIGGER CapNhapTienLuong
ON DonHang 
after INSERT
AS

	UPDATE NhanVien
	set TienLuong = (TienLuong + ((SELECT COUNT(inserted.MaDH) FROM inserted where inserted.MaNV = NhanVien.MaNV)*20000))
	where MaNV = (select MaNV from inserted)
GO
--Cập nhập tiền lương trong bảng nhân viên
CREATE TRIGGER CapNhapTienLuong2
ON DonHang 
FOR DELETE
AS

	UPDATE NhanVien
	set TienLuong = (TienLuong - ((SELECT COUNT(deleted.MaDH) FROM deleted where deleted.MaNV = NhanVien.MaNV)*20000))
	where MaNV = (select MaNV from deleted)
GO
--Cập nhập tiền lương trong bảng nhân viên
CREATE TRIGGER CapNhapTienLuong3
ON DonHang 
after update
AS
	UPDATE NhanVien
	set TienLuong = TienLuong + ((SELECT COUNT(inserted.MaDH) FROM inserted where inserted.MaNV = NhanVien.MaNV)*20000)
					- ((SELECT COUNT(deleted.MaDH) FROM deleted where deleted.MaNV = NhanVien.MaNV)*20000)
	from NhanVien join deleted on NhanVien.MaNV = deleted.MaNV
GO


--Đặt lại mật khẩu nhân viên
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DatLaiMatKhau]
@MaNV int
AS
BEGIN
	UPDATE dbo.NhanVien
	SET
	     --Mật khẩu là 123
	    dbo.NhanVien.Password = N'202cb962ac59075b964b07152d234b70' -- varchar
	WHERE dbo.NhanVien.MaNV = @MaNV
END
GO

/*====================================================================================*/
--Đổi mật khẩu nhân viên
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DoiMatKhau]
@MaNV int,
@matkhauTrangThai varchar(1000)
AS
BEGIN
	UPDATE dbo.NhanVien
	SET
	    dbo.NhanVien.Password = @matkhauTrangThai
	WHERE dbo.NhanVien.MaNV = @MaNV
END
GO

/*====================================================================================*/
--Cập nhập số lượng giống
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_CapNhatGiongSoLuongTon]
@maGiong int
AS
BEGIN
	UPDATE dbo.Giong
	SET
	    SoLuongTon =  (select COUNT(*) from ThuCung where ThuCung.MaGiong = @maGiong AND ThuCung.TrangThai = 0)
	WHERE dbo.Giong.MaGiong = @maGiong
END
GO

/*====================================================================================*/
--Lấy thông tin gắn vào panelHome
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayThongTinTong]
@manv int,
@thang int,
@nam int
AS
BEGIN
	DECLARE @thucung int = 0
	DECLARE @donhang int = 0
	DECLARE @khachhang int = 0
	DECLARE @doanhthu float = 0
	DECLARE @quyen int
	
	SELECT @quyen = dbo.NhanVien.MaQuyen FROM dbo.NhanVien WHERE dbo.NhanVien.MaNV = @manv

	SELECT @thucung = count(dbo.ThuCung.MaTC) FROM dbo.ThuCung

	IF (@quyen=1) 
	BEGIN 
		SELECT @donhang = count(dbo.DonHang.MaDH) FROM dbo.DonHang WHERE month(dbo.DonHang.CreatedDate) = @thang AND year(dbo.DonHang.CreatedDate) = @nam
		SELECT @khachhang = count(dbo.KhachHang.MaKH) FROM dbo.KhachHang
		SELECT @doanhthu= (sum(dbo.DonHang.TongTien)) FROM dbo.DonHang WHERE dbo.DonHang.TrangThai = 1
		AND month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam
	END 
	ELSE 
	BEGIN 
		SELECT @donhang = count(dbo.DonHang.MaDH) FROM dbo.DonHang WHERE month(dbo.DonHang.CreatedDate)=@thang 
				AND dbo.DonHang.MaNV = @manv AND year(dbo.DonHang.CreatedDate) = @nam
		SELECT @khachhang = count(dbo.KhachHang.MaKH) FROM dbo.KhachHang
		SELECT @doanhthu=(sum(dbo.DonHang.TongTien)) FROM dbo.DonHang WHERE dbo.DonHang.TrangThai = 1
		AND month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam AND dbo.DonHang.MaNV = @manv
	END 
		
	SELECT @thucung AS [SoThuCung], @donhang AS [SoHoaDon], @khachhang AS [SoKhachHang], iif(@doanhthu>=0,@doanhthu,0) AS [DoanhThu]
END
GO

/*====================================================================================*/
--Lấy doanh thú gắn vào panelHome
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_BaoCaoDoanhThuCuaHang]
@maNV int,
@thang int,
@nam int
AS
BEGIN
	DECLARE @quyen int
	SELECT @quyen = dbo.NhanVien.MaQuyen FROM dbo.NhanVien WHERE dbo.NhanVien.MaNV = @manv
	IF (@quyen=1) 
	BEGIN
		SELECT dbo.DonHang.CreatedDate AS [NgayBan], sum((dbo.DonHang.TongTien)) AS [DoanhThu] FROM dbo.DonHang 
		WHERE month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam AND dbo.DonHang.TrangThai = 1
		GROUP BY dbo.DonHang.CreatedDate
	END
	ELSE 
	BEGIN 
		SELECT dbo.DonHang.CreatedDate AS [NgayBan], sum((dbo.DonHang.TongTien)) AS [DoanhThu] FROM dbo.DonHang 
		WHERE month(dbo.DonHang.CreatedDate)=@thang AND year(dbo.DonHang.CreatedDate)=@nam AND dbo.DonHang.MaNV = @manv AND dbo.DonHang.TrangThai = 1
		GROUP BY dbo.DonHang.CreatedDate
	END 
END
GO

/*====================================================================================*/
--Thống kê doanh thu
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ThongKeDoanhThuCuaHang]
@frmdate date,
@todate date
AS
BEGIN
	BEGIN
		SELECT dbo.DonHang.CreatedDate AS [NgayBan], sum((dbo.DonHang.TongTien)) AS [DoanhThu] FROM dbo.DonHang 
		WHERE dbo.DonHang.CreatedDate >= @frmdate AND dbo.DonHang.CreatedDate <= @todate AND dbo.DonHang.TrangThai = 1
		GROUP BY dbo.DonHang.CreatedDate
	END
END
GO

/*====================================================================================*/
--Thống kê doanh thu
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ThongKeDonHang]
@frmdate date,
@todate date
AS 
BEGIN
	BEGIN
		SELECT top 10 dbo.DonHang.MaDH , dbo.DonHang.CreatedDate, sum((dbo.ChiTietDonHang.ThanhTien)) AS [DoanhThu] 
		FROM dbo.DonHang, dbo.ChiTietDonHang
		WHERE dbo.DonHang.MaDH = dbo.ChiTietDonHang.MaDH AND dbo.DonHang.CreatedDate >= @frmdate 
			AND dbo.DonHang.CreatedDate <= @todate AND dbo.DonHang.TrangThai = 1
		GROUP BY dbo.DonHang.MaDH , dbo.DonHang.CreatedDate
		ORDER BY [DoanhThu] DESC;
	END
END
GO

/*====================================================================================*/
--Thống kê doanh thu
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ThongKeThuCungBanChay]
@frmdate date,
@todate date
AS
BEGIN
	BEGIN
		SELECT TOP 5 dbo.Giong.MaGiong, dbo.Giong.TenGiong, COUNT(dbo.ChiTietDonHang.MaTC) AS [SoLuongBan], sum((dbo.ChiTietDonHang.ThanhTien)) AS [DoanhThu] 
		FROM dbo.Giong, dbo.ThuCung, dbo.ChiTietDonHang, dbo.DonHang
		WHERE dbo.Giong.MaGiong = dbo.ThuCung.MaGiong AND 
			dbo.ThuCung.MaTC=dbo.ChiTietDonHang.MaTC AND dbo.DonHang.MaDH=dbo.ChiTietDonHang.MaDH 
			AND dbo.DonHang.CreatedDate >= @frmdate AND dbo.DonHang.CreatedDate <= @todate AND dbo.DonHang.TrangThai = 1
		GROUP BY dbo.Giong.MaGiong, dbo.Giong.TenGiong
		ORDER BY [SoLuongBan] DESC;
	END
END
GO

/*====================================================================================*/
--Khoá Ngoại Bảng NhanVien
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhanQuyen] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[PhanQuyen] ([MaQuyen])
GO

ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhanQuyen]
GO

--Khoá Ngoại Bảng DonHang
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO

ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_NhanVien]
GO

ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO

ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO

--Khoá Ngoại Bảng ChiTietDonHang
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_ThuCung] FOREIGN KEY([MaTC])
REFERENCES [dbo].[ThuCung] ([MaTC])
GO

ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_ThuCung]
GO

ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO

ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO

--Khoá Ngoại Bảng Giong
ALTER TABLE [dbo].[Giong]  WITH CHECK ADD  CONSTRAINT [FK_Giong_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO

ALTER TABLE [dbo].[Giong] CHECK CONSTRAINT [FK_Giong_Loai]
GO

--Khoá Ngoại Bảng ThuCung
ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD  CONSTRAINT [FK_ThuCung_Loai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[Loai] ([MaLoai])
GO

ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [FK_ThuCung_Loai]
GO

ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD CONSTRAINT [FK_ThuCung_Gionggggg] FOREIGN KEY([MaGiong])
REFERENCES [dbo].[Giong] ([MaGiong])
GO

ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [FK_ThuCung_Gionggggg]
GO

--Khoá Ngoại Bảng ChiTietPN
ALTER TABLE [dbo].[ChiTietPN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPN_ThuCung] FOREIGN KEY([MaTC])
REFERENCES [dbo].[ThuCung] ([MaTC])
GO

ALTER TABLE [dbo].[ChiTietPN] CHECK CONSTRAINT [FK_ChiTietPN_ThuCung]
GO

ALTER TABLE [dbo].[ChiTietPN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPN_PhieuNhap] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO

ALTER TABLE [dbo].[ChiTietPN] CHECK CONSTRAINT [FK_ChiTietPN_PhieuNhap]
GO

--Khoá Ngoại Bảng PhieuNhap
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO

ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO

ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_DonDatMua] FOREIGN KEY([MaDDM])
REFERENCES [dbo].[DonDatMua] ([MaDDM])
GO

ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_DonDatMua]
GO

--Khoá Ngoại Bảng DonDatMua
ALTER TABLE [dbo].[DonDatMua]  WITH CHECK ADD  CONSTRAINT [FK_DonDatMua_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO

ALTER TABLE [dbo].[DonDatMua] CHECK CONSTRAINT [FK_DonDatMua_NhaCungCap]
GO

ALTER TABLE [dbo].[DonDatMua]  WITH CHECK ADD  CONSTRAINT [FK_DonDatMua_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO

ALTER TABLE [dbo].[DonDatMua] CHECK CONSTRAINT [FK_DonDatMua_NhanVien]
GO


--Khoá Ngoại Bảng ChiTietDDM
ALTER TABLE [dbo].[ChiTietDDM]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDDM_PhieuNhap] FOREIGN KEY([MaDDM])
REFERENCES [dbo].[DonDatMua] ([MaDDM])
GO

ALTER TABLE [dbo].[ChiTietDDM] CHECK CONSTRAINT [FK_ChiTietDDM_PhieuNhap]
GO

ALTER TABLE [dbo].[ChiTietDDM]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDDM_Giong] FOREIGN KEY([MaGiong])
REFERENCES [dbo].[Giong] ([MaGiong])
GO

ALTER TABLE [dbo].[ChiTietDDM] CHECK CONSTRAINT [FK_ChiTietDDM_Giong]
GO

--Khoá Ngoại Bảng DoiTra
ALTER TABLE [dbo].[DoiTra]  WITH CHECK ADD  CONSTRAINT [FK_DoiTra_DonHang] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO

ALTER TABLE [dbo].[DoiTra] CHECK CONSTRAINT [FK_DoiTra_DonHang]
GO

ALTER TABLE [dbo].[DoiTra]  WITH CHECK ADD  CONSTRAINT [FK_DoiTra_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO

ALTER TABLE [dbo].[DoiTra] CHECK CONSTRAINT [FK_DoiTra_NhanVien]
GO

--Khoá Ngoại Bảng ThuCungReview
ALTER TABLE [dbo].[ThuCungReview]  WITH CHECK ADD  CONSTRAINT [FK_ThuCungReview_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO

ALTER TABLE [dbo].[ThuCungReview] CHECK CONSTRAINT [FK_ThuCungReview_KhachHang]
GO

ALTER TABLE [dbo].[ThuCungReview]  WITH CHECK ADD  CONSTRAINT [FK_ThuCungReview_ThuCung] FOREIGN KEY([MaTC])
REFERENCES [dbo].[ThuCung] ([MaTC])
GO

ALTER TABLE [dbo].[ThuCungReview] CHECK CONSTRAINT [FK_ThuCungReview_ThuCung]
GO

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (1, N'Quản Lý')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (2, N'Nhân Viên')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF

/*===========================Mã Hash = 123=========================================================*/
SET IDENTITY_INSERT [dbo].[NhanVien] ON
INSERT [dbo].[NhanVien] ([MaNV], [UserName], [Password], [HoTen], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong]) 
VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70', N'Đinh Phát Tài','3009930872', CAST(N'2001-09-30T23:51:19.487' AS DateTime),
N'Ấp 3 Long Cang, Cần Đước, Long An', N'phattai30092001@gmail.com', N'0359975249', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 1 , CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [UserName], [Password], [HoTen], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong])
VALUES (2, N'nhanvien1', N'202cb962ac59075b964b07152d234b70', N'Nguyễn Thị Ánh','8247517810', CAST(N'2001-10-04T23:51:19.487' AS DateTime),
N'Ấp 1 Long Cang, Cần Đước, Long An', N'nguyenthia@gmail.com', N'0114226111', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 2 , CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [UserName], [Password], [HoTen], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong])
VALUES (3, N'nhanvien2', N'202cb962ac59075b964b07152d234b70', N'Trần Văn Hoàng','2100393548', CAST(N'2001-10-04T23:51:19.487' AS DateTime),
N'Ấp 2 Long Cang, Cần Đước, Long An', N'tranvanf@gmail.com', N'0199493953', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 2 , CAST(3000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [UserName], [Password], [HoTen], [CMND], [NgaySinh], [Address], [Email], [Phone], [CreateDate], [MaQuyen], [TienLuong])
VALUES (4, N'nhanvien3', N'202cb962ac59075b964b07152d234b70', N'Trương Hoàng Chiêu','6036139097', CAST(N'2001-10-04T23:51:19.487' AS DateTime),
N'Ấp 4 Long Cang, Cần Đước, Long An', N'truonghoangc@gmail.com', N'0306602466', CAST(N'2021-11-04T23:51:19.487' AS DateTime), 2 , CAST(3000000 AS Decimal(18, 0)))

SET IDENTITY_INSERT [dbo].[NhanVien] OFF

/*================================Mã Hash = 123456 ====================================================*/

SET IDENTITY_INSERT [dbo].[KhachHang] ON 
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [Address], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (1,
N'Nguyễn Văn Cảnh', N'nguyenvanc', N'e10adc3949ba59abbe56e057f20f883e', N'nguyenvanc@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0981234567', N'Nam', CAST(N'1987-10-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [Address], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (2,
N'Nguyễn Văn Dao', N'nguyenvand', N'e10adc3949ba59abbe56e057f20f883e', N'nguyenvand@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0429333883', N'Nam', CAST(N'1980-11-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [Address], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (3,
N'Nguyễn Thị Anh', N'nguyenthia', N'e10adc3949ba59abbe56e057f20f883e', N'nguyenthia@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0226998718', N'Nữ', CAST(N'1995-01-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [Address], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (4,
N'Nguyễn Trần Hoàng', N'nguyentranhoang', N'e10adc3949ba59abbe56e057f20f883e', N'nguyentranhoang@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0227254554', N'Nam', CAST(N'1994-02-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [HoTen], [TaiKhoan], [MatKhau], [Email], [Address], [DienThoai], [GioiTinh], [NgaySinh], [CreatedDate]) VALUES (5,
N'Trần Hoàng Anh', N'tranhoanganh', N'e10adc3949ba59abbe56e057f20f883e', N'phattai30092001@gmail.com', N'123 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP Hồ Chí Minh', N'0359975249', N'Nam', CAST(N'1993-03-01T00:00:00.000' AS DateTime), CAST(N'2021-12-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[KhachHang] OFF

/*====================================================================================*/

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [Phone], [Email], [Address]) VALUES (1, N'Nhà Cung Cấp A', N'0359975249', N'tai123@gmail.com', N'Long An')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [Phone], [Email], [Address]) VALUES (2, N'Nhà Cung Cấp B', N'0359975250', N'tai321@gmail.com', N'Cà Mau')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [Phone], [Email], [Address]) VALUES (3, N'Nhà Cung Cấp C', N'0359975534', N'tai145@gmail.com', N'Hà Nội')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [Phone], [Email], [Address]) VALUES (4, N'Nhà Cung Cấp D', N'0353425345', N'tai867@gmail.com', N'Bến Tre')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [Phone], [Email], [Address]) VALUES (5, N'Nhà Cung Cấp E', N'0354324235', N'tai978@gmail.com', N'Huế')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[Loai] ON 
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (1, N'Chó')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (2, N'Mèo')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (3, N'Chim')
INSERT [dbo].[Loai] ([MaLoai], [TenLoai]) VALUES (4, N'Hamster')
SET IDENTITY_INSERT [dbo].[Loai] OFF

/*====================================================================================*/
SET IDENTITY_INSERT [dbo].[Giong] ON 
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (1,
1, 
N'Chó Husky',0,
N'Chó Husky là một giống chó tuyết có nguồn gốc từ Sibir, Nga.
Husky có vẻ đẹp quyến rũ, thân hình dũng mãnh, sức khỏe dẻo dai phi thường.
Là giống chó hiền lành, rất tình cảm, hay tò mò, ưa vận động, rất thích người và đặc biệt thân thiện với trẻ em. 
Ở Việt Nam, chó Husky rất được yêu thích và được săn đón bởi đông đảo những người yêu chó.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (1,
2,
N'Chó Corgi',0,
N'Chó Corgi là một giống chó nhỏ, chân ngắn nhưng thân dài, đuôi cụt và một đôi tai lớn.
Corgi có vẻ ngoài đáng yêu, cặp mông hình trái tim tạo nên nét quyến rũ và đã tạo nên cơn sốt ngắm mông Corgi.  
Là giống chó rất thông minh, biết vâng lời, có bản năng bảo vệ, rất tận tâm với chủ và thân thiện với trẻ em. 
Chúng rất điềm tĩnh, trung thành và đáng yêu, song rất cảnh giác trước người lạ.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (1,
3,
N'Chó Golden Retriever',0,
N'Chó Golden Retriever là một giống chó săn thượng hạng đến từ Scotland.
Golden có bộ lông vàng mượt khá sang trọng, khuôn mặt thường xuyên cười vui vẻ, tuy nhiên, lúc buồn lại tỏ vẻ đáng thương rõ ràng.
Là giống chó rất thông minh, dễ huấn luyện, luôn biết cách làm hài lòng chủ nhân và thích vui chơi cùng mọi người.
Golden rất điềm tĩnh, hiền lành và tình cảm, lại rất nhanh nhẹn và năng động.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (1,
4,
N'Chó Pit Bull',0,
N'Chó Bull hay còn gọi với tên tiếng Anh là American Pit Bull Terrier hay Pit Bull hoặc Dog
Pit Bull Terrier American là một giống chó có nguồn gốc từ Mỹ. Đây là một giống chó có
kích cỡ trung bình đến lớn có nguồn gốc từ dòng chó chọi')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (1,
5,
N'Chó Pug',0,
N'Pug,
hay thường được gọi là chó mặt xệ, là giống chó thuộc nhóm chó cảnh có nguồn gốc từ Trung Quốc,
chúng có một khuôn mặt nhăn, mõm ngắn, và đuôi xoăn. Giống chó này có bộ lông mịn, bóng, có nhiều màu sắc nhưng phổ biến nhất là màu đen và nâu vàng.
Cơ thể của Pug nhỏ gọn hình vuông với các cơ bắp rất phát triển.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (2,
6,
N'Mèo Anh lông ngắn',0,
N'Mèo Anh lông ngắn là một giống mèo cảnh có nguồn gốc từ Anh.
Chúng sở hữu một thân hình vô cùng mập mạp đáng yêu, nổi bật với khuôn mặt tròn và bộ lông màu xám xanh cổ điển và một cái đuôi to.
Tính cách của chúng tuy khá lười biếng tuy nhiên lại phù hợp với những người bận rộn không có quá nhiều thời gian và không đòi hỏi chủ nhân của chúng phải chải chuốt vệ sinh thường xuyên.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (2,
7,
N'Mèo Nga lông dài',0,
N'Mèo Nga lông dài thực chất có nguồn gốc là giống mèo Angora Turkish, có xuất xứ từ Thổ Nhĩ Kỳ.
Mèo Nga sở hữu bộ lông dài trắng muốt như tuyết tuyệt đẹp, tuy nhiên không xù, thân hình nhỏ gọn, thanh thoát và quý phái.
Tính tình thông minh, linh hoạt, quấn chủ và hiền lành, mèo Nga được xem như loại mèo toàn diện nhất.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (2,
8,
N'Mèo Exotic',0,
N'Mèo lông ngắn Ba Tư hay còn gọi là mèo Exotic hay còn gọi là mèo Ba Tư mặt tịt là giống mèo có nguồn gốc tại Mỹ,
được phát triển trên cơ sở phiên bản của giống mèo Ba Tư. Chúng là giống khá nổi tiếng, đáng yêu và được nhiều người hâm hộ, đặc biệt là nữ giới')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (2,
9,
N'Mèo Ai Cập',0,
N'Mèo Sphinx hay còn gọi là mèo không lông Sphinx hay còn được biết đến là mèo Canada hoặc mèo Mexico không lông là
một giống mèo được phát triển vào thập niên 1960 với đặc điểm là thân thể trần trụi, không có sợi lông nào. Giống mèo này được coi là một trong những
giống mèo xấu nhất thế giới nhưng lại có giá rất đắt.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (3,
10,
N'Chim họa mi',0,
N'Có tên khoa học là Garrulux Canorus, chim Họa Mi thường sinh sống ở các khu rừng, vườn cây,
 công viên,… Loài chim cảnh Việt Nam này khá nhỏ bé, chỉ ngang hoặc bé hơn chim Sơn Ca nhưng 
 bù lại chúng là một trong các loại chim hót hay nhất. Bởi vậy mà người ta thường ví các ca sĩ có giọng hát cao là những chú chim họa mi.') 
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (3,
11,
N'Chim vàng anh',0,
N'Chim Vàng Anh luôn nổi bật với màu lông vàng rực. Chim mái và chim trống sẽ có ánh màu khác nhau đôi chút.
Chim Vàng Anh cũng thuộc các loại chim sâu ở Việt Nam nên thường được nuôi để diệt sâu và trang trí.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (3,
12,
N'Chim sơn ca',0,
N'Sơn ca hay Sơn ca phương Đông là một loài chim thuộc Họ Sơn ca. Loài này sinh sống ở Nam Á và Đông Nam Á.
 Giống như các loài sơn ca khác, nó được tìm thấy trong khu vực đồng cỏ thưa - thường gần các thuỷ vực - nơi nó ăn hạt và côn trùng.')
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (3,
13,
N'Chim chào mào',0,
N'Chào mào là một loài chim thuộc bộ Sẻ phân bố ở châu Á. Nó là một thành viên của họ Chào mào.
Nó là một loài động vật ăn quả thường trú được tìm thấy chủ yếu ở châu Á nhiệt đới. Nó đã được đưa bởi con người 
vào nhiều khu vực nhiệt đới trên thế giới, nơi các quần thể đã tự hình thành. Nó ăn trái cây và côn trùng nhỏ.') 
INSERT [dbo].[Giong] ([MaLoai], [MaGiong], [TenGiong], [SoLuongTon], [MoTa]) VALUES (4,
14,
N'Chuột Hamster',0,
N'Chuột Hamster không phải thuộc loài họ chuột thông thường (họ Chuột) như chuột cống, 
chuột nhắt, chuột đồng... mang nhiều mầm bệnh. Mà chúng thuộc họ Cricetidae, sinh sống ngoài tự nhiên, thường đào hang và có hai túi má để dự trữ thức ăn. ')

SET IDENTITY_INSERT [dbo].[Giong] OFF
/*====================================================================================*/

--/*====================================================================================*/

--SET IDENTITY_INSERT [dbo].[ThuCung] ON 
--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan],  [MaGiong], [MaLoai], [TrangThai]) VALUES (1,
--N'Chim Chào Mào Loại 1', CAST(750000 AS Decimal(18, 0)), N'CChim Chào Mào là loài chim đang ngày càng được lựa chọn nhiều để làm chim cảnh bởi tập tính sinh sống
--của chúng phù hợp với điều kiện sống ở nước ta. Cùng với đó là ngoại hình khá bắt mắt và giọng hót rất hay của loài chim cảnh này cũng khiến người chơi thích
--thú. Chim Chào Mào cũng rất thân thiện với người nuôi nếu như người nuôi hiểu rõ về tập tính, kỹ thuật và cách chăm sóc chúng.'
--,N'ChimChaoMao_1.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 13, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (2,
--N'Chim Chào Mào Loại 2', CAST(500000 AS Decimal(18, 0)), N'CChim Chào Mào là loài chim đang ngày càng được lựa chọn nhiều để làm chim cảnh bởi tập tính sinh sống
--của chúng phù hợp với điều kiện sống ở nước ta. Cùng với đó là ngoại hình khá bắt mắt và giọng hót rất hay của loài chim cảnh này cũng khiến người chơi thích
--thú. Chim Chào Mào cũng rất thân thiện với người nuôi nếu như người nuôi hiểu rõ về tập tính, kỹ thuật và cách chăm sóc chúng.'
--,N'ChimChaoMao_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 13, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (3,
--N'Chim Hoạ Mi Loại 1', CAST(650000 AS Decimal(18, 0)), N'Chim Họa Mi được nhiều người mệnh danh là loài chim có giọng hót tuyệt vời nhất trong tất cả các loài chim rừng.
--Cũng chính vì thế mà người nghệ sĩ nào có tông giọng tốt, hát hay đều được so sánh với chim họa mi.'
--,N'ChimHoaMi_1.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime),  10, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (4,
--N'Chim Hoạ Mi Loại 2', CAST(500000 AS Decimal(18, 0)), N'Chim Họa Mi được nhiều người mệnh danh là loài chim có giọng hót tuyệt vời nhất
--trong tất cả các loài chim rừng. Cũng chính vì thế mà người nghệ sĩ nào có tông giọng tốt, hát hay đều được so sánh với chim họa mi.'
--,N'ChimHoaMi_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 10, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (5,
--N'Chim Sơn Ca', CAST(500000 AS Decimal(18, 0)), N'Chim sơn ca là một trong những loài chim cảnh, được yêu thích nhất tại Việt Nam hiện nay.
--Trước khi có ý định nuôi 1 chú chim sơn ca, các bạn nên tìm hiểu rõ về đặc điểm và đặc tính của chúng.'
--,N'ChimSonCa_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 12, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (6,
--N'Chim Vàng Anh Loại 1', CAST(1660000 AS Decimal(18, 0)), N'Trước khi tìm hiểu chim vàng anh ăn gì thì bạn cần biết được nguồn gốc xuất xứ và đặc điểm của loài
--chim này. Vàng anh tên hay còn được gọi là chim hoàng anh, đây là loài duy nhất thuộc họ Vàng anh, bộ sẻ, sinh sống chủ yếu ở khu vực ôn đới của Bắc bán cầu.
--Loài chim này có tập tính di cư, mùa hè nó sẽ di cư đến những khu vực Châu Âu và Châu Á, mùa đông nó sẽ di cư đến khu vực nhiệt đới.'
--,N'ChimVangAnh_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 11, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (7,
--N'Chim Vàng Anh Loại 2', CAST(1500000 AS Decimal(18, 0)), N'Trước khi tìm hiểu chim vàng anh ăn gì thì bạn cần biết được nguồn gốc xuất xứ và đặc điểm của loài
--chim này. Vàng anh tên hay còn được gọi là chim hoàng anh, đây là loài duy nhất thuộc họ Vàng anh, bộ sẻ, sinh sống chủ yếu ở khu vực ôn đới của Bắc bán cầu.
--Loài chim này có tập tính di cư, mùa hè nó sẽ di cư đến những khu vực Châu Âu và Châu Á, mùa đông nó sẽ di cư đến khu vực nhiệt đới.'
--,N'ChimVangAnh_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 11, 3, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (8,
--N'Chó Corgi Loại 1', CAST(8550000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
--trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
--rãi và Việt Nam cũng không ngoại lệ.'
--,N'ChoCogri.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 2, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (9,
--N'Chó Corgi Loại 2', CAST(7000000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
--trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
--rãi và Việt Nam cũng không ngoại lệ.'
--,N'ChoCorgi_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 2, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (10,
--N'Chó Corgi Loại 3', CAST(6350000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
--trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
--rãi và Việt Nam cũng không ngoại lệ.'
--,N'ChoCorgi_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 2, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (11,
--N'Chó Corgi Thuần Chủng', CAST(12000000 AS Decimal(18, 0)), N'Xuất hiện từ hơn 3000 năm trước, chó Corgi luôn nằm trong bảng xếp hạng những giống chó được nuôi phổ biến nhất
--trên thế giới. Chú chó có nguồn gốc từ xứ Wales này rất được Hoàng gia Anh ưa chuộng. Ban đầu chúng được nuôi để chăn gia súc, từ sau thế kỉ 16 thì được nuôi rộng
--rãi và Việt Nam cũng không ngoại lệ.'
--,N'ChoCorgi_6.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 2, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (12,
--N'Chó Golden Loại 1', CAST(12500000 AS Decimal(18, 0)), N'Hiện nay trên thị trường, có rất nhiều trại chó chuyên về giống Golden Retriever thuần chủng.
--Những chú chó Golden sinh tại Việt Nam có mức giá rất hợp lý, dao động từ 6-8 triệu/ con. Rất nhiều người nuôi tỏ ra hài lòng với mức giá này. 
--Bởi chỉ với vài triệu họ có thể sở hữu được một chú chó cực kỳ thông minh, trung thành, thân thiện.'
--,N'ChoGoldenRetriever_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 3, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (13,
--N'Chó Golden Thuần Chủng', CAST(14500000 AS Decimal(18, 0)), N'Hiện nay trên thị trường, có rất nhiều trại chó chuyên về giống Golden Retriever thuần chủng.
--Những chú chó Golden sinh tại Việt Nam có mức giá rất hợp lý, dao động từ 6-8 triệu/ con. Rất nhiều người nuôi tỏ ra hài lòng với mức giá này. 
--Bởi chỉ với vài triệu họ có thể sở hữu được một chú chó cực kỳ thông minh, trung thành, thân thiện.'
--,N'ChoGoldenRetriever_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 3, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (14,
--N'Chó Husky Loại 1', CAST(7500000 AS Decimal(18, 0)), N'Chó Husky tên quốc tế là Siberian Husky hay chó Husky Sibir là giống chó nhà được phát triển bởi bộ tộc 
--Chukchi hơn 3000 năm trước và hoàn toàn không phải lai giữa chó và Sói.
--Người Chukchi đã sử dụng chó Husky để kéo xe trượt tuyết và họ xem chúng như một thành viên trong gia đình. Do đó chúng còn được 
--gọi là chó tuyết trắng, chó bạch tuyết hay chó kéo xe tuyết.'
--,N'ChoHusky_6.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 1, 1, 0)


--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (15,
--N'Chó Husky Xám', CAST(8900000 AS Decimal(18, 0)), N'Chó Husky tên quốc tế là Siberian Husky hay chó Husky Sibir là giống chó nhà được phát triển bởi bộ tộc 
--Chukchi hơn 3000 năm trước và hoàn toàn không phải lai giữa chó và Sói.
--Người Chukchi đã sử dụng chó Husky để kéo xe trượt tuyết và họ xem chúng như một thành viên trong gia đình. Do đó chúng còn được 
--gọi là chó tuyết trắng, chó bạch tuyết hay chó kéo xe tuyết.'
--,N'ChoHusky1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 1, 1, 0)


--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (16,
--N'Chó Husky Thuần Chủng', CAST(12500000 AS Decimal(18, 0)), N'Chó Husky tên quốc tế là Siberian Husky hay chó Husky Sibir là giống chó nhà được phát triển bởi bộ tộc 
--Chukchi hơn 3000 năm trước và hoàn toàn không phải lai giữa chó và Sói.
--Người Chukchi đã sử dụng chó Husky để kéo xe trượt tuyết và họ xem chúng như một thành viên trong gia đình. Do đó chúng còn được 
--gọi là chó tuyết trắng, chó bạch tuyết hay chó kéo xe tuyết.'
--,N'ChoHusky2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 1, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (17,
--N'Chó Pit Bull America', CAST(85000000 AS Decimal(18, 0)), N'Thực tế đã xảy ra rất nhiều vụ tai nạn do chó Pitbull gây ra khiến đa phần người Việt “tẩy chay” chúng.
--Tuy nhiên vẫn có rất nhiều người chọn nuôi Pitbull bởi đam mê và bởi họ biết một sự thật rằng, mọi người đang đánh đồng, hiểu sai về người bạn này.'
--,N'ChoPitBull_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 4, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (18,
--N'Chó Pit Bull Loại 1', CAST(65000000 AS Decimal(18, 0)), N'Thực tế đã xảy ra rất nhiều vụ tai nạn do chó Pitbull gây ra khiến đa phần người Việt “tẩy chay” chúng.
--Tuy nhiên vẫn có rất nhiều người chọn nuôi Pitbull bởi đam mê và bởi họ biết một sự thật rằng, mọi người đang đánh đồng, hiểu sai về người bạn này.'
--,N'ChoPitBull_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 4, 1, 0)


--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (19,
--N'Chó Pug Thuần Chủng', CAST(6000000 AS Decimal(18, 0)), N'Chó Pug mặt xệ là giống cảnh khuyển có lịch sử lâu đời. Xuất xứ của chúng đến nay vẫn chưa có câu trả lời
--chính xác. Khả năng cao nhất, Pug đã có mặt từ thời nhà Hán – Trung Quốc vào khoảng năm 200 TCN. Khi ấy, Pug được coi là giống thú cảnh quý tộc, có cuộc sống xa hoa bởi chủ yếu được hoàng thân, quốc thích Trung Quốc nuôi dưỡng.'
--,N'ChoPug_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 5, 1, 0)


--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (20,
--N'Chó Pug Con', CAST(4000000 AS Decimal(18, 0)), N'Chó Pug mặt xệ là giống cảnh khuyển có lịch sử lâu đời. Xuất xứ của chúng đến nay vẫn chưa có câu trả lời
--chính xác. Khả năng cao nhất, Pug đã có mặt từ thời nhà Hán – Trung Quốc vào khoảng năm 200 TCN. Khi ấy, Pug được coi là giống thú cảnh quý tộc, có cuộc sống xa hoa bởi chủ yếu được hoàng thân, quốc thích Trung Quốc nuôi dưỡng.'
--,N'ChoPug_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 5, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (21,
--N'Chó Pug Loại 1', CAST(3500000 AS Decimal(18, 0)), N'Chó Pug mặt xệ là giống cảnh khuyển có lịch sử lâu đời. Xuất xứ của chúng đến nay vẫn chưa có câu trả lời
--chính xác. Khả năng cao nhất, Pug đã có mặt từ thời nhà Hán – Trung Quốc vào khoảng năm 200 TCN. Khi ấy, Pug được coi là giống thú cảnh quý tộc, có cuộc sống xa hoa bởi chủ yếu được hoàng thân, quốc thích Trung Quốc nuôi dưỡng.'
--,N'ChoPug_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 5, 1, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (22,
--N'Chuột Hamster', CAST(350000 AS Decimal(18, 0)), N'Chuột Hamster hiện nay có khoảng 26 loài, tuy nhiên giống chuột được biết đến nhiều nhất là chuột Hamster
--Syria. Chúng được phát hiện lần đầu vào năm 1839 bởi một nhà động vật học người Anh tên là George Robert Waterhouse, ông đã đặt tên loài chuột kỳ lạ này là
--Mesocricetus auratus, có nghĩa là lông vàng.'
--,N'ChuotHamster_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 14, 4, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (23,
--N'Mèo Ai Cập Loại 1', CAST(45000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
--Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
--Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
--Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
--,N'MeoAiCap_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 9, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (24,
--N'Mèo Ai Cập Mắt Vàng', CAST(170000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
--Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
--Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
--Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
--,N'MeoAiCap_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 9, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (25,
--N'Mèo Ai Cập Mắt Vàng 2', CAST(112000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
--Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
--Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
--Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
--,N'MeoAiCap_3.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 9, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (26,
--N'Mèo Ai Cập', CAST(40000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
--Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
--Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
--Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
--,N'MeoAiCap_4.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 9, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (27,
--N'Mèo Ai Cập Chuẩn', CAST(135000000 AS Decimal(18, 0)), N'Vào năm 1966, có 1 sự giao phối rất ngẫu nhiên đến từ 2 chú mèo ở Toronto và Canada. 
--Kết quả thực sự rất bất ngờ khi Prune ra đời và trên người hoàn toàn trụi lông và trông rất hoang dã.
--Sau khi trưởng thành, Prune lại tiếp tục giao phối với mẹ của nó và kết quả là đã có nhiều chú mèo không lông khác ra đời.
--Chúng chính là cụ nội loài mèo không lông Ai Cập ngày nay'
--,N'MeoAiCap_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 9, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (28,
--N'Mèo Anh Long Ngắn Thuần Chủng', CAST(7500000 AS Decimal(18, 0)), N'Mèo Anh là giống mèo phổ biến có nguồn gốc từ nước Anh. Xuất hiên từ nhưng
--năm cuối thế kỉ 19 và trải qua một khoảng thời gian dài lai tạo để có những đặc tính tốt nhất. Hiện nay chúng đã được nuôi rất phổ biến trong các gia đình trên khắp thế giới, Việt Nam cũng không ngoại lệ.
--Có hai dòng mèo Anh phố biến nhất là Anh lông ngắn (ALN) và Anh lông dài (ALD).'
--,N'MeoAnhLongNgan_3.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 6, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (29,
--N'Mèo Anh Long Ngắn Loại 1', CAST(6000000 AS Decimal(18, 0)), N'Mèo Anh là giống mèo phổ biến có nguồn gốc từ nước Anh. Xuất hiên từ nhưng
--năm cuối thế kỉ 19 và trải qua một khoảng thời gian dài lai tạo để có những đặc tính tốt nhất. Hiện nay chúng đã được nuôi rất phổ biến trong các gia đình trên khắp thế giới, Việt Nam cũng không ngoại lệ.
--Có hai dòng mèo Anh phố biến nhất là Anh lông ngắn (ALN) và Anh lông dài (ALD).'
--,N'MeoAnhLongNgan_4.png', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 6, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (30,
--N'Mèo Anh Long Ngắn', CAST(5500000 AS Decimal(18, 0)), N'Mèo Anh là giống mèo phổ biến có nguồn gốc từ nước Anh. Xuất hiên từ nhưng
--năm cuối thế kỉ 19 và trải qua một khoảng thời gian dài lai tạo để có những đặc tính tốt nhất. Hiện nay chúng đã được nuôi rất phổ biến trong các gia đình trên khắp thế giới, Việt Nam cũng không ngoại lệ.
--Có hai dòng mèo Anh phố biến nhất là Anh lông ngắn (ALN) và Anh lông dài (ALD).'
--,N'MeoAnhLongNgan_5.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 6, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (31,
--N'Mèo Exotic', CAST(9000000 AS Decimal(18, 0)), N'Bạn yêu thích một chú Mèo Ba Tư sang trọng nhưng lại không có đủ thời gian săn sóc kĩ lưỡng cho bộ lông 
--của chúng? Hãy thử làm bạn với mèo Exotic là giống mèo còn khá mới, có nguồn gốc từ Ba Tư thuần chủng lai với mèo Mỹ lông ngắn vào những năm 1950. 
--Do có khuôn mặt, thân hình, tính cách và cả các bệnh di truyền giống hệt mèo Ba Tư nên giới yêu mèo thường gọi mèo Exotic là mèo Ba Tư lông ngắn.'
--,N'MeoExotic_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 8, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (32,
--N'Mèo Nga Long Dài Thuần Chủng', CAST(5200000 AS Decimal(18, 0)), N'Đúng với tên gọi của mình, mèo Nga thuần chủng có xuất xứ từ đất nước Russian 
--nhưng điều đặc biệt làm nên vẻ hấp dẫn của giống loài này không chỉ dừng lại ở đấy.
--Vào cuối thế kỉ 19, người ta tìm thấy loài mèo này tại nước Nga với thân hình nhỏ bé, bộ lông ngắn ôm sát và màu sắc rất riêng biệt.
--mèo nga mắt 2 màuTại 1 cuộc triển lãm thường niên dành cho loài mèo được tổ chức vào năm 1875.'
--,N'MeoNgaLongDai_1.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 7, 2, 0)

--INSERT [dbo].[ThuCung] ([MaTC], [TenTC], [GiaBan], [MoTa], [Anh], [CreateDate], [NgayCapNhat], [NgayBan], [MaGiong], [MaLoai], [TrangThai]) VALUES (33,
--N'Mèo Nga Long Dài', CAST(2400000 AS Decimal(18, 0)), N'Đúng với tên gọi của mình, mèo Nga thuần chủng có xuất xứ từ đất nước Russian 
--nhưng điều đặc biệt làm nên vẻ hấp dẫn của giống loài này không chỉ dừng lại ở đấy.
--Vào cuối thế kỉ 19, người ta tìm thấy loài mèo này tại nước Nga với thân hình nhỏ bé, bộ lông ngắn ôm sát và màu sắc rất riêng biệt.
--mèo nga mắt 2 màuTại 1 cuộc triển lãm thường niên dành cho loài mèo được tổ chức vào năm 1875.'
--,N'MeoNgaLongDai_2.jpg', CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), CAST(N'2021-11-22T00:00:00.000' AS DateTime), 7, 2, 0)

--SET IDENTITY_INSERT [dbo].[ThuCung] OFF

--/*====================================================================================*/
--SET IDENTITY_INSERT [dbo].[DonHang] ON 
--INSERT [dbo].[DonHang] ([MaDH], [MaNV], [CreatedDate], [MaKH], [NguoiNhan], [Email], [Phone], [Address], [TongTien], [TrangThai]) VALUES (1, 2,
--CAST(N'2022-06-01T23:51:19.487' AS DateTime), 2, N'Nguyễn Văn Dao', N'nguyenvandao@gmail.com', N'0425343423', N'Ấp 3 Long Cang, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 0)
--INSERT [dbo].[DonHang] ([MaDH], [MaNV], [CreatedDate], [MaKH], [NguoiNhan], [Email], [Phone], [Address], [TongTien], [TrangThai]) VALUES (2, 2,
--CAST(N'2022-06-02T23:51:19.487' AS DateTime), 1, N'Nguyễn Văn Cảnh', N'nguyenvanccanh@gmail.com', N'0417237280', N'Ấp 11 Long Định, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)
--INSERT [dbo].[DonHang] ([MaDH], [MaNV], [CreatedDate], [MaKH], [NguoiNhan], [Email], [Phone], [Address], [TongTien], [TrangThai]) VALUES (3, 3,
--CAST(N'2022-06-19T23:51:19.487' AS DateTime), 3, N'Nguyễn Thị Anh', N'nguyenthianh@gmail.com', N'0132003781', N'Ấp 11 Long Định, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)
--INSERT [dbo].[DonHang] ([MaDH], [MaNV], [CreatedDate], [MaKH], [NguoiNhan], [Email], [Phone], [Address], [TongTien], [TrangThai]) VALUES (4, 4,
--CAST(N'2022-06-15 23:51:19.487' AS DateTime), 4, N'Trần Hoàng Anh', N'tranvananh@gmail.com', N'0870063999', N'Ấp 11 Long Định, Cần Đước, Long An', CAST(25000000 AS Decimal(18, 0)), 1)
--SET IDENTITY_INSERT [dbo].[DonHang] OFF

--/*====================================================================================*/
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (1, 1, CAST(25000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (1, 12, CAST(25000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (2, 2, CAST(25000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (2, 4, CAST(25000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (3, 5, CAST(25000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (4, 19, CAST(25000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietDonHang] ([MaDH], [MaTC], [ThanhTien]) VALUES (4, 15, CAST(25000000 AS Decimal(18, 0)))


--/*====================================================================================*/
--SET IDENTITY_INSERT [dbo].[DonDatMua] ON 
--INSERT [dbo].[DonDatMua] ([MaDDM], [MaNCC], [MaNV], [CreateDate]) VALUES (1, 1, 1, CAST(N'2022-06-04T23:51:19.487' AS DateTime))
--INSERT [dbo].[DonDatMua] ([MaDDM], [MaNCC], [MaNV], [CreateDate]) VALUES (2, 2, 1, CAST(N'2022-06-04T23:51:19.487' AS DateTime))
--SET IDENTITY_INSERT [dbo].[DonDatMua] OFF

--/*====================================================================================*/
--INSERT [dbo].[ChiTietDDM] ([MaDDM], [MaGiong], [GiaMua], [SoLuongMua]) VALUES (1, 1, CAST(2000000 AS Decimal(18, 0)), 5)
--INSERT [dbo].[ChiTietDDM] ([MaDDM], [MaGiong], [GiaMua], [SoLuongMua]) VALUES (1, 2, CAST(2000000 AS Decimal(18, 0)), 5)
--INSERT [dbo].[ChiTietDDM] ([MaDDM], [MaGiong], [GiaMua], [SoLuongMua]) VALUES (2, 3, CAST(2000000 AS Decimal(18, 0)), 5)
--INSERT [dbo].[ChiTietDDM] ([MaDDM], [MaGiong], [GiaMua], [SoLuongMua]) VALUES (2, 4, CAST(2000000 AS Decimal(18, 0)), 5)

--/*====================================================================================*/
--SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 
--INSERT [dbo].[PhieuNhap] ([MaPN], [MADDM], [MaNV], [NgayNhap]) VALUES (1, 1, 1, CAST(N'2022-06-04T23:51:19.487' AS DateTime))
--INSERT [dbo].[PhieuNhap] ([MaPN], [MADDM], [MaNV], [NgayNhap]) VALUES (2, 1, 1, CAST(N'2022-06-04T23:51:19.487' AS DateTime))
--INSERT [dbo].[PhieuNhap] ([MaPN], [MADDM], [MaNV], [NgayNhap]) VALUES (3, 2, 1, CAST(N'2022-06-04T23:51:19.487' AS DateTime))
--INSERT [dbo].[PhieuNhap] ([MaPN], [MADDM], [MaNV], [NgayNhap]) VALUES (4, 2, 1, CAST(N'2022-06-04T23:51:19.487' AS DateTime))
--SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF

--/*====================================================================================*/
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (1, 1, 1 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (1, 1, 2 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (2, 2, 3 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (2, 2, 4 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (3, 3, 5 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (3, 3, 6 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (4, 4, 7 ,CAST(2000000 AS Decimal(18, 0)))
--INSERT [dbo].[ChiTietPN] ([MaPN], [MaGiong], [MaTC], [GiaNhap]) VALUES (4, 5, 8 ,CAST(2000000 AS Decimal(18, 0)))

--/*====================================================================================*/
--SET IDENTITY_INSERT [dbo].[DoiTra] ON 
--INSERT [dbo].[DoiTra] ([MaDT], [MaNV], [MADH], [NgayDoi], [LyDo], [TinhTrangThuCung]) VALUES (1, 1, 3, CAST(N'2022-06-04T23:51:19.487' AS DateTime), N'Xấu', N'Bình Thường')
--INSERT [dbo].[DoiTra] ([MaDT], [MaNV], [MADH], [NgayDoi], [LyDo], [TinhTrangThuCung]) VALUES (2, 1, 4, CAST(N'2022-06-04T23:51:19.487' AS DateTime), N'Xấu', N'Bình Thường')
--SET IDENTITY_INSERT [dbo].[DoiTra] OFF

--/*====================================================================================*/
--SET IDENTITY_INSERT [dbo].[ThuCungReview] ON 
--INSERT [dbo].[ThuCungReview] ([MaReview], [MaTC], [MaKH], [TieuDe], [DanhGia], [NoiDung], [CreatedDate], [TrangThai], [NgayDang]) VALUES (1, 1, 1, N'Chó Đẹp', 5, N'Thú cưng tại shop đẹp', CAST(N'2022-06-15T23:51:19.487' AS DateTime), 1, CAST(N'2022-06-15T23:51:19.487' AS DateTime))
--INSERT [dbo].[ThuCungReview] ([MaReview], [MaTC], [MaKH], [TieuDe], [DanhGia], [NoiDung], [CreatedDate], [TrangThai], [NgayDang]) VALUES (2, 1, 2, N'Chó Xấu', 1, N'Thú cưng tại shop xấu vô lý', CAST(N'2022-06-15T23:51:19.487' AS DateTime), 1, CAST(N'2022-06-15T23:51:19.487' AS DateTime))
--SET IDENTITY_INSERT [dbo].[ThuCungReview] OFF

-------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------BACKUP--------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------