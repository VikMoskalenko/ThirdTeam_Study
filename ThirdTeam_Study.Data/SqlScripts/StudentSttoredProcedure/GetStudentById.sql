CREATE PROCEDURE GetStudentById
    @Id INT
AS
BEGIN
    SELECT Id, Name, LastName, DOB
    FROM Student
    WHERE Id = @Id;
END
