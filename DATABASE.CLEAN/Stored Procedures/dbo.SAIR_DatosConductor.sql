SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DatosConductor]
    @VEHI_Id int
AS
BEGIN
    DECLARE @sqlQuery NVARCHAR(MAX);
    SELECT @sqlQuery = COALESCE(@sqlQuery + ' ', '') + 'SELECT ' + ' var' + TABLE_NAME + '.*,' + ' const' + TABLE_NAME + '.DiasAlerta, ' + ' const' + TABLE_NAME + '.FechaVencimiento, '
        + ' CASE WHEN DATEDIFF(dd, const' + TABLE_NAME + '.FechaVencimiento, GETDATE()) >  const' + TABLE_NAME + '.DiasAlerta THEN ' 
            + '''GREEN'' '
        + ' WHEN DATEDIFF(dd, const' + TABLE_NAME + '.FechaVencimiento, GETDATE()) < const' + TABLE_NAME + '.DiasAlerta THEN ' 
            + '''RED'' '
        + 'END Flag'

        + ' FROM ' + TABLE_SCHEMA + '.' + TABLE_NAME + ' var' + TABLE_NAME
        + ' LEFT JOIN driverconst.' + TABLE_NAME + ' const' + TABLE_NAME
            + ' ON ' + ' var' + TABLE_NAME +'.SAIR_VEHIID = ' + ' const' + TABLE_NAME + '.CSAIR_VEHIID'
        + ' WHERE ' + ' var' + TABLE_NAME +'.SAIR_VEHIID = ' + CAST(@VEHI_Id AS NVARCHAR(40)) + ';'
        FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'drivervars';
    PRINT @sqlQuery

    EXECUTE sp_executesql @sqlQuery
END


GO
