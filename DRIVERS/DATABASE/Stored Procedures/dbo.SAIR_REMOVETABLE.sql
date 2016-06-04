SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_REMOVETABLE]
	@tableNormalizedName NVARCHAR(200)
AS
BEGIN
	DECLARE @removeFilesSQL NVARCHAR(MAX)
	SELECT @removeFilesSQL = 'DELETE FROM dbo.SAIR_VEHICLEFILES
				WHERE VEFI_TableName = ''' + @tableNormalizedName + '''';
	PRINT @removeFilesSQL
	EXECUTE sp_executesql @removeFilesSQL;

	DECLARE @removeTablesSQL NVARCHAR(200)
	SELECT @removeTablesSQL = 'DROP TABLE [vehicleconst].' + QUOTENAME(@tableNormalizedName) + ';'
				+ ' DROP TABlE [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ';';
	PRINT @removeTablesSQL
	EXECUTE sp_executesql @removeTablesSQL
END
GO
