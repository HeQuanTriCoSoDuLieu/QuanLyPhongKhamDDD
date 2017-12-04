USE [quanlyphongkham_final]
GO
/****** Object:  StoredProcedure [dbo].[SP_DanhSachChiTietDonThuoc]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc [dbo].[SP_DanhSachChiTietDonThuoc] 
go
create proc [dbo].[SP_DanhSachChiTietDonThuoc] 
@MAPHIEU INT 
AS 
BEGIN
SELECT CTDT.MADONTHUOC, TENTHUOC, SOLUONG, HUONGDAN
FROM CHITIETDONTHUOC CTDT, THUOC T, DONTHUOC DT
WHERE CTDT.MATHUOC = T.MATHUOC AND DT.MADONTHUOC = CTDT.MADONTHUOC AND DT.MAPHIEUKHAM = @MAPHIEU

end
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_ChiTietDonThuoc]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc  [dbo].[SP_Insert_ChiTietDonThuoc] 
go
CREATE proc [dbo].[SP_Insert_ChiTietDonThuoc] 
@MAPHIEUKHAM INT,
@MATHUOC INT,
@SOLUONG INT,
@HUONGDAN TEXT
as
begin
declare @MADONTHUOC INT
SELECT @MADONTHUOC = MADONTHUOC from DONTHUOC DT where DT.MAPHIEUKHAM = @MAPHIEUKHAM
if exists(select * from CHITIETDONTHUOC where MADONTHUOC = @MADONTHUOC and MATHUOC = @MATHUOC)
begin
update CHITIETDONTHUOC set SOLUONG =@SOLUONG , HUONGDAN = @HUONGDAN WHERE MADONTHUOC = @MADONTHUOC AND MATHUOC = @MATHUOC
end
else 
begin
	INSERT INTO CHITIETDONTHUOC VALUES(@MADONTHUOC,@MATHUOC,@SOLUONG,@HUONGDAN)
end
end

GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_DonThuoc]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc [dbo].[SP_Insert_DonThuoc]
go
CREATE PROC [dbo].[SP_Insert_DonThuoc]
@MAPHIEUKHAM int
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM DONTHUOC WHERE MAPHIEUKHAM = @MAPHIEUKHAM) 
	BEGIN
		INSERT INTO DONTHUOC(MAPHIEUKHAM) VALUES(@MAPHIEUKHAM)
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_LichSuKham]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

drop proc  [dbo].[SP_LichSuKham] 
go
create proc [dbo].[SP_LichSuKham] 
@MABN int
as
begin

select pk.MAPHIEUKHAM, pk.NGAYKHAM, pk.CHUANDOAN, pk.KETLUAN
from PHIEUKHAM PK, BENHNHAN BN
where pk.MABN = bn.MABN and pk.MABN = @MABN

end
GO
/****** Object:  StoredProcedure [dbo].[SP_LichSuKhamNhanVien]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc  [dbo].[SP_LichSuKhamNhanVien] 
go
CREATE proc [dbo].[SP_LichSuKhamNhanVien] 
@MaNhanVien int
as
begin
select BN.MABN, PK.MAPHIEUKHAM, BN.HOTEN, PK.NGAYKHAM,PK.DATHANHTOAN from (BENHNHAN BN inner join PHIEUKHAM PK on BN.MABN = PK.MABN) where PK.MANV = @MaNhanVien
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Phieukham_By_Id]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc  [dbo].[SP_Search_Phieukham_By_Id]
go
CREATE PROC [dbo].[SP_Search_Phieukham_By_Id]
@ID INT
AS
BEGIN 
SELECT PK.MAPHIEUKHAM,PK.MABN, PK.MANV, PK.CHUANDOAN, PK.MAHINHTHUCKHAM, PK.NHIPTIM, PK.NHIETDO, PK.HUYETAP, PK.CANNANG, PK.CHIEUCAO, PK.MAICD, PK.NGAYKHAM, PK.HOANTHANH, PK.DATHANHTOAN, PK.KETLUAN, BN.TIENSU FROM PHIEUKHAM PK, BENHNHAN BN WHERE PK.MABN = BN.MABN AND MAPHIEUKHAM  = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Search_Phieukham_By_Ten]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc [dbo].[SP_Search_Phieukham_By_Ten]
go
CREATE PROC [dbo].[SP_Search_Phieukham_By_Ten]
@TEN NVARCHAR (50),
@MANV int
AS
BEGIN 
SELECT MAPHIEUKHAM,HOTEN,NGAYKHAM,HOANTHANH FROM PHIEUKHAM, BENHNHAN WHERE PHIEUKHAM.MABN = BENHNHAN.MABN AND BENHNHAN.HOTEN LIKE '%'+@TEN+'%' AND MANV = @MANV
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Phieukham_All]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc  [dbo].[SP_Select_Phieukham_All]
go
CREATE PROC [dbo].[SP_Select_Phieukham_All]
@MANV int
AS
BEGIN 
SELECT MAPHIEUKHAM,HOTEN,NGAYKHAM,HOANTHANH FROM PHIEUKHAM, BENHNHAN WHERE PHIEUKHAM.MABN = BENHNHAN.MABN AND MANV = @MANV
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Phieukham_Chokham]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc  [dbo].[SP_Select_Phieukham_Chokham]
go
CREATE PROC [dbo].[SP_Select_Phieukham_Chokham]
@MANV int,
@NGKHAM nvarchar (20) 
AS
BEGIN 
SELECT PHIEUKHAM.MAPHIEUKHAM, BENHNHAN.HOTEN, PHIEUKHAM.NGAYKHAM  FROM PHIEUKHAM, BENHNHAN WHERE PHIEUKHAM.MABN = BENHNHAN.MABN AND HOANTHANH = 0 AND MANV = @MANV AND NGAYKHAM = @NGKHAM
END
go

/****** Object:  StoredProcedure [dbo].[SP_TimKiemLichSuKhamNhanVien]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc  [dbo].[SP_TimKiemLichSuKhamNhanVien] 
go
CREATE proc [dbo].[SP_TimKiemLichSuKhamNhanVien] 
@ThongTin nvarchar(20),
@DuLieu nvarchar (50),
@MaNhanVien int
as 
begin 
	IF @ThongTin = 'MAPHIEUKHAM' select BN.MABN, PK.MAPHIEUKHAM, BN.HOTEN, PK.NGAYKHAM,PK.DATHANHTOAN from BENHNHAN BN, PHIEUKHAM PK where BN.MABN = PK.MABN AND PK.MANV = @MaNhanVien  AND MAPHIEUKHAM = @DuLieu;
	IF @ThongTin = 'MABN'	     select BN.MABN, PK.MAPHIEUKHAM, BN.HOTEN, PK.NGAYKHAM,PK.DATHANHTOAN from BENHNHAN BN, PHIEUKHAM PK where BN.MABN = PK.MABN AND PK.MANV = @MaNhanVien  AND PK.MABN = @DuLieu;
	IF @ThongTin = 'HOTEN'		 select BN.MABN, PK.MAPHIEUKHAM, BN.HOTEN, PK.NGAYKHAM,PK.DATHANHTOAN from BENHNHAN BN inner join PHIEUKHAM PK on BN.MABN = PK.MABN where PK.MANV = @MaNhanVien AND  BN.HOTEN LIKE '%'+@DuLieu+'%';
	IF @ThongTin = 'NGAYKHAM'	 select BN.MABN, PK.MAPHIEUKHAM, BN.HOTEN, PK.NGAYKHAM,PK.DATHANHTOAN from BENHNHAN BN, PHIEUKHAM PK where BN.MABN = PK.MABN AND PK.MANV = @MaNhanVien  AND NGAYKHAM LIKE '%'+@DuLieu+'%';
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_HoanThanhPhieuKham]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc [dbo].[SP_Update_HoanThanhPhieuKham]
go
create proc [dbo].[SP_Update_HoanThanhPhieuKham] 
@MAPHIEU int
as
begin 
update PHIEUKHAM set HOANTHANH = 1 where MAPHIEUKHAM = @MAPHIEU
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_Phieukham]    Script Date: 12/4/2017 11:17:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
drop proc [dbo].[SP_Update_Phieukham]
go
CREATE PROC [dbo].[SP_Update_Phieukham]
@MAPHIEUKHAM INT,
@MABN INT,
@CHUANDOAN NVARCHAR(250),
@NHIPTIM NVARCHAR (10),
@NHIETDO NVARCHAR (10),
@HUYETAP NVARCHAR (10),
@CANNANG INT,
@CHIEUCAO INT,
@MAICD NVARCHAR(10),
@NGAYKHAM DATE,
@KETLUAN NVARCHAR(50),
@TIENSU NVARCHAR(250)
AS
BEGIN 
UPDATE PHIEUKHAM SET 
MABN = @MABN,
CHUANDOAN = N''+ @CHUANDOAN +'',
NHIPTIM = @NHIPTIM,
NHIETDO = @NHIETDO,
HUYETAP = @HUYETAP,
CANNANG = @CANNANG,
CHIEUCAO = @CHIEUCAO,
MAICD = @MAICD,
NGAYKHAM = @NGAYKHAM,
KETLUAN = @KETLUAN
WHERE MAPHIEUKHAM = @MAPHIEUKHAM
UPDATE BENHNHAN SET TIENSU = @TIENSU where BENHNHAN.MABN = @MABN 
END

GO
