SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SAIR_SELECTTABLES]
AS
BEGIN
    SELECT AOB.NAME AS TableNormalizedName, EPR.value AS TableName FROM sys.all_objects AOB
    LEFT JOIN sys.extended_properties EPR
    ON aob.object_id = EPR.major_id
    JOIN sys.schemas SCH
    ON AOB.schema_id = SCH.schema_id
    WHERE AOB.type = 'U' AND SCH.name = 'vehiclevars';
END
GO
