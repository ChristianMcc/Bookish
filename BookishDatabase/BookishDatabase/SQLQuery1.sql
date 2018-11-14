IF OBJECT_ID('dbo.Books', 'U') IS NOT NULL
DROP TABLE dbo.Books
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Books
(
   BookId  INTEGER IDENTITY PRIMARY KEY, -- primary key column
   Name    [NVARCHAR](50)  NOT NULL,
   Author  [NVARCHAR](50)  NOT NULL,
   ISBN    [NVARCHAR](50)  NOT NULL
);
GO

INSERT INTO dbo.Books
	([Author],[Title],[ISBN])
VALUES
	('JRR Tolkien', 'The Silmarillion', '12345'),
	('Harper Lee', 'To Kill a Mockingbird', '54321'),
	('Tom Holt', 'The Portable Door', '13524')
GO

SELECT * FROM dbo.Books;

CREATE TABLE dbo.Barcodes
(
   BarcodeId  INTEGER IDENTITY PRIMARY KEY, -- primary key column
   Barcode    [NVARCHAR](50)  NOT NULL,
   BookId     int  FOREIGN KEY REFERENCES Books(BookId),
);
GO

INSERT INTO dbo.Barcodes
	([Barcode],[BookId])
VALUES
	('12453621', 1),
	('33664717', 1),
	('83495782', 2),
	('09127313', 2),
	('56515231', 2),
	('56781208', 3),
	('87537934', 3)
GO

SELECT * FROM dbo.Barcodes;


CREATE TABLE dbo.CheckedOutBooks
(
   CheckedOutId  INTEGER IDENTITY PRIMARY KEY, -- primary key column
   UserId        int NOT NULL,
   BarcodeID     int FOREIGN KEY REFERENCES Barcodes(BarcodeId),
   DueDate       datetime NOT NULL
);
GO