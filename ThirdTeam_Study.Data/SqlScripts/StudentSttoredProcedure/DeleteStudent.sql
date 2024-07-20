CREATE PROCEDURE DeleteStudent
    @Id INT
AS
BEGIN
    DELETE FROM Student
    WHERE Id = @Id;
END
