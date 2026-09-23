/*
SET DATEFORMAT DMY
EXEC sp_rptTCB04 '20150401','20150430', ''
*/
--Bao cao Hang qua can 80T
ALTER PROCEDURE sp_rptTCB04
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Dt VARCHAR(20) = '',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SET @_Key = '(0=0) AND (So_Luong_Vao <> 0 AND So_Luong_Ra <> 0) AND (Ma_Vt_Sp = ''CP'')'
	SET @_Key = @_Key + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	CREATE TABLE #T_Ph_Scale(Stt VARCHAR(20))
	EXEC sp_DefaultTable '#T_Ph_Scale'
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Ph_Scale', '', @_Key
	
	SELECT T1.Ma_Dt, CAST('' AS NVARCHAR(200)) AS Ten_Dt, T1.So_Luong
		INTO #T_PhatSinh
		FROM R05CTX_BARCODE T1 JOIN #T_Ph_Scale T2 ON T1.Stt = T2.Stt
	
	EXEC sp_DefaultTable '#T_PhatSinh'
	
	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt

	SELECT CONVERT(VARCHAR, ROW_NUMBER() OVER (ORDER BY Ma_Dt)) AS Stt_Sx , Ma_Dt, MAX(Ten_Dt) AS Ten_Dt, ISNULL(SUM(So_Luong), 0) AS So_Luong, CAST(0 AS BIT) As Bold
		INTO #T_BaoCao
		FROM #T_PhatSinh
		GROUP BY Ma_Dt
	
	EXEC sp_DefaultTable '#T_BaoCao'

	
	INSERT INTO #T_BaoCao(Stt_Sx, Ten_Dt, So_Luong, Bold)
	SELECT 'A', ISNULL((SELECT UPPER(Ten_Vt) FROM R81DMVT WHERE Ma_Vt = 'CP'), ''), SUM(So_Luong), 1
		FROM #T_BaoCao
		WHERE Bold = 0
	
	UPDATE #T_BaoCao SET Ten_Dt = SPACE(2*(2 - 1)) + Ten_Dt WHERE Bold = 0

	SELECT *, So_Luong AS Khoi_Luong
		FROM #T_BaoCao
		ORDER BY Ma_Dt
	

END
GO
