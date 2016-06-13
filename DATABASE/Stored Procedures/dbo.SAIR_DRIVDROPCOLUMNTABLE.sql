SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRIVDROPCOLUMNTABLE]
(
    @tableName nvarchar(200),
    @columnName nvarchar(200)
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    -- SET @columnName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@columnName)
    SELECT @sql = 'alter table drivervars.' + QUOTENAME(@tableName) + ' drop COLUMN' + QUOTENAME(@columnName) + ' '
    PRINT @sql
    EXEC sp_executesql @sql
END;

GO
