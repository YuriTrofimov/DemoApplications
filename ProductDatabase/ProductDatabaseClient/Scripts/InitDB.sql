-- Copyright (c) 2023 Yuri Trofimov.
-- Licensed under the MIT license. See LICENSE file in the project root for full license information.

if (not exists(select * from INFORMATION_SCHEMA.TABLES 
	where TABLE_NAME='ProductCategory' and TABLE_SCHEMA='dbo'))
begin
	CREATE TABLE [dbo].[ProductCategory]
	(
		[Id] INT NOT NULL PRIMARY KEY, 
		[Name] VARCHAR(100) COLLATE Cyrillic_General_CI_AS NOT NULL
	)
end

if (not exists(select * from INFORMATION_SCHEMA.TABLES 
	where TABLE_NAME='Products' and TABLE_SCHEMA='dbo'))
begin
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

	CREATE UNIQUE INDEX [UX_Products_Article] ON [dbo].[Products] ([Article])
end

IF (NOT EXISTS(SELECT 1 FROM dbo.ProductCategory))
BEGIN
	INSERT INTO dbo.ProductCategory ([Id], [Name]) VALUES (1, 'Default')
END