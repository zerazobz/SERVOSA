
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
    SELECT @sql = 'create table vehiclevars.' + QUOTENAME(@tableNormalizedName) + '(id int identity(1,1), SAIR_VEHIID int not null, DiasAlerta int null, RutaDocumento nvarchar(800))'
    PRINT @sql

    EXEC sp_executesql @sql

    PRINT 'EL antiguo nombre es: ' + @newTableName

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @newTableName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @tableNormalizedName;

    declare @foreignKeySQL NVARCHAR(MAX)

    SELECT @foreignKeySQL = 'alter table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ' add constraint ' + @tableNormalizedName
        + '_VEHI_FK foreign key (SAIR_VEHIID) REFERENCES dbo.SAIR_VEHICLE(Codigo)';
    PRINT @foreignKeySQL;
    EXEC sp_executesql @foreignKeySQL

    declare @primaryKeySQL NVARCHAR(MAX)

    SELECT @primaryKeySQL = 'alter table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ' add constraint ' + @tableNormalizedName
        + 'PK primary key(SAIR_VEHIID)';
    PRINT @primaryKeySQL;

    EXEC sp_executesql @primaryKeySQL;

END
GO
