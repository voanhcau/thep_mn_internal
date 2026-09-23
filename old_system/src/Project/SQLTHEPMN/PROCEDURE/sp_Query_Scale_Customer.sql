/*Thủ tục trả về bảng Filter
SET DATEFORMAT DMY
EXEC sp_Query_Scale_Customer @Ma_Ct = 'PXTH', @Ngay_Ct1 = '20150528', @Ngay_Ct2 = '20150605', @Is_Ph = 1

*/
ALTER PROCEDURE [dbo].[sp_Query_Scale_Customer]
(
	@Ma_Ct VARCHAR(5) = 'PXTH',
	@Loai_Ct VARCHAR(5) = '',
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@So_Xe VARCHAR(20) = '',
	@So_Ct VARCHAR(20) = '',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',	
	@Duyet BIT = 1,
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN	

	DECLARE @_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'
	
	SET @_Key = @_Key + ' AND Ma_Ct = ''' + @Ma_Ct + ''''

	IF @Loai_Ct <> ''
		SET @_Key = @_Key + ' AND Loai_Ct = ''' + @Loai_Ct + ''''

	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND So_Xe LIKE ''%' + @So_Xe + '%'''

	IF @So_Xa_Lan_Tau <> ''
		SET @_Key = @_Key + ' AND So_Xa_Lan_Tau LIKE ''%' + @So_Xa_Lan_Tau + '%'''

	IF @So_Ct <> ''
		SET @_Key = @_Key + ' AND So_Ct LIKE ''%' + @So_Ct + '%'''

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND Ma_Dt = ''' + @Ma_Dt + ''''

	IF @Ma_Vt_Sp <> ''
		SET @_Key = @_Key + ' AND Ma_Vt_Sp = ''' + @Ma_Vt_Sp + ''''

	CREATE TABLE #T_Stt0(Stt VARCHAR(15), Time_Out_Filter DATE)
	
	EXEC sp_DefaultTable '#T_Stt0'
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Stt0', '', @_Key
	
	UPDATE T1 SET Time_Out_Filter = T2.Time_Out
		FROM #T_Stt0 T1 JOIN R80PH_SCALE T2 ON T1.Stt = T2.Stt
	
	SELECT *
		INTO #T_Stt
		FROM #T_Stt0
		WHERE Time_Out_Filter >= @Ngay_Ct1 AND Time_Out_Filter <= @Ngay_Ct2
	
	EXEC sp_DefaultTable '#T_Stt'

	--PH
	SELECT T1.*, T3.Ten_Dt, T3.Ong_Ba, T4.Ten_Vt AS Ten_Vt_Sp, 
			CAST(0 AS MONEY) AS So_Luong_Cay, 
			CAST(0 AS MONEY) AS So_Luong_Bo, 
			CAST(0 AS MONEY) AS So_Luong_Barcode 
		INTO #T_Header1
		FROM R80PH_SCALE T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt 
									LEFT JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt
									LEFT JOIN R81DMVT T4 ON T1.Ma_Vt_Sp = T4.Ma_Vt
		ORDER BY T1.Ngay_Ct, T1.So_Ct
	
	--Ct
	SELECT T1.*, T3.Ngay_Nhap, T3.Yeild, T3.Tension, T3.ELong, T3.Length, T4.Grade_Name, T5.Ten_CL, T6.Ca, T7.Ten_Vt
		INTO #T_Detail1
		FROM R05CTX_BARCODE T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt
								JOIN R81DMBARCODE T3 ON T1.Barcode = T3.Barcode
								LEFT JOIN R81DMMACTHEP T4 ON T3.Grade_ID = T4.Grade_ID
								LEFT JOIN R81DMCL T5 ON T3.Ma_CL = T5.Ma_CL
								LEFT JOIN R81DMCA T6 ON T3.Ma_Ca = T6.Ma_Ca
								LEFT JOIN R81DmVt T7 ON T1.Ma_Vt = T7.Ma_Vt

	--Cập nhật SL_Cây, SL_Bó
	UPDATE #T_Header1 SET So_Luong_Cay = T2.So_Luong_Cay, 
							So_Luong_Bo = T2.So_Luong_Bo,
							So_Luong_Barcode = T2.So_Luong_Barcode
		FROM #T_Header1 T1 JOIN (SELECT Stt, ISNULL(SUM(Num_Bars), 0) AS So_Luong_Cay, 
											ISNULL(COUNT(*), 0) AS So_Luong_Bo, 
											ISNULL(SUM(So_Luong), 0) AS So_Luong_Barcode 
										FROM #T_Detail1 
										GROUP BY Stt) T2 ON T1.Stt = T2.Stt

	SELECT * FROM #T_Header1
	SELECT * FROM #T_Detail1
END 
