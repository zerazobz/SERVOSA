SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEALS_TodosNoEnviados]
AS
BEGIN 
	SELECT VEAL.VEAL_Id, VEAL.VEAL_TableName, VEAL.VEAL_DaysToAlert, VEAL.VEAL_DateToAlert, VEAL.VEAL_AlertName, VEAL.VEAL_AlertSended
	, VEAL.VEHI_ID FROM dbo.SAIR_VehicleAlerts VEAL
	WHERE VEAL.VEAL_AlertSended = 0;
END

GO
