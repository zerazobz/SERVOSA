
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRIVI]
(
    @TYPE_cTABBRND nvarchar(4),
    @TYPE_cCODBRND nvarchar(4),
    @TYPE_cTABVSTA nvarchar(4),
    @TYPE_cCODVSTA nvarchar(4),
    @VEHI_UnitType nvarchar(1),
    @VEHI_VehiclePlate nvarchar(40),
    @DRIV_dBirthDate date,
    @DRIV_cAddress nvarchar(400),
    @DRIV_Company nvarchar(50),
    @Codigo int out
)
AS
BEGIN
    insert into SAIR_DRIVER
        (TYPE_cTABBRND, TYPE_cCODBRND, TYPE_cTABVSTA, TYPE_cCODVSTA, VEHI_UnitType, VEHI_VehiclePlate, DRIV_dBirthDate, DRIV_cAddress, DRIV_Company)
        values
        (@TYPE_cTABBRND, @TYPE_cCODBRND, @TYPE_cTABVSTA, @TYPE_cCODVSTA, @VEHI_UnitType, @VEHI_VehiclePlate, @DRIV_dBirthDate, @DRIV_cAddress, @DRIV_Company);
        set @Codigo =  SCOPE_IDENTITY()
END
GO
