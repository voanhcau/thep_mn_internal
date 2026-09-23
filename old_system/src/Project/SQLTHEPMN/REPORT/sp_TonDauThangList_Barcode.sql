/*
--Tồn đâu từ năm 2012 đến tháng trước
--SELECT  Barcode, Ma_Vt_Sp, Ma_Vt, Standard_ID, Grade_ID, Ma_CL, Lot_ID, Num_Lot, No_Melt,
--		Num_Bars, So_Luong, So_Luong_Barem, Try_ID, Yeild, Tension, ELong, Bend_Test, Num_Bars_Embryos
--	INTO #T_TonCuoi_Barcode
--	FROM R81DMBARCODE
--	WHERE 0 = 1
--GO
--EXEC sp_TonDauThangList_Barcode '20150706', '', '#T_TonCuoi_Barcode', 'A01'
*/
ALTER PROCEDURE [dbo].[sp_TonDauThangList_Barcode]
(
	@Ngay_Ct DATE = '',
	@Key NVARCHAR(4000) = '',
	@Table_Out VARCHAR(50),
	@Ma_DvCs VARCHAR(5)
)
--WITH ENCRYPTION
AS

	IF Object_Id('Tempdb..#T_TonDauList0') IS NOT NULL DROP TABLE #T_TonDauList0
	IF Object_Id('Tempdb..#T_TonDauList1') IS NOT NULL DROP TABLE #T_TonDauList1
	IF Object_Id('Tempdb..#T_TonDauListSum') IS NOT NULL DROP TABLE #T_TonDauListSum

	DECLARE @_Key NVARCHAR(4000),
			@_KeyCd NVARCHAR(4000),
			@_Key_TLB NVARCHAR(4000),
			@_Nam INT, 
			@_Th_Bd_Ht INT, 
			@_Ngay_Ct1 DATE,
			@_Ngay_Ct2 DATE,
			@_Tong_Hop AS BIT

	SET @_Tong_Hop = (SELECT Tong_Hop FROM R00DMDVCS WHERE Ma_DvCs = @Ma_DvCs)
	SET @_Nam = YEAR(@Ngay_Ct) 
	SET @_Th_Bd_Ht = ISNULL((SELECT Th_Bd_Ht FROM R00NAM WHERE Ma_DvCs = @Ma_DvCs AND Nam = @_Nam), 1)

	SELECT	@_Ngay_Ct1 = dbo.fn_GetDate(2012, 1, 1),
			@_Ngay_Ct2 = DATEADD(DD,-(DAY(@Ngay_Ct)), @Ngay_Ct)

	SELECT	@_Key = '(0 = 0)',
			@_KeyCd = '(0 = 0)',
			@_Key_TLB = '(0 = 0)'

	SET @_Key_TLB = @_Key_TLB + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@_Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@_Ngay_Ct2) + ''')'

	IF (@Key <> '')
		SELECT	@_Key = @_Key + ' AND (' + @Key + ')',
				@_KeyCd = @_KeyCd + ' AND (' + @Key + ')',
				@_Key_TLB = @_Key_TLB + ' AND (' + @Key + ')'
	
	IF @_Tong_Hop = 0
		SELECT	@_Key = @_Key + ' AND (Ma_DvCs = ''' + @Ma_DvCs + ''')',
				@_KeyCd = @_KeyCd + ' AND (Ma_Data = ''' + @Ma_DvCs + ''')',
				@_Key_TLB = @_Key_TLB + ' AND (Ma_DvCs = ''' + @Ma_DvCs + ''')'
	ELSE
		SELECT	@_Key = @_Key + ' AND (Ma_DvCs IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop = 0))',
				@_KeyCd = @_KeyCd + ' AND (Ma_Data IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop = 0))',
				@_Key_TLB = @_Key_TLB + ' AND (Ma_DvCs IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop = 0))'
	
	SET @_KeyCd = @_KeyCd + ' AND (Is_OutPut = 1) AND (Ngay_Nhap >= ''' + dbo.fn_DTOS(@_Ngay_Ct1) + ''' AND Ngay_Nhap <= ''' + dbo.fn_DTOS(@_Ngay_Ct2) + ''')'

	--Lay ton dau tu truoc den dau thang hien tai
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, Grade_ID, Length, So_Luong, So_Luong_Barem, Num_Bars, Date_Process
		INTO #T_TonDauList0
		FROM R81DMBARCODE
		WHERE 0 = 1
	
	EXEC sp_Copy_Data 'R81DMBARCODE', '#T_TonDauList0', '', @_KeyCd
	
	DELETE FROM #T_TonDauList0 WHERE Date_Process > @Ngay_Ct
	
	--Lay so phat sinh tu ngay ap dung den thoi diem hien tai tru di 1 thang
	IF (@_Ngay_Ct2 > @_Ngay_Ct1)
	BEGIN
		
		SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars
			INTO #T_TonDauList1
			FROM R05CTX_BARCODE
			WHERE 0 = 1

		EXEC sp_ScanTableBarcode @_Ngay_Ct1, @_Ngay_Ct2, @_Key, '#T_TonDauList1', @Ma_DvCs
		
		UPDATE #T_TonDauList1 SET
				So_Luong = -So_Luong,
				Num_Bars = -Num_Bars
		
		INSERT INTO #T_TonDauList0(Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars)
			SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars FROM #T_TonDauList1
	END

	--Lay so phat sinh tu dau den thoi diem hien tai cho phieu nhap tra lai
	IF (@_Ngay_Ct2 > @_Ngay_Ct1)
	BEGIN
		SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars
			INTO #T_TonDauList2
			FROM R05CTN_BARCODE
			WHERE 0 = 1
			
		INSERT #T_TonDauList2(Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars)
		EXEC('SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars
			FROM R05CTN_BARCODE WITH(NOLOCK)
			WHERE ' + @_Key_TLB)

		INSERT INTO #T_TonDauList0(Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars)
			SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars FROM #T_TonDauList2
	END

	SELECT Barcode, Ma_Vt_Sp, Ma_Size,
			MAX(Grade_ID) AS Grade_ID,
			MAX(Length) AS Length,
			SUM(So_Luong) AS Ton_Dau,
			SUM(So_Luong_Barem) AS Ton_Dau_Barem,
			SUM(Num_Bars) AS Ton_Dau_Num_Bars
		INTO #T_TonDauListSum
		FROM #T_TonDauList0		
		GROUP BY Barcode, Ma_Vt_Sp, Ma_Size

	DELETE #T_TonDauListSum
		WHERE ABS(Ton_Dau) = 0

	EXEC sp_Copy_Data '#T_TonDauListSum', @Table_Out, '', ''

	DROP TABLE #T_TonDauList0
	DROP TABLE #T_TonDauListSum
	IF Object_ID('#T_TonDauList1') IS NOT NULL DROP TABLE #T_TonDauList1

RETURN
--SELECT  Barcode, Ma_Vt_Sp, Ma_Vt, Standard_ID, Grade_ID, Ma_CL, Lot_ID, Num_Lot, No_Melt,
--		Num_Bars, So_Luong, So_Luong_Barem, Try_ID, Yeild, Tension, ELong, Bend_Test, Num_Bars_Embryos
--	INTO #T_TonCuoi_Barcode
--	FROM R81DMBARCODE
--	WHERE 0 = 1
--GO
--EXEC sp_TonDauThangList_Barcode '20150706', '', '#T_TonCuoi_Barcode', 'A01'