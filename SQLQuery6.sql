CREATE TABLE [dbo].[tblFiles] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [ContentType] NVARCHAR (MAX) NOT NULL,
    [Data] VARBINARY (MAX)            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO