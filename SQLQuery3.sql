CREATE TABLE [dbo].[Sport] (
 [Id] int IDENTITY(1,1) NOT NULL,
 [Sports] nvarchar(max) NOT NULL,
PRIMARY KEY (Id)
);
GO

CREATE TABLE [dbo].[Calorie] (
 [Id] int IDENTITY(1,1) NOT NULL,
 [SportId] int NOT NULL,
 [SportName] nvarchar(max) NOT NULL,
 [Degree] nvarchar(max) NOT NULL,
 [Coef] int NOT NULL,
[Intercept] int NOT NULL,
[W130lb] int NOT NULL,
[W155lb] int NOT NULL,
[W180lb] int NOT NULL,
[W205lb] int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (SportId) REFERENCES Sport(Id)
);
GO