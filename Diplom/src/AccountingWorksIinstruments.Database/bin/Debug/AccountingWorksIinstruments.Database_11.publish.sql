﻿/*
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
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Location]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Location] (
    [Id]                       INT           IDENTITY (1, 1) NOT NULL,
    [TheNameOfTheOrganization] NVARCHAR (50) NULL,
    [Warehouse1]               NVARCHAR (50) NULL,
    [Warehouse2]               NVARCHAR (50) NULL,
    [Warehouse3]               NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Location])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Location] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Location] ([Id], [TheNameOfTheOrganization], [Warehouse1], [Warehouse2], [Warehouse3])
        SELECT   [Id],
                 [TheNameOfTheOrganization],
                 [Warehouse1],
                 [Warehouse2],
                 [Warehouse3]
        FROM     [dbo].[Location]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Location] OFF;
    END

DROP TABLE [dbo].[Location];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Location]', N'Location';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


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

GO
PRINT N'Обновление завершено.';


GO
