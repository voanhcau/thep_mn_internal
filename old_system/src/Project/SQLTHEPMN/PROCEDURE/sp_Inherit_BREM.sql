/*
SET DATEFORMAT DMY
sp_Inherit_BREM @Ngay_Ct1 = '20150601', @Ngay_Ct2 = '20150630', @Is_Inherited = 1, @So_Ct = '126810'
*/
ALTER PROCEDURE [dbo].[sp_Inherit_BREM]
(
	@Ma_Ct_Source VARCHAR(20)= 'PXTH',
	@Ngay_Ct1 DATETIME = '',
	@Ngay_Ct2 DATETIME = '',
	@So_Ct VARCHAR(300)= '',
	@Ma_Bp VARCHAR(20) = '',
	@Ma_Vt VARCHAR(20) = '',
	@Ma_Nh_Vt VARCHAR(20) = '',	
	@Ma_Kho VARCHAR(20) = '',
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

	IF (@Ma_Bp <> '')
		SELECT	@_Key = @_Key + ' AND (Ma_Bp = ''' + @Ma_Bp + ''')'
			
	IF (@Ma_Dt <> '')
		SELECT	@_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'
		
	IF (@Ma_Vt <> '')
		SELECT	@_Key = @_Key + ' AND (Ma_Vt LIKE ''' + @Ma_Vt + '%'')'
	
	IF @Ma_Nh_Vt <> ''	
		SET @_Key = @_Key + ' AND (Ma_Vt IN (SELECT Ma_Vt FROM  R81DMVT 
												WHERE Ma_Nh_Vt IN 
														(SELECT Ma_Nh_Vt 
															FROM dbo.fn_GetMa_Nh_Vt_List(''' + @Ma_Nh_Vt + ''', 1))))'	
	IF (@Ma_DvCs <> '')
		 SELECT	@_Key = @_Key + ' AND (Ma_DvCs = ''' + @Ma_DvCs + ''')'
	
	IF @Is_Inherited = '1'
		SET @_Key = @_Key +'AND Stt NOT IN (SELECT Stt_Org FROM R03CTBREM WHERE Stt_Org <> '''') AND Ngay_Ct >''20150503'''
	
	
	CREATE TABLE #T_PhatSinh
	(
		Ma_Ct VARCHAR(5),
		Ngay_Ct DATE,
		Stt VARCHAR(15),
		So_Ct VARCHAR(20),
		Barcode VARCHAR(50),
		Ma_Dt VARCHAR(20),
		Ma_Size VARCHAR(20),
		Dvt VARCHAR(20),
		Ma_Vt_Sp VARCHAR(20),
		Grade_ID VARCHAR(20),
		Standard_ID VARCHAR(20),
		Bar_Weight MONEY,
		Length MONEY,
		Num_Bars MONEY,
		So_Luong MONEY
	)
	
	--SELECT * FROM R05CTX_BARCODE WHERE 
	--(Ngay_Ct BETWEEN '20150601' AND '20150630') AND (Ma_DvCs = 'A01')AND Stt NOT IN (SELECT Stt_Org FROM R03CTBREM WHERE Stt_Org <> '') AND Ngay_Ct >'20150503'

	EXEC sp_Copy_Data @_Table_Source, '#T_PhatSinh', '', @_Key
	
	UPDATE T1 SET
			Standard_ID = T2.Standard_ID,
			Grade_ID = T2.Grade_ID,
			Length = T2.Length
		FROM #T_PhatSinh T1 JOIN R81DMBARCODE T2 ON T1.Barcode = T2.Barcode 
	
	UPDATE T1 SET Bar_Weight = T2.Bar_Weight
		FROM #T_PhatSinh T1 JOIN R81DMBAREMS T2 ON T1.Ma_Size = T2.Ma_Size AND T1.Grade_ID = T2.Grade_ID
				
	SELECT T1.Ma_Ct, T1.Ngay_Ct, T1.Stt, T1.So_Ct, T1.Ma_Vt_Sp, T2.So_Xe, T2.So_Xa_Lan_Tau, MAX(T2.Ma_Dt) AS Ma_Dt,
		ISNULL(MAX(T1.Bar_Weight), 0) AS Bar_Weight,
		ISNULL(MAX(T1.Length), 0) AS Length,
		CAST(ISNULL(MAX(T1.Bar_Weight), 0) * ISNULL(MAX(Length),2) AS DECIMAL(10,2)) AS Barem,
		ISNULL(SUM(T1.Num_Bars), 0) AS So_Luong_Cay,
		ISNULL(SUM(T1.So_Luong), 0) AS So_Luong_Barcode,
		CAST(0 AS DECIMAL(10,2)) AS So_Luong_Barem,
		CAST(0 AS DECIMAL(10,2)) AS So_Luong_Can,
		CAST(0 AS DECIMAL(10,2)) AS Ty_Le_CL,
		ISNULL(MAX(T2.So_Luong), 0) AS TSo_Luong_Can,
		ROW_NUMBER() OVER (ORDER BY T1.Ma_Ct, T1.Ngay_Ct, T1.Stt, T1.So_Ct, T1.Ma_Vt_Sp, T2.So_Xe) AS Stt_Row
	INTO #T_TCBR
	FROM #T_PhatSinh T1 JOIN R80PH_SCALE T2 ON T1.Stt= T2.Stt
	WHERE (So_Xe LIKE CASE WHEN @So_Xe = '' THEN So_Xe ELSE '%' + @So_Xe + '%' END) AND (So_Xa_Lan_Tau LIKE CASE WHEN @So_Xa_Lan_Tau = '' THEN So_Xa_Lan_Tau ELSE '%' + @So_Xa_Lan_Tau + '%' END) AND (T2.So_Luong + T2.So_Luong_Ra + T2.So_Luong <> 0)
	GROUP BY T1.Ma_Ct, T1.Ngay_Ct, T1.Stt, T1.So_Ct, T1.Ma_Vt_Sp, T2.So_Xe, T2.So_Xa_Lan_Tau
	
	UPDATE #T_TCBR SET So_Luong_Barem = ROUND(So_Luong_Cay * Barem, 0), So_Luong_Can = ROUND(So_Luong_Cay * Barem, 0)
	
	DECLARE C_Barem CURSOR FOR
		SELECT Stt, SUM(So_Luong_Barem) AS So_Luong_Barem, MAX(TSo_Luong_Can) AS TSo_Luong_Can
			FROM #T_TCBR
			GROUP BY Stt

	DECLARE @_Stt VARCHAR(15),
			@_TSo_Luong_Can DECIMAL(10,2),
			@_So_Luong_Barem DECIMAL(10,2)

	OPEN C_Barem
	FETCH NEXT FROM C_Barem INTO @_Stt, @_So_Luong_Barem, @_TSo_Luong_Can
	WHILE @@FETCH_STATUS = 0
	BEGIN

		UPDATE #T_TCBR SET So_Luong_Can = ROUND(((So_Luong_Barem / @_So_Luong_Barem) * @_TSo_Luong_Can), 4) WHERE Stt = @_Stt AND @_So_Luong_Barem <> 0

		FETCH NEXT FROM C_Barem INTO @_Stt, @_So_Luong_Barem, @_TSo_Luong_Can
	END
	CLOSE C_Barem
	DEALLOCATE C_Barem

	SELECT T1.Ma_Vt_Sp AS Ma_Vt, T1.*,
			T1.So_Luong_Barcode AS So_Luong, T1.So_Luong_Barcode AS So_Luong9,
			T2.Ten_Vt AS Ten_Vt,T2.Dvt AS Dvt,
			T3.Ten_Dt AS Ten_Dt, T3.Dia_Chi, T3.Ong_Ba,
			CAST(1 AS BIT) AS Is_Barcode, CAST(0 AS BIT) AS Chon
		FROM #T_TCBR T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt
							JOIN R81DMDT T3 ON T1.Ma_Dt = T3.Ma_Dt	
RETURN