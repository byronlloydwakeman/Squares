using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic.GoLogic
{
    public class GoLogic : IGoLogic
    {
        private BoardModel _boardModel;

        public void InsertBoardModel(BoardModel boardModel)
        {
            _boardModel = boardModel;
        }

        /// <summary>
        /// Search for line which connects p1 and p2 and activate it
        /// </summary>
        public void ActivateLine(PointModel p1, PointModel p2)
        {

        }

        /// <summary>
        /// Checks whether a sqaure has been made if so returns true, false if not
        /// </summary>
        public bool HasSquareBeenMade()
        {
            return false;
        }

        /// <summary>
        /// Switch the goes of the players with an xor operation
        /// </summary>
        public void SwitchGoes()
        {

        }
    }
}
