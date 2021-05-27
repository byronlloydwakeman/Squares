using SquaresUI.Library.Models.GameModels;

namespace SquaresUI.Library.Validation.LineValidation
{
    public interface ILineValidation
    {
        bool ArePointsAdjacent(PointModel p1, PointModel p2);
        bool HasLineBeenPlaced(PointModel p1, PointModel p2);
        bool DoesLineExist(PointModel p1, PointModel p2);
    }
}