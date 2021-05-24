using SquaresUI.Library.Models.GameModels;

namespace SquaresUI.Library.GameLogic.WinnerLogic
{
    public interface IWinnerLogic
    {
        PlayerModel FindWinner();
        bool HasWon();
        void InsertPlayerModels(PlayerModel player1, PlayerModel player2);
    }
}