set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go



-- Copy du lieu tu @TableSource vao @TableDest theo danh sach cac column
ALTER PROCEDURE [dbo].[sp_Copy_Data]
(
	@TableSource VARCHAR(50),
	@TableDest VARCHAR(50),
	@ColumnList VARCHAR(4000) = '',
	@Key VARCHAR(4000) = ''
)
WITH ENCRYPTION	
AS
BEGIN
	
	IF Object_Id('TempDB..#T_ColumnCopy') IS NOT NULL DROP TABLE #T_ColumnCopy

	DECLARE @_SQLExec VARCHAR(MAX), 
			@_ColumnList1 VARCHAR(MAX),
			@_ColumnList2 VARCHAR(MAX),	
			@_ColumnName VARCHAR(50),
			@_DBSource VARCHAR(50),
			@_DBDest VARCHAR(50),
			@_TableSource VARCHAR(50),
			@_TableDest VARCHAR(50),
			@_Is_TableSourceTemp BIT,
			@_Is_TableDestTemp BIT,
			@_Is_Identity BIT,
			@_Source_Type VARCHAR(50), 
			@_Source_Length INT, 
			@_Source_Scale INT, 
			@_Dest_Type VARCHAR(50), 
			@_Dest_Length INT, 
			@_Dest_Scale INT
	
	SELECT	@_Is_TableSourceTemp = CASE WHEN LEFT(@TableSource, 1) = '#' THEN 1 ELSE 0 END,
			@_Is_TableDestTemp = CASE WHEN LEFT(@TableDest, 1) = '#' THEN 1 ELSE 0 END,
			@_ColumnList1 = '',
			@_ColumnList2 = '',
			@_DBSource = '',
			@_DBDest = ''

	SELECT	@ColumnList = REPLACE(@ColumnList, ' ', ''),
			@ColumnList = REPLACE(@ColumnList, CHAR(13), ''),
			@ColumnList = REPLACE(@ColumnList, CHAR(10), ''),
			@ColumnList = REPLACE(@ColumnList, CHAR(9), '')

	DECLARE @i INT

	--Source
	IF @_Is_TableSourceTemp = 1
		SELECT	@_DBSource = 'TempDB.',
				@_TableSource = 'TempDB..' + @TableSource
	ELSE
		BEGIN
			SELECT @i = CHARINDEX ('.',@TableSource)

			IF( @i > 0) 
			BEGIN
				SET @_DBSource = SubString(@TableSource,1,@i )
			END
			ELSE SET @_DBSource = ''
			 
			SELECT	--@_DBSource = '',
					@_TableSource = @TableSource
		END

--		SELECT	@_DBSource = '',
--				@_TableSource = @TableSource

	--Dest
	IF @_Is_TableDestTemp = 1
		SELECT	@_DBDest = 'TempDB.',
				@_TableDest = 'TempDB..' + @TableDest
	ELSE
		BEGIN			
			SELECT @i = CHARINDEX ('.',@TableDest)

			IF( @i > 0) 
			BEGIN
				SET @_DBDest = SubString(@TableDest,1,@i )
			END
			ELSE SET @_DBDest = ''
			 
			SELECT	--@_DBDest = '',
					@_TableDest = @TableDest
		END
--		SELECT	@_DBDest = '',
--				@_TableDest = @TableDest

	--Tao danh sach cac column co trong ca 2 table
	CREATE TABLE #T_ColumnCopy (
			ColumnName VARCHAR(50) NOT NULL, 
			Source_Type VARCHAR(50), Source_Length INT, Source_Scale INT,
			Dest_Type VARCHAR(50), Dest_Length INT, Dest_Scale INT)

	SET @_SQLExec = 
		'SELECT Name AS ColumnName, 
				CAST('''' AS VARCHAR(50)) AS Source_Type, CAST(0 AS INT) AS Source_Length, CAST(0 AS INT) AS Source_Scale, 
				CAST('''' AS VARCHAR(50)) AS Dest_Type, CAST(0 AS INT) AS Dest_Length, CAST(0 AS INT) AS Dest_Scale 
			FROM ' + @_DBSource + 'Sys.Columns
			WHERE Object_ID = ' + CAST(Object_ID(@_TableSource) AS VARCHAR(50)) + ' AND Is_Identity <> 1 AND 
				Name IN (SELECT Name FROM ' + @_DBDest + 'Sys.Columns WHERE Object_ID = ' + CAST(Object_ID(@_TableDest) AS VARCHAR(50)) + ')'

--SELECT @_SQLExec

	INSERT INTO #T_ColumnCopy
		EXEC(@_SQLExec)

	--cập nhật thông tin các cột Source
	SET @_SQLExec = '
		UPDATE #T_ColumnCopy SET 
				Source_Type = Type_Name,
				Source_Length = Max_Length,
				Source_Scale = Scale
			FROM #T_ColumnCopy T1 JOIN 
				(SELECT	Name AS ColumnName, Type_Name(User_Type_Id) AS Type_Name, Max_Length, Scale
						FROM ' + @_DBSource + 'sys.columns
						WHERE Object_ID = Object_ID(''' + @_TableSource + ''') AND Name IN (SELECT Name FROM #T_ColumnCopy)) T2
				ON T1.ColumnName = T2.ColumnName'

--SELECT @_SQLExec
	EXEC(@_SQLExec) 

	--cập nhật thông tin các cột Dest
	SET @_SQLExec = '
		UPDATE #T_ColumnCopy SET 
				Dest_Type = Type_Name,
				Dest_Length = Max_Length,
				Dest_Scale = Scale
			FROM #T_ColumnCopy T1 JOIN 
				(SELECT	Name AS ColumnName, Type_Name(User_Type_Id) AS Type_Name, Max_Length, Scale
						FROM ' + @_DBDest + 'sys.columns
						WHERE Object_ID = Object_ID(''' + @_TableDest + ''') AND Name IN (SELECT Name FROM #T_ColumnCopy)) T2
				ON T1.ColumnName = T2.ColumnName'

--SELECT @_SQLExec
	EXEC(@_SQLExec) 

	--Tao danh sach @_ColumnList2 trong danh sach column truyen vao
--	IF (@ColumnList <> '')
--	BEGIN
--		SET @ColumnList = ',' + @ColumnList + ','
--
--		DECLARE C_ColumnCopy CURSOR FOR 
--			SELECT ColumnName FROM #T_ColumnCopy
--
--		OPEN C_ColumnCopy
--		
--		FETCH NEXT FROM C_ColumnCopy INTO @_ColumnName
--
--		WHILE @@FETCH_STATUS = 0
--		BEGIN
--
--			IF (CHARINDEX(',' + @_ColumnName + ',', @ColumnList) > 0)
--				SET @_ColumnList2 = @_ColumnList2 + @_ColumnName + ','
--			
--			FETCH NEXT FROM C_ColumnCopy INTO @_ColumnName
--		END
--
--	END 
--	ELSE
--	BEGIN
--		SET @_ColumnList2 = (SELECT ColumnName + ',' FROM #T_ColumnCopy FOR XML PATH(''))
--	END

	IF @ColumnList IS NULL
		SET @ColumnList = ''

	SET @ColumnList = ',' + @ColumnList + ','
	DECLARE C_ColumnCopy CURSOR FOR 
		SELECT ColumnName, Source_Type, Source_Length, Source_Scale, Dest_Type, Dest_Length, Dest_Scale 
			FROM #T_ColumnCopy

	OPEN C_ColumnCopy
	
	FETCH NEXT FROM C_ColumnCopy INTO @_ColumnName, @_Source_Type, @_Source_Length, @_Source_Scale, @_Dest_Type, @_Dest_Length, @_Dest_Scale

	WHILE @@FETCH_STATUS = 0
	BEGIN

		IF (@ColumnList = ',,' OR (@ColumnList <> ',,' AND CHARINDEX(',' + @_ColumnName + ',', @ColumnList) > 0))
		BEGIN
			SET @_ColumnList1 = @_ColumnList1 + @_ColumnName + ','

			IF (@_Source_Type = @_Dest_Type AND @_Source_Length = @_Dest_Length)
				SET @_ColumnList2 = @_ColumnList2 + @_ColumnName + ','
			ELSE
			BEGIN
				PRINT @_ColumnName
				--SELECT @_Dest_Type
				SET @_ColumnList2 = @_ColumnList2 + 
					CASE @_Dest_Type
						WHEN 'NUMERIC' THEN 
							'CAST(' + @_ColumnName + ' AS NUMERIC(28, 6)) AS ' + @_ColumnName + ','
						WHEN 'MONEY' THEN 
							'CAST(' + @_ColumnName + ' AS MONEY) AS ' + @_ColumnName + ','
						WHEN 'INT' THEN 
							'CAST(' + @_ColumnName + ' AS INT) AS ' + @_ColumnName + ','
						WHEN 'NVARCHAR' THEN 
							'CAST(' + @_ColumnName + ' AS NVARCHAR(' + CAST(@_Dest_Length AS VARCHAR(50)) + ')) AS ' + @_ColumnName + ','
						WHEN 'VARCHAR' THEN 
							'CAST(' + @_ColumnName + ' AS VARCHAR(' + CAST(@_Dest_Length AS VARCHAR(50)) + ')) AS ' + @_ColumnName + ','
						ELSE
							@_ColumnName + ','
					END
			END

		END

		FETCH NEXT FROM C_ColumnCopy INTO @_ColumnName, @_Source_Type, @_Source_Length, @_Source_Scale, @_Dest_Type, @_Dest_Length, @_Dest_Scale
	END

	IF (RIGHT(@_ColumnList1, 1) = ',')
		SET @_ColumnList1 = LEFT(@_ColumnList1, LEN(@_ColumnList1) - 1)

	IF (RIGHT(@_ColumnList2, 1) = ',')
		SET @_ColumnList2 = LEFT(@_ColumnList2, LEN(@_ColumnList2) - 1)

	--Bat dau Insert
	IF (@_ColumnList2 <> '')
	BEGIN

		EXECUTE Sp_DefaultTable @TableDest

		SET @_SQLExec = '
			INSERT INTO ' + @TableDest + ' (' + @_ColumnList1 + ') ' + '
				SELECT ' + @_ColumnList2 + ' 
				FROM ' + @TableSource + ' WITH (NOLOCK) '

		IF (@Key <> '')
			SET @_SQLExec = @_SQLExec + ' WHERE ' + @Key

		EXECUTE(@_SQLExec)

	END ELSE
		PRINT 'Khong copy duoc'

	DROP TABLE #T_ColumnCopy

END	
	


