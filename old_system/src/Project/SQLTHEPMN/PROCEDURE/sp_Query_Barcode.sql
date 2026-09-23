/*
EXEC sp_Query_Barcode '20150401', '20150430', ''

SELECT T1.Barcode, MAX(T2.Stt) 
	FROM R81DMBARCODE T1 JOIN R05CTX_BARCODE T2 ON T1.Barcode = T2.Barcode 
	GROUP BY T1.Barcode HAVING COUNT(T1.Barcode + T2.Stt) > 1

SELECT * FROM R05CTX_BARCODE WHERE Barcode = '01150047392'

*/
ALTER PROCEDURE [dbo].[sp_Query_Barcode]
(
	@Ngay_Ct1 DATE, 
	@Barcode VARCHAR(50) = '', 
	@Ma_Vt_Sp VARCHAR(50) = '', 
	@Ma_Vt VARCHAR(50) = ''
)
AS
BEGIN


	SELECT	T1.Barcode, 
			T1.So_Luong, 
			T1.MA_VT_SP, 
			CAST('' AS NVARCHAR(300)) AS Ten_Vt_Sp, 
			T1.LENGTH, 
			T1.MA_CL, 
			T1.NUM_BARS, 
			T1.GRADE_ID, 
			T1.NUM_LOT, 
			T1.MA_CA, 
			T1.NGAY_NHAP, 
			T1.PRINTED, 
			T1.INPUT_TYPE, 
			T2.Stt AS Stt_Xuat, 
			T2.Ngay_Ct AS NGAY_XUAT, 
			T2.SO_CT AS So_Ct_Xuat, 
			T2.MA_DT, 
			T2.So_Luong AS So_Luong_Xuat, 
			T2.Num_Bars AS So_Cay_Xuat,
			ISNULL(T3.So_Luong, 0) AS So_Luong_Nhap_Lai, 
			ISNULL(T3.Num_Bars, 0) AS So_Cay_Nhap_Lai,
			CAST('' AS NVARCHAR(300)) AS Ten_Dt, 
			CAST('' AS NVARCHAR(100)) AS SO_XE, 
			CAST(CASE WHEN T2.Barcode IS NULL THEN 0 ELSE 1 END AS BIT) AS Da_Xuat, 
			CAST(CASE WHEN T3.Barcode IS NULL THEN 0 ELSE 1 END AS BIT) AS Da_Nhap, 
			T1.CREATE_LOG
		INTO #T_Baocao 
		FROM R81DMBARCODE T1 WITH (NOLOCK) LEFT JOIN R05CTX_BARCODE T2 WITH (NOLOCK) ON T1.Barcode = T2.Barcode
												LEFT JOIN R05CTN_BARCODE T3 WITH (NOLOCK) ON T2.Barcode = T3.Barcode AND T2.Stt = T3.Stt_Org
		WHERE T1.Ngay_Nhap >= @Ngay_Ct1 AND (T1.Barcode LIKE CASE WHEN @Barcode = '' THEN T1.Barcode ELSE '%' + @Barcode + '%' END)
		
	
	EXEC sp_DefaultTable #T_Baocao 
	
	--Neu Barcode nhap lai roi thi kiem Da xuat = 0
	UPDATE #T_Baocao SET Da_Xuat = CASE WHEN Da_Nhap = 1 THEN 0 ELSE Da_Xuat END

	UPDATE #T_Baocao SET So_Xe = T2.So_Xe
		FROM #T_Baocao T1 JOIN R80PH_Scale T2 WITH (NOLOCK) ON T1.Stt_Xuat = T2.Stt

	UPDATE #T_Baocao SET Ten_Dt = T2.Ten_Dt
		FROM #T_Baocao T1 JOIN R81DmDt T2 WITH (NOLOCK) ON T1.Ma_Dt = T2.Ma_Dt

	UPDATE #T_Baocao SET Ten_Vt_Sp = T2.Ten_Vt
		FROM #T_Baocao T1 JOIN R81DmVt T2 WITH (NOLOCK) ON T1.Ma_Vt_Sp = T2.Ma_Vt

	SELECT * 
		FROM #T_Baocao
		ORDER BY Barcode

END