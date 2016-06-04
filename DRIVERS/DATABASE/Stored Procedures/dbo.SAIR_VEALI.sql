SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEALI]
	@VEAL_TableName nvarchar(80),
	@VEAL_DaysToAlert int,
	@VEAL_DateToAlert datetime,
	@VEAL_AlertName nvarchar(80),
	@VEAL_AlertSended bit,
	@VEHI_ID int
AS
BEGIN
	INSERT INTO dbo.SAIR_VehicleAlerts
	        ( VEAL_TableName ,
	          VEAL_DaysToAlert ,
	          VEAL_DateToAlert ,
	          VEAL_AlertName ,
	          VEAL_AlertSended,
			  VEHI_ID
	        )
	VALUES  ( @VEAL_TableName , -- VEAL_TableName - nvarchar(80)
	          @VEAL_DaysToAlert , -- VEAL_DaysToAlert - int
	          @VEAL_DateToAlert , -- VEAL_DateToAlert - datetime
	          @VEAL_AlertName , -- VEAL_AlertName - nvarchar(80)
	          0,  -- VEAL_AlertSended - bit
			  @VEHI_ID
	        );
END
GO
