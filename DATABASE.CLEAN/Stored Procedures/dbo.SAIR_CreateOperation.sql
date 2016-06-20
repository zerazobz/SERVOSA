SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_CreateOperation]
    @operationName NVARCHAR(40)
AS
BEGIN
	DECLARE @databaseName NVARCHAR(80) = 'SAIR_' + @operationName;
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
END
GO
