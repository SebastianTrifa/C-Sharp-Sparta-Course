GO
CREATE TABLE [dbo].[Projects]
(
	[Project_Id] INT NOT NULL IDENTITY, 
    [Manager_Id] INT NOT NULL, 
    [Proj_Desc] NTEXT NULL, 
    [Proj_Name] NCHAR(20) NOT NULL, 
    [WorKType] NCHAR(20) NULL, 
	CONSTRAINT [PK_PROJECTS] PRIMARY KEY CLUSTERED ([Project_Id] ASC),
	CONSTRAINT [FK_PROJECTS_MANAGER] FOREIGN KEY ([Manager_Id]) REFERENCES [dbo].[Users] ([User_Id])
)

GO
CREATE TABLE [dbo].[Timesheets]
(
	[Timesheet_Id] INT NOT NULL, 
    [Start_Date] DATETIME NOT NULL, 
    [Hours_Worked] INT NOT NULL DEFAULT 0, 
    [User_Id] INT NOT NULL, 
    [ApprovedBy_UserId] INT NOT NULL, 
    [Project_Id] INT NOT NULL,
	[CEO] BIT NOT NULL,
	CONSTRAINT [PK_TIMESHEETS] PRIMARY KEY CLUSTERED ([Timesheet_Id] ASC),
	CONSTRAINT [FK_TIMESHEETS_PROJECTS] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Project_Id]),
	CONSTRAINT [FK_TIMESHEETS_MANAGERS] FOREIGN KEY ([ApprovedBy_UserId]) REFERENCES [dbo].[Users] ([User_Id]),
	CONSTRAINT [FK_TIMESHEETS_USERS] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([User_Id])
)

GO
CREATE TABLE [dbo].[Users]
(
	[User_Id] INT NOT NULL, 
    [First_Name] CHAR(10) NULL, 
    [Last_Name] CHAR(10) NULL, 
    [Email] NCHAR(30) NOT NULL, 
    [Password_Hash] NCHAR(20) NOT NULL, 
    [Username] NCHAR(20) NOT NULL, 
    [Project_Id] INT NULL,
	CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED ([User_Id] ASC),
	CONSTRAINT [FK_USERS_PROJECT] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Project_Id]),
)

GO
CREATE TABLE [dbo].[Project_Relationships]
(
	[Relationship_Id] INT NOT NULL,
	[Parent_Id] INT NULL,
	[Child_Id] INT NOT NULL,
	CONSTRAINT [PK_RELATIONSHIPS] PRIMARY KEY CLUSTERED ([Relationship_Id] ASC),
	CONSTRAINT [FK_RELATIONSHIPS_PARENT] FOREIGN KEY ([Parent_Id]) REFERENCES [dbo].[Projects] ([Project_Id]),
	CONSTRAINT [FK_RELATIONSHIPS_CHILD] FOREIGN KEY ([Child_Id]) REFERENCES [dbo].[Projects] ([Project_Id]),
);