ALTER PROC sp_GetBarCode_XKKV
(
	@BarCode VARCHAR(20)
)
AS
BEGIN
SELECT T1.*, 							
					T1.So_Luong + ISNULL(T3.So_Luong_TL, 0) - ISNULL(T2.So_Luong, 0) AS So_Luong_Current,
					T1.Num_Bars + ISNULL(T3.Num_Bars_TL, 0) - ISNULL(T2.Num_Bars, 0) AS Num_Bars_Current,
					T5.Ten_Size, T4.Length, T4.So_Luong AS So_Luong_Barcode, T4.Num_Bars AS Num_Bars_Barcode,
					T6.Grade_ID, T6.Grade_Name, T7.Standard_ID, T7.Standard_Name, 
					T8.Ma_CL, T8.Ten_CL
	FROM (SELECT *
							FROM R05CTN_BARCODE_KKV WITH(NOLOCK) 
							WHERE Ma_Nvu LIKE 'BKV%' AND Barcode = @BarCode) T1 
			LEFT JOIN(SELECT Barcode, ISNULL(SUM(So_Luong), 0) AS So_Luong, ISNULL(SUM(Num_Bars), 0) AS Num_Bars
							FROM R05CTX_BARCODE_KKV WITH(NOLOCK) 
							WHERE Barcode = @BarCode GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode
			LEFT JOIN(SELECT Barcode, ISNULL(SUM(So_Luong), 0) AS So_Luong_TL, ISNULL(SUM(Num_Bars), 0) AS Num_Bars_TL
							FROM R05CTN_BARCODE_KKV WITH(NOLOCK) 
							WHERE Ma_Nvu LIKE 'TL%' AND Barcode = @BarCode GROUP BY Barcode) T3 ON T1.Barcode = T3.Barcode				
			LEFT JOIN R81DMSIZE T5 WITH(NOLOCK) ON T1.Ma_Size = T5.Ma_Size
			JOIN R81DMBARCODE T4 WITH(NOLOCK) ON T1.Barcode = T4.Barcode
			LEFT JOIN R81DMMACTHEP T6 WITH(NOLOCK) ON T4.Grade_ID = T6.Grade_ID
			LEFT JOIN R81DMSTANDARD T7 WITH(NOLOCK) ON T4.Standard_ID = T7.Standard_ID
			LEFT JOIN R81DMCL T8 WITH(NOLOCK) ON T4.Ma_CL = T8.Ma_CL
	WHERE T1.Barcode = @BarCode AND T1.So_Luong + ISNULL(T3.So_Luong_TL, 0) - ISNULL(T2.So_Luong, 0) <> 0
END
GO
EXEC sp_GetBarCode_XKKV	'01160146041'