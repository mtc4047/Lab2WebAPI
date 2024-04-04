CREATE PROCEDURE GenerateOrder
    @UserId INT
AS
BEGIN
    DECLARE @OrderID INT

    IF NOT EXISTS (
        SELECT 1
        FROM BasketPositions bp
        WHERE bp.UserId = @UserId
    )
    BEGIN
        RETURN;
    END

    INSERT INTO Orders (UserID, Date, IsPaid)
    VALUES (@UserId, GETDATE(), 0)

    SET @OrderID = SCOPE_IDENTITY()

    INSERT INTO OrdersPositions (OrderID, ProductID, Amount, Price)
    SELECT @OrderID, bp.ProductID, bp.Amount, p.Price
    FROM BasketPositions bp
    JOIN Products p ON bp.ProductID = p.ID
    WHERE bp.UserId = @UserId

END
