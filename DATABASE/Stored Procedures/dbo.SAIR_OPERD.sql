SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_OPERD]
	@OPER_Id INT,
	@OPER_DBName NVARCHAR(80)
AS
BEGIN
	BEGIN TRANSACTION [DeleteOperation]
	BEGIN TRY
		DELETE FROM dbo.SAIR_OPERATIONS
		WHERE OPER_Id = @OPER_Id;
		COMMIT TRANSACTION [DeleteOperation];
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [DeleteOperation];
		THROW;
	END CATCH

	--IF @@TRANCOUNT > 0
	--BEGIN
		DECLARE @SQL varchar(max)
		SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
		FROM MASTER..SysProcesses
		WHERE DBId = DB_ID(@OPER_DBName) AND SPId <> @@SPId

		DECLARE @deleteSQL NVARCHAR(MAX) = 'DROP DATABASE ' + @OPER_DBName + ';';
		EXECUTE sp_executesql @deleteSQL;
	--END
END
GO