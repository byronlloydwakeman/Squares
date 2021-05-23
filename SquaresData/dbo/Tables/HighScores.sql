CREATE TABLE [dbo].[HighScores]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [LoggedInUser] NVARCHAR(50) NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [BoardSize] INT NULL, 
    [Date] DATETIME2 NULL, 
    [HighScore] INT NULL
)
