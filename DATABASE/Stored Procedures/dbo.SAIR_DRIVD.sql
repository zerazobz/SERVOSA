SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRIVD]
(
    @Codigo int
)
AS
BEGIN
    delete from SAIR_DRIVER
        where Codigo = @Codigo;
END

GO
