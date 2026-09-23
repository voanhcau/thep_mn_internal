set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/*
--Test thủ tục Delete
EXEC Sp_Delete_Ct 'A01010000010853', 'BN', 'TEST', 'A01'
*/

ALTER PROCEDURE [dbo].[Sp_Delete_Ct]
(
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@LastModify_Log NVARCHAR(35) = '',
	@Ma_DvCs VARCHAR(5)
)
--WITH ENCRYPTION
AS
BEGIN

	DECLARE @_SQLExec NVARCHAR(MAX) = '',
			@_TablePHName VARCHAR(50) = '', @_TVPPHName VARCHAR(50) = '',
			@_TableCtName VARCHAR(50) = '', @_TVPCtName VARCHAR(50) = '',
			@_Count INT = 0

	SELECT	@_TablePHName = Table_PH,
			@_TableCtName = Table_Ct
		FROM R00DmCt
		WHERE Ma_Ct = @Ma_Ct

	EXECUTE('SELECT 1 FROM ' + @_TablePHName + ' WHERE Stt = ''' + @Stt + ''' AND Ma_DvCs = ''' + @Ma_DvCs + '''')
	IF (@@ROWCOUNT = 0)
	BEGIN
		RAISERROR (N'Không tồn tại phiếu [%s1] - Stt [%s2] - DvCs [%s3]', 16, 1, @Ma_Ct, @Stt, @Ma_DvCs)
		RETURN
	END

	BEGIN TRY
		BEGIN TRANSACTION

		--Xóa trong HanTt0
		IF (COL_LENGTH('R80CtHanTt', 'LastModify_Log') IS NOT NULL)
			UPDATE R80CtHanTt SET LastModify_Log = @LastModify_Log WHERE Stt_TT = @Stt OR Stt_PT = @Stt OR Stt_HD = @Stt

		DELETE FROM R80CtHanTt WHERE Stt_TT = @Stt OR Stt_PT = @Stt OR Stt_HD = @Stt

		--Xóa trong R05CtNXLR
		IF (COL_LENGTH('R05CTNXLR', 'LastModify_Log') IS NOT NULL)
			UPDATE R05CTNXLR SET LastModify_Log = @LastModify_Log WHERE Stt = @Stt

		IF EXISTS(SELECT 1 FROM R05CTNXLR WHERE Stt = @Stt)
			DELETE FROM R05CTNXLR WHERE Stt = @Stt

		--Xóa trong Bảng Ct
		--SET @_SQLExec = '
		--		IF EXISTS (SELECT * FROM ' + @_TableCtName + ' WHERE Stt = ''' + @Stt + ''')
		--		BEGIN ' +
		--			IF (COL_LENGTH(@_TableCtName, 'LastModify_Log') IS NOT NULL) 
		--				'UPDATE ' + @_TableCtName + ' SET LastModify_Log = ''' + @LastModify_Log + ''' WHERE Stt = ''' + @Stt + '''
					
		--			DELETE FROM ' + @_TableCtName + ' WHERE Stt = ''' + @Stt + '''
		--		END'
		
		--EXECUTE(@_SQLExec)

		EXECUTE('SELECT 1 FROM ' + @_TableCtName + ' WHERE Stt = ''' + @Stt + '''')
		IF (@@ROWCOUNT > 0)
		BEGIN
			IF (COL_LENGTH(@_TableCtName, 'LastModify_Log') IS NOT NULL)
				EXECUTE('UPDATE ' + @_TableCtName + ' SET LastModify_Log = ''' + @LastModify_Log + ''' WHERE Stt = ''' + @Stt + '''')

			EXECUTE('DELETE FROM ' + @_TableCtName + ' WHERE Stt = ''' + @Stt + '''')
		END

		--Xóa trong Bảng PH
		EXECUTE('SELECT 1 FROM ' + @_TablePHName + ' WHERE Stt = ''' + @Stt + '''')
		IF (@@ROWCOUNT > 0)
		BEGIN
			IF (COL_LENGTH(@_TablePHName, 'LastModify_Log') IS NOT NULL)
				EXECUTE('UPDATE ' + @_TablePHName + ' SET LastModify_Log = ''' + @LastModify_Log + ''' WHERE Stt = ''' + @Stt + '''')

			EXECUTE('DELETE FROM ' + @_TablePHName + ' WHERE Stt = ''' + @Stt + '''')
		END

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE(),
				@ErrorSeverity INT = ERROR_SEVERITY(),
				@ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH
	
	--SELECT @Stt

END
