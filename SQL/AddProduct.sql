CREATE PROCEDURE AddProduct
    @Name NVARCHAR(100),
    @Price DECIMAL(18, 2),
    @GroupId INT,
    @Image NVARCHAR(255)
AS
BEGIN
    IF @Price > 0
    BEGIN
        INSERT INTO Products (Name, Price, GroupId, Image, IsActive)
        VALUES (@Name, @Price, @GroupId, @Image, 1);
    END
END