IF (NOT EXISTS (SELECT TOP 1 * FROM tblBooks))
BEGIN
	Insert into tblBooks (Title) 
		values	('Harry Potter and the Philosopher''s Stone'),
				('Harry Potter and the Chamber of Secrets'),
				('Harry Potter and the Prisoner of Azkaban'),
				('Harry Potter and the Goblet of Fire'),
				('Sharp Objects'),
				('Dark Places'),
				('Gone Girl'),
				('Flowers for Algernon'),
				('The Minds of Billy Milligan')
END
