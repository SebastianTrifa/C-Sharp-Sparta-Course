CREATE TABLE [dbo].[Projects]
(
	[Project_Id] INT NOT NULL IDENTITY, 
    [Manager_Id] INT NOT NULL, 
    [Proj_Desc] NTEXT NULL, 
    [Proj_Name] NCHAR(20) NOT NULL, 
    [WorKType] NCHAR(20) NULL, 
    [Parent_Id] INT NULL
	CONSTRAINT [PK_PROJECTS] PRIMARY KEY CLUSTERED ([Project_Id] ASC)
	CONSTRAINT [FK_PROJECTS_MANAGER] FOREIGN KEY ([Manager_Id]) REFERENCES [dbo].[Users] ([User_Id]),
	CONSTRAINT [FK_PROJECTS_PROJECTS] FOREIGN KEY ([Parent_Id]) REFERENCES [dbo].[Projects] ([Project_Id])
);
