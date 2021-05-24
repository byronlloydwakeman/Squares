using SquaresUI.Library.GameLogic.GoLogic;
using SquaresUI.Library.GameLogic.HighScoreLogic;
using SquaresUI.Library.GameLogic.WinnerLogic;
using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic
{
    public class GameThread : IGameThread
    {
        private IGoLogic _goLogic;
        private IHighScoreLogic _highScoreLogic;
        private IWinnerLogic _winnerLogic;

        public GameThread(PlayerModel player1, PlayerModel player2, IGoLogic goLogic, IHighScoreLogic highScoreLogic, IWinnerLogic winnerLogic)
        {
            _goLogic = goLogic;
            _highScoreLogic = highScoreLogic;
            _winnerLogic = winnerLogic;
            _winnerLogic.InsertPlayerModels(player1, player2);

            //Initializes board when an instance of the the class is made (the game has started)
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            //Adds the lines to the lists in board model
            BoardModel board = new BoardModel();
            //Add instance to go logic
            _goLogic.InsertBoardModel(board);
        }


        public void Move(PointModel p1, PointModel p2)
        {
            //Find line in array and activate
            _goLogic.ActivateLine(p1, p2);

            //Check whether square has been made
            bool hasSquareBeenMade = _goLogic.HasSquareBeenMade();

            //Check whether a sqaure has been made
            if (hasSquareBeenMade)
            {
                //Add score onto whoevers go it is

                //Check if the game has been won
                if (_winnerLogic.HasWon())
                {
                    //If won find who the winner is and set highscores if needed
                    PlayerModel winner = _winnerLogic.FindWinner();
                    if (_highScoreLogic.IsNewHighScore(winner))
                    {
                        _highScoreLogic.AddNewHighScore(winner);
                    }
                }
            }
            else //If not switch goes and carry on playing
            {
                _goLogic.SwitchGoes();
            }
        }

    }
}
