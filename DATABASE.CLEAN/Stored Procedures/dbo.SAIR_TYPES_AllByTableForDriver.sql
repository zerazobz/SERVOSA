SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_TYPES_AllByTableForDriver]
	@TYPE_cCodTable NVARCHAR(4)
AS
BEGIN
	SELECT STYP.TYPE_cCodTable + '|@|' + STYP.TYPE_cCodType AS TYPE_CodeConcatenated
		, STYP.TYPE_cCodTable
		, STYP.TYPE_cCodType
		, STYP.TYPE_cDescription
		, STYP.TYPE_cNotes
		FROM dbo.SAIR_TYPES STYP
		WHERE STYP.TYPE_cCodTable = @TYPE_cCodTable;
END



GO
