
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_ADDCOLUMNTABLE]
(
    @tableName nvarchar(200),
    @columnName nvarchar(200),
    @columnType nvarchar(50)
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    SET @columnName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@columnName)
    SELECT @sql = 'alter table vehiclevars.' + QUOTENAME(@tableName) + ' add ' + QUOTENAME(@columnName) + ' ' + @columnType
    PRINT @sql
    EXEC sp_executesql @sql
END;

GO
