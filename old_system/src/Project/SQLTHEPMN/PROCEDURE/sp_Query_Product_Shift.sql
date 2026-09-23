/*
EXEC sp_Query_Product_Shift '20150401', '20150430', ''
*/
ALTER PROCEDURE [dbo].[sp_Query_Product_Shift]
(
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@Ca VARCHAR(5) = ''
)
AS
BEGIN
	SELECT	T1.Ma_Ca, 
			T1.Ngay_Sx, 
			T1.Ca, 
			CAST(T1.Gio_Begin AS VARCHAR(8)) AS Gio_Begin, CAST(T1.Gio_End AS VARCHAR(8)) AS Gio_End, 
			MAX(T1.Ma_Dt_CbNv_TC) AS Ma_Dt_CbNv_TC, ISNULL(MAX(T2.Ten_Dt), '') AS Ten_Dt_CbNv_TC,
			MAX(T1.Ma_Dt_CbNv_KCS) AS Ma_Dt_CbNv_KCS, ISNULL(MAX(T3.Ten_Dt), '') AS Ten_Dt_CbNv_KCS, 
			MAX(T1.Ma_Dt_CbNv_Can) AS Ma_Dt_CbNv_Can, ISNULL(MAX(T4.Ten_Dt), '') AS Ten_Dt_CbNv_Can, 
			T1.Ended, 
			ISNULL(COUNT(T5.Barcode), 0) AS TSo_Bo, ISNULL(SUM(T5.Num_Bars), 0) AS TSo_Cay, ISNULL(SUM(T5.So_Luong), 0) AS TSo_Luong_Kg 
		FROM R81DMCA T1 LEFT JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv_TC = T2.Ma_Dt 
					LEFT JOIN R81DMDT T3 ON T1.Ma_Dt_CbNv_KCS = T3.Ma_Dt 
					LEFT JOIN R81DMDT T4 ON T1.Ma_Dt_CbNv_Can = T4.Ma_Dt 
					LEFT JOIN R81DmBarcode T5 ON T1.Ma_Ca = T5.Ma_Ca 
		WHERE (T1.Ngay_Sx >= @Ngay_Ct1 AND T1.Ngay_Sx <= @Ngay_Ct2) AND (T1.Ca = CASE WHEN @Ca = '' THEN T1.Ca ELSE @Ca END)
		GROUP BY T1.Ma_Ca, T1.Ngay_Sx, T1.Ca, T1.Gio_Begin, T1.Gio_End, T1.Ended
		ORDER BY T1.Ngay_Sx

END