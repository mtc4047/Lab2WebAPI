CREATE TRIGGER PreventInactiveProductInsert
ON BasketPositions
AFTER INSERT
AS
BEGIN
    DECLARE @ProductId INT

    SELECT @ProductId = ProductId
    FROM inserted;

    IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = @ProductId AND IsActive = 1)
    BEGIN
        RAISERROR('Cannot add inactive product to basket.', 16, 1)
        ROLLBACK TRANSACTION;
    END
END