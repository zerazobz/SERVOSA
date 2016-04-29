SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS_UnReg]
	@Codigo INT
AS
BEGIN
	select VEHI.Item, VEHI.Codigo, VEHI.PlacaTracto, VEHI.PlacaTolva, VEHI.CodigoMarca, VEHI.CodigoEstado
	from SAIR_VEHICLE VEHI
	WHERE VEHI.Codigo = @Codigo;
END
GO
