SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEFII]
	@VEHI_VEHIID int,
	@VEFI_TableName NVARCHAR(80),
	@VEFI_DataFile binary,
	@VEFI_FileName NVARCHAR(80),
	@VEFI_FileContentType NVARCHAR(40),
	@VEFI_FileLocationStored NVARCHAR(360),
	@VEFI_DateCreated datetime
AS
BEGIN
	INSERT INTO dbo.SAIR_VEHICLEFILES
	        ( VEHI_VEHIID ,
	          VEFI_TableName ,
	          VEFI_DataFile ,
	          VEFI_FileName ,
	          VEFI_FileContentType ,
	          VEFI_FileLocationStored ,
	          VEFI_DateCreated
	        )
	VALUES  ( @VEHI_VEHIID , -- VEHI_VEHIID - int
	          @VEFI_TableName , -- VEFI_TableName - nvarchar(80)
	          @VEFI_DataFile , -- VEFI_DataFile - binary
	          @VEFI_FileName , -- VEFI_FileName - nvarchar(80)
	          @VEFI_FileContentType , -- VEFI_FileContentType - nvarchar(40)
	          @VEFI_FileLocationStored , -- VEFI_FileLocationStored - nvarchar(360)
	          GETDATE()  -- VEFI_DateCreated - datetime
	        )
END

GO
