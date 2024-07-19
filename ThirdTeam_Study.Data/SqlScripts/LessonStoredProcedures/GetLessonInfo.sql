CREATE PROCEDURE GetLessonInfo
    @LessonId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT 
        l.LessonType, 
        l.LessonTheme, 
        l.LessonStart, 
        t.TutorFirstName, 
        t.TutorLastName
    FROM 
        Lesson l
    JOIN 
        Tutor t ON l.TutorID = t.Id
    WHERE 
        l.Id = @LessonId;
END;