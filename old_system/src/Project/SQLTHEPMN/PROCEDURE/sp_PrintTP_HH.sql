CREATE PROCEDURE sp_PrintTP_CT
(
	@Is_Co_Tinh BIT = 0,
	@Stt VARCHAR(15) = '',
	@Ma_Ct VARCHAR(5),
	@Language_Type CHAR(1) = 'V'
)
AS
BEGIN
	DECLARE @_Table_Ph VARCHAR(50),
			@_Table_Ct VARCHAR(50),
			@_Key VARCHAR(1000),
			@_SQLExec VARCHAR(MAX),
			@_Stt1 INT = 0

	SELECT	@_Table_Ph = Table_Ph,
			@_Table_Ct = Table_Ct
		FROM R00DmCt WHERE Ma_Ct = @Ma_Ct

	SET @_Key = '(0=0)'

	IF @Stt <> ''
		SET @_Key = @_Key + ' AND Stt = ''' + @Stt + ''''

	CREATE TABLE #T_Header(Stt VARCHAR(15))
	CREATE TABLE #T_Detail(Stt VARCHAR(15))

	EXEC sp_Copy_Column @_Table_Ph, '#T_Header', ''
	EXEC sp_Copy_Column @_Table_Ct, '#T_Detail', ''

	EXEC sp_DefaultTable '#T_Header'
	EXEC sp_DefaultTable '#T_Detail'
	
	SET @_Key = '(Stt = ''' + @Stt + ''')'

	EXEC sp_Copy_Data @_Table_Ph, '#T_Header', '', @_Key
	EXEC sp_Copy_Data @_Table_Ct, '#T_Detail', '', @_Key	
	
	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Dt') IS NULL
		ALTER TABLE #T_Header ADD Ten_Dt NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ten_Vt_Sp') IS NULL
		ALTER TABLE #T_Header ADD Ten_Vt_Sp NVARCHAR(200) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_In') IS NULL
		ALTER TABLE #T_Header ADD Ngay_In DATE NOT NULL DEFAULT('19000101')

	IF COL_LENGTH('TempDB..#T_Header', 'Gio_In') IS NULL
		ALTER TABLE #T_Header ADD Gio_In VARCHAR(10) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Header', 'Ngay_Xuat') IS NULL
		ALTER TABLE #T_Header ADD Ngay_Xuat NVARCHAR(50) NOT NULL DEFAULT('')

	--Detail
	
	IF COL_LENGTH('TempDB..#T_Detail', 'Num_Lot') IS NULL
		ALTER TABLE #T_Detail ADD Num_Lot VARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ngay_Sx') IS NULL
		ALTER TABLE #T_Detail ADD Ngay_Sx DATE NOT NULL DEFAULT('19000101')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ma_Vt') IS NULL
		ALTER TABLE #T_Detail ADD Ma_Vt VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Lot_ID') IS NULL
		ALTER TABLE #T_Detail ADD Lot_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Lot_Name') IS NULL
		ALTER TABLE #T_Detail ADD Lot_Name NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Ten_Vt') IS NULL
		ALTER TABLE #T_Detail ADD Ten_Vt NVARCHAR(100) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_ID') IS NULL
		ALTER TABLE #T_Detail ADD Grade_ID VARCHAR(20) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'Grade_Name') IS NULL
		ALTER TABLE #T_Detail ADD Grade_Name NVARCHAR(100) NOT NULL DEFAULT('')

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

	IF COL_LENGTH('TempDB..#T_Detail', 'Yeild') IS NULL
		ALTER TABLE #T_Detail ADD Yeild MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'Tension') IS NULL
		ALTER TABLE #T_Detail ADD Tension MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'ELong') IS NULL
		ALTER TABLE #T_Detail ADD ELong MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'Bend_Test') IS NULL
		ALTER TABLE #T_Detail ADD Bend_Test BIT NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'Try_ID') IS NULL
		ALTER TABLE #T_Detail ADD Try_ID VARCHAR(50) NOT NULL DEFAULT('')

	IF COL_LENGTH('TempDB..#T_Detail', 'No_Melt') IS NULL
		ALTER TABLE #T_Detail ADD No_Melt VARCHAR(50) NOT NULL DEFAULT('')
	
	IF COL_LENGTH('TempDB..#T_Detail', 'Diameter') IS NULL
		ALTER TABLE #T_Detail ADD Diameter MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'DMin') IS NULL
		ALTER TABLE #T_Detail ADD Dmin MONEY NOT NULL DEFAULT(0)
		
	IF COL_LENGTH('TempDB..#T_Detail', 'DMax') IS NULL
		ALTER TABLE #T_Detail ADD DMax MONEY NOT NULL DEFAULT(0)

	IF COL_LENGTH('TempDB..#T_Detail', 'No_Melt') IS NULL
		ALTER TABLE #T_Detail ADD No_Melt VARCHAR(50) NOT NULL DEFAULT('')

	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_Header T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	UPDATE #T_Header SET Ngay_Xuat = N'Ngày ' + CONVERT(VARCHAR, DAY(Ngay_Ct)) + N' tháng ' + CONVERT(VARCHAR, MONTH(Ngay_Ct)) + N' năm ' + CONVERT(VARCHAR, YEAR(Ngay_Ct))
	UPDATE #T_Header SET Ngay_In = (SELECT dbo.fn_GetNow())
	UPDATE #T_Header SET Gio_In = (SELECT CONVERT(VARCHAR(8),GETDATE(),108))

	--Detail
	UPDATE T1 SET
			Lot_ID = T2.Lot_ID,
			Grade_ID = T2.Grade_ID,
			Standard_ID = T2.Standard_ID,
			Ngay_Sx = T2.Ngay_Sx,
			No_Melt = T2.No_Melt,
			Num_Lot = T2.Num_Lot,
			Yeild = T2.Yeild,
			Tension = T2.Tension,
			ELong = T2.ELong,
			Try_ID = T2.Try_ID,
			Bend_Test = T2.Bend_Test
		FROM #T_Detail T1 JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode
	
	UPDATE T1 SET
			Ten_Vt = UPPER(ISNULL(T2.Ten_Vt, '')),
			Diameter = ISNULL(T2.Diameter, 0)
		FROM #T_Detail T1 WITH(NOLOCK) JOIN R81DMVT T2 WITH(NOLOCK) ON T1.Ma_Vt = T2.Ma_Vt

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
		SELECT CAST(0 AS INT) AS Stt1, MAX(T1.Ngay_Ct) AS Ngay_Ct, T1.Grade_Name, T1.So_Ct, T1.Ngay_Sx, T1.Lot_Name, T1.Standard_Name, T1.No_Melt, T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, T1.Chemis_Standard, T1.Try_ID
			INTO #T_Detail_TPHH
			FROM #T_Detail T1 JOIN (SELECT T1.No_Melt,
				CASE WHEN T1.C < ISNULL(T2.C_Min, 0) THEN T2.C_Min WHEN T1.C > ISNULL(T2.C_Max, 100) THEN T2.C_Max ELSE T1.C END AS C,
				CASE WHEN T1.Mn < ISNULL(T2.Mn_Min, 0) THEN T2.Mn_Min WHEN T1.Mn > ISNULL(T2.Mn_Max, 100) THEN T2.Mn_Max ELSE T1.Mn END AS Mn,
				CASE WHEN T1.Si < ISNULL(T2.Si_Min, 0) THEN T2.Si_Min WHEN T1.Si > ISNULL(T2.Si_Max, 100) THEN T2.Si_Max ELSE T1.Si END AS Si,
				CASE WHEN T1.P < ISNULL(T2.P_Min, 0) THEN T2.P_Min WHEN T1.P > ISNULL(T2.P_Max, 100) THEN T2.P_Max ELSE T1.P END AS P,
				CASE WHEN T1.S < ISNULL(T2.S_Min, 0) THEN T2.S_Min WHEN T1.S > ISNULL(T2.S_Max, 100) THEN T2.S_Max ELSE T1.S END AS S,
				T1.C_Mn_6, T1.Grade_Name
			FROM R81MTTPHH T1 WITH(NOLOCK) LEFT JOIN R81DMMACTHEP T3 WITH(NOLOCK) ON T1.Grade_Name = T3.Grade_Name
								LEFT JOIN R81DMTPHH T2 WITH(NOLOCK) ON T2.Grade_ID = T3.Grade_ID) T2 ON T1.No_Melt = T2.No_Melt
			GROUP BY T1.Grade_Name, T1.So_Ct, T1.Ngay_Sx, T1.Lot_Name, T1.Standard_Name, T1.No_Melt, T2.C, T2.Mn, T2.Si, T2.P, T2.S, T2.C_Mn_6, T1.Chemis_Standard, T1.Try_ID

		UPDATE #T_Detail_TPHH SET 
				@_Stt1 = (CASE WHEN @_Stt1 IS NULL THEN 0 ELSE @_Stt1 END) + 1,
				Stt1 = LTRIM(RTRIM(STR(@_Stt1)))
		
		SELECT *
			FROM #T_Header

		SELECT *
			FROM #T_Detail_TPHH
			ORDER BY Stt1

		RETURN
	END
	ELSE
	BEGIN
		SELECT MAX(Ngay_Ct) AS Ngay_Ct, CAST(0 AS INT) AS Stt1, T1.So_Ct, T1.Yeild, T2.YeildP_Min AS Yeild_Default, T2.YeildP_Max, T1.Tension, T2.TensionP_Min AS Tension_Default, T2.TensionP_Max,
				T1.ELong, T2.Elong_Min AS ELong_Default, T2.Elong_Max, T1.Grade_Name, T1.Bend_Test, T1.Standard_Name,
				T1.Ten_Vt, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Sx, T1.Pull_Standard, T1.Bend_Standard, T1.Try_ID, T1.Diameter, T1.DMin, T1.DMax
			INTO #T_Detail_CoTinh
			FROM #T_Detail T1 JOIN R81DMCOTINH T2 ON T1.Grade_ID = T2.Grade_ID AND T1.Diameter BETWEEN T2.DMin AND T2.DMax
			GROUP BY T1.So_Ct, T1.Yeild, T2.YeildP_Min, T2.YeildP_Max, T1.Tension, T2.TensionP_Min, T2.TensionP_Max,
				T1.ELong, T2.Elong_Min, T2.Elong_Max, T1.Grade_Name, T1.Bend_Test, T1.Standard_Name,
				T1.Ten_Vt, T1.Grade_ID, T1.Lot_Name, T1.Ngay_Sx, T1.Pull_Standard, T1.Bend_Standard, T1.Try_ID, T1.Diameter, T1.DMin, T1.DMax

		UPDATE #T_Detail_CoTinh SET 
				@_Stt1 = (CASE WHEN @_Stt1 IS NULL THEN 0 ELSE @_Stt1 END) + 1,
				Stt1 = LTRIM(RTRIM(STR(@_Stt1)))

		SELECT *
			FROM #T_Header

		SELECT *
			FROM #T_Detail_CoTinh
	END
	
END
GO
EXEC sp_PrintTP_CT 1, '1','PXTH'
--select * from R81DMMACTHEP