SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_LISTOPERATIONS]
AS
BEGIN
	SELECT name AS OperationName, database_id AS OperationId FROM sys.databases
	WHERE name LIKE 'SAIR%'
END

GO
