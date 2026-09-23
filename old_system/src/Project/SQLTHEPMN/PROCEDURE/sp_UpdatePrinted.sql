/*
USE R50THEPMN
GO
*/
CREATE PROCEDURE [dbo].[sp_UpdatePrinted]
(
	@TableName VARCHAR(50) = '',
	@ColumnKey VARCHAR(50) = '',
	@ValueKey VARCHAR(50) = '',
	@ColumnUpdate VARCHAR(50) = ''
)
AS
BEGIN
	DECLARE	@_SQLExec VARCHAR(MAX) = '',
			@_Printed INT = 0

	
	SET @_SQLExec = '
		UPDATE ' + @TableName + ' SET
			' + @ColumnUpdate + ' = (SELECT ISNULL(MAX(' + @ColumnUpdate + '), 0) + 1 FROM ' + @TableName + ' WHERE ' + @ColumnKey + ' = ''' + @ValueKey + ''')
			WHERE ' + @ColumnKey + ' = ''' + @ValueKey + ''''
	
	EXEC (@_SQLExec)
END
