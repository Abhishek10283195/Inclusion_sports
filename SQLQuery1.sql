CREATE TABLE [dbo].[History] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Date]   Date  NOT NULL,
    [UserId] NVARCHAR (MAX)  NOT NULL,
    [Calorie]      NVARCHAR (MAX)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

