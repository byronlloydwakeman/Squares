using SquaresUI.Library.Models.GameModels;

namespace SquaresUI.Library.GameLogic.GoLogic
{
    public interface IGoLogic
    {
        void ActivateLine(PointModel p1, PointModel p2);
        bool HasSquareBeenMade();
        void InsertBoardModel(BoardModel boardModel);
        void SwitchGoes();
    }
}