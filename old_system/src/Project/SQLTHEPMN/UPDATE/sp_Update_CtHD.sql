set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/*
DROP PROCEDURE Sp_Update_CtHD

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R80PH', 'TVP_PHHD', 1
EXEC sp_CreateTVPStructure 'R04CtHD', 'TVP_CtHD', 1

EXEC sp_CreateTVPStructure 'R80HanTt0', 'TVP_HanTt0', 1

--Test thủ tục cập nhật
DECLARE @PH AS TVP_PH, @Ct TVP_CtHD
INSERT INTO @PH SELECT * FROM R80PH WHERE Stt = 'A01010000010064-'
INSERT INTO @Ct SELECT * FROM R04CtHD WHERE Stt = 'A01010000010064-'
EXEC Sp_Update_CtHD 'E', @PH, @Ct, 'A01010000010064-', 'A01'
*/
IF OBJECT_ID('Sp_Update_CtHD') IS NOT NULL DROP PROCEDURE Sp_Update_CtHD
GO 

CREATE PROCEDURE [dbo].[Sp_Update_CtHD]
(
	@strNew_Edit CHAR(1),
	@PH TVP_PHHD READONLY,
	@Ct TVP_CtHD READONLY,
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

	--Kiểm Tra So_Luong9 * He_So9 <> So_Luong
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((So_Luong9 * He_So9) - So_Luong) > 1 AND So_Luong9 <> 0)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((So_Luong9 * He_So9) - So_Luong) > 1 AND So_Luong9 <> 0)
		
		RAISERROR (N'Tồn tại dòng [%d] (So_Luong9 * He_So) <> So_Luong', 16, 1, @_Stt0_Error)
		RETURN
	END

	--Kiểm Tra So_Luong * Gia9 <> Tien9
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((So_Luong9 * Gia_Nt9) - Tien_Nt9) > 1000 AND So_Luong9 <> 0)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((So_Luong9 * Gia_Nt9) - Tien_Nt9) > 1000 AND So_Luong9 <> 0)
		
		RAISERROR (N'Tồn tại dòng [%d] (So_Luong9 * Gia_Nt9) <> Tien_Nt9', 16, 1, @_Stt0_Error)
		RETURN
	END
	--Kiểm Tra So_Luong * Gia9 <> Tien9
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS(ROUND(So_Luong * Gia_Nt2,2) - ROUND(Tien_Nt2,2)) > 0.1 AND Tien_Nt2 <> 0 AND Ty_Gia <> 1)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS(ROUND(So_Luong * Gia_Nt2,2) - ROUND(Tien_Nt2,2)) > 0.01 AND Tien_Nt2 <> 0 AND Ty_Gia <> 1)

		RAISERROR (N'Tồn tại dòng [%d] (So_Luong * Gia_Nt2) <> Tien_Nt2)', 16, 1, @_Stt0_Error)
		RETURN
	END
	--Kiểm Tra Tien_Nt2 * Ty_Gia <> Tien2
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((Tien_Nt2 * Ty_Gia) - Tien2) > 1000 AND Tien_Nt2 <> 0 AND Ty_Gia <> 1)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((Tien_Nt2 * Ty_Gia) - Tien2) > 1000 AND Tien_Nt2 <> 0 AND Ty_Gia <> 1)

		RAISERROR (N'Tồn tại dòng [%d] (Tien_Nt * Ty_Gia) <> Tien)', 16, 1, @_Stt0_Error)
		RETURN
	END


	----Kiểm Tra số HD không trùng trong cùng seri
	--DECLARE @_So_Ct0 VARCHAR(20), @_So_Seri0 VARCHAR(20), @_Ngay_Ct0 DATETIME, @_So_Ct0_Max INT, @_So_Ct_Update VARCHAR(20), @_So_Ct0_Update VARCHAR(20) 
	--SET @_So_Ct0_Update = (SELECT MAX(So_Ct0) FROM @Ct)
	--SET @_So_Ct_Update = (SELECT MAX(So_Ct) FROM @Ct)
	
	--IF(@Ma_Ct ='HD')
	--BEGIN
	--	SET @_So_Ct0 = (SELECT MAX(So_Ct0) FROM @Ct)
	--	SET @_So_Seri0 = (SELECT MAX(So_Seri0) FROM @Ct)
	--	SET @_Ngay_Ct0 = (SELECT MAX(Ngay_Ct0) FROM @Ct)
	--	SET @_So_Ct0_Max = CAST(@_So_Ct0 AS INT) + 1
	--	SET @_So_Ct0_Update = @_So_Ct0
	--	IF EXISTS(SELECT Stt0 FROM R04CTHD WHERE So_Ct0 = @_So_Ct0 AND Ngay_Ct0 = @_Ngay_Ct0 AND So_Seri0 = @_So_Seri0 AND @strNew_Edit = 'N')
	--	BEGIN
		
	--		SET @_So_Ct0_Update =  REPLACE(STR(@_So_Ct0_Max,7),' ','0')
	--		SET @_So_Ct_Update =  REPLACE(STR(@_So_Ct0_Max,7),' ','0')
	--	END
	--END

	DECLARE @_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',
			@_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(2000),
			@_InsertPHScript VARCHAR(MAX) = '', @_InsertCtScript VARCHAR(MAX) = '',
			@_UpdatePHScript VARCHAR(MAX) = '', @_UpdateCtScript VARCHAR(MAX) = '',
			@_ColumnName VARCHAR(50) = ''

	SELECT	@_TablePHName = Table_PH,
			@_TableCtName = Table_Ct
		FROM R00DmCt
		WHERE Ma_Ct = @Ma_Ct

	SELECT	@_TVPPHName = 'TVP_PHHD',
			@_TVPCtName = 'TVP_CtHD'

	SELECT * INTO #T_TablePH FROM @PH
	SELECT * INTO #T_TableCt FROM @Ct

	-- Xử lý Is_Lock Có 131
	IF EXISTS(SELECT Stt0 FROM #T_TableCt WHERE Tk_Co2 LIKE '131%' OR Tk_Co3 LIKE '131%')
		UPDATE #T_TableCt SET Is_Lock = 1
	ELSE
		UPDATE #T_TableCt SET Is_Lock = 0

	UPDATE #T_TablePH SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	UPDATE #T_TableCt SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	----Bang them
	--UPDATE #T_TableCt SET So_Ct0 = @_So_Ct0_Update, So_Ct = @_So_Ct_Update
	--UPDATE #T_TablePH SET So_Ct = @_So_Ct_Update
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

			----CT
			SELECT @_SQLExec = 
				'INSERT INTO ' + @_TableCtName + ' (' + @_InsertCtScript + ')
					SELECT ' + @_InsertCtScript + '
						FROM #T_TableCT
						WHERE Stt = @Stt'

			SELECT @_Params = N'@Stt VARCHAR(15)'

			EXEC sp_executesql @_SQLExec, @_Params, @Stt

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
	
	--Bang kiểm tra sau khi lưu
	EXEC sp_UpdateDaXuatHD @Stt, @Ma_Ct, 0

	DECLARE @_So_Ct VARCHAR(20), @_Ngay_Ct DATETIME
	SET @_So_Ct = (SELECT So_Ct FROM #T_TablePH)
	SET @_Ngay_Ct = (SELECT Ngay_Ct FROM #T_TablePH)
	IF (@strNew_Edit IN ('N','C') AND EXISTS(SELECT So_Ct FROM R80PH WHERE So_Ct = @_So_Ct AND Ma_Ct = 'HD' AND Ngay_Ct = @_Ngay_Ct))
	BEGIN
		EXEC sp_Update_Rule_So_Ct0 @Stt, @Ma_Ct, @strNew_Edit		
	END

	
	
	SELECT @Stt

END


