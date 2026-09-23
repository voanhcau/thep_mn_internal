/*
SET DATEFORMAT DMY
EXEC sp_rptTCB05 '20150401','20150430', ''
*/
--Báo cáo xuất hàng theo khách hàng
ALTER PROCEDURE [dbo].[sp_rptTCB05]
(
	@Ngay_Ct1 DATETIME = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Dt VARCHAR(20) = '',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0,
			@_RowMax INT = 0

	SET @_Key = '(0=0) AND (So_Luong_Vao <> 0 AND So_Luong_Ra <> 0) AND (Ma_Vt_Sp = ''CP'')'
	SET @_Key = @_Key + ' AND (Time_Out >= ''' + CONVERT(VARCHAR, @Ngay_Ct1, 9) + ''' AND Time_Out <= ''' + CONVERT(VARCHAR, @Ngay_Ct2, 9) + ''')'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	CREATE TABLE #T_Ph_Scale(Stt VARCHAR(20))
	
	EXEC sp_DefaultTable '#T_Ph_Scale'
	
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_Ph_Scale', '', @_Key
	
	SELECT T1.Ma_Dt, CAST('' AS NVARCHAR(200)) AS Ten_Dt, T1.Ma_Size, CAST('' AS NVARCHAR(200)) AS Ten_Size,
			T1.Barcode, T1.So_Luong,
			CAST('' AS NVARCHAR(200)) AS Ten_Vt_Mac_Thep,
			CAST('' AS VARCHAR(20)) AS Grade_ID, CAST('' AS NVARCHAR(200)) AS Grade_Name, CAST(0 AS MONEY) AS Length
		INTO #T_PhatSinh
		FROM R05CTX_BARCODE T1 JOIN #T_Ph_Scale T2 ON T1.Stt = T2.Stt
	
	EXEC sp_DefaultTable '#T_PhatSinh'
	
	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Grade_ID = T2.Grade_ID, Length = ISNULL(T2.Length, 0)
		FROM #T_PhatSinh T1 JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode

	UPDATE T1 SET Grade_Name = UPPER(ISNULL(T2.Grade_Name, ''))
		FROM #T_PhatSinh T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

	UPDATE T1 SET Ten_Size = UPPER(ISNULL(T2.Ten_Size, ''))
		FROM #T_PhatSinh T1 JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size

	UPDATE #T_PhatSinh SET Ten_Vt_Mac_Thep = UPPER(ISNULL(Ten_Size, '')) + '-' + UPPER(ISNULL(Grade_Name, '')) + '--' + dbo.fn_FormatNumber(Length, 1, ' ') + 'M'

	CREATE TABLE #T_BaoCao
	(
		Stt_Sx VARCHAR(20) DEFAULT(''),
		Ma_Dt VARCHAR(20) DEFAULT(''),
		Ten_Dt NVARCHAR(200) DEFAULT(''),
		Ma_Size VARCHAR(20) DEFAULT(''),
		Ten_Size NVARCHAR(200) DEFAULT(''),
		Grade_ID VARCHAR(20) DEFAULT(''),
		So_Luong MONEY DEFAULT(0),
		Num_Barcode MONEY DEFAULT(0),
		Bold BIT NOT NULL DEFAULT(0),
		SortPath VARBINARY(MAX),
		Ma_Tg1 VARCHAR(20) DEFAULT(''),
		Ma_Tg2 VARCHAR(20) DEFAULT(''),
		Ma_Tg3 VARCHAR(20) DEFAULT(''),
		ColumnID VARCHAR(20) DEFAULT(''),
		ColumnName NVARCHAR(200) DEFAULT('')
	)
	
	SELECT Ma_Dt, MAX(Ten_Dt) AS Ten_Dt,
			Ma_Size, MAX(Ten_Vt_Mac_Thep) AS Ten_Size,
			Grade_ID, MAX(Grade_Name) AS Grade_Name,
			ISNULL(SUM(So_Luong), 0) AS So_Luong,
			ISNULL(COUNT(Barcode), 0) AS Num_Barcode,
			CAST(0 AS BIT) As Bold
		INTO #T_PhatSinhSum
		FROM #T_PhatSinh
		GROUP BY Ma_Dt, Ma_Size, Grade_ID
	
	EXEC sp_DefaultTable '#T_PhatSinhSum'

	CREATE INDEX Ma_Dt ON #T_PhatSinhSum(Ma_Dt)
	CREATE INDEX Ma_Size ON #T_PhatSinhSum(Ma_Size)
	CREATE INDEX Grade_ID ON #T_PhatSinhSum(Grade_ID)

	EXEC sp_BuildGroup '#T_PhatSinhSum', '#T_BaoCao', 'Ma_Dt',  'So_Luong, Num_Barcode', @Language_Type, @Ma_DvCs

	--Cập nhật phần nhóm
	UPDATE #T_BaoCao SET 
		Ma_Dt = ColumnID,
		Ten_Dt = UPPER(ColumnName), 
		Bold = 1
		
	--Danh So thu tu
	UPDATE #T_BaoCao SET Stt_Sx = T2.Stt_Sx
		FROM #T_BaoCao T1 JOIN (SELECT ROW_NUMBER() OVER(ORDER BY ColumnID) AS Stt_Sx, ColumnID FROM #T_BaoCao WHERE Bold = 1) T2 ON T1.ColumnID = T2.ColumnID

	EXECUTE Sp_Copy_Data '#T_PhatSinhSum', '#T_BaoCao'

	UPDATE #T_BaoCao SET Ten_Dt = UPPER(Ten_Size) FROM #T_BaoCao WHERE Bold = 0

	UPDATE #T_BaoCao SET Ten_Dt = SPACE(2*(Level - 1)) + Ten_Dt WHERE Bold = 0

	--Danh so thu tu
		SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS Stt_Sx, String AS Stt_Sx_Char
			INTO #T_Stt_Sx
			FROM dbo.fn_Split('A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z')

		SET @_RowID = 1
		SET @_RowMax = (SELECT MAX(Stt_Sx) FROM #T_Stt_Sx)
		WHILE @_RowID <=ISNULL((SELECT COUNT(*) FROM #T_BaoCao WHERE Bold = 1), 0)
		BEGIN
			
			INSERT #T_Stt_Sx(Stt_Sx, Stt_Sx_Char)
			SELECT @_RowMax + 1, LTRIM(RTRIM(STR(@_RowID)))

			SELECT @_RowMax = @_RowMax + 1
			SELECT @_RowID = @_RowID + 1
		END

		UPDATE T1 SET Stt_Sx = T2.Stt_Sx_Char
			FROM #T_BaoCao T1 JOIN #T_Stt_Sx T2 ON T1.Stt_Sx = T2.Stt_Sx

	UPDATE #T_BaoCao SET Stt_Sx = T2.Stt
			FROM #T_BaoCao T1 JOIN (SELECT ROW_NUMBER() OVER (PARTITION BY Ma_Dt ORDER BY SortPath, Level, Ma_Dt, Ma_Size, Grade_ID) AS Stt, Ma_Dt, Ma_Size, Grade_ID FROM #T_BaoCao WHERE Bold = 0) T2 ON T1.Ma_Dt = T2.Ma_Dt AND T1.Ma_Size = T2.Ma_Size AND T1.Grade_ID = T2.Grade_ID
			WHERE Bold = 0

	INSERT INTO #T_BaoCao(Ten_Dt, So_Luong, Num_Barcode, Bold)
	SELECT UPPER(dbo.fn_GetLanguage('Tong_Cong', @Language_Type)), SUM(So_Luong), SUM(Num_Barcode), 1
		FROM #T_BaoCao
		WHERE Bold = 0
	
	SELECT *, So_Luong AS Khoi_Luong
		FROM #T_BaoCao
		ORDER BY SortPath, Level, Ma_Dt
	
END
