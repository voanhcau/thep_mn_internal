--Báo cáo Tổng hợp tồn kho --Không barcode
ALTER PROCEDURE [dbo].[sp_rptTCB_TKCD01]
(	
	@Ngay_Ct DATETIME = '',
	@Ma_Kho VARCHAR(20) = '',
	@Ma_Size VARCHAR(20) = '',
	@Is_Vnd BIT = 1,
	@Language_Type CHAR(1) = 'V',
	@Ma_Dvcs CHAR(5) = 'A01' 
)
--WITH ENCRYPTION
AS
BEGIN	
	
	DECLARE @_Key NVARCHAR(4000),
			@_SQL NVARCHAR(4000),
			@_GetDetail BIT,
			@_Stt0 INT = 0,
			@_RowID INT = 0
 			
	--Tao Key	
	SET @_Key = '( 0 = 0)'	
	
	IF @Ma_Size <> ''	
		SET @_Key = @_Key + ' AND (Ma_Size = ''' + @Ma_Size + ''')'		
	
	--Lay so du dau	
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, Length, So_Luong AS Ton_Dau, Num_Bars AS Ton_Dau_Num_Bars
		INTO #T_Barcode
		FROM R81DMBARCODE
		WHERE 0 = 1
	
	EXEC sp_TonCuoiList_Barcode @Ngay_Ct, @Ma_Kho, @_Key, '#T_Barcode', @Ma_DvCs

	SELECT Ma_Size + 'ROSY' + CAST(Length AS VARCHAR) AS Ma_Nh, Ma_Vt_Sp, Ma_Size, Length,
			SUM(Ton_Dau) AS Ton_Cuoi_Khoi_Luong,
			SUM(Ton_Dau_Num_Bars) AS Ton_Cuoi_Num_Bars,
			COUNT(Barcode) AS So_Bo
		INTO #T_TonCuoi
		FROM #T_Barcode
		GROUP BY Ma_Vt_Sp, Ma_Size, Length

	CREATE TABLE #T_BaoCao 
	(
		Stt_Sx VARCHAR(20) DEFAULT(''),
		Ma_Nh VARCHAR(30) DEFAULT(''),
		Ma_Size VARCHAR(20) DEFAULT(''),
		Ma_Vt_Sp VARCHAR(20) DEFAULT(''),
		Ten_Size NVARCHAR(200) DEFAULT(''),
		Length MONEY DEFAULT(0),
		Ton_Cuoi_Khoi_Luong MONEY DEFAULT(0),
		Ton_Cuoi_Num_Bars MONEY DEFAULT(0),
		So_Bo MONEY DEFAULT(0),
		Bold BIT NOT NULL DEFAULT(0),
		SortPath VARBINARY(MAX),
		Ma_Tg1 VARCHAR(20) DEFAULT(''),
		Ma_Tg2 VARCHAR(20) DEFAULT(''),
		Ma_Tg3 VARCHAR(20) DEFAULT(''),
		ColumnID VARCHAR(20) DEFAULT(''),
		ColumnName NVARCHAR(200) DEFAULT('')
	)
	
	EXEC sp_DefaultTable '#T_BaoCao'

	-- Sum Ma_Kho, Ma_Vt
	SELECT	Ma_Nh, Ma_Size, Ma_Vt_Sp, Length,
			SUM(Ton_Cuoi_Khoi_Luong) AS Ton_Cuoi_Khoi_Luong,
			SUM(Ton_Cuoi_Num_Bars) AS Ton_Cuoi_Num_Bars,
			SUM(So_Bo) AS So_Bo
		INTO #T_BaoCao0
		FROM #T_TonCuoi
		GROUP BY Ma_Nh, Ma_Size, Ma_Vt_Sp, Length
	
	CREATE INDEX Ma_Size ON #T_BaoCao0(Ma_Nh)

	EXEC sp_BuildGroup '#T_BaoCao0', '#T_BaoCao', 'Ma_Nh', 
			'Ton_Cuoi_Khoi_Luong, Ton_Cuoi_Num_Bars, So_Bo', @Language_Type, @Ma_DvCs

	--Cập nhật phần nhóm
	UPDATE #T_BaoCao SET 
		Ma_Size = SUBSTRING(ColumnID, 0, CHARINDEX('ROSY', ColumnID)),
		Ten_Size = ColumnName, 
		Bold = 1
		
	EXECUTE Sp_Copy_Data '#T_BaoCao0', '#T_BaoCao'

	UPDATE #T_BaoCao SET
			Length = SUBSTRING(Ma_Nh, CHARINDEX('ROSY', Ma_Nh) + 4, LEN(Ma_Nh))
		WHERE Bold = 1

	UPDATE #T_BaoCao SET 
				Ten_Size = T2.Ten_Size
		FROM #T_BaoCao T1 INNER JOIN R81DmSize T2 ON T1.Ma_Size = T2.Ma_Size
		WHERE Bold = 1

	UPDATE	#T_BaoCao SET 
				Ten_Size = Ten_Size + ' x ' + CAST(Length AS VARCHAR)
		FROM #T_BaoCao
		WHERE Bold = 1

	UPDATE #T_BaoCao SET 
				Ten_Size = T2.Ten_Vt
		FROM #T_BaoCao T1 INNER JOIN R81DmVt T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt	
	
	UPDATE #T_BaoCao SET Ten_Size = SPACE(2*(Level - 1)) + Ten_Size
	
	UPDATE #T_BaoCao SET 
				@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
				Stt_Sx = LTRIM(RTRIM(STR(@_RowID)))
			WHERE Bold = 1
	
	UPDATE #T_BaoCao SET Stt_Sx = T2.Stt_Sx
		FROM #T_BaoCao T1 JOIN(SELECT Stt_Sx, Ma_Nh FROM #T_BaoCao WHERE Bold = 1) T2 ON T1.Ma_Nh = T2.Ma_Nh
		WHERE Bold = 0

	UPDATE #T_BaoCao SET Stt_Sx = Stt_Sx + '.' + LTRIM(RTRIM(STR(T2.Stt)))
			FROM #T_BaoCao T1 JOIN (SELECT ROW_NUMBER() OVER (PARTITION BY Ma_Nh ORDER BY SortPath, Level, Ma_Nh, Ma_Size, Ma_Vt_Sp) AS Stt, Ma_Nh, Ma_Size, Ma_Vt_Sp FROM #T_BaoCao WHERE Bold = 0) T2 ON T1.Ma_Nh = T2.Ma_Nh AND T1.Ma_Size = T2.Ma_Size AND T1.Ma_Vt_Sp = T2.Ma_Vt_Sp
			WHERE Bold = 0

	INSERT INTO #T_BaoCao (Ten_Size, Ton_Cuoi_Khoi_Luong, Ton_Cuoi_Num_Bars, So_Bo, SortPath, Level, Bold)
		SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), 
				ISNULL(SUM(Ton_Cuoi_Khoi_Luong), 0), ISNULL(SUM(Ton_Cuoi_Num_Bars), 0), ISNULL(SUM(So_Bo), 0), MAX(SortPath), MAX(Level) + 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0

	SELECT * 
		FROM #T_BaoCao
		ORDER BY SortPath, Level
	
END
GO
--EXEC sp_rptTCB_TKCD01 '20150615', 'L', '10'
--SELECT * FROM R81DMBARCODE WHERE LEFT(Barcode, 1) = 'L'