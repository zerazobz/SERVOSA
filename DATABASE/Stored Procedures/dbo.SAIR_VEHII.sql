SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHII]
(
	@PlacaTracto nvarchar(60),
	@PlacaTolva nvarchar(60),
	@CodigoMarca int,
	@CodigoEstado int,
	@Codigo int out
)
AS
BEGIN
	insert into SAIR_VEHICLE
		(PlacaTracto, PlacaTolva, CodigoMarca, CodigoEstado)
		values
		(@PlacaTracto, @PlacaTolva, @CodigoMarca, @CodigoEstado);
		set @Codigo =  SCOPE_IDENTITY()
END
GO
