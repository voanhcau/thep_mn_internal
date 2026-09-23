/*
SET DATEFORMAT DMY
EXEC sp_rptTCB26 '20150501','20150527', ''
SELECT TOP 10 * FROM R81DmBarcode 
*/
--Báo cáo San pham khong phu hop - chi tiet
ALTER PROCEDURE [dbo].[sp_rptTCBC26]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Vt VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Status CHAR(1) = '1', --1 cho xu ly, 2--thu pham
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
		WHERE 0 = 1

	IF @Status = '1'
		INSERT #T_Detail
		SELECT T1.*, T2.Ca
			FROM R81DmBarcode T1 WITH(NOLOCK) JOIN R81DmCa T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca 
			WHERE T1.Barcode_Org = '' AND T1.Is_Wait_Process = 1 AND (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2)
					AND (T1.Ma_Vt = CASE WHEN @Ma_Vt = '' THEN T1.Ma_Vt ELSE @Ma_Vt END)
					AND (T1.Grade_ID = CASE WHEN @Grade_ID = '' THEN T1.Grade_ID ELSE @Grade_ID END)
			ORDER BY Ma_Vt
	ELSE
		INSERT #T_Detail
		SELECT T1.*, T2.Ca
			FROM R81DmBarcode T1 WITH(NOLOCK) JOIN R81DmCa T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca 
			WHERE T1.Barcode_Org = '' AND T1.Is_Thu_Pham = 1 AND (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2)
					AND (T1.Ma_Vt = CASE WHEN @Ma_Vt = '' THEN T1.Ma_Vt ELSE @Ma_Vt END)
					AND (T1.Grade_ID = CASE WHEN @Grade_ID = '' THEN T1.Grade_ID ELSE @Grade_ID END)
			ORDER BY Ma_Vt

	SELECT	CONVERT(VARCHAR, ROW_NUMBER() OVER (ORDER BY Ngay_Nhap)) AS Stt_Sx , Ngay_Nhap, Ma_Ca, MAX(Ca) AS Ca, Ma_Vt, CAST('' AS NVARCHAR(200)) AS Ten_Vt, Grade_ID, CAST('' AS NVARCHAR(200)) AS Grade_Name, MAX(Length) AS Length, No_Melt, Barcode, MAX(Remark) AS DKPH, MAX(Remark_KCS) AS Remark_KCS,
			ISNULL(SUM(So_Luong), 0) AS Khoi_Luong_Barcode, CAST(0 AS BIT) AS Bold
		INTO #T_BaoCao
		FROM #T_Detail
		GROUP BY Ngay_Nhap, Ma_Ca, Ma_Vt, Grade_ID, No_Melt, Barcode
	
	EXEC sp_DefaultTable '#T_BaoCao'
	
	UPDATE T1 SET Ten_Vt = T2.Ten_Vt
		FROM #T_BaoCao T1 JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt

	UPDATE T1 SET Grade_Name = T2.Grade_Name
		FROM #T_BaoCao T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID

	UPDATE #T_BaoCao SET Ten_Vt = Ten_Vt + CASE WHEN Length = 0 THEN '' ELSE ' x ' + dbo.fn_FormatNumber(Length, 1, '') END + ' - ' + Grade_Name
	
	INSERT INTO #T_BaoCao (Stt_Sx, Ten_Vt, Khoi_Luong_Barcode, Bold)
		SELECT 'A', UPPER(dbo.fn_GetLanguage('Tong_Cong', @Language_Type)), ISNULL(SUM(Khoi_Luong_Barcode), 0), 1
			FROM #T_BaoCao

	SELECT *
		FROM #T_BaoCao
		ORDER BY Ngay_Nhap


	
END
