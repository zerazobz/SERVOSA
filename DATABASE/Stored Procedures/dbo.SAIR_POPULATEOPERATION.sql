SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_POPULATEOPERATION]
	@operationName NVARCHAR(80)
AS
BEGIN
	DECLARE @sqlQuery NVARCHAR(MAX);
	SET @sqlQuery = '
	USE ' + @operationName + ';
	CREATE TABLE Testing
    (
        TestPk int,
        TestDescription nvarchar(80)
    );';
	PRINT @sqlQuery;
	EXEC sp_executesql @sqlQuery;
END
GO
