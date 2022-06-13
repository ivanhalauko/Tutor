ALTER TABLE [dbo].[SubmissionWriteTool]
	ADD CONSTRAINT [FK_SubmissionWriteOff_SubmissionWriteTool]
	FOREIGN KEY (SubmissionWriteID)
	REFERENCES [SubmissionWriteOff] (Id)
	ON DELETE CASCADE