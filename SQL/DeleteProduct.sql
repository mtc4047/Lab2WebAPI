CREATE PROCEDURE DeleteProduct
    @ProductId INT
AS
BEGIN
    DECLARE @UserId INT
    DECLARE @IsPaid BIT

    SELECT @UserId = UserId
    FROM BasketPositions
    WHERE ProductId = @ProductId;

    SELECT @IsPaid = IsPaid
    FROM Orders
    WHERE UserId = @UserId;


    IF (@IsPaid = 1)
    BEGIN
        DELETE FROM Products
        WHERE Id = @ProductId;
    END
END
