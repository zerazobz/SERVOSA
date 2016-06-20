SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_ADDCOLUMNTABLE]
(
    @normalizedTableName nvarchar(200),
    @columnName nvarchar(200),
    @columnType nvarchar(50),
    @normalizedColumnName  nvarchar(200) output
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    set @normalizedColumnName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@columnName)
    SELECT @sql = 'alter table vehiclevars.' + QUOTENAME(@normalizedTableName) + ' add ' + QUOTENAME(@normalizedColumnName) + ' ' + @columnType
    PRINT @sql
    EXEC sp_executesql @sql

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @columnName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @normalizedTableName,
    @level2type = N'COLUMN',  @level2name = @normalizedColumnName;


END;
GO
