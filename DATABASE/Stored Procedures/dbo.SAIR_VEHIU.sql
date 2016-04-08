SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIU]
(
	@Codigo int,
	@PlacaTracto nvarchar(60),
	@PlacaTolva nvarchar(60),
	@CodigoMarca int,
	@CodigoEstado int
	
)
AS
BEGIN
	update SAIR_VEHICLE
		set PlacaTracto = @PlacaTracto,
		PlacaTolva = @PlacaTolva,
		CodigoMarca = @CodigoMarca,
		CodigoEstado = @CodigoEstado
		where Codigo = @Codigo;
END
GO
