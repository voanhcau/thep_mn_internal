/*
DROP PROCEDURE sp_Update_Inherit_Barcode
*/

IF OBJECT_ID('sp_Update_Inherit_Barcode') IS NOT NULL DROP PROCEDURE sp_Update_Inherit_Barcode
GO 

CREATE PROCEDURE [dbo].[sp_Update_Inherit_Barcode]
(
	@Ngay_Ct DATE,
	@Ct TVP_CTN_BARCODE READONLY,
	@Ma_Ct VARCHAR(5),
	@Ma_DvCs VARCHAR(5)
)
--WITH ENCRYPTION
AS
BEGIN
	
	DECLARE @_Stt VARCHAR(15) = '', 
			@_So_Ct VARCHAR(20) = ''

	--Stt = 'A01TP20150131'
	SET @_Stt = @Ma_DvCs + 'TP' + YEAR(@Ngay_Ct) + dbo.fn_PADL(MONTH(@Ngay_Ct), 2, '0') + dbo.fn_PADL(DAY(@Ngay_Ct), 2, '0')

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

	BEGIN TRY
		BEGIN TRANSACTION


		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE() + CHAR(13) + @_SQLExec,
				@ErrorSeverity INT = ERROR_SEVERITY(),
				@ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH
	
	SELECT @_Stt

END