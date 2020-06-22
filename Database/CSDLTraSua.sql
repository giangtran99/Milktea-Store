create database CSDLTraSua
go

use CSDLTrasua
go

create table tRole(
 
 RoleID varchar(100) primary key,
 RoleName varchar(100)
)

create table Permission(
  PerID varchar(100) primary key,
  PerName varchar(100)
)
create table Per_Role(
 Per_RoleID varchar(100) primary key,
 PerID varchar(100) foreign key(PerID) references Permission(PerID) , 
  RoleID varchar(100) foreign key(RoleID) references tRole(RoleID),
)

create table KhachHang(
MaKhachHang int primary key IDENTITY (1,1),
HoTen nvarchar(50),
Diachi text,
SDT int,
Email nvarchar(50),
TenDangNhap nvarchar(50),
MatKhau nvarchar(50)
)

create table Nhanvien(
MaNhanvien int primary key,
Hoten nvarchar(50),
Ngaysinh datetime,
Diachi text,
Email nvarchar(50),
Gioitinh bit,
TenDangNhap nvarchar(50),
MatKhau nvarchar(50),
RoleID varchar(100) foreign key(RoleID) references tRole(RoleID)
)
create table Giamgia(
MaGiamgia int primary key,
Giatrigiam int,
Ngaybatdau datetime,
Ngayketthuc datetime
)

create table Topping(
MaTopping int primary key,
Ten nvarchar(50)
)


create table SanPham(
MaSanPham int primary key,
TenSanPham nvarchar(50),
Gia float,
Linkanh varchar(100)
)


create table DonHang(
MaDonHang int primary key IDENTITY (1,1),
NgayDatHang datetime,
TongTien float,
MaKhachHang int  foreign key (MaKhachHang) references KhachHang(MaKhachHang),
MaNhanvien int  foreign key (MaNhanvien) references Nhanvien(MaNhanvien),
MaGiamgia int  foreign key (MaGiamgia) references Giamgia(MaGiamgia),
)
create table Size(
TenSize varchar(50) primary key,
GiaSize int
)
create table ChitietDonHang(
MaChitietDonHang int primary key IDENTITY (1,1),
MaSanPham int foreign key (MaSanPham) references SanPham(MaSanPham),
MaTopping int  foreign key (MaTopping) references Topping(MaTopping),
MaDonHang int foreign key (MaDonHang) references DonHang(MaDonHang),
TenSize varchar(50) foreign key (TenSize) references Size(TenSize),
SoLuong int,
Thanhtien float
)


insert SanPham(MaSanPham,TenSanPham,Gia,Linkanh)
values(1, N'Trà Sữa Trân Trâu',
35000,'/TemplateTraSua/anh-layer/img-layer-1-2.jpg')

insert SanPham(MaSanPham,TenSanPham,Gia,Linkanh)
values(2, N'Trà Sữa Kem chesse',
35000,'/TemplateTraSua/anh-layer/img-layer-2.jpg')


insert SanPham(MaSanPham,TenSanPham,Gia,Linkanh)
values(3, N'Trà Sữa Matcha',
35000,'/TemplateTraSua/anh-layer/img-layer-2-1.jpg')

insert Topping(MaTopping,Ten)
values(1,N'Hoa Quả Tươi')
insert Topping(MaTopping,Ten)
values(2,N'Trân Trâu')
insert Topping(MaTopping,Ten)
values(3,N'Thạch Hoa Quả')

insert Size(TenSize,GiaSize)
values('L',15000)
insert Size(TenSize,GiaSize)
values('M',0)

insert KhachHang(TenDangNhap,MatKhau,HoTen,SDT,Email,Diachi)
values('admin','123',N'Trần Hoàng Giang','123123123','giang@gmail.com','Thanh Xuan - Ha Noi')










