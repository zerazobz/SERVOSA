SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[tmp_DoSomethingWithEmployees]
  @List AS dbo.tmp_EmployeeList READONLY
AS
BEGIN
  SET NOCOUNT ON;
  SELECT EmployeeID FROM @List; 
END
GO
