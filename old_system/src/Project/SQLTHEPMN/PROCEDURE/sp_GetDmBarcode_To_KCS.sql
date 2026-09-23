/*
EXEC sp_GetDmBarcode_To_KCS @Ngay_Ct1 = '20150628', @Ngay_Ct2 = '20150628', @Filter_Update = 'A', @Barcode1 = '01150094416', @Barcode2 = '01150094416'
*/
ALTER PROCEDURE [dbo].[sp_GetDmBarcode_To_KCS]
(
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@Filter_Update CHAR(1) = 'N',
	@Barcode1 VARCHAR(20) = '',
	@Barcode2 VARCHAR(20) = '',
	@Ca VARCHAR(20) = '',
	@Ma_Size VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Ma_CL VARCHAR(20) = '',
	@Num_Lot VARCHAR(50) = '',
	@Is_OutPut CHAR(1) = '',
	@Is_Ton_Kho CHAR(1) = '',
	@Status CHAR(1) = '',
	@Ma_Data VARCHAR(3) = '*'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'

	IF @Status <> ''
	BEGIN
		IF @Status = '1'
			SET @_Key = @_Key + ' AND (LEFT(Barcode, 1) <> ''L'') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1)'
		ELSE IF @Status = '2'
			SET @_Key = @_Key + ' AND (LEFT(Barcode, 1) = ''L'') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1)'
		ELSE IF @Status = '3'
			SET @_Key = @_Key + ' AND Is_Wait_Process = 1'
		ELSE IF @Status = '4'
			SET @_Key = @_Key + ' AND Is_Thu_Pham = 1'
	END

	IF @Filter_Update <> ''
	BEGIN
		IF @Filter_Update = 'N'
			SET @_Key = @_Key + ' AND Try_ID = '''''
		ELSE IF @Filter_Update = 'E'
			SET @_Key = @_Key + ' AND Try_ID <> '''''
	END

	SELECT T1.*
		INTO #T_PhatSinh
		FROM R81DmBarcode T1 WITH(NOLOCK) JOIN R81DmCa T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca 
		WHERE (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) 
				AND T1.Barcode >= CASE WHEN @Barcode1 = '' THEN T1.Barcode ELSE @Barcode1 END AND T1.Barcode <= CASE WHEN @Barcode2 = '' THEN T1.Barcode ELSE @Barcode2 END
				AND T1.Ma_Size = CASE WHEN @Ma_Size = '' THEN T1.Ma_Size ELSE @Ma_Size END
				AND T1.Grade_ID = CASE WHEN @Grade_ID = '' THEN T1.Grade_ID ELSE @Grade_ID END
				AND T1.Ma_CL = CASE WHEN @Ma_CL = '' THEN T1.Ma_CL ELSE Ma_CL END
				AND T1.Num_Lot = CASE WHEN @Num_Lot = '' THEN T1.Num_Lot ELSE @Num_Lot END
				AND T1.Num_Lot = CASE WHEN @Num_Lot = '' THEN T1.Num_Lot ELSE @Num_Lot END
				AND T1.Is_Output = CASE WHEN @Is_Output = '' THEN T1.Is_Output ELSE @Is_OutPut END
	
	SELECT *
		INTO #T_DmBarcode
		FROM R81DMBARCODE
		WHERE 0 = 1

	EXEC sp_Copy_Data '#T_PhatSinh', '#T_DmBarcode', '', @_Key
	
	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Ten_Size') IS NULL
		ALTER TABLE #T_DmBarcode ADD Ten_Size NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Lot_Name') IS NULL
		ALTER TABLE #T_DmBarcode ADD Lot_Name NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Standard_Name') IS NULL
		ALTER TABLE #T_DmBarcode ADD Standard_Name NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Ten_CL') IS NULL
		ALTER TABLE #T_DmBarcode ADD Ten_CL NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Grade_Name') IS NULL
		ALTER TABLE #T_DmBarcode ADD Grade_Name NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Ca') IS NULL
		ALTER TABLE #T_DmBarcode ADD Ca NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_DmBarcode', 'Ton_Cuoi') IS NULL
		ALTER TABLE #T_DmBarcode ADD Ton_Cuoi MONEY NOT NULL DEFAULT(0)

	UPDATE T1 SET Ten_Size = T2.Ten_Size
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMSIZE T2  WITH(NOLOCK) ON T1.Ma_Size = T2.Ma_Size

	UPDATE T1 SET Grade_Name = T2.Grade_Name
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMMACTHEP T2  WITH(NOLOCK) ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Ten_Cl = T2.Ten_Cl
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMCL T2  WITH(NOLOCK) ON T1.Ma_Cl = T2.Ma_Cl

	UPDATE T1 SET Standard_Name = T2.Standard_Name
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMSTANDARD T2  WITH(NOLOCK) ON T1.Standard_ID = T2.Standard_ID

	UPDATE T1 SET Lot_Name = T2.Lot_Name
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMLOTS T2  WITH(NOLOCK) ON T1.Lot_ID = T2.Lot_ID

	UPDATE T1 SET Ca = UPPER(T2.Ca)
		FROM #T_DmBarcode T1 WITH(NOLOCK) JOIN R81DMCA T2  WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca

	UPDATE T1 SET Ton_Cuoi = T1.So_Luong + ISNULL(T3.Sl_Nhap, 0) - ISNULL(T2.Sl_Xuat, 0)
		FROM #T_DmBarcode T1 WITH(NOLOCK) LEFT JOIN (SELECT Barcode, SUM(So_Luong) AS Sl_Xuat FROM R05CTX_BARCODE WITH(NOLOCK) GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode
											LEFT JOIN (SELECT Barcode, SUM(So_Luong) AS Sl_Nhap FROM R05CTN_BARCODE WITH(NOLOCK) GROUP BY Barcode) T3 ON T1.Barcode = T3.Barcode

	IF @Is_Ton_Kho <> ''
		IF @Is_Ton_Kho = '1'
			DELETE #T_DmBarcode WHERE Ton_Cuoi = 0
		ELSE
			DELETE #T_DmBarcode WHERE Ton_Cuoi <> 0

	IF @Ca <> ''
		DELETE #T_DmBarcode WHERE Ca <> @Ca

	
	SELECT *,
			CAST(CASE WHEN LEFT(Barcode, 1) <> 'L' AND Is_Wait_Process <> 1 AND Is_Thu_Pham <> 1 THEN 1 ELSE 0 END AS BIT) AS Is_Kho_Chan,
			CAST(CASE WHEN LEFT(Barcode, 1) = 'L' AND Is_Wait_Process <> 1 AND Is_Thu_Pham <> 1 THEN 1 ELSE 0 END AS BIT) AS Is_Kho_Le,
			CASE WHEN Is_OutPut = 1 THEN N'Cho phép xuất' ELSE N'Không cho phép xuất' END AS Is_Outputed,
			CASE WHEN Bend_Test = 1 THEN N'Đạt' ELSE N'Không đạt' END AS Bend_Tested,
			CASE WHEN Ton_Cuoi = 0 THEN N'Đã xuất' ELSE N'Tồn kho' END AS Ton_Kho
		FROM #T_DmBarcode
		ORDER BY Barcode
END