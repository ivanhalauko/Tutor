--- Worker
if not exists (SELECT*FROM dbo.Worker WHERE Name='Nikolai' and Surname='Nikolaev' and SecondName='Nikolaevich' and PositionId=1 and ToolId=1)
begin
insert into dbo.Worker (Name,Surname,SecondName,PositionId,ToolId)
values
('Nikolai','Nikolaev','Nikolaevich',1,1)
end
GO
--- Position
if not exists (SELECT*FROM dbo.Position WHERE Name='Master')
begin
insert into dbo.Position(Name)
values
('Master')
end 
GO

--- Tool
if not exists (SELECT*FROM dbo.Tool WHERE Name='Grinder' and Description='Work with metal' and LocationId=2)
begin
insert into dbo.Tool(Name,Description,LocationId)
values
('Grinder','Work with metal',1)
end
GO

--- Location
if not exists (SELECT*FROM dbo.Location WHERE TheNameOfTheOrganization='RKP' and Warehouse1='Equipped' and Warehouse2='Equipped' and Warehouse3='Equipped')
begin
insert into dbo.Location(TheNameOfTheOrganization,Warehouse1,Warehouse2,Warehouse3)
values
('RKP','Equipped','Equipped','Equipped')
end
GO