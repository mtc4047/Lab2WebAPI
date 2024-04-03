CREATE PROCEDURE AddProductToBasket
    @ProductId INT,
    @UserId INT,
    @Amount INT
AS
BEGIN
    IF @Amount > 0
    BEGIN
        IF EXISTS (SELECT 1 FROM Products WHERE Id = @ProductId AND IsActive = 1)
        BEGIN
            INSERT INTO BasketPositions (ProductId, UserId, Amount)
            VALUES (@ProductId, @UserId, @Amount);
        END
        ELSE
        BEGIN
            RAISERROR('Cannot add inactive product to basket.', 16, 1);
        END
    END
    ELSE
    BEGIN
        RAISERROR('Amount must be greater than 0.', 16, 1);
    END
END
