---Warehouse
if not exists (SELECT*FROM dbo.Warehouse WHERE WarehouseNumber='Sklad №1')
begin
insert into dbo.Warehouse(WarehouseNumber)
values
('Sklad №1'),
('Sklad №2'),
('Sklad №3')
end
GO
--- Location
if not exists (SELECT*FROM dbo.Location WHERE NameOfTheOrganization='RKP' and WarehouseId=1)
begin
insert into dbo.Location(NameOfTheOrganization,WarehouseId)
values
('RKP',1),
('Alcopack',2),
('KSK',1),
('DELCOM',3)
end
GO


--- Position
if not exists (SELECT*FROM dbo.Position WHERE Name='Master')
begin
insert into dbo.Position(Name)
values
('Master'),
('Boss'),
('Stock boy'),
('Slesar')
end 
GO

--- Worker
if not exists (SELECT*FROM dbo.Worker WHERE Name='Nikolai' and Surname='Nikolaev' and SecondName='Nikolaevich' and PositionId=1)
begin
insert into dbo.Worker (Name,Surname,SecondName,PositionId)
values
('Nikolai','Nikolaev','Nikolaevich',1),
('Petrov','Petr','Petrovich',2),
('Sidorov','Sidr','Sidorovich',3)
end
GO

--- Status
if not exists (SELECT*FROM dbo.Status WHERE StatusDiscription='busy')
begin
insert into dbo.Status(StatusDiscription)
values
('busy'),
('broken'),
('repair'),
('out of stock'),
('avialable')
end
GO

--- Tool
if not exists (SELECT*FROM dbo.Tool WHERE Name='Grinder' and Description='Work with metal' and LocationId=1 and WorkerId=1 and StatusId=1)
begin
insert into dbo.Tool(Name,Description,LocationId,WorkerId,StatusId)
values
('Grinder','Work with metal',2,1,2),
('Svarka','Work with metal',1,3,1)
end
GO

--- SubmissionForTools
if not exists (SELECT*FROM dbo.SubmissionForTools WHERE Purpose='Cut' and DateOfDelivery=20.12)
begin
insert into dbo.SubmissionForTools(Purpose,DateOfDelivery)
values
('Cut',20.12),
('Varit',12.01)
end
GO

---SubmissionForToolTool
if not exists (SELECT*FROM dbo.SubmissionForToolTool WHERE ToolId=1 and SubmissionId=1)
begin
insert into dbo.SubmissionForToolTool(ToolId,SubmissionId)
values
(1,1),
(2,2)
end
GO

---SubmissionWriteOff
if not exists (SELECT*FROM dbo.SubmissionWriteOff WHERE Date=20.12)
begin
insert into dbo.SubmissionWriteOff(Date)
values
(20.12),
(10.11),
(14.04)
end
GO

---SubmissionWriteTool
if not exists (SELECT*FROM dbo.SubmissionWriteTool WHERE ToolId=1 and SubmissionWriteID=1)
begin
insert into dbo.SubmissionWriteTool(ToolId,SubmissionWriteID)
values
(1,3),
(2,2)
end
GO
---NoteDelivery
if not exists (SELECT*FROM dbo.NoteDelivery WHERE NumberOfDeliveryNote=41245 and CarsNumber=4214 and DeliveryDate=23.05)
begin
insert into dbo.NoteDelivery(NumberOfDeliveryNote,CarsNumber,DeliveryDate)
values
(52142,3124,12.05),
(53543,6342,31.12),
(65324,9874,19.03)
end
GO

---NotesDeliveryTool
if not exists (SELECT*FROM dbo.NotesDeliveryTool WHERE ToolId=1 and NoteDeliveryId=1)
begin
insert into dbo.NotesDeliveryTool(ToolId,NoteDeliveryId)
values
(2,1),
(1,3)
end
GO
