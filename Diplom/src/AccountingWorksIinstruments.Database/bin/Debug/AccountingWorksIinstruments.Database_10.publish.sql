/*
Скрипт развертывания для AccountingWorksIinstruments.Database

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "AccountingWorksIinstruments.Database"
:setvar DefaultFilePrefix "AccountingWorksIinstruments.Database"
:setvar DefaultDataPath "C:\Users\Sergey\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Sergey\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Операция рефакторинга Rename с помощью ключа e413e4df-f3a9-45fb-a878-91f766cf6ebd, 5957053e-2096-4e08-b945-3da3996dc059 пропущена, элемент [dbo].[Location].[Name ] (SqlSimpleColumn) не будет переименован в TheNameOfTheOrganization';


GO
PRINT N'Операция рефакторинга Rename с помощью ключа 244ac5ed-8262-4110-b591-32bd8c9b4a2c пропущена, элемент [dbo].[Location].[WareHouse] (SqlSimpleColumn) не будет переименован в Warehouse1';


GO
PRINT N'Идет создание Таблица [dbo].[Location]…';


GO
CREATE TABLE [dbo].[Location] (
    [Id]                       INT            IDENTITY (1, 1) NOT NULL,
    [TheNameOfTheOrganization] NVARCHAR (50)  NULL,
    [Warehouse1]               NVARCHAR (MAX) NULL,
    [Warehouse2]               NVARCHAR (50)  NULL,
    [Warehouse3]               NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- Выполняется этап рефакторинга для обновления развернутых журналов транзакций на целевом сервере
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'e413e4df-f3a9-45fb-a878-91f766cf6ebd')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('e413e4df-f3a9-45fb-a878-91f766cf6ebd')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5957053e-2096-4e08-b945-3da3996dc059')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5957053e-2096-4e08-b945-3da3996dc059')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '244ac5ed-8262-4110-b591-32bd8c9b4a2c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('244ac5ed-8262-4110-b591-32bd8c9b4a2c')

GO

GO
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
if not exists (SELECT*FROM dbo.Tool WHERE Name='Grinder' and Description='Work with metal' and LocationId=1)
begin
insert into dbo.Tool(Name,Description,LocationId)
values
('Grinder','Work with metal',1)
end
GO

GO
PRINT N'Обновление завершено.';


GO
