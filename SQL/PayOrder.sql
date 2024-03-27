CREATE PROCEDURE PayOrder
    @OrderId INT,
    @Amount DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TotalAmount DECIMAL(18, 2)

    SELECT @TotalAmount = SUM(op.Amount * op.Price)
    FROM OrderPositions op
    WHERE op.OrderId = @OrderId;

    IF (@TotalAmount = @Amount)
    BEGIN
        UPDATE Orders
        SET IsPaid = 1
        WHERE Id = @OrderId;
    END
END
