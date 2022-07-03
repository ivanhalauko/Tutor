CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NameOfLocation] NVARCHAR(50) NULL, 
    [WarehouseId] INT NULL, 
)
