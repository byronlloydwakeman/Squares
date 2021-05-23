CREATE PROCEDURE [dbo].[spInsertHighScore]
	@LoggedInUser nvarchar(50),
	@UserName nvarchar(50),
	@BoardSize int,
	@Date datetime2(7),
	@HighScore int
AS
begin
	insert into dbo.HighScores(LoggedInUser, UserName, BoardSize, [Date], HighScore)
	values (@LoggedInUser, @UserName, @BoardSize, @Date, @HighScore);
end
