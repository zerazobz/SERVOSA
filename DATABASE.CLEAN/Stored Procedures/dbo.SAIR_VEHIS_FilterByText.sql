
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS_FilterByText]
	@termToSearch NVARCHAR(200)
AS
BEGIN
	SELECT VEHI.Item ,
       VEHI.Codigo ,
       VEHI.TYPE_cTABBRND ,
       VEHI.TYPE_cCODBRND ,
       VEHI.TYPE_cTABVSTA ,
       VEHI.TYPE_cCODVSTA ,
       VEHI.VEHI_UnitType ,
       VEHI.VEHI_VehiclePlate
	   , TBRN.TYPE_cDescription AS VEHI_DescriptionUnitType
	   FROM dbo.SAIR_VEHICLE VEHI
	   LEFT JOIN dbo.SAIR_TYPES TBRN
	   ON TBRN.TYPE_cCodTable = VEHI.TYPE_cTABBRND AND TBRN.TYPE_cCodType = VEHI.TYPE_cCODBRND
	   WHERE VEHI.VEHI_VehiclePlate LIKE '%' + @termToSearch +'%'
	   OR TBRN.TYPE_cDescription LIKE '%' + @termToSearch +'%'
END
GO
