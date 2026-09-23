/*
SET DATEFORMAT DMY
EXEC sp_rptTCB03 '20150401','20150430', @Kieu_Nh = '1'
*/
--Bao cao tong hop khach hang - hang hoa va hang hoa - khach hang 
ALTER PROCEDURE sp_rptTCB03
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@So_Ct VARCHAR(20) = '',
	@So_Xe VARCHAR(20) = '',
	@Kieu_Nh CHAR(1) = '1',--1-Nhom Ma san pham, 2- Nhom Khach hang
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SET @_Key = '(0=0) AND (So_Luong_Vao <> 0 AND So_Luong_Ra <> 0)'
	SET @_Key = @_Key + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'

	IF @Ma_Dt <> ''
		SET @_Key = @_Key + ' AND (Ma_Dt = ''' + @Ma_Dt + ''')'

	IF @Ma_Vt_Sp <> ''
		SET @_Key = @_Key + ' AND (Ma_Vt_Sp = ''' + @Ma_Vt_Sp + ''')'

	IF @So_Ct <> ''
		SET @_Key = @_Key + ' AND (So_Ct = ''' + @So_Ct + ''')'

	IF @So_Xe <> ''
		SET @_Key = @_Key + ' AND (So_Xe = ''' + @So_Xe + ''')'

	SELECT	CAST('' AS VARCHAR(20)) AS Stt_Sx, Stt, Ma_Ct, So_Ct, Ngay_Ct, Ma_Dt, CAST('' AS NVARCHAR(100)) AS Ten_Dt,
			Ma_Dt_CbNv_Vao, CAST('' AS NVARCHAR(100)) AS Ten_Dt_CbNV_Vao,
			Ma_Dt_CbNv_Ra, CAST('' AS NVARCHAR(100)) AS Ten_Dt_CbNV_Ra,
			Ma_Vt_Sp, CAST('' AS NVARCHAR(200)) AS Ten_Vt_Sp,
			Dien_Giai, So_Xe, So_Luong_Vao, So_Luong_Ra, So_Luong, Time_In, Time_Out,
			Duyet, Ly_Do, SL_Xe_Hang, TSL_Barcode, TSo_Barcode, SL_QDinh, SL_CL, Ghi_Chu_QDinh
		INTO #T_PhatSinh
		FROM R80PH_SCALE
		WHERE 0 = 1
	
	EXEC sp_DefaultTable '#T_PhatSinh'
	EXEC sp_Copy_Data 'R80PH_SCALE', '#T_PhatSinh', '', @_Key
	
	UPDATE T1 SET Ten_Vt_Sp = UPPER(ISNULL(T2.Ten_Vt, ''))
		FROM #T_PhatSinh T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt
	
	UPDATE T1 SET Ten_Dt = UPPER(ISNULL(T2.Ten_Dt, ''))
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Vao = ISNULL(T2.Ten_Dt, '')
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv_Vao = T2.Ma_Dt

	UPDATE T1 SET Ten_Dt_CbNv_Ra = ISNULL(T2.Ten_Dt, '')
		FROM #T_PhatSinh T1 JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv_Ra = T2.Ma_Dt

	CREATE TABLE #T_BaoCao
	(
		Stt_Sx VARCHAR(20) DEFAULT(''),
		So_Ct VARCHAR(20) DEFAULT(''),
		Ma_Vt_Sp VARCHAR(20) DEFAULT(''),
		Ten_Vt_Sp NVARCHAR(200) DEFAULT(''),
		Ma_Dt VARCHAR(20) DEFAULT(''),
		Ten_Dt NVARCHAR(200) DEFAULT(''),
		So_Xe VARCHAR(20) DEFAULT(''),
		So_Luong_Vao MONEY DEFAULT(0),
		So_Luong_Ra MONEY DEFAULT(0),
		So_Luong MONEY DEFAULT(0),
		Dien_Giai NVARCHAR(200) DEFAULT(''),
		Bold BIT NOT NULL DEFAULT(0),
		SortPath VARBINARY(MAX),
		Ma_Tg1 VARCHAR(20) DEFAULT(''),
		Ma_Tg2 VARCHAR(20) DEFAULT(''),
		Ma_Tg3 VARCHAR(20) DEFAULT(''),
		ColumnID VARCHAR(20) DEFAULT(''),
		ColumnName NVARCHAR(200) DEFAULT('')
	)

	IF @Kieu_Nh = '1' --Nhom Ma san pham
	BEGIN
		SELECT	Ma_Dt, MAX(Ten_Dt) AS Ten_Dt,
				Ma_Vt_Sp, MAX(Ten_Vt_Sp) AS Ten_Vt_Sp,
				SUM(So_Luong_Vao) AS So_Luong_Vao,
				SUM(So_Luong_Ra) AS So_Luong_Ra,
				SUM(So_Luong) AS So_Luong,
				MAX(Stt_Sx) AS Stt_Sx
			INTO #T_PhatSinhSum
			FROM #T_PhatSinh
			GROUP BY Ma_Dt, Ma_Vt_Sp
		
		CREATE INDEX Ma_Vt_Sp ON #T_PhatSinhSum(Ma_Vt_Sp)
		CREATE INDEX Ma_Dt ON #T_PhatSinhSum(Ma_Dt)

		EXEC sp_BuildGroup '#T_PhatSinhSum', '#T_BaoCao', 'Ma_Vt_Sp', 
				'So_Luong_Vao, So_Luong_Ra, So_Luong', @Language_Type, @Ma_DvCs

		--Cập nhật phần nhóm
		UPDATE #T_BaoCao SET 
			Ma_Vt_Sp = ColumnID,
			Ten_Vt_Sp = ColumnName, 
			Bold = 1
		
		EXECUTE Sp_Copy_Data '#T_PhatSinhSum', '#T_BaoCao'

		UPDATE #T_BaoCao SET 
				Ten_Vt_Sp = T2.Ten_Vt 
			FROM #T_BaoCao T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt

		UPDATE #T_BaoCao SET Ten_Vt_Sp = '' WHERE Bold = 0
		
		UPDATE #T_BaoCao SET 
				@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
				Stt_Sx = LTRIM(RTRIM(STR(@_RowID)))
			WHERE Bold = 1
		
		SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS Stt_Sx, String AS Stt_Sx_Char
			INTO #T_Stt_Sx
			FROM dbo.fn_Split('A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z')
			
		UPDATE T1 SET Stt_Sx = T2.Stt_Sx_Char
			FROM #T_BaoCao T1 JOIN #T_Stt_Sx T2 ON T1.Stt_Sx = T2.Stt_Sx

		UPDATE #T_BaoCao SET Stt_Sx = T2.Stt
			FROM #T_BaoCao T1 JOIN (SELECT ROW_NUMBER() OVER (PARTITION BY Ma_Vt_Sp ORDER BY SortPath, Level, Ma_Vt_Sp, Ma_Dt) AS Stt, Ma_Vt_Sp, Ma_Dt FROM #T_BaoCao WHERE Bold = 0) T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt_Sp AND T1.Ma_Dt = T2.Ma_Dt
			WHERE Bold = 0
		
		INSERT INTO #T_BaoCao(Ten_Vt_Sp, So_Luong_Vao, So_Luong_Ra, So_Luong, SortPath, Bold)
		SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), SUM(So_Luong_Vao), SUM(So_Luong_Ra), SUM(So_Luong), MAX(SortPath) + 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0

		SELECT *, So_Luong AS Khoi_Luong
			FROM #T_BaoCao
			ORDER BY SortPath, Level, Ma_Vt_Sp
	END
	
	ELSE IF @Kieu_Nh = '2' --Nhom theo Khach hang
	BEGIN
		SELECT	Ma_Dt, MAX(Ten_Dt) AS Ten_Dt,
				Ma_Vt_Sp, MAX(Ten_Vt_Sp) AS Ten_Vt_Sp,
				SUM(So_Luong_Vao) AS So_Luong_Vao,
				SUM(So_Luong_Ra) AS So_Luong_Ra,
				SUM(So_Luong) AS So_Luong,
				MAX(Stt_Sx) AS Stt_Sx
			INTO #T_PhatSinhSum0
			FROM #T_PhatSinh
			GROUP BY Ma_Dt, Ma_Vt_Sp
		
		
		CREATE INDEX Ma_Dt ON #T_PhatSinhSum0(Ma_Dt)
		CREATE INDEX Ma_Vt_Sp ON #T_PhatSinhSum0(Ma_Vt_Sp)

		EXEC sp_BuildGroup '#T_PhatSinhSum0', '#T_BaoCao', 'Ma_Dt', 
				'So_Luong_Vao, So_Luong_Ra, So_Luong', @Language_Type, @Ma_DvCs

		--Cập nhật phần nhóm
		UPDATE #T_BaoCao SET 
			Ma_Dt = ColumnID,
			Ten_Dt = ColumnName, 
			Bold = 1
		
		EXECUTE Sp_Copy_Data '#T_PhatSinhSum0', '#T_BaoCao'

		UPDATE #T_BaoCao SET 
				Ten_Dt = T2.Ten_Dt
			FROM #T_BaoCao T1 JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt

		UPDATE #T_BaoCao SET Ten_Dt = '' WHERE Bold = 0

		UPDATE #T_BaoCao SET 
				@_RowID = (CASE WHEN @_RowID IS NULL THEN 0 ELSE @_RowID END) + 1,
				Stt_Sx = LTRIM(RTRIM(STR(@_RowID)))
			WHERE Bold = 1
		
		SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS Stt_Sx, String AS Stt_Sx_Char
			INTO #T_Stt_Sx0
			FROM dbo.fn_Split('A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z')
			
		UPDATE T1 SET Stt_Sx = T2.Stt_Sx_Char
			FROM #T_BaoCao T1 JOIN #T_Stt_Sx0 T2 ON T1.Stt_Sx = T2.Stt_Sx

		UPDATE #T_BaoCao SET Stt_Sx = T2.Stt
			FROM #T_BaoCao T1 JOIN (SELECT ROW_NUMBER() OVER (PARTITION BY Ma_Dt ORDER BY SortPath, Level, Ma_Dt, Ma_Vt_Sp) AS Stt, Ma_Dt, Ma_Vt_Sp FROM #T_BaoCao WHERE Bold = 0) T2 ON T1.Ma_Dt = T2.Ma_Dt AND T1.Ma_Vt_Sp = T2.Ma_Vt_Sp
			WHERE Bold = 0
		
		INSERT INTO #T_BaoCao(Ten_Dt, So_Luong_Vao, So_Luong_Ra, So_Luong, SortPath, Bold)
		SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), SUM(So_Luong_Vao), SUM(So_Luong_Ra), SUM(So_Luong), MAX(SortPath) + 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0

		SELECT *, So_Luong AS Khoi_Luong
			FROM #T_BaoCao
			ORDER BY SortPath, Level, Ma_Dt
		
	END
 	
	IF Object_Id('TempDB..#T_Stt_Sx') IS NOT NULL		
		DROP TABLE #T_Stt_Sx
	
	IF Object_Id('TempDB..#T_Stt_Sx0') IS NOT NULL		
		DROP TABLE #T_Stt_Sx0

	IF Object_Id('TempDB..#T_PhatSinhSum') IS NOT NULL		
		DROP TABLE #T_PhatSinhSum
	
	IF Object_Id('TempDB..#T_PhatSinhSum0') IS NOT NULL		
		DROP TABLE #T_PhatSinhSum0

END
GO
