--SET DATEFORMAT DMY
--sp_rptTCB_TKT01 @Ngay_Ct1 = '01/04/2015', @Ngay_Ct2 = '30/04/2015', @Ma_Kho = 'CCDC', @Ma_DvCs =  'A01'
--Báo cáo tổng hợp nhập xuất tồn
ALTER PROCEDURE [dbo].[sp_rptTCB_TKT01]
(	
	@Ngay_Ct1 DATE = '20150401',
	@Ngay_Ct2 DATE = '20150415',
	@Ma_Size VARCHAR(20) = '',
	@Is_Vnd BIT = 1,
	@Language_Type CHAR(1) = 'V',
	@Ma_Dvcs VARCHAR(5) = 'A01'
)
--WITH ENCRYPTION
AS
BEGIN	
	
	DECLARE @_SQLExec VARCHAR(4000),
			@_Key NVARCHAR(4000),
			@_Key_Barcode_Ngay VARCHAR(MAX),
			@_Key_Barcode_Thang VARCHAR(MAX)
			
	IF Object_ID('TempDB..#T_TonDau') IS NOT NULL DROP TABLE #T_TonDau	
	IF Object_ID('TempDB..#T_TheKho') IS NOT NULL DROP TABLE #T_TheKho	
	IF Object_ID('TempDB..#T_TheKho1') IS NOT NULL DROP TABLE #T_TheKho1	
	IF Object_ID('TempDB..#T_TheKhoSum') IS NOT NULL DROP TABLE #T_TheKhoSum
 			
	--Tao Key	
	SET @_Key = '( 0 = 0)'
	SET @_Key_Barcode_Ngay = '( 0 = 0)'
	SET @_Key_Barcode_Thang = '( 0 = 0)'

	IF @Ma_Size <> ''
		SELECT	@_Key = @_Key + ' AND (Ma_Size = ''' + @Ma_Size + ''')',
				@_Key_Barcode_Ngay = @_Key_Barcode_Ngay + ' AND (Ma_Size = ''' + @Ma_Size + ''')',
				@_Key_Barcode_Thang = @_Key_Barcode_Thang + ' AND (Ma_Size = ''' + @Ma_Size + ''')'
	
	SET @_Key_Barcode_Ngay = @_Key_Barcode_Ngay + ' AND (Is_OutPut = 1) AND (Ngay_Nhap >= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''' AND Ngay_Nhap <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'
	SET @_Key_Barcode_Thang = @_Key_Barcode_Thang + ' AND (Is_OutPut = 1) AND (Ngay_Nhap >= ''' + dbo.fn_DTOS(@Ngay_Ct1) + ''' AND Ngay_Nhap <= ''' + dbo.fn_DTOS(@Ngay_Ct2) + ''')'


	CREATE TABLE #T_PhatSinh
	(
		Ma_Nh VARCHAR(30) DEFAULT(''),
		Ma_Vt_Sp VARCHAR(20) DEFAULT(''),
		Ma_Size VARCHAR(20) DEFAULT(''),
		Grade_ID VARCHAR(20) DEFAULT(''),
		
		Ton_Dau_Thang MONEY,
		Ton_Dau_Thang_Num_Bars MONEY,
		Ton_Dau_Thang_So_Bo MONEY,
		
		Ton_Dau_Ngay MONEY,
		Ton_Dau_Ngay_Num_Bars MONEY,
		Ton_Dau_Ngay_So_Bo MONEY,

		Sl_Nhap_Ngay MONEY,
		Sl_Nhap_Ngay_Num_Bars MONEY,
		Sl_Nhap_Ngay_So_Bo MONEY,

		Sl_Nhap_Lk MONEY,
		Sl_Nhap_Lk_Num_Bars MONEY,
		Sl_Nhap_Lk_So_Bo MONEY,

		Sl_Xuat_Ngay MONEY,
		Sl_Xuat_Ngay_Num_Bars MONEY,
		Sl_Xuat_Ngay_So_Bo MONEY,

		Sl_Xuat_Lk MONEY,
		Sl_Xuat_Lk_Num_Bars MONEY,
		Sl_Xuat_Lk_So_Bo MONEY
	)
	EXEC sp_DefaultTable '#T_PhatSinh'

	--Lay so du dau	cua thang
	SELECT Barcode, Ma_Size, Ma_Vt_Sp, Grade_ID, So_Luong AS Ton_Dau, Num_Bars AS Ton_Dau_Num_Bars
		INTO #T_TonDau_Thang
		FROM R81DMBARCODE
		WHERE 0 = 1
	
	EXEC sp_TonDauThangList_Barcode @Ngay_Ct1, @_Key, '#T_TonDau_Thang', @Ma_DvCs		
	
	INSERT #T_PhatSinh(Ma_Vt_Sp, Ma_Size, Grade_ID, Ton_Dau_Thang, Ton_Dau_Thang_Num_Bars, Ton_Dau_Thang_So_Bo)
	SELECT Ma_Vt_Sp, Ma_Size, Grade_ID,
			SUM(Ton_Dau) AS Ton_Dau_Thang_Khoi_Luong,
			SUM(Ton_Dau_Num_Bars) AS Ton_Dau_Thang_Num_Bars,
			COUNT(Barcode) AS So_Bo_Thang
		FROM #T_TonDau_Thang
		GROUP BY Ma_Vt_Sp, Ma_Vt, Grade_ID
		
	--Ton dau ngay
	--Lay so du dau	cua thang
	SELECT Barcode, Ma_Size, Ma_Vt_Sp, Grade_ID, So_Luong AS Ton_Dau, Num_Bars AS Ton_Dau_Num_Bars
		INTO #T_TonDau_Ngay
		FROM R81DMBARCODE
		WHERE 0 = 1

	EXEC sp_TonDauNgayList_Barcode @Ngay_Ct2, @_Key, '#T_TonDau_Ngay', @Ma_DvCs		
	
	INSERT #T_PhatSinh(Ma_Vt_Sp, Ma_Size, Grade_ID, Ton_Dau_Ngay, Ton_Dau_Ngay_Num_Bars, Ton_Dau_Ngay_So_Bo)	
	SELECT Ma_Vt_Sp, Ma_Size, Grade_ID,
			SUM(Ton_Dau) AS Ton_Dau_Ngay_Khoi_Luong,
			SUM(Ton_Dau_Num_Bars) AS Ton_Dau_Ngay_Num_Bars,
			COUNT(Barcode) AS So_Bo_Ngay
		FROM #T_TonDau_Ngay
		GROUP BY Ma_Vt_Sp, Ma_Size, Grade_ID

	--Nhap trong ngay
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, Grade_ID, So_Luong, Num_Bars
		INTO #T_NhapTrongNgay
		FROM R81DMBARCODE
		WHERE 0 = 1
		
	EXEC sp_Copy_Data 'R81DMBARCODE', '#T_NhapTrongNgay', '', @_Key_Barcode_Ngay
	
	INSERT #T_PhatSinh(Ma_Vt_Sp, Ma_Size, Grade_ID, Sl_Nhap_Ngay, Sl_Nhap_Ngay_Num_Bars, Sl_Nhap_Ngay_So_Bo)	
	SELECT Ma_Vt_Sp, Ma_Size, Grade_ID,
			SUM(So_Luong) AS Sl_Nhap_Ngay,
			SUM(Num_Bars) AS Sl_Nhap_Ngay_Num_Bars,
			COUNT(Barcode) AS Sl_Nhap_Ngay_So_Bo
		FROM #T_NhapTrongNgay
		GROUP BY Ma_Vt_Sp, Ma_Size, Grade_ID

	--Nhap trong thang hien tai
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, Grade_ID, So_Luong, Num_Bars
		INTO #T_Nhap_Lk
		FROM R81DMBARCODE
		WHERE 0 = 1
		
	EXEC sp_Copy_Data 'R81DMBARCODE', '#T_Nhap_Lk', '', @_Key_Barcode_Thang
	
	INSERT #T_PhatSinh(Ma_Vt_Sp, Ma_Size, Grade_ID, Sl_Nhap_Lk, Sl_Nhap_Lk_Num_Bars, Sl_Nhap_Lk_So_Bo)	
	SELECT Ma_Vt_Sp, Ma_Size, Grade_ID,
			SUM(So_Luong) AS Sl_Nhap_Lk,
			SUM(Num_Bars) AS Sl_Nhap_Lk_Num_Bars,
			COUNT(Barcode) AS Sl_Nhap_Lk_So_Bo
		FROM #T_Nhap_Lk
		GROUP BY Ma_Vt_Sp, Ma_Size, Grade_ID

	--------------------
	--Xuat
	--------------------
	--Xuat trong ngay
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, CAST('' AS VARCHAR(20)) AS Grade_ID, So_Luong, Num_Bars
		INTO #T_XuatTrongNgay
		FROM R05CTX_BARCODE
		WHERE 0 = 1
	
	EXEC sp_ScanTableBarcode @Ngay_Ct2, @Ngay_Ct2, @_Key, '#T_XuatTrongNgay', @Ma_DvCs
	
	UPDATE T1 SET Grade_ID = T2.Grade_ID
		FROM #T_XuatTrongNgay T1 JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode

	INSERT #T_PhatSinh(Ma_Vt_Sp, Ma_Size, Grade_ID, Sl_Xuat_Ngay, Sl_Xuat_Ngay_Num_Bars, Sl_Xuat_Ngay_So_Bo)	
	SELECT Ma_Vt_Sp, Ma_Size, Grade_ID,
			SUM(So_Luong) AS Sl_Nhap_Ngay,
			SUM(Num_Bars) AS Sl_Nhap_Ngay_Num_Bars,
			COUNT(Barcode) AS Sl_Nhap_Ngay_So_Bo
		FROM #T_XuatTrongNgay
		GROUP BY Ma_Vt_Sp, Ma_Size, Grade_ID

	
	--Nhap trong thang hien tai
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, CAST('' AS VARCHAR(20)) AS Grade_ID, So_Luong, Num_Bars
		INTO #T_Xuat_LK
		FROM R05CTX_BARCODE
		WHERE 0 = 1
		
	EXEC sp_ScanTableBarcode @Ngay_Ct1, @Ngay_Ct2, @_Key, '#T_Xuat_LK', @Ma_DvCs
	
	UPDATE T1 SET Grade_ID = T2.Grade_ID
		FROM #T_Xuat_LK T1 JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode

	INSERT #T_PhatSinh(Ma_Vt_Sp, Ma_Size, Grade_ID, Sl_Nhap_Lk, Sl_Nhap_Lk_Num_Bars, Sl_Nhap_Lk_So_Bo)	
	SELECT Ma_Vt_Sp, Ma_Size, Grade_ID,
			SUM(So_Luong) AS Sl_Xuat_Lk,
			SUM(Num_Bars) AS Sl_Xuat_Lk_Num_Bars,
			COUNT(Barcode) AS Sl_Xuat_Lk_So_Bo
		FROM #T_Xuat_LK
		GROUP BY Ma_Vt_Sp, Ma_Size, Grade_ID

		CREATE TABLE #T_BaoCao
		(
			Ma_Size VARCHAR(20) DEFAULT(''),
			Ten_Size NVARCHAR(200) DEFAULT(''),
			Ma_Vt_Sp VARCHAR(20) DEFAULT(''),
			Grade_ID VARCHAR(20) DEFAULT(''),
			Bold BIT NOT NULL DEFAULT(0),
			SortPath VARBINARY(MAX),
			Ma_Tg1 VARCHAR(20) DEFAULT(''),
			Ma_Tg2 VARCHAR(20) DEFAULT(''),
			Ma_Tg3 VARCHAR(20) DEFAULT(''),
			ColumnID VARCHAR(20) DEFAULT(''),
			ColumnName NVARCHAR(200) DEFAULT('')
		)
	
			-- Sum Ma_Kho, Ma_Vt
			SELECT	Ma_Vt_Sp, Ma_Size, Grade_ID,
				SUM(Ton_Dau_Thang) AS Ton_Dau_Thang,
				SUM(Ton_Dau_Thang_Num_Bars) AS Ton_Dau_Thang_Num_Bars,
				SUM(Ton_Dau_Thang_So_Bo) AS Ton_Dau_Thang_So_Bo,
				SUM(Ton_Dau_Ngay) AS Ton_Dau_Ngay,
				SUM(Ton_Dau_Ngay_Num_Bars) AS Ton_Dau_Ngay_Num_Bars,
				SUM(Ton_Dau_Ngay_So_Bo) AS Ton_Dau_Ngay_So_Bo,
				SUM(Sl_Nhap_Ngay) AS Sl_Nhap_Ngay,
				SUM(Sl_Nhap_Ngay_Num_Bars) AS Sl_Nhap_Ngay_Num_Bars,
				SUM(Sl_Nhap_Ngay_So_Bo) AS Sl_Nhap_Ngay_So_Bo,
				SUM(Sl_Nhap_Lk) AS Sl_Nhap_Lk,
				SUM(Sl_Nhap_Lk_Num_Bars) AS Sl_Nhap_Lk_Num_Bars,
				SUM(Sl_Nhap_Lk_So_Bo) AS Sl_Nhap_Lk_So_Bo,
				SUM(Sl_Xuat_Ngay) AS Sl_Xuat_Ngay,
				SUM(Sl_Xuat_Ngay_Num_Bars) AS Sl_Xuat_Ngay_Num_Bars,
				SUM(Sl_Xuat_Ngay_So_Bo) AS Sl_Xuat_Ngay_So_Bo,
				SUM(Sl_Xuat_Lk) AS Sl_Xuat_Lk,
				SUM(Sl_Xuat_Lk_Num_Bars) AS Sl_Xuat_Lk_Num_Bars,
				SUM(Sl_Xuat_Lk_So_Bo) AS Sl_Xuat_Lk_So_Bo,
				CAST(0 AS MONEY) AS Ton_Cuoi_Ngay,
				CAST(0 AS MONEY) AS Ton_Cuoi_Ngay_Num_Bars,
				CAST(0 AS MONEY) AS Ton_Cuoi_Ngay_So_Bo
			INTO #T_PhatSinhSum
			FROM #T_PhatSinh
			GROUP BY Ma_Vt_Sp, Ma_Size, Grade_ID
		
			UPDATE #T_PhatSinhSum SET Ton_Cuoi_Ngay = Ton_Dau_Ngay + Sl_Nhap_Ngay - Sl_Xuat_Ngay,
									Ton_Cuoi_Ngay_Num_Bars = Ton_Dau_Ngay_Num_Bars + Sl_Nhap_Ngay_Num_Bars - Sl_Xuat_Ngay_Num_Bars,
									Ton_Cuoi_Ngay_So_Bo = Ton_Dau_Ngay_So_Bo + Sl_Nhap_Ngay_So_Bo - Sl_Xuat_Ngay_So_Bo
		
			CREATE INDEX Grade_ID ON #T_PhatSinhSum(Grade_ID)

			EXEC sp_BuildGroup '#T_PhatSinhSum', '#T_BaoCao', 'Grade_ID', 
					'Ton_Dau_Thang, Ton_Dau_Thang_Num_Bars, Ton_Dau_Thang_So_Bo, Ton_Dau_Ngay, Ton_Dau_Ngay_Num_Bars, Ton_Dau_Ngay_So_Bo,
					Sl_Nhap_Ngay, Sl_Nhap_Ngay_Num_Bars, Sl_Nhap_Ngay_So_Bo, Sl_Nhap_Lk, Sl_Nhap_Lk_Num_Bars, Sl_Nhap_Lk_So_Bo, Sl_Xuat_Ngay, Sl_Xuat_Ngay_Num_Bars,
					Sl_Xuat_Ngay_So_Bo, Sl_Xuat_Lk, Sl_Xuat_Lk_Num_Bars, Sl_Xuat_Lk_So_Bo, Ton_Cuoi_Ngay, Ton_Cuoi_Ngay_Num_Bars, Ton_Cuoi_Ngay_So_Bo', @Language_Type, @Ma_DvCs

			--Cập nhật phần nhóm
			UPDATE #T_BaoCao SET 
				Grade_ID = ColumnID,
				Ten_Size = ColumnName, 
				Bold = 1
		
		EXECUTE Sp_Copy_Data '#T_PhatSinhSum', '#T_BaoCao'

	UPDATE #T_BaoCao SET 
				Ten_Size = T2.Ten_Size
		FROM #T_BaoCao T1 INNER JOIN R81DmSize T2 ON T1.Ma_Size = T2.Ma_Size
		WHERE Bold = 1

	UPDATE #T_BaoCao SET 
				Ten_Size = T2.Ten_Vt
		FROM #T_BaoCao T1 INNER JOIN R81DmVt T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt	

	UPDATE #T_BaoCao SET Ten_Size = SPACE(2*(Level - 1)) + Ten_Vt	
	
	INSERT INTO #T_BaoCao (Ten_Size, Ton_Dau_Thang, Ton_Dau_Thang_Num_Bars, Ton_Dau_Thang_So_Bo, Ton_Dau_Ngay, Ton_Dau_Ngay_Num_Bars, Ton_Dau_Ngay_So_Bo,
					Sl_Nhap_Ngay, Sl_Nhap_Ngay_Num_Bars, Sl_Nhap_Ngay_So_Bo, Sl_Nhap_Lk, Sl_Nhap_Lk_Num_Bars, Sl_Nhap_Lk_So_Bo, Sl_Xuat_Ngay, Sl_Xuat_Ngay_Num_Bars,
					Sl_Xuat_Ngay_So_Bo, Sl_Xuat_Lk, Sl_Xuat_Lk_Num_Bars, Sl_Xuat_Lk_So_Bo, Ton_Cuoi_Ngay, Ton_Cuoi_Ngay_Num_Bars, Ton_Cuoi_Ngay_So_Bo, SortPath, Bold)
		SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), SUM(Ton_Dau_Thang), SUM(Ton_Dau_Thang_Num_Bars), SUM(Ton_Dau_Thang_So_Bo), SUM(Ton_Dau_Ngay), SUM(Ton_Dau_Ngay_Num_Bars), SUM(Ton_Dau_Ngay_So_Bo),
					SUM(Sl_Nhap_Ngay), SUM(Sl_Nhap_Ngay_Num_Bars), SUM(Sl_Nhap_Ngay_So_Bo), SUM(Sl_Nhap_Lk), SUM(Sl_Nhap_Lk_Num_Bars), SUM(Sl_Nhap_Lk_So_Bo), SUM(Sl_Xuat_Ngay), SUM(Sl_Xuat_Ngay_Num_Bars),
					SUM(Sl_Xuat_Ngay_So_Bo), SUM(Sl_Xuat_Lk), SUM(Sl_Xuat_Lk_Num_Bars), SUM(Sl_Xuat_Lk_So_Bo),SUM(Ton_Cuoi_Ngay), SUM(Ton_Cuoi_Ngay_Num_Bars), SUM(Ton_Cuoi_Ngay_So_Bo), MAX(SortPath) + 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0

	SELECT * 
		FROM #T_BaoCao
		ORDER BY SortPath, Level, Ma_Size
	 	
	IF Object_Id('TempDB..#T_TheKhoSum') IS NOT NULL		
		DROP TABLE #T_TheKhoSum 										 
	
	IF Object_Id('TempDB..#T_TheKhoSum0') IS NOT NULL		
		DROP TABLE #T_TheKhoSum0
												
END
--GO
--EXEC sp_rptTCB_TKT01 '20150701','20150705'