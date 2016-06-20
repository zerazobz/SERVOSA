SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_DRIVLISTTABLESANDCOLUMNS]
    @schemaName nvarchar(40)
AS
BEGIN
    SELECT TAB.object_id TableObjectId, TAB.name TableNormalizedName, EPT.value TableName, TAB.schema_id SchemaId, SCH.name SchemaName
    , COL.name ColumnNormalizedName, EPC.value ColumnName , COL.user_type_id UserType , COL.system_type_id SystemType, TYP.name TypeName
    FROM sys.tables TAB
    LEFT JOIN sys.schemas SCH
    ON TAB.schema_id = SCH.schema_id
    LEFT JOIN sys.extended_properties EPT
    ON TAB.object_id = EPT.major_id AND EPT.minor_id = 0
    LEFT JOIN sys.columns COL
    ON TAB.object_id = COl.object_id
    LEFT JOIN sys.extended_properties EPC
    ON COl.object_id = EPC.major_id AND col.column_id = EPC.minor_id
    LEFT JOIN sys.types TYP
    ON TYP.system_type_id = COL.system_type_id AND TYP.user_type_id = COL.user_type_id
    WHERE SCH.name = @schemaName;
END


GO
