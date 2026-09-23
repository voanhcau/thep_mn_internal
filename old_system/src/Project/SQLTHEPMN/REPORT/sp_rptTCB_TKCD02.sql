--Báo cáo Tổng hợp tồn kho --Không barcode
ALTER PROCEDURE [dbo].[sp_rptTCB_TKCD02]
(	
	@Ngay_Ct DATETIME = '',
	@Ma_Kho VARCHAR(20) = '',
	@Ma_Size VARCHAR(20) = '',
	@Ma_Vt_Sp_List VARCHAR(1000) = '',
	@Is_Vnd BIT = 1,
	@Is_CheckInventory BIT = 0,
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
		
	IF @Ma_Vt_Sp_List <> ''	
		SELECT @_Key = '(Ma_Vt_Sp = ''' + REPLACE(@Ma_Vt_Sp_List, ',', ''' OR Ma_Vt_Sp = ''') + ''')'

	
	--Lay so du dau	
	SELECT Barcode, Ma_Vt_Sp, Ma_Size, Length, Grade_ID, So_Luong AS Ton_Dau, Num_Bars AS Ton_Dau_Num_Bars
		INTO #T_Barcode
		FROM R81DMBARCODE
		WHERE 0 = 1
	
	EXEC sp_TonCuoiList_Barcode @Ngay_Ct, @Ma_Kho, @_Key, '#T_Barcode', @Ma_DvCs
	
	SELECT Barcode, Ma_Vt_Sp, Ma_Size,
			CAST('' AS NVARCHAR(200)) AS Ten_Size,
			Grade_ID,
			CAST('' AS NVARCHAR(200)) AS Grade_Name,
			Length,
			CAST('' AS VARCHAR(20)) AS Ma_Ca,
			CAST('' AS VARCHAR(20)) AS Ca,
			CAST('19000101' AS DATE) AS Ngay_Nhap,
			SUM(Ton_Dau) AS Ton_Cuoi_Khoi_Luong,
			SUM(Ton_Dau_Num_Bars) AS Ton_Cuoi_Num_Bars
		INTO #T_TonCuoi
		FROM #T_Barcode
		GROUP BY Barcode, Ma_Vt_Sp, Ma_Size, Grade_ID, Length

	UPDATE T1 SET
			Ma_Ca = T2.Ma_Ca
		FROM #T_TonCuoi T1 LEFT JOIN R81DMBARCODE T2 ON T1.Barcode = T2.Barcode

	UPDATE T1 SET Ngay_Nhap = ISNULL(T2.Ngay_Sx, ''), Ca = ISNULL(T2.Ca, '')
		FROM #T_TonCuoi T1 LEFT JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca
		
	SELECT *,
			CAST(3 AS INT) AS Level, 
			CAST(0 AS BIT) AS Bold
		INTO #T_BaoCao
		FROM #T_TonCuoi
	
	EXEC sp_DefaultTable '#T_BaoCao'

	UPDATE #T_BaoCao SET Ten_Size = T2.Ten_Size
		FROM #T_BaoCao T1 JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size
		
	UPDATE #T_BaoCao SET Grade_Name = T2.Grade_Name
		FROM #T_BaoCao T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

	IF @Is_CheckInventory = 0
	BEGIN
		INSERT INTO #T_BaoCao (Ten_Size, Ton_Cuoi_Khoi_Luong, Ton_Cuoi_Num_Bars, Level, Bold)
			SELECT dbo.fn_GetLanguage('Tong_Cong', @Language_Type), 
					ISNULL(SUM(Ton_Cuoi_Khoi_Luong), 0), ISNULL(SUM(Ton_Cuoi_Num_Bars), 0), 1, 1
				FROM #T_BaoCao
				WHERE Bold = 0

		SELECT *
			FROM #T_BaoCao
			ORDER BY Level, Ten_Size
		
		RETURN
	END
	ELSE
	BEGIN
		SELECT *, Ton_Cuoi_Khoi_Luong AS Khoi_Luong, Ton_Cuoi_Num_Bars AS Num_Bars
			FROM #T_BaoCao
			ORDER BY Level, Ten_Size

		RETURN
	END
END
--GO
--EXEC sp_rptTCB_TKCD02 '20150625', 'L', '', 'B35510320,B35410250,B35410180', 1, 0
