/*
SET DATEFORMAT DMY
EXEC sp_rptTCB07 '20150401','20150430', ''
*/
--Báo cáo xuất hàng theo khách hàng
ALTER PROCEDURE [dbo].[sp_rptTCB07]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_Vt VARCHAR(20) = '',
	@Kieu_Nh VARCHAR(20) = '0',--0-KHONG NHOM, 3-THEO DOI TUONG, 9-THEO VAT TU
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_Ma_Nhom VARCHAR(20),
			@_RowID INT = 0

	SET @_Key = '(0=0) AND (Is_80TAN = 1)'
	SET @_Key = @_Key + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'
	SET @_Key = @_Key + ' AND (Stt_Org IN (SELECT Stt FROM R80PH_SCALE WHERE Ma_Ct LIKE ''PXTH%''))'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	IF @Ma_Vt <> ''
		SET @_Key = @_Key + ' AND (Ma_Vt = ''' + @Ma_Vt + ''')'

	SELECT *
		INTO #T_CtBrem
		FROM R03CTBREM
		WHERE 0 = 1
	
	EXEC sp_DefaultTable '#T_CtBrem'
	
	EXEC sp_Copy_Data 'R03CTBREM', '#T_CtBrem', '', @_Key
	
	CREATE TABLE #T_PhatSinh
	(
		Stt VARCHAR(15) DEFAULT(''),
		Stt_Org VARCHAR(15) DEFAULT(''),
		So_Ct_Barem VARCHAR(20) DEFAULT(''),
		So_Ct_PCan VARCHAR(20) DEFAULT(''),
		Ma_Dt VARCHAR(20) DEFAULT(''),
		Ten_Dt NVARCHAR(200) DEFAULT(''),
		Ma_Vt VARCHAR(20) DEFAULT(''),
		Ten_Vt NVARCHAR(200) DEFAULT(''),
		So_Xe VARCHAR(20) DEFAULT(''),
		So_Xa_Lan_Tau VARCHAR(20) DEFAULT(''),
		So_Bo MONEY DEFAULT(0),
		Num_Bars MONEY DEFAULT(0),
		So_Luong_Barcode MONEY DEFAULT(0),
		So_Luong_80T MONEY DEFAULT(0),
		So_Luong_CL MONEY DEFAULT(0),
		Pt_CL MONEY DEFAULT(0)
	)

	INSERT #T_PhatSinh(Stt, Stt_Org, So_Ct_Barem, Ma_Dt, Ma_Vt, So_Xe, So_Xa_Lan_Tau, Num_Bars, So_Luong_Barcode, So_Luong_80T)
	SELECT Stt, Stt_Org, So_Ct, Ma_Dt, Ma_Vt, So_Xe, So_Xa_Lan_Tau, So_Luong_Cay, So_Luong_Barcode, So_Luong_Can
		FROM #T_CtBrem

	EXEC sp_DefaultTable '#T_PhatSinh'
	
	UPDATE T1 SET So_Ct_PCan = T2.So_Ct
		FROM #T_PhatSinh T1 JOIN R80PH_SCALE T2 ON T1.Stt_Org = T2.Stt

	UPDATE #T_PhatSinh SET So_Bo = (SELECT ISNULL(COUNT(Barcode), 0)
									FROM R05CTX_BARCODE WITH (NOLOCK) 
									WHERE Stt = #T_PhatSinh.So_Ct_PCan AND Ma_Vt_Sp = #T_PhatSinh.Ma_Vt) 
	
	UPDATE T1 SET Ten_Dt = UPPER(T2.Ten_Dt)
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Vt = UPPER(T2.Ten_Vt)
		FROM #T_PhatSinh T1 JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt = T2.Ma_Vt

	UPDATE #T_PhatSinh SET So_Luong_CL = So_Luong_80T - So_Luong_Barcode
	UPDATE #T_PhatSinh SET Pt_CL = (So_Luong_80T - So_Luong_Barcode) / 100

	SELECT *
		INTO #T_BaoCao0
		FROM #T_PhatSinh

	SELECT *,
			SPACE(20) AS ColumnID, CAST('' AS NVARCHAR(200)) AS ColumnName,
			CAST(0 AS BIT) AS Bold, 0 AS Level, CAST(0 AS VARBINARY(MAX)) AS SortPath
		INTO #T_BaoCao
		FROM #T_BaoCao0
		WHERE 0 = 1

	EXEC sp_DefaultTable '#T_BaoCao0'
	EXEC sp_DefaultTable '#T_BaoCao'

	SELECT @_Ma_Nhom = dbo.fn_GetMa_Nhom(@Kieu_Nh)

	IF @_Ma_Nhom <> ''
		EXEC sp_BuildGroup '#T_BaoCao0', '#T_BaoCao', @_Ma_Nhom, 'So_Bo, Num_Bars, So_Luong_Barcode, So_Luong_80T, So_Luong_CL, PT_CL', @Language_Type, @Ma_DvCs	

	UPDATE #T_BaoCao SET
		Ma_Dt = ColumnID,
		Ten_Dt = ColumnName,
		Bold = 1
	
	EXECUTE Sp_Copy_Data '#T_BaoCao0', '#T_BaoCao'

	INSERT INTO #T_BaoCao(Ten_Dt, So_Bo, Num_Bars, So_Luong_Barcode, So_Luong_80T, So_Luong_CL, Pt_CL, Bold)
	SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), ISNULL(SUM(So_Bo), 0), ISNULL(SUM(Num_Bars), 0), ISNULL(SUM(So_Luong_Barcode), 0), ISNULL(SUM(So_Luong_80T), 0), ISNULL(SUM(So_Luong_CL), 0), ISNULL(SUM(Pt_CL), 0), 1
		FROM #T_BaoCao
		WHERE Bold = 0
	
	SELECT *, So_Luong_Barcode AS Trong_Luong_Barcode, So_Luong_80T AS Trong_Luong_80T, So_Luong_CL AS Trong_Luong_CL
		FROM #T_BaoCao
		ORDER BY SortPath, Level, So_Ct_Barem
	
END