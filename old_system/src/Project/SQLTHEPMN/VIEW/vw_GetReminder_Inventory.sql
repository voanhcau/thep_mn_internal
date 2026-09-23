USE R50THEPMN3
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[vw_GetReminder_Inventory]
--WITH ENCRYPTION
AS

	WITH R1 AS
	(
		SELECT	Ngay_Current = GETDATE()
				--Ngay_Current = (SELECT ISNULL(MAX(Ngay_Ct), GETDATE()) FROM vw_DoanhThu WHERE Ngay_Ct <= GETDATE())
	)
	,R2 AS
	(
		SELECT	Ngay_Ct_Thang1 = dbo.fn_GetDate(YEAR(R1.Ngay_Current), MONTH(R1.Ngay_Current), 1),
				Ngay_Ct_Thang2 = dbo.fn_GetDate(YEAR(R1.Ngay_Current), MONTH(R1.Ngay_Current), 1),
				Ngay_Ct_Nam1 = dbo.fn_GetDate(YEAR(R1.Ngay_Current), 1, 1),
				Ngay_Ct_Nam2 = DATEADD(day, -1, dbo.fn_GetDate(YEAR(R1.Ngay_Current) + 1, 1, 1))
			FROM R1
	)
	,T1 AS
	(
		SELECT Ma_Vt, SUM(SL_Nhap - SL_Xuat) AS Value, Ma_DvCs
			FROM R90TheKhoThang T1, R1, R2
			WHERE Nam = YEAR(R1.Ngay_Current) AND Thang BETWEEN MONTH(R2.Ngay_Ct_Nam1) AND MONTH(R2.Ngay_Ct_Thang2)
			GROUP BY T1.Ma_Vt, T1.Ma_DvCs
			--UNION ALL
			--SELECT T1.Ma_Vt, ISNULL(SUM(CASE WHEN T1.Loai_Ct = '1' THEN 1 ELSE -1 END * T1.So_Luong), 0) AS Value, T1.Ma_DvCs
			--	FROM vw_TheKho T1 WITH (NOLOCK), R1, R2
			--	WHERE T1.Ngay_Ct BETWEEN R2.Ngay_Ct_Nam1 AND R1.Ngay_Current AND (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '')
			--	GROUP BY T1.Ma_Vt, T1.Ma_DvCs
			UNION ALL
			SELECT T1.Ma_Vt, ISNULL(SUM(T1.Ton_Dau), 0) AS Value, T1.Ma_DvCs 
				FROM R80SDV T1 WITH (NOLOCK), R1, R2
				WHERE T1.Nam = YEAR(R1.Ngay_Current) AND (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '')
				GROUP BY T1.Ma_Vt, T1.Ma_DvCs
	)
	SELECT 'REMIN_STOCK_CURRENT' AS Object_ID, ISNULL(SUM(T1.Value), 0) AS Value, T1.Ma_DvCs, '*' AS Member_ID 
		FROM R1, R2, T1
		GROUP BY T1.Ma_DvCs
		UNION ALL
		SELECT 'REMIN_STOCK_MIN' AS Object_ID, ISNULL(COUNT(DISTINCT T1.Ma_Vt), 0) AS Value, T1.Ma_DvCs, '*' AS Member_ID 
			FROM R1, R2, T1 INNER JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt
			WHERE T1.Value < T2.Sl_Ton_Min AND T2.SL_Ton_Min > 0
			GROUP BY T1.Ma_DvCs
		UNION ALL
		SELECT 'REMIN_STOCK_MAX' AS Object_ID, ISNULL(COUNT(DISTINCT T1.Ma_Vt), 0) AS Value, T1.Ma_DvCs, '*' AS Member_ID 
			FROM R1, R2, T1 INNER JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt
			WHERE T1.Value > T2.Sl_Ton_Max AND T2.Sl_Ton_Max > 0
			GROUP BY T1.Ma_DvCs
		UNION ALL
		 	SELECT 'REMIN_MEAM' AS Object_ID, ISNULL(COUNT(DISTINCT T1.So_Me), 0) AS Value, '*' AS Ma_DvCs, '*' AS Member_ID 
			FROM (SELECT T2.So_Me, Phan_Loai_Phoi, SUM(SL_Ton_D +Ton_Dau) AS SL_Ton_D FROM vw_NhapXuatPhoi T2 JOIN 
			(SELECT So_Me, Ton_Dau FROM R80SDVPHOI WHERE Ngay_Ct = '20150701') T3 ON T2.So_Me = T3.So_Me GROUP BY T2.So_Me, Phan_Loai_Phoi) T1
			WHERE SL_Ton_D < 0 AND Phan_Loai_Phoi <> ''
			

GO
