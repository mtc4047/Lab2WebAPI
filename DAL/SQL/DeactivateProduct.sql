CREATE PROCEDURE DeactivateProduct
    @ProductId INT
AS
BEGIN
    DECLARE @UserId INT
    DECLARE @OrderId INT

    SELECT @UserId = UserId
    FROM BasketPositions
    WHERE ProductId = @ProductId;

    SELECT @OrderId = Id
    FROM Orders
    WHERE UserId = @UserId;

    IF (@OrderId IS NOT NULL)
    BEGIN
        IF EXISTS (SELECT 1 FROM Orders WHERE Id = @OrderId AND IsPaid = 1)
        BEGIN
            UPDATE Products
            SET IsActive = 0
            WHERE Id = @ProductId;
        END
    END
END
