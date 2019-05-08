CREATE TABLE [dbo].[Timesheets]
(
	[Timesheet_Id] INT NOT NULL, 
    [Start_Date] DATETIME NOT NULL, 
    [Hours_Worked] INT NOT NULL DEFAULT 0, 
    [User_Id] INT NOT NULL, 
    [ApprovedBy_UserId] INT NOT NULL, 
    [Project_Id] INT NOT NULL,
	CONSTRAINT [PK_TIMESHEETS] PRIMARY KEY CLUSTERED ([Timesheet_Id] ASC),
	CONSTRAINT [FK_TIMESHEETS_PROJECTS] FOREIGN KEY ([Project_Id]) REFERENCES [dbo].[Projects] ([Project_Id]),
	CONSTRAINT [FK_TIMESHEETS_MANAGERS] FOREIGN KEY ([ApprovedBy_UserId]) REFERENCES [dbo].[Users] ([User_Id]),
	CONSTRAINT [FK_TIMESHEETS_USERS] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([User_Id])
);
