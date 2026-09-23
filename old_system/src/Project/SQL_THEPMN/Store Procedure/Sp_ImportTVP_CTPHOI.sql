USE [R50THEPMN]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ImportTVP_CTPhoi]    Script Date: 02/28/2015 11:00:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
	DECLARE @TVP_Import AS TVP_PHOI
	INSERT INTO @TVP_Import
	SELECT Ngaysanxuat, Casanxuat, Kyhieume, Loaiphoi, Chieudaiphoi, Macthep, Socaynapnong, Socaynaptrunggian, Socayrabai, SocayPHdai, KhoiluongPHdai, SocayPHngan, KhoiluongPHngan, SocayCXL, KhoiluongCXL, SocayKPH, daiKPH, KhoiluongKPH
		 FROM BTP_Phoi WHERE 0=1
	EXEC Sp_ImportTVP_CTPHOI
	SELECT * FROM ImportCTPHOI
	DROP TABLE ImportCTPHOI
*/

-- DROP PROCEDURE Sp_ImportTVP_CTPHOI
ALTER PROCEDURE [dbo].[Sp_ImportTVP_CTPhoi]
(
 @TVP_Import TVP_PHOI READONLY
)	
--WITH ENCRYPTION
AS
BEGIN
		IF Object_ID('#T_ImportCTPHOI') IS NOT NULL DROP TABLE #T_ImportCTPHOI
		SELECT  *
		  INTO #T_ImportCTPHOI
		  FROM @TVP_Import
		  WHERE CHON = 1
		
		SELECT A.*
		FROM
		(
				SELECT     CAST('KTP_PHOI' AS VARCHAR(15)) AS Ma_Kho, ISNULL(T2.Ma_Vt,'') AS Ma_Vt, Ngaysanxuat AS Ngay_Ct, Casanxuat AS Ca_SX, Kyhieume AS So_Me, 
							Loaiphoi AS Loai_Phoi, Chieudaiphoi AS DDai_Phoi, Macthep AS Mac_Thep, 1 AS Phoi_Ngan,
							Socaynapnong AS SL_Phoi_Nong, Socaynaptrunggian AS SL_Phoi_TG, Socayrabai AS SL_Phoi_Nguoi, 
							SocayPHngan AS So_Luong_Cay, KhoiluongPHngan AS So_Luong, KhoiluongPHngan AS So_Luong9
				FROM         #T_ImportCTPHOI T1 LEFT JOIN R81DMVT T2 ON T1.Loaiphoi = T2.Loai_Phoi AND T1.Macthep = T2.Mac_Thep AND T2.Phoi_Ngan = 1
				UNION ALL
				SELECT     CAST('KTP_PHOI' AS VARCHAR(15)) AS Ma_Kho, ISNULL(T2.Ma_Vt,'') AS Ma_Vt, Ngaysanxuat AS Ngay_Ct, Casanxuat AS Ca_SX, Kyhieume AS So_Me, 
							Loaiphoi AS Loai_Phoi, Chieudaiphoi AS DDai_Phoi, Macthep AS Mac_Thep, 0 AS Phoi_Ngan,
							Socaynapnong AS SL_Phoi_Nong, Socaynaptrunggian AS SL_Phoi_TG, Socayrabai AS SL_Phoi_Nguoi, 
							SocayPHdai AS So_Luong_Cay, KhoiluongPHdai AS So_Luong, KhoiluongPHdai AS So_Luong9
				FROM         #T_ImportCTPHOI T1 LEFT JOIN R81DMVT T2 ON T1.Loaiphoi = T2.Loai_Phoi AND T1.Macthep = T2.Mac_Thep AND T2.Phoi_Ngan = 0
				UNION ALL
				SELECT     CAST('KCXL_PHOI' AS VARCHAR(15)) AS Ma_Kho, CAST('' AS VARCHAR(15)) AS Ma_Vt, Ngaysanxuat AS Ngay_Ct, Casanxuat, Kyhieume AS So_Me, 
							Loaiphoi AS Loai_Phoi, Chieudaiphoi AS DDai_Phoi, Macthep AS Mac_Thep, 0 AS Phoi_Ngan,
							Socaynapnong AS SL_Phoi_Nong, Socaynaptrunggian AS SL_Phoi_TG, Socayrabai AS SL_Phoi_Nguoi, 
							SocayCXL AS So_Luong_Cay, KhoiluongCXL AS So_Luong, KhoiluongCXL AS So_Luong9
				FROM         #T_ImportCTPHOI
				UNION ALL
				SELECT     CAST('KPP_PHOI' AS VARCHAR(15)) AS Ma_Kho, CAST('' AS VARCHAR(15)) AS Ma_Vt, Ngaysanxuat AS Ngay_Ct, Casanxuat, Kyhieume AS So_Me, 
							Loaiphoi AS Loai_Phoi, Chieudaiphoi AS DDai_Phoi, Macthep AS Mac_Thep, 0 AS Phoi_Ngan,
							Socaynapnong AS SL_Phoi_Nong, Socaynaptrunggian AS SL_Phoi_TG, Socayrabai AS SL_Phoi_Nguoi, 
							SocayKPH AS So_Luong_Cay, KhoiluongKPH AS So_Luong, KhoiluongKPH AS So_Luong9
				FROM         #T_ImportCTPHOI
		) A
		WHERE So_Luong + So_Luong_Cay <>0
END