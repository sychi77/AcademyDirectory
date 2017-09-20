CREATE PROCEDURE [dbo].[Students_Delete]
	@Id int
AS
/*
DECLARE 
	@_id INT = 1;
SELECT * FROM Students;
EXECUTE Students_Delete
	@_id;
SELECT * FROM Students;
*/
BEGIN
	DELETE Students WHERE Id = @Id;
END