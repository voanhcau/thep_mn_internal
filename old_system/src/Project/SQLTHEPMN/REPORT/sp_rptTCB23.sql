/*
SET DATEFORMAT DMY
EXEC sp_rptTCB23 '20150601','20150630', '', 'B'

SELECT TOP 10 * FROM R81DmBarcode 
*/
--Báo cáo Tổng hợp sản lượng sản xuất
ALTER PROCEDURE [dbo].[sp_rptTCB23]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@Ca VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Kieu_Nhom VARCHAR(20) = '1',
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
		WHERE Barcode_Org = '' AND (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) 
				AND T2.Ca = CASE WHEN @Ca = '' THEN T2.Ca ELSE @Ca END 
				AND T1.Ma_Vt_Sp = CASE WHEN @Ma_Vt_Sp = '' THEN T1.Ma_Vt_Sp ELSE @Ma_Vt_Sp END 


	IF @Kieu_Nhom = '0' --Khong nhom theo Ca
		UPDATE #T_Detail SET Ca = ''
	
	SELECT Ma_Vt_Sp, Ca, 
			CAST('' AS NVARCHAR(300)) AS Ten_Vt_Sp, 
			COUNT(Ma_Vt_Sp) AS So_Bo, 
			SUM(Num_Bars) AS So_Cay, 
			SUM(So_Luong) AS So_Luong, 
			SUM(So_Luong_Barem) AS So_Luong_Barem, 
			SUM(CASE WHEN Is_Output = 1 THEN 1 ELSE 0 END) AS So_Bo_NT,
			SUM(CASE WHEN Is_Output = 1 THEN Num_Bars ELSE 0 END) AS So_Cay_NT,
			SUM(CASE WHEN Is_Output = 1 THEN So_Luong ELSE 0 END) AS So_Luong_NT,
			CAST(0 AS MONEY) AS So_Luong_CL,
			CAST(0 AS MONEY) AS PT_CL,
			CAST(3 AS INT) AS Level, 
			CAST(0 AS BIT) AS Bold
		INTO #T_BaoCao 
		FROM #T_Detail 
		GROUP BY Ma_Vt_Sp, Ca

	EXEC sp_DefaultTable '#T_BaoCao'

	UPDATE #T_BaoCao SET Ten_Vt_Sp = T2.Ten_Vt FROM R81DmVt T2 WHERE #T_BaoCao.Ma_Vt_Sp = T2.Ma_Vt

	IF (@Kieu_Nhom = '1')
	BEGIN
		INSERT INTO #T_BaoCao (Ca, Ten_Vt_Sp, So_Bo, So_Cay, So_Luong, So_Bo_NT, So_Cay_NT, So_Luong_NT, Level, Bold)
			SELECT Ca, 'Total Ca ' + Ca, SUM(So_Bo), SUM(So_Cay), SUM(So_Luong), SUM(So_Bo_NT), SUM(So_Cay_NT), SUM(So_Luong_NT), 2, 1
				FROM #T_BaoCao
				GROUP BY Ca
	END	

	INSERT INTO #T_BaoCao (Ca, Ten_Vt_Sp, So_Bo, So_Cay, So_Luong, So_Bo_NT, So_Cay_NT, So_Luong_NT, Level, Bold)
		SELECT 'Z', N'Tổng cộng', SUM(So_Bo), SUM(So_Cay), SUM(So_Luong), SUM(So_Bo_NT), SUM(So_Cay_NT), SUM(So_Luong_NT), 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0
	
	UPDATE #T_BaoCao SET So_Luong_CL = So_Luong - So_Luong_NT, PT_CL = CASE WHEN So_Luong_NT = 0 THEN 0 ELSE So_Luong * 100/So_Luong_NT END

	SELECT *
		FROM #T_BaoCao
		ORDER BY Ca, Level
	
END