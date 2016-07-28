
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRIVS_Filtrado]
    @prmStart int,
    @prmEnd int
AS
    DECLARE @totalRows int
BEGIN
    SELECT @totalRows = count(*) from SAIR_DRIVER;

    select DATA.* from
    (
        select ROW_NUMBER() OVER(ORDER BY VEHI.Codigo) RowNumber, @totalRows AS TotalRows, VEHI.Item, VEHI.Codigo, VEHI.TYPE_cTABBRND
    , VEHI.TYPE_cCODBRND, VEHI.TYPE_cTABVSTA, VEHI.TYPE_cCODVSTA, VEHI.VEHI_UnitType, VEHI.VEHI_VehiclePlate
    , VEHI.DRIV_dBirthDate, VEHI.DRIV_cAddress, VEHI.DRIV_Company
        from SAIR_DRIVER VEHI
    ) DATA
    where DATA.RowNUmber >= @prmStart and DATA.RowNUmber <= @prmEnd;
END
GO
