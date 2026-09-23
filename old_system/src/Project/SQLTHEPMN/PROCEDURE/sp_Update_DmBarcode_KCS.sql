ALTER PROCEDURE [dbo].[sp_Update_DmBarcode_KCS]
(
	@Barcode VARCHAR(20) = '',
	@Yeild MONEY = 0,
	@Tension MONEY = 0,
	@ELong MONEY = 0,
	@Try_ID VARCHAR(50) = '',
	@Bend_Test BIT = 0,
	@Is_OutPut BIT = 1,
	@Is_Thu_Pham BIT = 0,
	@No_Melt_Confirm VARCHAR(20) = '',
	@LastModify_Log_KCS VARCHAR(35) = '',
	@Remark_KCS NVARCHAR(200) = ''
)
AS
BEGIN
	DECLARE @_Is_Wait_Process BIT,
			@_Is_OutPuted BIT

	BEGIN TRY
		BEGIN TRANSACTION

			SET @_Is_Wait_Process = (SELECT ISNULL(Is_Wait_Process, 0) FROM R81DMBARCODE WHERE Barcode = @Barcode)
			
			SET @_Is_OutPuted = (SELECT CASE WHEN T2.So_Luong_OutPut IS NULL THEN 0 ELSE 1 END
									FROM R81DMBARCODE T1 LEFT JOIN (SELECT Barcode, ISNULL(SUM(So_Luong), 0) AS So_Luong_OutPut
																			FROM R05CTX_BARCODE WITH(NOLOCK)
																			WHERE Barcode = @Barcode
																			GROUP BY Barcode) T2 ON T1.Barcode = T2.Barcode
									WHERE T1.Barcode = @Barcode)

				UPDATE R81DMBARCODE SET
						Yeild = @Yeild,
						Tension = @Tension,
						ELong = @ELong,
						Try_ID = @Try_ID,
						Bend_Test = @Bend_Test,
						Is_OutPut = @Is_OutPut,
						Is_Thu_Pham = @Is_Thu_Pham,
						Remark_KCS = @Remark_KCS,
						LastModify_Log_KCS = @LastModify_Log_KCS,
						No_Melt_Confirm = @No_Melt_Confirm
					WHERE Barcode = @Barcode
			
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