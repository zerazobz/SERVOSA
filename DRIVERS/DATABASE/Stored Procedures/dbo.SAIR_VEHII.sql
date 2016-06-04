
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHII]
(
	-- @PlacaTracto nvarchar(60),
	-- @PlacaTolva nvarchar(60),
	@TYPE_cTABBRND nvarchar(4),
	@TYPE_cCODBRND nvarchar(4),
	@TYPE_cTABVSTA nvarchar(4),
	@TYPE_cCODVSTA nvarchar(4),
	@VEHI_UnitType nvarchar(1),
	@VEHI_VehiclePlate nvarchar(40),
	@Codigo int out
)
AS
BEGIN
	insert into SAIR_VEHICLE
		(TYPE_cTABBRND, TYPE_cCODBRND, TYPE_cTABVSTA, TYPE_cCODVSTA, VEHI_UnitType, VEHI_VehiclePlate)
		values
		(@TYPE_cTABBRND, @TYPE_cCODBRND, @TYPE_cTABVSTA, @TYPE_cCODVSTA, @VEHI_UnitType, @VEHI_VehiclePlate);
		set @Codigo =  SCOPE_IDENTITY()
END
GO
