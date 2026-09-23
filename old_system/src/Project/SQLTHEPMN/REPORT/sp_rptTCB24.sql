/*
SET DATEFORMAT DMY
EXEC sp_rptTCB23 '20150401','20150430', ''

SELECT TOP 10 * FROM R81DmBarcode 
*/
--Báo cáo Chat luong thep can
ALTER PROCEDURE [dbo].[sp_rptTCB24]
(
	@Ngay_Ct1 DATE = '19000101',
	@Ngay_Ct2 DATE = '19000101',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Language_Type CHAR(1) = 'V',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX),
			@_RowID INT = 0

	SELECT T1.*
		INTO #T_Detail 
		FROM R81DmBarcode T1 WITH(NOLOCK) JOIN R81DmCa T2 WITH(NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca 
		WHERE Barcode_Org = '' AND (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) 
				AND T1.Ma_Vt_Sp = CASE WHEN @Ma_Vt_Sp = '' THEN T1.Ma_Vt_Sp ELSE @Ma_Vt_Sp END
		ORDER BY Ma_Size
	
	SELECT Ma_Vt_Sp,
			MAX(Ma_Size) AS Ma_Size,
			MAX(Length) AS Length,
			CAST('' AS NVARCHAR(300)) AS Ten_Size,
			CAST('' AS NVARCHAR(300)) AS Ten_Vt_Sp,
			COUNT(Barcode) AS So_Bo_SX,
			SUM(So_Luong) AS Khoi_Luong_SX,
			
			SUM(CASE WHEN Is_Output = 1 AND Date_Process = '' THEN 1 ELSE 0 END) AS So_Bo_CP,
			SUM(CASE WHEN Is_Output = 1 AND Date_Process = '' THEN So_Luong ELSE 0 END) AS Khoi_Luong_CP,
			
			SUM(CASE WHEN Is_Output = 1 AND Date_Process <> '' THEN 1 ELSE 0 END) AS So_Bo_CXL_NL,
			SUM(CASE WHEN Is_Output = 1 AND Date_Process <> '' THEN So_Luong ELSE 0 END) AS Khoi_Luong_CXL_NL,

			CAST(0 AS MONEY) AS TSo_Bo,
			CAST(0 AS MONEY) AS TKhoi_Luong,

			SUM(CASE WHEN Is_Thu_Pham = 1 THEN 1 ELSE 0 END) AS So_Bo_Thu_Pham,
			SUM(CASE WHEN Is_Thu_Pham = 1 THEN So_Luong ELSE 0 END) AS Khoi_Luong_Thu_Pham,
			
			SUM(CASE WHEN Is_Wait_Process = 1 THEN 1 ELSE 0 END) AS So_Bo_CXL,
			SUM(CASE WHEN Is_Wait_Process = 1 THEN So_Luong ELSE 0 END) AS Khoi_Luong_CXL,

			CAST(3 AS INT) AS Level, 
			CAST(0 AS BIT) AS Bold
		INTO #T_BaoCao 
		FROM #T_Detail 
		GROUP BY Ma_Vt_Sp

	EXEC sp_DefaultTable '#T_BaoCao'

	
	UPDATE #T_BaoCao SET TSo_Bo = So_Bo_CP + So_Bo_CXL_NL, TKhoi_Luong = Khoi_Luong_CP + Khoi_Luong_CXL_NL
	UPDATE #T_BaoCao SET Ten_Vt_Sp = T2.Ten_Vt  + CASE WHEN #T_BaoCao.Length <> 0 THEN + '-' + CAST(#T_BaoCao.Length AS VARCHAR) ELSE '' END FROM R81DmVt T2 WHERE #T_BaoCao.Ma_Vt_Sp = T2.Ma_Vt
	UPDATE #T_BaoCao SET Ten_Size = T2.Ten_Size FROM R81DMSIZE T2 WHERE #T_BaoCao.Ma_Size = T2.Ma_Size

	INSERT INTO #T_BaoCao (Ten_Vt_Sp, So_Bo_SX, Khoi_Luong_SX, So_Bo_CP, Khoi_Luong_CP, So_Bo_CXL_NL, Khoi_Luong_CXL_NL, TSo_Bo, TKhoi_Luong, So_Bo_Thu_Pham, Khoi_Luong_Thu_Pham, So_Bo_CXL, Khoi_Luong_CXL, Level, Bold)
		SELECT N'Tổng cộng', SUM(So_Bo_SX), SUM(Khoi_Luong_SX), SUM(So_Bo_CP), SUM(Khoi_Luong_CP), SUM(So_Bo_CXL_NL), SUM(Khoi_Luong_CXL_NL), SUM(TSo_Bo), SUM(TKhoi_Luong), SUM(So_Bo_Thu_Pham), SUM(Khoi_Luong_Thu_Pham), SUM(So_Bo_CXL), SUM(Khoi_Luong_CXL), 1, 1
			FROM #T_BaoCao
			WHERE Bold = 0
	
	SELECT *
		FROM #T_BaoCao
		ORDER BY Level, Ten_Size
	
END
GO
EXEC sp_rptTCB24 '20150801','20150810', ''