CREATE PROCEDURE [dbo].[uspSelectAuthors]
	@Search varchar(max),
	@Offset int,
	@Length int,
	@OrderBy int,
	@OrderDir bit,
	@Total int = 0 out
AS
BEGIN
	DECLARE @Result TABLE(
		[Id] int,
		[FirstName] nvarchar(255),
		[LastName] nvarchar(255),
		[BookCount] int)

	INSERT INTO @Result
	SELECT 
		a.[Id],
		a.[FirstName],
		a.[LastName],
		COUNT(ba.[Id]) as [BookCount]
	FROM [tblAuthors] as a
	LEFT JOIN [tblBooks_Authors] as ba on ba.[AuthorId] = a.[Id]
	WHERE @Search IS NULL OR a.[FirstName] LIKE '%' + @Search + '%' OR a.[LastName] LIKE '%' + @Search + '%'
	GROUP BY 
		a.[Id],
		a.[FirstName],
		a.[LastName]

	SELECT @Total = COUNT(*) FROM @Result

	IF @OrderDir = 1
	BEGIN
		SELECT * FROM @Result
		ORDER BY 
			CASE WHEN @OrderBy IS NULL OR @OrderBy = 0 THEN [FirstName] END DESC,
			CASE WHEN @OrderBy = 1 THEN [LastName] END DESC
		OFFSET @Offset ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT * FROM @Result
		ORDER BY 
			CASE WHEN @OrderBy IS NULL OR @OrderBy = 0 THEN [FirstName] END ASC,
			CASE WHEN @OrderBy = 1 THEN [LastName] END ASC
		OFFSET @Offset ROWS FETCH NEXT @Length ROWS ONLY
	END
END
