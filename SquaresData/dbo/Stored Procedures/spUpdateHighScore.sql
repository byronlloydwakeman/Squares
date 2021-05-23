CREATE PROCEDURE [dbo].[spUpdateHighScore]
	@LoggedInUser nvarchar(50),
	@UserName nvarchar(50),
	@BoardSize int,
	@Date datetime2(7),
	@HighScore int
AS
begin 
	update HighScores
	set HighScore = @HighScore, BoardSize = @BoardSize, [Date] = @Date, LoggedInUser = @LoggedInUser
	where UserName = @UserName;
end
