CREATE DATABASE LearningPortal
GO

CREATE TABLE Student (
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),  -- UUID type with default value generator
    Name VARCHAR(50) NOT NULL,                      -- VARCHAR instead of NVARCHAR
    LastName VARCHAR(50) NOT NULL,                  -- VARCHAR instead of NVARCHAR
    DOB DATE NULL                                    -- Same DATE type
);

-- Insert Data
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
