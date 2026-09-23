/*
SELECT * FROM R05CTX_BARCODE WHERE Stt = 3981
EXEC sp_Print_KCS_ 0, '01150128371', '01150128409'
EXEC sp_PrintTP_CT 0, '116877', 'PXTH', 'B35410120'
*/
ALTER PROCEDURE [dbo].[sp_Print_KCS]
(
	@Is_Co_Tinh BIT = 0,
	@Barcode1_1 VARCHAR(50) = '',
	@Barcode1_2 VARCHAR(50) = '',
	@Barcode2_1 VARCHAR(50) = '',
	@Barcode2_2 VARCHAR(50) = '',
	@Barcode3_1 VARCHAR(50) = '',
	@Barcode3_2 VARCHAR(50) = '',
	@Ma_Vt_Sp VARCHAR(30) = '',
	@So_Ct VARCHAR(20) = '',
	@Ten_Dt NVARCHAR(200) = '',
	@Ten_Cong_Trinh NVARCHAR(200) = '',
	@Language_Type CHAR(1) = 'V'
)
AS
BEGIN
	DECLARE @_Table_Ph VARCHAR(50),
			@_Table_Ct VARCHAR(50),
			@_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX),
			@_Stt1 VARCHAR(20) = '',
			@_RowID INT = 0,
			@_RowMax INT = 0,
			@_RowID_Reset INT = 0

	SET @_Key = '(0=0)'

	IF @Ma_Vt_Sp <> ''
		SET @_Key = @_Key + ' AND (Ma_Vt_Sp = ''' + @Ma_Vt_Sp + ''')'

	IF @Barcode1_1 <> '' AND @Barcode1_2 <> ''
		SET @_Key = @_Key + ' AND (Barcode >= ''' + @Barcode1_1 + ''' AND Barcode <= ''' + @Barcode1_2 + ''')'
	
	IF @Barcode2_1 <> '' AND @Barcode2_2 <> ''
		SET @_Key = @_Key + ' OR (Barcode >= ''' + @Barcode2_1 + ''' AND Barcode <= ''' + @Barcode2_2 + ''')'

	IF @Barcode3_1 <> '' AND @Barcode3_2 <> ''
		SET @_Key = @_Key + ' OR (Barcode >= ''' + @Barcode3_1 + ''' AND Barcode <= ''' + @Barcode3_2 + ''')'

	CREATE TABLE #T_Header
	(
		Stt VARCHAR(15),
		So_Ct VARCHAR(20),
		Ngay_Ct DATE,
		Ma_Vt_Sp VARCHAR(20),
		Ten_Vt_Sp NVARCHAR(200),
		Ten_Dt NVARCHAR(200),
		Ten_Cong_Trinh NVARCHAR(200),
		Ngay_In VARCHAR(20),
		Gio_In VARCHAR(10),
		Ngay_Xuat DATE,
		Ngay_Nhap DATE,
		Pull_Standard VARCHAR(100),
		Bend_Standard VARCHAR(100),
		Standard_Name VARCHAR(100),
		Grade_Name NVARCHAR(200),
		Chemis_Standard VARCHAR(100)
	)
	
	CREATE TABLE #T_Detail(Stt VARCHAR(15))
	EXEC sp_Copy_Column 'R81DMBARCODE', '#T_Detail', ''

	EXEC sp_DefaultTable '#T_Header'
	EXEC sp_DefaultTable '#T_Detail'
	
	EXEC sp_Copy_Data 'R81DMBARCODE', '#T_Detail', '', @_Key
	
	IF (@Ma_Vt_Sp <> '')
		DELETE FROM #T_Detail WHERE Ma_Vt_Sp <> @Ma_Vt_Sp

	UPDATE T1 SET Ngay_Nhap = ISNULL(CASE WHEN T2.Ngay_Sx IS NULL THEN T1.Ngay_Nhap ELSE T2.Ngay_Sx END, '')
		FROM #T_Detail T1 LEFT JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca
	
	--Detail
	IF COL_LENGTH('TempDB..#T_Detail', 'So_Ct') IS NULL
		ALTER TABLE #T_Detail ADD So_Ct VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ten_Size') IS NULL
		ALTER TABLE #T_Detail ADD Ten_Size NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_Name') IS NULL
		ALTER TABLE #T_Detail ADD Grade_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Lot_Name') IS NULL
		ALTER TABLE #T_Detail ADD Lot_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Chemis_Standard') IS NULL
		ALTER TABLE #T_Detail ADD Chemis_Standard VARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Pull_Standard') IS NULL
		ALTER TABLE #T_Detail ADD Pull_Standard VARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Bend_Standard') IS NULL
		ALTER TABLE #T_Detail ADD Bend_Standard VARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Standard_ID') IS NULL
		ALTER TABLE #T_Detail ADD Standard_ID VARCHAR(20) NOT NULL DEFAULT('')
		
	IF COL_LENGTH('TempDB..#T_Detail', 'Standard_Name') IS NULL
		ALTER TABLE #T_Detail ADD Standard_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Diameter') IS NULL
		ALTER TABLE #T_Detail ADD Diameter MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'DMin') IS NULL
		ALTER TABLE #T_Detail ADD Dmin MONEY NOT NULL DEFAULT(0)
		
	IF COL_LENGTH('TempDB..#T_Detail', 'DMax') IS NULL
		ALTER TABLE #T_Detail ADD DMax MONEY NOT NULL DEFAULT(0)

	INSERT #T_Header(So_Ct, Ngay_Ct, Ma_Vt_Sp, Ten_Dt, Ten_Cong_Trinh, Ngay_Xuat, Gio_In)
	SELECT @So_Ct, (SELECT dbo.fn_GetNow()), @Ma_Vt_Sp, @Ten_Dt, @Ten_Cong_Trinh, (SELECT dbo.fn_GetNow()), (SELECT CONVERT(VARCHAR(8),GETDATE(),108))

	UPDATE #T_Header SET Ngay_In = dbo.fn_PADL(CONVERT(VARCHAR, DAY(dbo.fn_GetNow())), 2, '0') + dbo.fn_PADL(CONVERT(VARCHAR, MONTH(dbo.fn_GetNow())), 2, '0') + SUBSTRING(CONVERT(VARCHAR,YEAR(dbo.fn_GetNow())), 3, 3)

	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	UPDATE T1 SET
			Ten_Size = UPPER(ISNULL(T2.Ten_Size, '')),
			Diameter = ISNULL(T2.Diameter, 0)
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMSIZE T2 WITH(NOLOCK) ON T1.Ma_Size = T2.Ma_Size

	
	UPDATE T1 SET
			Grade_Name = UPPER(ISNULL(T2.Grade_Name, '')),
			Chemis_Standard = UPPER(ISNULL(T2.Chemis_Standard, '')),
			Pull_Standard = UPPER(ISNULL(T2.Pull_Standard, '')),
			Bend_Standard = UPPER(ISNULL(T2.Bend_Standard, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMMACTHEP T2 WITH(NOLOCK) ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Standard_Name = UPPER(ISNULL(T2.Standard_Name, ''))
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMSTANDARD T2 WITH(NOLOCK) ON T1.Standard_ID = T2.Standard_ID

	IF @Is_Co_Tinh = 0
	BEGIN
		
		SELECT T1.No_Melt_Confirm, T1.Grade_ID, MAX(T2.Ca) AS Ca, MAX(T2.Fe) AS Fe, MAX(T2.C) AS C, MAX(T2.Mn) AS Mn, MAX(T2.Si) AS Si, MAX(T2.P) AS P, MAX(T2.S) AS S,
				MAX(T2.Cr) AS Cr, MAX(T2.Ni) AS Ni, MAX(T2.Mo) AS Mo, MAX(T2.Cu) AS Cu, MAX(T2.Al) AS Al, MAX(T2.V) AS V, MAX(T2.W) AS W, MAX(T2.Sn) AS Sn, MAX(T2.Ass) AS Ass,
				MAX(T2.Cueq) AS Cueq, MAX(T2.Ceq) AS Ceq, MAX(T2.C_Mn_6) AS C_Mn_6
			INTO #T_MTTPHH
			FROM #T_Detail T1 LEFT JOIN R81MTTPHH T2 ON T1.No_Melt_Confirm = T2.No_Melt
			GROUP BY T1.No_Melt_Confirm, T1.Grade_ID
		
		EXEC sp_DefaultTable '#T_MTTPHH'
		
		SELECT *
			INTO #T_Temp_TPHH1
			FROM #T_Detail
			WHERE Ngay_Nhap < '20150911'

		SELECT *
			INTO #T_Temp_TPHH2
			FROM #T_Detail
			WHERE Ngay_Nhap >= '20150911'

		SELECT CAST(0 AS INT) AS RowID, CAST('' AS VARCHAR(20)) AS Stt1, dbo.fn_GetNow() AS Ngay_Ct,
				T1.Grade_Name, T1.So_Ct, T1.Ngay_Nhap, T1.Lot_Name, T1.Standard_Name, T1.No_Melt_Confirm, T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, 
				T1.Chemis_Standard,
				T1.No_Melt_Confirm + '/' + T1.Try_ID AS Try_ID, '' AS Description, LTRIM(RTRIM(STR(COUNT(T1.Barcode)))) + ' bó' AS Count_Barcode
			INTO #T_Detail_TPHH
			FROM #T_Temp_TPHH1 T1 JOIN (SELECT No_Melt_Confirm,
					CASE WHEN T1.C < ISNULL(T2.C_Min, 0) THEN T2.C_Min WHEN T1.C > ISNULL(C_Max, 100) THEN C_Max ELSE T1.C END AS C,
					CASE WHEN T1.Mn < ISNULL(T2.Mn_Min, 0) THEN T2.Mn_Min WHEN T1.Mn > ISNULL(Mn_Max, 100) THEN Mn_Max ELSE T1.Mn END AS Mn,
					CASE WHEN T1.Si < ISNULL(T2.Si_Min, 0) THEN T2.Si_Min WHEN T1.Si > ISNULL(Si_Max, 100) THEN Si_Max ELSE T1.Si END AS Si,
					CASE WHEN T1.P < ISNULL(T2.P_Min, 0) THEN T2.P_Min WHEN T1.P > ISNULL(P_Max, 100) THEN P_Max ELSE T1.P END AS P,
					CASE WHEN T1.S < ISNULL(T2.S_Min, 0) THEN T2.S_Min WHEN T1.S > ISNULL(S_Max, 100) THEN S_Max ELSE T1.S END AS S,
					C_Mn_6
				FROM #T_MTTPHH T1 LEFT JOIN R81DMTPHH T2 ON T1.Grade_ID = T2.Grade_ID) T2 ON T1.No_Melt_Confirm = T2.No_Melt_Confirm
			GROUP BY T1.Grade_Name, T1.So_Ct, T1.Ngay_Nhap, T1.Lot_Name, T1.Standard_Name, T1.Num_Lot, T1.No_Melt_Confirm,
						T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, T1.Chemis_Standard, T1.Try_ID
			ORDER BY T1.Try_ID

		EXEC sp_DefaultTable '#T_Detail_TPHH'

		INSERT #T_Detail_TPHH
		SELECT CAST(0 AS INT) AS RowID, CAST('' AS VARCHAR(20)) AS Stt1, dbo.fn_GetNow() AS Ngay_Ct,
			T1.Grade_Name, T1.So_Ct, T1.Ngay_Nhap, T1.Lot_Name, T1.Standard_Name, MAX(T1.No_Melt_Confirm) AS No_Melt_Confirm, T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, 
			T1.Chemis_Standard,
			T1.Num_Lot AS Try_ID, '' AS Description, LTRIM(RTRIM(STR(COUNT(T1.Barcode)))) + ' bó' AS Count_Barcode
		FROM #T_Temp_TPHH2 T1 JOIN (SELECT No_Melt_Confirm,
				CASE WHEN T1.C < ISNULL(T2.C_Min, 0) THEN T2.C_Min WHEN T1.C > ISNULL(C_Max, 100) THEN C_Max ELSE T1.C END AS C,
				CASE WHEN T1.Mn < ISNULL(T2.Mn_Min, 0) THEN T2.Mn_Min WHEN T1.Mn > ISNULL(Mn_Max, 100) THEN Mn_Max ELSE T1.Mn END AS Mn,
				CASE WHEN T1.Si < ISNULL(T2.Si_Min, 0) THEN T2.Si_Min WHEN T1.Si > ISNULL(Si_Max, 100) THEN Si_Max ELSE T1.Si END AS Si,
				CASE WHEN T1.P < ISNULL(T2.P_Min, 0) THEN T2.P_Min WHEN T1.P > ISNULL(P_Max, 100) THEN P_Max ELSE T1.P END AS P,
				CASE WHEN T1.S < ISNULL(T2.S_Min, 0) THEN T2.S_Min WHEN T1.S > ISNULL(S_Max, 100) THEN S_Max ELSE T1.S END AS S,
				C_Mn_6
			FROM #T_MTTPHH T1 LEFT JOIN R81DMTPHH T2 ON T1.Grade_ID = T2.Grade_ID) T2 ON T1.No_Melt_Confirm = T2.No_Melt_Confirm
		GROUP BY T1.Grade_Name, T1.So_Ct, T1.Ngay_Nhap, T1.Lot_Name, T1.Standard_Name, T1.Num_Lot, T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, T1.Chemis_Standard
		ORDER BY T1.Ngay_Nhap

		--Cach cu
		--SELECT CAST(0 AS INT) AS RowID, CAST('' AS VARCHAR(20)) AS Stt1, dbo.fn_GetNow() AS Ngay_Ct,
		--		T1.Grade_Name, T1.So_Ct, T1.Ngay_Nhap, T1.Lot_Name, T1.Standard_Name, T1.No_Melt_Confirm, T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, 
		--		T1.Chemis_Standard,
		--		CASE WHEN LEN(T1.Num_Lot) = 9 THEN T1.Num_Lot ELSE T1.No_Melt_Confirm + '/' + T1.Try_ID END AS Try_ID, '' AS Description, LTRIM(RTRIM(STR(COUNT(T1.Barcode)))) + ' bó' AS Count_Barcode
		--	INTO #T_Detail_TPHH
		--	FROM #T_Detail T1 JOIN (SELECT No_Melt_Confirm,
		--			CASE WHEN T1.C < ISNULL(T2.C_Min, 0) THEN T2.C_Min WHEN T1.C > ISNULL(C_Max, 100) THEN C_Max ELSE T1.C END AS C,
		--			CASE WHEN T1.Mn < ISNULL(T2.Mn_Min, 0) THEN T2.Mn_Min WHEN T1.Mn > ISNULL(Mn_Max, 100) THEN Mn_Max ELSE T1.Mn END AS Mn,
		--			CASE WHEN T1.Si < ISNULL(T2.Si_Min, 0) THEN T2.Si_Min WHEN T1.Si > ISNULL(Si_Max, 100) THEN Si_Max ELSE T1.Si END AS Si,
		--			CASE WHEN T1.P < ISNULL(T2.P_Min, 0) THEN T2.P_Min WHEN T1.P > ISNULL(P_Max, 100) THEN P_Max ELSE T1.P END AS P,
		--			CASE WHEN T1.S < ISNULL(T2.S_Min, 0) THEN T2.S_Min WHEN T1.S > ISNULL(S_Max, 100) THEN S_Max ELSE T1.S END AS S,
		--			C_Mn_6
		--		FROM #T_MTTPHH T1 LEFT JOIN R81DMTPHH T2 ON T1.Grade_ID = T2.Grade_ID) T2 ON T1.No_Melt_Confirm = T2.No_Melt_Confirm
		--	GROUP BY T1.Grade_Name, T1.So_Ct, T1.Ngay_Nhap, T1.Lot_Name, T1.Standard_Name, T1.Num_Lot, T1.No_Melt_Confirm,
		--				T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, T1.Chemis_Standard, T1.Try_ID
		--	ORDER BY T1.Try_ID
		
		UPDATE #T_Detail_TPHH SET C_Mn_6 = (Mn / 6) + C

		UPDATE #T_Detail_TPHH SET 
				@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
				RowID = LTRIM(RTRIM(STR(@_RowID))),
				Stt1 = LTRIM(RTRIM(STR(@_RowID)))

		SELECT @_RowMax = (SELECT COUNT(*) FROM #T_Detail_TPHH)

		IF @_RowMax > 12
		BEGIN
			SET @_RowID_Reset = 0
			SET @_RowID = 13
			WHILE @_RowID < 25
			BEGIN
				UPDATE #T_Detail_TPHH SET
						@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
						Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
					WHERE RowID = @_RowID

				SET @_RowID = @_RowID + 1
			END
		END

		IF @_RowMax > 24
		BEGIN
			SET @_RowID_Reset = 0
			SET @_RowID = 25
			WHILE @_RowID < 37
			BEGIN
				UPDATE #T_Detail_TPHH SET
						@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
						Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
					WHERE RowID = @_RowID

				SET @_RowID = @_RowID + 1
			END
		END

		IF @_RowMax > 36
		BEGIN
			SET @_RowID_Reset = 0
			SET @_RowID = 37
			WHILE @_RowID < 49
			BEGIN
				UPDATE #T_Detail_TPHH SET
						@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
						Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
					WHERE RowID = @_RowID

				SET @_RowID = @_RowID + 1
			END
		END

		--WHILE @_RowID < 8
		--BEGIN
		--	SET @_RowID = @_RowID + 1
		--	INSERT #T_Detail_TPHH(RowID) VALUES (@_RowID)
		--END

		UPDATE T1 SET
				Ngay_Nhap = ISNULL(T2.Ngay_Nhap, ''),
				Chemis_Standard = ISNULL(T2.Chemis_Standard, ''),
				Standard_Name = ISNULL(T2.Standard_Name, ''),
				Grade_Name = ISNULL(T2.Grade_Name, '')
			FROM #T_Header T1 
				JOIN (SELECT MAX(Ngay_Ct) AS Ngay_Ct, MAX(Ngay_Nhap) AS Ngay_Nhap, MAX(Chemis_Standard) AS Chemis_Standard,
							MAX(Standard_Name) AS Standard_Name, MAX(Grade_Name) AS Grade_Name
						FROM #T_Detail_TPHH) T2 ON T1.Ngay_Ct = T2.Ngay_Ct


		SELECT *, (SELECT ISNULL(MAX(Ten_Vt), '') FROM R81DmVt WHERE Ma_Vt = @Ma_Vt_Sp) AS Ten_Vt_Sp_Sx
			FROM #T_Header

		SELECT *
			FROM #T_Detail_TPHH
			ORDER BY RowID

		RETURN
	END
	ELSE
	BEGIN
		
		SELECT *
			INTO #T_Temp1
			FROM #T_Detail
			WHERE Ngay_Nhap < '20150911'

		SELECT *
			INTO #T_Temp2
			FROM #T_Detail
			WHERE Ngay_Nhap >= '20150911'

		SELECT	dbo.fn_GetNow() AS Ngay_Ct, 
				CAST(0 AS INT) AS RowID, 
				CAST('' AS VARCHAR(20)) AS Stt1, 
				@So_Ct AS So_Ct, T1.Yeild, T2.YeildP_Min AS Yeild_Default, T2.YeildP_Max, T1.Tension, T2.TensionP_Min AS Tension_Default, T2.TensionP_Max,
				T1.ELong, T2.Elong_Min AS ELong_Default, T2.Elong_Max, T1.Grade_Name, 
				CASE WHEN T1.Bend_Test = 1 THEN N'Đạt' ELSE N'Đạt' END AS Bend_Test, 
				T1.Standard_Name, T1.Ten_Size, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Nhap, T1.Pull_Standard, T1.Bend_Standard, 
				T1.No_Melt + '/' + T1.Try_ID AS Try_ID, 
				T1.Diameter, T1.DMin, T1.DMax, LTRIM(RTRIM(STR(COUNT(T1.Barcode)))) + ' bó' AS Count_Barcode, '' AS Description
			INTO #T_Detail_CoTinh
			FROM #T_Temp1 T1 JOIN R81DMCOTINH T2 ON T1.Grade_ID = T2.Grade_ID AND T1.Diameter BETWEEN T2.DMin AND T2.DMax
			GROUP BY T1.So_Ct, T1.Yeild, T2.YeildP_Min, T2.YeildP_Max, T1.Tension, T2.TensionP_Min, T2.TensionP_Max,
				T1.ELong, T2.Elong_Min, T2.Elong_Max, T1.Grade_Name, T1.Bend_Test, T1.Standard_Name,
				T1.Ten_Size, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Nhap, T1.Pull_Standard, T1.Bend_Standard, T1.Num_Lot, T1.No_Melt, T1.Try_ID, T1.Diameter, T1.DMin, T1.DMax
			ORDER BY T1.Try_ID

		EXEC sp_DefaultTable '#T_Detail_CoTinh'

		INSERT #T_Detail_CoTinh
		SELECT	dbo.fn_GetNow() AS Ngay_Ct, 
				CAST(0 AS INT) AS RowID, 
				CAST('' AS VARCHAR(20)) AS Stt1, 
				@So_Ct AS So_Ct, T1.Yeild, T2.YeildP_Min AS Yeild_Default, T2.YeildP_Max, T1.Tension, T2.TensionP_Min AS Tension_Default, T2.TensionP_Max,
				T1.ELong, T2.Elong_Min AS ELong_Default, T2.Elong_Max, T1.Grade_Name, 
				CASE WHEN T1.Bend_Test = 1 THEN N'Đạt' ELSE N'Đạt' END AS Bend_Test, 
				T1.Standard_Name, T1.Ten_Size, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Nhap, T1.Pull_Standard, T1.Bend_Standard, 
				T1.Num_Lot AS Try_ID, 
				T1.Diameter, T1.DMin, T1.DMax, LTRIM(RTRIM(STR(COUNT(T1.Barcode)))) + ' bó' AS Count_Barcode, '' AS Description
			FROM #T_Temp2 T1 JOIN R81DMCOTINH T2 ON T1.Grade_ID = T2.Grade_ID AND T1.Diameter BETWEEN T2.DMin AND T2.DMax
			GROUP BY T1.So_Ct, T1.Yeild, T2.YeildP_Min, T2.YeildP_Max, T1.Tension, T2.TensionP_Min, T2.TensionP_Max,
				T1.ELong, T2.Elong_Min, T2.Elong_Max, T1.Grade_Name, T1.Bend_Test, T1.Standard_Name,
				T1.Ten_Size, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Nhap, T1.Pull_Standard, T1.Bend_Standard, T1.Num_Lot, T1.Diameter, T1.DMin, T1.DMax
			ORDER BY T1.Ngay_Nhap

		--Cach cu
		--SELECT	dbo.fn_GetNow() AS Ngay_Ct, 
		--		CAST(0 AS INT) AS RowID, 
		--		CAST('' AS VARCHAR(20)) AS Stt1, 
		--		@So_Ct AS So_Ct, T1.Yeild, T2.YeildP_Min AS Yeild_Default, T2.YeildP_Max, T1.Tension, T2.TensionP_Min AS Tension_Default, T2.TensionP_Max,
		--		T1.ELong, T2.Elong_Min AS ELong_Default, T2.Elong_Max, T1.Grade_Name, 
		--		CASE WHEN T1.Bend_Test = 1 THEN N'Đạt' ELSE N'Đạt' END AS Bend_Test, 
		--		T1.Standard_Name, T1.Ten_Size, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Nhap, T1.Pull_Standard, T1.Bend_Standard, 
		--		CASE WHEN LEN(T1.Num_Lot) = 9 THEN T1.Num_Lot ELSE T1.No_Melt + '/' + T1.Try_ID END AS Try_ID, 
		--		T1.Diameter, T1.DMin, T1.DMax, LTRIM(RTRIM(STR(COUNT(T1.Barcode)))) + ' bó' AS Count_Barcode, '' AS Description
		--	INTO #T_Detail_CoTinh
		--	FROM #T_Detail T1 JOIN R81DMCOTINH T2 ON T1.Grade_ID = T2.Grade_ID AND T1.Diameter BETWEEN T2.DMin AND T2.DMax
		--	GROUP BY T1.So_Ct, T1.Yeild, T2.YeildP_Min, T2.YeildP_Max, T1.Tension, T2.TensionP_Min, T2.TensionP_Max,
		--		T1.ELong, T2.Elong_Min, T2.Elong_Max, T1.Grade_Name, T1.Bend_Test, T1.Standard_Name,
		--		T1.Ten_Size, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Nhap, T1.Pull_Standard, T1.Bend_Standard, T1.Num_Lot, T1.No_Melt, T1.Try_ID, T1.Diameter, T1.DMin, T1.DMax
		--	ORDER BY T1.Try_ID

		--EXEC sp_DefaultTable '#T_Detail_CoTinh'
		
		UPDATE #T_Detail_CoTinh SET 
				@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
				RowID = LTRIM(RTRIM(STR(@_RowID))),
				Stt1 = LTRIM(RTRIM(STR(@_RowID)))

		SELECT @_RowMax = (SELECT COUNT(*) FROM #T_Detail_CoTinh)

		IF @_RowMax > 12
		BEGIN
			SET @_RowID_Reset = 0
			SET @_RowID = 13
			WHILE @_RowID < 25
			BEGIN
				UPDATE #T_Detail_CoTinh SET
						@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
						Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
					WHERE RowID = @_RowID

				SET @_RowID = @_RowID + 1
			END
		END

		IF @_RowMax > 24
		BEGIN
			SET @_RowID_Reset = 0
			SET @_RowID = 25
			WHILE @_RowID < 37
			BEGIN
				UPDATE #T_Detail_CoTinh SET
						@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
						Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
					WHERE RowID = @_RowID

				SET @_RowID = @_RowID + 1
			END
		END

		IF @_RowMax > 36
		BEGIN
			SET @_RowID_Reset = 0
			SET @_RowID = 37
			WHILE @_RowID < 49
			BEGIN
				UPDATE #T_Detail_CoTinh SET
						@_RowID_Reset = (CASE WHEN @_RowID_Reset IS NULL THEN 0 ELSE @_RowID_Reset END) + 1,
						Stt1 = LTRIM(RTRIM(STR(@_RowID_Reset)))
					WHERE RowID = @_RowID

				SET @_RowID = @_RowID + 1
			END
		END

		--WHILE @_RowID < 8
		--BEGIN
		--	SET @_RowID = @_RowID + 1
		--	INSERT #T_Detail_CoTinh(RowID) VALUES (@_RowID)
		--END

		UPDATE T1 SET
				Ngay_Nhap = ISNULL(T2.Ngay_Nhap, ''),
				Bend_Standard = ISNULL(T2.Bend_Standard, ''),
				Pull_Standard = ISNULL(T2.Pull_Standard, ''),
				Standard_Name = ISNULL(T2.Standard_Name, ''),
				Grade_Name = ISNULL(T2.Grade_Name, '')
			FROM #T_Header T1 
				JOIN (SELECT MAX(Ngay_Ct) AS Ngay_Ct, MAX(Ngay_Nhap) AS Ngay_Nhap, MAX(Pull_Standard) AS Pull_Standard, MAX(Bend_Standard) AS Bend_Standard,
							MAX(Standard_Name) AS Standard_Name, MAX(Grade_Name) AS Grade_Name
						FROM #T_Detail_CoTinh) T2 ON T1.Ngay_Ct = T2.Ngay_Ct

		SELECT *, (SELECT ISNULL(MAX(Ten_Vt), '') FROM R81DmVt WHERE Ma_Vt = @Ma_Vt_Sp) AS Ten_Vt_Sp_Sx
			FROM #T_Header

		SELECT *
			FROM #T_Detail_CoTinh
			ORDER BY RowID
	END
	
END
GO
EXEC sp_Print_KCS 0, '01150158150', '01150158177'