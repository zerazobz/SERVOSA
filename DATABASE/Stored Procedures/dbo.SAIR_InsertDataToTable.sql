SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_InsertDataToTable]
	@columnsDeclaration AS vehiclevars.ColumnList READONLY,
	@columnsValues AS vehiclevars.ValuesList READONLY,
	@tableName AS NVARCHAR(80)
AS
BEGIN
	DECLARE @columnsPrepared NVARCHAR(MAX);
	SELECT @columnsPrepared = COALESCE(@columnsPrepared + ',', '') + ColumnName
	FROM @columnsDeclaration;
	DECLARE @valuesPrepared NVARCHAR(MAX);
	SELECT @valuesPrepared = COALESCE(@valuesPrepared + ',', '') + ColumnValue FROM
	@columnsValues

	DECLARE @sqlQuery NVARCHAR(MAX);
	SELECT @sqlQuery = 'INSERT INTO [vehiclevars].' + QUOTENAME(@tableName) +
	'(' + @columnsPrepared + ') VALUES ('
	+ @valuesPrepared + ')';
	SELECT @sqlQuery;
	EXEC sp_executesql @sqlQuery;
END
GO
