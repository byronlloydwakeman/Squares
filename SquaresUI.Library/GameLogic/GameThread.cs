using Autofac;
using SquaresExceptions;
using SquaresUI.Library.AutoFac;
using SquaresUI.Library.GameLogic.GoLogic;
using SquaresUI.Library.GameLogic.HighScoreLogic;
using SquaresUI.Library.GameLogic.WinnerLogic;
using SquaresUI.Library.Models.GameModels;
using SquaresUI.Library.Validation;
using SquaresUI.Library.Validation.LineValidation;
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
        private IBoardModel _boardModel;
        private ILineValidation _lineValidation;
        //Note the player models aren't needed theyre just being used to show the state of the players
        private PlayerModel _player1;
        private PlayerModel _player2;

        public GameThread(IGoLogic goLogic, IHighScoreLogic highScoreLogic, IWinnerLogic winnerLogic, IBoardModel boardModel, ILineValidation lineValidation)
        {
            _goLogic = goLogic;
            _highScoreLogic = highScoreLogic;
            _winnerLogic = winnerLogic;
            _boardModel = boardModel;
            _lineValidation = lineValidation;
            //Initializes board when an instance of the the class is made (the game has started)
            InitializeBoard();
        }

        public async Task InsertLogin(string username, string password)
        {
            await _highScoreLogic.Login(username, password);
        }

        public void InsertPlayerModels(PlayerModel player1, PlayerModel player2)
        {
            _player1 = player1;
            _player2 = player2;
            _winnerLogic.InsertPlayerModels(player1, player2);
            _goLogic.InsertPlayerModel(player1, player2);
        }

        private void InitializeBoard()
        {
            _winnerLogic.InsertMaxScore(_boardModel.Squares.Count);
            _highScoreLogic.InsertBoardSize(_boardModel.Squares.Count);
        }

        /// <summary>
        /// Method to call to perform a move, returns true if the game has ended false if not
        /// </summary>
        public async Task<bool> Move(PointModel p1, PointModel p2)
        {
            //Find line in array and activate
            _goLogic.ActivateLine(p1, p2);

            //Check input points are valid
            if (!_lineValidation.DoesLineExist(p1, p2))
            {
                throw new InvalidLineException(p1.XCoord, p1.YCoord, p2.XCoord, p2.YCoord);
            }

            //Check the line hasnt already been activated
            if (_lineValidation.HasLineBeenPlaced(p1, p2))
            {
                throw new LineActivatedException(p1.XCoord, p1.YCoord, p2.XCoord, p2.YCoord);
            }
            
            ShowBoard();
            ShowPlayers();

            //Check whether square has been made
            int SquaresMade = _goLogic.HasSquareBeenMade();

            //If a square has been made
            if (SquaresMade > 0)
            {
                Console.WriteLine("Square has been made");
                //Add score onto whoevers go it is
                _winnerLogic.AddPoint(SquaresMade);

                //Check if the game has been won
                if (_winnerLogic.HasWon())
                {
                    //If won find who the winner is and set highscores if needed
                    PlayerModel winner = _winnerLogic.FindWinner();
                    bool newHigh = await _highScoreLogic.IsNewHighScore(winner);
                    if(newHigh)
                    {
                        _highScoreLogic.AddNewHighScore(winner);
                    }
                    return true;
                }
                
            }
            else //If not switch goes and carry on playing
            {
                _goLogic.SwitchGoes();
            }

            return false;
        }

        public void ShowPlayers()
        {
            Console.WriteLine(_player1);
            Console.WriteLine(_player2);
        }

        public void ShowBoard()
        {
            Console.WriteLine("Lines : ");
            foreach (var item in _boardModel.Lines)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Squares : ");
            for (int i = 0; i < _boardModel.Squares.Count; i++)
            {
                Console.WriteLine($"Square {i + 1}");
                for (int j = 0; j < _boardModel.Squares[i].Count; j++)
                {
                    Console.WriteLine(_boardModel.Squares[i][j]);
                }
            }
        }


    }
}
