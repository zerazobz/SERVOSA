SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_DRIVS]
AS
BEGIN
    select VEHI.Item, VEHI.Codigo, VEHI.TYPE_cTABBRND, VEHI.TYPE_cCODBRND, VEHI.TYPE_cTABVSTA, VEHI.TYPE_cCODVSTA
        , BRND.TYPE_cDescription AS Marca, VSTA.TYPE_cDescription AS Estado
    , VEHI.VEHI_UnitType, VEHI.VEHI_VehiclePlate, CASE WHEN VEHI.VEHI_UnitType = 'R' THEN
            'Remolque'
        WHEN VEHI.VEHI_UnitType = 'S' THEN
            'Semi-Remolque'
        ELSE
            NULL
        END VEHI_DescriptionUnitType, VEHI.DRIV_dBirthDate, VEHI.DRIV_cAddress
    from SAIR_DRIVER VEHI
    LEFT JOIN SAIR_TYPES BRND
    ON VEHI.TYPE_cTABBRND = BRND.TYPE_cCodTable AND VEHI.TYPE_cCODBRND = BRND.TYPE_cCodType
    LEFT JOIN SAIR_TYPES VSTA
    ON VEHI.TYPE_cTABVSTA = VSTA.TYPE_cCodTable AND VEHI.TYPE_cCODVSTA = VSTA.TYPE_cCodType;
END



GO
