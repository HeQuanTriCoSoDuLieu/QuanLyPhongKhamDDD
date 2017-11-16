﻿--------------------------------------------CREATE DATABASE --------------------------------------------------
USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='quanlyphongkham_final')
DROP DATABASE quanlyphongkham_final
CREATE DATABASE quanlyphongkham_final
GO

USE quanlyphongkham_final
GO


--CTRL+SHIFT+U DE IN HOA, CTRL+SHIFT+L DE IN THUONG
GO

-------------------------------------------- CREATE TABLES --------------------------------------------------
--1.TẠO BẢNG TAIKHOAN
CREATE TABLE TAIKHOAN(
	MATK INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TENDANGNHAP VARCHAR(50) NOT NULL,
	MATKHAU VARCHAR(50) NOT NULL,
	TENHIENTHI NVARCHAR(50) NULL,
	MAPHANQUYEN INT DEFAULT 1, --TÀI KHOẢN THƯỜNG
	TRANGTHAI BIT DEFAULT 1,-- HOẠT ĐỘNG
)
GO


--2 TẠO BẢNG PHANQUYEN
CREATE TABLE PHANQUYEN(
	MAPHANQUYEN INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	QUYEN INT DEFAULT 1, --TÀI KHOẢN THƯỜNG
	GHICHU NVARCHAR(250) NULL,
)
GO

--3 TẠO BẢNG HINHTHUCKHAM

CREATE TABLE HINHTHUCKHAM(
	MAHINHTHUCKHAM int IDENTITY(1,1) NOT NULL,
	TENHINHTHUCKHAM nvarchar(100) NULL
	PRIMARY KEY (MAHINHTHUCKHAM)
) 
GO



--4 TẠO BẢNG PHIEUKHAM -- THÊM TRƯỜNG DATHANHTOAN BIT
CREATE TABLE PHIEUKHAM(
	MAPHIEUKHAM int IDENTITY(1,1) NOT NULL,
	MABN int NULL,
	MANV int NULL,
	CHUANDOAN nvarchar(250) NULL,
	MAHINHTHUCKHAM int NULL,
	NHIPTIM nvarchar(10)NULL,
	NHIETDO NVARCHAR (10)NULL,
	HUYETAP NVARCHAR(10)NULL,
	CANNANG INT NULL,
	CHIEUCAO INT NULL,
	MAICD INT NULL,
	NGAYKHAM date NULL DEFAULT GETDATE(),
	HOANTHANH bit NULl,
	DATHANHTOAN bit NULL,
	KETLUAN nvarchar(50) NULL,
	PRIMARY KEY (MAPHIEUKHAM)
)
GO

--5 TẠO BẢNG HOADON
CREATE TABLE HOADON(
	MAHOADON INT IDENTITY(1,1) NOT NULL,
	MAPHIEUKHAM INT NOT NULL,
	TONGCONG MONEY NULL
	PRIMARY KEY (MAHOADON)
)
GO

--6 TẠO BẢNG CHITIETDICHVUCLS
CREATE TABLE CHITIETCLS(
	MADICHVUCLS INT,
	MACLS INT,
	KETQUA VARCHAR(250),
	PRIMARY KEY (MADICHVUCLS,MACLS)
)
GO

--7 TẠO BẢNG DICHVUCLS
CREATE TABLE DICHVUCLS(
	MADICHVUCLS INT PRIMARY KEY IDENTITY(1,1),
	MAPHIEUKHAM INT, 
	TONGCONG MONEY
)
GO

--8 TẠO BẢNG CANLAMSANG
CREATE TABLE CANLAMSANG(
	MACLS INT PRIMARY KEY IDENTITY(1,1),
	TENCLS NVARCHAR(250),
	GIATIEN MONEY,
	MALOAICLS INT
)
GO

--9 TẠO BẢNG LOAICANLAMSANG
CREATE TABLE LOAICANLAMSANG(
	MALOAICLS INT PRIMARY KEY IDENTITY(1,1),
	TENLOAI NVARCHAR(250)
)
GO

--10 TẠO BẢNG KHOA
CREATE TABLE KHOA(
	MAKHOA INT PRIMARY KEY IDENTITY(1,1),
	TENKHOA NVARCHAR(100)
)
GO

--11 TẠO BẢNG NHANVIEN
CREATE TABLE NHANVIEN(
MANV INT IDENTITY(1,1) NOT NULL,
	HOTEN NVARCHAR(50) NULL,
	GIOITINH BIT NULL,
	SODT VARCHAR(20) NULL,
	EMAIL VARCHAR(50) NULL,
	MAKHOA INT NULL,
	MACHUCDANH INT NULL,
	MACHUCVU INT NULL,
	PRIMARY KEY (MANV)
)
GO

--12 TẠO BẢNG CHUCDANH
CREATE TABLE CHUCDANH(
MACHUCDANH INT IDENTITY(1,1) NOT NULL,
	TENCHUCDANH NVARCHAR(50) NULL,
	PRIMARY KEY (MACHUCDANH)
)
GO


--13 TẠO BẢNG BENHNHAN
CREATE TABLE BENHNHAN(
	MABN INT IDENTITY(1,1) NOT NULL,
	HOTEN NVARCHAR(50) NULL,
	GIOITINH BIT DEFAULT 1,--NAM
	NGAYSINH DATE NULL,
	DANTOC NVARCHAR(50) DEFAULT 'Kinh',
	SOCMND NVARCHAR(20) NULL,
	DIACHI NVARCHAR(250) NULL,
	SODT VARCHAR(20) NULL,
	TIENSU NVARCHAR(250) NULL,
	PRIMARY KEY (MABN)
)
GO

--14 TẠO BẢNG CHUCVU
CREATE TABLE CHUCVU(
	MACHUCVU INT IDENTITY(1,1) NOT NULL,
	TENCHUCVU NVARCHAR(50) NULL,
	PRIMARY KEY (MACHUCVU)
) 
GO




--15 TẠO BẢNG PHIEUNHAP
CREATE TABLE PHIEUNHAP(
	MAPHIEUNHAP INT IDENTITY(1,1) NOT NULL,
	MANV INT NULL,
	NGAYNHAP DATE NULL,
	PRIMARY KEY (MAPHIEUNHAP)
)
GO



--16 TẠO BẢNG DONTHUOC
CREATE TABLE DONTHUOC(
	MADONTHUOC INT IDENTITY(1,1)  PRIMARY KEY NOT NULL,
	MAPHIEUKHAM INT NOT NULL,
	TONGCONG MONEY
)
GO

--17 TẠO BẢNG CHITIETDONTHUOC
CREATE TABLE CHITIETDONTHUOC(
	MADONTHUOC INT not null,
	MATHUOC INT not null,
	SOLUONG INT,
	HUONGDAN TEXT,
	CONSTRAINT CTDT_MADONTHUOC_MATHUOC_PK PRIMARY KEY(MADONTHUOC, MATHUOC)
)
GO

--18 TẠO BẢNG CHITIETNHAPVATTU
CREATE TABLE CHITIETNHAPVATTU(
	MAPHIEUNHAP INT NOT NULL,
	MAVTYT INT NOT NULL,
	SOLUONG INT,
	MAHSX INT,
	NGAYSX DATE,
	NGAYHETHAN DATE,
	GIANHAP MONEY,
	MANHACC INT,
	PRIMARY KEY(MAPHIEUNHAP,MAVTYT)
)
GO

--19 TẠO BẢNG DONVITINH
CREATE TABLE DONVITINH(
MADVT INT IDENTITY PRIMARY KEY NOT NULL,
TENDVT NVARCHAR(50)
)
GO


--20 TẠO BẢNG VATTUYTE
CREATE TABLE VATTUYTE(
	MAVTYT INT PRIMARY KEY IDENTITY(1,1),
	TENVATTU NVARCHAR(250),
	MADVT INT, 
	SOLUONGTON INT
)
GO

--21 TẠO BẢNG THUOC
CREATE TABLE THUOC(
	MATHUOC INT IDENTITY(1,1)  PRIMARY KEY NOT NULL,
	TENTHUOC NVARCHAR(50) NOT NULL,
	DONVITINH INT ,
	LOAITHUOC INT ,
	SOLUONGTON INT ,
	GHICHU TEXT
)
GO

--22 TẠO BẢNG CHITIETNHAPTHUOC
CREATE TABLE CHITIETPHIEUNHAPTHUOC(
	MAPHIEUNHAP INT NOT NULL,
	MATHUOC INT NOT NULL,
	SOLUONG INT NULL,
	NGAYSX DATE NULL,
	NGAYHETHAN DATE NULL,
	GIANHAP MONEY NULL,
	GIABANLE MONEY NULL,
	MAHSX INT NULL,
	MANHACC INT  NULL,
	PRIMARY KEY (MAPHIEUNHAP,MATHUOC)
)
GO

--23 TẠO BẢNG LOAITHUOC
CREATE TABLE LOAITHUOC(
	MALOAITHUOC INT IDENTITY(1,1)  PRIMARY KEY NOT NULL,
	TENLOAI NVARCHAR(50)
)
GO



--24 TẠO BẢNG HANGSANXUAT
CREATE TABLE HANGSANXUAT(
	MAHSX INT PRIMARY KEY IDENTITY(1,1),
	TENHSX NVARCHAR(100),
	DIACHI NVARCHAR(250),
	MAQUOCGIA INT
)
GO


--25 TẠO BẢNG NHANCUNGCAP
CREATE TABLE NHACUNGCAP(
	MANHACC INT IDENTITY(1,1) NOT NULL,
	TENNHACC NVARCHAR(100) NULL,
	DIACHI NVARCHAR(100) NULL,
	SODT VARCHAR(20) NULL,
	EMAIL NVARCHAR(50) NULL,
	MAQUOCGIA INT NULL,
	PRIMARY KEY (MANHACC)
)
GO

--26 TẠO BẢNG QUOCGIA
CREATE TABLE QUOCGIA
(
	MAQUOCGIA INT IDENTITY(1,1) NOT NULL,
	TENQUOCGIA NVARCHAR(50)
	PRIMARY KEY (MAQUOCGIA)
)
GO











--------------------------------------------FOREIGN KEYS ------------------------------------------------------------------------------------------
--NOTE: FK CHO BẢNG NÀO THÌ GHI BẢNG ĐÓ
GO

--1. BẢNG TAIKHOAN
ALTER TABLE dbo.TAIKHOAN ADD CONSTRAINT FK_TAIKHOAN_PHANQUYEN FOREIGN KEY (MAPHANQUYEN)  REFERENCES dbo.PHANQUYEN(MAPHANQUYEN)
GO


--2. BẢNG HOADON

ALTER TABLE HOADON ADD CONSTRAINT FK_HOADON_PHIEUKHAM FOREIGN KEY (MAPHIEUKHAM) REFERENCES PHIEUKHAM(MAPHIEUKHAM)
GO



--3. PHIEUKHAM

ALTER TABLE PHIEUKHAM  ADD CONSTRAINT FK_PHIEUKHAM_HINHTHUCKHAM FOREIGN KEY(MAHINHTHUCKHAM) REFERENCES HINHTHUCKHAM(MAHINHTHUCKHAM)
GO

ALTER TABLE PHIEUKHAM  ADD CONSTRAINT FK_PHIEUKHAM_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
GO


ALTER TABLE PHIEUKHAM  ADD CONSTRAINT FK_PHIEUKHAM_BENHNHAN FOREIGN KEY(MABN) REFERENCES BENHNHAN(MABN)
GO

--4. KHOA
ALTER TABLE NHANVIEN ADD CONSTRAINT FK_NHANVIEN_KHOA FOREIGN KEY (MAKHOA) REFERENCES dbo.KHOA(MAKHOA)
GO

--5. CHITIETDONTHUOC
ALTER TABLE CHITIETDONTHUOC ADD CONSTRAINT CTDT_MADONTHUOC_FK FOREIGN KEY(MADONTHUOC) REFERENCES DONTHUOC(MADONTHUOC)

ALTER TABLE CHITIETDONTHUOC ADD CONSTRAINT CTDT_MATHUOC_FK FOREIGN KEY(MATHUOC) REFERENCES THUOC(MATHUOC)
GO

--6.THUOC
ALTER TABLE THUOC ADD CONSTRAINT THUOC_DONVITINH_FK FOREIGN KEY(DONVITINH) REFERENCES DONVITINH(MADVT)
ALTER TABLE THUOC ADD CONSTRAINT THUOC_LOAITHUOC_FK FOREIGN KEY(LOAITHUOC) REFERENCES LOAITHUOC(MALOAITHUOC)
GO

---7. DONTHUOC
ALTER TABLE DONTHUOC ADD CONSTRAINT DONTHUOC_MAPHIEUKHAM_FK FOREIGN KEY(MAPHIEUKHAM) REFERENCES PHIEUKHAM(MAPHIEUKHAM)
GO

--8. CHITIETPHIEUNHAPTHUOC
ALTER TABLE CHITIETPHIEUNHAPTHUOC
ADD CONSTRAINT FK_CHITIETPHIEUNHAPTHUOC_PHIEUNHAP
FOREIGN KEY  (MAPHIEUNHAP)
REFERENCES PHIEUNHAP(MAPHIEUNHAP)
 GO
 
ALTER TABLE CHITIETPHIEUNHAPTHUOC
ADD CONSTRAINT FK_CHITIETPHIEUNHAPTHUOC_THUOC
FOREIGN KEY  (MATHUOC)
REFERENCES THUOC(MATHUOC)
GO
 
ALTER TABLE CHITIETPHIEUNHAPTHUOC
ADD CONSTRAINT FK_CHITIETPHIEUNHAPTHUOC_HANGSANXUAT
FOREIGN KEY  (MAHSX)
REFERENCES HANGSANXUAT(MAHSX)
GO
 
ALTER TABLE CHITIETPHIEUNHAPTHUOC
ADD CONSTRAINT FK_CHITIETPHIEUNHAPTHUOC_NHACUNGCAP
FOREIGN KEY  (MANHACC)
REFERENCES NHACUNGCAP(MANHACC)
GO
 
 
--9. VATTUYTE
ALTER TABLE VATTUYTE
ADD CONSTRAINT FK_VATTUYTE_DONVITINH
FOREIGN KEY  (MADVT)
REFERENCES DONVITINH(MADVT)
GO
 
 
--10. CHITIETNHAPVATTU
ALTER TABLE CHITIETNHAPVATTU
ADD CONSTRAINT FK_CHITIETNHAPVATTU_PHIEUNHAP
FOREIGN KEY  (MAPHIEUNHAP)
REFERENCES PHIEUNHAP(MAPHIEUNHAP)
GO
 
ALTER TABLE CHITIETNHAPVATTU
ADD CONSTRAINT FK_CHITIETNHAPVATTU_NHACUNGCAP
FOREIGN KEY  (MANHACC)
REFERENCES NHACUNGCAP(MANHACC)
GO
 
ALTER TABLE CHITIETNHAPVATTU
ADD CONSTRAINT FK_CHITIETNHAPVATTU_HANGSANXUAT
FOREIGN KEY  (MAHSX)
REFERENCES HANGSANXUAT(MAHSX)
GO
 
ALTER TABLE CHITIETNHAPVATTU
ADD CONSTRAINT FK_CHITIETNHAPVATTU_VATTUYTE
FOREIGN KEY  (MAVTYT)
REFERENCES VATTUYTE(MAVTYT)
GO
 
--11. HANGSANXUAT

ALTER TABLE HANGSANXUAT
ADD CONSTRAINT FK_HANGSANXUAT_QUOCGIA
FOREIGN KEY  (MAQUOCGIA)
REFERENCES QUOCGIA(MAQUOCGIA)
GO
--12. NHANVIEN

ALTER TABLE NHANVIEN 
ADD CONSTRAINT FK_NHANVIEN_CHUCDANH 
FOREIGN KEY (MACHUCDANH)
REFERENCES CHUCDANH(MACHUCDANH)
ALTER TABLE NHANVIEN 
ADD CONSTRAINT FK_NHANVIEN_CHUCVU 
FOREIGN KEY (MACHUCVU)
REFERENCES CHUCVU(MACHUCVU)
GO
--13. PHIEUNHAP

ALTER TABLE PHIEUNHAP 
ADD CONSTRAINT FK_PHIEUNHAP_NHANVIEN 
FOREIGN KEY (MANV)
REFERENCES NHANVIEN(MANV)
GO

--14. NHACUNGCAP
ALTER TABLE dbo.NHACUNGCAP ADD CONSTRAINT FK_NHACUNGCAP_QUOCGIA FOREIGN KEY (MAQUOCGIA) REFERENCES dbo.QUOCGIA(MAQUOCGIA)
GO

--15. CANLAMSANG

ALTER TABLE dbo.CANLAMSANG ADD CONSTRAINT FK_CANLAMSANG_LOAICANLAMSANG FOREIGN KEY (MALOAICLS) REFERENCES dbo.LOAICANLAMSANG(MALOAICLS)
GO

--16. DICHVUCLS
ALTER TABLE dbo.DICHVUCLS ADD CONSTRAINT FK_DICHVUCLS_PHIEUKHAM FOREIGN KEY (MAPHIEUKHAM) REFERENCES dbo.PHIEUKHAM(MAPHIEUKHAM)
GO


--17. CHITIETCLS
ALTER TABLE dbo.CHITIETCLS ADD CONSTRAINT FK_CHITIETCLS_CANLAMSANG FOREIGN KEY (MACLS) REFERENCES dbo.CANLAMSANG(MACLS)
GO

ALTER TABLE dbo.CHITIETCLS ADD CONSTRAINT FK_CHITIETCLS_DICHVUCLS FOREIGN KEY (MADICHVUCLS) REFERENCES dbo.DICHVUCLS(MADICHVUCLS)
GO







