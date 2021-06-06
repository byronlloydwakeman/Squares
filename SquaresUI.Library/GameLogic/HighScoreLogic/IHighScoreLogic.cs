using SquaresUI.Library.Models;
using SquaresUI.Library.Models.GameModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic.HighScoreLogic
{
    public interface IHighScoreLogic
    {
        void AddNewHighScore(PlayerModel player);
        Task Login(string username, string password);
        Task<bool> IsNewHighScore(PlayerModel player);
        void InsertBoardSize(int boardSize);
        Task<List<HighScoreUIModel>> ReturnHighscoresByOldest();
        Task<List<HighScoreUIModel>> ReturnHighscoresByNewest();
        Task<List<HighScoreUIModel>> ReturnHighscoresByAlpha();
        Task<List<HighScoreUIModel>> ReturnHighscoreByScore();
    }
}