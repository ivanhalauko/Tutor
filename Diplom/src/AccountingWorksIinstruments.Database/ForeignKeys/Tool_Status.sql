﻿ALTER TABLE [dbo].[Tool]
	ADD CONSTRAINT [Tool_Status]
	FOREIGN KEY (StatusId)
	REFERENCES [Status] (Id)
	ON DELETE CASCADE