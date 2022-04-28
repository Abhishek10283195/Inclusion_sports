-- Creating table 'Trust Heterosexual'
CREATE TABLE [dbo].[TrustHetero] (
 [Id] int IDENTITY(1,1) NOT NULL,
 [Type] nvarchar(max) NOT NULL,
 [Degree] nvarchar(max) NOT NULL,
 [Percentage] int NOT NULL,
PRIMARY KEY (Id));
GO


-- Creating table 'Trust Homosexual'
CREATE TABLE [dbo].[TrustHomo] (
 [Id] int IDENTITY(1,1) NOT NULL,
 [Type] nvarchar(max) NOT NULL,
 [Degree] nvarchar(max) NOT NULL,
 [Percentage] int NOT NULL
PRIMARY KEY (Id));
GO