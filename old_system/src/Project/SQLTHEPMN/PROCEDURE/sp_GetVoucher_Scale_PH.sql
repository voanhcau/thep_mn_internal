/*Thủ tục trả về bảng Filter
--EXEC sp_GetPH_Scale_Truck_Out 'PXTH', '20150101','20151231', 1
*/
ALTER PROCEDURE [dbo].[sp_GetVoucher_Scale_PH]
(
	@Ma_Ct VARCHAR(5) = '',
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@Duyet BIT = 1
)
AS
BEGIN	

	DECLARE @_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'

	SET @_Key = @_Key + ' AND Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''''
	SET @_Key = @_Key + ' AND Ma_Ct = ''' + @Ma_Ct + ''''
	SET @_Key = @_Key + ' AND Duyet = ' + CAST(@Duyet AS CHAR(1))
	
	CREATE TABLE #T_Header(Stt VARCHAR(15), Ma_Dt VARCHAR(20), Ma_Vt_Sp VARCHAR(20), Ma_Dt_CbNv_Vao VARCHAR(20), Ma_Dt_CbNv_Ra VARCHAR(20))
	
	SET @_SQLExec =
		'SELECT Stt, Ma_Dt, Ma_Vt_Sp, Ma_Dt_CbNv_Vao, Ma_Dt_CbNv_Ra
			FROM R80PH_SCALE WITH(NOLOCK)
			WHERE ' + @_Key
	
	INSERT #T_Header(Stt, Ma_Dt, Ma_Vt_Sp, Ma_Dt_CbNv_Vao, Ma_Dt_CbNv_Ra)
	EXEC(@_SQLExec)

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Vt') IS NULL
		ALTER TABLE #T_Header ADD Ten_Vt NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt_CbNv_Vao') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt_CbNv_Vao NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt_CbNv_Ra') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt_CbNv_Ra NVARCHAR(200) NOT NULL DEFAULT('')

	UPDATE T1 SET Ten_Dt = T2.Ten_Dt
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Vt = T2.Ten_Vt
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	UPDATE T1 SET Ten_Dt_CbNv_Vao = T2.Ten_Dt
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Vao = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Ra = T2.Ten_Dt
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMDT T2 WITH(NOLOCK) ON T1.Ma_Dt_CbNv_Ra = T2.Ma_Dt

	--PH
	SELECT T1.*, T2.Ten_Dt, T2.Ten_Vt, T2.Ten_Dt_CbNv_Vao, T2.Ten_Dt_CbNv_Ra
		FROM R80PH_SCALE T1 WITH(NOLOCK)
				JOIN #T_Header T2 WITH(NOLOCK) ON T1.Stt = T2.Stt
END 
GO
--EXEC sp_GetVoucher_Scale_PH 'PXTH', '20150311','20150319', 1
