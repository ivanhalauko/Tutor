ALTER TABLE [dbo].[SubmissionWriteTool]
	ADD CONSTRAINT [FK_SubmissionWriteTool_Tool]
	FOREIGN KEY (ToolId)
	REFERENCES [Tool] (Id)
	ON DELETE CASCADE