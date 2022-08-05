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
if not exists (SELECT*FROM dbo.Location WHERE NameOfLocation='RKP' and WarehouseId=1)
begin
insert into dbo.Location(NameOfLocation,WarehouseId)
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

---AspNetRoles
if not exists (SELECT*FROM dbo.AspNetRoles WHERE Id='93288d77-4729-4b10-8d58-caa19f6a73cf' and Name='Admin' and NormalizedName='ADMIN' and 
ConcurrencyStamp='24a9e76f-a0b8-4579-8cf3-719b01eb3831')
begin
insert into dbo.AspNetRoles(Id,Name,NormalizedName,ConcurrencyStamp)
values
('93288d77-4729-4b10-8d58-caa19f6a73cf','Admin','ADMIN','24a9e76f-a0b8-4579-8cf3-719b01eb3831'),
('03b995ca-b196-43c9-9a54-b1be52f97412','Stock Boy','STOCK BOY','5a470f50-829c-4468-ae2e-de6fb151e276'),
('2834e398-f2e5-4477-8e43-8211d3dc9d5b','worker','WORKER','1919c07e-8114-4ba3-aabe-8d565b429de5')
end
GO


---AspNetUser
if not exists (SELECT*FROM dbo.AspNetUsers WHERE Id='b8055e4f-d51d-4422-a59a-bd1f87ab616b' and UserName='admin123@sobaca.ru' and NormalizedUserName='ADMIN123@SOBACA.RU' 
and Email='admin123@sobaca.ru' and NormalizedEmail='ADMIN123@SOBACA.RU' and EmailConfirmed='False' 
and PasswordHash='AQAAAAEAACcQAAAAELAR7Z6yRX31T3BvBZe+1N1oevws7oWS7pGf1t9ntDIq9oAppNpo+0PB+1F0ywEapA==' 
and SecurityStamp='MQ7KQM5ONQ5QYN7YXGNCPWLNTYUU6WHJ' and ConcurrencyStamp='e7ade904-565d-4963-8d1b-02d2961954f6' 
and PhoneNumber=NULL and PhoneNumberConfirmed='False' and TwoFactorEnabled='False' and LockoutEnd=NULL and LockoutEnabled='True' 
and AccessFailedCount=0 and Surname=NULL and PositionId=1)
begin
insert into dbo.AspNetUsers(Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,
ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Surname,PositionId)
values
('b8055e4f-d51d-4422-a59a-bd1f87ab616b','admin123@sobaca.ru','ADMIN123@SOBACA.RU','admin123@sobaca.ru','ADMIN123@SOBACA.RU','False',
'AQAAAAEAACcQAAAAELAR7Z6yRX31T3BvBZe+1N1oevws7oWS7pGf1t9ntDIq9oAppNpo+0PB+1F0ywEapA==',
'MQ7KQM5ONQ5QYN7YXGNCPWLNTYUU6WHJ','e7ade904-565d-4963-8d1b-02d2961954f6',NULL,'False','False',
NULL,'True',0,NULL,1),
('54301f6b-5463-4024-9cac-770a6eaee02f','antonstepanovich@mail.com','ANTONSTEPANOVICH@MAIL.COM','antonstepanovich@mail.com','ANTONSTEPANOVICH@MAIL.COM',
'False','AQAAAAEAACcQAAAAEKjmlfjOfI9peuPnSzxjLXWWkMcT+XxZVNVkkPb9sFmW9FqAW0keysBWJyCq5UZTVw==','Q3Z2A3T6ZI3AL7OLPG3FFTXREJGEITQ2',
'090fa272-6616-469b-92aa-481188562461',NULL,'False','False',NULL,'True',0,NULL,1),
('283b1569-66d6-461e-8f72-f92c394884fe','stockboy@mail.ri','STOCKBOY@MAIL.RI','stockboy@mail.ri','STOCKBOY@MAIL.RI','False',
'AQAAAAEAACcQAAAAEBPmct7/Db38LhSyZ8y9q5sZz98ssE3lqUqDByL5lHx3DXTb+zqKqwEKVu9D49g1KA==','SUGHPAARFLROWEPBSMCSHSZOLEY7B2W5',
'b4bb3a8c-1c2a-4499-8284-0bd8d852c31f',NULL,'False','False',NULL,'True',0,NULL,1),
('c24811f8-56af-4807-8abb-6604d3392844','vasyapertrovich@mail.ru','VASYAPERTROVICH@MAIL.RU','vasyapertrovich@mail.ru','VASYAPERTROVICH@MAIL.RU',
'False','AQAAAAEAACcQAAAAEBTGVuq8hw5XNnhTgtZfgcgHxSXvJ5EWq8WxIved4MI8pMb8YVNshp4DoGN1rudzSQ==','7DLJFWM5V6ZNWTUGKAA6JTECH2T6X5V6',
'1728bf49-0c04-437d-9e50-0da956f6a8d4',NULL,'False','False',NULL,'True',0,NULL,1)
end 
GO
---AspNetUserRoles
if not exists (SELECT*FROM dbo.AspNetUserRoles WHERE UserId='b8055e4f-d51d-4422-a59a-bd1f87ab616b' and RoleId='93288d77-4729-4b10-8d58-caa19f6a73cf')
begin 
insert into dbo.AspNetUserRoles(UserId,RoleId)
values
('b8055e4f-d51d-4422-a59a-bd1f87ab616b','93288d77-4729-4b10-8d58-caa19f6a73cf')
end
GO



----- Worker
--if not exists (SELECT*FROM dbo.Worker WHERE Name='Nikolai' and Surname='Nikolaev' and SecondName='Nikolaevich' and PositionId=1 and LocationId=1)
--begin
--insert into dbo.Worker (Name,Surname,SecondName,PositionId,LocationId)
--values
--('Nikolai','Nikolaev','Nikolaevich',1,3),
--('Petrov','Petr','Petrovich',2,4),
--('Sidorov','Sidr','Sidorovich',3,2)
--end
--GO

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
if not exists (SELECT*FROM dbo.Tool WHERE Name='Grinder' and Description='Work with metal' and LocationId=1 and StatusId=1
and AspNetUsersId='b8055e4f-d51d-4422-a59a-bd1f87ab616b' and PosterImageUrl=null and MarkWriteOffTools=0 and MarkForShipment=0 and MarkFromWorker = 0
and MarkDestinationUser = 0 and MarkForDecline = 0)
begin
insert into dbo.Tool(Name,Description,LocationId,StatusId,AspNetUsersId,PosterImageUrl,MarkWriteOffTools,MarkForShipment,MarkFromWorker,
MarkDestinationUser,MarkForDecline)
values
('Grinder','Work with metal',1,2,'b8055e4f-d51d-4422-a59a-bd1f87ab616b',null,0,0,0,0,0),
('Svarka','Work with metal',3,1,'b8055e4f-d51d-4422-a59a-bd1f87ab616b', null,0,0,0,0,0)
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

if not exists (SELECT*FROM dbo.StatusSubmission WHERE StatusSub='Approved')
begin
insert into dbo.StatusSubmission(StatusSub)
values
('Approved'),
('Denied')
end
GO