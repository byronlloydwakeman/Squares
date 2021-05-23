CREATE PROCEDURE [dbo].[spGetHighScores]

AS
begin
	select *
	from HighScores
	order by HighScore desc;
end