IF (NOT EXISTS (SELECT TOP 1 * FROM tblBooks_Authors))
BEGIN
	Insert into tblBooks_Authors (BookId, AuthorId) 
		values	(1, 1),
				(2, 1),
				(3, 1),
				(4, 1),
				(5, 2),
				(6, 2),
				(7, 2),
				(8, 3),
				(9, 3)
END
