SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DriverInsertVariableDataToTable]
    @columnsDeclaration AS drivervars.ColumnList READONLY,
    @columnsValues AS drivervars.ValuesList READONLY,
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
    SELECT @sqlQuery = 'INSERT INTO [drivervars].' + QUOTENAME(@tableName) +
    '(' + @columnsPrepared + ') VALUES ('
    + @valuesPrepared + ')';
    SELECT @sqlQuery;
    EXEC sp_executesql @sqlQuery;
END


GO
