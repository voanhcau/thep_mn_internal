ALTER PROCEDURE [dbo].[sp_PrintBarcode]
(
	@Barcode VARCHAR(20),
	@Language_Type CHAR(1) = 'V'
)
AS
BEGIN
	DECLARE @_Barcode_Split VARCHAR(50),
			@_Barcode_1 VARCHAR(20),
			@_Barcode_2 VARCHAR(20),
			@_Barcode_3 VARCHAR(20),
			@_Barcode_4 VARCHAR(20)

	SELECT @_Barcode_1 = ISNULL(SUBSTRING(@Barcode, 0, LEN(@Barcode) - 8), '')
	SELECT @_Barcode_2 = ISNULL(SUBSTRING(@Barcode, 3, LEN(@Barcode) - 9), '')
	SELECT @_Barcode_3 = ISNULL(SUBSTRING(@Barcode, 5, LEN(@Barcode) - 8), '')
	SELECT @_Barcode_4 = ISNULL(SUBSTRING(@Barcode, 8, LEN(@Barcode)), '')
	
	SELECT @_Barcode_Split = @_Barcode_1 + REPLICATE(' ', 2) + @_Barcode_2 + REPLICATE(' ', 2) + @_Barcode_3 + REPLICATE(' ', 2) + @_Barcode_4

	SELECT  Barcode, Standard_ID, CAST('' AS NVARCHAR(100)) AS Standard_Name, Grade_ID, CAST('' AS NVARCHAR(100)) AS Grade_Name,
			Ma_Vt, CAST('' AS NVARCHAR(100)) AS Ten_Vt, Length, Num_Lot, No_Melt, Num_Bars, Code AS Num_Barcode,
			So_Luong, So_Luong_Barem, Ma_Ca, CAST('' AS CHAR(1)) AS Ca, Ngay_Nhap AS Ngay_Ct,
			CAST('' AS NVARCHAR(200)) AS Title, CAST('' AS NVARCHAR(200)) AS Ten_Vt_Length, CAST('' AS VARCHAR(100)) AS So_Luong_Kg
		INTO #T_DmBarcode
		FROM R81DMBARCODE WITH(NOLOCK)
		WHERE Barcode = @Barcode

	UPDATE T1 SET Standard_Name = T2.Standard_Name
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMSTANDARD T2 WITH(NOLOCK) ON T1.Standard_ID = T2.Standard_ID

	UPDATE T1 SET Grade_Name = T2.Grade_Name
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMMACTHEP T2 WITH(NOLOCK) ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Ten_Vt = T2.Ten_Vt
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt = T2.Ma_Vt

	UPDATE T1 SET Ca = T2.Ca
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMCA T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca
		
	UPDATE #T_DmBarcode SET Ten_Vt_Length = CASE WHEN Num_Bars <> 0 THEN Ten_Vt + REPLICATE(' ', 3) + 'x' + REPLICATE(' ', 3) + dbo.fn_FormatNumber(Length, 2, ',') + 'm' ELSE Ten_Vt END
	UPDATE #T_DmBarcode SET So_Luong_Kg = dbo.fn_FormatNumber(So_Luong, 0, '.') + ' kg'
	UPDATE #T_DmBarcode SET Title = CASE WHEN Num_Bars <> 0 THEN N'THÉP CỐT BÊ TÔNG CÁN NÓNG' ELSE N'THÉP CỐT BÊ TÔNG CÁN NÓNG' END
	
	SELECT *, @_Barcode_Split AS Barcode_Split
		FROM #T_DmBarcode WITH(NOLOCK)
END
EXEC sp_PrintBarcode 'L01150000001'