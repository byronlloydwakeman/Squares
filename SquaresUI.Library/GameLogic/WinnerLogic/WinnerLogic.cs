using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic.WinnerLogic
{
    public class WinnerLogic : IWinnerLogic
    {
        private int MaxScore { get; set; }
        private PlayerModel _player1;
        private PlayerModel _player2;

        public void InsertPlayerModels(PlayerModel player1, PlayerModel player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void InsertMaxScore(int maxScore)
        {
            MaxScore = maxScore;
        }

        /// <summary>
        /// Finds whos go it is and adds a point to their score
        /// </summary>
        public void AddPoint(int point)
        {
            if (_player1.IsGo)
            {
                _player1.Score += point;
            }
            else
            {
                _player2.Score += point;
            }
        }

        /// <summary>
        /// Checks the sum of the score of both players to see if the game has been won, if so return true, if not false 
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            if ((_player1.Score + _player2.Score) == MaxScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Find which player has the larger score and return that player
        /// </summary>
        /// <returns></returns>
        public PlayerModel FindWinner()
        {
            if (_player1.Score > _player2.Score)
            {
                return _player1;
            }
            else
            {
                return _player2;
            }
        }
    }
}
