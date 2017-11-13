USE quanlyphongkham_final
GO

-------------------STORE-PROCEDURE----------------------------------------

--1. Bảng PHANQUYEN
--1.1 SP_INSERT_PHANQUYEN
CREATE PROC SP_INSERT_PHANQUYEN
@QUYEN INT,
@GHICHU NVARCHAR(250)
AS
BEGIN
	INSERT dbo.PHANQUYEN
	        ( QUYEN, GHICHU )
	VALUES  ( @QUYEN, -- QUYEN - int
	          @GHICHU  -- GHICHU - nvarchar(250)
	          )
END
GO



--2. BẢNG TAIKHOAN
--2.1 SPINSERT_TAIKHOAN
CREATE PROC SP_INSERT_TAIKHOAN
	@TENDANGNHAP VARCHAR(50),
	@MATKHAU VARCHAR(50),
	@TENHIENTHI NVARCHAR(50),
	@MAPHANQUYEN int,
	@TRANGTHAI BIT
AS
BEGIN
	INSERT dbo.TAIKHOAN 
	        ( TENDANGNHAP ,
	          MATKHAU ,
	          TENHIENTHI ,
	          MAPHANQUYEN ,
	          TRANGTHAI
	        )
	VALUES  ( @TENDANGNHAP , -- TENDANGNHAP - varchar(50)
	          @MATKHAU , -- MATKHAU - varchar(50)
	          @TENHIENTHI , -- TENHIENTHI - nvarchar(50)
	          @MAPHANQUYEN , -- MAPHANQUYEN - int
	          @TRANGTHAI  -- TRANGTHAI - bit
	        )
END
GO

EXEC dbo.SP_INSERT_TAIKHOAN @TENDANGNHAP = 'sadmin', -- varchar(50)
    @MATKHAU = '1', -- varchar(50)
    @TENHIENTHI = N'Super Admin', -- nvarchar(50)
    @MAPHANQUYEN = 1, -- int
    @TRANGTHAI = 1 -- bit
GO
    
--2.2 SP_LOGIN
ALTER PROC SP_LOGIN
	@TenDangNhap VARCHAR(50),
	@MatKhau VARCHAR(50)
AS
BEGIN
	DECLARE @result int
	SELECT  @result = QUYEN 
	FROM dbo.TAIKHOAN T , dbo.PHANQUYEN P 
	WHERE TENDANGNHAP = @TenDangNhap AND MATKHAU = @MatKhau AND TRANGTHAI = 1 AND P.MAPHANQUYEN = T.MAPHANQUYEN
	IF	@result = NULL
	RETURN 0
	RETURN @result
END
GO

DECLARE @R INT;
EXEC @R =  dbo.SP_Login @TenDangNhap = N'sadmin', -- nvarchar(50)
    @MatKhau = N's' -- nvarchar(50)
PRINT @R
