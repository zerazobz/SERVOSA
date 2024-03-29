SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_DRIVS_Datos]
    @tableName nvarchar(60)
AS
BEGIN
   declare @sqlSelectTableData nvarchar(max);

   select @sqlSelectTableData = 'SELECT ''' + @tableName + ''' AS TableName, VEHI.Codigo VehicleCode, VEDA.*, VECONST.DiasAlerta, VECONST.RutaDocumento, VECONST.FechaVencimiento '
      + ' FROM [dbo].[SAIR_DRIVER] VEHI '
      + ' LEFT JOIN [drivervars].' + QUOTENAME(@tableName)
      + ' VEDA  ON VEHI.Codigo = VEDA.SAIR_VEHIID '
      + ' LEFT JOIN [driverconst].' + QUOTENAME(@tableName)
      + ' VECONST ON VEHI.Codigo = VECONST.CSAIR_VEHIID'
    
    print @sqlSelectTableData

    exec sp_executesql @sqlSelectTableData
END


GO
