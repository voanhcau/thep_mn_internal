/*
SET DATEFORMAT DMY
EXEC sp_rptTCB28 @Ngay_Ct1 = '20151201', @Ngay_Ct2 = '20151228', @Kieu_Nh = '1'
*/
--Báo cáo San pham cho xu ly
ALTER PROCEDURE [dbo].[sp_rptTCB28]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Size VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Kieu_Nh CHAR(1) = '0',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SELECT T1.*, T2.Ca
		INTO #T_Detail
		FROM R81DmBarcode T1 WITH(NOLOCK) JOIN R81DmCa T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca 
		WHERE T1.Barcode_Org = '' AND T1.Is_Wait_Process = 1 AND (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2)
				AND (T1.Ma_Size = CASE WHEN @Ma_Size = '' THEN T1.Ma_Size ELSE @Ma_Size END)
				AND (T1.Grade_ID = CASE WHEN @Grade_ID = '' THEN T1.Grade_ID ELSE @Grade_ID END)
		ORDER BY Ma_Size
	
	--Tong hop
	IF @Kieu_Nh = '0'
	BEGIN
		SELECT	CONVERT(VARCHAR, ROW_NUMBER() OVER (ORDER BY Ma_Size)) AS Stt_Sx,
				Ma_Size, CAST('' AS NVARCHAR(200)) AS Ten_Size,
				Grade_ID, CAST('' AS NVARCHAR(200)) AS Grade_Name,
				MAX(Length) AS Length,
				MAX(Remark) AS DKPH,
				ISNULL(COUNT(Barcode), 0) AS So_Bo,
				ISNULL(SUM(So_Luong), 0) AS Khoi_Luong_Barcode,
				CAST(0 AS BIT) AS Bold
			INTO #T_BaoCao_Sum
			FROM #T_Detail
			GROUP BY Ma_Size, Grade_ID

		EXEC sp_DefaultTable '#T_BaoCao_Sum'

		UPDATE T1 SET Ten_Size = T2.Ten_Size
			FROM #T_BaoCao_Sum T1 JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size

		UPDATE T1 SET Grade_Name = T2.Grade_Name
			FROM #T_BaoCao_Sum T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

		UPDATE #T_BaoCao_Sum SET Ten_Size = Ten_Size + CASE WHEN Length = 0 THEN '' ELSE ' x ' + dbo.fn_FormatNumber(Length, 3, '') END + ' - ' + Grade_Name
	
		INSERT INTO #T_BaoCao_Sum (Stt_Sx, Ten_Size, Khoi_Luong_Barcode, Bold)
			SELECT 'A', UPPER(dbo.fn_GetLanguage('Tong_Cong', @Language_Type)), ISNULL(SUM(Khoi_Luong_Barcode), 0), 1
				FROM #T_BaoCao_Sum

		SELECT *
			FROM #T_BaoCao_Sum
			ORDER BY Ma_Size
	END
	ELSE
	BEGIN
		SELECT	CONVERT(VARCHAR, ROW_NUMBER() OVER (ORDER BY Ngay_Nhap)) AS Stt_Sx ,
				Ngay_Nhap, Ma_Ca, MAX(Ca) AS Ca,
				Ma_Size, CAST('' AS NVARCHAR(200)) AS Ten_Size,
				Grade_ID, CAST('' AS NVARCHAR(200)) AS Grade_Name,
				MAX(Length) AS Length, No_Melt,
				Barcode,
				MAX(Remark) AS DKPH,
				MAX(Remark_KCS) AS Remark_KCS,
				ISNULL(SUM(So_Luong), 0) AS Khoi_Luong_Barcode,
				CAST(0 AS BIT) AS Bold
		INTO #T_BaoCao_Detail
		FROM #T_Detail
		GROUP BY Ngay_Nhap, Ma_Ca, Ma_Size, Grade_ID, No_Melt, Barcode

		EXEC sp_DefaultTable '#T_BaoCao_Detail'

		UPDATE T1 SET Ten_Size = T2.Ten_Size
			FROM #T_BaoCao_Detail T1 JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size

		UPDATE T1 SET Grade_Name = T2.Grade_Name
			FROM #T_BaoCao_Detail T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

		UPDATE #T_BaoCao_Detail SET Ten_Size = Ten_Size + CASE WHEN Length = 0 THEN '' ELSE ' x ' + dbo.fn_FormatNumber(Length, 3, '') END + ' - ' + Grade_Name
	
		INSERT INTO #T_BaoCao_Detail (Stt_Sx, Ten_Size, Khoi_Luong_Barcode, Bold)
			SELECT 'A', UPPER(dbo.fn_GetLanguage('Tong_Cong', @Language_Type)), ISNULL(SUM(Khoi_Luong_Barcode), 0), 1
				FROM #T_BaoCao_Detail

		SELECT *
			FROM #T_BaoCao_Detail
			ORDER BY Ngay_Nhap
	END

END