ALTER TABLE [dbo].[NotesDeliveryTool]
	ADD CONSTRAINT [FK_NotesDeliveryTool_NotesDelivery]
	FOREIGN KEY (NoteDeliveryId)
	REFERENCES [NoteDelivery] (Id)
	ON DELETE CASCADE
