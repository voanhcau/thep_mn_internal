/*
SET DATEFORMAT DMY
EXEC sp_rptTCB15 '20150401','20150430', ''
*/
--Bảng kê trả lại barcode
ALTER PROCEDURE [dbo].[sp_rptTCB17]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@So_Ct1 VARCHAR(20) = '',
	@So_Ct2 VARCHAR(20) = '',
	@Ma_Dt VARCHAR(20) = '',
	@So_Xe VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',
	@Kieu_Nh CHAR(1) = '3',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0,
			@_Ma_Nhom VARCHAR(20)

	SET @_Key = '(0=0)'
	SET @_Key = @_Key + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'
	SET @_Key = @_Key + ' AND (Ma_Ct LIKE ''PXTH%'')'
	
	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	IF @So_Ct1 <> ''
		SET @_Key = @_Key + ' AND (So_Ct >= ''' + @So_Ct1 + ''')'	
		
	IF @So_Ct2 <> ''
		SET @_Key = @_Key + ' AND (So_Ct <= ''' + @So_Ct2 + ''')'

	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND (So_Xe LIKE ''%' + @So_Xe + '%'')'

	IF @So_Xa_Lan_Tau <> ''
		SET @_Key = @_Key + ' AND (So_Xa_Lan_Tau LIKE ''%' + @So_Xa_Lan_Tau + '%'')'

	SELECT *
		INTO #T_Header
		FROM R80PH_SCALE
		WHERE 0 = 1
	
	EXEC sp_DefaultTable '#T_Header'
	
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Header', '', @_Key
	
	SELECT T1.*, T2.So_Xe, T2.So_Xa_Lan_Tau, CAST('' AS NVARCHAR(400)) AS Ten_Size, CAST('' AS NVARCHAR(200)) AS Ten_Dt, CAST('' AS VARCHAR(20)) AS No_Melt,
			CAST('' AS VARCHAR(20)) AS Grade_ID, CAST('' AS NVARCHAR(200)) AS Grade_Name,
			CAST('' AS VARCHAR(20)) AS Standard_ID, CAST('' AS NVARCHAR(200)) AS Standard_Name,
			CAST('' AS VARCHAR(20)) AS Ma_Ca, CAST('' AS VARCHAR(20)) AS Ca, CAST('' AS MONEY) AS Length, CAST('' AS DATE) AS Ngay_Nhap, CAST('' AS VARCHAR(20)) AS Num_Lot
		INTO #T_PhatSinh
		FROM R05CTX_BARCODE T1 LEFT JOIN #T_Header T2 ON T1.Stt = T2.Stt
		WHERE T2.Stt IS NOT NULL
		
	EXEC sp_DefaultTable '#T_PhatSinh'
	
	UPDATE #T_PhatSinh SET 
			Ten_Size = T2.Ten_Size
		FROM #T_PhatSinh T1 JOIN R81DMSize T2 ON T1.Ma_Size = T2.Ma_Size
		
	UPDATE #T_PhatSinh SET 
			Ten_Dt = T2.Ten_Dt 
		FROM #T_PhatSinh T1 JOIN R81DmDt T2 ON T1.Ma_Dt = T2.Ma_Dt 	
	
	UPDATE T1 SET
			No_Melt = T2.No_Melt,
			Grade_ID = T2.Grade_ID,
			Standard_ID = T2.Standard_ID,
			Ma_Ca = T2.Ma_Ca,
			Length = T2.Length,
			Ngay_Nhap = T2.Ngay_Nhap,
			Num_Lot = T2.Num_Lot
		FROM #T_PhatSinh T1 LEFT JOIN R81DMBARCODE T2 ON T1.Barcode = T2.Barcode
		WHERE T2.Barcode IS NOT NULL

	UPDATE T1 SET Grade_Name = T2.Grade_Name
		FROM #T_PhatSinh T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Standard_Name = T2.Standard_Name
		FROM #T_PhatSinh T1 JOIN R81DMSTANDARD T2 ON T1.Standard_ID = T2.Standard_ID

	UPDATE T1 SET Ca = T2.Ca, Ngay_Nhap = CASE WHEN T2.Ngay_Sx IS NULL THEN T1.Ngay_Nhap ELSE T2.Ngay_Sx END
		FROM #T_PhatSinh T1 JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca

	SELECT	Stt, Barcode, Ngay_Ct, Ma_Ct, So_Ct, MAX(Dien_Giai) AS Dien_Giai, Ma_Dt,  MAX(Ten_Dt) AS Ten_Dt, Ma_Size, MAX(Ten_Size) AS Ten_Size, So_Xe, So_Xa_Lan_Tau,
			Grade_ID, MAX(Grade_Name) AS Grade_Name, Standard_ID, MAX(Standard_Name) AS Standard_Name, Ca, Ngay_Nhap, No_Melt,
			SUM(Num_Bars) AS Num_Bars, SUM(So_Luong) AS So_Luong,
			SPACE(20) AS ColumnID, CAST('' AS NVARCHAR(200)) AS ColumnName,
			CAST(0 AS BIT) AS Bold, 0 AS Level, CAST(0 AS VARBINARY(MAX)) AS SortPath 
		INTO #T_BaoCao0
		FROM #T_PhatSinh
		GROUP BY Stt, Barcode, Ngay_Ct, Ma_Ct, So_Ct, Ma_Dt, So_Xe, So_Xa_Lan_Tau, Ma_Size, Grade_ID, Standard_ID, Ca, Ngay_Nhap, No_Melt
	
	SELECT * 
		INTO #T_BaoCao 
		FROM #T_BaoCao0 
		WHERE 0 = 1
	
	EXECUTE sp_DefaultTable '#T_BaoCao'

	SELECT @_Ma_Nhom = dbo.fn_GetMa_Nhom(@Kieu_Nh)
	IF @Kieu_Nh = 's'
		SELECT @_Ma_Nhom = 'So_Xe'
	ELSE IF @Kieu_Nh = 'x'
		SELECT @_Ma_Nhom = 'So_Xa_Lan_Tau'

	IF @_Ma_Nhom <> ''
		EXEC sp_BuildGroup '#T_BaoCao0', '#T_BaoCao', @_Ma_Nhom, 'So_Luong, Num_Bars', @Language_Type, @Ma_DvCs	
	
	UPDATE #T_BaoCao SET
		Ma_Dt = ColumnID,
		Ten_Dt = ColumnName,
		Dien_Giai = ColumnName,
		Bold = 1
	
	EXECUTE Sp_Copy_Data '#T_BaoCao0', '#T_BaoCao'
	
	INSERT #T_BaoCao(Dien_Giai, Num_Bars, So_Luong, SortPath, Level, Bold)
		SELECT	dbo.fn_Getlanguage('Tong_Cong', @Language_Type), ISNULL(SUM(Num_Bars), 0) AS Num_Bars ,ISNULL(SUM(So_Luong), 0) AS So_Luong,
				MAX(SortPath) + CAST(1 AS VARBINARY(MAX)), 0, 1	
			FROM #T_BaoCao
			WHERE Bold <> 1

	SELECT * 
		FROM #T_BaoCao
		ORDER BY SortPath, Level, Ngay_Ct, Ma_Ct, So_Ct, Ma_Dt
	
END
