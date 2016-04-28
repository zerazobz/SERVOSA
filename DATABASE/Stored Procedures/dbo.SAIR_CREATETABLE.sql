
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_CREATETABLE]
(
    @newTableName NVARCHAR(200),
    @tableNormalizedName NVARCHAR(200) OUT
)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @tableNormalizedName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@newTableName)
    --SET @tableNormalizedName = @newTableName
    --DECLARE @tableDesc NVARCHAR(50)
    SELECT @sql = 'create table vehiclevars.' + QUOTENAME(@tableNormalizedName) + '(id int identity(1,1) primary key )'
    PRINT @sql

    EXEC sp_executesql @sql

	PRINT 'EL antiguo nombre es: ' + @newTableName

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @newTableName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @tableNormalizedName;
END
GO
