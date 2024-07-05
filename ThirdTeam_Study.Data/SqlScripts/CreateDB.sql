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

