/*
EXEC sp_PrintScale_Out '136248', 'PXTH'
*/

ALTER PROCEDURE [dbo].[sp_PrintScale_Out]
(
	@Stt VARCHAR(15) = '',
	@Ma_Ct VARCHAR(5),
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Table_Ph VARCHAR(50),
			@_Table_Ct VARCHAR(50),
			@_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

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
	
	
	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Vt_Sp') IS NULL
		ALTER TABLE #T_Header ADD Ten_Vt_Sp NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt_CbNv_Vao') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt_CbNv_Vao NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt_CbNv_Ra') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt_CbNv_Ra NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_In') IS NULL
		ALTER TABLE #T_Header ADD Ngay_In DATE NOT NULL DEFAULT('19000101')

	IF COL_LENGTH('TempDB..#T_Header', 'Gio_In') IS NULL
		ALTER TABLE #T_Header ADD Gio_In VARCHAR(10) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_Xuat') IS NULL
		ALTER TABLE #T_Header ADD Ngay_Xuat NVARCHAR(50) NOT NULL DEFAULT('')

	--Detail
	IF COL_LENGTH('TempDB..#T_Detail', 'Ten_Vt_Mac_Thep') IS NULL
		ALTER TABLE #T_Detail ADD Ten_Vt_Mac_Thep NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Length') IS NULL
		ALTER TABLE #T_Detail ADD Length MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'Num_Lot') IS NULL
		ALTER TABLE #T_Detail ADD Num_Lot VARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Num_Barcode') IS NULL
		ALTER TABLE #T_Detail ADD Num_Barcode VARCHAR(10) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ngay_Nhap') IS NULL
		ALTER TABLE #T_Detail ADD Ngay_Nhap DATE NOT NULL DEFAULT('19000101')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ma_Ca') IS NULL
		ALTER TABLE #T_Detail ADD Ma_Ca VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ma_Size') IS NULL
		ALTER TABLE #T_Detail ADD Ma_Size VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ten_Size') IS NULL
		ALTER TABLE #T_Detail ADD Ten_Size NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_ID') IS NULL
		ALTER TABLE #T_Detail ADD Grade_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_Name') IS NULL
		ALTER TABLE #T_Detail ADD Grade_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Standard_ID') IS NULL
		ALTER TABLE #T_Detail ADD Standard_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Standard_Name') IS NULL
		ALTER TABLE #T_Detail ADD Standard_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Stt_In') IS NULL
		ALTER TABLE #T_Detail ADD Stt_In VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Bold') IS NULL
		ALTER TABLE #T_Detail ADD Bold BIT NOT NULL DEFAULT(0)

	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	UPDATE T1 SET Ten_Dt_CbNv_Vao = T2.Ten_Dt
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Vao = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Ra = T2.Ten_Dt
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Ra = T2.Ma_Dt

	UPDATE #T_Header SET Ngay_Xuat = N'Ngày ' + CONVERT(VARCHAR, DAY(Ngay_Ct)) + N' tháng ' + CONVERT(VARCHAR, MONTH(Ngay_Ct)) + N' năm ' + CONVERT(VARCHAR, YEAR(Ngay_Ct))
	UPDATE #T_Header SET Ngay_In = (SELECT dbo.fn_GetNow())
	UPDATE #T_Header SET Gio_In = (SELECT CONVERT(VARCHAR(8),GETDATE(),108))
	UPDATE #T_Header SET So_Luong = (SELECT SUM(So_Luong) AS So_Luong FROM #T_Detail)
	
	--Detail
	UPDATE T1 SET
			Grade_ID = T2.Grade_ID,
			Standard_ID = T2.Standard_ID,
			Length = T2.Length,
			Num_Lot = T2.Num_Lot,
			Num_Barcode = T2.Num_Barcode,
			Ma_Ca = T2.Ma_Ca,
			Ngay_Nhap = T2.Ngay_Nhap
		FROM #T_Detail T1 JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode
	
	UPDATE T1 SET Ten_Size = UPPER(ISNULL(T2.Ten_Size, '')) 
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMSIZE T2 WITH(NOLOCK) ON T1.Ma_Size = T2.Ma_Size

	--UPDATE T1 SET Ma_Nh_Vt_Sp = T2.Ma_Nh_Vt
	--	FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	UPDATE T1 SET Grade_Name = UPPER(ISNULL(T2.Grade_Name, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMMACTHEP T2 WITH(NOLOCK) ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Standard_Name = UPPER(ISNULL(T2.Standard_Name, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMSTANDARD T2 WITH(NOLOCK) ON T1.Standard_ID = T2.Standard_ID

	UPDATE #T_Detail SET Ten_Vt_Mac_Thep = UPPER(Ten_Size + REPLICATE(' ', 2)  + Grade_Name)

	INSERT INTO #T_Detail (Ma_Vt_Sp, Ten_Vt_Mac_Thep, Ma_Size, Grade_ID, Num_Bars, So_Luong, Stt_In, Bold)
		SELECT T1.Ma_Vt_Sp, 
					ISNULL(MAX(T2.Ten_Vt), ''), 
					ISNULL(MAX(T1.Ma_Size), ''), 
					ISNULL(MAX(T1.Grade_ID), ''), 
					ISNULL(SUM(T1.Num_Bars), 0), 
					ISNULL(SUM(T1.So_Luong), 0), 
					ROW_NUMBER() OVER (ORDER BY T1.Ma_Vt_Sp) AS Stt_In,
					1 
				FROM #T_Detail T1 JOIN R81DmVt T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt
				GROUP BY T1.Ma_Vt_Sp

	UPDATE #T_Detail SET Stt_In = T2.Stt
		FROM #T_Detail T1 JOIN (SELECT Ma_Vt_Sp, Stt0, ROW_NUMBER() OVER (PARTITION BY Ma_Vt_Sp ORDER BY Ma_Vt_Sp, Stt0) AS Stt 
										FROM #T_Detail 
										WHERE Bold = 0) T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt_Sp AND T1.Stt0 = T2.Stt0
		WHERE T1.Bold = 0

	UPDATE #T_Detail SET 
			Stt_In = CASE Stt_In 
						WHEN '1' THEN 'I'
						WHEN '2' THEN 'II'
						WHEN '3' THEN 'III'
						WHEN '4' THEN 'IV'
						WHEN '5' THEN 'V'
						WHEN '6' THEN 'VI'
						WHEN '7' THEN 'VII'
						WHEN '8' THEN 'VIII'
						WHEN '9' THEN 'IX'
						WHEN '10' THEN 'X'
						ELSE ''
					END
			WHERE Bold = 1

	UPDATE T1 SET Ten_Size = UPPER(ISNULL(T2.Ten_Size, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMSIZE T2 WITH(NOLOCK) ON T1.Ma_Size = T2.Ma_Size

	UPDATE T1 SET Grade_Name = UPPER(ISNULL(T2.Grade_Name, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMMACTHEP T2 WITH(NOLOCK) ON T1.Grade_ID = T2.Grade_ID

	--UPDATE #T_PhatSinh SET Ten_Vt_Mac_Thep = N'Các bó thép ' + UPPER(Ten_Vt + REPLICATE(' ', 2)  + Grade_Name) WHERE Bold = 1

	UPDATE #T_Detail SET Num_Barcode = T2.Num_Barcode
		FROM #T_Detail T1 JOIN (SELECT Ma_Vt_Sp, COUNT(Barcode) AS Num_Barcode FROM #T_Detail WHERE Bold = 0 GROUP BY Ma_Vt_Sp) T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt_Sp
		WHERE Bold = 1

	SELECT *
		FROM #T_Header

	SELECT *
		FROM #T_Detail
		ORDER BY Ma_Vt_Sp, Stt0

END
