CREATE TABLE [dbo].[Tool]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [LocationId] INT NULL
)
