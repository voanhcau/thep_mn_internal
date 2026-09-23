/*
DROP PROCEDURE sp_Update_CtN_Barcode

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R80PH_SCALE', 'TVP_PH_SCALE_N', 1
EXEC sp_CreateTVPStructure 'R05CtN_Barcode', 'TVP_CTN_BARCODE', 1


--Test thủ tục cập nhật
DECLARE @PH AS TVP_PH, @Ct TVP_CtNX
INSERT INTO @PH SELECT * FROM R80PH WHERE Stt = 'A01010000010064-'
INSERT INTO @Ct SELECT * FROM R05CtNX WHERE Stt = 'A01010000010064-'
EXEC Sp_Update_CtNX 'E', @PH, @Ct, 'A01010000010064-', 'A01'
*/
IF OBJECT_ID('sp_Update_CtN_Barcode') IS NOT NULL DROP PROCEDURE sp_Update_CtN_Barcode
GO 

CREATE PROCEDURE [dbo].[sp_Update_CtN_Barcode]
(
	@strNew_Edit CHAR(1),
	@PH TVP_PH_SCALE_N READONLY,
	@Ct TVP_CTN_BARCODE READONLY,
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@Ma_DvCs VARCHAR(5)
)
--WITH ENCRYPTION
AS
BEGIN
	
	DECLARE @_iStt INT = 0,
			@_iSo_Ct INT = 0,
			@_Stt VARCHAR(15) = '',
			@_So_Ct VARCHAR(20) = ''

	--Kiểm Tra tồn tại Stt khi thêm mới
	IF (@strNew_Edit IN ('N','C') AND NOT EXISTS(SELECT Stt FROM R80PH_SCALE WHERE Stt = @Stt))
	BEGIN
		--Stt
		SET @_iStt = (SELECT ISNULL(MAX(SUBSTRING(Stt, 6, 10)), 0)
							FROM R80PH_SCALE WITH(NOLOCK)
							WHERE Stt LIKE '___80%' AND ISNUMERIC(SUBSTRING(Stt, 6, 10)) = 1) + 1

		SET @Stt = (SELECT dbo.fn_PADL(@Ma_DvCs, 3, '0')) + '80' + (SELECT dbo.fn_PADL(@_iStt, 10, '0'))
	
		--So_Ct
		SET @_iSo_Ct = (SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(So_Ct)) AS BIGINT)), 0) FROM R80PH_SCALE WHERE YEAR(Ngay_Ct) = YEAR(GETDATE())) + 1
		SET @_So_Ct = (SELECT dbo.fn_PADL(@_iSo_Ct, 6, '0'))
	END

	DECLARE @_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',
			@_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(2000),
			@_InsertPHScript VARCHAR(2000) = '', @_UpdatePHScript VARCHAR(2000) = '',
			@_InsertCtScript VARCHAR(2000) = '', @_UpdateCtScript VARCHAR(2000) = '',
			@_ColumnName VARCHAR(50) = ''

	SELECT	@_TablePHName = Table_PH,
			@_TableCtName = Table_Ct
		FROM R00DmCt
		WHERE Ma_Ct = @Ma_Ct

	SELECT	@_TVPPHName = 'TVP_PH_SCALE_N',
			@_TVPCtName = 'TVP_CTN_BARCODE'

	SELECT * INTO #T_TablePH FROM @PH
	SELECT * INTO #T_TableCt FROM @Ct
	
	UPDATE #T_TablePH SET Stt = @Stt, So_Ct = @_So_Ct, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	UPDATE #T_TableCt SET Stt = @Stt, So_Ct = @_So_Ct, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs

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
	
	SELECT @Stt

END