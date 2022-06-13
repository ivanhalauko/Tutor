CREATE TABLE [dbo].[Worker]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Surname] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(50) NULL, 
    [SecondName] NVARCHAR(50) NULL, 
    [PositionId] INT NULL, 
    )
