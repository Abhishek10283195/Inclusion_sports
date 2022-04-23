CREATE TABLE [dbo].[Reporting] (
[Id] int IDENTITY(1,1) NOT NULL,
[Name] nvarchar(max) NOT NULL,
[Email] nvarchar(max) NOT NULL,
[Answer] nvarchar(max) NOT NULL,
PRIMARY KEY (Id)
);
GO