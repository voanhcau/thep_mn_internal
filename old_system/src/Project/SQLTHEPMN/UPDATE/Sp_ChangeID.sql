USE R50THEPMN3
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO


--Sp_ChangeID 'MA_HD', 'REG', '11/22/NB/REG/GC'
ALTER PROCEDURE [dbo].[Sp_ChangeID]
(
	@Column_Type VARCHAR(50), 
	@OldValue VARCHAR(50), 
	@NewValue VARCHAR(50)
)
WITH ENCRYPTION
AS
BEGIN

	IF (@OldValue = @NewValue OR @OldValue = '' OR @NewValue = '')
		RETURN

	DECLARE @_SQLExec VARCHAR(1000),
			@_Table_Name VARCHAR(50),
			@_Column_ID VARCHAR(50),
			@_iColumn_Type INT
	
	SELECT @_Table_Name = Table_Name FROM R00ChangeID WHERE Column_Type = @Column_Type	

	DECLARE C_ChangeID CURSOR FOR
		SELECT Object_Name(Object_ID) AS Table_Name, Name AS Column_ID
			FROM sys.Columns 
			WHERE Object_ID IN (SELECT Object_ID FROM sys.Tables WHERE Type = 'U' AND name BETWEEN 'R00' AND 'R99' AND (name NOT LIKE '%BACKUP%' AND Name NOT LIKE '%BARCODE%' AND Name NOT LIKE '%PHOI%' AND Name NOT LIKE '%SCALE%' AND Name NOT LIKE '%DINHMUC%' AND Name NOT LIKE '%BUDGET%')) AND 
					((Name LIKE @Column_Type + '%' AND Object_ID <> Object_ID(@_Table_Name)) OR 
						(Name LIKE @Column_Type + '%' AND Object_ID = Object_ID(@_Table_Name) AND Name <> @Column_Type)) AND 
					user_type_id <> 104 AND 
					User_Type_ID IN (167, 231) --varchar, nvarchar

	OPEN C_ChangeID

	FETCH NEXT FROM C_ChangeID
		INTO @_Table_Name, @_Column_ID

	BEGIN TRANSACTION
	
	BEGIN TRY

		WHILE @@FETCH_STATUS = 0
		BEGIN

			IF (COL_LENGTH(@_Table_Name, @_Column_ID) IS NULL) 
			BEGIN

				FETCH NEXT FROM C_ChangeID
					INTO @_Table_Name, @_Column_ID
				
				CONTINUE
			END

			SET @_SQLExec = '
				UPDATE ' + @_Table_Name + ' 
					SET ' + @_Column_ID +  ' = ''' + @NewValue + '''' + '
					WHERE ' + @_Column_ID + ' = ''' + @OldValue + ''''

			PRINT @_SQLExec
			EXECUTE (@_SQLExec)

			FETCH NEXT FROM C_ChangeID
				INTO @_Table_Name, @_Column_ID
		END

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000),
				@ErrorSeverity INT,
				@ErrorState INT

		SELECT	@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();
	    
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH

	CLOSE C_ChangeID
	DEALLOCATE C_ChangeID

END



GO
