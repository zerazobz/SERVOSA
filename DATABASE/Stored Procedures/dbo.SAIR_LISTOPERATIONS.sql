SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_LISTOPERATIONS]
AS
BEGIN
	--SELECT name AS OperationName, database_id AS OperationId FROM sys.databases
	--WHERE name LIKE 'SAIR%'
	SELECT OPER_Id AS OperationId, OPER_Name AS OperationName, OPER_DBName AS DataBaseName, OPER_DBId AS DataBaseId
	FROM dbo.SAIR_OPERATIONS
END

GO