ALTER TABLE [dbo].[SubmissionForToolTool]
	ADD CONSTRAINT [FK_Submission_SubmissionForTool]
	FOREIGN KEY (SubmissionId)
	REFERENCES [SubmissionForTools] (Id)
	ON DELETE CASCADE