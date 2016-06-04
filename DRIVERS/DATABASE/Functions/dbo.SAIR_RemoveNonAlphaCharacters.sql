SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[SAIR_RemoveNonAlphaCharacters](@textToReplace VarChar(1000))
RETURNS VarChar(1000)
AS
BEGIN

    DECLARE @KeepValues as varchar(50)
    SET @KeepValues = '%[^a-zA-Z0-9]%'
    While PatIndex(@KeepValues, @textToReplace) > 0
        Set @textToReplace = Stuff(@textToReplace, PatIndex(@KeepValues, @textToReplace), 1, '')

    Return @textToReplace
END
GO
