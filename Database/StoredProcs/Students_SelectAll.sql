CREATE PROCEDURE [dbo].[Students_SelectAll]
/*
	Execute dbo.Students_SelectAll
*/
AS
BEGIN
	SELECT
		[Id],
		[FirstName],
		[MiddleInitial],
		[LastName],
		[DateOfBirth],
		[CreatedDate],
		[ModifiedDate],
		[ModifiedBy]
	FROM 
		[dbo].Students
END