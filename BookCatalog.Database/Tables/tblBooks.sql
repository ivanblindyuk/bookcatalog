CREATE TABLE [dbo].[tblBooks]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(max) NOT NULL,
	[ReleaseDate] DATE NULL,
	[Ranking] INT NULL,
	[PageCount] INT NULL,	
	CONSTRAINT [CHK_tblBooks_RankingValue] CHECK ([Ranking] > 0 AND [Ranking] <= 10) 
)
