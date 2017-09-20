CREATE PROCEDURE [dbo].[Students_Update]
	@Id int,
	@FirstName NVARCHAR(50),
	@MiddleInitial NVARCHAR(10) = NULL,
	@LastName NVARCHAR(50),
	@DOB DATE,
	@ModifiedBy NVARCHAR(128)
AS
/*
DECLARE 
	@_id INT = 3,
	@_firstName NVARCHAR(50) = 'TestUpdate01',
	@_middleInitial NVARCHAR(50) = 'U',
	@_lastName NVARCHAR(50) = 'TestUpdate01',
	@_dob DATE = '02-02-2002',
	@_modifiedBy NVARCHAR(128) = 'modByUser02';
SELECT * FROM Students;
EXECUTE Students_Update 
	@_id, 
	@_firstName,
	@_middleInitial,
	@_lastName,
	@_dob,
	@_modifiedBy;
SELECT * FROM Students;
*/
BEGIN
	DECLARE @modifiedDate DATETIME = GETUTCDATE();
	UPDATE Students
	SET FirstName = @FirstName,
		MiddleInitial = @MiddleInitial,
		LastName = @LastName,
		DateOfBirth = @DOB,
		ModifiedDate = @modifiedDate,
		ModifiedBy = @ModifiedBy
	WHERE Id = @Id;
END