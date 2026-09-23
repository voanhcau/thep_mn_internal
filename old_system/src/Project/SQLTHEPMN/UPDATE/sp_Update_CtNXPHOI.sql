set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/*
DROP PROCEDURE Sp_Update_CtNXPHOI

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R80PH', 'TVP_PHNXPHOI', 1
EXEC sp_CreateTVPStructure 'R05CtNXPHOI', 'TVP_CtNXPHOI', 1

EXEC sp_CreateTVPStructure 'R05CtNXLR', 'TVP_CtNXLR', 1
EXEC sp_CreateTVPStructure 'R80HanTt0', 'TVP_HanTt0', 1

--Test thủ tục cập nhật
DECLARE @PH AS TVP_PH, @Ct TVP_CtNX
INSERT INTO @PH SELECT * FROM R80PH WHERE Stt = 'A01010000010064-'
INSERT INTO @Ct SELECT * FROM R05CtNX WHERE Stt = 'A01010000010064-'
EXEC Sp_Update_CtNX 'E', @PH, @Ct, 'A01010000010064-', 'A01'
*/
IF OBJECT_ID('Sp_Update_CtNXPHOI') IS NOT NULL DROP PROCEDURE Sp_Update_CtNXPHOI
GO 

CREATE PROCEDURE [dbo].[Sp_Update_CtNXPHOI]
(
	@strNew_Edit CHAR(1),
	@PH TVP_PHNXPHOI READONLY,
	@Ct TVP_CtNXPHOI READONLY,
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@Ma_DvCs VARCHAR(5)
)
WITH ENCRYPTION
AS
BEGIN

	--Kiểm Tra tồn tại Stt khi thêm mới
	IF (@strNew_Edit IN ('N','C') AND EXISTS(SELECT Stt FROM R80PH WHERE Stt = @Stt))
	BEGIN
		RAISERROR (N'Thêm mới trùng Stt [%s]', 16, 1, @Stt)
		RETURN
	END

	DECLARE @_Stt0_Error INT

	----Kiểm Tra So_Luong9 * He_So9 <> So_Luong
	--IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((So_Luong9 * He_So9) - So_Luong) > 1 AND So_Luong9 <> 0)
	--BEGIN
	--	SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((So_Luong9 * He_So9) - So_Luong) > 1 AND So_Luong9 <> 0)
		
	--	RAISERROR (N'Tồn tại dòng [%d] (So_Luong9 * He_So) <> So_Luong', 16, 1, @_Stt0_Error)
	--	RETURN
	--END

	----Kiểm Tra So_Luong * Gia9 <> Tien9
	--IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((So_Luong9 * Gia_Nt9) - Tien_Nt9) > 1000 AND So_Luong9 <> 0)
	--BEGIN
	--	SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((So_Luong9 * Gia_Nt9) - Tien_Nt9) > 1000 AND So_Luong9 <> 0)
		
	--	RAISERROR (N'Tồn tại dòng [%d] (So_Luong9 * Gia_Nt9) <> Tien_Nt9', 16, 1, @_Stt0_Error)
	--	RETURN
	--END

	----Kiểm Tra Tien_Nt * Ty_Gia <> Tien
	--IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((Tien_Nt * Ty_Gia) - Tien) > 1000 AND Tien_Nt <> 0 AND Ty_Gia <> 1)
	--BEGIN
	--	SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((Tien_Nt * Ty_Gia) - Tien) > 1000 AND Tien_Nt <> 0 AND Ty_Gia <> 1)

	--	RAISERROR (N'Tồn tại dòng [%d] (Tien_Nt * Ty_Gia) <> Tien)', 16, 1, @_Stt0_Error)
	--	RETURN
	--END
	--Kiểm Tra nhập mã ca
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE Ca_SX = '' AND Ma_Ct in ('PNSB','PXSB'))
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE Ca_SX = '')

		RAISERROR (N'Tồn tại dòng [%d] không nhập ca sản xuất, vui lòng nhập trước khi lưu)', 16, 1, @_Stt0_Error)
		RETURN
	END
	DECLARE @_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',  @_TVPPHName_Kt VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',@_TVPCtName_Kt VARCHAR(50) = '',
			@_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(2000),
			@_InsertPHScript VARCHAR(MAX) = '', @_InsertCtScript VARCHAR(MAX) = '',
			@_UpdatePHScript VARCHAR(MAX) = '', @_UpdateCtScript VARCHAR(MAX) = '',
			@_ColumnName VARCHAR(50) = ''

	SELECT	@_TablePHName = Table_PH,
			@_TableCtName = Table_Ct
		FROM R00DmCt
		WHERE Ma_Ct = @Ma_Ct

	SELECT	@_TVPPHName = 'TVP_PHNXPHOI',
			@_TVPCtName = 'TVP_CtNXPHOI'

	SELECT * INTO #T_TablePH FROM @PH
	SELECT * INTO #T_TableCt FROM @Ct

	UPDATE #T_TablePH SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	UPDATE #T_TableCt SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs

	BEGIN TRY
		BEGIN TRANSACTION

		--PH
		SELECT @_ColumnName = MIN(Name) 
			FROM sys.columns T1
			WHERE (T1.OBJECT_ID IN (SELECT Type_Table_object_id FROM sys.table_types where name = @_TVPPHName)) 
				AND EXISTS(SELECT * FROM sys.columns T2 WHERE T2.Object_ID = Object_ID(@_TablePHName) AND T2.Is_Identity = 0 AND T2.Name = T1.Name)

		WHILE @_ColumnName IS NOT NULL
		BEGIN
			SELECT @_InsertPHScript = CASE  
										WHEN @_InsertPHScript = '' THEN '' 
										ELSE @_InsertPHScript + ','
									END + @_ColumnName
										
			SELECT @_UpdatePHScript = CASE  
										WHEN @_UpdatePHScript = '' THEN '' 
										ELSE @_UpdatePHScript + ','
									END + @_ColumnName + '=T2.' + @_ColumnName
			
			SELECT @_ColumnName = MIN(Name) 
				FROM sys.columns T1
				WHERE (T1.OBJECT_ID IN (SELECT Type_Table_object_id FROM sys.table_types where name = @_TVPPHName)) 
					AND EXISTS(SELECT * FROM sys.columns T2 WHERE T2.Object_ID = Object_ID(@_TablePHName) AND T2.Is_Identity = 0 AND T2.Name = T1.Name) AND T1.name > @_ColumnName
		END

		PRINT @_InsertPHScript
		PRINT @_UpdatePHScript

		--Ct
		SELECT @_ColumnName = MIN(Name) 
			FROM sys.columns T1
			WHERE (T1.OBJECT_ID IN (SELECT Type_Table_object_id FROM sys.table_types where name = @_TVPCtName)) 
				AND EXISTS(SELECT * FROM sys.columns T2 WHERE T2.Object_ID = Object_ID(@_TableCtName) AND T2.Is_Identity = 0 AND T2.Name = T1.Name)
 
		WHILE @_ColumnName IS NOT NULL
		BEGIN
			SELECT @_InsertCtScript = CASE  
										WHEN @_InsertCtScript = '' THEN '' 
										ELSE @_InsertCtScript + ','
									END + @_ColumnName

			SELECT @_UpdateCtScript = CASE  
										WHEN @_UpdateCtScript = '' THEN '' 
										ELSE @_UpdateCtScript + ','
									END + @_ColumnName + '=T2.' + @_ColumnName
			
			SELECT @_ColumnName = MIN(Name) 
				FROM sys.columns T1
				WHERE (T1.OBJECT_ID IN (SELECT Type_Table_object_id FROM sys.table_types where name = @_TVPCtName)) 
					AND EXISTS(SELECT * FROM sys.columns T2 WHERE T2.Object_ID = Object_ID(@_TableCtName) AND T2.Is_Identity = 0 AND T2.Name = T1.Name) AND name > @_ColumnName
		END

		PRINT @_InsertCtScript
		PRINT @_UpdateCtScript

		--Chuyển dữ liệu sang kế toán

		--DECLARE @_Stt_Ct VARCHAR(15), @_Ngay_Ct DATETIME, @_Ma_Ct VARCHAR(5), @_Stt0 AS INT = 0, @_Ma_Nvu VARCHAR(5), @_Ma_Bp VARCHAR(20), @_Auto_Cost BIT
		--SET @_Ma_Ct = CASE WHEN @Ma_Ct = 'PNSB' THEN 'NTHAO' ELSE 'XTHAO' END
		--SET @_Ngay_Ct = (SELECT Ngay_Ct FROM #T_TablePH)
		--SET @_Ma_Nvu = CASE WHEN @Ma_Ct = 'PNSB' THEN 'NTHAO' ELSE 'PX05' END
		--SET @_Ma_Bp = CASE WHEN @Ma_Ct = 'PXSB' THEN 'PXCAN' ELSE '' END
		--SET @_Auto_Cost = CASE WHEN @Ma_Ct = 'PXSB' THEN 1 ELSE 0 END
		--SET @_Stt_Ct = LEFT(@Stt,6) + CASE WHEN @Ma_Ct = 'PNSB' THEN 'N' ELSE 'X' END + CONVERT(VARCHAR(8), @_Ngay_Ct, 112)
		
		--SELECT @_Stt_Ct AS Stt, @_Ma_Ct AS Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_Giai, TSo_Luong
		--	INTO #T_TablePH_KT
		--	FROM #T_TablePH
					
		--SELECT @_Stt_Ct AS Stt, CAST(0 AS INT) AS Stt0, '' AS Create_Log, '' AS LastModify_Log, @Stt AS Stt_Org, CAST('' AS VARCHAR(20)) AS Ma_Km,  Ma_Vt, Dvt, Phan_Loai_Phoi, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, SUM(So_Luong_Cay) AS So_Luong_Cay, SUM(So_Luong9) AS So_Luong9, SUM(So_Luong) AS So_Luong
		--	INTO #T_Ct
		--	FROM #T_TableCT
		--	WHERE Phan_Loai_Phoi <> 'CXL'
		--	GROUP BY Ma_Vt, Phan_Loai_Phoi, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, Dvt, Create_Log, LastModify_Log
		
		--IF(EXISTS(SELECT * FROM R05CTNX WHERE Stt = @_Stt_Ct)) --Đánh lại Stt0
		--BEGIN
		--	SET @_Stt0 = (SELECT MAX(Stt0) FROM R05CTNX WHERE Stt = @_Stt_Ct)
		--END
		
		--UPDATE #T_Ct SET Stt0 = @_Stt0 + 1, @_Stt0 = @_Stt0 + 1
		
		--UPDATE #T_Ct SET Phan_Loai_Phoi = 'PH' WHERE @Ma_Ct  = 'PXSB'
		
		--SELECT @_Stt_Ct AS Stt, Stt0, @_Ma_Ct AS Ma_Ct, Stt_Org, @_Ma_Nvu AS Ma_Nvu, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, Ma_Vt, Dvt, So_Luong_Cay, So_Luong9, So_Luong,
		--		CASE WHEN Phan_Loai_Phoi = 'PH' THEN '02BTP' ELSE '01PP' END AS Ma_Kho,
		--		CASE WHEN Phan_Loai_Phoi = 'PH' AND @Ma_Ct  = 'PNSB' THEN '15511' 
		--			 WHEN Phan_Loai_Phoi = 'PH' AND @Ma_Ct  = 'PXSB' THEN '6212' 
		--			ELSE '152' END AS Tk_No,
		--		CASE WHEN Phan_Loai_Phoi = 'PH' AND @Ma_Ct  = 'PNSB' THEN '1542' 
		--			WHEN  Phan_Loai_Phoi = 'PH' AND @Ma_Ct  = 'PXSB' THEN '15511' 
		--			ELSE '6212' END AS Tk_Co,
		--		CASE WHEN @Ma_Ct = 'PXSB' THEN 'A02' ELSE '' END AS Ma_Km,
		--		Create_Log, LastModify_Log
		--	INTO #T_TableCT_KT
		--	FROM #T_Ct
		
		--UPDATE #T_TablePH_KT SET TSo_Luong = (SELECT SUM(So_Luong) FROM #T_TableCT_KT)
	
		---
		IF (@strNew_Edit IN ('N','C')) --Thêm, Copy
		BEGIN
			PRINT @Stt

			--PH
			SELECT @_SQLExec = 
				'INSERT INTO ' + @_TablePHName + ' (' + @_InsertPHScript + ')
					SELECT ' + @_InsertPHScript + '
						FROM #T_TablePH 
						WHERE Stt = @Stt'

			SELECT @_Params = N'@Stt VARCHAR(15)'

			EXEC sp_executesql @_SQLExec, @_Params, @Stt
			
			--- kế toán
			--IF(NOT EXISTS(SELECT * FROM R80PH WHERE Stt = @_Stt_Ct))
			--	INSERT INTO R80PH(Stt, Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_Giai, TSo_Luong, Ma_DvCs)
			--	 SELECT Stt, Ma_Ct, Ngay_Ct, So_Ct, Ma_Dt, Dien_Giai, TSo_Luong, @Ma_DvCs
			--	 FROM #T_TablePH_KT

			----CT
			SELECT @_SQLExec = 
				'INSERT INTO ' + @_TableCtName + ' (' + @_InsertCtScript + ')
					SELECT ' + @_InsertCtScript + '
						FROM #T_TableCT
						WHERE Stt = @Stt'

			SELECT @_Params = N'@Stt VARCHAR(15)'

			EXEC sp_executesql @_SQLExec, @_Params, @Stt
			
			--- kế toán
			--INSERT INTO R05CTNX( Stt, Stt0, Stt_Org, Ma_Ct,  Ma_Nvu, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, Ma_Vt, Dvt, Ma_Km, So_Luong_Cay, So_Luong9, So_Luong, Ma_Kho, Tk_No, Tk_Co, Ma_DvCs, Create_Log, LastModify_Log)
			-- SELECT  Stt, Stt0, Stt_Org, Ma_Ct, Ma_Nvu, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, Ma_Vt, Dvt, Ma_Km, So_Luong_Cay, So_Luong9, So_Luong, Ma_Kho, Tk_No, Tk_Co, @Ma_DvCs, Create_Log, LastModify_Log
			-- FROM #T_TableCT_KT
			 	
		END
		ELSE IF (@strNew_Edit IN ('E')) --Sửa
		BEGIN
			--PH
			SELECT @_SQLExec = 
				'UPDATE T1 SET ' + @_UpdatePHScript + '
					FROM ' + @_TablePHName + ' T1 JOIN #T_TablePH T2 ON T1.Stt = T2.Stt
					WHERE T1.Stt = @Stt'
		
			SELECT @_Params = N'@Stt VARCHAR(15)'

			EXEC sp_executesql @_SQLExec, @_Params, @Stt
			-- Chuyển sang kế toán
			--IF(EXISTS(SELECT * FROM R80PH WHERE Stt = @_Stt_Ct))
			--	UPDATE R80PH SET Ngay_Ct = T2.Ngay_Ct, Dien_Giai = T2.Dien_Giai, TSo_Luong = T2.TSo_Luong
			--		FROM R80PH T1 JOIN #T_TablePH_KT T2 ON T1.Stt = T2.Stt
			--		WHERE T1.Stt = @_Stt_Ct
			--Ct
			SELECT @_SQLExec = '
				--Delete những dòng không tồn tại trong bảng mới (Những dòng đã xóa)
				DELETE T1
					FROM ' + @_TableCtName + ' T1
					WHERE NOT EXISTS (SELECT Stt, Stt0 FROM #T_TableCT T2 WHERE T2.Stt = T1.Stt AND T2.Stt0 = T1.Stt0)
						AND T1.Stt = @Stt
		
				--Update những dòng đã tồn tại
				UPDATE T1 SET ' + @_UpdateCtScript + '
					FROM ' + @_TableCtName + ' T1 JOIN #T_TableCT T2 ON T1.Stt = T2.Stt AND T1.Stt0 = T2.Stt0
					WHERE T1.Stt = @Stt

				--Insert những dòng mới thêm vào
				INSERT INTO ' + @_TableCtName + ' (' + @_InsertCtScript + ')
					SELECT 	' + @_InsertCtScript + '
						FROM #T_TableCT T2
						WHERE Stt = @Stt AND NOT EXISTS (SELECT Stt, Stt0 FROM ' + @_TableCtName + ' T1 WHERE T2.Stt = T1.Stt AND T2.Stt0 = T1.Stt0)'

			SELECT @_Params = N'@Stt VARCHAR(15)'

			EXEC sp_executesql @_SQLExec, @_Params, @Stt
			
			-- sửa dữ liệu kế toán
			--IF(EXISTS(SELECT * FROM R05CTNX WHERE Stt = @_Stt_Ct))
			--BEGIN
				
			--	--Delete những dòng không tồn tại trong bảng mới (Những dòng đã xóa)
			--	DELETE T1
			--		FROM R05CTNX T1
			--		WHERE NOT EXISTS (SELECT Stt, Stt_Org, Ma_Vt FROM #T_TableCT_KT T2 WHERE T2.Stt = T1.Stt AND T2.Ma_Vt = T1.Ma_Vt AND T2.Stt_Org = T1.Stt_Org)
			--			AND T1.Stt = @_Stt_Ct AND T1.Stt_Org = @Stt
		
			--	--Update những dòng đã tồn tại
			--	UPDATE T1 SET So_Luong_Cay = T2.So_Luong_Cay, So_Luong = T2.So_Luong, So_Luong9 = T2.So_Luong9
			--		FROM R05CTNX T1 JOIN #T_TableCT_KT T2 ON T1.Stt = T2.Stt AND T1.Ma_Vt = T2.Ma_Vt AND T2.Stt_Org = T1.Stt_Org
			--		WHERE T1.Stt = @_Stt_Ct AND T1.Stt_Org = @Stt

			--	--Insert những dòng mới thêm vào
			--	INSERT INTO R05CTNX( Stt, Stt0, Stt_Org, Ma_Ct,  Ma_Nvu, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, Ma_Vt, Dvt, So_Luong_Cay, So_Luong9, So_Luong, Ma_Kho, Tk_No, Tk_Co, Ma_DvCs)
			--		SELECT  Stt, Stt0, Stt_Org, Ma_Ct, Ma_Nvu, Ngay_Ct, So_Ct, Ma_Dt, Ma_Tte, Ty_Gia, Dien_Giai, Ma_Vt, Dvt, So_Luong_Cay, So_Luong9, So_Luong, Ma_Kho, Tk_No, Tk_Co, @Ma_DvCs
			--			 FROM #T_TableCT_KT T2
			--			 WHERE Stt = @_Stt_Ct AND Stt_Org = @Stt AND NOT EXISTS (SELECT Stt, Ma_Vt, Stt_Org FROM R05CTNX T1 WHERE T2.Stt = T1.Stt AND T2.Ma_Vt = T1.Ma_Vt AND T2.Stt_Org = T1.Stt_Org)
				
				

			--END
		END

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE() + CHAR(13) + @_SQLExec,
				@ErrorSeverity INT = ERROR_SEVERITY(),
				@ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH
	
	SELECT @Stt

	

END
