ALTER PROCEDURE [dbo].[sp_DefaultTable]
(
	@_Table VARCHAR(128)
)
WITH ENCRYPTION
AS
BEGIN
	IF Object_Id('Tempdb..' + @_Table) IS NULL RETURN

	DECLARE	@_Name VARCHAR(64), @_Type VARCHAR(64), @_DefaultValue VARCHAR(128),
			@_Variance1 VARCHAR(1000)

	SET @_Variance1 = ',tinyint,smallint,int,real,money,float,bit,decimal,numeric,smallmoney,bigint,varbinary,binary,'
	
	DECLARE @T_TableDefault TABLE (Name VARCHAR(50) PRIMARY KEY, Type VARCHAR(50))
	INSERT INTO @T_TableDefault
		SELECT Tb1.Name, Tb2.Name AS Type
			FROM Tempdb..Syscolumns Tb1 INNER JOIN Tempdb..Systypes Tb2 ON Tb1.XType = Tb2.XType
			WHERE Id = Object_Id('Tempdb..' + @_Table) AND Tb1.cDefault = 0 AND
				NOT (Tb1.Colstat = 1 AND Tb1.Autoval <> SPACE(0)) -- Chi xu ly voi field khong co default
				AND Tb2.Name <> 'sysname'

	SELECT @_Name = MIN(Name) FROM @T_TableDefault
					
	WHILE @_Name IS NOT NULL
	BEGIN
		SELECT @_Type = Type FROM @T_TableDefault WHERE Name = @_Name

		SET @_DefaultValue = ''''''
		IF CHARINDEX (',' + @_Type + ',',@_Variance1) > 0
			SET @_DefaultValue = '0'

		EXEC ('ALTER TABLE ' + @_Table + ' ADD DEFAULT (' + @_DefaultValue +  ') FOR [' + @_Name + ']')

		IF CHARINDEX (',' + @_Type + ',',@_Variance1) > 0
			EXEC('UPDATE ' + @_Table + ' SET [' + @_Name + '] = 0 WHERE [' + @_Name + '] IS NULL')
		ELSE
			EXEC('UPDATE ' + @_Table + ' SET [' + @_Name + '] = '''' WHERE [' + @_Name + '] IS NULL')

		SELECT @_Name = MIN(Name) FROM @T_TableDefault WHERE Name > @_Name
	END
END