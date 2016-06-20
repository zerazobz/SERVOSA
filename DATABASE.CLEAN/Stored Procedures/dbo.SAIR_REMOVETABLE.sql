SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_REMOVETABLE]
	@tableNormalizedName NVARCHAR(200),
	@typeEntity nvarchar(1)
AS
BEGIN
	DECLARE @removeFilesSQL NVARCHAR(MAX);
	DECLARE @removeTablesSQL NVARCHAR(MAX);

	IF @typeEntity = 'V'
	BEGIN
		SELECT @removeFilesSQL = 'DELETE FROM dbo.SAIR_VEHICLEFILES
					WHERE VEFI_TableName = ''' + @tableNormalizedName + '''';
		PRINT @removeFilesSQL
		--EXECUTE sp_executesql @removeFilesSQL;

	
		SELECT @removeTablesSQL = 'DROP TABLE [vehicleconst].' + QUOTENAME(@tableNormalizedName) + ';'
					+ ' DROP TABlE [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ';';
		PRINT @removeTablesSQL
		--EXECUTE sp_executesql @removeTablesSQL
	END
	ELSE
	BEGIN--[dbo].[SAIR_DRIVERFILES]
			SELECT @removeFilesSQL = 'DELETE FROM dbo.SAIR_DRIVERFILES
						WHERE VEFI_TableName = ''' + @tableNormalizedName + '''';
			PRINT @removeFilesSQL
			--EXECUTE sp_executesql @removeFilesSQL;

			SELECT @removeTablesSQL = 'DROP TABLE [driverconst].' + QUOTENAME(@tableNormalizedName) + ';'
						+ ' DROP TABlE [drivervars].' + QUOTENAME(@tableNormalizedName) + ';';
			PRINT @removeTablesSQL
			--EXECUTE sp_executesql @removeTablesSQL
	END
	EXECUTE sp_executesql @removeFilesSQL;
	EXECUTE sp_executesql @removeTablesSQL
END

GO
