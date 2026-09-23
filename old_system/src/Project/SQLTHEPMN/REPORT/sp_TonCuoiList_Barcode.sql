--EXEC sp_TonCuoiList_Barcode '20150430', 'MA_VT = ''10''', '', 'A01'
ALTER PROCEDURE [dbo].[sp_TonCuoiList_Barcode]
(
	@Ngay_Ct DATE = '',
	@Ma_Kho VARCHAR(20) = '',
	@Key NVARCHAR(4000) = '',
	@Table_Out VARCHAR(50),
	@Ma_Data VARCHAR(5) = 'A01'
)
--WITH ENCRYPTION
AS

	IF Object_Id('Tempdb..#T_TonCuoiList0') IS NOT NULL DROP TABLE #T_TonCuoiList0
	IF Object_Id('Tempdb..#T_TonCuoiList1') IS NOT NULL DROP TABLE #T_TonCuoiList1
	IF Object_Id('Tempdb..#T_TonCuoiListSum') IS NOT NULL DROP TABLE #T_TonCuoiListSum

	DECLARE @_Key NVARCHAR(4000),
			@_KeyCd NVARCHAR(4000),
			@_Key_TLB NVARCHAR(4000),
			@_Nam INT, 
			@_Th_Bd_Ht INT, 
			@_Ngay_Ct1 DATE,
			@_Ngay_Ct2 DATE,
			@_Tong_Hop AS BIT

	SET @_Tong_Hop = (SELECT Tong_Hop FROM R00DMDVCS WHERE Ma_Data = @Ma_Data)
	SET @_Nam = YEAR(@Ngay_Ct) 
	
	SELECT	@_Ngay_Ct1 = dbo.fn_GetDate(2012, 1, 1),
			@_Ngay_Ct2 = @Ngay_Ct 

	SELECT	@_Key = '(0 = 0)',
			@_KeyCd = '(0 = 0)',
			@_Key_TLB = '(0 = 0)'

	SET @_Key_TLB = @_Key_TLB + ' AND (Ngay_Ct >= ''' + dbo.fn_DTOS(@_Ngay_Ct1) + ''' AND Ngay_Ct <= ''' + dbo.fn_DTOS(@_Ngay_Ct2) + ''')'

	IF (@Key <> '')
		SELECT	@_Key = @_Key + ' AND (' + @Key + ')',
				@_KeyCd = @_KeyCd + ' AND (' + @Key + ')',
				@_Key_TLB = @_Key_TLB + ' AND (' + @Key + ')'
	
	IF @_Tong_Hop = 0
		SELECT	@_Key = @_Key + ' AND (Ma_DvCs = ''' + @Ma_Data + ''')',
				@_KeyCd = @_KeyCd + ' AND (Ma_Data= ''' + @Ma_Data + ''')',
				@_Key_TLB = @_Key_TLB + ' AND (Ma_DvCs = ''' + @Ma_Data + ''')'
	ELSE
		SELECT	@_Key = @_Key + ' AND (Ma_DvCs IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop = 0))',
				@_KeyCd = @_KeyCd + ' AND (Ma_Data IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop = 0))',
				@_Key_TLB = @_Key_TLB + ' AND (Ma_DvCs IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop = 0))'
	
	IF @Ma_Kho <> '' AND @Ma_Kho = 'L'
		SELECT	@_Key = @_Key + ' AND (LEFT(Barcode, 1) = ''L'')',
				@_KeyCd = @_KeyCd + ' AND (LEFT(Barcode, 1) = ''L'') AND (Is_OutPut = 1) AND (Ngay_Nhap >= ''' + dbo.fn_DTOS(@_Ngay_Ct1) + ''' AND Ngay_Nhap <= ''' + dbo.fn_DTOS(@_Ngay_Ct2) + ''')',
				@_Key_TLB = @_Key_TLB + ' AND (LEFT(Barcode, 1) = ''L'')'

	ELSE IF @Ma_Kho <> '' AND @Ma_Kho <> 'L'
		SELECT	@_Key = @_Key + ' AND (LEFT(Barcode, 1) <> ''L'')',
				@_KeyCd = @_KeyCd + ' AND (LEFT(Barcode, 1) <> ''L'') AND (Is_OutPut = 1) AND (Ngay_Nhap >= ''' + dbo.fn_DTOS(@_Ngay_Ct1) + ''' AND Ngay_Nhap <= ''' + dbo.fn_DTOS(@_Ngay_Ct2) + ''')',
				@_Key_TLB = @_Key_TLB + ' AND (LEFT(Barcode, 1) <> ''L'')'
	ELSE
		SET @_KeyCd = @_KeyCd + ' AND (Is_OutPut = 1) AND (Ngay_Nhap >= ''' + dbo.fn_DTOS(@_Ngay_Ct1) + ''' AND Ngay_Nhap <= ''' + dbo.fn_DTOS(@_Ngay_Ct2) + ''')'
	
	--Lay ton dau nam
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, Grade_ID, Length, So_Luong, So_Luong_Barem, Num_Bars, Date_Process
		INTO #T_TonCuoiList0
		FROM R81DMBARCODE
		WHERE 0 = 1
	
	EXEC sp_Copy_Data 'R81DMBARCODE', '#T_TonCuoiList0', '', @_KeyCd
	
	DELETE FROM #T_TonCuoiList0 WHERE Date_Process > @Ngay_Ct
	
	--Lay so phat sinh tu dau den thoi diem hien tai
	IF (@_Ngay_Ct2 > @_Ngay_Ct1)
	BEGIN
		SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars
			INTO #T_TonCuoiList1
			FROM R05CTX_BARCODE
			WHERE 0 = 1

		EXEC sp_ScanTableBarcode @_Ngay_Ct1, @_Ngay_Ct2, @_Key, '#T_TonCuoiList1', @Ma_Data
		
		UPDATE #T_TonCuoiList1 SET
				So_Luong = -So_Luong,
				Num_Bars = -Num_Bars
		
		INSERT INTO #T_TonCuoiList0(Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars)
			SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars FROM #T_TonCuoiList1
	END
	
	--Lay so phat sinh tu dau den thoi diem hien tai cho phieu nhap tra lai
	IF (@_Ngay_Ct2 > @_Ngay_Ct1)
	BEGIN
		SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars
			INTO #T_TonCuoiList2
			FROM R05CTN_BARCODE
			WHERE 0 = 1
			
		INSERT #T_TonCuoiList2(Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars)
		EXEC('SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars
			FROM R05CTN_BARCODE WITH(NOLOCK)
			WHERE ' + @_Key_TLB)

		INSERT INTO #T_TonCuoiList0(Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars)
			SELECT Barcode, Ma_Vt_Sp, Ma_Size, So_Luong, So_Luong_Barem, Num_Bars FROM #T_TonCuoiList2
	END
	
	SELECT Barcode, Ma_Vt_Sp, Ma_Size,
			MAX(Grade_ID) AS Grade_ID,
			MAX(Length) AS Length,
			SUM(So_Luong) AS Ton_Dau,
			SUM(So_Luong_Barem) AS Ton_Dau_Barem,
			SUM(Num_Bars) AS Ton_Dau_Num_Bars
		INTO #T_TonCuoiListSum
		FROM #T_TonCuoiList0
		GROUP BY Barcode, Ma_Vt_Sp, Ma_Size
	
	DELETE #T_TonCuoiListSum WHERE ABS(Ton_Dau) = 0
	
	IF (@Table_Out <> '')
		EXEC sp_Copy_Data '#T_TonCuoiListSum', @Table_Out, '', ''

	DROP TABLE #T_TonCuoiList0
	
RETURN
GO
--DECLARE @_Key VARCHAR(MAX)
--SET @_Key = '( 0 = 0) AND (Ma_Vt_Sp = ''B35510320'')'
--EXEC sp_TonCuoiList_Barcode '20150615', 'L', @_Key, '#T_TonCuoiList0', 'A01'