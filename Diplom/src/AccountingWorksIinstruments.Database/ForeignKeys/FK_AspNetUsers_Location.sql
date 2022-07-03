ALTER TABLE [dbo].[AspNetUsers]
	ADD CONSTRAINT [FK_AspNetUsers_Location]
	FOREIGN KEY (LocationId)
	REFERENCES [Location] (Id)
	ON DELETE CASCADE
