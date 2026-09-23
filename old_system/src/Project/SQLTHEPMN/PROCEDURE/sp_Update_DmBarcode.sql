/*
EXEC sp_Update_DmBarcode 'N', @Code = 6968
*/
ALTER PROCEDURE [dbo].[sp_Update_DmBarcode]
(
	@strNew_Edit CHAR(1) = '',
	@Barcode_Org VARCHAR(100) = '',
	@Barcode VARCHAR(20) = '',
	@Ma_Size VARCHAR(20) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@Ma_Ca VARCHAR(20) = '',
	@Standard_ID VARCHAR(20) = '',
	@Grade_ID VARCHAR(20) = '',
	@Ma_CL VARCHAR(20) = '',
	@No_Melt VARCHAR(20) = '',
	@No_Melt_Confirm VARCHAR(20) = '',
	@Lot_ID VARCHAR(20) = '',
	@Num_Lot VARCHAR(50) = '',
	@Num_Bars MONEY = 0,
	@Length MONEY = 0,
	@Code INT = 0,
	@So_Luong MONEY = 0,
	@So_Luong_Barem MONEY = 0,
	@Num_Bars_Embryos MONEY = 0,
	@Bend_Test BIT = 0,
	@Ly_Do NVARCHAR(200) = '',
	@Remark NVARCHAR(200) = '',
	@State_Process BIT = 0,
	@Input_Type BIT = 0,
	@Yeild MONEY = 0,
	@Tension MONEY = 0,
	@ELong MONEY = 0,
	@Try_ID VARCHAR(50) = '',
	@Date_Process DATE = '19000101',
	@Is_Thu_Pham BIT = 0,
	@Is_OutPut BIT = 0,
	@Is_Barem BIT = 0,
	@Create_Log VARCHAR(35) = '',
	@LastModify_Log VARCHAR(35) = '',
	@Ma_Data VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_Ngay_Nhap DATE = '19000101',
			@_BarCode VARCHAR(50) = '',
			@_Ma_Kho VARCHAR(20) = '',
			@_SuffixLen INT = 7,
			@_Num_Barcode VARCHAR(10) = '',
			@_Code INT = 0

	SET @_Code = @Code

	IF @strNew_Edit = 'E'
	BEGIN
		UPDATE R81DMBARCODE SET
				Ma_Size = @Ma_Size,
				Grade_ID = @Grade_ID,
				Standard_ID = @Standard_ID,
				Ma_CL = @Ma_CL,
				Lot_ID = @Lot_ID,
				Num_Lot = @Num_Lot,
				Num_Bars = @Num_Bars,
				Length = @Length,
				So_Luong = @So_Luong,
				So_Luong_Barem = @So_Luong_Barem,
				No_Melt = @No_Melt,
				Num_Bars_Embryos = @Num_Bars_Embryos,
				Ly_Do = @Ly_Do,
				LastModify_Log = @LastModify_Log
			WHERE Barcode = @Barcode

		RETURN
	END
	ELSE
	BEGIN	
		SET @_Ma_Kho = 'KTPBARCODE'
		--Hai sua lai Lay Ngay_Sx Tu DmCa Phuc vu cho viec Ke thua sang PX, PX
		SET @_Ngay_Nhap = (SELECT MAX(Ngay_Sx) FROM R81DMCA WHERE Ma_Ca = @Ma_Ca) 

		BEGIN TRY
		BEGIN TRANSACTION

			--La Barcode lẻ
			IF @strNew_Edit = 'L'
			BEGIN
				
				SET @_BarCode = (SELECT dbo.fn_GetNewBarcode(@strNew_Edit, @_Ngay_Nhap, @_SuffixLen, @Code))
				SET @_Num_BarCode = CASE WHEN LEN(@_BarCode) >= @_SuffixLen THEN SUBSTRING(@_BarCode, @_SuffixLen, LEN(@_Barcode)) ELSE 0 END
				SET @_Num_BarCode = (SELECT dbo.fn_PADL(@_Num_Barcode, @_SuffixLen,'0'))

				SET @_Code = CASE WHEN LEN(@_BarCode) >= @_SuffixLen THEN SUBSTRING(@_BarCode, @_SuffixLen, LEN(@_Barcode)) ELSE 0 END
				--SET @_Ngay_Nhap = (SELECT Ngay_Sx FROM R81DMCA WHERE Ma_Ca = @Ma_Ca)
				SET @_Ngay_Nhap = (SELECT dbo.fn_GetNow())

				--Insert R81DMBARCODE
				INSERT R81DMBARCODE(Barcode, Ngay_Nhap, Ma_Size, Ma_Vt_Sp, Ma_Ca, Standard_ID, Grade_ID, Ma_CL, No_Melt, No_Melt_Confirm, Lot_ID, Num_Lot, Num_Bars, Num_Barcode, Num_Bars_Embryos, Bend_Test, Length, Code, So_Luong, So_Luong_Barem, So_Luong_Old, Num_Bars_Old, Create_Log, LastModify_Log, State_Process, Input_Type, Remark, Yeild, Tension, ELong, Try_ID, Date_Process, Is_Thu_Pham, Is_OutPut, Is_Barem, Barcode_Org, Ma_Data)
				VALUES(@_Barcode, @_Ngay_Nhap, @Ma_Size, @Ma_Vt_Sp, @Ma_Ca, @Standard_ID, @Grade_ID, @Ma_CL, @No_Melt, @No_Melt_Confirm, @Lot_ID, @Num_Lot, @Num_Bars, @_Num_Barcode, @Num_Bars_Embryos, @Bend_Test, @Length, @_Code, @So_Luong, @So_Luong_Barem, @So_Luong, @Num_Bars, @Create_Log, @LastModify_Log, @State_Process, @Input_Type, @Remark, @Yeild, @Tension, @ELong, @Try_ID, @Date_Process, @Is_Thu_Pham, @Is_OutPut, @Is_Barem, @Barcode_Org, @Ma_Data)

			END
			ELSE
			BEGIN
				
				SET @_BarCode = (SELECT dbo.fn_GetNewBarcode(@strNew_Edit, @_Ngay_Nhap, @_SuffixLen, @Code))
				SET @_Num_BarCode = CASE WHEN LEN(@_BarCode) >= @_SuffixLen THEN SUBSTRING(@_BarCode, @_SuffixLen, LEN(@_Barcode)) ELSE 0 END
				SET @_Num_BarCode = (SELECT dbo.fn_PADL(@_Num_Barcode, @_SuffixLen,'0'))

				--Insert R81DMBARCODE
				INSERT R81DMBARCODE(Barcode, Ngay_Nhap, Ma_Size, Ma_Vt_Sp, Ma_Ca, Standard_ID, Grade_ID, Ma_CL, No_Melt, No_Melt_Confirm, Lot_ID, Num_Lot, Num_Bars, Num_Barcode, Num_Bars_Embryos, Bend_Test, Length, Code, So_Luong, So_Luong_Barem, So_Luong_Old, Num_Bars_Old, Create_Log, State_Process, Input_Type, Is_Barem, Remark, Ma_Data)
				VALUES(@_Barcode, @_Ngay_Nhap, @Ma_Size, @Ma_Vt_Sp, @Ma_Ca, @Standard_ID, @Grade_ID, @Ma_CL, @No_Melt, @No_Melt_Confirm, @Lot_ID, @Num_Lot, @Num_Bars, @_Num_Barcode, @Num_Bars_Embryos, @Bend_Test, @Length, @_Code, @So_Luong, @So_Luong_Barem, @So_Luong, @Num_Bars, @Create_Log, @State_Process, @Input_Type, @Is_Barem, @Remark, @Ma_Data)
		
			END
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @_Barcode = ''
			DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE(),
					@ErrorSeverity INT = ERROR_SEVERITY(),
					@ErrorState INT = ERROR_STATE()

			RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

		END CATCH

		SELECT @_BarCode AS Barcode
	END
END
