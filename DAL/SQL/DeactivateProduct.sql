CREATE PROCEDURE DeactivateProduct
    @ProductId INT
AS
BEGIN

    DECLARE @UserId INT
    DECLARE @OrderId INT

    IF EXISTS (SELECT 1 FROM BasketPositions WHERE ProductId = @ProductId)
    BEGIN
        SELECT @UserId = UserId
        FROM BasketPositions
        WHERE ProductId = @ProductId;

        IF @UserId IS NOT NULL
        BEGIN
            SELECT @OrderId = Id
            FROM Orders
            WHERE UserId = @UserId;
            IF (@OrderId IS NULL OR NOT EXISTS (SELECT 1 FROM Orders WHERE Id = @OrderId AND IsPaid = 0))
            BEGIN
                UPDATE Products
                SET IsActive = 0
                WHERE Id = @ProductId;
            END
        END
    END
    ELSE 
    BEGIN
        UPDATE Products
        SET IsActive = 0
        WHERE Id = @ProductId;
    END
END