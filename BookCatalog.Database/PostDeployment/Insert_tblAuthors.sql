IF (NOT EXISTS (SELECT TOP 1 * FROM tblAuthors))
BEGIN
	Insert into tblAuthors (FirstName, LastName) 
		values	('Joanne', 'Rowling'),
				('Gillian', 'Flynn'),
				('Daniel', 'Keyes')
END
