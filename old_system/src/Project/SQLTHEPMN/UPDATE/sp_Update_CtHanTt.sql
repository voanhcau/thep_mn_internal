set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


/*
DROP PROCEDURE Sp_Update_CtHanTt

--Tạo lại TVP
EXEC sp_CreateTVPStructure 'R80CtHanTt', 'TVP_CtHanTt', 1

--Test thủ tục cập nhật
DECLARE @Ct TVP_CtHanTt
INSERT INTO @Ct SELECT * FROM R80CtHanTt WHERE Stt_Tt = 'A01010000010486'
EXEC Sp_Update_CtHanTt 'A01010000010486', 'PC', @Ct, '', '', 'A01'
SELECT * FROM R80CtHanTt
*/
IF OBJECT_ID('Sp_Update_CtHanTt') IS NOT NULL DROP PROCEDURE Sp_Update_CtHanTt
GO 

CREATE PROCEDURE [dbo].Sp_Update_CtHanTt
(
	@Stt VARCHAR(15),
	@Ma_Ct VARCHAR(5),
	@CtHanTt TVP_CtHanTt READONLY,
	@Tk VARCHAR(10) = '',
	@Ma_Dt VARCHAR(20) = '',
	@Ma_DvCs VARCHAR(5)
)
WITH ENCRYPTION
AS
BEGIN

	----Kiểm Tra tồn tại Stt khi thêm mới
	--IF (@strNew_Edit IN ('N','C', 'E') AND (NOT EXISTS(SELECT Stt FROM R80PH WHERE Stt = @Stt) AND NOT EXISTS(SELECT Stt FROM R80SDHanTt WHERE Stt = @Stt)))
	--BEGIN
	--	RAISERROR (N'Phát sinh thanh toán không đúng [%s]', 16, 1, @Stt)
	--	RETURN
	--END

	DECLARE @_SQLExec NVARCHAR(MAX) = '', @_Params NVARCHAR(2000),
			@_InsertCtScript VARCHAR(2000) = '', @_UpdateCtScript VARCHAR(2000) = '',
			@_ColumnName VARCHAR(50) = '',
			@_Stt_TT VARCHAR(15),
			@_Tk_ClTg515 NVARCHAR(20) = '',
			@_Tk_ClTg635 NVARCHAR(20) = '',
			@_Ma_Bp_ClTg NVARCHAR(20) = '',
			@_Ma_Km_ClTg NVARCHAR(20) = '',
			@_Table_Name VARCHAR(50),
			@_TVP_Name VARCHAR(50)

	SELECT	@_Table_Name = 'R80CtHanTt',
			@_TVP_Name = 'TVP_CtHanTt'

	SELECT @_Stt_TT = @Ma_DvCs + 'TT' + dbo.fn_PADL(ISNULL(MAX(SUBSTRING(Stt_Tt, 6, 10)), 0) + 1, 10, '0') 
		FROM R80CTHANTT WITH (NOLOCK)
		WHERE ISNUMERIC(SUBSTRING(Stt_Tt, 6, 10)) = 1

	SELECT * 
		INTO #T_TableCtHanTt
		FROM @CtHanTt

	EXEC sp_DefaultTable '#T_TableCtHanTt'

	UPDATE #T_TableCtHanTt SET Stt_TT = @_Stt_TT, Ma_Ct_TT = @Ma_Ct, Ma_DvCs = @Ma_DvCs 
		WHERE Stt_Tt = ''

	SELECT	@_Tk_ClTg515 = Parameter_Value
		FROM R00Parameter
		WHERE Parameter_ID = 'TK_CLTG515'

	SELECT	@_Tk_ClTg635 = Parameter_Value 
		FROM R00Parameter
		WHERE Parameter_ID = 'TK_CLTG635'
	
	SELECT	@_Ma_Bp_ClTg = Parameter_Value 
		FROM R00Parameter
		WHERE Parameter_ID = 'Ma_Bp_ClTg'

	SELECT	@_Ma_Km_ClTg = Parameter_Value 
		FROM R00Parameter
		WHERE Parameter_ID = 'Ma_Km_ClTg'

	IF @_Tk_ClTg515 = '' OR @_Tk_ClTg515 IS NULL SELECT @_Tk_ClTg515 = '5154'
	IF @_Tk_ClTg635 = '' OR @_Tk_ClTg635 IS NULL SELECT @_Tk_ClTg635 = '6354'
	IF @_Ma_Bp_ClTg = '' OR @_Ma_Bp_ClTg IS NULL SELECT @_Ma_Bp_ClTg = 'PKT'
	IF @_Ma_Km_ClTg = '' OR @_Ma_Km_ClTg IS NULL SELECT @_Ma_Km_ClTg = 'A300401'

	BEGIN TRY
		BEGIN TRANSACTION

		--Xử lý phiếu trong trường hợp người dùng F3 chứng từ gốc, chỉnh sửa chuyển đổi từ HanTt <-> ThanhToan
		IF (@Stt <> '')
		BEGIN
			IF EXISTS(SELECT * FROM dbo.vw_HanTt WHERE Stt_HD = @Stt) AND EXISTS(SELECT * FROM R80CtHanTt WHERE Stt_PT = @Stt) --Đã là HD thì không thể là PT
			BEGIN
				DELETE T1
					FROM R80CtHanTt T1
					WHERE T1.Stt_PT = @Stt AND EXISTS (SELECT 1 FROM dbo.vw_HanTt T2 WHERE T2.Stt_HD = @Stt AND T1.Tk = T2.Tk AND T1.Ma_Dt = T2.Ma_Dt)
			END
			ELSE IF EXISTS(SELECT * FROM dbo.vw_ThanhToan WHERE Stt_PT = @Stt) AND EXISTS(SELECT * FROM R80CtHanTt WHERE Stt_HD = @Stt) --Đã là PT thì không thể là HD
			BEGIN
				DELETE T1
					FROM R80CtHanTt T1
					WHERE T1.Stt_HD = @Stt AND EXISTS (SELECT 1 FROM dbo.vw_ThanhToan T2 WHERE T2.Stt_PT = @Stt AND T1.Tk = T2.Tk AND T1.Ma_Dt = T2.Ma_Dt)
			END
		END
		--Xử lý xong

		UPDATE #T_TableCtHanTt SET 
				Ma_Ct_TT = T2.Ma_Ct_PT,
				So_Ct_TT = T2.So_Ct_PT,
				Dien_Giai_TT = T2.Dien_Giai_PT
			FROM dbo.vw_ThanhToan T2 JOIN #T_TableCtHanTt T1 ON T1.Stt_PT = T2.Stt_PT

		UPDATE #T_TableCtHanTt SET Tk_No_CLTG = Tk, Tk_Co_CLTG = @_Tk_ClTg515, Dau_CLTG = 1 WHERE (LEFT(Tk, 1) IN (1, 2)) AND Tien_ClTg > 0 --131 - Lãi
		UPDATE #T_TableCtHanTt SET Tk_No_CLTG = @_Tk_ClTg635, Tk_Co_CLTG = Tk, Dau_CLTG = 1 WHERE (LEFT(Tk, 1) IN (1, 2)) AND Tien_ClTg < 0 --131 - Lỗ

		UPDATE #T_TableCtHanTt SET Tk_No_CLTG = @_Tk_ClTg635, Tk_Co_CLTG = Tk, Dau_CLTG = -1 WHERE (LEFT(Tk, 1) IN (3, 4)) AND Tien_ClTg < 0 --331 - Lỗ
		UPDATE #T_TableCtHanTt SET Tk_No_CLTG = Tk, Tk_Co_CLTG = @_Tk_ClTg515, Dau_CLTG = -1 WHERE (LEFT(Tk, 1) IN (3, 4)) AND Tien_ClTg > 0 --331 - Lãi

		UPDATE #T_TableCtHanTt SET Ma_Bp = @_Ma_Bp_ClTg WHERE Tk_No_ClTg LIKE '635%' OR Tk_Co_ClTg LIKE '635%'
		UPDATE #T_TableCtHanTt SET Ma_Km = @_Ma_Km_ClTg WHERE Tk_No_ClTg LIKE '635%' OR Tk_Co_ClTg LIKE '635%'

		UPDATE #T_TableCtHanTt SET Ma_Bp = @_Ma_Bp_ClTg WHERE Tk_No_ClTg LIKE '515%' OR Tk_Co_ClTg LIKE '515%'
		UPDATE #T_TableCtHanTt SET Ma_Km = @_Ma_Km_ClTg WHERE Tk_No_ClTg LIKE '515%' OR Tk_Co_ClTg LIKE '515%'

		-- cập nhật thanh toán xong HÓA ĐƠN
		SELECT Stt_HD, Stt_PT, ROW_NUMBER() OVER(ORDER BY Stt_HD, Stt_PT) AS Stt INTO #T_TableTtHt FROM #T_TableCtHanTt WHERE Is_TtHt = 1 GROUP BY Stt_HD, Stt_PT
		DECLARE @_i INT = 1, @_j INT = (SELECT MAX(Stt) FROM #T_TableTtHt), @_Stt_HD varchar(20) = '', @_Stt_PT varchar(20)= ''
		WHILE (@_i <= @_j)
		BEGIN
			SET @_Stt_HD = (SELECT Stt_HD FROM #T_TableTtHt WHERE Stt = @_i)
			SET @_Stt_PT = (SELECT Stt_PT FROM #T_TableTtHt WHERE Stt = @_i)

			UPDATE R04CTHD SET Is_TtHt = 1 WHERE Stt = @_Stt_HD AND Ma_Dt = @Ma_Dt
			UPDATE R02CTNM SET Is_TtHt = 1 WHERE Stt = @_Stt_HD AND Ma_Dt = @Ma_Dt
			UPDATE R80CTKT SET Is_TtHt = 1 WHERE Stt = @_Stt_HD AND Ma_Dt = @Ma_Dt
			UPDATE R01CTTIEN SET Is_TtHt = 1 WHERE Stt = @_Stt_HD AND Ma_Dt = @Ma_Dt



			UPDATE R04CTHD SET Is_TtHt = 1 WHERE Stt = @_Stt_PT AND Ma_Dt = @Ma_Dt
			UPDATE R02CTNM SET Is_TtHt = 1 WHERE Stt = @_Stt_PT AND Ma_Dt = @Ma_Dt
			UPDATE R80CTKT SET Is_TtHt = 1 WHERE Stt = @_Stt_PT AND Ma_Dt = @Ma_Dt
			UPDATE R01CTTIEN SET Is_TtHt = 1 WHERE Stt = @_Stt_PT AND Ma_Dt = @Ma_Dt


			SET @_i = @_i + 1
		END
		

		--Cập nhật vào bảng dữ liệu
		SELECT @_ColumnName = MIN(Name) 
			FROM sys.columns T1
			WHERE (T1.OBJECT_ID IN (SELECT Type_Table_object_id FROM sys.table_types where name = @_TVP_Name)) 
				AND EXISTS(SELECT * FROM sys.columns T2 WHERE T2.Object_ID = Object_ID(@_Table_Name) AND T2.Is_Identity = 0 AND T2.Name = T1.Name)
 
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
				WHERE (T1.OBJECT_ID IN (SELECT Type_Table_object_id FROM sys.table_types where name = @_TVP_Name)) 
					AND EXISTS(SELECT * FROM sys.columns T2 WHERE T2.Object_ID = Object_ID(@_Table_Name) AND T2.Is_Identity = 0 AND T2.Name = T1.Name) AND name > @_ColumnName
		END

		SELECT @_SQLExec = '
			--Delete những dòng không tồn tại trong bảng mới (Những dòng đã xóa)
			DELETE T1
				FROM ' + @_Table_Name + ' T1
				WHERE EXISTS (SELECT 1 FROM #T_TableCtHanTt T3 WHERE T3.Stt_PT = T1.Stt_PT AND T3.Ma_Dt = T1.Ma_Dt AND T3.Tk = T1.Tk )
					AND NOT EXISTS (SELECT 1 FROM dbo.vw_ThanhToan T2 WHERE T2.Tk = T1.Tk AND T2.Ma_Dt = T1.Ma_Dt AND T2.Stt_PT = T1.Stt_PT)
		
			--Update những dòng đã tồn tại
			UPDATE T1 SET ' + @_UpdateCtScript + '
				FROM ' + @_Table_Name + ' T1 INNER 
				JOIN #T_TableCtHanTt T2 ON T1.Tk = T2.Tk AND T1.Ma_Dt = T2.Ma_Dt 
				AND T1.Stt_Hd = T2.Stt_Hd AND T1.Stt_PT = T2.Stt_PT

			--Insert những dòng mới thêm vào
			INSERT INTO ' + @_Table_Name + ' (' + @_InsertCtScript + ')
				SELECT 	' + @_InsertCtScript + '
					FROM #T_TableCtHanTt T2 
					WHERE NOT EXISTS (SELECT 1 FROM ' + @_Table_Name + ' T1 
					WHERE T2.Tk = T1.Tk AND T2.Ma_Dt = T1.Ma_Dt AND T2.Stt_Hd = T1.Stt_Hd 
					AND T2.Stt_PT = T1.Stt_PT)
						AND (ABS(Tien_Tt) + ABS(Tien_Tt_Nt) + ABS(Tien_CLTG) <> 0)

			--Xóa những dòng không chứa Tiền thanh toán
			DELETE T1 
				FROM ' + @_Table_Name + ' T1
				WHERE EXISTS (SELECT 1 FROM #T_TableCtHanTt T3 WHERE T3.Stt_PT = T1.Stt_PT AND T3.Tk = T1.Tk AND T3.Ma_Dt = T1.Ma_Dt) 
				AND Tien_Tt = 0 AND Tien_Tt_Nt = 0 AND Tien_CLTG = 0'

		EXEC sp_executesql @_SQLExec

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE() + CHAR(13) + @_SQLExec,
				@ErrorSeverity INT = ERROR_SEVERITY(),
				@ErrorState INT = ERROR_STATE()

		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH

END
