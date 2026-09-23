/*
SET DATEFORMAT DMY
EXEC sp_rptTCB11 '20150501','20150505', @Kieu_Nh = '0'
*/
--Báo cáo chênh lệch Barem - cân 80T
ALTER PROCEDURE [dbo].[sp_rptTCB11]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@So_Xe VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',
	@Kieu_Nh VARCHAR(20) = '0',--0-KHONG NHOM, 3-THEO DOI TUONG, 9-THEO VAT TU, S-SO XE, X-XA LAN
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_Ma_Nhom VARCHAR(20),
			@_RowID INT = 0

	SET @_Key = '(0=0) AND (So_Luong_Vao <> 0 AND So_Luong_Ra <> 0) AND (Ma_Vt_Sp = ''CP'')'
	SET @_Key = @_Key + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'
	SET @_Key = @_Key + ' AND (Stt IN (SELECT Stt_Org FROM R03CTBREM WHERE Ma_Ct LIKE ''BBREM%'' AND Ma_Vt_Sp LIKE ''B3%'' AND Stt_Org <> '''' AND So_Luong_Barem <> 0))'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND (So_Xe LIKE ''%' + @So_Xe + '%'')'

	IF @So_Xa_Lan_Tau <> ''
		SET @_Key = @_Key + ' AND (So_Xa_Lan_Tau LIKE ''%' + @So_Xa_Lan_Tau + '%'')'

	SELECT *
		INTO #T_Ph_Scale
		FROM R80PH_SCALE
		WHERE 0 = 1
	
	EXEC sp_DefaultTable '#T_Ph_Scale'
	
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Ph_Scale', '', @_Key

	CREATE TABLE #T_PhatSinh
	(
		Stt_Sx VARCHAR(20) DEFAULT(''),
		Stt_Org VARCHAR(15) DEFAULT(''),
		So_Ct_Barem VARCHAR(20) DEFAULT(''),
		So_Ct_PCan VARCHAR(20) DEFAULT(''),
		Ma_Dt VARCHAR(20) DEFAULT(''),
		Ten_Dt NVARCHAR(200) DEFAULT(''),
		Ma_Vt_Sp VARCHAR(20) DEFAULT(''),
		Ten_Vt_Sp NVARCHAR(200) DEFAULT(''),
		So_Xe VARCHAR(20) DEFAULT(''),
		So_Xa_Lan_Tau VARCHAR(20) DEFAULT(''),
		So_Bo MONEY DEFAULT(0),
		Num_Bars MONEY DEFAULT(0),
		So_Luong_Can80 MONEY DEFAULT(0),
		So_Luong_80T MONEY DEFAULT(0),
		So_Luong_Barem MONEY DEFAULT(0),
		So_Luong_CL MONEY DEFAULT(0),
		Pt_CL MONEY DEFAULT(0)
	)

	SELECT T1.Stt, T1.Stt_Org, T1.So_Ct AS So_Ct_Barem, T2.So_Ct AS So_Ct_PCan, T1.Ma_Dt, T1.So_Xe, T1.So_Xa_Lan_Tau, T1.Ma_Vt_Sp,
			T2.So_Luong AS So_Luong_80T, T1.So_Luong AS So_Luong_Barem, T1.So_Luong_Cay AS Num_Bars, CAST(0 AS MONEY) AS So_Bo
		INTO #T_CtNX
		FROM R03CTBREM T1 JOIN #T_Ph_Scale T2 ON T1.Stt_Org = T2.Stt
		WHERE T1.Is_Barem = 1 AND T1.Ma_Vt_Sp = CASE WHEN @Ma_Vt_Sp = '' THEN T1.Ma_Vt_Sp ELSE @Ma_Vt_Sp END
	
	EXEC sp_DefaultTable '#T_CtNX'
	
	UPDATE #T_CtNX SET So_Bo = (SELECT ISNULL(COUNT(Barcode), 0)
									FROM R05CTX_BARCODE WITH (NOLOCK) 
									WHERE Stt = #T_CtNX.Stt_Org AND Ma_Vt_Sp = #T_CtNX.Ma_Vt_Sp) 

	--Insert Ct
	INSERT #T_PhatSinh(Stt_Org, So_Ct_Barem, So_Ct_PCan, Ma_Dt, Ma_Vt_Sp, So_Xe, So_Xa_Lan_Tau, So_Bo, Num_Bars, So_Luong_80T, So_Luong_Barem)
	SELECT MAX(Stt_Org), MAX(So_Ct_Barem), So_Ct_PCan, Ma_Dt, Ma_Vt_Sp, So_Xe, So_Xa_Lan_Tau, SUM(So_Bo), SUM(Num_Bars), SUM(So_Luong_Barem), SUM(So_Luong_Barem)
		FROM #T_CtNX
		GROUP BY So_Ct_PCan, Ma_Dt, Ma_Vt_Sp, So_Xe, So_Xa_Lan_Tau
	
	UPDATE T1 SET So_Luong_Can80 = T2.So_Luong
		FROM #T_PhatSinh T1 JOIN #T_Ph_Scale T2 ON T1.Stt_Org = T2.Stt

	UPDATE T1 SET Stt_Sx = T2.Stt_Sx
		FROM #T_PhatSinh T1 JOIN (SELECT ROW_NUMBER() OVER (PARTITION BY Stt_Org ORDER BY (SELECT 1)) AS Stt_Sx, Stt_Org, Ma_Vt_Sp FROM #T_PhatSinh) T2 ON T1.Stt_Org = T2.Stt_Org AND T1.Ma_Vt_Sp = T2.Ma_Vt_Sp

	SELECT DENSE_RANK() OVER (ORDER BY Stt_Org) as Stt_Order, *
		INTO #T_PhatSinhSum
		FROM #T_PhatSinh
	
	SELECT Stt_Order, Stt_Org, CAST('' AS VARCHAR(20)) AS Stt_Sx, MAX(So_Luong_Barem) AS So_Luong, CAST(0 AS MONEY) AS So_Luong_Sum
		INTO #T_PhatSinhSum0
		FROM #T_PhatSinhSum
		GROUP BY Stt_Order, Stt_Org

	UPDATE #T_PhatSinhSum0 SET Stt_Sx = T2.Stt_Sx
		FROM #T_PhatSinhSum0 T1 JOIN #T_PhatSinhSum T2 ON T1.Stt_Order = T2.Stt_Order AND T1.Stt_Org = T2.Stt_Org AND T1.So_Luong = T2.So_Luong_80T
	
	UPDATE T1 SET So_Luong_Sum = T2.So_Luong_Sum
		FROM #T_PhatSinhSum0 T1 JOIN (SELECT Stt_Order, Stt_Org, SUM(So_Luong_Barem) AS So_Luong_Sum
								FROM #T_PhatSinhSum
								WHERE LTRIM(RTRIM(STR(Stt_Order))) + Stt_Org + Stt_Sx  NOT IN(SELECT LTRIM(RTRIM(STR(Stt_Order))) + Stt_Org + Stt_Sx  FROM #T_PhatSinhSum0)
								GROUP BY Stt_Order, Stt_Org) T2 ON T1.Stt_Order = T2.Stt_Order AND T1.Stt_Org = T2.Stt_Org
	
	UPDATE T1 SET So_Luong_80T = So_Luong_Can80 - T2.So_Luong_Sum
		FROM #T_PhatSinhSum T1 JOIN #T_PhatSinhSum0 T2 ON T1.Stt_Order = T2.Stt_Order AND T1.Stt_Org = T2.Stt_Org AND T1.Stt_Sx = T2.Stt_Sx

	UPDATE #T_PhatSinhSum SET So_Luong_CL = So_Luong_Barem - So_Luong_80T, Pt_CL = (So_Luong_Barem - So_Luong_80T) / 100

	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_PhatSinhSum T1 JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_PhatSinhSum T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt

	SELECT *
		INTO #T_BaoCao0
		FROM #T_PhatSinhSum

	SELECT *,
			SPACE(20) AS ColumnID, CAST('' AS NVARCHAR(200)) AS ColumnName,
			CAST(0 AS BIT) AS Bold, 0 AS Level, CAST(0 AS VARBINARY(MAX)) AS SortPath
		INTO #T_BaoCao
		FROM #T_BaoCao0
		WHERE 0 = 1

	EXEC sp_DefaultTable '#T_BaoCao0'
	EXEC sp_DefaultTable '#T_BaoCao'

	SELECT @_Ma_Nhom = dbo.fn_GetMa_Nhom(@Kieu_Nh)

	IF @Kieu_Nh = 's'
		SELECT @_Ma_Nhom = 'So_Xe'
	ELSE IF @Kieu_Nh = 'x'
		SELECT @_Ma_Nhom = 'So_Xa_Lan_Tau'

	IF @_Ma_Nhom <> ''
		EXEC sp_BuildGroup '#T_BaoCao0', '#T_BaoCao', @_Ma_Nhom, 'So_Bo, Num_Bars, So_Luong_80T, So_Luong_Barem, So_Luong_CL, PT_CL', @Language_Type, @Ma_DvCs	

	UPDATE #T_BaoCao SET
		Ma_Dt = ColumnID,
		Ten_Dt = ColumnName,
		Bold = 1
	
	EXECUTE Sp_Copy_Data '#T_BaoCao0', '#T_BaoCao'

	UPDATE #T_BaoCao SET 
				@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
				Stt_Sx = LTRIM(RTRIM(STR(@_RowID)))

	INSERT INTO #T_BaoCao(Ten_Dt, So_Bo, Num_Bars, So_Luong_80T, So_Luong_Barem, So_Luong_CL, Pt_CL, Bold)
	SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), ISNULL(SUM(So_Bo), 0), ISNULL(SUM(Num_Bars), 0), ISNULL(SUM(So_Luong_80T), 0),
			ISNULL(SUM(So_Luong_Barem), 0), ISNULL(SUM(So_Luong_CL), 0), ISNULL(SUM(Pt_CL), 0), 1
		FROM #T_BaoCao
		WHERE Bold = 0
	
	SELECT *, So_Luong_80T AS Trong_Luong_80T, So_Luong_Barem AS Trong_Luong_Barem, So_Luong_CL AS Trong_Luong_CL
		FROM #T_BaoCao
		ORDER BY SortPath, Level, So_Ct_PCan
		
	
END
