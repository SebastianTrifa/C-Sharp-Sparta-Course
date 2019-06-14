use Northwind
GO
DROP database Sparta
GO
CREATE database Sparta
GO
use Sparta

GO
CREATE TABLE Specialisations
(
	[SpecID] INT NOT NULL IDENTITY PRIMARY KEY,
    [SpecName] NVARCHAR(50) NULL,
);

GO
CREATE TABLE Cohorts
(
	[CohortID] INT NOT NULL IDENTITY PRIMARY KEY,
    [CohortName] NVARCHAR(50) NULL,
    [SpecID] INT NULL FOREIGN KEY REFERENCES Specialisations(SpecID),
);

GO
CREATE TABLE Roles
(
	[RoleID] INT NOT NULL IDENTITY PRIMARY KEY,
    [RoleName] NVARCHAR(50) NULL,
);

GO
CREATE TABLE Users
(
	[UserID] INT NOT NULL IDENTITY PRIMARY KEY,
    [FirstName] NVARCHAR(50) NULL,
    [LastName] NVARCHAR(50) NULL,
    [Email] NVARCHAR(50) NULL,
    [Password] NVARCHAR(50) NULL,
    [CohortID] INT NULL FOREIGN KEY REFERENCES Cohorts(CohortID),
    [RoleID] INT NULL FOREIGN KEY REFERENCES Roles(RoleID),
);

INSERT INTO Roles (RoleName) VALUES ('Trainer');
INSERT INTO Roles (RoleName) VALUES ('Trainee');
INSERT INTO Roles (RoleName) VALUES ('Admin');

INSERT INTO Specialisations(SpecName) VALUES ('DevOps');
INSERT INTO Specialisations(SpecName) VALUES ('C#');
INSERT INTO Specialisations(SpecName) VALUES ('Javascript');
INSERT INTO Specialisations(SpecName) VALUES ('Business');
INSERT INTO Specialisations(SpecName) VALUES ('Data');

INSERT INTO Cohorts(CohortName, SpecID) VALUES ('Eng-31',2);
INSERT INTO Cohorts(CohortName, SpecID) VALUES ('Data',5);
INSERT INTO Cohorts(CohortName, SpecID) VALUES ('Eng-30',3);

INSERT INTO Users (FirstName, LastName, Email, [Password], CohortID, RoleID) VALUES ('Sebastian', 'Trifa', 'strifa@spartaglobal.com', 'Pa$$w0rd', 1, 2);
INSERT INTO Users (FirstName, LastName, Email, [Password], CohortID, RoleID) VALUES ('Phil', 'Anderson', 'panderson@spartaglobal.com', 'Pa$$w0rd', 1, 1);
INSERT INTO Users (FirstName, LastName, Email, [Password], CohortID, RoleID) VALUES ('Luitzen', 'Hietkamp', 'lhietkamp@spartaglobal.com', 'Pa$$w0rd', 1, 2);
INSERT INTO Users (FirstName, LastName, Email, [Password], CohortID, RoleID) VALUES ('Li', 'Dinh', 'ldinh@spartaglobal.com', 'Pa$$w0rd', 1, 2);
INSERT INTO Users (FirstName, LastName, Email, [Password], CohortID, RoleID) VALUES ('Jaspreet', 'Rai', 'jrai@spartaglobal.com', 'Pa$$w0rd', 1, 2);