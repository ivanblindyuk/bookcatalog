CREATE PROCEDURE [dbo].[uspInsertAuthor]
	@FirstName nvarchar(255),
	@LastName nvarchar(255)
AS
BEGIN
	Declare @AuthorExists BIT

	Set @AuthorExists = [dbo].[fnAuthorExists](@FirstName, @LastName);

	IF @AuthorExists = 1
	BEGIN
		RAISERROR ('Author already exists', 16, 1);
	END
	ELSE
	BEGIN
		Insert into [tblAuthors] ([FirstName], [LastName])
		values (@FirstName, @LastName)
	END
END
