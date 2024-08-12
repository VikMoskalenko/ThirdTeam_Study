CREATE PROCEDURE DeleteStudentById
    @Id INT
AS
BEGIN
    DELETE FROM Student
    WHERE Id = @Id;
END
