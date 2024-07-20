CREATE PROCEDURE CreateStudent
    @Name NVARCHAR(50),
    @LastName NVARCHAR(50),
    @DOB DATE
AS
BEGIN
    INSERT INTO Student (Name, LastName, DOB)
    VALUES (@Name, @LastName, @DOB);
END
