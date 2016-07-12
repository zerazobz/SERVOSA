
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_VEHIS_Datos]
    @tableName nvarchar(60)
AS
BEGIN
  --DECLARE @tableName nvarchar(60) = 'LasBambasSoat'
   DECLARE @sqlSelectTableData nvarchar(max);
   DECLARE @columnsQuery NVARCHAR(MAX);
  SELECT @columnsQuery = COALESCE(@columnsQuery + ', ', ' ') + '''' + COLUMN_NAME +'|@|'' + ISNULL(CAST(VEDA.' + COLUMN_NAME + ' AS NVARCHAR(80)), '''') AS ''' + COLUMN_NAME + '''' FROM INFORMATION_SCHEMA.COLUMNS
  WHERE TABLE_NAME = @tableName AND TABLE_SCHEMA = 'vehiclevars';
  --SELECT @columnsQuery

   select @sqlSelectTableData = 'SELECT ''' + @tableName + ''' AS TableName, VEHI.Codigo VehicleCode, ' + @columnsQuery + ', ''DiasAlerta|@|'' + CAST(VECONST.DiasAlerta AS NVARCHAR(40)) AS DiasAlerta , ''RutaDocumento|@|'' + CAST(VECONST.RutaDocumento AS 
        NVARCHAR(40)) AS RutaDocumento, ''FechaVencimiento|@|'' + ISNULL(CAST(VECONST.FechaVencimiento AS NVARCHAR(40)), '''') AS FechaVencimiento '
      + ' FROM [dbo].[SAIR_VEHICLE] VEHI '
      + ' LEFT JOIN [vehiclevars].' + QUOTENAME(@tableName)
      + ' VEDA  ON VEHI.Codigo = VEDA.SAIR_VEHIID '
      + ' LEFT JOIN [vehicleconst].' + QUOTENAME(@tableName)
      + ' VECONST ON VEHI.Codigo = VECONST.CSAIR_VEHIID'
    
    print @sqlSelectTableData

    exec sp_executesql @sqlSelectTableData
END
GO
