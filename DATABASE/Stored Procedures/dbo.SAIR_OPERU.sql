SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERU]
	@OPER_Id [int],
	@OPER_cApellidoPaterno [nvarchar](40),
	@OPER_cApellidoMaterno [nvarchar](40),
	@OPER_cNombre [nvarchar](40),
	@OPER_cCorreo [nvarchar](60),
	@VEHI_Id [int],
	@PUES_Id [int]
WITH EXECUTE AS CALLER
AS
BEGIN
	update SAIR_OPERARIOS
		set OPER_cApellidoPaterno = @OPER_cApellidoPaterno,
		OPER_cApellidoMaterno = @OPER_cApellidoMaterno,
		OPER_cNombre= @OPER_cNombre,
		OPER_cCorreo = @OPER_cCorreo,
		VEHI_Id=@VEHI_Id,
		PUES_Id=@PUES_Id
		where OPER_Id= @OPER_Id;
END

GO
