CREATE PROCEDURE DeleteProduct
    @ProductId INT
AS
BEGIN
    DECLARE @BasketPositionId INT

    DECLARE @ProductIsActive BIT
    SELECT @ProductIsActive = IsActive
    FROM Products
    WHERE Id = @ProductId

    IF @ProductIsActive IS NOT NULL
    BEGIN
        SELECT @BasketPositionId = UserId
        FROM BasketPositions
        WHERE ProductId = @ProductId

        IF @BasketPositionId IS NOT NULL
        BEGIN
            DECLARE @IsPaid BIT
            SELECT @IsPaid = IsPaid
            FROM Orders
            WHERE UserId = @BasketPositionId

            IF @IsPaid IS NOT NULL
            BEGIN
                UPDATE Products
                SET IsActive = 0
                WHERE Id = @ProductId

                DELETE FROM Products
                WHERE Id = @ProductId AND @IsPaid = 1
            END
            ELSE
            BEGIN
                UPDATE Products
                SET IsActive = 0
                WHERE Id = @ProductId
            END
        END
        ELSE
        BEGIN
            DELETE FROM Products
            WHERE Id = @ProductId
        END
    END
END