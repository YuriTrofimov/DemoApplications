CREATE PROCEDURE [dbo].[UpdateProduct]
	@Article VARCHAR(50),
	@Name varchar(250),
	@Price numeric(15, 2),
	@Quantity int,
	@CategoryId INT
AS

SET NOCOUNT ON

IF isnull(@Article, '') = ''
	RETURN

IF isnull(@Name, '') = ''
	RETURN

IF NOT EXISTS(SELECT 1 FROM dbo.Products WHERE Article=@Article)
	-- Create new product if not exists
	INSERT INTO dbo.Products 
		(Article, [Name], Price, Quantity, CategoryId)
		VALUES 
			(@Article, @Name, @Price, @Quantity, @CategoryId)
ELSE
	-- Update existing product
	UPDATE dbo.Products SET 
		[Name]=@Name,
		Price=@Price,
		Quantity=@Quantity,
		CategoryId=@CategoryId
		WHERE Article=@Article