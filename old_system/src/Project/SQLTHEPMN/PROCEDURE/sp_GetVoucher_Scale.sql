/*Thủ tục trả về bảng Filter
--EXEC sp_GetPH_Scale_Truck_Out 'PXTH', '20150101','20151231', 1
*/
ALTER PROCEDURE [dbo].[sp_GetVoucher_Scale]
(
	@Ma_Ct VARCHAR(5) = 'PXTH',
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@So_Xe VARCHAR(20) = '',
	@So_Ct VARCHAR(20) = '',
	@Ma_Dt VARCHAR(20) = '',
	@Duyet BIT = 1,
	@Is_PH BIT = 0,
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN	

	DECLARE @_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'

	SET @_Key = @_Key + ' AND Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''''
	SET @_Key = @_Key + ' AND Ma_Ct = ''' + @Ma_Ct + ''''
	SET @_Key = @_Key + ' AND Duyet = ' + CAST(@Duyet AS CHAR(1))
	
	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND So_Xe LIKE ''%' + @So_Xe + '%'''

	IF @So_Ct <> ''
		SET @_Key = @_Key + ' AND So_Ct LIKE ''%' + @So_Ct + '%'''

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND Ma_Dt = ''' + @Ma_Dt + ''''

	CREATE TABLE #T_Stt(Stt VARCHAR(15))
	
	EXEC sp_DefaultTable '#T_Stt'
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Stt', '', @_Key

	IF @Is_PH = 0
	BEGIN
		--PH
		SELECT @_SqlExec = 
			'SELECT T1.*, T3.Ten_Dt, T3.Ong_Ba, T4.Ten_Vt AS Ten_Vt_Sp
				FROM R80PH_SCALE T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt 
											LEFT JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt
											LEFT JOIN R81DMVT T4 ON T1.Ma_Vt_Sp = T4.Ma_Vt_Sp
				ORDER BY T1.Ngay_Ct, T1.So_Ct'
	
		EXEC(@_SqlExec)

		--Ct
		SELECT @_SqlExec = 
			'SELECT T1.*, T3.Ngay_Sx, T3.Yeild, T3.Tension, T3.ELong, T3.Length, T4.Grade_Name, T5.Ten_CL, T6.Ca, T7.Ten_Vt
				FROM R05CTX_BARCODE T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt
										JOIN R81DMBARCODE T3 ON T1.Barcode = T3.Barcode
										LEFT JOIN R81DMMACTHEP T4 ON T3.Grade_ID = T4.Grade_ID
										LEFT JOIN R81DMCL T5 ON T3.Ma_CL = T5.Ma_CL
										LEFT JOIN R81DMCA T6 ON T3.Ma_Ca = T6.Ma_Ca
										LEFT JOIN R81DmVt T7 ON T1.Ma_Vt = T7.Ma_Vt'
		EXEC(@_SqlExec)
	END
	ELSE
	BEGIN
		--PH
		SELECT T1.*, T3.Ten_Dt, T3.Ong_Ba, T4.Ten_Vt AS Ten_Vt_Sp
				INTO #T_PhatSinh
				FROM R80PH_SCALE T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt 
											LEFT JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt
											LEFT JOIN R81DMVT T4 ON T1.Ma_Vt_Sp = T4.Ma_Vt_Sp
				ORDER BY T1.Ngay_Ct, T1.So_Ct
		
		SELECT	*,
				CAST(0 AS BIT) AS Bold,
				CAST('' AS VARBINARY(MAX)) AS SortPath,
				CAST('' AS VARCHAR(20)) AS Ma_Tg1,
				CAST('' AS VARCHAR(20)) AS Ma_Tg2,
				CAST('' AS VARCHAR(20)) AS Ma_Tg3,
				CAST('' AS VARCHAR(20)) AS ColumnID,
				CAST('' AS NVARCHAR(200)) AS ColumnName
			INTO #T_Header
			FROM #T_PhatSinh
			WHERE 0 = 1

			
			EXEC sp_BuildGroup '#T_PhatSinh', '#T_Header', 'Ngay_Ct', 'So_Luong_Vao, So_Luong_Ra, So_Luong', @Language_Type, @Ma_DvCs

			--Cập nhật phần nhóm
			UPDATE #T_Header SET 
				Ngay_Ct = ColumnID,
				Bold = 1
		
			EXECUTE Sp_Copy_Data '#T_PhatSinh', '#T_Header'

			SELECT * 
				FROM #T_Header
				ORDER BY SortPath, Level, Ngay_Ct

	END
END 
GO
EXEC sp_GetVoucher_Scale 'PXTH', '20150401','20150420', @Is_PH = 1
