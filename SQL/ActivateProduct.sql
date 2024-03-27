CREATE PROCEDURE ActivateProduct
    @ProductId INT
AS
BEGIN
    UPDATE Products
    SET IsActive = 1
    WHERE Id = @ProductId;
END