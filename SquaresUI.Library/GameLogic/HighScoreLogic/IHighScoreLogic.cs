using SquaresUI.Library.Models.GameModels;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic.HighScoreLogic
{
    public interface IHighScoreLogic
    {
        void AddNewHighScore(PlayerModel player);
        Task Login(string username, string password);
        Task<bool> IsNewHighScore(PlayerModel player);
        void InsertBoardSize(int boardSize);
    }
}