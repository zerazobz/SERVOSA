SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE FUNCTION [dbo].[SAIR_RemoveAccentsAndNormalizeTest]
(@textToReplace varChar(1000))
	RETURNS varChar(1000)
AS
BEGIN
	select @textToReplace = REPLACE(LTRIM(RTRIM(@textToReplace)), ' ', '') collate SQL_Latin1_General_Cp1251_CS_AS
	RETURN @textToReplace
END
GO
