ALTER TABLE [dbo].[AspNetUsers]
	ADD CONSTRAINT [FK_AspNetUsers_Position]
	FOREIGN KEY (PositionId)
	REFERENCES [Position] (Id)
	ON DELETE CASCADE
