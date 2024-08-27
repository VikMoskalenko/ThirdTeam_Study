CREATE PROCEDURE UpdateStudent
    @Id INT,
    @Name NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DOB DATE
AS
BEGIN
    UPDATE Student
    SET Name = @Name,
        LastName = @LastName,
        DOB = @DOB
    WHERE Id = @Id;
END
