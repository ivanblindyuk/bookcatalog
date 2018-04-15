IF (NOT EXISTS (SELECT TOP 1 * FROM tblAuthors))
BEGIN
	Insert into tblAuthors (FirstName, LastName) values ('Joanne', 'Rowling')
	Insert into tblAuthors (FirstName, LastName) values ('Gillian', 'Flynn')
	Insert into tblAuthors (FirstName, LastName) values ('Daniel', 'Keyes')
END
