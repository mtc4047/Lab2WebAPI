CREATE PROCEDURE ChangeAmount
    @UserId INT,
    @ProductId INT,
    @NewQuantity INT
AS
BEGIN
    IF @NewQuantity >= 0
    BEGIN
        UPDATE BasketPositions
        SET Amount = @NewQuantity
        WHERE UserId = @UserId AND ProductId = @ProductId;
    END
    ELSE
    BEGIN
        RAISERROR('New quantity must be greater than or equal to 0.', 16, 1);
    END
END