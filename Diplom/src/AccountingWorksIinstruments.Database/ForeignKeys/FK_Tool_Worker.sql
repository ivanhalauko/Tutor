﻿ALTER TABLE [dbo].[Tool]
	ADD CONSTRAINT [FK_Tool_Worker]
	FOREIGN KEY (WorkerId)
	REFERENCES [Worker] (Id)
	ON DELETE CASCADE
