SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEFID]
	@VEHI_VEHIID int,
	@VEFI_TableName nvarchar,
	@VEFI_FileName nvarchar
AS
BEGIN
	DELETE FROM dbo.SAIR_VEHICLEFILES
	WHERE VEHI_VEHIID = @VEHI_VEHIID AND VEFI_TableName = @VEFI_TableName
	AND VEFI_FileName = @VEFI_FileName;
END

GO