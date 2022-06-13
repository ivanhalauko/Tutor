ALTER TABLE [dbo].[SubmissionForToolTool]
	ADD CONSTRAINT [FK_SubmissionForToolTool_Tool]
	FOREIGN KEY (ToolId)
	REFERENCES [Tool] (Id)
	ON DELETE CASCADE