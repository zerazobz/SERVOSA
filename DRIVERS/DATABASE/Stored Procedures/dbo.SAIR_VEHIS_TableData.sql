
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_VEHIS_TableData]
    @tableName nvarchar(80),
    @vehicleId int
AS
BEGIN
    DECLARE @columnsTable NVARCHAR(MAX) = STUFF
    (
        (SELECT ', CAST(' +   QUOTENAME(name) + ' AS NVARCHAR(80)) AS ' + name 
            FROM sys.columns
            WHERE objecT_id IN (OBJECT_ID('vehiclevars.' + @tableName), OBJECT_ID('vehicleconst.' + @tableName))
            FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)'), 1, 1, ''
    )
    , @listColumns NVARCHAR(MAX) = STUFF
    (
        (SELECT ',' +   QUOTENAME(name)
            FROM sys.columns
            WHERE objecT_id IN (OBJECT_ID('vehiclevars.' + @tableName), OBJECT_ID('vehicleconst.' + @tableName))
            FOR XML PATH(''), TYPE).value('.', 'VARCHAR(MAX)') , 1, 1, ''
    )
    , @tableDataSQL NVARCHAR(MAX);

    SET @tableDataSQL = 'SELECT  TAB.name TableName,
                TAB.object_id ObjectId,
                COL.name ColumnName,
                COL.column_id ColumnId,
                U.ColumnValue TableValue,
                T.name ColumnType
        FROM sys.tables TAB
        INNER JOIN SYS.columns COL
            ON TAB.object_id = COL.object_id
        INNER JOIN sys.types T
            ON T.user_type_id = COL.system_type_id 
        LEFT JOIN
        (
            SELECT ColumnName, ColumnValue
            FROM ( SELECT ' + @columnsTable + ' FROM vehiclevars.' + @tableName + ' V JOIN vehicleconst.' + @tableName + ' C ON V.SAIR_VEHIID = C.CSAIR_VEHIID where SAIR_VEHIID = ' + CAST(@vehicleId AS NVARCHAR(60)) + ' ) AS P
            UNPIVOT
            ( ColumnValue FOR ColumnName IN (' + @listColumns + ' )
            ) as unpvt
        ) as U
        ON U.ColumnName = COL.name
        WHERE TAB.name = '''+ @tableName + '''';

    PRINT @tableDataSQL

    EXEC sp_executesql @tableDataSQL
END
GO
