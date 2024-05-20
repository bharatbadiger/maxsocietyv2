CREATE TABLE [Visitors] (
    [Id] bigint NOT NULL IDENTITY,
    [VisitorName] nvarchar(60) NOT NULL,
    [MobileNo] nvarchar(14) NOT NULL,
    [Gender] int NOT NULL,
    [Email] nvarchar(50) NOT NULL,
    [FlatNo] nvarchar(max) NULL,
    [ImagePath] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [VisitorLogs] (
    [Id] bigint NOT NULL IDENTITY,
    [VisitorId] bigint NULL,
    [Block] nvarchar(max) NULL,
    [FlatNo] nvarchar(max) NULL,
    [Type] nvarchar(max) NULL,
    [VisitPurpose] nvarchar(max) NULL,
    [ResidentName] nvarchar(60) NULL,
    [VisitStatus] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_VisitorLogs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_VisitorLogs_Visitors_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Visitors] ([Id])
);
GO


CREATE INDEX [IX_VisitorLogs_VisitorId] ON [VisitorLogs] ([VisitorId]);
GO


