using SquaresUI.Library.Models;
using SquaresUI.Library.Models.GameModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic
{
    public interface IGameThread
    {
        Task<bool> Move(PointModel p1, PointModel p2);
        void InsertPlayerModels(PlayerModel player1, PlayerModel player2);
        Task InsertLogin(string username, string password);
        int ReturnPlayer1Score();
        int ReturnPlayer2Score();
        bool IsPlayer1Go();
    }
}