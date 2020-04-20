CREATE FUNCTION [dbo].[fnAuthorExists]
(
	@FirstName nvarchar(255),
	@LastName nvarchar(255)
)
RETURNS BIT
BEGIN
	DECLARE @AuthorId INT, @Exists BIT

	SELECT TOP 1 @AuthorId = [Id]
	FROM [tblAuthors]
	WHERE [FirstName] = @FirstName AND [LastName] = @LastName

	IF @AuthorId IS NULL
	BEGIN
		SET @Exists = 0
	END
	ELSE
	BEGIN
		SET @Exists = 1
	END

	RETURN @Exists
END
