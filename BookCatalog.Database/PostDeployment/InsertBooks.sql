IF (NOT EXISTS (SELECT TOP 1 * FROM tblBooks))
BEGIN
	Insert into tblBooks (Title, AuthorId) values ('Harry Potter and the Philosopher''s Stone', 1)
	Insert into tblBooks (Title, AuthorId) values ('Harry Potter and the Chamber of Secrets', 1)
	Insert into tblBooks (Title, AuthorId) values ('Harry Potter and the Prisoner of Azkaban', 1)
	Insert into tblBooks (Title, AuthorId) values ('Harry Potter and the Goblet of Fire', 1)
	Insert into tblBooks (Title, AuthorId) values ('Sharp Objects', 2)
	Insert into tblBooks (Title, AuthorId) values ('Dark Places', 2)
	Insert into tblBooks (Title, AuthorId) values ('Gone Girl', 2)
	Insert into tblBooks (Title, AuthorId) values ('Flowers for Algernon', 3)
	Insert into tblBooks (Title, AuthorId) values ('The Minds of Billy Milligan', 3)
END
