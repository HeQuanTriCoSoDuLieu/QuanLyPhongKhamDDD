﻿USE quanlyphongkham_final
GO




--2. BẢNG PHANQUYEN
--2.1 SP_INSERT_PHANQUYEN
CREATE PROC SP_INSERT_PHANQUYEN
	@QUYEN INT,
	@GHICHU NVARCHAR(250)
AS
BEGIN
	INSERT INTO dbo.PHANQUYEN
	        (  QUYEN, GHICHU )
	VALUES  ( @QUYEN, -- QUYEN - int
	          N''+@GHICHU  -- GHICHU - nvarchar(250)
	          )
END
GO


--3. Bảng NHANVIEN
--3.1 SP_INSERT_NHANVIEN
CREATE PROC SP_INSERT_NHANVIEN
@MANV INT,	
@HOTEN NVARCHAR(50),
@GIOITINH BIT,
@SODT VARCHAR(20),
@EMAIL VARCHAR(50),
@MAKHOA INT,
@MACHUCDANH INT,
@MACHUCVU INT
AS
BEGIN
	INSERT INTO NHANVIEN VALUES(@MANV,@HOTEN,@GIOITINH,@SODT,@EMAIL,@MAKHOA,@MACHUCDANH,@MACHUCVU)
END
GO
--3.2 SP_UPDATE_NHANVIEN
CREATE PROC SP_UPDATE_NHANVIEN
@MANV INT,
@HOTEN NVARCHAR(50),
@GIOITINH BIT,
@SODT VARCHAR(20),
@EMAIL VARCHAR(50),
@MAKHOA INT,
@MACHUCDANH INT,
@MACHUCVU INT
AS
BEGIN
	UPDATE NHANVIEN SET  
						HOTEN=@HOTEN,
						GIOITINH=@GIOITINH,
						SODT=@SODT,
						EMAIL=@EMAIL,
						MAKHOA=@MAKHOA,
						MACHUCDANH=@MACHUCDANH,
						MACHUCVU=@MACHUCVU
	WHERE MANV=@MANV
END
GO
--3.3 SP_TIMKIEM_NHANVIEN
	CREATE PROC SP_TIMKIEM_NHANVIEN
@MANV INT
AS
BEGIN
	SELECT *
	FROM NHANVIEN NV
	WHERE NV.MANV=@MANV
END
GO

--4. Bảng CHUCVU
--4.1 SP_INSERT_CHUCVU
	CREATE PROC SP_INSERT_CHUCVU
@MACHUCVU INT,
@TENCHUCVU NVARCHAR(50)
AS
BEGIN
	INSERT INTO CHUCVU VALUES(@MACHUCVU,@TENCHUCVU)
END
GO
--4.2 SP_UPDATE_CHUCVU
CREATE PROC SP_UPDATE_CHUCVU
@MACHUCVU INT,
@TENCHUCVU NVARCHAR(50)
AS
BEGIN
	UPDATE CHUCVU SET
					  TENCHUCVU=@TENCHUCVU
	WHERE MACHUCVU=@MACHUCVU
END
GO
--4.3 SP_TIMKIEM_CHUCVU
CREATE PROC SP_TIMKIEM_CHUCVU
@MACHUCVU INT
AS
BEGIN
	SELECT *
	FROM CHUCVU CV
	WHERE CV.MACHUCVU=@MACHUCVU
END
GO
--5 Bảng CHUCDANH
--5.1 SP_INSERT_CHUCDANH
CREATE PROC SP_INSERT_CHUCDANH
@MACHUCDANH INT,
@TENCHUCDANH NVARCHAR(50)
AS
BEGIN
	INSERT INTO CHUCDANH VALUES(@MACHUCDANH,@TENCHUCDANH)
END
GO
--5.2 SP_UPDATE_CHUCDANH
CREATE PROC SP_UPDATE_CHUCDANH
@MACHUCDANH INT,
@TENCHUCDANH NVARCHAR(50)
AS
BEGIN
	UPDATE CHUCDANH SET
						TENCHUCDANH=@TENCHUCDANH
	WHERE MACHUCDANH=@MACHUCDANH
END
GO
--5.3 SP_TIMKIEM_CHUCDANH
CREATE PROC SP_TIMKIEM_CHUCDANH
 @MACHUCDANH INT
AS
BEGIN
	SELECT *
	FROM CHUCDANH CD
	WHERE CD.MACHUCDANH=@MACHUCDANH
END
GO
--6. Bảng NHAPPHIEU
--6.1 SP_INSERT_PHIEUNHAP
CREATE PROC SP_INSERT_PHIEUNHAP
 @MAPHIEUNHAP INT,
 @MAMV INT,
 @NGAYNHAP DATE
 AS
 BEGIN
	INSERT INTO PHIEUNHAP VALUES(@MAPHIEUNHAP,@MAMV,@NGAYNHAP)
 END
 GO
--6.2 SP_UPDATE_PHIEUNHAP
CREATE PROC SP_UPDATE_PHIEUNHAP
 @MAPHIEUNHAP INT,
 @MAMV INT,
 @NGAYNHAP DATE
 AS
 BEGIN
	UPDATE PHIEUNHAP SET
						 MANV=@MAMV,
						 NGAYNHAP=@NGAYNHAP
WHERE MAPHIEUNHAP=@MAPHIEUNHAP 
END
 GO
--6.3 SP_TIMKIEM_PHIEUNHAP
CREATE PROC SP_TIMKIEM_PHIEUNHAP
@MAPHIEUNHAP INT
AS
BEGIN
	SELECT *
	FROM PHIEUNHAP PN
	WHERE PN.MAPHIEUNHAP=@MAPHIEUNHAP
END
GO

--7. Bảng NHACUNGCAP
--7.1 SP_INSERT_NHACUNGCAP
CREATE PROC SP_INSERT_NHACUNGCAP
 @MANHACC INT,
 @TENNHACC NVARCHAR(100),
 @DIACHI NVARCHAR(100),
 @SODT VARCHAR(20),
 @EMAIL NVARCHAR(50),
 @MAQUOCGIA INT
 AS
 BEGIN
	INSERT INTO NHACUNGCAP VALUES(@MANHACC,@TENNHACC,@DIACHI,@SODT,@EMAIL,@MAQUOCGIA)
 END
 GO
--7.2 SP_UPDATE_NHACUNGCAP
CREATE PROC SP_UPDATE_NHACUNGCAP
 @MANHACC INT,
 @TENNHACC NVARCHAR(100),
 @DIACHI NVARCHAR(100),
 @SODT VARCHAR(20),
 @EMAIL NVARCHAR(50),
 @MAQUOCGIA INT
 AS
 BEGIN
UPDATE NHACUNGCAP SET		TENNHACC=@TENNHACC,
						  DIACHI=@DIACHI,
						  SODT=@SODT,
						  EMAIL=@EMAIL,
						  MAQUOCGIA=@MAQUOCGIA
WHERE MANHACC = @MANHACC
 END
 GO
--7.3 SP_TIMKIEM_NHACUNGCAP
CREATE PROC SP_TIMKIEM_NHACUNGCAP
@MANHACC INT
AS
BEGIN
	SELECT *
	FROM NHACUNGCAP NCC
	WHERE NCC.MANHACC=@MANHACC
END
GO

--BẢNG PHIEUKHAM
--8.1 SP_INSERT PHIEU KHAM

CREATE PROC SP_Insert_Phieukham
@MABN INT,
@NHANVIEN INT,
@CHUANDOAN NVARCHAR(250),
@MAHINHTHUCKHAM INT,
@NGAYKHAM DATE,
@KETLUAN NVARCHAR(50),
@HOANTHANH BIT
AS
BEGIN 
INSERT INTO PHIEUKHAM VALUES (@MABN,
@NHANVIEN,
@CHUANDOAN,
@MAHINHTHUCKHAM,
@NGAYKHAM,
@KETLUAN,
@HOANTHANH
)
END
GO

--8.2 SP  UPDATE PHIEUKHAM

CREATE PROC SP_Update_Phieukham
@MAPHIEUKHAM INT,
@MABN INT,
@NHANVIEN INT,
@CHUANDOAN NVARCHAR(250),
@MAHINHTHUCKHAM INT,
@NGAYKHAM DATE,
@KETLUAN NVARCHAR(50),
@HOANTHANH BIT
AS
BEGIN 
UPDATE PHIEUKHAM SET 
MABN = @MABN,
NHANVIEN = @NHANVIEN,
CHUANDOAN = @CHUANDOAN,
MAHINHTHUCKHAM = @MAHINHTHUCKHAM,
NGAYKHAM = @NGAYKHAM,
KETLUAN = @KETLUAN,
HOANTHANH = @HOANTHANH
WHERE MAPHIEUKHAM = @MAPHIEUKHAM
END

GO

--8.3 SP SELECT ALL PHIEUKHAM

CREATE PROC SP_Select_Phieukham
AS
BEGIN 
SELECT * FROM PHIEUKHAM
END
GO

CREATE PROC SP_Select_Danhsachkham
AS
BEGIN 
SELECT * FROM DANHSACHKHAM
END
GO

--8.4 SP SEARCH PHIEUKHAM BẰNG ID


CREATE PROC SP_Search_Phieukham
@MAPHIEU INT
AS
BEGIN 
SELECT * FROM PHIEUKHAM WHERE MAPHIEUKHAM = @MAPHIEU 
END
GO


--BẢNG BENHNHAN

--9.1 SP INSERT BENHNHAN

CREATE PROC SP_Insert_Benhnhan 
@HOTEN nvarchar(50),@GIOITINH BIT,@NGAYSINH DATE,@SOCMND NCHAR(10),@DIACHI NVARCHAR(250),@SODT VARCHAR(20)
AS 
BEGIN 
INSERT INTO BENHNHAN VALUES (@HOTEN,@GIOITINH,@NGAYSINH,@SOCMND,@DIACHI,@SODT)
END
GO

--9.2 SP UPDATE  BENHNHAN


CREATE PROC SP_Update_Benhnhan
@MABN  INT,
@HOTEN nvarchar(50),
@GIOITINH BIT,
@NGAYSINH DATE,
@SOCMND NCHAR(10),
@DIACHI NVARCHAR(250),
@SODT VARCHAR(20)
AS 
BEGIN 
UPDATE BENHNHAN SET HOTEN = @HOTEN, GIOITINH = @GIOITINH, NGAYSINH = @NGAYSINH, SOCMND = @SOCMND, DIACHI = @DIACHI, SODT = @SODT
WHERE MABN = @MABN
END
GO

--9.3 SP SELECT ALL BENHNHAN

CREATE PROC SP_Select_Benhnhan
AS
BEGIN 
SELECT * FROM BENHNHAN 
END
GO


--9.4 SP SEARCH  BENHNHAN  BANG ID


CREATE PROC SP_Search_Benhnhan
@HOTEN NVARCHAR(50)
AS
BEGIN
SELECT * FROM BENHNHAN BN WHERE BN.HOTEN = @HOTEN  
END
GO


--BẢNG HINHTHUCKHAM
--10.1 SP INSERT HINHTHUCKHAM

CREATE PROC SP_Insert_Hinhthuckham
@TENHINHTHUCKHAM NVARCHAR(100)
AS 
BEGIN
INSERT INTO HINHTHUCKHAM VALUES (@TENHINHTHUCKHAM)
END

GO


--10.2 SP UPDATE HINHTHUCKHAM

CREATE PROC SP_Update_Hinhthuckham
@MAHINHTHUCKHAM INT,
@TENHINHTHUCKHAM NVARCHAR(100)
AS 
BEGIN
UPDATE HINHTHUCKHAM SET TENHINHTHUCKHAM = @TENHINHTHUCKHAM 
WHERE MAHINHTHUCKHAM = @MAHINHTHICKHAM
END
GO

--10.3 SP SELECT ALL HINHTHUCKHAM


CREATE PROC SP_Select_Hinhthuckham
AS
BEGIN 
SELECT * FROM HINHTHUCKHAM
END
GO

--10.4 SP SEARCH HINHTHUCKHAM QUA ID

CREATE PROC SP_Search_Hinhthuckham
@MAHINHTHUCKHAM INT
AS
BEGIN 
SELECT * FROM HINHTHUCKHAM WHERE MAHINHTHUCKHAM = @MAHINHTHUCKHAM 
END
GO

--BẢNG HOADON

--11.1 SP INSERT  HOADON

CREATE PROC SP_Insert_Hoadon
@MAPHIEUKHAM int,
@TONGCONG money
AS 
BEGIN 
INSERT INTO HOADON VALUES (@MAPHIEUKHAM,
@TONGCONG )
END

GO


--11.2 SP UPDATE HOADON


CREATE PROC SP_Update_Hoadon
@MAHOADON INT,
@MAPHIEUKHAM int,
@TONGCONG money
AS 
BEGIN 
UPDATE HOADON SET MAPHIEUKHAM = @MAPHIEUKHAM,TONGCONG = @TONGCONG 
WHERE MAHOADON = @MAHOADON
END
GO


--11.3 SP SELECT ALL HOADON


CREATE PROC SP_Select_Hoadon
AS
BEGIN 
SELECT * FROM HOADON
END
GO

--11.4 SEARCH HOADON

CREATE PROC SP_Search_Hoadon
@MAHD INT
AS
BEGIN 
SELECT * FROM HOADON WHERE MAHOADON = @MAHD 
END
GO

--BẢNG DANHSACHKHAM
--12.1 SP INSERT DANHSACHKHAM

CREATE PROC SP_Insert_Danhsachkham
@MAPHIEUKHAM int,
@NGAYKHAM date,
@HOANTHANH bit
AS 
BEGIN
INSERT INTO DANHSACHKHAM VALUES (@MAPHIEUKHAM,
@NGAYKHAM,
@HOANTHANH)
END

GO


--12.2 SP UPDATE DANHSACHKHAM


CREATE PROC SP_Update_Danhsachkham
@MADSK INT,
@MAPHIEUKHAM int,
@NGAYKHAM date,
@HOANTHANH bit
AS 
BEGIN
UPDATE DANHSACHKHAM SET MAPHIEUKHAM=@MAPHIEUKHAM,
NGAYKHAM=@NGAYKHAM,
HOANTHANH=@HOANTHANH
WHERE MADSK = @MADSK
END

GO

--12.3 SP SELECT ALL DANHSACHKHAM

CREATE PROC SP_Select_Danhsachkham
AS
BEGIN 
SELECT * FROM DANHSACHKHAM
END
GO

--12.4 SP SEARCH DANHSACHKHAM


CREATE PROC SP_Search_Danhsachkham
@MADSK INT
AS
BEGIN 
SELECT * FROM DANHSACHKHAM WHERE MADSK = @MADSK 
END
GO

--- BẢNG DONTHUOC

-- 13.1 SP_InsertDonThuoc

create PROC SP_InsertDonThuoc
	@Maphieukham INT
AS
	DECLARE @TONGCONG money
	DECLARE @MATHUOC INT
	SET @MATHUOC = (SELECT MATHUOC FROM CHITIETDONTHUOC, DONTHUOC WHERE DONTHUOC.MAPHIEUKHAM = @Maphieukham )
	DECLARE @GIABANLE INT
	SET @GIABANLE =  (SELECT GIABANLE FROM CHITIETPHIEUNHAPTHUOC, THUOC WHERE THUOC.MATHUOC = CHITIETPHIEUNHAPTHUOC.MATHUOC AND THUOC.MATHUOC = @MATHUOC)
	IF (EXISTS (SELECT * FROM PHIEUKHAM WHERE MAPHIEUKHAM = @Maphieukham))	-- ma phieu kham ton tại
	BEGIN
		INSERT INTO DONTHUOC(MAPHIEUKHAM, TONGCONG) VALUES (@Maphieukham, @Tongcong)
	END

GO

exec SP_InsertDonThuoc 10
select * from DONTHUOC where DONTHUOC.MAPHIEUKHAM = 10

--- 13.2 SP_UpdateDonThuoc

create PROC SP_UpdateDonThuoc
	@MaDT int,
	@Maphieukham INT
AS
	DECLARE @TONGCONG money 
	DECLARE @MATHUOC INT
	SET @MATHUOC = (SELECT MATHUOC FROM CHITIETDONTHUOC WHERE CHITIETDONTHUOC.MADONTHUOC = @MaDT )
	DECLARE @GIABANLE INT
	SET @GIABANLE =  (SELECT GIABANLE FROM CHITIETPHIEUNHAPTHUOC, THUOC WHERE THUOC.MATHUOC = CHITIETPHIEUNHAPTHUOC.MATHUOC AND THUOC.MATHUOC = @MATHUOC)
	IF (EXISTS (SELECT * FROM DONTHUOC WHERE MADONTHUOC = @MaDT))	-- ma phieu kham ton tại
	BEGIN
		UPDATE DONTHUOC SET MAPHIEUKHAM = @Maphieukham, TONGCONG = @Tongcong WHERE MADONTHUOC = @MaDT
	END

GO

exec SP_UpdateDonThuoc 11, 9
select * from DONTHUOC where DONTHUOC.MADONTHUOC = 11

--- BẢNG CHITIETHOADON

--- 14.1 SP_InsertCTDT

create PROC SP_InsertCTDT
	@madthuoc int,
	@mathuoc int,
	@soluong int,
	@huongdan text
AS 
	IF EXISTS (SELECT * FROM DONTHUOC WHERE MADONTHUOC = @madthuoc)
	BEGIN
		if EXISTS (SELECT * FROM THUOC WHERE MATHUOC = @mathuoc)
		BEGIN
		INSERT INTO CHITIETDONTHUOC(MADONTHUOC, MATHUOC, SOLUONG, HUONGDAN) VALUES (@madthuoc, @mathuoc, @soluong, @huongdan)
		END
	END
GO

exec SP_InsertCTDT 10, 5, 10, N'Sáng tối'
select * from CHITIETDONTHUOC

--- 14.2 SP_UpdateCTDT

create PROC SP_UpdateCTDT
	@madthuoc int,
	@mathuoc int,
	@soluong int,
	@huongdan text
AS 
	IF EXISTS (SELECT * FROM CHITIETDONTHUOC WHERE MADONTHUOC = @madthuoc)
	BEGIN
		UPDATE CHITIETDONTHUOC SET MATHUOC = @mathuoc, SOLUONG = @soluong, HUONGDAN = @huongdan
		WHERE MADONTHUOC = @madthuoc
	END

GO

exec SP_UpdateCTDT 10, 6, 20, N'sáng tối'
select * from CHITIETDONTHUOC

--- BẢNG THUOC
--- 15.1 SP_InsertThuoc

CREATE PROC SP_InsertThuoc
	@tenthuoc nvarchar(50),
	@donvitinh int,
	@loaithuoc int,
	@soluongton int,
	@ghichu text
AS
	BEGIN 
		INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) 
		VALUES (@tenthuoc, @donvitinh, @loaithuoc, @soluongton, @ghichu)
	END

GO
exec SP_InsertThuoc N'auta',2,3,300,N'abc'
select * from THUOC

--- 15.2 SP_UpdateThuoc

CREATE PROC SP_UpdateThuoc
	@mathuoc int,
	@tenthuoc nvarchar(50),
	@donvitinh int,
	@loaithuoc int,
	@soluongton int,
	@ghichu text
AS
	BEGIN 
		UPDATE THUOC SET TENTHUOC = @tenthuoc, DONVITINH = @donvitinh, LOAITHUOC = @loaithuoc, SOLUONGTON = @soluongton, GHICHU = @ghichu
		WHERE MATHUOC = @mathuoc
	END

GO	

exec SP_UpdateThuoc 11, N'abc', 2,1,500, N'xyz'
select * from THUOC

--- BẢNG LOAITHUOC
--- 16.1 SP_InsertLoaiThuoc

CREATE PROC SP_InsertLoaiThuoc
	@tenloaithuoc nvarchar(50)
AS
	IF NOT EXISTS (SELECT * FROM LOAITHUOC WHERE TENLOAI = @tenloaithuoc)
	BEGIN 
		INSERT INTO LOAITHUOC(TENLOAI) VALUES (@tenloaithuoc)
	END

GO

--- 16.2 SP_UpdateLoaiThuoc

CREATE PROC SP_UpdateLoaiThuoc
	@maloaithuoc int,
	@tenloaithuoc nvarchar(50)
AS
	IF NOT EXISTS (SELECT * FROM LOAITHUOC WHERE MALOAITHUOC = @maloaithuoc)
	BEGIN
		UPDATE LOAITHUOC SET TENLOAI = @tenloaithuoc
		WHERE MALOAITHUOC = @maloaithuoc
	END

GO

exec SP_InsertLoaiThuoc 

--- BẢNG DONVITINH
--- 17.1 SP_InsertDVT

CREATE PROC SP_InsertDVT
	@tendvt nvarchar(50)
AS
	IF NOT EXISTS (SELECT * FROM DONVITINH WHERE TENDVT = @tendvt)
	BEGIN 
		INSERT INTO DONVITINH(TENDVT) VALUES (@tendvt)
	END

GO


--- 17.2  SP_UpdateDVT

CREATE PROC SP_UpdateDVT
	@madvt int,
	@tendvt nvarchar(50)
AS
	IF NOT EXISTS (SELECT * FROM DONVITINH WHERE MADVT = @madvt)
	BEGIN
		UPDATE DONVITINH SET TENDVT = @tendvt
		WHERE MADVT = @madvt
	END

GO






--- BẢNG PHIEUNHAP
--- 18.1 SP_InsertCHITIETPHIEUNHAPTHUOC
Create Procedure SP_InsertCHITIETPHIEUNHAPTHUOC
@SoLuong int,
@NgaySX date,
@NgayHH date,
@GiaNhap money,
@GiaBanLe money,
@MaHSX int,
@MaNCC int
as
begin
insert into CHITIETPHIEUNHAPTHUOC(SOLUONG, NGAYSX, NGAYHETHAN, GIANHAP, GIABANLE, MAHSX, MANHACC)
VALUES (@SoLuong, @NgaySX, @NgayHH, @GiaNhap, @GiaBanLe,@MaHSX, @MaNCC)
end
 
 SP_UpdateCHITIETPHIEUNHAPTHUOC
Create Procedure SP_UpdateCHITIETPHIEUNHAPTHUOC
@MAPHIEUNHAP int,
@MATHUOC int,
@SoLuong int,
@NgaySX date,
@NgayHH date,
@GiaNhap money,
@GiaBanLe money,
@MaHSX int,
@MaNCC int
as
begin
update CHITIETPHIEUNHAPTHUOC
set      	SOLUONG = @SoLuong , NGAYSX = @NgaySX , NGAYHETHAN = @NgayHH, GIANHAP = @GiaNhap , GIABANLE = @GiaBanLe, MAHSX = @MaHSX, MANHACC = @MaNCC
where MAPHIEUNHAP = @MAPHIEUNHAP and MATHUOC = @MATHUOC
end
 
 SP_SelectAllCHITIETPHIEUNHAPTHUOC
Create Procedure SP_SelectAllCHITIETPHIEUNHAPTHUOC
as
begin
Select * From CHITIETPHIEUNHAPTHUOC
end
 
SP_SearchCHITIETPHIEUNHAPTHUOC
Create Procedure SP_SearchCHITIETPHIEUNHAPTHUOC
@MAPHIEUNHAP int
as
begin
Select * From CHITIETPHIEUNHAPTHUOC where MAPHIEUNHAP = @MAPHIEUNHAP
end

 
 
--- BẢNG CHITIETNHAPVATTU
--- 19.1 SP_InsertCHITIETNHAPVATTU
Create Procedure SP_InsertCHITIETNHAPVATTU
 
@SoLuong int,
@MaNHSX int,
@NgaySX date,
@NgayHH date,
@GiaNhap money,
@GiaBanLe money,
@MaNCC int
as
begin
insert into CHITIETNHAPVATTU (SOLUONG, MANHSX, NGAYSX, NGAYHETHAN, GIANHAP, GIABANLE, MANHACC)
VALUES (@SoLuong, @MaNHSX, @NgaySX, @NgayHH, @GiaNhap, @GiaBanLe, @MaNCC)
end
 
 --- 19.2  SP_UpdateCHITIETNHAPVATTU
Create Procedure SP_UpdateCHITIETNHAPVATTU
@MaPhieuNhap int,
@MaVTYT int,
@SoLuong int,
@MaNHSX int,
@NgaySX date,
@NgayHH date,
@GiaNhap money,
@GiaBanLe money,
@MaNCC int
as
begin
update CHITIETNHAPVATTU
set SOLUONG = @SoLuong ,
MANHSX = @MaNHSX,
NGAYSX = @NgaySX ,
NGAYHETHAN =  @NgayHH,
GIANHAP = @GiaNhap ,
GIABANLE = @GiaBanLe ,
MANHACC = @MaNCC
where MAPHIEUNHAP = @MaPhieuNhap and MAVTYT = @MaVTYT
end
 
 --- 19.3  SP_SelectAllCHITIETNHAPVATTU
Create Procedure SP_SelectAllCHITIETNHAPVATTU
as
begin
Select * From CHITIETNHAPVATTU
end
 

---19.4 SP_SearchCHITIETNHAPVATTU
Create Procedure SP_SearchCHITIETNHAPVATTU
@MaPhieuNhap int
as
begin
Select * From CHITIETNHAPVATTU where MAPHIEUNHAP = @MaPhieuNhap
end
 
 
 
 
 
--- BẢNG VATTUYTE
--20.1 SP_InsertVATTUYTE
Create Procedure SP_InsertVATTUYTE
@MaVTYT int,
@TenVT nvarchar(100),
@MaDVT int,
@SoLuongTon int
as
begin
insert into VATTUYTE ( TENVATTU, MADVT, SOLUONGTON)
values (@TenVT, @MaDVT, @SoLuongTon)
END
 
 --- 20.2 SP_UpdateVATTUYTE
Create Procedure SP_UpdateVATTUYTE
@MaVTYT int,
@TenVT nvarchar(100),
@MaDVT int,
@SoLuongTon int
as
begin
update VATTUYTE
set TENVATTU = @TenVT, MADVT = @TenVT, SOLUONGTON = @SoLuongTon
where MAVTYT = @MaVTYT
end
 
 --- 20.3  SP_SelectAllVATTUYTE
Create Procedure SP_SelectAllVATTUYTE
as
begin
select * From VATTUYTE
end
 
 --- 20.4  SP_SearchVATTUYTE
Create Procedure SP_SearchVATTUYTE
@MaVTYT int
as
begin
select * From VATTUYTE where MAVTYT = @MaVTYT
end
 
 
 
--- BẢNG HANGSANXUAT
--- 21.1 SP_InsertHANGSANXUAT

Create Procedure SP_InsertHANGSANXUAT
@TenNHSX nvarchar(100),
@DiaChi nvarchar(100),
@MaQuocGia int
as
begin
insert into HANGSANXUAT ( TENHSX, DIACHI, MAQUOCGIA)
VALUES (@TenNHSX, @DiaChi, @MaQuocGia)
end
 
 ---21.2 SP_UpdateHANGSANXUAT

Create Procedure SP_UpdateHANGSANXUAT
@MaHSX int,
@TenNHSX nvarchar(100),
@DiaChi nvarchar(100),
@MaQuocGia int
as
begin
update HANGSANXUAT
set MAHSX = @MaHSX, TENHSX = @TenNHSX, DIACHI = @DiaChi, MAQUOCGIA = @MaQuocGia
where MAHSX = @MaHSX
end
 
--- 21.3 SP_SelectAllHANGSANXUAT
Create Procedure SP_SelectAllHANGSANXUAT
as
begin
Select * From HANGSANXUAT
end
 
 --- 21.4  SP_SearchHANGSANXUAT
Create Procedure SP_SearchHANGSANXUAT
@MaHSX int
as
begin
Select * From HANGSANXUAT where MAHSX = @MaHSX
end 
 
 
 
 
--- BẢNG QUOCGIA
--- 22.1 SP_InsertQUOCGIA
Create Procedure SP_InsertQUOCGIA
@TenQuocGia nvarchar(50)
as
begin
insert into QUOCGIA (TENQUOCGIA)
values (@TenQuocGia)
end
 
 --- 22.2 SP_UpdateQUOCGIA
Create Procedure SP_UpdateQUOCGIA
@MaQuocGia int,
@TenQuocGia nvarchar(50)
as
begin
update QUOCGIA
set TENQUOCGIA = @TenQuocGia
where MAQUOCGIA = @MaQuocGia
end
 
 --- 22.3 SP_SelectAllQUOCGIA
Create Procedure SP_SelectAllQUOCGIA
as
begin
Select * From QUOCGIA
end
 
 
 --- 22.4 SP_SearchQUOCGIA
Create Procedure SP_SearchQUOCGIA
@MaQuocGia int
as
begin
Select * From QUOCGIA
where MAQUOCGIA = @MaQuocGia
end


GO
--------------------------------------------TRIGGER -----------------------------------------------------------------------------------------------
-- NOTE: TRIGGER CHO BẢNG NÀO THÌ GHI BẢNG ĐÓ, NHỚ GHI THỨ TỰ VÀ GHI TÊN 
GO


--------------------------------------------INSERT DATA -------------------------------------------------------------------------------------------

--NOTE: INSERT CHO BẢNG NÀO THÌ GHI BẢNG ĐÓ, NHỚ GHI THỨ TỰ VÀ GHI TÊN 

--1. BẢNG PHANQUYEN
EXEC dbo.SP_INSERT_PHANQUYEN @QUYEN = 0, -- int
    @GHICHU = N'Quyền admin' -- nvarchar(250)
GO 



--2. BẢNG TAIKHOAN
EXEC dbo.SP_INSERT_TAIKHOAN @TENDANGNHAP = 'admin', -- varchar(50)
    @MATKHAU = 'admin', -- varchar(50)
    @TENHIENTHI = N'Admin', -- nvarchar(50)
    @MAPHANQUYEN = 1, -- int
    @TRANGTHAI = 1 -- bit
GO

-- 3. BẢNG LOAITHUOC
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC NÃO')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC GIẢM ĐAU, HẠ SỐT, CHỐNG VIÊM')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC CHỐNG DỊ ỨNG')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC GIẢI ĐỘC')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC ĐIỀU TRỊ KÝ SINH TRÙNG, CHỐNG NHIỄM KHUẨN')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC KHÁNG SINH')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC TIM MẠCH')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC XƯƠNG KHỚP')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC TẨY TRÙNG VÀ SÁT KHUẨN')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'THUỐC ĐƯỜNG TIÊU HÓA')
INSERT INTO LOAITHUOC(TENLOAI) VALUES (N'KHOÁNG CHẤT VÀ VITAMIN')

--- 4. BẢNG DONVITINH
INSERT INTO DONVITNH(TENDVT) VALUES (N'Hộp')
INSERT INTO DONVITNH(TENDVT) VALUES (N'Viên')
INSERT INTO DONVITNH(TENDVT) VALUES (N'Vỉ')
INSERT INTO DONVITNH(TENDVT) VALUES (N'Nước')
INSERT INTO DONVITNH(TENDVT) VALUES (N'Miếng dán')

--- 5. BẢNG THUOC
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Nimesulid',1,2,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Meloxicam',1,2,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Cetirizin',1,3,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Cinnarizin',1,3,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Clorphenamin',1,3,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Epinephrin (adrenalin)',1,3,500,N'Tiêm')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Fexofenadin HCL',1,3,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Atropin (sulfat)',1,4,500,N'Tiêm')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Than hoạt',1,4,500,N'Uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Albendazol',1,5,500,N'Trị sán, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Mebendazol',1,5,500,N'trị giun, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Amoxicilin',1,5,500,N'nhóm beta-lactam, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Cefadroxil',1,5,500,N'nhóm beta-lactam, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Ceftriaxon',1,5,500,N'nhóm beta-lactam, tiêm')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Gentamicin',1,5,500,N'nhóm aminoglycosid, Tiêm; Thuốc tra mắt')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Folic acid (Vitamin B9)',1,11,500,N'chống thiếu máu, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Glyceryl trinitrat (Nitroglycerin)',1,8,500,N'chống đau thắt ngực, uống, ngậm dưới lưỡi')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Trimetazidin',1,8,500,N'chống đau thắt ngực, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Amlodipin',1,7,500,N'điều trị tăng huyết áp, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Captopril',1,7,500,N'điều trị tăng huyết áp, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Sorbitol',1,10,500,N'tẩy,nhuận tràng, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Duphalac',1,10,500,N'tẩy,nhuận tràng, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Berberin (hydroclorid)',1,10,500,N'điều trị tiêu chảy, uống')
INSERT INTO THUOC(TENTHUOC, DONVITINH, LOAITHUOC, SOLUONGTON, GHICHU) VALUES (N'Diosmectit',1,10,500,N'điều trị tiêu chảy, uống')

--- 6. BẢNG CHITIETDONTHUOC
INSERT INTO CHITIETDONTHUOC(MADONTHUOC, MATHUOC, SOLUONG, HUONGDAN) VALUES (1,1,60,N'UỐNG 2 LẦN SÁNG TỐI')
INSERT INTO CHITIETDONTHUOC(MADONTHUOC, MATHUOC, SOLUONG, HUONGDAN) VALUES (1,3,60,N'UỐNG 2 LẦN SÁNG TỐI')
INSERT INTO CHITIETDONTHUOC(MADONTHUOC, MATHUOC, SOLUONG, HUONGDAN) VALUES (1,5,60,N'UỐNG 2 LẦN SÁNG TỐI')
INSERT INTO CHITIETDONTHUOC(MADONTHUOC, MATHUOC, SOLUONG, HUONGDAN) VALUES (1,6,60,N'UỐNG 2 LẦN SÁNG TỐI')
INSERT INTO CHITIETDONTHUOC(MADONTHUOC, MATHUOC, SOLUONG, HUONGDAN) VALUES (1,18,60,N'UỐNG 2 LẦN SÁNG TỐI')

 





 
 


