/*
SELECT * FROM R05CTX_BARCODE WHERE Stt = 3981
GO
EXEC sp_Print_GCN '128713','PXTH'
*/

ALTER PROCEDURE [dbo].[sp_Print_GCN]
(
	@Stt VARCHAR(15) = '',
	@Ma_Ct VARCHAR(5),
	@Ma_Vt_Sp VARCHAR(30) = '',
	@Language_Type CHAR(1) = 'V'
)
AS
BEGIN
	DECLARE @_Table_Ph VARCHAR(50),
			@_Table_Ct VARCHAR(50),
			@_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX),
			@_Stt1 VARCHAR(20) = '',
			@_RowID INT = 0,
			@_RowMax INT = 0,
			@_RowID_Reset INT = 0

	SELECT	@_Table_Ph = Table_Ph,
			@_Table_Ct = Table_Ct
		FROM R00DmCt WHERE Ma_Ct = @Ma_Ct

	SET @_Key = '(0=0)'

	IF @Stt <> ''
		SET @_Key = @_Key + ' AND Stt = ''' + @Stt + ''''

	CREATE TABLE #T_Header(Stt VARCHAR(15))
	CREATE TABLE #T_Detail(Stt VARCHAR(15))

	EXEC sp_Copy_Column @_Table_Ph, '#T_Header', ''
	EXEC sp_Copy_Column @_Table_Ct, '#T_Detail', ''

	EXEC sp_DefaultTable '#T_Header'
	EXEC sp_DefaultTable '#T_Detail'
	
	SET @_Key = '(Stt = ''' + @Stt + ''')'

	EXEC sp_Copy_Data @_Table_Ph, '#T_Header', '', @_Key
	EXEC sp_Copy_Data @_Table_Ct, '#T_Detail', '', @_Key
	
	
	IF (@Ma_Vt_Sp <> '')
		DELETE FROM #T_Detail WHERE Ma_Vt_Sp <> @Ma_Vt_Sp

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_In') IS NULL
		ALTER TABLE #T_Header ADD Ngay_In VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Gio_In') IS NULL
		ALTER TABLE #T_Header ADD Gio_In VARCHAR(10) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_Xuat') IS NULL
		ALTER TABLE #T_Header ADD Ngay_Xuat NVARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_Nhap') IS NULL
		ALTER TABLE #T_Header ADD Ngay_Nhap DATE NOT NULL DEFAULT('19000101')
		
	--Detail
	IF COL_LENGTH('TempDB..#T_Detail', 'Ma_Ca') IS NULL
		ALTER TABLE #T_Detail ADD Ma_Ca VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Num_Lot') IS NULL
		ALTER TABLE #T_Detail ADD Num_Lot VARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'No_Melt') IS NULL
		ALTER TABLE #T_Detail ADD No_Melt VARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ngay_Nhap') IS NULL
		ALTER TABLE #T_Detail ADD Ngay_Nhap DATE NOT NULL DEFAULT('19000101')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ma_Size') IS NULL
		ALTER TABLE #T_Detail ADD Ma_Size VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ten_Size') IS NULL
		ALTER TABLE #T_Detail ADD Ten_Size NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ten_Size0') IS NULL
		ALTER TABLE #T_Detail ADD Ten_Size0 NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_ID') IS NULL
		ALTER TABLE #T_Detail ADD Grade_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_Name') IS NULL
		ALTER TABLE #T_Detail ADD Grade_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Try_ID') IS NULL
		ALTER TABLE #T_Detail ADD Try_ID VARCHAR(50) NOT NULL DEFAULT('')
	
	IF COL_LENGTH('TempDB..#T_Detail', 'Nhan_Mac') IS NULL
		ALTER TABLE #T_Detail ADD Nhan_Mac NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Length') IS NULL
		ALTER TABLE #T_Detail ADD Length MONEY NOT NULL DEFAULT(0)

	UPDATE #T_Header SET Ngay_Xuat = N'Ngày ' + CONVERT(VARCHAR, DAY(dbo.fn_GetNow())) + N' tháng ' + dbo.fn_PADL(CONVERT(VARCHAR, MONTH(dbo.fn_GetNow())), 2, '0') + N' năm ' + CONVERT(VARCHAR, YEAR(dbo.fn_GetNow()))
	UPDATE #T_Header SET Ngay_In = dbo.fn_PADL(CONVERT(VARCHAR, DAY(dbo.fn_GetNow())), 2, '0') + dbo.fn_PADL(CONVERT(VARCHAR, MONTH(dbo.fn_GetNow())), 2, '0') + SUBSTRING(CONVERT(VARCHAR,YEAR(dbo.fn_GetNow())), 3, 3)
	UPDATE #T_Header SET Gio_In = (SELECT CONVERT(VARCHAR(8),GETDATE(),108))
	UPDATE #T_Header SET Ten_Dt = T2.Ten_Dt FROM #T_Header T1 JOIN R81DMDT T2 on T1.Ma_Dt = T2.Ma_Dt
	
	--Detail
	UPDATE T1 SET
			Ma_Ca = T2.Ma_Ca,
			Grade_ID = T2.Grade_ID,
			Ngay_Nhap = T2.Ngay_Nhap,
			No_Melt = T2.No_Melt,
			Num_Lot = T2.Num_Lot,
			Try_ID = T2.Try_ID,
			Length = T2.Length
		FROM #T_Detail T1 JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode
	
	UPDATE T1 SET Ngay_Nhap = ISNULL(CASE WHEN T2.Ngay_Sx IS NULL THEN T1.Ngay_Nhap ELSE T2.Ngay_Sx END, '')
		FROM #T_Detail T1 LEFT JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca
	
	UPDATE T1 SET
			Ten_Size0 = T2.Ten_Size,
			Ten_Size = CASE WHEN T1.Length <> 0 THEN N'THÉP CÂY VẰN ' + UPPER(ISNULL(T2.Ten_Size, '')) ELSE N'THÉP CUÔN ' + UPPER(ISNULL(T2.Ten_Size, '')) END
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMSIZE T2 WITH(NOLOCK) ON T1.Ma_Size = T2.Ma_Size

	UPDATE T1 SET
			Grade_Name = UPPER(ISNULL(T2.Grade_Name, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMMACTHEP T2 WITH(NOLOCK) ON T1.Grade_ID = T2.Grade_ID
	
	UPDATE #T_Detail SET Nhan_Mac = N'Thép Miền Nam /V/'

	SELECT *
		INTO #T_Temp1
		FROM #T_Detail
		WHERE Ngay_Nhap < '20150911'

	SELECT *
		INTO #T_Temp2
		FROM #T_Detail
		WHERE Ngay_Nhap >= '20150911'

	SELECT MAX(Ngay_Ct) AS Ngay_Ct, CAST(0 AS INT) AS RowID, CAST('' AS VARCHAR(20)) AS Stt1, 
			Ma_Size, MAX(Ten_Size0) AS Ten_Size0, MAX(Ten_Size) AS Ten_Size, Nhan_Mac, Grade_ID, MAX(Grade_Name) AS Grade_Name,
			No_Melt + '/' + Try_ID AS Try_ID, Ngay_Nhap
		INTO #T_Detail_GCN
		FROM #T_Temp1
		GROUP BY Ma_Size, Grade_ID, Ngay_Nhap, Num_Lot, No_Melt, Try_ID, Nhan_Mac
		ORDER BY Ten_Size0

	EXEC sp_DefaultTable '#T_Detail_GCN'

	INSERT #T_Detail_GCN
	SELECT MAX(Ngay_Ct) AS Ngay_Ct, CAST(0 AS INT) AS RowID, CAST('' AS VARCHAR(20)) AS Stt1, 
			Ma_Size, MAX(Ten_Size0) AS Ten_Size0, MAX(Ten_Size) AS Ten_Size, Nhan_Mac, Grade_ID, MAX(Grade_Name) AS Grade_Name,
			Num_Lot AS Try_ID, Ngay_Nhap
		FROM #T_Temp2
		GROUP BY Ma_Size, Grade_ID, Ngay_Nhap, Num_Lot, Nhan_Mac
		ORDER BY Ten_Size0

	--Cach cu
	--SELECT MAX(Ngay_Ct) AS Ngay_Ct, CAST(0 AS INT) AS RowID, CAST('' AS VARCHAR(20)) AS Stt1, 
	--		Ma_Size, MAX(Ten_Size0) AS Ten_Size0, MAX(Ten_Size) AS Ten_Size, Nhan_Mac, Grade_ID, MAX(Grade_Name) AS Grade_Name, CASE WHEN LEN(Num_Lot) = 9 THEN Num_Lot ELSE No_Melt + '/' + Try_ID END AS Try_ID, Ngay_Nhap
	--	INTO #T_Detail_GCN
	--	FROM #T_Detail
	--	GROUP BY Ma_Size, Grade_ID, Ngay_Nhap, Num_Lot, No_Melt, Try_ID, Nhan_Mac
	--	ORDER BY Ten_Size0
	
	--IF (SELECT COUNT(*) FROM #T_Detail_GCN) < 18
	--BEGIN
	--	DECLARE @_Stt0 INT = 18
	--	WHILE @_Stt0 < 30
	--	BEGIN
			
	--		INSERT #T_Detail_GCN(Ngay_Ct, RowID, Stt1, Ma_Vt, Ten_Vt0, Ten_Vt, Nhan_Mac, Grade_ID, Grade_Name, Try_ID, Ngay_Nhap)
	--		SELECT TOP 2 Ngay_Ct, RowID, Stt1, Ma_Vt, Ten_Vt0, Ten_Vt, Nhan_Mac, Grade_ID, Grade_Name, Try_ID, Ngay_Nhap
	--			FROM #T_Detail_GCN

	--		SET @_Stt0 = @_Stt0 + 1
	--	END
		
	--END 

	UPDATE #T_Detail_GCN SET 
			@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
			RowID = LTRIM(RTRIM(STR(@_RowID))),
			Stt1 = LTRIM(RTRIM(STR(@_RowID)))
		
	SELECT @_RowMax = (SELECT COUNT(*) FROM #T_Detail_GCN)
	
	IF @_RowMax > 13
	BEGIN
		SET @_RowID_Reset = 0
		SET @_RowID = 14
		WHILE @_RowID < 27
		BEGIN
			UPDATE #T_Detail_GCN SET
					@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
					Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
				WHERE RowID = @_RowID

			SET @_RowID = @_RowID + 1
		END
	END
		
	IF @_RowMax > 26
	BEGIN
		SET @_RowID_Reset = 0
		SET @_RowID = 27
		WHILE @_RowID < 40
		BEGIN
			UPDATE #T_Detail_GCN SET
					@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
					Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
				WHERE RowID = @_RowID

			SET @_RowID = @_RowID + 1
		END
	END

	SELECT *
		FROM #T_Header

	SELECT *
		FROM #T_Detail_GCN
		ORDER BY RowID
	
END