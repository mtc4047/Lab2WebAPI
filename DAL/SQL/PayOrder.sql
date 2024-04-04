CREATE PROCEDURE PayOrder
    @OrderId INT,
    @Amount DECIMAL
AS
BEGIN
    DECLARE @IsPaid BIT
    DECLARE @TotalAmount DECIMAL

    SELECT @IsPaid = IsPaid
    FROM Orders
    WHERE Id = @OrderId

    IF @IsPaid IS NULL OR @IsPaid = 1
    BEGIN
        RETURN;
    END

    SELECT @TotalAmount = SUM(op.Amount * op.Price)
    FROM OrdersPositions op
    WHERE op.OrderID = @OrderId


    IF @Amount = @TotalAmount
    BEGIN
        UPDATE Orders
        SET IsPaid = 1
        WHERE Id = @OrderId

        COMMIT;
    END
    ELSE
    BEGIN

        RETURN;
    END
END
