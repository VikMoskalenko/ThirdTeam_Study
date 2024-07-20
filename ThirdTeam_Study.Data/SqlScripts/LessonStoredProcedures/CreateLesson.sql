CREATE PROCEDURE CreateLesson
    @LessonType NVARCHAR(100),
    @LessonTheme NVARCHAR(MAX),
    @LessonStart DATETIME,
    @TutorID UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO Lesson (Id, LessonType, LessonTheme, LessonStart, TutorID)
    VALUES (NEWID(), @LessonType, @LessonTheme, @LessonStart, @TutorID);
END;