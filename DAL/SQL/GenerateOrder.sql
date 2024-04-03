CREATE PROCEDURE GenerateOrder
    @UserId INT
AS
BEGIN
    INSERT INTO Orders (UserID, Date)
    VALUES (@UserId, GETDATE());
END