/*
SET DATEFORMAT DMY
EXEC sp_rptTCB01 '20150401','20150430'
*/
--Thống kê số liệu hang qua can
ALTER PROCEDURE [dbo].[sp_rptTCB01]
(
	@Ngay_Ct1 DATETIME = '19000101',
	@Ngay_Ct2 DATETIME = '19000101',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@So_Ct VARCHAR(20) = '',
	@So_Xe VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',
	@Is_Edit CHAR(1) = '0',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SET @_Key = '(0=0) AND (So_Luong_Vao <> 0 AND So_Luong_Ra <> 0)'
	SET @_Key = @_Key + ' AND (Time_Out >= ''' + CONVERT(VARCHAR, @Ngay_Ct1, 9) + ''' AND Time_Out <= ''' + CONVERT(VARCHAR, @Ngay_Ct2, 9) + ''')'

	IF @Is_Edit <> '' AND @Is_Edit = '1'
		SET @_Key = @_Key + ' AND (Ly_Do <> '''')'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	IF @Ma_Vt_Sp <> ''
		SET @_Key = @_Key + ' AND (Ma_Vt_Sp = ''' + @Ma_Vt_Sp + ''')'

	IF @So_Ct <> ''
		SET @_Key = @_Key + ' AND (So_Ct = ''' + @So_Ct + ''')'

	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND (So_Xe = ''' + @So_Xe + ''')'

	IF @So_Xa_Lan_Tau <> ''
		SET @_Key = @_Key + ' AND (So_Xa_Lan_Tau = ''' + @So_Xa_Lan_Tau + ''')'

	SELECT	CAST('' AS VARCHAR(20)) AS Stt_Sx, Stt, Ma_Ct, So_Ct, Ngay_Ct, Ma_Dt, CAST('' AS NVARCHAR(100)) AS Ten_Dt,
			Ma_Dt_CbNv_Vao, CAST('' AS NVARCHAR(100)) AS Ten_Dt_CbNV_Vao,
			Ma_Dt_CbNv_Ra, CAST('' AS NVARCHAR(100)) AS Ten_Dt_CbNV_Ra,
			Ma_Vt_Sp, CAST('' AS NVARCHAR(200)) AS Ten_Vt_Sp,
			Dien_Giai, So_Xe, So_Xa_Lan_Tau, So_Luong_Vao, So_Luong_Ra, So_Luong, Time_In, Time_Out,
			Duyet, Ly_Do, SL_Xe_Hang, TSL_Barcode, TSo_Barcode, SL_QDinh, SL_CL, Ghi_Chu_QDinh, CAST(0 AS BIT) AS Bold
		INTO #T_PhatSinh
		FROM R80PH_SCALE
		WHERE 0 = 1
	
	EXEC sp_DefaultTable '#T_PhatSinh'
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_PhatSinh', '', @_Key
	
	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_PhatSinh T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt
	
	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Vao = ISNULL(T2.Ten_Dt, '')
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv_Vao = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Ra = ISNULL(T2.Ten_Dt, '')
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv_Ra = T2.Ma_Dt

	SELECT ROW_NUMBER() OVER(ORDER BY Stt) AS Stt_Sx, Stt
		INTO #T_RowID
		FROM #T_PhatSinh
	
	UPDATE T1 SET Stt_Sx = T2.Stt_Sx
		FROM #T_PhatSinh T1 JOIN #T_RowID T2 ON T1.Stt = T2.Stt

	INSERT #T_PhatSinh(Ten_Dt, So_Xe, So_Xa_Lan_Tau, So_Luong_Vao, So_Luong_Ra, So_Luong, Bold)
	SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), CONVERT(VARCHAR, ISNULL(COUNT(So_Xe), 0)) + ' xe', CONVERT(VARCHAR, (ISNULL((SELECT COUNT(So_Xa_Lan_Tau) FROM #T_PhatSinh WHERE So_Xa_Lan_Tau <> ''), 0))) + ' XL - Tàu', ISNULL(SUM(So_Luong_Vao), 0), ISNULL(SUM(So_Luong_Ra), 0), ISNULL(SUM(So_Luong), 0), 1
		FROM #T_PhatSinh

	SELECT *, Dien_Giai AS Ghi_Chu, So_Ct AS So_Phieu, So_Luong AS Khoi_Luong
		FROM #T_PhatSinh
		ORDER BY Stt, Ngay_Ct

END