set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/*
DROP PROCEDURE Sp_Update_CtNXLR

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R05CtNXLR', 'TVP_CtNXLR', 1

--Test thủ tục cập nhật
DECLARE @Ct TVP_CtTien
INSERT INTO @Ct SELECT * FROM R01CtTien WHERE Stt = 'A01010000010064-'
EXEC Sp_Update_CtNXLR 'E', @PH, @Ct, 'A01010000010064-', 'A01'
*/
IF OBJECT_ID('Sp_Update_CtNXLR') IS NOT NULL DROP PROCEDURE Sp_Update_CtNXLR
GO 

CREATE PROCEDURE [dbo].[Sp_Update_CtNXLR]
(
	@strNew_Edit CHAR(1),
	@CtNXLR TVP_CtNXLR READONLY,
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@Ma_DvCs VARCHAR(5)
)
WITH ENCRYPTION
AS
BEGIN

	DECLARE @_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',
			@_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(2000),
			@_InsertPHScript VARCHAR(2000) = '', @_InsertCtScript VARCHAR(2000) = '',
			@_UpdatePHScript VARCHAR(2000) = '', @_UpdateCtScript VARCHAR(2000) = '',
			@_ColumnName VARCHAR(50) = ''

	SELECT	@_TableCtName = 'R05CtNXLR',
			@_TVPCtName = 'TVP_CtNXLR'

	SELECT * INTO #T_TableCtNXLR FROM @CtNXLR
	UPDATE #T_TableCtNXLR SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs

	--Kiểm Tra tồn tại Stt
	IF (NOT EXISTS(SELECT Stt FROM @CtNXLR))
	BEGIN
		EXECUTE('DELETE FROM ' + @_TableCtName + ' WHERE Stt = ''' + @Stt + '''')
		RETURN
	END

	BEGIN TRY
		BEGIN TRANSACTION

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

			----CT
			SELECT @_SQLExec = 
				'INSERT INTO ' + @_TableCtName + ' (' + @_InsertCtScript + ')
					SELECT ' + @_InsertCtScript + '
						FROM #T_TableCtNXLR
						WHERE Stt = @Stt'

			SELECT @_Params = N'@Stt VARCHAR(15)'

			EXEC sp_executesql @_SQLExec, @_Params, @Stt
			
		END
		ELSE IF (@strNew_Edit IN ('E')) --Sửa
		BEGIN

			SELECT @_SQLExec = '
				--Delete những dòng không tồn tại trong bảng mới (Những dòng đã xóa)
				DELETE T1
					FROM ' + @_TableCtName + ' T1
					WHERE NOT EXISTS (SELECT Stt FROM #T_TableCtNXLR T2 WHERE T2.Stt = T1.Stt /*AND T2.Ma_Vt = T1.Ma_Vt AND T2.Ma_Kho = T1.Ma_Kho*/)
						AND T1.Stt = @Stt
		
				--Update những dòng đã tồn tại
				UPDATE T1 SET ' + @_UpdateCtScript + '
					FROM ' + @_TableCtName + ' T1 JOIN #T_TableCtNXLR T2 ON T1.Stt = T2.Stt /*AND T1.Ma_Vt = T2.Ma_Vt AND T1.Ma_Kho = T2.Ma_Kho*/
					WHERE T1.Stt = @Stt

				--Insert những dòng mới thêm vào
				INSERT INTO ' + @_TableCtName + ' (' + @_InsertCtScript + ')
					SELECT 	' + @_InsertCtScript + '
						FROM #T_TableCtNXLR T2
						WHERE Stt = @Stt AND NOT EXISTS (SELECT Stt FROM ' + @_TableCtName + ' T1 WHERE T2.Stt = T1.Stt /*AND T2.Ma_Vt = T1.Ma_Vt AND T2.Ma_Kho = T1.Ma_Kho*/)'

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
