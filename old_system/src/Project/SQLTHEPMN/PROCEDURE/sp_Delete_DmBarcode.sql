ALTER PROCEDURE sp_Delete_DmBarcode
(
	@Barcode VARCHAR(20) = ''
)
AS
BEGIN
	IF EXISTS(SELECT Barcode FROM R05CTX_BARCODE WHERE Barcode = @Barcode)
	BEGIN
		RAISERROR (N'Mã vạch đã được xuất rồi Barcode [%s]', 16, 1, @Barcode)
		RETURN
	END

	BEGIN TRY
	BEGIN TRANSACTION

		DELETE FROM R81DMBARCODE WHERE Barcode = @Barcode
		--DELETE FROM R05CTN_BARCODE WHERE Ident00 = @Ident00 AND Barcode = @Barcode

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE(),
				@ErrorSeverity INT = ERROR_SEVERITY(),
				@ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH
END