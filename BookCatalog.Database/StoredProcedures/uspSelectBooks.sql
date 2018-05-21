CREATE PROCEDURE [dbo].[uspSelectBooks]
	@Search varchar(max),
	@Offset int,
	@Length int,
	@OrderBy int,
	@OrderDir bit,
	@Total int out
AS
BEGIN
	DECLARE @Result TABLE(
		[Id] int,
		[Title] varchar(max),
		[ReleaseDate] date,
		[Ranking] int,
		[PageCount] int)

	INSERT INTO @Result
	SELECT 
		[Id],
		[Title],
		[ReleaseDate],
		[Ranking],
		[PageCount]
	FROM [tblBooks]
	WHERE @Search IS NULL OR [Title] LIKE '%' + @Search + '%'

	SELECT @Total = COUNT(*) FROM @Result

	IF @OrderDir = 1
	BEGIN
		SELECT * FROM @Result
		ORDER BY 
			CASE WHEN @OrderBy IS NULL OR @OrderBy = 0 THEN [Title] END DESC,
			CASE WHEN @OrderBy = 1 THEN [ReleaseDate] END DESC,
			CASE WHEN @OrderBy = 2 THEN [Ranking] END DESC,
			CASE WHEN @OrderBy = 3 THEN [PageCount] END DESC
		OFFSET @Offset ROWS FETCH NEXT @Length ROWS ONLY
	END
	ELSE
	BEGIN
		SELECT * FROM @Result
		ORDER BY 
			CASE WHEN @OrderBy IS NULL OR @OrderBy = 0 THEN [Title] END ASC,
			CASE WHEN @OrderBy = 1 THEN [ReleaseDate] END ASC,
			CASE WHEN @OrderBy = 2 THEN [Ranking] END ASC,
			CASE WHEN @OrderBy = 3 THEN [PageCount] END ASC
		OFFSET @Offset ROWS FETCH NEXT @Length ROWS ONLY
	END
END
