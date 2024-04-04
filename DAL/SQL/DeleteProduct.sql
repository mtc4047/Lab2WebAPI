CREATE PROCEDURE DeleteProduct
(
  @ProductId INT
)
AS
BEGIN
  DECLARE @BasketPositionId INT;

  IF EXISTS (SELECT 1 FROM BasketPositions WHERE ProductId = @ProductId)
  BEGIN

    SELECT TOP 1 @BasketPositionId = Id
    FROM BasketPositions
    WHERE ProductId = @ProductId;


    IF EXISTS (SELECT 1 FROM Orders WHERE UserId = @BasketPositionId)
    BEGIN

      UPDATE Products
      SET IsActive = 0
      WHERE Id = @ProductId;


      IF EXISTS (SELECT 1 FROM Orders WHERE UserId = @BasketPositionId AND IsPaid = 1)
      BEGIN
        DELETE FROM Products
        WHERE Id = @ProductId;
      END
    ELSE

      DELETE FROM Products
      WHERE Id = @ProductId;
      END
  END

END

