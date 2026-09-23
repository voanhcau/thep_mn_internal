set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- Thu tuc ScanTableTheKho
ALTER PROCEDURE [dbo].[sp_ScanTableTheKhoPhoi]
(
	@Ngay_Ct1 DATE = '',
	@Ngay_Ct2 DATE = '',
	@Key NVARCHAR(4000) = '',
	@Table_Out VARCHAR(32),
	@Ma_DvCs CHAR(5)
)
--WITH ENCRYPTION
AS
BEGIN

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	DECLARE @_Key NVARCHAR(4000),
			@_Tong_Hop AS BIT,
			@_SysMa_Tte	VARCHAR(5),
			@_ColumnList VARCHAR(4000),
			@_ColumnSelect VARCHAR(4000),
			@_SQLExec NVARCHAR(MAX)

	SET @_Tong_Hop = (SELECT Tong_Hop FROM R00DMDVCS WHERE Ma_DvCs = @Ma_DvCs)
	SET @_SysMa_Tte = (SELECT Parameter_Value FROM R00PARAMETER WHERE Parameter_ID = 'SYSMA_TTE')

	SET @_Key = 
		'(Ngay_Ct BETWEEN ''' + CAST(@Ngay_Ct1 AS VARCHAR(11)) + ''' AND ''' + CAST(@Ngay_Ct2 AS VARCHAR(11)) + ''')'

	IF @Key <> ''
		SET @_Key = @_Key + ' AND ' + @Key

	IF @_Tong_Hop <> 1
		SET @_Key = @_Key + ' AND (Ma_DvCs = ''' + @Ma_DvCs + ''')'
	ELSE
		SET @_Key = @_Key + ' AND (Ma_DvCs IN (SELECT Ma_DvCs FROM R00DMDVCS WHERE Tong_Hop <> 1))'

	EXEC sp_GetColumnListBetween2Table 'vw_TheKhoPhoi', @Table_Out, @_ColumnList OUTPUT, 0

	SET @_ColumnSelect = @_ColumnList + ','

	IF @_SysMa_Tte = 'VND'
	BEGIN
		SET @_ColumnSelect = REPLACE(@_ColumnSelect, 'Gia_Nt,', 'CASE WHEN Ma_Tte = ''' + @_SysMa_Tte + ''' THEN 0 ELSE Gia_Nt END,')
		SET @_ColumnSelect = REPLACE(@_ColumnSelect, 'Tien_Nt,', 'CASE WHEN Ma_Tte = ''' + @_SysMa_Tte + ''' THEN 0 ELSE Tien_Nt END,')
		SET @_ColumnSelect = REPLACE(@_ColumnSelect, 'Tien_Nt3,', 'CASE WHEN Ma_Tte = ''' + @_SysMa_Tte + ''' THEN 0 ELSE Tien_Nt3 END,')
	END

	IF RIGHT(@_ColumnSelect, 1) = ','
		SET @_ColumnSelect = LEFT(@_ColumnSelect, LEN(@_ColumnSelect) - 1)

	SET @_SQLExec = '
		INSERT INTO ' + @Table_Out + '(' + @_ColumnList + ')
			SELECT ' + @_ColumnSelect + '
				FROM vw_TheKhoPhoi
				WHERE ' + @_Key
	PRINT @_SQLExec
	EXECUTE(@_SQLExec)
	
END




