ALTER PROCEDURE [dbo].[sp_PrintTruck_In_Out]
(
	@Truck_In_Out VARCHAR(3) = '',
	@Ma_Ct VARCHAR(5) = '',
	@Stt VARCHAR(15) = '',
	@Language_Type CHAR(1) = 'V'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0=0)'

	IF @Ma_Ct <> ''
		SET @_Key = @_Key + ' AND Ma_Ct = ''' + @Ma_Ct + ''''

	IF @Stt <> ''
		SET @_Key = @_Key + ' AND Stt = ''' + @Stt + ''''

	IF @Truck_In_Out = 'IN'
		SET @_Key = @_Key + ' AND So_Luong_Vao > 0 AND So_Luong_Ra = 0 AND Duyet = 0'
	ELSE IF @Truck_In_Out = 'OUT'
		SET @_Key = @_Key + ' AND So_Luong_Vao > 0 AND So_Luong_Ra > 0 AND Duyet = 1'

	--PRINT @_Key
	--RETURN
	CREATE TABLE #T_PH_Scale(Stt VARCHAR(15), Ma_Dt VARCHAR(20), Ma_Vt_Sp VARCHAR(20), Ma_Dt_CbNv_Vao VARCHAR(20), Ma_Dt_CbNv_Ra VARCHAR(20))

	SET @_SQLExec =
		'SELECT Stt, Ma_Dt, Ma_Vt_Sp, Ma_Dt_CbNv_Vao, Ma_Dt_CbNv_Ra
			FROM R80PH_SCALE WITH(NOLOCK)
			WHERE ' + @_Key
	
	INSERT #T_PH_Scale(Stt, Ma_Dt, Ma_Vt_Sp, Ma_Dt_CbNv_Vao, Ma_Dt_CbNv_Ra)
	EXEC(@_SQLExec)

	IF COL_LENGTH('TempDB..#T_PH_Scale', 'Ten_Dt') IS NULL
		ALTER TABLE #T_PH_Scale ADD Ten_Dt NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_PH_Scale', 'Ten_Vt_Sp') IS NULL
		ALTER TABLE #T_PH_Scale ADD Ten_Vt_Sp NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_PH_Scale', 'Ten_Dt_CbNv_Vao') IS NULL
		ALTER TABLE #T_PH_Scale ADD Ten_Dt_CbNv_Vao NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_PH_Scale', 'Ten_Dt_CbNv_Ra') IS NULL
		ALTER TABLE #T_PH_Scale ADD Ten_Dt_CbNv_Ra NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_PH_Scale', 'So_Luong_Xe_Hang') IS NULL
		ALTER TABLE #T_PH_Scale ADD So_Luong_Xe_Hang MONEY NOT NULL DEFAULT(0)
		
	IF COL_LENGTH('TempDB..#T_PH_Scale', 'So_Luong_Xe_Khong') IS NULL
		ALTER TABLE #T_PH_Scale ADD So_Luong_Xe_Khong MONEY NOT NULL DEFAULT(0)

	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_PH_Scale T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_PH_Scale T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	UPDATE T1 SET Ten_Dt_CbNv_Vao = T2.Ten_Dt
		FROM #T_PH_Scale T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Vao = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Ra = T2.Ten_Dt
		FROM #T_PH_Scale T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Ra = T2.Ma_Dt

	SELECT T1.*,
			T2.Ten_Dt, T2.Ten_Vt_Sp, T2.Ten_Dt_CbNv_Vao, T2.Ten_Dt_CbNv_Ra, CASE WHEN T1.Loai_Ct = '1' THEN N'NHẬP' ELSE N'XUẤT' END AS Loai_Nx,
			CASE WHEN So_Luong_Vao > So_Luong_Ra THEN So_Luong_Vao ELSE So_Luong_Ra END AS So_Luong_Co_Hang,
			CASE WHEN So_Luong_Vao > So_Luong_Ra THEN So_Luong_Ra ELSE So_Luong_Vao END AS So_Luong_Khong_Hang,
			CASE WHEN T1.Can <> '' AND T1.Can = 'CANA' THEN N'CÂN A' ELSE CASE WHEN T1.Can <> '' AND T1.Can = 'CANB' THEN  N'CÂN B' ELSE '' END END AS Ten_Can
		FROM R80PH_SCALE T1 WITH(NOLOCK)
				JOIN #T_PH_Scale T2 WITH(NOLOCK) ON T1.Stt = T2.Stt

END
--EXEC sp_PrintTruck_In_Out 'IN', 'PXTH', '7'
--SELECT * FROM R80PH_SCALE