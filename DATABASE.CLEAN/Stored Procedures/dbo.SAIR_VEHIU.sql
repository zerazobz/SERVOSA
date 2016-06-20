SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIU]
(
	@Codigo int,
	-- @PlacaTracto nvarchar(60),
	-- @PlacaTolva nvarchar(60),
	@TYPE_cTABBRND nvarchar(4),
	@TYPE_cCODBRND nvarchar(4),
	-- @CodigoMarca int,
	-- @CodigoEstado int,
	@TYPE_cTABVSTA nvarchar(4),
	@TYPE_cCODVSTA nvarchar(4),
	@VEHI_UnitType	nvarchar(1),
	@VEHI_VehiclePlate	nvarchar(80)
)
AS
BEGIN
	update SAIR_VEHICLE
		set 
		TYPE_CTABBRND = @TYPE_CTABBRND,
		TYPE_CCODBRND = @TYPE_CCODBRND,
		-- CodigoMarca = @CodigoMarca,
		TYPE_cTABVSTA = @TYPE_cTABVSTA,
		TYPE_cCODVSTA = @TYPE_cCODVSTA,
		VEHI_UnitType = @VEHI_UnitType,
		VEHI_VehiclePlate = @VEHI_VehiclePlate
		where Codigo = @Codigo;
END
GO
