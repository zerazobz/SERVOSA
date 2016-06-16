
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_CreateOperation]
    @operationName NVARCHAR(40),
	@operationNormalizedName NVARCHAR(40) OUTPUT,
	@databaseId int OUTPUT,
	@operationId INT OUTPUT
AS
BEGIN
	SET @operationNormalizedName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@operationName);
	DECLARE @databaseName NVARCHAR(80) = 'SAIR_' + @operationNormalizedName;
	SET @operationNormalizedName = @databaseName;
	PRINT 'The database name is: ' + @databaseName
    DECLARE @sqlCreation NVARCHAR(MAX);
    SET @sqlCreation = '
        USE MASTER;

        EXEC(''CREATE DATABASE ' + @databaseName + ''');
		DECLARE @useDatabase NVARCHAR(80);
		SET @useDatabase = ''USE ' + @databaseName + ' '';
    ';

    PRINT @sqlCreation;
    EXEC sp_executesql @sqlCreation;

	SET @databaseId = (SELECT database_id FROM sys.databases
	WHERE name = @databaseName);
	INSERT INTO dbo.SAIR_OPERATIONS
	(OPER_Name,OPER_DBName,OPER_DBId)
	VALUES
	(@operationName, @databaseName, @databaseId);
	SET @operationId = SCOPE_IDENTITY();
END
GO
