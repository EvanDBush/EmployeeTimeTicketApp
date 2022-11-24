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
    [EmployeeId] int NOT NULL,
    [ProjectId] int NOT NULL,
    [DateTime] datetime2 NULL,
    [NotPaid] bit NOT NULL,
    CONSTRAINT [PK_TimeTickets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TimeTickets_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TimeTickets_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Employees_ProjectId] ON [Employees] ([ProjectId]);
GO


CREATE INDEX [IX_TimeTickets_EmployeeId] ON [TimeTickets] ([EmployeeId]);
GO


CREATE INDEX [IX_TimeTickets_ProjectId] ON [TimeTickets] ([ProjectId]);
GO


