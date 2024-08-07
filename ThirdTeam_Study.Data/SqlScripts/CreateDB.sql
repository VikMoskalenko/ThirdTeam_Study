CREATE DATABASE LearningPortal
GO

CREATE TABLE Teachers(
Id int IDENTITY not null PRIMARY KEY, 
Name nvarchar(20) not null,
DateOfBirth date null
)

GO

CREATE TABLE Users
(
Id int not null, 
Name nvarchar(20) not null,
PRIMARY KEY(Id)
)

GO

CREATE TABLE Role
(
Id int not null, 
RoleName nvarchar(20) not null,
PRIMARY KEY(Id)
)

GO

CREATE TABLE UserRoles
(
UserId int not null, 
RoleId int not null,
PRIMARY KEY(UserId, RoleId)
)

GO

ALTER Table UserRoles
Add constraint FK_UserRoles_Role_Id FOREIGN KEY(RoleId)
REFERENCES Role(Id)
GO

ALTER Table UserRoles
Add constraint FK_UserRoles_Users_Id FOREIGN KEY(UserId)
REFERENCES Users(Id)
GO


INSERT INTO Users
VALUES (1, 'Olga'),
(2, 'Mariia'),
(3, 'Olga2'),
(4, 'Olga3'),
(5, 'Olga4')

GO

CREATE TABLE Student (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DOB DATE NULL
);
Select  * from Student
INSERT INTO Student (Name, LastName, DOB) VALUES ('John', 'Doe', '2000-01-01');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Jane', 'Smith', '1999-02-15');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Michael', 'Johnson', '2001-03-10');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Emily', 'Davis', '2002-04-05');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Matthew', 'Brown', '2003-05-20');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Olivia', 'Wilson', '2004-06-25');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Daniel', 'Moore', '2005-07-30');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Sophia', 'Taylor', '2006-08-15');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Alexander', 'Anderson', '2007-09-05');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Emma', 'Thomas', '2008-10-10');

Go

Create TABLE EdPlatform(
	Name nvarchar(64) PRIMARY KEY not null,
	Language nvarchar(8) not null,
	PlatformTheme int not null,
)

ALTER TABLE Student
Add EdPlatform nvarchar(64);

ALTER TABLE Student
Add constraint FK_Student_EdPlatform_Id FOREIGN KEY(EdPlatform)
REFERENCES EdPlatform(Name)

ALTER TABLE Teachers
Add EdPlatform nvarchar(64);

ALTER TABLE Teachers
Add constraint FK_Teachers_EdPlatform_Id FOREIGN KEY(EdPlatform)
REFERENCES EdPlatform(Name)

Insert into EdPlatform (Name, Language, PlatformTheme)
Values ('HillelEdPlatform', 'en', 0)

GO

DELETE FROM EdPlatform

ALTER TABLE Students
DROP Constraint FK_Student_EdPlatform_Id

ALTER TABLE Teachers
DROP Constraint FK_Teachers_EdPlatform_Id

ALTER TABLE Teachers
DROP COLUMN EdPlatform

ALTER TABLE Students
DROP COLUMN EdPlatform

DROP TABLE EdPlatform

Create TABLE EdPlatform(
	Id uniqueidentifier PRIMARY KEY not null DEFAULT newid(),
	Name nvarchar(64) not null,
	Language nvarchar(8) not null DEFAULT 'en',
	PlatformTheme int not null DEFAULT 0,
)

ALTER TABLE Student
Add EdPlatform uniqueidentifier;

ALTER TABLE Student
Add constraint FK_Student_EdPlatform_Id FOREIGN KEY(EdPlatform)
REFERENCES EdPlatform(Id)

ALTER TABLE Teachers
Add EdPlatform uniqueidentifier;

ALTER TABLE Teachers
Add constraint FK_Teachers_EdPlatform_Id FOREIGN KEY(EdPlatform)
REFERENCES EdPlatform(Id)

ALTER TABLE LessonStudentList DROP CONSTRAINT FK__LessonStu__Stude__2BFE89A6;
Alter table LessonScore drop constraint FK__LessonSco__Stude__2FCF1A8A;

DROP TABLE Student;

Select * from student;

CREATE TABLE Student (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DOB DATE NULL
);
Select  * from Student
INSERT INTO Student (Name, LastName, DOB) VALUES ('John', 'Doe', '2000-01-01');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Jane', 'Smith', '1999-02-15');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Michael', 'Johnson', '2001-03-10');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Emily', 'Davis', '2002-04-05');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Matthew', 'Brown', '2003-05-20');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Olivia', 'Wilson', '2004-06-25');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Daniel', 'Moore', '2005-07-30');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Sophia', 'Taylor', '2006-08-15');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Alexander', 'Anderson', '2007-09-05');
INSERT INTO Student (Name, LastName, DOB) VALUES ('Emma', 'Thomas', '2008-10-10');    
           

ALTER TABLE Student
Add EdPlatform uniqueidentifier;

ALTER TABLE Student
Add constraint FK_Student_EdPlatform_Id FOREIGN KEY(EdPlatform)
REFERENCES EdPlatform(Id)

ALTER TABLE LessonScore
DROP CONSTRAINT FK__LessonSco__Lesso__2EDAF651

ALTER TABLE LessonScore
ADD NewStudentID UNIQUEIDENTIFIER;

UPDATE LessonScore
SET NewStudentID = sm.NewId
FROM LessonScore ls
JOIN Student sm ON ls.StudentID = sm.OldId;

ALTER TABLE LessonScore
DROP COLUMN StudentID;

ALTER TABLE LessonScore
ALTER COLUMN StudentID UNIQUEIDENTIFIER;

ALTER TABLE LessonScore
ADD CONSTRAINT FK__LessonScore_Student FOREIGN KEY (StudentID) REFERENCES Student(Id);

ALTER TABLE LessonStudentList
DROP CONSTRAINT FK__LessonStuden__Id__2B0A656D;

ALTER TABLE LessonStudentList
DROP CONSTRAINT PK__LessonStudentList

SELECT StudentID AS OldId, NEWID() AS NewId
INTO StudentMapping
FROM LessonStudentList;


ALTER TABLE LessonStudentList
ADD StudentID UNIQUEIDENTIFIER;

UPDATE LessonStudentList
SET NewStudentID = sm.NewId
FROM LessonStudentList ls
JOIN StudentMapping sm ON ls.StudentID = sm.OldId;


ALTER TABLE LessonStudentList
DROP COLUMN StudentID;

EXEC sp_rename 'LessonStudentList.NewStudentID', 'StudentID', 'COLUMN'

ALTER TABLE LessonStudentList
ALTER COLUMN StudentID UNIQUEIDENTIFIER NOT NULL;

ALTER TABLE LessonStudentList
ADD CONSTRAINT PK_LessonStudentList PRIMARY KEY (LessonID, StudentID);

ALTER TABLE LessonStudentList
ADD CONSTRAINT FK__LessonStudentList_Student FOREIGN KEY (StudentID) REFERENCES Student(Id);


DROP TABLE StudentMapping;

DROP TABLE LessonStudentList;

CREATE TABLE LessonStudentList (
    LessonID UNIQUEIDENTIFIER NOT NULL,
    StudentID UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (LessonID, StudentID));

ALTER TABLE LessonStudentList
ADD CONSTRAINT FK_LessonStudentList_Lesson_Id
FOREIGN KEY (LessonID) REFERENCES Lesson(Id);