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
PRINT N'Идет удаление Внешний ключ [dbo].[FK_Tool_Worker]…';


GO
ALTER TABLE [dbo].[Worker] DROP CONSTRAINT [FK_Tool_Worker];


GO
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Tool]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Tool] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50) NULL,
    [Description] NVARCHAR (50) NULL,
    [LocationId]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Tool])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tool] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Tool] ([Id], [Name], [Description], [LocationId])
        SELECT   [Id],
                 [Name],
                 [Description],
                 [LocationId]
        FROM     [dbo].[Tool]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Tool] OFF;
    END

DROP TABLE [dbo].[Tool];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Tool]', N'Tool';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Идет создание Внешний ключ [dbo].[FK_Tool_Worker]…';


GO
ALTER TABLE [dbo].[Worker] WITH NOCHECK
    ADD CONSTRAINT [FK_Tool_Worker] FOREIGN KEY ([ToolId]) REFERENCES [dbo].[Tool] ([Id]) ON DELETE CASCADE;


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

GO
PRINT N'Существующие данные проверяются относительно вновь созданных ограничений';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Worker] WITH CHECK CHECK CONSTRAINT [FK_Tool_Worker];


GO
PRINT N'Обновление завершено.';


GO
