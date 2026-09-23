ALTER PROCEDURE [dbo].[sp_Update_PH_Scale]
(
	@strNew_Edit CHAR(1) = '',
	@Loai_Ct VARCHAR(5) = '',
	@Stt VARCHAR(15) = '',
	@Ma_Ct VARCHAR(5) = '',
	@So_Ct VARCHAR(20) = '',
	@Ngay_Ct DATE = '',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_Dt_CbNv_Vao VARCHAR(20) = '',
	@Ma_Dt_CbNv_Ra VARCHAR(20) = '',
	@Ma_Vt_Sp VARCHAR(20) = '',
	@Dien_Giai NVARCHAR(200) = '',
	@Ten_Cong_Trinh NVARCHAR(200) = '',
	@So_Xe VARCHAR(20) = '',
	@So_Xa_Lan_Tau VARCHAR(20) = '',
	@Can VARCHAR(5) = '',
	@So_Luong_Vao MONEY = 0,
	@So_Luong_Ra MONEY = 0,
	@So_Luong MONEY = 0,
	@Time_In DATETIME = '',
	@Time_Out DATETIME = '',
	@Duyet BIT = 0,
	@Ly_Do NVARCHAR(200) = '',
	@Stt_Org VARCHAR(15) = '',
	@Ma_Vt_Org VARCHAR(1000) = '',
	@Create_Log VARCHAR(35) = '',
	@LastModify_Log VARCHAR(35) = '',
	@LastModify_Log2 VARCHAR(35) = '',
	@Ma_DvCs VARCHAR(3) = 'A01'
)
AS
BEGIN
	DECLARE @_iStt INT,
			@_iSo_Ct INT,
			@_Stt VARCHAR(15),
			@_So_Ct VARCHAR(20),
			@_Ngay_Ct DATE,
			@_Time_In DATETIME,
			@_Time_Out DATETIME

	SET DATEFORMAT MDY
	SET @_Ngay_Ct = GETDATE()
	SET @_Time_In = CONVERT(VARCHAR, GETDATE(), 120)--Chi lay DD-MM-YYY HH:mm:ss nen phai FORMAT MDY
	SET @_Time_Out = CONVERT(VARCHAR, GETDATE(), 120)
	
	IF @strNew_Edit = 'N'
	BEGIN
		BEGIN TRY
		BEGIN TRANSACTION
		
			--Stt
			SET @_iStt = (SELECT ISNULL(MAX(SUBSTRING(Stt, 6, 10)), 0)
								FROM R80PH_SCALE WITH(NOLOCK)
								WHERE Stt LIKE '___80%' AND ISNUMERIC(SUBSTRING(Stt, 6, 10)) = 1) + 1

			SET @_Stt = (SELECT dbo.fn_PADL(@Ma_DvCs, 3, '0')) + '80' + (SELECT dbo.fn_PADL(@_iStt, 10, '0'))
	
			--So_Ct
			SET @_iSo_Ct = (SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(So_Ct)) AS BIGINT)), 0) FROM R80PH_SCALE WHERE YEAR(Ngay_Ct) = YEAR(GETDATE())) + 1
			SET @_So_Ct = (SELECT dbo.fn_PADL(@_iSo_Ct, 6, '0'))

			--INSERT R80PH_SCALE
			--INSERT SO_CT = STT
			INSERT R80PH_SCALE(Stt, Ma_Ct, Loai_Ct, So_Ct, Ngay_Ct, Ma_Dt, Ma_Dt_CbNv_Vao, Ma_Vt_Sp, Dien_Giai, Ten_Cong_Trinh, So_Xe, So_Xa_Lan_Tau, So_Luong_Vao, So_Luong_Ra, So_Luong, Time_In, Can, Stt_Org, Ma_Vt_Org, Create_Log, Duyet, Ma_DvCs)
				VALUES(@_Stt, @Ma_Ct, @Loai_Ct, @_So_Ct, @_Ngay_Ct, @Ma_Dt, @Ma_Dt_CbNv_Vao, @Ma_Vt_Sp, @Dien_Giai, @Ten_Cong_Trinh, @So_Xe, @So_Xa_Lan_Tau, @So_Luong_Vao, @So_Luong_Ra, @So_Luong, @_Time_In, @Can, @Stt_Org, @Ma_Vt_Org, @Create_Log, @Duyet, @Ma_DvCs)
		
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @_Stt = ''
			DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE(),
					@ErrorSeverity INT = ERROR_SEVERITY(),
					@ErrorState INT = ERROR_STATE()

			RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

		END CATCH

		SELECT @_Stt AS Stt
		
		RETURN
	END
	ELSE IF @strNew_Edit = 'E'
	BEGIN
		BEGIN TRY
		BEGIN TRANSACTION
		
			--UPDATE R80PH_SCALE
			UPDATE R80PH_SCALE SET
					Ma_Dt = @Ma_Dt,
					Ma_Dt_CbNv_Ra = @Ma_Dt_CbNv_Ra,
					Ma_Vt_Sp = @Ma_Vt_Sp,
					Dien_Giai = @Dien_Giai,
					Ten_Cong_Trinh = @Ten_Cong_Trinh,
					So_Xe = @So_Xe,
					So_Xa_Lan_Tau = @So_Xa_Lan_Tau,
					So_Luong_Vao = @So_Luong_Vao,
					So_Luong_Ra = @So_Luong_Ra,
					Loai_Ct = CASE WHEN @So_Luong_Vao > @So_Luong_Ra THEN '1' ELSE '2' END,
					So_Luong = @So_Luong,
					Time_Out = @_Time_Out,
					Duyet = @Duyet,
					Ly_Do = @Ly_Do,
					LastModify_Log = @LastModify_Log
			WHERE Stt = @Stt
		
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @_Stt = ''
			DECLARE @ErrorMessage1 NVARCHAR(4000) = ERROR_MESSAGE(),
					@ErrorSeverity1 INT = ERROR_SEVERITY(),
					@ErrorState1 INT = ERROR_STATE()

			RAISERROR (@ErrorMessage1, @ErrorSeverity1, @ErrorState1);

		END CATCH
	END
	ELSE
	BEGIN
		BEGIN TRY
		BEGIN TRANSACTION
		
			--UPDATE R80PH_SCALE Khi sửa toàn phiếu đã hoàn thành
			UPDATE R80PH_SCALE SET
					So_Xe = @So_Xe,
					So_Xa_Lan_Tau = @So_Xa_Lan_Tau,
					Ma_Dt = @Ma_Dt,
					Ma_Vt_Sp = @Ma_Vt_Sp,
					Dien_Giai = @Dien_Giai,
					Ten_Cong_Trinh = @Ten_Cong_Trinh,
					So_Luong_Vao = @So_Luong_Vao,
					So_Luong_Ra = @So_Luong_Ra,
					So_Luong = @So_Luong,
					Ly_Do = @Ly_Do,
					LastModify_Log2 = @LastModify_Log2
			WHERE Stt = @Stt
		
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION

			SET @_Stt = ''
			DECLARE @ErrorMessage2 NVARCHAR(4000) = ERROR_MESSAGE(),
					@ErrorSeverity2 INT = ERROR_SEVERITY(),
					@ErrorState2 INT = ERROR_STATE()

			RAISERROR (@ErrorMessage2, @ErrorSeverity2, @ErrorState2);

		END CATCH
	END
END
GO
--EXEC sp_Update_PH_Scale @strNew_Edit = 'N', @Loai_Ct = '1', @Stt = '', @Ma_Ct = 'PXTH'