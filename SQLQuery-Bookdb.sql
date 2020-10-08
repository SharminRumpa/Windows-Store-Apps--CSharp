GO
USE master;
GO
If DB_ID ('BooksBD') IS NOT NULL DROP DATABASE BooksBD;

GO

CREATE DATABASE BooksBD;

GO
USE BooksBD;

create TABLE Books (	BookID				INT				PRIMARY KEY,
						BookTitle			VARCHAR(100),
						AuthorName			VARCHAR(50),
						ISBN				VARCHAR(30),
						NumberOfPage		INT,
						PublicationName		VARCHAR(50),
						PublishYear			INT);


INSERT INTO Books	 VALUES			(1, 'The Bluest Eye', 'William Shakespere', 'O-671-854216', 230, 'Lyall Publication', 1965),	
									(2,'Mrityukshuda',   'Rabindranath Tagor', 'O-688-1433-4', 150,'Agamee Prakshani', 1890), 
									(3,'She Stoop', 'Joan Magretta', 'O-525-67520-5', 290, 'Clarlon Books', 1949),
									(4,'Agni Bani', 'Kazi Nazrul Islam', 'O-14-0125867', 290, 'Somoy Prokashon', 1922),
									(5,'Ratri Shesh', 'Ahsan Habib', 'O-14-11205867',300, 'Kakoli Prokashoni', 1930);	


									