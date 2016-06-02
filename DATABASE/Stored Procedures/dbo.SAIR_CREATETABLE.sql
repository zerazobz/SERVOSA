
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_CREATETABLE]
(
    @newTableName NVARCHAR(200),
    @tableNormalizedName NVARCHAR(200) OUT,
    @objectId INT OUT
)
AS
BEGIN
    DECLARE @vehicleconstSQL NVARCHAR(MAX)
    DECLARE @vehiclevarsSQL NVARCHAR(MAX)
    SET @tableNormalizedName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@newTableName)
    SELECT @vehiclevarsSQL = 'create table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + '(id int identity(1,1), SAIR_VEHIID int not null )';
    PRINT @vehiclevarsSQL
    SELECT @vehicleconstSQL = 'create table [vehicleconst].' + QUOTENAME(@tableNormalizedName) + '(cid int identity(1, 1), CSAIR_VEHIID int not null, DiasAlerta int null, RutaDocumento nvarchar(800), FechaVencimiento DateTime)';

    PRINT @vehicleconstSQL

    EXEC sp_executesql @vehiclevarsSQL
    EXEC sp_executesql @vehicleconstSQL

    PRINT 'EL antiguo nombre es: ' + @newTableName

    EXEC sys.sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = @newTableName, 
    @level0type = N'SCHEMA', @level0name = 'vehiclevars', 
    @level1type = N'TABLE',  @level1name = @tableNormalizedName;

    declare @foreignKeyVehicleVarsSQL NVARCHAR(MAX)
    declare @foreignKeyVehicleConstSQL NVARCHAR(MAX)

    SELECT @foreignKeyVehicleVarsSQL = 'alter table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ' add constraint vehiclevar' + @tableNormalizedName
        + '_VEHI_FK foreign key (SAIR_VEHIID) REFERENCES dbo.SAIR_VEHICLE(Codigo)';
    
    SELECT @foreignKeyVehicleConstSQL = 'alter table [vehicleconst].' + QUOTENAME(@tableNormalizedName) + ' add constraint vehicleconst' + @tableNormalizedName
        + '_VEHI_FK foreign key (CSAIR_VEHIID) REFERENCES dbo.SAIR_VEHICLE(Codigo)';

    PRINT @foreignKeyVehicleVarsSQL;
    PRINT @foreignKeyVehicleConstSQL;
    
    EXEC sp_executesql @foreignKeyVehicleVarsSQL
    EXEC sp_executesql @foreignKeyVehicleConstSQL

    declare @primaryKeySQL NVARCHAR(MAX)

    SELECT @primaryKeySQL = 'alter table [vehiclevars].' + QUOTENAME(@tableNormalizedName) + ' add constraint vehiclevars' + @tableNormalizedName
        + 'PK primary key(SAIR_VEHIID)';
    PRINT @primaryKeySQL;
    EXEC sp_executesql @primaryKeySQL;

    SELECT @primaryKeySQL = 'alter table [vehicleconst].' + QUOTENAME(@tableNormalizedName) + ' add constraint vehicleconst' + @tableNormalizedName
        + 'PK primary key(CSAIR_VEHIID)';
    PRINT @primaryKeySQL;
    EXEC sp_executesql @primaryKeySQL;

    SET @objectId = OBJECT_ID('vehiclevars.' + @tableNormalizedName)
    PRINT 'El objecto ID de : ' + @tableNormalizedName + ' es: ' + CAST(@objectId as NVARCHAR(100))
END
GO
