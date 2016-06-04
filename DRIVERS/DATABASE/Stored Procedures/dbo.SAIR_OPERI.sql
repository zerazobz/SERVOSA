
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO






CREATE PROCEDURE [dbo].[SAIR_OPERI]
 @OPER_cApellidoPaterno [nvarchar](40),
 @OPER_cApellidoMaterno [nvarchar](40),
 @OPER_cNombre [nvarchar](40),
 @OPER_cCorreo [nvarchar](60),
 @VEHI_Id [int],
 @PUES_Id [int],
 @OPER_Id [int] OUTPUT
WITH EXECUTE AS CALLER
AS
BEGIN
 insert into SAIR_OPERARIOS
  (OPER_cApellidoPaterno, OPER_cApellidoMaterno, OPER_cNombre, OPER_cCorreo,VEHI_Id,PUES_Id)
  values
  (@OPER_cApellidoPaterno, @OPER_cApellidoMaterno, @OPER_cNombre, @OPER_cCorreo,@VEHI_Id,@PUES_Id);
  set @OPER_Id =  SCOPE_IDENTITY()
END

GO
