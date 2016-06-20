SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_RENAMETABLENAME]
	@schemaName NVARCHAR(20),
	@tableName NVARCHAR(80),
	@MS_DescriptionValue NVARCHAR(80)
AS
BEGIN
	DECLARE @sentenceSQL NVARCHAR(MAX);
	DECLARE @composedTableName NVARCHAR(80);
	SET @composedTableName = @schemaName + '.' + @tableName;
	PRINT 'The composed name is: ' + @composedTableName

	DECLARE @MS_Description NVARCHAR(200);
	SET @MS_Description = NULL;

	SET @MS_Description = (SELECT CAST(Value AS NVARCHAR(200)) AS [MS_Description]
	FROM sys.extended_properties AS ep
	WHERE ep.major_id = OBJECT_ID(@composedTableName)
	AND ep.name = N'MS_Description' AND ep.minor_id = 0);

	IF @MS_Description IS NULL
    BEGIN
		PRINT 'Agregando la Propiedad';
		SET @sentenceSQL = 'EXEC sys.sp_addextendedproperty 
         @name  = N''MS_Description'', 
         @value = ''' + @MS_DescriptionValue + ''',
         @level0type = N''SCHEMA'',
         @level0name = ''' +@schemaName + ''', 
         @level1type = N''TABLE'',
         @level1name = ''' + @tableName + ''';';
    END
	ELSE
    BEGIN
		PRINT 'Actualizando la Propiedad';
		SET @sentenceSQL = 'EXEC sys.sp_updateextendedproperty 
         @name  = N''MS_Description'', 
         @value = ''' + @MS_DescriptionValue + ''',
         @level0type = N''SCHEMA'',
         @level0name = ''' + @schemaName + ''',
         @level1type = N''TABLE'',
         @level1name = ''' + @tableName + ''';';
    END
	PRINT @sentenceSQL;
	EXEC sp_executesql @sentenceSQL;
END

GO
