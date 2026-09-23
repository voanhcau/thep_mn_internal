/*
SET DATEFORMAT DMY
EXEC sp_rptTCB22 '20150401','20150430', '01150059082'

SELECT TOP 10 * FROM R81DmBarcode 
*/
--Báo cáo Tổng hợp sản lượng sản xuất
ALTER PROCEDURE [dbo].[sp_rptTCB22]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Barcode VARCHAR(50) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@Ca VARCHAR(20) = '',
	@Kieu_Nhom VARCHAR(20) = '1',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SELECT T1.*, T2.Ca,
			1 AS So_Bo,
			T1.Num_Bars AS So_Cay,
			CAST('' AS NVARCHAR(300)) AS Ten_Vt_Sp, 
			CAST(3 AS INT) AS Level, 
			CAST(0 AS BIT) AS Bold
		INTO #T_BaoCao 
		FROM R81DmBarcode T1 WITH(NOLOCK) JOIN R81DmCa T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca 
		WHERE Barcode_Org = '' AND (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) 
				AND T1.Barcode = CASE WHEN @Barcode = '' THEN T1.Barcode ELSE @Barcode END 
				AND T2.Ca = CASE WHEN @Ca = '' THEN T2.Ca ELSE @Ca END 
				AND T1.Ma_Vt_Sp = CASE WHEN @Ma_Vt_Sp = '' THEN T1.Ma_Vt_Sp ELSE @Ma_Vt_Sp END 

	IF @Kieu_Nhom = '0' --Khong nhom theo Ca
		UPDATE #T_BaoCao SET Ca = ''
	
	EXEC sp_DefaultTable '#T_BaoCao'

	UPDATE #T_BaoCao SET Ten_Vt_Sp = T2.Ten_Vt FROM R81DmVt T2 WHERE #T_BaoCao.Ma_Vt_Sp = T2.Ma_Vt

	IF (@Kieu_Nhom = '1')
	BEGIN
		INSERT INTO #T_BaoCao (Ca, Ten_Vt_Sp, Num_Bars, So_Bo, So_Cay, So_Luong, So_Luong_Barem, Level, Bold)
			SELECT Ca, 'Total Ca ' + Ca, SUM(Num_Bars), SUM(So_Bo), SUM(So_Cay), SUM(So_Luong), SUM(So_Luong_Barem), 2, 1
				FROM #T_BaoCao
				GROUP BY Ca
	END	

	INSERT INTO #T_BaoCao (Ca, Ten_Vt_Sp, Num_Bars, So_Bo, So_Cay, So_Luong, So_Luong_Barem, Level, Bold)
		SELECT 'Z', N'Tổng cộng', SUM(Num_Bars), SUM(So_Bo), SUM(So_Cay), SUM(So_Luong), SUM(So_Luong_Barem), 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0
	
	SELECT *
		FROM #T_BaoCao
		ORDER BY Ca, Level
	
END