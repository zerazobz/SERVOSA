
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRIVIU]
(
    @Codigo int,
    @TYPE_cTABBRND nvarchar(4),
    @TYPE_cCODBRND nvarchar(4),
    @TYPE_cTABVSTA nvarchar(4),
    @TYPE_cCODVSTA nvarchar(4),
    @VEHI_UnitType  nvarchar(1),
    @VEHI_VehiclePlate  nvarchar(80),
    @DRIV_dBirthDate date,
    @DRIV_cAddress nvarchar(400),
    @DRIV_Company nvarchar(50)
)
AS
BEGIN
    update SAIR_DRIVER
        set 
        TYPE_CTABBRND = @TYPE_CTABBRND,
        TYPE_CCODBRND = @TYPE_CCODBRND,
        TYPE_cTABVSTA = @TYPE_cTABVSTA,
        TYPE_cCODVSTA = @TYPE_cCODVSTA,
        VEHI_UnitType = @VEHI_UnitType,
        VEHI_VehiclePlate = @VEHI_VehiclePlate,
        DRIV_dBirthDate = @DRIV_dBirthDate,
        DRIV_cAddress = @DRIV_cAddress,
        DRIV_Company = @DRIV_Company
        where Codigo = @Codigo;
END
GO
