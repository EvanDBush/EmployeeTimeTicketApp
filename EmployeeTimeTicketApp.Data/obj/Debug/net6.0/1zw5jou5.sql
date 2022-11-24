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

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EMail] nvarchar(max) NULL,
    [TaxWithholding] float NOT NULL,
    [HourlyRate] float NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Projects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Budget] float NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmployeeProject] (
    [EmployeesId] int NOT NULL,
    [ProjectsId] int NOT NULL,
    CONSTRAINT [PK_EmployeeProject] PRIMARY KEY ([EmployeesId], [ProjectsId]),
    CONSTRAINT [FK_EmployeeProject_Employees_EmployeesId] FOREIGN KEY ([EmployeesId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeProject_Projects_ProjectsId] FOREIGN KEY ([ProjectsId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TimeTickets] (
    [Id] int NOT NULL IDENTITY,
    [Hours] float NOT NULL,
    [EmployeeId] int NOT NULL,
    [ProjectId] int NOT NULL,
    [DateTime] datetime2 NULL,
    [NotPaid] bit NOT NULL,
    CONSTRAINT [PK_TimeTickets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TimeTickets_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TimeTickets_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_EmployeeProject_ProjectsId] ON [EmployeeProject] ([ProjectsId]);
GO

CREATE INDEX [IX_TimeTickets_EmployeeId] ON [TimeTickets] ([EmployeeId]);
GO

CREATE INDEX [IX_TimeTickets_ProjectId] ON [TimeTickets] ([ProjectId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221124151038_init', N'7.0.0');
GO

COMMIT;
GO

