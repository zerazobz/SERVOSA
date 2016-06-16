
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_POPULATEOPERATION]
	@operationName NVARCHAR(80)
AS
BEGIN
DECLARE @dataBaseName NVARCHAR(80) = 'SAIR_' + @operationName;
	PRINT 'El nombre de la base de datos es: ' + @dataBaseName
	DECLARE @sqlQuery NVARCHAR(MAX);
	SET @sqlQuery = '
	USE ' + @dataBaseName + ';
	';
	PRINT @sqlQuery;
	EXEC sp_executesql @sqlQuery;
END
GO
