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