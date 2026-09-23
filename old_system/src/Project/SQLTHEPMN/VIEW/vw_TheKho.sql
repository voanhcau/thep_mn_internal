
--DROP VIEW vw_TheKho
ALTER VIEW [dbo].[vw_TheKho]
-- WITH ENCRYPTION
AS
	SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '1' AS Loai_Ct, 
			T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 2) AS So_Luong, CAST (0 AS MONEY) AS So_Luong_Cay, CAST (0 AS VARCHAR(10)) AS So_Me, CAST (0 AS VARCHAR(10)) AS Mac_Thep, CAST (0 AS VARCHAR(10)) AS Loai_Phoi, CAST (0 AS MONEY) AS DDai_Phoi, CAST (0 AS BIT) AS Phoi_Ngan,
			T1.Gia, ROUND(T1.Tien, 0) + (CASE WHEN T1.Tk_No5 LIKE '15%' THEN ROUND(T1.Tien5, 0) ELSE 0 END) + (CASE WHEN T1.Tk_No6 LIKE '15%' THEN ROUND(T1.Tien6, 0) ELSE 0 END) AS Tien, ROUND(T1.Tien3, 0) AS Tien3, ROUND(T1.Tien5, 0) AS Tien5, ROUND(T1.Tien6, 0) AS Tien6, 
			T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) + (CASE WHEN T1.Tk_No5 LIKE '15%' THEN ROUND(T1.Tien_Nt5, 2) ELSE 0 END) + (CASE WHEN T1.Tk_No6 LIKE '15%' THEN ROUND(T1.Tien_Nt6, 2) ELSE 0 END) AS Tien_Nt, ROUND(T1.TIen_Nt3, 2) AS TIen_Nt3, ROUND(T1.Tien_Nt5, 2) AS Tien_Nt5, ROUND(T1.TIen_Nt6, 2) AS TIen_Nt6, 
			T1.Tk_No AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, CAST('' AS VARCHAR(20)) AS Ma_Kv, T1.Ma_Kho AS Ma_KhoN, CAST('' AS VARCHAR(20)) AS Ma_KhoX, 
			T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, CAST(0 AS BIT) AS Auto_Cost, T1.Stt_Org, CAST('' AS VARCHAR(20)) AS So_Xe, T1.Ma_DvCs 
		FROM dbo.R02CTNM T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
							JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 1
		WHERE (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '')
		UNION ALL 
		SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '2' AS Loai_Ct, 
				T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 2) AS So_Luong, CAST (0 AS MONEY) AS So_Luong_Cay, CAST (0 AS VARCHAR(10)) AS So_Me, CAST (0 AS VARCHAR(10)) AS Mac_Thep, CAST (0 AS VARCHAR(10)) AS Loai_Phoi, CAST (0 AS MONEY) AS DDai_Phoi, CAST (0 AS BIT) AS Phoi_Ngan,
				T1.Gia, ROUND(T1.Tien, 0) AS Tien, ROUND(T1.Tien3, 0) AS Tien3, ROUND(T1.Tien5, 0) AS Tien5, ROUND(T1.Tien6, 0) AS Tien6, 
				T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) AS Tien_Nt, ROUND(T1.Tien_Nt3, 2) AS Tien_Nt3, ROUND(T1.Tien_Nt5, 2) AS Tien_Nt5, ROUND(T1.Tien_Nt6, 2) AS Tien_Nt6, 
				T1.Tk_Co AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, CAST('' AS VARCHAR(20)) AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_KhoN, T1.Ma_Kho AS Ma_KhoX, 
				T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, CAST(0 AS BIT) AS Auto_Cost, T1.Stt_Org, CAST('' AS VARCHAR(20)) AS So_Xe, T1.Ma_DvCs 
			FROM dbo.R02CTNM T1  WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
								JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 2
			WHERE (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '')
		UNION ALL
		SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '1' AS Loai_Ct, 
				T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 2) AS So_Luong, CAST (0 AS MONEY) AS So_Luong_Cay, CAST (0 AS VARCHAR(10)) AS So_Me, CAST (0 AS VARCHAR(10)) AS Mac_Thep, CAST (0 AS VARCHAR(10)) AS Loai_Phoi, CAST (0 AS MONEY) AS DDai_Phoi, CAST (0 AS BIT) AS Phoi_Ngan,
				T1.Gia, ROUND(T1.Tien, 0) AS Tien, ROUND(T1.Tien3, 0) AS Tien3, CAST(0 AS MONEY) AS Tien5, CAST(0 AS MONEY) AS Tien6, 
				T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) AS Tien_Nt, ROUND(T1.Tien_Nt3, 2) AS Tien_Nt3, CAST(0 AS MONEY) AS Tien_Nt5, CAST(0 AS MONEY) AS Tien_Nt6, 
				T1.Tk_No AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, T1.Ma_Dt_CbNv, T1.Ma_Kv, T1.Ma_Kho AS Ma_KhoN, CAST('' AS VARCHAR(20)) AS Ma_KhoX, 
				T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, T1.Auto_Cost, T1.Stt_Org, So_Xe, T1.Ma_DvCs 
			FROM dbo.R04CTHD T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
								JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 1
			WHERE (T1.Ma_Kho <> '' AND T1.Ma_Vt <> ''  AND T1.Ma_Ct <> 'HD') 
		UNION ALL 
		SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '2' AS Loai_Ct, 
				T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 2) AS So_Luong, CAST (0 AS MONEY) AS So_Luong_Cay, CAST (0 AS VARCHAR(10)) AS So_Me, CAST (0 AS VARCHAR(10)) AS Mac_Thep, CAST (0 AS VARCHAR(10)) AS Loai_Phoi, CAST (0 AS MONEY) AS DDai_Phoi, CAST (0 AS BIT) AS Phoi_Ngan,
				T1.Gia, ROUND(T1.Tien, 0) AS Tien, ROUND(T1.Tien3, 0) AS Tien3, CAST(0 AS MONEY) AS Tien5, CAST(0 AS MONEY) AS Tien6, 
				T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) AS Tien_Nt, ROUND(T1.TIen_Nt3, 2) AS TIen_Nt3, CAST(0 AS MONEY) AS Tien_Nt5, CAST(0 AS MONEY) AS Tien_Nt6, 
				T1.Tk_Co AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, T1.Ma_Dt_CbNv, T1.Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_KhoN, T1.Ma_Kho AS Ma_KhoX, 
				T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, T1.Auto_Cost, T1.Stt_Org, So_Xe, T1.Ma_DvCs 
			FROM dbo.R04CTHD T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
								JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 2
			WHERE (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '' AND T1.Ma_Ct <> 'HD') 
		UNION ALL 
		SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '1' AS Loai_Ct, 
				T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 2) AS So_Luong, ROUND(T1.So_Luong_Cay, 3) AS So_Luong_Cay, So_Me, Mac_Thep, Loai_Phoi, DDai_Phoi, Phoi_Ngan,
				T1.Gia, ROUND(T1.Tien, 0) AS Tien, CAST(0 AS MONEY) AS Tien3, CAST(0 AS MONEY) AS Tien5, CAST(0 AS MONEY) AS Tien6, 
				T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) AS Tien_Nt, CAST(0 AS MONEY) AS TIen_Nt3, CAST(0 AS MONEY) AS Tien_Nt5, CAST(0 AS MONEY) AS Tien_Nt6, 
				T1.Tk_No AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, CAST('' AS VARCHAR(20)) AS Ma_Kv, T1.Ma_Kho AS Ma_KhoN, CAST('' AS VARCHAR(20)) AS Ma_KhoX, 
				T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, T1.Auto_Cost, T1.Stt_Org, So_Xe, T1.Ma_DvCs 
			FROM dbo.R05CTNX T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
								JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 1
			WHERE (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '')
		UNION ALL 
		SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '2' AS Loai_Ct, 
				T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, T1.So_Luong, ROUND(T1.So_Luong_Cay, 3) AS So_Luong_Cay, So_Me, Mac_Thep, Loai_Phoi, DDai_Phoi, Phoi_Ngan,
				T1.Gia, ROUND(T1.Tien, 0) AS Tien, CAST(0 AS MONEY) AS Tien3, CAST(0 AS MONEY) AS Tien5, CAST(0 AS MONEY) AS Tien6, 
				T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) AS Tien_Nt, CAST(0 AS MONEY) AS Tien_Nt3, CAST(0 AS MONEY) AS Tien_Nt5, CAST(0 AS MONEY) AS Tien_Nt6, 
				T1.Tk_Co AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, CAST('' AS VARCHAR(20)) AS Ma_Kv, CAST('' AS VARCHAR(20)) AS Ma_KhoN, T1.Ma_Kho AS Ma_KhoX, 
				T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, T1.Auto_Cost, T1.Stt_Org, So_Xe, T1.Ma_DvCs 
			FROM dbo.R05CTNX T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
								JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 2
			WHERE (T1.Ma_Kho <> '' AND T1.Ma_Vt <> '')
		UNION ALL --Nhập do [Xuất chuyển kho]
		SELECT  T1.Stt, T1.Stt0, T1.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Ma_Tte, T1.Ty_Gia, T1.Ong_Ba, T1.Dien_Giai, '1' AS Loai_Ct, 
				T1.Ma_KhoN AS Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 0) AS So_Luong, ROUND(T1.So_Luong_Cay, 3) AS So_Luong_Cay, So_Me, Mac_Thep, Loai_Phoi, DDai_Phoi, Phoi_Ngan,
				T1.Gia, ROUND(T1.Tien, 0) AS Tien, CAST(0 AS MONEY) AS Tien3, CAST(0 AS MONEY) AS Tien5, CAST(0 AS MONEY) AS Tien6, 
				T1.Gia_Nt, ROUND(T1.Tien_Nt, 2) AS Tien_Nt, CAST(0 AS MONEY) AS Tien_Nt3, CAST(0 AS MONEY) AS Tien_Nt5, CAST(0 AS MONEY) AS Tien_Nt6, 
				T1.Tk_No AS Tk, T1.Tk_No, T1.Tk_Co, T1.Ma_Dt, T1.Ma_Vt_Sp, T1.Ma_Bp, T1.Ma_Km, T1.Ma_Hd, T1.Ma_Job, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, CAST('' AS VARCHAR(20)) AS Ma_Kv, T1.Ma_KhoN, T1.Ma_Kho AS Ma_KhoX, 
				T1.Ngay_Ct0, T1.So_Ct0, T1.So_Seri0, T1.Auto_Cost, T1.Stt_Org, So_Xe, T1.Ma_DvCs 
			FROM dbo.R05CTNX T1 WITH (NOLOCK) JOIN dbo.R80PH T2 WITH (NOLOCK) ON T1.Stt = T2.Stt AND T2.Duyet = 1
								JOIN dbo.R00DMCT T3 ON T1.Ma_Ct = T3.Ma_Ct AND T3.Nh_Ct = 2
			WHERE (T1.Ma_Kho <> '' AND T1.Ma_KhoN <> '' AND T1.Ma_Vt <> '')
		UNION ALL --Nhập do [Xuất lắp ráp]
		SELECT  T1.Stt, 999 AS Stt0, T2.Ma_Nvu, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T2.Ma_Tte, T2.Ty_Gia, T2.Ong_Ba, T2.Dien_Giai, '1' AS Loai_Ct, 
				T1.Ma_Kho, T1.Ma_Vt, T1.Dvt, ROUND(T1.So_Luong, 2) AS So_Luong, CAST (0 AS MONEY) AS So_Luong_Cay, CAST (0 AS VARCHAR(10)) AS So_Me, CAST (0 AS VARCHAR(10)) AS Mac_Thep, CAST (0 AS VARCHAR(10)) AS Loai_Phoi, CAST (0 AS MONEY) AS DDai_Phoi, CAST (0 AS BIT) AS Phoi_Ngan,
				CASE WHEN T1.So_Luong <> 0 THEN T2.Tien / T1.So_Luong ELSE CAST(0 AS MONEY) END AS Gia, ROUND(T2.Tien, 0) AS Tien, CAST(0 AS MONEY) AS Tien3, CAST(0 AS MONEY) AS Tien5, CAST(0 AS MONEY) AS Tien6, 
				CASE WHEN T1.So_Luong <> 0 THEN T2.Tien_Nt / T1.So_Luong ELSE CAST(0 AS MONEY) END AS Gia_Nt, ROUND(T2.Tien_Nt, 2) AS Tien_Nt, CAST(0 AS MONEY) AS Tien_Nt3, CAST(0 AS MONEY) AS Tien_Nt5, CAST(0 AS MONEY) AS Tien_Nt6, 
				T2.Tk_No AS Tk, T2.Tk_No, T2.Tk_Co, T2.Ma_Dt, T2.Ma_Vt_Sp, T2.Ma_Bp, T2.Ma_Km, T2.Ma_Hd, T2.Ma_Job, CAST('' AS VARCHAR(20)) AS Ma_Dt_CbNv, CAST('' AS VARCHAR(20)) AS Ma_Kv, T1.Ma_Kho AS Ma_KhoN, T2.Ma_Kho AS Ma_KhoX, 
				T2.Ngay_Ct0, T2.So_Ct0, T2.So_Seri0, CAST(0 AS BIT) AS Auto_Cost, T2.Stt_Org, CAST('' AS VARCHAR(20)) AS So_Xe, T2.Ma_DvCs 
			FROM dbo.R05CTNXLR T1 WITH (NOLOCK) INNER JOIN 
						(SELECT T3.Stt, MAX(T3.Ma_Nvu) AS Ma_Nvu, MAX(T3.Ma_Ct) AS Ma_Ct, MAX(T3.Ong_Ba) AS Ong_Ba, MAX(T3.Dien_Giai) AS Dien_Giai, MAX(T3.Ma_Tte) AS Ma_Tte, MAX(T3.Ty_Gia) AS Ty_Gia, SUM(T3.Tien_Nt) AS Tien_Nt, SUM(T3.Tien) AS Tien,
								MAX(T3.Ma_Kho) AS Ma_Kho, MAX(T3.Ma_Dt) AS Ma_Dt, MAX(T3.Ma_Bp) AS Ma_Bp, MAX(T3.Ma_Km) AS Ma_Km , MAX(T3.Ma_Vt_Sp) AS Ma_Vt_Sp, MAX(T3.Ma_Hd) AS Ma_Hd, MAX(T3.Ma_Job) AS Ma_Job, MAX(T3.Tk_No) AS Tk_No, MAX(T3.Tk_Co) AS Tk_Co, 
								MAX(T3.So_Ct0) AS So_Ct0, MAX(T3.Ngay_Ct0) AS Ngay_Ct0, MAX(T3.So_Seri0) AS So_Seri0, MAX(T3.Stt_Org) AS Stt_Org, MAX(T3.Ma_DvCs) AS Ma_DvCs
							FROM dbo.R05CTNX T3 WITH (NOLOCK) JOIN dbo.R80PH T4 WITH (NOLOCK) ON T3.Stt = T4.Stt AND T4.Duyet = 1
							WHERE T3.Ma_Ct = 'LR' AND T3.Ma_Kho <> '' AND T3.Ma_Vt <> ''
							GROUP BY T3.Stt) T2 ON T1.Stt = T2.Stt 
			WHERE T1.Ma_Ct = 'LR'
GO