
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DatosVehiculo]
    @VEHI_Id int
AS
BEGIN
    DECLARE @sqlQuery NVARCHAR(MAX);
    SET @sqlQuery = 'SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = ''vehiclevars''';
    SELECT @sqlQuery = COALESCE(@sqlQuery + ' ', '') + 'SELECT ' + ' var' + TABLE_NAME + '.*,' + ' const' + TABLE_NAME + '.DiasAlerta, ' + ' const' + TABLE_NAME + '.FechaVencimiento, '
        + ' CASE WHEN DATEDIFF(dd, GETDATE(), const' + TABLE_NAME + '.FechaVencimiento) >  const' + TABLE_NAME + '.DiasAlerta THEN ' 
            + '''GREEN'' '
        + ' WHEN DATEDIFF(dd, GETDATE(), const' + TABLE_NAME + '.FechaVencimiento) < const' + TABLE_NAME + '.DiasAlerta THEN ' 
            + '''RED'' '
        + 'END Flag'

        + ' FROM ' + TABLE_SCHEMA + '.' + TABLE_NAME + ' var' + TABLE_NAME
        + ' LEFT JOIN vehicleconst.' + TABLE_NAME + ' const' + TABLE_NAME
            + ' ON ' + ' var' + TABLE_NAME +'.SAIR_VEHIID = ' + ' const' + TABLE_NAME + '.CSAIR_VEHIID'
        + ' WHERE ' + ' var' + TABLE_NAME +'.SAIR_VEHIID = ' + CAST(@VEHI_Id AS NVARCHAR(40)) + ';'
        FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'vehiclevars';
    PRINT @sqlQuery

    EXECUTE sp_executesql @sqlQuery
END
GO
