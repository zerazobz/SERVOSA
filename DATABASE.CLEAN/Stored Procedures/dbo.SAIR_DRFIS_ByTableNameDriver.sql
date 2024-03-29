SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRFIS_ByTableNameDriver]
    @VEHI_VEHIID int,
    @VEFI_TableName NVARCHAR(80)
AS
BEGIN
    SELECT VEFI.VEFI_Identity, VEFI.VEHI_VEHIID, VEFI.VEFI_TableName, VEFI.VEFI_DataFile
    , VEFI.VEFI_FileName, VEFI.VEFI_FileContentType, VEFI.VEFI_FileLocationStored
    , VEFI.VEFI_DateCreated
    FROM dbo.SAIR_DRIVERFILES VEFI
    WHERE VEFI.VEFI_TableName = @VEFI_TableName AND VEFI.VEHI_VEHIID = @VEHI_VEHIID;
END

GO
