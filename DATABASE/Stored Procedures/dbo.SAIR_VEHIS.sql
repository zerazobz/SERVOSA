SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_VEHIS]
	@prmStart int,
	@prmEnd int
AS
	DECLARE @totalRows int
BEGIN
	SELECT @totalRows = count(*) from SAIR_VEHICLE;

	select DATA.* from
	(
		select ROW_NUMBER() OVER(ORDER BY VEHI.Codigo) RowNumber, @totalRows AS TotalRows, VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHI.CodigoMarca, VEHI.CodigoEstado
		from SAIR_VEHICLE VEHI
	) DATA
	where DATA.RowNUmber >= @prmStart and DATA.RowNUmber <= @prmEnd;
END


GO
