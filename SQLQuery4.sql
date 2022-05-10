﻿
CREATE TABLE [dbo].[Calorie] (
 [Id] int IDENTITY(1,1) NOT NULL,
 [SportName] nvarchar(max) NOT NULL,
 [Degree] nvarchar(max) NOT NULL,
 [Coef] int NOT NULL,
[Intercept] int NOT NULL,
[W130lb] int NOT NULL,
[W155lb] int NOT NULL,
[W180lb] int NOT NULL,
[W205lb] int NOT NULL,
PRIMARY KEY (Id),
);
GO