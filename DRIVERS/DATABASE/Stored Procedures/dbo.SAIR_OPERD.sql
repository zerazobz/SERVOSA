SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERD]
	@OPER_Id [int]
WITH EXECUTE AS CALLER
AS
BEGIN
	delete from SAIR_OPERARIOS
		where OPER_Id = @OPER_Id;
END

GO
