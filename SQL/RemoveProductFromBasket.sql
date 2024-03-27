CREATE PROCEDURE RemoveProductFromBasket
    @UserId INT,
    @ProductId INT
AS
BEGIN
    DELETE FROM BasketPositions
    WHERE UserId = @UserId AND ProductId = @ProductId;
END