SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DriverUpdateConstantDataToTable]
    @columnsDictionaryDeclarationAndValue AS drivervars.ColumnValueDictionary READONLY,
    @tableName AS NVARCHAR(80),
    @vehicleId AS INT
AS
BEGIN
    DECLARE @cursorColumnAndValues CURSOR;
    DECLARE @updateSQL NVARCHAR(MAX);

    DECLARE @iColumnName NVARCHAR(80),
        @iColumnValue NVARCHAR(80);

    SET @updateSQL = 'UPDATE [driverconst].' + QUOTENAME(@tableName) + ' SET ';

    SET @cursorColumnAndValues = CURSOR FOR
        SELECT ColumnaName, ColumnValue FROM
            @columnsDictionaryDeclarationAndValue;

    OPEN @cursorColumnAndValues
        FETCH NEXT FROM @cursorColumnAndValues
        INTO @iColumnName, @iColumnValue

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @updateSQL += @iColumnName + ' = ' + @iColumnValue + ', '

        FETCH NEXT FROM @cursorColumnAndValues
            INTO @iColumnName, @iColumnValue
    END

    SET @updateSQL = SUBSTRING(@updateSQL, 1, LEN(@updateSQL) - 1)
    SET @updateSQL += ' WHERE CSAIR_VEHIID = ' + CAST(@vehicleId AS NVARCHAR(20)) + ';'

    PRINT @updateSQL
    EXEC sp_executesql @updateSQL;
END


GO
