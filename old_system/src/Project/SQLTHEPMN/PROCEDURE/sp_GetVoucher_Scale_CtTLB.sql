/*Thủ tục trả về bảng Filter
--EXEC sp_GetPH_Scale_Truck_Out 'PXTH', '20150101','20151231', 1
*/
ALTER PROCEDURE [dbo].[sp_GetVoucher_Scale_CtTLB]
(
	@Table_PH VARCHAR(50), 
	@Table_Ct VARCHAR(50), 
	@Stt VARCHAR(15) = '',
	@Ma_Ct_List VARCHAR(5) = '',
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@So_Xe VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',
	@So_Ct1 VARCHAR(20) = '',
	@So_Ct2 VARCHAR(20) = '',
	@Ma_Dt VARCHAR(20) = '',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN	

	DECLARE @_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'

	IF @Ngay_Ct1 <> ''
		SET @_Key = @_Key + ' AND Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''''
	
	IF @Ngay_Ct1 <> ''
		SET @_Key = @_Key + ' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''''
	
	IF @Stt <> ''
		SET @_Key = @_Key + ' AND (Stt = ''' + @Stt + ''')'

	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND So_Xe LIKE ''%' + @So_Xe + '%'''

	IF @So_Xa_Lan_Tau <> ''
		SET @_Key = @_Key + ' AND So_Xa_Lan_Tau LIKE ''%' + @So_Xa_Lan_Tau + '%'''

	IF @So_Ct1 <> ''
		SET @_Key = @_Key + ' AND (So_Ct >= ''' + @So_Ct1 + ''')'	

	IF @So_Ct2 <> ''
		SET @_Key = @_Key + ' AND (So_Ct <= ''' + @So_Ct2 + ''')'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND Ma_Dt = ''' + @Ma_Dt + ''''

	IF @Ma_Ct_List <> ''	
		SET @_Key = @_Key + ' AND (Ma_Ct LIKE ''' + REPLACE(@Ma_Ct_List, ',', ''' OR Ma_Ct LIKE ''') + ''')'

	CREATE TABLE #T_Stt(Stt VARCHAR(15))
	
	EXEC sp_DefaultTable '#T_Stt'
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Stt', '', @_Key
	
	--PH
	SELECT @_SqlExec = 
		'SELECT T1.*, T3.Ten_Dt, T3.Ong_Ba, T4.Ten_Vt AS Ten_Vt_Sp
			FROM ' + @Table_PH + ' T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt 
										LEFT JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt
										LEFT JOIN R81DMVT T4 ON T1.Ma_Vt_Sp = T4.Ma_Vt_Sp
			ORDER BY T1.Ngay_Ct, T1.So_Ct'
	
	EXEC(@_SqlExec)

	--Ct
	SELECT @_SqlExec = 
		'SELECT T1.*, T3.Ngay_Nhap, T3.Length, T3.Num_Lot, T4.Grade_Name, T5.Ten_CL, T6.Ca, T7.Ten_Size, T8.Standard_Name
			FROM ' + @Table_Ct + ' T1 JOIN #T_Stt T2 ON T1.Stt = T2.Stt
									JOIN R81DMBARCODE T3 ON T1.Barcode = T3.Barcode
									LEFT JOIN R81DMMACTHEP T4 ON T3.Grade_ID = T4.Grade_ID
									LEFT JOIN R81DMCL T5 ON T3.Ma_CL = T5.Ma_CL
									LEFT JOIN R81DMCA T6 ON T3.Ma_Ca = T6.Ma_Ca
									LEFT JOIN R81DMSIZE T7 ON T1.Ma_Size = T7.Ma_Size
									LEFT JOIN R81DMSTANDARD T8 ON T3.Standard_ID = T8.Standard_ID'
	EXEC(@_SqlExec)
END 
GO
EXEC sp_GetVoucher_Scale_CtTLB 'R80PH_SCALE', 'R05CTN_BARCODE', '129789', 'PNTLB'