SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRALU]
	@VEAL_Id int,
	@VEAL_TokenSMS nvarchar(80),
	@VEAL_SendDate datetime,
	@VEAL_Recipients nvarchar(max)
AS
BEGIN
	UPDATE dbo.SAIR_DriverAlerts
	SET VEAL_AlertSended = 1,
	VEAL_TokenSMS = @VEAL_TokenSMS,
	VEAL_SendDate = @VEAL_SendDate,
	VEAL_Recipients = @VEAL_Recipients
	WHERE VEAL_Id = @VEAL_Id;
END



GO
