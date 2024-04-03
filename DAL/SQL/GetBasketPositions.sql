CREATE PROCEDURE GetBasketPositions
    @UserId INT
AS
BEGIN
    SELECT Id, ProductId, UserId, Amount
    FROM BasketPositions
    WHERE UserId = @UserId;
END