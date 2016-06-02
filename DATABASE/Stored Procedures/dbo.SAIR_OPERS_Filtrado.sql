
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS_Filtrado]
	@prmStart [int],
	@prmEnd [int]
WITH EXECUTE AS CALLER
AS
DECLARE @totalRows int
BEGIN
	SELECT @totalRows = count(*) from SAIR_OPERARIOS;

	select DATA.* from
	(
		select ROW_NUMBER() OVER(ORDER BY OPER.OPER_Id) RowNumber, @totalRows AS TotalRows,OPER.OPER_Id,
		OPER.OPER_cApellidoPaterno, OPER.OPER_cApellidoMaterno, OPER.OPER_cNombre
		, OPER.OPER_cCorreo,OPER.VEHI_Id, VEHI.VEHI_VehiclePlate + ' / ' + BRNDTY.TYPE_cDescription AS VEHI_cDescripcion
		, OPER.PUES_Id
		from SAIR_OPERARIOS OPER
		LEFT JOIN SAIR_VEHICLE VEHI
			ON OPER.VEHI_Id=VEHI.Codigo 
		LEFT JOIN dbo.SAIR_TYPES BRNDTY
			ON BRNDTY.TYPE_cCodTable = VEHI.TYPE_cTABBRND AND BRNDTY.TYPE_cCodType = VEHI.TYPE_cCODBRND
	) DATA
	where DATA.RowNUmber >= @prmStart and DATA.RowNUmber <= @prmEnd;
END

GO
