CREATE PROCEDURE [dbo].[uspSelectBooks]
	@Search varchar(max),
	@Offset int,
	@Length int,
	@OrderBy int,
	@OrderDir bit,
	@Total int = 0 out
AS
BEGIN
	DECLARE @All TABLE(
		[Id] int,
		[Title] nvarchar(max),
		[ReleaseDate] date,
		[Ranking] int,
		[PageCount] int)

	DECLARE @AllFiltered TABLE(
		[Id] int,
		[Title] nvarchar(max),
		[ReleaseDate] date,
		[Ranking] int,
		[PageCount] int)

	INSERT INTO @All
	SELECT 
		[Id],
		[Title],
		[ReleaseDate],
		[Ranking],
		[PageCount]
	FROM [tblBooks]
	WHERE @Search IS NULL OR [Title] LIKE '%' + @Search + '%'

	SELECT @Total = COUNT(*) FROM @All

	IF @OrderDir = 1
	BEGIN
		INSERT INTO @AllFiltered
		SELECT * FROM @All
		ORDER BY 
			CASE WHEN @OrderBy NOT IN (1, 2, 3) THEN [Title] END DESC,
			CASE WHEN @OrderBy = 1 THEN [ReleaseDate] END DESC,
			CASE WHEN @OrderBy = 2 THEN [Ranking] END DESC,
			CASE WHEN @OrderBy = 3 THEN [PageCount] END DESC
		OFFSET @Offset ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		INSERT INTO @AllFiltered
		SELECT * FROM @All
		ORDER BY 
			CASE WHEN @OrderBy NOT IN (1, 2, 3) THEN [Title] END ASC,
			CASE WHEN @OrderBy = 1 THEN [ReleaseDate] END ASC,
			CASE WHEN @OrderBy = 2 THEN [Ranking] END ASC,
			CASE WHEN @OrderBy = 3 THEN [PageCount] END ASC
		OFFSET @Offset ROWS FETCH NEXT @Length ROWS ONLY
	END
	
	SELECT * FROM @AllFiltered
	
	SELECT
		b.[Id] as [BookId],
		a.[Id] as [AuthorId],
		a.[FirstName],
		a.[LastName]
	FROM @AllFiltered as b
	INNER JOIN [tblBooks_Authors] as ba on ba.[BookId] = b.[Id]
	INNER JOIN [tblAuthors] as a on ba.[AuthorId] = a.[Id]
	ORDER BY b.[Id]

END
