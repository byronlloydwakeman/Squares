using SquaresUI.Library.Models.GameModels;

namespace SquaresUI.Library.GameLogic.HighScoreLogic
{
    public interface IHighScoreLogic
    {
        void AddNewHighScore(PlayerModel player);
        bool IsNewHighScore(PlayerModel player);
    }
}