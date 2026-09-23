/*
SET DATEFORMAT DMY
GO
EXEC sp_Inherit_Nhap_Barcode '20150501', '20150531', @Is_CXL = 1


SELECT * FROM R81DmBarcode T1 WHERE Ngay_sx >= '20150501' AND Is_Output = 1 AND (T1.Is_Kho_Chan = 0 AND T1.Is_Kho_Le = 0 AND T1.Is_Thu_Pham = 0)
SELECT * FROM R81DmBarcode T1 WHERE Ngay_sx >= '20150501' AND Is_Output = 1 AND (T1.Is_Kho_Chan = 1 OR T1.Is_Kho_Le = 1 OR T1.Is_Thu_Pham = 1)

SELECT * FROM R05CTX_BARCODE WHERE 0=1
SELECT * FROM R81DMBARCODE
SELECT * FROM R05CTNX
SELECT * FROM R80PH_SCALE

ALTER TABLE R05CTNX ADD So_Luong_Bo MONEY NOT NULL DEFAULT(0)
*/
ALTER PROCEDURE [dbo].[sp_Inherit_Nhap_Barcode]
(
	@Ngay_Ct1 DATETIME = '20150101',
	@Ngay_Ct2 DATETIME = '20150327',
	@Ma_Ct VARCHAR(20) = 'TP',
	@Ma_Nvu VARCHAR(20) = 'TP03',
	@Ma_Kho VARCHAR(20) = '',
	@Except_Inherited BIT = 0,
	@Is_CXL BIT = 0, --Chờ xử lý
	@Ma_DvCs VARCHAR(5) = 'A01' 
)
--WITH ENCRYPTION
AS

	DECLARE @_Key NVARCHAR(1000) = '1 = 1',
			@_SQLExec NVARCHAR(MAX) = ''
	
	SELECT	@_Key = @_Key + ' AND (T1.Ngay_Ct BETWEEN ''' + CAST(@Ngay_Ct1 AS VARCHAR(11)) + ''' AND ''' + CAST(@Ngay_Ct2 AS VARCHAR(11)) + ''')'

	IF (@Ma_DvCs <> '')
		 SELECT	@_Key = @_Key + ' AND (T1.Ma_DvCs = ''' + @Ma_DvCs + ''')'

	SELECT	T1.Barcode, 
			T1.Ma_Vt_Sp AS Ma_Vt, 
			T1.Ma_Vt AS Product_ID, 
			T1.Is_Thu_Pham, --Phân biệt nhập [kho TP]/[Kho Thứ phẩm]
			T2.Ngay_Sx AS Ngay_Ct, 
			T1.So_Luong AS So_Luong, 
			T1.Num_Bars AS So_Luong_Cay, 
			T1.So_Luong_Barem AS So_Luong_Barem 
		INTO #T_DmBarcode
		FROM R81DmBarcode T1 WITH (NOLOCK) 
						INNER JOIN R81DMCA T2 WITH (NOLOCK) ON T1.Ma_Ca = T2.Ma_Ca
		WHERE (T2.Ngay_Sx BETWEEN @Ngay_Ct1 AND @Ngay_Ct2) AND
				(T1.Ma_Data = '*' OR T1.Ma_Data = @Ma_DvCs) AND 
				(T1.Is_Output = 1) AND --[Được phép xuất]
				(1 = CASE WHEN @Is_CXL = 0 AND (T1.Is_Thu_Pham = 0) --Bó thép Đạt
							THEN 1  
							ELSE 
								CASE WHEN @Is_CXL = 1 AND (T1.Is_Thu_Pham = 1) --Bó thép Xử lý lại (Sau khi Xử lý nó đc đưa vào Kho_Chan, Kho_Le, Thu_Pham)
								THEN 1  
								ELSE 0 END
							END) 
		ORDER BY T1.Ma_Vt_Sp, T1.Ma_Vt

	SELECT	T1.Ma_Vt, 
			T1.Product_ID, 
			T1.Is_Thu_Pham, --Phân biệt nhập [kho TP]/[Kho Thứ phẩm]
			MAX(T3.Ten_Vt) AS Ten_Vt, 
			MAX(T3.Dvt) AS Dvt, 
			MAX(T1.Ngay_Ct) AS Ngay_Ct, 
			SUM(T1.So_Luong) AS So_Luong, 
			SUM(T1.So_Luong) AS So_Luong9, 
			SUM(T1.So_Luong_Cay) AS So_Luong_Cay, 
			SUM(T1.So_Luong_Barem) AS So_Luong_Barem, 
			MAX(T5.Tk_No) AS Tk_No, 
			MAX(T5.Tk_Co) AS Tk_Co, 
			MAX(T5.Ma_Kho) AS Ma_Kho, 
			COUNT(T1.Barcode) AS So_Luong_Bo, 
			CAST(1 AS BIT) AS Is_Barcode, 
			CAST(1 AS BIT) AS Chon	
		FROM #T_DmBarcode T1 LEFT JOIN R81DMVT T3 WITH (NOLOCK) ON T1.Ma_Vt = T3.Ma_Vt, 
						(SELECT * FROM R00DmCt WHERE Ma_Ct = @Ma_Ct) T4,
						(SELECT * FROM R81DmNvu WHERE Ma_Nvu = @Ma_Nvu) T5
		GROUP BY T1.Ma_Vt, T1.Product_ID, T1.Is_Thu_Pham 
		ORDER BY Ma_Vt, Product_ID

RETURN
