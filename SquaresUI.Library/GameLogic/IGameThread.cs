using SquaresUI.Library.Models.GameModels;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic
{
    public interface IGameThread
    {
        Task Move(PointModel p1, PointModel p2);
        void InsertPlayerModels(PlayerModel player1, PlayerModel player2);
        Task InsertLogin(string username, string password);
    }
}