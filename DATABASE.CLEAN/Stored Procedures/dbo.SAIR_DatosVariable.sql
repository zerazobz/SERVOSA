SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DatosVariable]
    @variableName NVARCHAR(80)
AS
BEGIN
    DECLARE @selectSQL NVARCHAR(MAX);
    SET @selectSQL = 'SELECT VTBL.*
           , VEHI.VEHI_VehiclePlate, CASE WHEN VEHI.VEHI_UnitType = ''R'' THEN
                ''Remolque''
            WHEN VEHI.VEHI_UnitType = ''S'' THEN
                ''Semi-Remolque''
            ELSE
                NULL
            END VEHI_DescriptionUnitType,
            CASE WHEN DATEDIFF(dd, CTBL.FechaVencimiento, GETDATE()) > CTBL.DiasAlerta THEN
                ''GREEN''
            WHEN DATEDIFF(dd, CTBL.FechaVencimiento, GETDATE()) < CTBL.DiasAlerta THEN
                ''RED''
            END Flag
            FROM vehiclevars.' + @variableName + ' VTBL
            INNER JOIN dbo.SAIR_VEHICLE VEHI
            ON VEHI.Codigo = VTBL.SAIR_VEHIID
            LEFT JOIN vehicleconst.' + @variableName + ' CTBL
            ON VTBL.SAIR_VEHIID = CTBL.CSAIR_VEHIID
            ';

    PRINT @selectSQL
    EXECUTE sp_executesql @selectSQL
END
GO
