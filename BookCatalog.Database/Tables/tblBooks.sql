CREATE TABLE [dbo].[tblBooks]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(max) NOT NULL,
	[ReleaseDate] DATE NULL,
	[Ranking] INT NULL
)
