CREATE PROCEDURE [dbo].[Students_Insert]
	@FirstName NVARCHAR(50),
	@MiddleName NVARCHAR(10) = NULL,
	@LastName NVARCHAR(50),
	@DOB DATE,
	@ModifiedBy NVARCHAR(128),
	@Id INT OUTPUT
AS
/*
DECLARE 
	@_id INT,
	@_firstName NVARCHAR(50) = 'Test01',
	@_middleName NVARCHAR(50) = 'T',
	@_lastName NVARCHAR(50) = 'Test01',
	@_dob DATE = '01/01/2001',
	@_modifiedBy NVARCHAR(128) = 'User01';
EXECUTE [Students_Insert]
	@_id OUT, 
	@_firstName,
	@_middleName,
	@_lastName,
	@_dob,
	@_modifiedBy;
SELECT @_id;
SELECT * FROM Students
*/
BEGIN
	INSERT INTO Students (FirstName, MiddleInitial, LastName, DateOfBirth, ModifiedBy)
	VALUES (@FirstName, @MiddleName, @LastName, @DOB, @ModifiedBy);

	SET @Id = SCOPE_IDENTITY();
END