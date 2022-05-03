CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TheNameOfTheOrganization] NVARCHAR(50) NULL, 
    [Warehouse1] NVARCHAR(50) NULL, 
    [Warehouse2] NVARCHAR(50) NULL, 
    [Warehouse3] NVARCHAR(50) NULL
)
