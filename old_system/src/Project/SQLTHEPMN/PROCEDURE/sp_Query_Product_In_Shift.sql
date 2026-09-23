/*
EXEC sp_Query_Product_In_Shift '1007815'
*/
ALTER PROCEDURE [dbo].[sp_Query_Product_In_Shift]
(
	@Ma_Ca VARCHAR(20) = ''
)
AS
BEGIN
	SELECT T1.*,
			CASE WHEN T1.So_Luong - T1.So_Luong_Old = 0 THEN 0 ELSE 1 END AS Change_So_Luong,
			CASE WHEN T1.Num_Bars - T1.Num_Bars_Old = 0 THEN 0 ELSE 1 END AS Change_Num_Bars,
			CASE WHEN T2.So_Luong_OutPut IS NULL THEN 0 ELSE 1 END AS OutPut,
			CASE WHEN T3.So_Luong_InPut IS NULL THEN 0 ELSE 1 END AS InPut
		INTO #T_DmBarcode
		FROM R81DMBARCODE T1 LEFT JOIN(SELECT Barcode, SUM(So_Luong) AS So_Luong_OutPut FROM R05CTX_BARCODE GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode
								LEFT JOIN(SELECT Barcode, SUM(So_Luong) AS So_Luong_InPut FROM R05CTN_BARCODE GROUP BY Barcode) T3 ON T1.Barcode = T3.Barcode
		WHERE T1.Ma_Ca = @Ma_Ca

	UPDATE #T_DmBarcode SET OutPut = CASE WHEN Input = 1 THEN 0 ELSE OutPut END

	SELECT T1.*, ISNULL(T2.Grade_Name, '') AS Grade_Name, ISNULL(T3.Standard_Name, '') AS Standard_Name, ISNULL(T4.Ten_CL, '') AS Standard_Name, ISNULL(T5.Lot_Name, '') AS Lot_Name, ISNULL(T6.Ten_Size, '') AS Ten_Size
		FROM #T_DmBarcode T1 LEFT JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID
								LEFT JOIN R81DMSTANDARD T3 ON T1.Standard_ID = T3.Standard_ID
								LEFT JOIN R81DMCL T4 ON T1.Ma_CL = T4.Ma_CL
								LEFT JOIN R81DMLOTS T5 ON T1.Lot_ID = T5.Lot_ID
								LEFT JOIN R81DMSIZE T6 ON T1.Ma_Size = T6.Ma_Size
END
