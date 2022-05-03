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
PRINT N'Выполняется запуск перестройки таблицы [dbo].[Worker]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Worker] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Surname]    NVARCHAR (50) NULL,
    [Name]       NVARCHAR (50) NULL,
    [SecondName] NVARCHAR (50) NULL,
    [PositionId] INT           NULL,
    [ToolId]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Worker])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Worker] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Worker] ([Id], [Surname], [Name], [SecondName], [PositionId], [ToolId])
        SELECT   [Id],
                 [Surname],
                 [Name],
                 [SecondName],
                 [PositionId],
                 [ToolId]
        FROM     [dbo].[Worker]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Worker] OFF;
    END

DROP TABLE [dbo].[Worker];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Worker]', N'Worker';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
---Worker
if not exists (SELECT*FROM dbo.Worker WHERE Name='Nikolai' and Surname='Nikolaev' and SecondName='Nikolaevich' and PositionId=1 and ToolId=1)
begin
insert into dbo.Worker (Name,Surname,SecondName,PositionId,ToolId)
values
('Nikolai','Nikolaev','Nikolaevich',1,1)
end
GO

GO

GO
PRINT N'Обновление завершено.';


GO
