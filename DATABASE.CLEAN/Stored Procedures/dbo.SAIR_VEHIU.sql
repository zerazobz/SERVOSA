
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIU]
(
	@Codigo int,
	@TYPE_cTABBRND nvarchar(4),
	@TYPE_cCODBRND nvarchar(4),
	@TYPE_cTABVSTA nvarchar(4),
	@TYPE_cCODVSTA nvarchar(4),
	@VEHI_UnitType	nvarchar(1),
	@VEHI_VehiclePlate	nvarchar(80),
	@VEHI_Company nvarchar(50)
)
AS
BEGIN
	update SAIR_VEHICLE
		set 
		TYPE_CTABBRND = @TYPE_CTABBRND,
		TYPE_CCODBRND = @TYPE_CCODBRND,
		TYPE_cTABVSTA = @TYPE_cTABVSTA,
		TYPE_cCODVSTA = @TYPE_cCODVSTA,
		VEHI_UnitType = @VEHI_UnitType,
		VEHI_VehiclePlate = @VEHI_VehiclePlate,
		VEHI_Company = @VEHI_Company
		where Codigo = @Codigo;
END
GO
