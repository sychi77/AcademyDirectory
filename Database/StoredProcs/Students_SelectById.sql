CREATE PROCEDURE [dbo].[Students_SelectById]
	@Id int
AS
/*
DECLARE 
	@_id INT = 1;
EXECUTE Students_SelectById 
	@_id;
*/
BEGIN
	SELECT
		Id,
		FirstName,
		MiddleInitial,
		LastName,
		DateOfBirth,
		CreatedDate,
		ModifiedDate,
		ModifiedBy
	FROM
		Students
	WHERE
		Id = @Id;
END