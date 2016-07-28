
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHII]
(
	@TYPE_cTABBRND nvarchar(4),
	@TYPE_cCODBRND nvarchar(4),
	@TYPE_cTABVSTA nvarchar(4),
	@TYPE_cCODVSTA nvarchar(4),
	@VEHI_UnitType nvarchar(1),
	@VEHI_VehiclePlate nvarchar(40),
	@VEHI_Company nvarchar(50),
	@Codigo int out
)
AS
BEGIN
	insert into SAIR_VEHICLE
		(TYPE_cTABBRND, TYPE_cCODBRND, TYPE_cTABVSTA, TYPE_cCODVSTA, VEHI_UnitType, VEHI_VehiclePlate, VEHI_Company)
		values
		(@TYPE_cTABBRND, @TYPE_cCODBRND, @TYPE_cTABVSTA, @TYPE_cCODVSTA, @VEHI_UnitType, @VEHI_VehiclePlate, @VEHI_Company);
		set @Codigo =  SCOPE_IDENTITY()
END
GO
