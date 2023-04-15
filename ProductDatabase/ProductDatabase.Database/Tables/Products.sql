CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Article] VARCHAR(50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Name] varchar(250) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Price] numeric(15, 2) NOT NULL default 0.00,
	[Quantity] int NOT NULL default 0, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY (CategoryId) REFERENCES dbo.ProductCategory(Id) 
)

GO

CREATE UNIQUE INDEX [UX_Products_Article] ON [dbo].[Products] ([Article])
