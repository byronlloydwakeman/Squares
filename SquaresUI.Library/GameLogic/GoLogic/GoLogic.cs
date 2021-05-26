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
        private IBoardModel _boardModel;
        private PlayerModel _player1;
        private PlayerModel _player2;

        public void InsertBoardModel(IBoardModel boardModel)
        {
            _boardModel = boardModel;
        }

        public void InsertPlayerModel(PlayerModel player1, PlayerModel player2)
        {
            _player2 = player2;
            _player1 = player1;
        }

        /// <summary>
        /// Search for line which connects p1 and p2 and activate it
        /// </summary>
        public void ActivateLine(PointModel p1, PointModel p2)
        {
            foreach (var item in _boardModel.Lines)
            {
                if((item.Point1.XCoord == p1.XCoord) && (item.Point2.XCoord == p2.XCoord) && (item.Point1.YCoord == p1.YCoord) && (item.Point2.YCoord == p2.YCoord))
                {
                    item.IsActivated = true;
                }
            }
        }

        /// <summary>
        /// Checks whether a square has been made if so returns true, false if not
        /// </summary>
        public bool HasSquareBeenMade()
        {
            for (int i = 0; i < _boardModel.Squares.Count; i++)
            {
                bool isSquareActivated = true;
                foreach (var item in _boardModel.Squares[i])
                {
                    if(!item.IsActivated)
                    {
                        isSquareActivated = false;
                    }
                }
                if (isSquareActivated)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Switch the goes of the players with an xor operation
        /// </summary>
        public void SwitchGoes()
        {
            _player1.IsGo ^= true;
            _player2.IsGo ^= true;
        }
    }
}
