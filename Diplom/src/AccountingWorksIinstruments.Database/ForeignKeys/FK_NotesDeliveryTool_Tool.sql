ALTER TABLE [dbo].[NotesDeliveryTool]
	ADD CONSTRAINT [FK_NotesDeliveryTool_Tool]
	FOREIGN KEY (ToolId)
	REFERENCES [Tool] (Id)
	ON DELETE CASCADE