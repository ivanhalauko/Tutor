ALTER TABLE [dbo].[Location]
	ADD CONSTRAINT [FK_Location_Warehouse]
	FOREIGN KEY (WarehouseId)
	REFERENCES [Warehouse] (Id)
	ON DELETE CASCADE