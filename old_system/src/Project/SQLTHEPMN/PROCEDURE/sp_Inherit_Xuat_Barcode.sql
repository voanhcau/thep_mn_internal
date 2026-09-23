/*
SET DATEFORMAT DMY
sp_Inherit_BREM @Ngay_Ct1 = '20150601', @Ngay_Ct2 = '20150630', @Is_Inherited = 1, @So_Ct = '126810'
*/
/*
SET DATEFORMAT DMY
sp_Inherit_BREM @Ngay_Ct1 = '20150601', @Ngay_Ct2 = '20150630', @Is_Inherited = 1, @So_Ct = '126810'
*/
ALTER PROCEDURE [dbo].[sp_Inherit_Xuat_Barcode]
(
	@Ma_Ct_Source VARCHAR(20)= 'PXTH',
	@Stt VARCHAR(15) = '',
	@Ngay_Ct1 DATETIME = '',
	@Ngay_Ct2 DATETIME = '',
	@So_Ct VARCHAR(300)= '',
	@Ma_Size VARCHAR(20) = '',
	@Ma_Dt VARCHAR(20) = '',
	@So_Xe VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',
	@Is_Inherited BIT ='1',
	@Ma_DvCs VARCHAR(5) = 'A01' 
)
--WITH ENCRYPTION
AS

	DECLARE @_Key NVARCHAR(1000) = '1 = 1',
			@_Key_HD NVARCHAR(1000) = '1 = 1',
			@_SQLExec NVARCHAR(MAX) = '',
			@_Table_Source VARCHAR(20),
			@_Table_Dest VARCHAR(20)
	
	SELECT @_Table_Source = (SELECT Table_Ct FROM R00DMCT WHERE Ma_Ct = @Ma_Ct_Source)		

	IF (@So_Ct <> '')
		SELECT	@_Key = @_Key + ' AND (So_Ct LIKE ''' + REPLACE(@So_Ct,',',''' OR So_Ct LIKE ''') + '%'')'
	
	SELECT	@_Key = @_Key + ' AND (Ngay_Ct BETWEEN ''' +CAST(@Ngay_Ct1 AS VARCHAR(11)) + ''' AND ''' +CAST(@Ngay_Ct2 AS VARCHAR(11)) + ''')'

	IF (@Stt <> '')
		SELECT @_Key = @_Key + ' AND (Stt = ''' + @Stt + ''')'

	IF (@Ma_Dt <> '')
		SELECT	@_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'
		
	IF (@Ma_Size <> '')
		SELECT	@_Key = @_Key + ' AND (Ma_Size LIKE ''' + @Ma_Size + '%'')'
	
	IF (@Ma_DvCs <> '')
		 SELECT	@_Key = @_Key + ' AND (Ma_DvCs = ''' + @Ma_DvCs + ''')'
	
	IF @Is_Inherited = '1'
		SET @_Key = @_Key + 'AND Stt NOT IN (SELECT Stt_Org FROM R05CTN_BARCODE WHERE Stt_Org <> '''')'

	SELECT *
		INTO #T_PhatSinh
		FROM R05CTX_BARCODE
		WHERE 0 = 1

	EXEC sp_Copy_Data @_Table_Source, '#T_PhatSinh', '', @_Key
	
	SELECT T1.*, T2.Grade_ID, T2.Standard_ID, T2.Ma_CL, T2.Num_Lot, T2.Ma_Ca,
			CAST('' AS NVARCHAR(200)) AS Ten_Size, CAST('' AS NVARCHAR(200)) AS Grade_Name, Length, 
			CAST('' AS NVARCHAR(200)) AS Standard_Name, CAST('' AS NVARCHAR(200)) AS Ten_CL, CAST('' AS NVARCHAR(200)) AS Ca , CAST('19000101' AS DATE) AS Ngay_Nhap,
			CAST('' AS VARCHAR(20)) AS So_Xe, CAST('' AS VARCHAR(20)) AS So_Xa_Lan_Tau, CAST('' AS VARCHAR(20)) AS Ma_Vt_Sp_PH  
		INTO #T_Detail0
		FROM #T_PhatSinh T1 LEFT JOIN R81DMBARCODE T2 ON T1.Barcode = T2.Barcode
		WHERE T2.Barcode IS NOT NULL

	UPDATE T1 SET So_Xe = T2.So_Xe, So_Xa_Lan_Tau = T2.So_Xa_Lan_Tau, Ma_Vt_Sp_PH = T2.Ma_Vt_Sp
		FROM #T_Detail0 T1 LEFT JOIN R80PH_SCALE T2 ON T1.Stt = T2.Stt

	SELECT *
		INTO #T_Detail
		FROM #T_Detail0
		WHERE So_Xe LIKE CASE WHEN @So_Xe <> '' THEN '%' + @So_Xe + '%' ELSE So_Xe END
			AND So_Xa_Lan_Tau LIKE CASE WHEN @So_Xa_Lan_Tau <> '' THEN '%' + @So_Xa_Lan_Tau + '%' ELSE So_Xa_Lan_Tau END 

	UPDATE T1 SET Ten_Size = T2.Ten_Size
		FROM #T_Detail T1 JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size

	UPDATE T1 SET Grade_Name = T2.Grade_Name
		FROM #T_Detail T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Standard_Name = T2.Standard_Name
		FROM #T_Detail T1 JOIN R81DMSTANDARD T2 ON T1.Standard_ID= T2.Standard_ID

	UPDATE T1 SET Ten_CL = T2.Ten_CL
		FROM #T_Detail T1 JOIN R81DMCL T2 ON T1.Ma_CL= T2.Ma_CL

	UPDATE T1 SET Ca = T2.Ca, Ngay_Nhap = T2.Ngay_Sx
		FROM #T_Detail T1 JOIN R81DMCA T2 ON T1.Ma_Ca= T2.Ma_Ca

	SELECT CAST(1 AS BIT) AS Chon, *
		FROM #T_Detail
		ORDER BY Stt0

RETURN
GO
--EXEC sp_Inherit_Xuat_Barcode @Ngay_Ct1 = '20150715', @Ngay_Ct2 = '20150715', @Is_Inherited = 1, @So_Ct = '129021'