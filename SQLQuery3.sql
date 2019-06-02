USE [ToDo]
GO

DROP TABLE IF EXISTS [dbo].[Tasks];
GO
DROP TABLE IF EXISTS [dbo].[Categories];
GO
DROP TABLE IF EXISTS [dbo].[Users];
GO

CREATE TABLE [dbo].[Categories] (
    [CategoryID]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);


CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

CREATE TABLE [dbo].[Tasks] (
    [TaskId]          INT           IDENTITY (1, 1) NOT NULL,
    [TaskDescription] NVARCHAR (50) NULL,
    [Done]            BIT           NULL,
    [DateStarted]     DATE          NOT NULL,
    [DateFinished]    DATE          NULL,
    [CategoryID]      INT           NULL,
    [UserID]          INT           NULL,
	[Deadline]        DATE			NULL,
    PRIMARY KEY CLUSTERED ([TaskId] ASC),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([CategoryID]),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Home')
INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Work')
INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Leisure')
INSERT INTO [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Hobbies')
SET IDENTITY_INSERT [dbo].[Categories] OFF



SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [UserName]) VALUES (1, N'Alex')
INSERT INTO [dbo].[Users] ([UserID], [UserName]) VALUES (2, N'Bob')
INSERT INTO [dbo].[Users] ([UserID], [UserName]) VALUES (3, N'Henry')
INSERT INTO [dbo].[Users] ([UserID], [UserName]) VALUES (4, N'Andrew')
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Tasks] ON
INSERT INTO [dbo].[Tasks] ([TaskId], [TaskDescription], [Done], [DateStarted], [DateFinished], [CategoryID], [UserID]) VALUES (1, N'ForWork', 1, N'2019-05-24', N'2019-05-24', 2, 1)
INSERT INTO [dbo].[Tasks] ([TaskId], [TaskDescription], [Done], [DateStarted], [DateFinished], [CategoryID], [UserID]) VALUES (2, N'ForHome', 0, N'2019-05-24', N'2019-05-24', 1, 2)
INSERT INTO [dbo].[Tasks] ([TaskId], [TaskDescription], [Done], [DateStarted], [DateFinished], [CategoryID], [UserID]) VALUES (3, N'ForWork', 1, N'2019-05-23', N'2019-05-24', 2, 3)
INSERT INTO [dbo].[Tasks] ([TaskId], [TaskDescription], [Done], [DateStarted], [DateFinished], [CategoryID], [UserID]) VALUES (4, N'ForWork', 1, N'2019-05-24', N'2019-05-25', 2, 1)
INSERT INTO [dbo].[Tasks] ([TaskId], [TaskDescription], [Done], [DateStarted], [DateFinished], [CategoryID], [UserID]) VALUES (6, N'ForHome', 0, N'2019-05-14', NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Tasks] OFF