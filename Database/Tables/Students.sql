﻿CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleInitial] NCHAR(10) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT getutcdate(), 
    [ModifiedDate] DATETIME NOT NULL DEFAULT getutcdate(), 
    [ModifiedBy] NVARCHAR(128) NOT NULL
)
