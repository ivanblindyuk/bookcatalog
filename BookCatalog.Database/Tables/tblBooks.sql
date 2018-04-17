CREATE TABLE [dbo].[tblBooks]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(max) NOT NULL,
	[AuthorId] INT NULL,
	CONSTRAINT [FK_tblBooks_tblAuthors] FOREIGN KEY ([AuthorId]) REFERENCES [tblAuthors] ([Id])
)
