USE [quanlyphongkham_final]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_DICHVUCLS]    Script Date: 12/10/2017 10:05:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
DROP PROC [dbo].[SP_INSERT_DICHVUCLS]

GO
CREATE PROC [dbo].[SP_INSERT_DICHVUCLS]
	@maphieu int,
	@macls INT,
	@duongdan varchar(50)
AS
BEGIN
	DECLARE @madichvucls int
	SET @madichvucls = (SELECT MADICHVUCLS FROM DICHVUCLS WHERE MAPHIEUKHAM = @maphieu)
	if(EXISTS (SELECT * FROM CHITIETCLS WHERE MADICHVUCLS = @madichvucls and MACLS = @macls))
		begin
		return -1;
		end
	INSERT INTO CHITIETCLS VALUES (@madichvucls, @macls, @duongdan)
END


GO
DROP PROC [dbo].[SP_LayKetQuaCLS]

GO
CREATE PROC [dbo].[SP_LayKetQuaCLS]
	@maphieu int,
	@macls INT
AS
BEGIN
	DECLARE @madichvucls int
	SET @madichvucls = (SELECT MADICHVUCLS FROM DICHVUCLS WHERE MAPHIEUKHAM = @maphieu)
	select * from CHITIETCLS where MADICHVUCLS = @madichvucls and MACLS = @macls
END

--- Lay Thông Tin CLS


GO
DROP proc [dbo].[SP_Getbyid_CLS]

GO
CREATE proc [dbo].[SP_Getbyid_CLS]
	@macls int
AS
begin
	select b.MACLS, b.TENCLS, b.GIATIEN, b.MALOAICLS from CANLAMSANG b, LOAICANLAMSANG a
		where b.MALOAICLS = a.MALOAICLS and a.MALOAICLS = @macls

end

--- insert thuốc vào đơn thuốc

GO
DROP proc [dbo].[SP_InsertThuoc]

GO
CREATE proc [dbo].[SP_InsertThuoc]
	@maphieukham nvarchar(100),
	@mathuoc int,
	@soluong int,
	@huongdan nvarchar(100)
AS
begin
	if(EXISTS (select * from DONTHUOC where MADONTHUOC = @maphieukham) and EXISTS (select * from THUOC where MATHUOC = @mathuoc))
		begin
			declare @slton int
			set @slton = (select SOLUONGTON from THUOC where MATHUOC = @mathuoc)
				if(@slton - @soluong > 39) 
					begin
						INSERT INTO CHITIETDONTHUOC values (@maphieukham, @mathuoc, @soluong, @huongdan)
					end
		end
end


---- tìm kiếm thuốc
GO
DROP proc [dbo].[SP_timkiemthuoc]

GO
CREATE proc [dbo].[SP_timkiemthuoc]

	@timkiem nvarchar(50),
	@timtheo int,
	@loaithuoc int
AS
begin
	declare @donvitinh nvarchar(10)
	declare @tenloaithuoc nvarchar(50)

	if(@timtheo = 0)
		begin 
					if(@loaithuoc = 0)
						begin
							select MATHUOC, TENTHUOC, DVT.TENDVT, LT.TENLOAI, SOLUONGTON from THUOC T, DONVITINH DVT, LOAITHUOC LT where T.DONVITINH = DVT.MADVT and T.LOAITHUOC = LT.MALOAITHUOC and MATHUOC = @timkiem
						end
					if(@loaithuoc != 0 )
						begin
							select MATHUOC, TENTHUOC, DVT.TENDVT, LT.TENLOAI, SOLUONGTON from THUOC T, DONVITINH DVT, LOAITHUOC LT where T.DONVITINH = DVT.MADVT and T.LOAITHUOC = LT.MALOAITHUOC and MATHUOC = @timkiem and LOAITHUOC = @loaithuoc
						end
		end
	if(@timtheo = 1)
		begin
			if(@loaithuoc = 0)
				begin
					select MATHUOC, TENTHUOC, DVT.TENDVT, LT.TENLOAI, SOLUONGTON from THUOC T, DONVITINH DVT, LOAITHUOC LT where T.DONVITINH = DVT.MADVT and T.LOAITHUOC = LT.MALOAITHUOC and TENTHUOC LIKE N'%' +@timkiem+ '%'
				end
			if(@loaithuoc != 0 )
				begin
					select MATHUOC, TENTHUOC, DVT.TENDVT, LT.TENLOAI, SOLUONGTON from THUOC T, DONVITINH DVT, LOAITHUOC LT where T.DONVITINH = DVT.MADVT and T.LOAITHUOC = LT.MALOAITHUOC and TENTHUOC LIKE N'%' +@timkiem+ '%' and LOAITHUOC = @loaithuoc
				end

		end
	if(@timtheo = -1)
		begin
			select MATHUOC, TENTHUOC, DVT.TENDVT, LT.TENLOAI, SOLUONGTON from THUOC T, DONVITINH DVT, LOAITHUOC LT where T.DONVITINH = DVT.MADVT and T.LOAITHUOC = LT.MALOAITHUOC
		end
end


--- Lay Thông Tin CLS
GO
DROP proc [dbo].[SP_Getbyid_CLS]

GO
CREATE proc [dbo].[SP_Getbyid_CLS]
	@macls int
AS
begin
	select b.MACLS, b.TENCLS, b.GIATIEN, b.MALOAICLS from CANLAMSANG b, LOAICANLAMSANG a
		where b.MALOAICLS = a.MALOAICLS and a.MALOAICLS = @macls

end

GO
