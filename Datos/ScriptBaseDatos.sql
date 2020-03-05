CREATE DATABASE [School];
USE  [School]
CREATE TABLE [dbo].[Teacher]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Skills] VARCHAR(250) NOT NULL,
    [TotalStudents] INT NOT NULL,
    [Salary] MONEY NOT NULL,
    [AddedOn] DATE NOT NULL DEFAULT GETDATE()
)
COMMIT

CREATE TABLE [dbo].[Persona](
	[Identificacion] [nvarchar](10) NOT NULL PRIMARY KEY,
	[Nombre] [nvarchar](50) NULL,
	[Sexo] [nvarchar](2) NULL,
	[Edad] [int] NULL,
	[Pulsacion] [numeric](18, 0) NULL,
) 
GO

COMMIT