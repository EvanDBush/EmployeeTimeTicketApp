IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Budget] float NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EMail] nvarchar(max) NULL,
    [TaxWithholding] float NOT NULL,
    [HourlyRate] float NOT NULL,
    [ProjectId] int NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id])
);
GO

CREATE TABLE [TimeTickets] (
    [Id] int NOT NULL IDENTITY,
    [Hours] float NOT NULL,
    [EmployeeId] int NULL,
    [ProjectId] int NULL,
    [DateTime] datetime2 NULL,
    [HasBeenPaid] bit NOT NULL,
    CONSTRAINT [PK_TimeTickets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TimeTickets_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]),
    CONSTRAINT [FK_TimeTickets_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id])
);
GO

CREATE INDEX [IX_Employees_ProjectId] ON [Employees] ([ProjectId]);
GO

CREATE INDEX [IX_TimeTickets_EmployeeId] ON [TimeTickets] ([EmployeeId]);
GO

CREATE INDEX [IX_TimeTickets_ProjectId] ON [TimeTickets] ([ProjectId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221114152621_init', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TimeTickets] DROP CONSTRAINT [FK_TimeTickets_Employees_EmployeeId];
GO

ALTER TABLE [TimeTickets] DROP CONSTRAINT [FK_TimeTickets_Projects_ProjectId];
GO

DROP INDEX [IX_TimeTickets_ProjectId] ON [TimeTickets];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TimeTickets]') AND [c].[name] = N'ProjectId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TimeTickets] DROP CONSTRAINT [' + @var0 + '];');
UPDATE [TimeTickets] SET [ProjectId] = 0 WHERE [ProjectId] IS NULL;
ALTER TABLE [TimeTickets] ALTER COLUMN [ProjectId] int NOT NULL;
ALTER TABLE [TimeTickets] ADD DEFAULT 0 FOR [ProjectId];
CREATE INDEX [IX_TimeTickets_ProjectId] ON [TimeTickets] ([ProjectId]);
GO

DROP INDEX [IX_TimeTickets_EmployeeId] ON [TimeTickets];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TimeTickets]') AND [c].[name] = N'EmployeeId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TimeTickets] DROP CONSTRAINT [' + @var1 + '];');
UPDATE [TimeTickets] SET [EmployeeId] = 0 WHERE [EmployeeId] IS NULL;
ALTER TABLE [TimeTickets] ALTER COLUMN [EmployeeId] int NOT NULL;
ALTER TABLE [TimeTickets] ADD DEFAULT 0 FOR [EmployeeId];
CREATE INDEX [IX_TimeTickets_EmployeeId] ON [TimeTickets] ([EmployeeId]);
GO

ALTER TABLE [TimeTickets] ADD CONSTRAINT [FK_TimeTickets_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [TimeTickets] ADD CONSTRAINT [FK_TimeTickets_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221114201250_ticketparentids', N'7.0.0');
GO

COMMIT;
GO

