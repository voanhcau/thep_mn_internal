set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

/*Thủ tục tính Mã tăng dần
SELECT TOP 10 * FROM R80PH ORDER BY Stt
EXEC sp_GetNewID 'R80PH', 'Stt', '23300139', 'Ma_DvCs = ''A01''', 3, 0

EXEC sp_GetNewID 'R81DMVT', 'Ma_Vt', '23300139','Ma_Vt ', 'Ma_DvCs = ''A01''', 3, 0
EXEC sp_GetNewID 'R80PH', 'So_Ct', '0060/04', 'Ma_DvCs = ''A01'' AND Ma_Ct = ''PC''', 0, 3
SELECT MAX(So_Ct) FROM R80PH WHERE Ma_DvCs = 'A01' AND Ma_Ct = 'PT'
*/
ALTER PROCEDURE [dbo].[sp_GetNewID]
(
	@TableName VARCHAR(50),
	@ColumnName VARCHAR(50),
	@CurrentID VARCHAR(50),
	@Key VARCHAR(1000) = '',
	@PrefixLen INT = 0,
	@SuffixLen INT = 0
)
WITH ENCRYPTION
AS
BEGIN

	IF COL_LENGTH(@TableName, @ColumnName) IS NULL
		RETURN
	
	DECLARE @_i BIGINT,
			@_iColLen BIGINT,
			@_iMaxID BIGINT,
			@_iRestLen BIGINT,
			@_NewID NVARCHAR(50),
			@_PrefixID NVARCHAR(50),
			@_RestID NVARCHAR(50),
			@_RestMaxID NVARCHAR(50),
			@_SQLExec NVARCHAR(1000),
			@_Prefix NVARCHAR(50),
			@_Suffix NVARCHAR(50),
			@_iSubStart BIGINT,
			@_iSubLen BIGINT

	--Tách Prefix, Suffix định nghĩa trước
	SELECT @_Prefix = '', @_Suffix = ''
	
	IF (LEN(@CurrentID) > @PrefixLen AND @PrefixLen > 0)
	BEGIN
		SELECT	@_Prefix = SUBSTRING(@CurrentID, 0, @PrefixLen + 1),
				@CurrentID = SUBSTRING(@CurrentID, @PrefixLen + 1, LEN(@CurrentID) - @PrefixLen)
	END

	IF (LEN(@CurrentID) > @SuffixLen AND @SuffixLen > 0)
	BEGIN
		SELECT	@_Suffix = SUBSTRING(@CurrentID, LEN(@CurrentID) - @SuffixLen + 1, @SuffixLen),
				@CurrentID = SUBSTRING(@CurrentID, 0, LEN(@CurrentID) - @SuffixLen + 1)
	END

	--Tách xong
	
	SELECT	@_i = 0,
			@_iRestLen = LEN(@CurrentID),
			@_PrefixID = '',
			@_RestID = '',
			@_iMaxID = 0,
			@_RestMaxID = '',
			@_iColLen = COL_LENGTH(@TableName, @ColumnName)
	
	--Đi từ trái sang phải
	WHILE @_i <= LEN(@CurrentID)
	BEGIN
		SELECT	@_PrefixID = LEFT(@CurrentID, @_i),
				@_RestID = SUBSTRING(@CurrentID, @_i + 1, LEN(@CurrentID) - @_i),
				@_iRestLen = LEN(@_RestID)

		PRINT @_PrefixID

		--Nếu chuỗi còn lại là số hoặc chuỗi còn lại bằng ''
		IF ((ISNUMERIC(@_RestID) = 1 AND CHARINDEX('.', @_RestID) = 0) OR (@_RestID = ''))
		BEGIN
			SELECT	@_iSubStart = @_i+1 + LEN(@_Prefix),
					@_iSubLen = LEN(@CurrentID) - @_i

			SET @_SQLExec = N'
				SELECT @_iMaxID = ISNULL(MAX(CAST(RTRIM(LTRIM(SUBSTRING(' + @ColumnName + ', ' + LTRIM(STR(@_iSubStart)) + ', ' + LTRIM(STR(@_iSubLen)) + '))) AS BIGINT)), 0)
					FROM ' + @TableName + '
					WHERE ' + @ColumnName + ' LIKE ''' + @_Prefix + @_PrefixID + '%'' AND ' + @ColumnName + ' LIKE ''%' + @_Suffix + ''' AND ' + 
						'ISNUMERIC(SUBSTRING(' + @ColumnName + ', ' + LTRIM(STR(@_iSubStart)) + ', ' + LTRIM(STR(@_iSubLen)) + ')) = 1 AND ' + 
						'CHARINDEX(''.'', SUBSTRING(' + @ColumnName + ', ' + LTRIM(STR(@_iSubStart)) + ', ' + LTRIM(STR(@_iSubLen)) + ')) = 0'

			IF @Key <> ''
				SET @_SQLExec = @_SQLExec + ' AND ' + @Key

			PRINT @_SQLExec
			EXEC sp_ExecuteSQL @_SQLExec, N'@_iMaxID BIGINT OUTPUT', @_iMaxID OUTPUT

			SET @_RestMaxID = LTRIM(RTRIM(STR(@_iMaxID)))
			
			IF (@_RestMaxID IS NOT NULL AND ISNUMERIC(@_RestMaxID) = 1)
			BEGIN
				SELECT	@_iRestLen = LEN(@_RestMaxID),
						@_RestMaxID = REPLACE(STR(CAST(@_RestMaxID AS BIGINT) + 1), ' ', '')

				BREAK
			END
		END

		SET @_i = @_i + 1
	END

	IF (LEN(@_RestMaxID) < LEN(@_RestID))
		SET @_RestMaxID = dbo.fn_PADL(@_RestMaxID, LEN(@_RestID), '0')
	
	SET @_NewID = @_Prefix + @_PrefixID + @_RestMaxID + @_Suffix
	
	SELECT ISNULL(@_NewID, @CurrentID)
	
END
