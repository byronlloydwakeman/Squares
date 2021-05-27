using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Validation.LineValidation
{
    public class LineValidation : ILineValidation
    {
        private IBoardModel _boardModel;
        public LineValidation(IBoardModel boardModel)
        {
            _boardModel = boardModel;
        }

        public bool ArePointsAdjacent(PointModel p1, PointModel p2)
        {
            //Take p1 as the reference point
            bool adjacent = false;

            //Check if theyre on the same column and adjacent
            //If its above, or if its below
            if (((p1.XCoord == p2.XCoord) && (p1.YCoord == p2.YCoord - 1)) || ((p1.XCoord == p2.XCoord) && (p1.YCoord == p2.YCoord + 1)))
            {
                adjacent = true;
            }

            //If its to the left, or if its to the right
            if (((p1.YCoord == p2.YCoord) && (p1.XCoord == p2.XCoord + 1)) || ((p1.YCoord == p2.YCoord) && (p1.XCoord == p2.XCoord - 1)))
            {
                adjacent = true;
            }

            return adjacent;
        }

        public bool HasLineBeenPlaced(PointModel p1, PointModel p2)
        {
            bool beenPlaced = false;

            foreach (var line in _boardModel.Lines)
            {
                //Find given line
                if(((line.Point1 == p1) && (line.Point2 == p2)) || ((line.Point1 == p2) && (line.Point2 == p1)))
                {
                    if (line.IsActivated == true)
                    {
                        beenPlaced = true;
                    }
                }
            }

            return beenPlaced;
        }

        public bool DoesLineExist(PointModel p1, PointModel p2)
        {
            bool onBoard = false;

            foreach (var line in _boardModel.Lines)
            {
                if (((line.Point1 == p1) && (line.Point2 == p2)) || ((line.Point1 == p2) && (line.Point2 == p1)))
                {
                    onBoard = true;
                }
            }

            return onBoard;
        }
    }
}
