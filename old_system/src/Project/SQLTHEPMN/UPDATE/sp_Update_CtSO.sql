set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/*
DROP PROCEDURE Sp_Update_CtSO

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R80PH', 'TVP_PHSO', 1
EXEC sp_CreateTVPStructure 'R04CtSO', 'TVP_CtSO', 1

--Test thủ tục cập nhật
DECLARE @PH AS TVP_PH, @Ct TVP_CtSO
INSERT INTO @PH SELECT * FROM R80PH WHERE Stt = 'A01010000010064-'
INSERT INTO @Ct SELECT * FROM R04CtSO WHERE Stt = 'A01010000010064-'
EXEC Sp_Update_CtSO 'E', @PH, @Ct, 'A01010000010064-', 'A01'
*/
IF OBJECT_ID('Sp_Update_CtSO') IS NOT NULL DROP PROCEDURE Sp_Update_CtSO
GO 

create PROCEDURE [dbo].[Sp_Update_CtSO]
(
	@strNew_Edit CHAR(1),
	@PH TVP_PHSO READONLY,
	@Ct TVP_CtSO READONLY,
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@Ma_DvCs VARCHAR(5)
)
WITH ENCRYPTION
AS
BEGIN
	DECLARE @_So_Ct VARCHAR(20), @_So_Ct_Org VARCHAR(20) , @_Stt_Org VARCHAR(20), @_Ngay_Ct DATETIME, @_Stt0_Error INT
	SET @_So_Ct = (SELECT MAX(So_Ct) FROM @PH) 
	SET @_Ngay_Ct = (SELECT MAX(Ngay_Ct) FROM @PH) 
	IF(@strNew_Edit IN ('N','C') AND EXISTS(SELECT So_Ct FROM R80PH WHERE So_Ct = @_So_Ct 
		AND Ma_Ct = @Ma_Ct AND Ngay_Ct =  @_Ngay_Ct))
	BEGIN
		RAISERROR (N'Số chứng từ đã tồn tại. Yêu cầu thoát ra và lập lại trước khi lưu [%s]', 16, 1, @_So_Ct)
		RETURN
	END

	--Kiểm Tra tồn tại Stt khi thêm mới
	IF (@strNew_Edit IN ('N','C') AND EXISTS(SELECT Stt FROM R80PH WHERE Stt = @Stt))
	BEGIN
		RAISERROR (N'Thêm mới trùng Stt [%s]', 16, 1, @Stt)
		RETURN
	END

	--Kiểm Tra So_Luong9 * He_So9 <> So_Luong
	IF NOT EXISTS(SELECT COUNT(*) FROM @Ct)
	BEGIN
				
		RAISERROR (N'Không lưu chứng từ chưa có chi tiết. Vui lòng kiểm tra lại',16,1)
		RETURN
	END
	IF(@Ma_Ct = 'SO' AND EXISTS(SELECT * FROM @Ct WHERE LEN(So_Ct)> 13 ))
	BEGIN
				
		RAISERROR (N'Số chứng từ đang sai quy tắc không cập nhật được',16,1)
		RETURN
	END

	--SET @_Stt_Org = (SELECT MAX(Stt_Org) FROM @Ct) 
	--SET @_So_Ct_Org = (SELECT MAX(So_Ct) FROM R80PH WHERE Stt = @_Stt_Org) 
	--IF(@Ma_Ct = 'LXH' AND @_So_Ct_Org <> LEFT(@_So_Ct,13))
	--BEGIN
	--	RAISERROR (N'Số chứng từ không trùng với số lệnh. Kiểm tra lại trước khi lưu [%s]', 16, 1, @Stt)
	--	RETURN
	--END
	
	IF(@Ma_Ct IN ('SO','SOCP') AND CONVERT(VARCHAR(8),@_Ngay_Ct,112) <> RIGHT(@_So_Ct,8) AND @strNew_Edit = 'N')
	BEGIN
		RAISERROR (N'Số chứng từ sai quy tắc. Kiểm tra lại trước khi lưu [%s]', 16, 1, @Stt)
		RETURN
	END



	-- Kiểm tra LXH
	IF(@Ma_Ct = 'LXH' AND EXISTS(SELECT Stt_Org FROM @Ct WHERE Stt_Org = ''))
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE Stt_Org = '' )
		RAISERROR (N'Tồn tại dòng [%d] phiếu phải được kế thừa từ SO, không được nhập tay.', 16, 1, @_Stt0_Error)
		RETURN
	END

	DECLARE @_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',
			@_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(MAX),
			@_InsertPHScript VARCHAR(MAX) = '', @_InsertCtScript VARCHAR(MAX) = '',
			@_UpdatePHScript VARCHAR(MAX) = '', @_UpdateCtScript VARCHAR(MAX) = '',
			@_ColumnName VARCHAR(50) = ''

	SELECT	@_TablePHName = Table_PH,
			@_TableCtName = Table_Ct
		FROM R00DmCt
		WHERE Ma_Ct = @Ma_Ct

	SELECT	@_TVPPHName = 'TVP_PHSO',
			@_TVPCtName = 'TVP_CtSO'

	SELECT * INTO #T_TablePH FROM @PH
	SELECT * INTO #T_TableCt FROM @Ct

	UPDATE #T_TablePH SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	UPDATE #T_TableCt SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	--- Update số lượng bó, cây
	UPDATE #T_TableCt SET So_Bo = So_Luong_Bo , So_Cay = So_Luong_Cay_Le ,  TSo_Luong_Cay = So_Luong_Cay 
	---
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
	
	
	IF (@strNew_Edit IN ('N','C') AND EXISTS(SELECT So_Ct FROM R80PH WHERE So_Ct = @_So_Ct AND Ma_Ct LIKE 'SO%' AND Ngay_Ct = @_Ngay_Ct))
	BEGIN
		EXEC sp_Update_Rule_So_Ct0 @Stt, @Ma_Ct, @strNew_Edit		
	END

	SELECT @Stt

END
GO
