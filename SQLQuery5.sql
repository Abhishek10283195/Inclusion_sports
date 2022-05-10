CREATE TABLE [dbo].[Calorie] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [SportName] NVARCHAR (MAX) NOT NULL,
    [Degree]    NVARCHAR (MAX) NOT NULL,
    [Coef]      NUMERIC (10,8) NOT NULL,
    [Intercept] NUMERIC (10,8) NOT NULL,
    [W130lb]    INT            NOT NULL,
    [W155lb]    INT            NOT NULL,
    [W180lb]    INT            NOT NULL,
    [W205lb]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
