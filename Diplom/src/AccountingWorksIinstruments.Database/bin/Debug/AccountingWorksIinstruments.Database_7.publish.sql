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
