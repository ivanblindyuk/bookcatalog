CREATE TABLE [dbo].[tblBooks_Authors]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BookId] INT NOT NULL,
	[AuthorId] INT NOT NULL,
	CONSTRAINT [FK_tblBooks_Authors_tblBooks] FOREIGN KEY ([BookId]) REFERENCES [tblBooks] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_tblBooks_Authors_tblAuthors] FOREIGN KEY ([AuthorId]) REFERENCES [tblAuthors] ([Id])
)
