SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERS_Datos]
	@tableName [nvarchar](60)
WITH EXECUTE AS CALLER
AS
BEGIN
   declare @sqlSelectTableData nvarchar(max);

   select @sqlSelectTableData = 'SELECT ''' + @tableName + ''' AS TableName, OPER.OPER_Id DriverCode, OPER.* FROM [dbo].[SAIR_OPERARIOS] OPER LEFT JOIN [vehiclevars].' + QUOTENAME(@tableName) 
    + ' VEDA  ON OPER.OPER_Id = VEDA.SAIR_VEHIID '
    
    print @sqlSelectTableData

    exec sp_executesql @sqlSelectTableData
END


GO
