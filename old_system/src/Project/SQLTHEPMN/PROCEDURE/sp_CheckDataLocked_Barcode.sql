-- Thu tuc tra ve 
CREATE PROCEDURE [dbo].[sp_CheckDataLocked_Barcode]
(
	@Ngay_Ct DATETIME,
	@Ma_DvCs VARCHAR(3)
)	
WITH ENCRYPTION
AS
BEGIN

	 IF (SELECT COUNT(*) 
			FROM R00Locked_Barcode
			WHERE Ma_DvCs = @Ma_DvCs AND @Ngay_Ct BETWEEN Ngay_Locked1 AND Ngay_Locked2) > 0

		SELECT CAST(0 AS Bit)
	ELSE
		SELECT CAST(1 AS Bit)

END
GO
