SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vw_SoCai0]
WITH ENCRYPTION
AS
	WITH SYS_MA_TTE AS
	(
		SELECT MAX(Parameter_Value) AS Value
			FROM R00Parameter WITH (NOLOCK)
			WHERE Parameter_ID = 'SYSMA_TTE'
	)
	--CtTien.Tien
	SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
			T1.Tk_No, T1.Tk_Co, 
			CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt, 2) END AS Tien_Nt, 
			ROUND(T1.Tien, 0) AS Tien, 
			T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
			T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
			T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
			T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
			T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
			T1.Ma_Job, '' AS Ma_Vt, '' AS Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
			T1.So_Luong, CAST(0 AS MONEY) AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, T1.Is_UngTruoc, T1.Han_Tt, 
			CAST(0 AS BIT) AS Is_ClTg, CAST('' AS NVARCHAR(100)) AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0,
			CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
		FROM R01CTTIEN T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
		WHERE (ABS(T1.Tien) + ABS(T1.Tien_Nt) <> 0) AND T1.Posted = 1

		UNION ALL --CtTien.Tien3
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No3, T1.Tk_Co3, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt3, 2) END AS Tien_Nt3, 
				ROUND(T1.Tien3, 0) AS Tien3, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, '' AS Ma_Vt, '' AS Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, CAST(0 AS MONEY) AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, T1.Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, CAST('' AS NVARCHAR(100)) AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(3 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R01CTTIEN T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien3) + ABS(T1.Tien_Nt3) <> 0) AND T1.Posted = 1

		UNION ALL --CtKT.Tien
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No, T1.Tk_Co, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt, 2) END AS Tien_Nt, 
				ROUND(T1.Tien, 0) AS Tien, 
				T1.Ma_Dt AS Ma_Dt_No, CASE WHEN T1.Ma_Dt_Co <> '' THEN T1.Ma_Dt_Co ELSE T1.Ma_Dt END AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, CASE WHEN T1.Ma_Vt_Sp_Co <> '' THEN T1.Ma_Vt_Sp_Co ELSE T1.Ma_Vt_Sp END AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, '' AS Ma_Vt, '' AS Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, CAST(0 AS MONEY) AS Gia, T1.Is_KetChuyen, T1.Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, CAST('' AS NVARCHAR(100)) AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R80CTKT T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien) + ABS(T1.Tien_Nt) <> 0) AND T1.Posted = 1

		UNION ALL --CtKT.Tien3
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No3, T1.Tk_Co3, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt3, 2) END AS Tien_Nt3, 
				ROUND(T1.Tien3, 0) AS Tien3, 
				T1.Ma_Dt AS Ma_Dt_No, CASE WHEN T1.Ma_Dt_Co <> '' THEN T1.Ma_Dt_Co ELSE T1.Ma_Dt END AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, CASE WHEN T1.Ma_Vt_Sp_Co <> '' THEN T1.Ma_Vt_Sp_Co ELSE T1.Ma_Vt_Sp END AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, '' AS Ma_Vt, '' AS Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, CAST(0 AS MONEY) AS Gia, T1.Is_KetChuyen, T1.Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, CAST('' AS NVARCHAR(100)) AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(3 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R80CTKT T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien3) + ABS(T1.Tien_Nt3) <> 0) --AND T1.Posted = 1

		UNION ALL --CtNM.Tien
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No, T1.Tk_Co, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt, 2) END AS Tien_Nt, 
				ROUND(T1.Tien, 0) AS Tien, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg , T1.Dien_Giai AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0,
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs 
			FROM R02CTNM T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien) + ABS(T1.Tien_Nt) <> 0) AND T1.Posted = 1

		UNION ALL --CtNM.Tien3
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No3, T1.Tk_Co3, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt3, 2) END AS Tien_Nt3, 
				ROUND(T1.Tien3, 0) AS Tien3, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg , T1.Dien_Giai AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(3 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R02CTNM T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien3) + ABS(T1.Tien_Nt3) <> 0) AND T1.Posted = 1

		UNION ALL --CtNM.Tien5
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No5, T1.Tk_Co5, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt5, 0) END AS Tien_Nt5, 
				ROUND(T1.Tien5, 0) AS Tien5, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg , T1.Dien_Giai AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(3 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R02CTNM T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien5) + ABS(T1.Tien_Nt5) <> 0) AND T1.Posted = 1

		UNION ALL --CtNM.Tien6
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No6, T1.Tk_Co6, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt6, 2) END AS Tien_Nt6, 
				ROUND(T1.Tien6, 0) AS Tien6, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, '' AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong,  T1.Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg , T1.Dien_Giai AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(3 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R02CTNM T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien6) + ABS(T1.Tien_Nt6) <> 0) AND T1.Posted = 1

		UNION ALL --CtHD.Tien
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No, T1.Tk_Co, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt, 2) END AS Tien_Nt, 
				ROUND(T1.Tien, 0) AS Tien, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, T1.Ma_Kv, T1.Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia, CAST(0 AS BIT) AS Is_KetChuyen, 0 AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, T1.Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R04CTHD T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien) + ABS(T1.Tien_Nt) <> 0) --AND T1.Posted = 1

		UNION ALL --CtHD.Tien2
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No2, T1.Tk_Co2, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt2, 2) END AS Tien_Nt2, 
				ROUND(T1.Tien2, 0) AS Tien2, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, T1.Ma_Kv, T1.Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia2 AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, 0 AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, T1.Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R04CTHD T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien2) + ABS(T1.Tien_Nt2) <> 0) AND T1.Posted = 1

		UNION ALL --CtHD.Tien3
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No3, T1.Tk_Co3, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt3, 2) END AS Tien_Nt3, 
				ROUND(T1.Tien3, 0), 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, T1.Ma_Kv, T1.Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia2 AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, 0 AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, T1.Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R04CTHD T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien3) + ABS(T1.Tien_Nt3) <> 0) AND T1.Posted = 1

		UNION ALL --CtHD.Tien4
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No4, T1.Tk_Co4, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt4, 2) END AS Tien_Nt4, 
				ROUND(T1.Tien4, 0) AS Tien4, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, T1.Ma_Kv, T1.Ma_Dt_CbNv, T1.Ma_Thue, 
				T1.So_Luong, T1.Gia2 AS Gia,  CAST(0 AS BIT) AS Is_KetChuyen, 0 AS Is_UngTruoc, T1.Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg, T1.Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R04CTHD T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien4) + ABS(T1.Tien_Nt4) <> 0) AND T1.Posted = 1 AND (T1.Tk_No4 <> '' OR T1.Tk_Co4 <> '')

		UNION ALL --CtNX.Tien
		SELECT T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.So_Ct0, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, 
				T1.Tk_No, T1.Tk_Co, 
				CASE WHEN T1.Ma_Tte = SYS_MA_TTE.Value THEN CAST(0 AS MONEY) ELSE ROUND(T1.Tien_Nt, 2) END AS Tien_Nt, 
				ROUND(T1.Tien, 0) AS Tien, 
				T1.Ma_Dt AS Ma_Dt_No, T1.Ma_Dt AS Ma_Dt_Co, 
				T1.Ma_Vt_Sp AS Ma_Vt_Sp_No, T1.Ma_Vt_Sp AS Ma_Vt_Sp_Co, 
				T1.Ma_Bp AS Ma_Bp_No, T1.Ma_Bp AS Ma_Bp_Co, 
				T1.Ma_Km AS Ma_Km_No, T1.Ma_Km AS Ma_Km_Co, 
				T1.Ma_Hd AS Ma_Hd_No, T1.Ma_Hd AS Ma_Hd_Co, 
				T1.Ma_Job, T1.Ma_Vt, T1.Ma_Kho, '' AS Ma_Kv, '' AS Ma_Dt_CbNv, '' AS Ma_Thue, 
				T1.So_Luong, T1.Gia AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, CAST(0 AS BIT) AS Han_Tt, 
				CAST(0 AS BIT) AS Is_ClTg , T1.Dien_Giai AS Ten_Vt, T1.Ngay_Ct0, T1.So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, T1.Ma_DvCs
			FROM R05CTNX T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1, SYS_MA_TTE
			WHERE (ABS(T1.Tien) + ABS(T1.Tien_Nt) <> 0) AND T1.Posted = 1 

		UNION ALL --HanTt0.Tien_CLTG
		SELECT Stt_TT, 1000 + ROW_NUMBER ( ) OVER(ORDER BY Stt_Tt), '' Ma_Nvu, Ma_Ct_TT, Ngay_Ct_TT, So_Ct_TT, '', 'VND' AS Ma_Tte, 1 AS Ty_Gia, '' AS Ong_Ba, Dien_Giai_TT, 
				Tk_No_ClTg, Tk_Co_ClTg, 0, SUM(ABS(Tien_ClTg)), 
				Ma_Dt AS Ma_Dt_No, Ma_Dt AS Ma_Dt_Co, 
				'' AS Ma_Vt_Sp_No, '' AS Ma_Vt_Sp_Co, 
				'' AS Ma_Bp_No, '' AS Ma_Bp_Co, 
				'' AS Ma_Km_No, '' AS Ma_Km_Co, 
				'' AS Ma_Hd_No, '' AS Ma_Hd_Co, 
				'' AS Ma_Job, '' AS Ma_Vt, '' AS Ma_Kho, '' AS Ma_Kv, '' AS Ma_Dt_CbNv, '' AS Ma_Thue, 
				0 AS So_Luong, 0 AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, CAST(0 AS BIT) AS Han_Tt, 
				CAST(1 AS BIT) AS Is_ClTg, CAST('' AS NVARCHAR(100)) AS Ten_Vt, CAST('' AS DATE) AS Ngay_Ct0, '' AS So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, Ma_DvCs
			FROM R80CtHanTt WITH (NOLOCK)
			WHERE Tien_CLTG <> 0
			GROUP BY Stt_TT, Ma_Ct_TT, Ngay_Ct_TT, So_Ct_TT, Dien_Giai_TT, Tk_No_ClTg, Tk_Co_ClTg, Ma_Dt, Ma_DvCs

		UNION ALL --HanTt0.Tien_CLTG(-)
		SELECT Stt_TT, 1001 + ROW_NUMBER ( ) OVER(ORDER BY Stt_Tt), '' Ma_Nvu, Ma_Ct_TT, Ngay_Ct_TT, So_Ct_TT, '', 'VND' AS Ma_Tte, 1 AS Ty_Gia, '' AS Ong_Ba, Dien_Giai_TT, 
				Tk_No_ClTg2, Tk_Co_ClTg2, 0, -SUM(ABS(Tien_ClTg)), 
				Ma_Dt AS Ma_Dt_No, Ma_Dt AS Ma_Dt_Co, 
				'' AS Ma_Vt_Sp_No, '' AS Ma_Vt_Sp_Co, 
				'' AS Ma_Bp_No, '' AS Ma_Bp_Co, 
				'' AS Ma_Km_No, '' AS Ma_Km_Co, 
				'' AS Ma_Hd_No, '' AS Ma_Hd_Co, 
				'' AS Ma_Job, '' AS Ma_Vt, '' AS Ma_Kho, '' AS Ma_Kv, '' AS Ma_Dt_CbNv, '' AS Ma_Thue, 
				0 AS So_Luong, 0 AS Gia, CAST(0 AS BIT) AS Is_KetChuyen, CAST(0 AS BIT) AS Is_UngTruoc, CAST(0 AS BIT) AS Han_Tt, 
				CAST(1 AS BIT) AS Is_ClTg, CAST('' AS NVARCHAR(100)) AS Ten_Vt, CAST('' AS DATE) AS Ngay_Ct0, '' AS So_Seri0, 
				CAST(0 AS TINYINT) AS Stt_Nvu, Ma_DvCs
			FROM R80CtHanTt WITH (NOLOCK)
			WHERE Tien_CLTG <> 0 AND Tk_No_ClTg2 <> '' AND Tk_Co_ClTg2 <> ''
			GROUP BY Stt_TT, Ma_Ct_TT, Ngay_Ct_TT, So_Ct_TT, Dien_Giai_TT, Tk_No_ClTg2, Tk_Co_ClTg2, Ma_Dt, Ma_DvCs

GO


