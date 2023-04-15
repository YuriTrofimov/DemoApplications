IF (NOT EXISTS(SELECT 1 FROM dbo.ProductCategory))
BEGIN
	INSERT INTO dbo.ProductCategory ([Id], [Name]) VALUES (1, 'Default')
END
