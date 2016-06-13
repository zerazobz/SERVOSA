SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_CreateOperation]
    @operationName NVARCHAR(40)
AS
BEGIN
    DECLARE @sqlCreation NVARCHAR(MAX);
    SET @sqlCreation = '
        USE MASTER;

        EXEC(''CREATE DATABASE ' + @operationName + ''');
		DECLARE @useDatabase NVARCHAR(80);
		SET @useDatabase = ''USE ' + @operationName + ' '';
    ';

    PRINT @sqlCreation;
    EXEC sp_executesql @sqlCreation;
END
GO
