use Northwind
GO
DROP database ToDo
GO
CREATE database ToDo
GO
use ToDo
GO
CREATE TABLE Categories
(
	[CategoryID] INT NOT NULL IDENTITY PRIMARY KEY,
    [CategoryName] NVARCHAR(50) NULL,
);

GO
CREATE TABLE Users
(
	[UserID] INT NOT NULL IDENTITY PRIMARY KEY,
    [UserName] NVARCHAR(50) NULL,
);

GO
CREATE TABLE Tasks
(
	[TaskId] INT NOT NULL IDENTITY PRIMARY KEY,
    [TaskDescription] NVARCHAR(50) NULL,
    [Done] bit NULL,
    [DateStarted] DATE NOT NULL,
    [DateFinished] DATE NULL,
    [CategoryID] INT NULL FOREIGN KEY REFERENCES Categories(CategoryID),
    [UserID] INT NULL FOREIGN KEY REFERENCES Users(UserID),
);

INSERT INTO Categories (CategoryName) VALUES ('Home');
INSERT INTO Categories (CategoryName) VALUES ('Work');
INSERT INTO Categories (CategoryName) VALUES ('Leisure');
INSERT INTO Categories (CategoryName) VALUES ('Hobbies');

INSERT INTO Users (UserName) VALUES ('Alex');
INSERT INTO Users (UserName) VALUES ('Bob');
INSERT INTO Users (UserName) VALUES ('Henry');

INSERT INTO Tasks (TaskDescription, Done, DateStarted, DateFinished, CategoryID, UserID) VALUES ('ForWork', 'true', GETDATE(), GETDATE(), 2, 1);
INSERT INTO Tasks (TaskDescription, Done, DateStarted, DateFinished, CategoryID, UserID) VALUES ('ForHome', 'False', GETDATE(), GETDATE(), 1, 2);
INSERT INTO Tasks (TaskDescription, Done, DateStarted, DateFinished, CategoryID, UserID) VALUES ('ForWork', 'True', dateadd(d,-1,getdate()), GETDATE(), 2, 3);
