CREATE TABLE [dbo].[Users]
(
	[User_Id] INT NOT NULL, 
    [First_Name] CHAR(10) NULL, 
    [Last_Name] CHAR(10) NULL, 
    [Email] NCHAR(30) NOT NULL, 
    [Password_Hash] NCHAR(20) NOT NULL, 
    [Username] NCHAR(20) NOT NULL, 
    [Project_Id] INT NULL
	CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED ([User_Id] ASC)
);
