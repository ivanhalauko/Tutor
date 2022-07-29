CREATE TABLE [dbo].[Tool]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    [LocationId] INT NULL, 
    [StatusId] INT NULL, 
    [AspNetUsersId] NVARCHAR(450) NULL, 
    [PosterImageUrl] NVARCHAR(MAX) NULL, 
    [MarkWriteOffTools] BIT NULL, 
    [MarkForShipment] BIT NULL, 
    [MarkFromWorker] BIT NULL
)
