CREATE TABLE [dbo].[Products]
(
	[ProductID] INT NOT NULL PRIMARY KEY, 
    [Code] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(100) NULL, 
    [CategoryID] INT NOT NULL
)
