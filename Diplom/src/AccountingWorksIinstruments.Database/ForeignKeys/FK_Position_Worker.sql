ALTER TABLE [dbo].[Worker]
	ADD CONSTRAINT [FK_Position_Worker]
	FOREIGN KEY (PositionId)
	REFERENCES [dbo].[Position] (Id)
	ON DELETE CASCADE
