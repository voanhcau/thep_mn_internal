

WITH T_NhapXuatSP AS
(
SELECT Ma_Vt_Sp, 'PH' AS Loai_Sp, T2.Ngay_Sx, SUM(So_Luong) AS So_Luong 
	FROM R81DMBARCODE T1 JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca 
	WHERE Barcode_Org = '' AND T2.Ngay_Sx >= '20160401' AND T2.Ngay_Sx <= '20160430' and Is_Wait_Process = 0 and Is_Thu_Pham = 0 GROUP BY Ma_Vt_Sp
UNION ALL	
SELECT Ma_Vt_Sp, 'CXL' AS Loai_Sp, T2.Ngay_Sx, SUM(So_Luong) AS So_Luong 
	FROM R81DMBARCODE T1 JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca 
	WHERE Barcode_Org = '' AND T2.Ngay_Sx >= '20160401' AND T2.Ngay_Sx <= '20160430' and Is_Wait_Process = 1 and Is_Thu_Pham = 0 GROUP BY Ma_Vt_Sp
UNION ALL	
SELECT Ma_Vt_Sp, 'PP' AS Loai_Sp, T2.Ngay_Sx, SUM(So_Luong) AS So_Luong 
	FROM R81DMBARCODE T1 JOIN R81DMCA T2 ON T1.Ma_Ca = T2.Ma_Ca 
	WHERE Barcode_Org = '' AND T2.Ngay_Sx >= '20160401' AND T2.Ngay_Sx <= '20160430' and Is_Wait_Process = 0 and Is_Thu_Pham = 1 GROUP BY Ma_Vt_Sp		
)
SELECT Ma_Vt_Sp, Loai_Sp, Ngay_Sx, SUM(So_Luong) AS So_Luong
	FROM T_NhapXuatSP
	GROUP BY Ma_Vt_Sp, Loai_Sp, Ngay_Sx
	
	
	
SELECT Ma_Vt, 'PH' AS Loai_Sp, SUM(So_Luong) AS So_Luong FROM R05CTNXPHOI WHERE Phan_Loai_Phoi = 'PH' AND Ngay_Ct BETWEEN '20160401' AND '20160422' AND Ma_Ct = 'PNSB' GROUP BY Ma_Vt
SELECT Ma_Vt, 'PH' AS Loai_Sp, SUM(So_Luong) AS So_Luong FROM R05CTNXLRPHOI WHERE Phan_Loai_Phoi = 'PH' AND Ngay_Ct BETWEEN '20160401' AND '20160422' AND Ma_Ct = 'PNSB' GROUP BY Ma_Vt


SELECT Ma_Vt, 'PP' AS Loai_Sp, SUM(So_Luong) AS So_Luong FROM R05CTNXPHOI WHERE Phan_Loai_Phoi = 'PP' AND Ngay_Ct BETWEEN '20160401' AND '20160422' AND Ma_Ct = 'PNSB' GROUP BY Ma_Vt
SELECT Ma_Vt, 'PP' AS Loai_Sp, SUM(So_Luong) AS So_Luong FROM R05CTNXLRPHOI WHERE Phan_Loai_Phoi = 'PP' AND Ngay_Ct BETWEEN '20160401' AND '20160422' AND Ma_Ct = 'PNSB' GROUP BY Ma_Vt


SELECT T1.Ma_Vt, T1.Phan_Loai_Phoi, T2.Phan_Loai_Phoi, SUM(T1.So_Luong), ISNULL(SUM(T2.SO_LUONG),0) --AS So_Luong
	FROM R05CTNXPHOI T1 LEFT JOIN R05CTNXLRPHOI T2 ON T1.Stt = T2.Stt AND T1.Stt0 = T2.Stt0 
	WHERE T1.Phan_Loai_Phoi = 'CXL' AND T1.Ngay_Ct BETWEEN '20160401' AND '20160430' 
	GROUP BY T1.Ma_Vt, T1.Phan_Loai_Phoi, T2.Phan_Loai_Phoi
	
	

	