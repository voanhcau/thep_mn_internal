/*
SELECT dbo.fn_GetNewBarcode('N', '20150615', 7, 120)
*/
ALTER FUNCTION [dbo].[fn_GetNewBarcode]
(
	@strNew_Edit CHAR(1),
	@Ngay_Nhap DATE,
	@SuffixLen INT,
	@Code INT
)
RETURNS VARCHAR(50)
AS
BEGIN
	
	DECLARE	@_Barcode VARCHAR(50)
			
	--Lấy max số Barcode lẻ
	IF @strNew_Edit = 'L'
	BEGIN
		SET @_Barcode = ISNULL((SELECT MAX(SUBSTRING(Barcode, 6, 11))
										FROM R81DMBARCODE WITH(NOLOCK)
										WHERE LEFT(Barcode, 1) = 'L' AND YEAR(Ngay_Nhap) = YEAR(@Ngay_Nhap)), '')
		IF @_Barcode <> ''
		BEGIN
			SET @_Barcode = (SELECT @_Barcode + 1)
			
			SET @_BarCode = (SELECT SUBSTRING(CONVERT(VARCHAR,YEAR(@Ngay_Nhap)), 3, 3) + (SELECT dbo.fn_PADL(@_Barcode, @SuffixLen,'0')))
			
		END
		ELSE
		BEGIN
			SET @_BarCode = @_BarCode + 1
			SET @_BarCode = (SELECT SUBSTRING(CONVERT(VARCHAR,YEAR(@Ngay_Nhap)), 3, 3) + (SELECT dbo.fn_PADL(@_Barcode, @SuffixLen,'0')))
		END
	END
	ELSE
		SET @_BarCode = SUBSTRING(CONVERT(VARCHAR,YEAR(@Ngay_Nhap)), 3, 3) + (SELECT dbo.fn_PADL(@Code, @SuffixLen,'0'))
	
	RETURN CASE WHEN @strNew_Edit = 'L' THEN 'L01' + @_Barcode ELSE '01' + @_Barcode END
END
GO
SELECT dbo.fn_GetNewBarcode('L', '20150615', 7, 120)