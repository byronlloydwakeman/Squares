using SquaresUI.Library.Models.GameModels;

namespace SquaresUI.Library.GameLogic
{
    public interface IGameThread
    {
        void Move(PointModel p1, PointModel p2);
    }
}