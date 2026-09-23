
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO

/*
DROP PROCEDURE Sp_Update_CtNX

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R80PH', 'TVP_PHNX', 1
EXEC sp_CreateTVPStructure 'R05CtNX', 'TVP_CtNX', 1

EXEC sp_CreateTVPStructure 'R05CtNXLR', 'TVP_CtNXLR', 1
EXEC sp_CreateTVPStructure 'R80HanTt0', 'TVP_HanTt0', 1

--Test thủ tục cập nhật
DECLARE @PH AS TVP_PH, @Ct TVP_CtNX
INSERT INTO @PH SELECT * FROM R80PH WHERE Stt = 'A01010000010064-'
INSERT INTO @Ct SELECT * FROM R05CtNX WHERE Stt = 'A01010000010064-'
EXEC Sp_Update_CtNX 'E', @PH, @Ct, 'A01010000010064-', 'A01'
*/
IF OBJECT_ID('Sp_Update_CtNX') IS NOT NULL DROP PROCEDURE Sp_Update_CtNX
GO 
CREATE PROCEDURE [dbo].[Sp_Update_CtNX]
(
	@strNew_Edit CHAR(1),
	@PH TVP_PHNX READONLY,
	@Ct TVP_CtNX READONLY,
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@Ma_DvCs VARCHAR(5)
)
WITH ENCRYPTION
AS
BEGIN
	
	DECLARE @_So_Seri0 VARCHAR(50) = '', @_So_Ct VARCHAR(50) = (select max(So_Ct) from @PH)
	--Ki?m Tra t?n t?i Stt khi thêm m?i
	IF (@strNew_Edit IN ('N','C') AND EXISTS(SELECT Stt FROM R80PH WHERE Stt = @Stt))
	BEGIN
		RAISERROR (N'Thêm m?i trùng Stt [%s]', 16, 1, @Stt)
		RETURN
	END
	----Kiểm tra chứng từ được in rồi không cho phép sửa
	--IF (@strNew_Edit IN ('E') AND (SELECT Print_Count FROM R80PH WHERE Stt = @Stt) > 0 AND @Ma_Ct IN ('PXBR'))
	--BEGIN
	--	RAISERROR (N'Không được sửa chứng từ khi đã in Stt [%s]', 16, 1, @Stt)
	--	RETURN
	--END
	--Kiểm tra sửa chứng từ khi đã xuất hóa đơn
	IF (@strNew_Edit IN ('E') AND EXISTS(SELECT Stt_Org FROM R04CTHD WHERE Stt_Org = @Stt) AND @Ma_Ct = 'PXBR')
	BEGIN
		RAISERROR (N'Không được sửa chứng từ khi đã kế thừa ra hóa đơn Stt [%s]', 16, 1, @Stt)
		RETURN
	END
		--Kiểm tra sửa chứng từ PX ko được lưu khi không kế thừa
	--IF (EXISTS(SELECT Stt FROM @Ct WHERE Stt_Org = '' AND Ma_Vt NOT LIKE '%0000' 
	--	AND Ma_Kho NOT LIKE '058%' AND (Ma_Kho = '04TP' AND Ma_Nvu <> 'PX16')) AND @Ma_Ct IN ('PXBR','PXDC') )
	--BEGIN
	--	RAISERROR (N'Không được nhập PX khi không kế thừa Stt [%s]', 16, 1, @Stt)
	--	RETURN
	--END

	--Kiểm tra trùng số chứng từ
	--Kiểm tra chứng từ duyệt rồi không cho phép sửa
	
	DECLARE @_Stt0_Error INT

	--Ki?m Tra So_Luong9 * He_So9 <> So_Luong
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((So_Luong9 * He_So9) - So_Luong) > 1 AND So_Luong9 <> 0)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((So_Luong9 * He_So9) - So_Luong) > 1 AND So_Luong9 <> 0)
		
		RAISERROR (N'T?n t?i dòng [%d] (So_Luong9 * He_So) <> So_Luong', 16, 1, @_Stt0_Error)
		RETURN
	END

	--Ki?m Tra So_Luong * Gia9 <> Tien9
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((So_Luong9 * Gia_Nt9) - Tien_Nt9) > 1000 AND So_Luong9 <> 0)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((So_Luong9 * Gia_Nt9) - Tien_Nt9) > 1000 AND So_Luong9 <> 0)
		
		RAISERROR (N'T?n t?i dòng [%d] (So_Luong9 * Gia_Nt9) <> Tien_Nt9', 16, 1, @_Stt0_Error)
		RETURN
	END

	--Ki?m Tra Tien_Nt * Ty_Gia <> Tien
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE ABS((Tien_Nt * Ty_Gia) - Tien) > 1000 AND Tien_Nt <> 0 AND Ty_Gia <> 1)
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE ABS((Tien_Nt * Ty_Gia) - Tien) > 1000 AND Tien_Nt <> 0 AND Ty_Gia <> 1)

		RAISERROR (N'T?n t?i dòng [%d] (Tien_Nt * Ty_Gia) <> Tien)', 16, 1, @_Stt0_Error)
		RETURN
	END

	--Kiểm tra tài khoản nợ trước khi lưu
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE Tk_No NOT IN (SELECT Tk FROM R81DMTK WHERE Tk_Cuoi = 1))
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE Tk_No NOT IN (SELECT Tk FROM R81DMTK WHERE Tk_Cuoi = 1))

		RAISERROR (N'T?n t?i dòng [%d] tài khoản nợ chưa đúng', 16, 1, @_Stt0_Error)
		RETURN
	END

	--Kiểm tra tài khoản có trước khi lưu
	IF EXISTS(SELECT Stt0 FROM @Ct WHERE Tk_Co NOT IN (SELECT Tk FROM R81DMTK WHERE Tk_Cuoi = 1))
	BEGIN
		SET @_Stt0_Error = (SELECT MAX(Stt0) FROM @Ct WHERE Tk_Co NOT IN (SELECT Tk FROM R81DMTK WHERE Tk_Cuoi = 1))

		RAISERROR (N'T?n t?i dòng [%d] tài khoản có chưa đúng', 16, 1, @_Stt0_Error)
		RETURN
	END

	IF (@strNew_Edit IN ('N') AND @Ma_Ct = 'PXDC')
	BEGIN
		SET @_So_Seri0 = (SELECT MAX(So_Seri0) FROM @Ct)
		SET @_So_Ct = (SELECT MAX(So_Ct) FROM @Ct)
		
		if(exists(select * from R80PHSOCT WHERE Ma_Ct = @Ma_Ct AND So_Seri0 = @_So_Seri0 and So_CT = @_So_Ct))
			set @_So_Ct = (select REPLACE(STR(CAST(So_Ct as INT) + 1,7),' ','0') from R80PHSOCT  WITH (UPDLOCK, HOLDLOCK) 
					WHERE Ma_Ct = @Ma_Ct AND So_Seri0 = @_So_Seri0)
		
		UPDATE R80PHSOCT SET So_CT = @_So_Ct WHERE Ma_Ct = @Ma_Ct AND So_Seri0 = @_So_Seri0
		
		
		--RAISERROR (N'Không được sửa chứng từ khi đã duyệt Stt [%s]', 16, 1, @Stt)
		--RETURN
	END

	DECLARE @_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',
			@_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(2000),
			@_InsertPHScript VARCHAR(MAX) = '', @_InsertCtScript VARCHAR(MAX) = '',
			@_UpdatePHScript VARCHAR(MAX) = '', @_UpdateCtScript VARCHAR(MAX) = '',
			@_ColumnName VARCHAR(50) = '', @_So_LXH VARCHAR(20) = '', @_Ma_Dt VARCHAR(20) = '', @_Ma_Kho VARCHAR(20) = ''

	SELECT	@_TablePHName = Table_PH,
			@_TableCtName = Table_Ct
		FROM R00DmCt
		WHERE Ma_Ct = @Ma_Ct

	SELECT	@_TVPPHName = 'TVP_PHNX',
			@_TVPCtName = 'TVP_CtNX'

	SELECT * INTO #T_TablePH FROM @PH
	SELECT * INTO #T_TableCt FROM @Ct

	UPDATE #T_TablePH SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	UPDATE #T_TableCt SET Stt = @Stt, Ma_Ct = @Ma_Ct, Ma_DvCs = @Ma_DvCs
	
	IF(EXISTS(SELECT * FROM #T_TablePH WHERE So_Ct <> @_So_Ct AND Ma_Ct = 'PXDC' AND @_So_Ct <> ''))
	BEGIN
		UPDATE #T_TablePH SET So_Ct = @_So_Ct where Ma_Ct = 'PXDC'
		UPDATE #T_TableCt SET So_Ct = @_So_Ct, So_Ct0 = @_So_Ct where Ma_Ct = 'PXDC'
	END

	SET @_Ma_Kho = (SELECT MAX(Ma_Kho) FROM #T_TableCt)
	IF (EXISTS (SELECT * FROM #T_TableCt WHERE So_LXH <> ''))
	BEGIN
		SET @_So_LXH = (SELECT MAX(So_LXH) FROM #T_TableCt)
		SET @_Ma_Dt = (SELECT MAX(Ma_Dt) FROM #T_TableCt)

		--xử lý trùng chứng từ
	END
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
		ELSE IF (@strNew_Edit IN ('E')) --S?a
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
				--Delete nh?ng dòng không t?n t?i trong b?ng m?i (Nh?ng dòng ?ã xóa)
				DELETE T1
					FROM ' + @_TableCtName + ' T1
					WHERE NOT EXISTS (SELECT Stt, Stt0 FROM #T_TableCT T2 WHERE T2.Stt = T1.Stt AND T2.Stt0 = T1.Stt0)
						AND T1.Stt = @Stt
		
				--Update nh?ng dòng ?ã t?n t?i
				UPDATE T1 SET ' + @_UpdateCtScript + '
					FROM ' + @_TableCtName + ' T1 JOIN #T_TableCT T2 ON T1.Stt = T2.Stt AND T1.Stt0 = T2.Stt0
					WHERE T1.Stt = @Stt

				--Insert nh?ng dòng m?i thêm vào
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

	EXEC dbo.sp_Import_Tp_DChinh @Stt
	EXEC sp_UpdateDaXuatHD @Stt, @Ma_Ct, 0
	
	IF(@_Ma_Kho LIKE '05%')
		EXEC sp_UpdateHuySOCP @_So_LXH, @_Ma_Dt
END
GO