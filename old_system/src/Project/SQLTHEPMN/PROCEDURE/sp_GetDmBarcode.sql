ALTER PROCEDURE [dbo].[Sp_GetDmBarcode]
(
	@Ma_Ca VARCHAR(20) = '',
	@Barcode VARCHAR(20) = ''
)
AS
BEGIN
	DECLARE @_Key VARCHAR(MAX),
			@_SQLExec VARCHAR(MAX)

	SET @_Key = '(0 = 0)'

	IF @Ma_Ca <> ''
		SET @_Key = @_Key + ' AND T1.Ma_Ca = ''' + @Ma_Ca + ''''

	IF @Barcode <> ''
		SET @_Key = @_Key + ' AND T1.Barcode = ''' + @Barcode + ''''

	SET @_SQLExec = '
		SELECT	T1.*,
				T2.Ten_Size, T3.Lot_Name, T4.Grade_Name, T5.Ten_CL, T6.Standard_Name
			FROM R81DMBARCODE T1 WITH(NOLOCK)
				LEFT JOIN R81DMSIZE T2 WITH(NOLOCK) ON T1.Ma_Size = T2.Ma_Size
				LEFT JOIN R81DMLOTS T3 WITH(NOLOCK) ON T1.Lot_ID = T3.Lot_ID
				LEFT JOIN R81DMMACTHEP T4 WITH(NOLOCK) ON T1.Grade_ID = T4.Grade_ID
				LEFT JOIN R81DMCL T5 WITH(NOLOCK) ON T1.Ma_CL = T5.Ma_CL
				LEFT JOIN R81DMSTANDARD T6 WITH(NOLOCK) ON T1.Standard_ID = T6.Standard_ID
			WHERE ' + @_Key + '
			ORDER BY T1.Barcode DESC'
	EXEC (@_SQLExec)

END

GO
EXEC Sp_GetDmBarcode '1008407'