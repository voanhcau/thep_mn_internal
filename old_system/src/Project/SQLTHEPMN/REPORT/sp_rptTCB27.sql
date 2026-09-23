/*
SET DATEFORMAT DMY
EXEC sp_rptTCB27 '20150501','20150527', ''
*/
--Báo cáo San pham da xu ly trong thang
ALTER PROCEDURE [dbo].[sp_rptTCB27]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Size VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Language_Type CHAR(1) = 'V',
	@Kieu_Nh CHAR(1) = '1',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SELECT T1.*
		INTO #T_Detail
		FROM R81DmBarcode T1 WITH(NOLOCK) LEFT JOIN R81DMCA T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca
		WHERE Barcode_Org = '' AND MONTH(T2.Ngay_Sx) <> MONTH(@Ngay_Ct2) AND (T1.Date_Process BETWEEN @Ngay_Ct1 AND @Ngay_Ct2)
				AND (T1.Ma_Size = CASE WHEN @Ma_Size = '' THEN T1.Ma_Size ELSE @Ma_Size END)
				AND (T1.Grade_ID = CASE WHEN @Grade_ID = '' THEN T1.Grade_ID ELSE @Grade_ID END)
		ORDER BY Ma_Size
	
	IF @Kieu_Nh = '0'
	BEGIN
		SELECT	CONVERT(VARCHAR, ROW_NUMBER() OVER (ORDER BY Ma_Vt_Sp)) AS Stt_Sx,
					Ma_Vt_Sp, CAST('' AS NVARCHAR(200)) AS Ten_Vt_Sp,
				
					MAX(Length) AS Length,

					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) <> 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN 1 ELSE 0 END), 0) AS So_Bo_CP,
					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) <> 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN So_Luong ELSE 0 END), 0) AS Khoi_Luong_CP,
				
					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) = 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN 1 ELSE 0 END), 0) AS So_Bo_Le,
					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) = 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN So_Luong ELSE 0 END), 0) AS Khoi_Luong_Le,

					ISNULL(SUM(CASE WHEN Is_Thu_Pham = 1 THEN 1 ELSE 0 END), 0) AS So_Bo_TP,
					ISNULL(SUM(CASE WHEN Is_Thu_Pham = 1 THEN So_Luong ELSE 0 END), 0) AS Khoi_Luong_TP,
					CAST(0 AS BIT) AS Bold
			INTO #T_BaoCao
			FROM #T_Detail
			GROUP BY Ma_Vt_Sp
	
		EXEC sp_DefaultTable '#T_BaoCao'

		UPDATE T1 SET Ten_Vt_Sp = T2.Ten_Vt
			FROM #T_BaoCao T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt

		UPDATE #T_BaoCao SET Ten_Vt_Sp = UPPER(Ten_Vt_Sp) + CASE WHEN Length = 0 THEN '' ELSE '-' + dbo.fn_FormatNumber(Length, 1, '') + 'M' END
	
		INSERT INTO #T_BaoCao (Stt_Sx, Ten_Vt_Sp, So_Bo_CP, Khoi_Luong_CP, So_Bo_Le, Khoi_Luong_Le, So_Bo_TP, Khoi_Luong_TP, Bold)
			SELECT 'A', UPPER(dbo.fn_GetLanguage('Tong_Cong', @Language_Type)), ISNULL(SUM(So_Bo_CP), 0), ISNULL(SUM(Khoi_Luong_CP), 0), ISNULL(SUM(So_Bo_Le), 0), ISNULL(SUM(Khoi_Luong_Le), 0), ISNULL(SUM(So_Bo_TP), 0), ISNULL(SUM(Khoi_Luong_TP), 0), 1
				FROM #T_BaoCao

		SELECT *
			FROM #T_BaoCao
			ORDER BY Ma_Vt_Sp
	END
	ELSE
	BEGIN
		SELECT	Barcode, Ngay_Nhap, Ma_Vt_Sp, CAST('' AS NVARCHAR(200)) AS Ten_Vt_Sp, Date_Process,					
					
					MAX(Length) AS Length,

					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) <> 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN 1 ELSE 0 END), 0) AS So_Bo_CP,
					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) <> 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN So_Luong ELSE 0 END), 0) AS Khoi_Luong_CP,
				
					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) = 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN 1 ELSE 0 END), 0) AS So_Bo_Le,
					ISNULL(SUM(CASE WHEN (LEFT(Barcode, 1) = 'L') AND (Is_Wait_Process <> 1) AND (Is_Thu_Pham <> 1) THEN So_Luong ELSE 0 END), 0) AS Khoi_Luong_Le,

					ISNULL(SUM(CASE WHEN Is_Thu_Pham = 1 THEN 1 ELSE 0 END), 0) AS So_Bo_TP,
					ISNULL(SUM(CASE WHEN Is_Thu_Pham = 1 THEN So_Luong ELSE 0 END), 0) AS Khoi_Luong_TP,
					CAST(0 AS BIT) AS Bold
			INTO #T_BaoCao1
			FROM #T_Detail
			GROUP BY Barcode, Ngay_Nhap, Ma_Vt_Sp, Date_Process

		EXEC sp_DefaultTable '#T_BaoCao1'

		UPDATE T1 SET Ten_Vt_Sp = T2.Ten_Vt
			FROM #T_BaoCao1 T1 JOIN R81DMVT T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt

		UPDATE #T_BaoCao1 SET Ten_Vt_Sp = UPPER(Ten_Vt_Sp) + CASE WHEN Length = 0 THEN '' ELSE '-' + dbo.fn_FormatNumber(Length, 1, '') + 'M' END
	
		INSERT INTO #T_BaoCao1 (Ten_Vt_Sp, So_Bo_CP, Khoi_Luong_CP, So_Bo_Le, Khoi_Luong_Le, So_Bo_TP, Khoi_Luong_TP, Bold)
			SELECT UPPER(dbo.fn_GetLanguage('Tong_Cong', @Language_Type)), ISNULL(SUM(So_Bo_CP), 0), ISNULL(SUM(Khoi_Luong_CP), 0), ISNULL(SUM(So_Bo_Le), 0), ISNULL(SUM(Khoi_Luong_Le), 0), ISNULL(SUM(So_Bo_TP), 0), ISNULL(SUM(Khoi_Luong_TP),0), 1
				FROM #T_BaoCao1

		SELECT *
			FROM #T_BaoCao1
			ORDER BY Ma_Vt_Sp
	END

END