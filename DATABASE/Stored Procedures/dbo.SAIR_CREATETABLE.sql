
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_CREATETABLE]
(
	@newTableName NVARCHAR(200),
	@tableNormalizedName NVARCHAR(200) OUT
)
AS
BEGIN
	DECLARE @sql NVARCHAR(MAX)
	SET @newTableName = dbo.SAIR_RemoveAccentsAndNormalizeTest(@newTableName)
	SET @tableNormalizedName = @newTableName
	--DECLARE @tableDesc NVARCHAR(50)
	SELECT @sql = 'create table ' + QUOTENAME(@newTableName) + '(id int identity(1,1) primary key )'
	PRINT @sql
	EXEC sp_executesql @sql
END
GO
