using Autofac;
using Caliburn.Micro;
using SquaresDesktopUI.ButtonHelper;
using SquaresExceptions;
using SquaresUI.Library.AutoFac;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SquaresDesktopUI.ViewModels
{
    public class GameViewModel : Screen
    {
        private IGameThread _gameThread;
        private IBoardModel _boardModel;

        private Button _button1; //So we can change its color after the second button has been chosen
        private PointModel _pointModel1;
        private PointModel _pointModel2;
        private bool _newGo = true;
        private bool _blueGo = true;
        private bool _gameEnded = false;
        private SolidColorBrush _currentColor = Brushes.Red;

        private List<Brush> _UILines = new List<Brush>();
        public List<Brush> UILines
        {
            get { return _UILines; }
            set 
            { 
                _UILines = value;
                NotifyOfPropertyChange(() => UILines);
            }
        }

        private List<Brush> _UISquares = new List<Brush>();

        public List<Brush> UISquares
        {
            get { return _UISquares; }
            set
            { 
                _UISquares = value;
                NotifyOfPropertyChange(() => UISquares);
            }
        }


        public GameViewModel(IGameThread gameThread, IBoardModel boardModel)
        {
            _boardModel = boardModel;
            _gameThread = gameThread;
            InitializeUIBoard(); //Add colors to lines and squares
        }

        private void InitializeUIBoard()
        {
            for (int i = 0; i < _boardModel.Lines.Count; i++)
            {
                UILines.Add(Brushes.White);
            }

            for (int i = 0; i < _boardModel.Squares.Count; i++)
            {
                UISquares.Add(Brushes.Transparent);
            }
        }

        public async Task ButtonClicked(Button button)
        {
            //Set the current color depending on whether its blue or reds go
            SetCurrentColor();

            //If the 'first' button has been selected (first in this context meaning first of the two points to create a line)
            if (_newGo)
            {
                //Get the button thats been converted and convert it to a point model so it can be used as a parameter for move
                _pointModel1 = Conversion.ButtonNameToPointModel(button.Name);
                _button1 = button; //Save the button for later so we can change its background after the move has been validated
            }
            //If its the second point being selected
            else
            {
                //Convert the second button into a point model so it can be passed through moved aswell
                _pointModel2 = Conversion.ButtonNameToPointModel(button.Name);

                //Then do the move
                try //In try catch as if the library throws an error if the points are invalid, then we can catch the exception
                {
                    await PerformMove(_pointModel1, _pointModel2);

                    ColorButtons(button); //Color in selected buttons

                    ColorLines();

                    ColorSquares();

                    _blueGo = _gameThread.IsPlayer1Go(); //Tie to the back end so we dont have to have logic in the front end
                }
                catch (Exception e)
                {
                    //Show any errors as a pop up
                    MessageBox.Show(e.Message);          
                }
            }

            ChangeButtonGoes();

            //Check game hasnt ended 
            if (_gameEnded)
            {
                MessageBox.Show("game has ended");
            }
        }

        private void SetCurrentColor()
        {
            //Set the appropriate brush color
            if (_blueGo)
            {
                _currentColor = Brushes.CornflowerBlue;
            }
            else
            {
                _currentColor = Brushes.Red;
            }
        }

        private void ColorLines()
        {
            //Loop through every line ui line and library line and check whether its been activated and its color is white or blank
            //as this means its just been activated and we need to change its color

            //As the UI is a pain, we can bind elements to a list to the UI rectangles but with NotifyOfPropertyChange() it notifies that the list has changed not the elements in the list
            //so we need to change the instance of the list so it gets updated, so in order to do this we've created a temp list called newLines, which will hold the previous and new colors 
            List<Brush> newLines = new List<Brush>();
            List<LineModel> backEndLines = _boardModel.Lines;

            for (int i = 0; i < UILines.Count; i++)
            {
                bool isLineActive = backEndLines[i].IsActivated == true; //If the line has been selected or not
                if (isLineActive && (UILines[i] != Brushes.CornflowerBlue && UILines[i] != Brushes.Red)) //If the line has been selected for a first time
                {
                    //Change the current list to a new list but with the one color change

                    for (int j = 0; j < 144; j++)
                    {
                        if (j == i) //The just selected line
                        {
                            newLines.Add(_currentColor);
                        }
                        else if ((UILines[j] == Brushes.CornflowerBlue) || (UILines[j] == Brushes.Red)) //If there was a previous color there
                        {
                            newLines.Add(UILines[j]);
                        }
                        else //if neither make the line whitespace
                        {
                            newLines.Add(Brushes.White);
                        }
                    }
                    break;
                }
            }


            //Update the new list
            UILines = newLines;

            //Note all this works because the lines in the library have the same respective index as the line in the UI, so the given index is the same for them both
        }

        private void ColorButtons(Button button2)
        {
            //Any errors with the points would have been thrown from calling move, meaning at this point theyre valid so we can change their backgrounds
            _button1.Background = _currentColor;
            button2.Background = _currentColor;
        }

        private void ColorSquares()
        {
            //Loop through library and ui squares check if theyre valid and that they havent already been activated

            //New Squares color list to set its instance to
            List<Brush> newSquares = new List<Brush>();
            List<List<LineModel>> backEndSquares = _boardModel.Squares;

            //Multiple squares couldve been activated in one go so we need a list to store the indexs
            List<int> squareIndex = new List<int>();

            //Loop through squares, check if the square is activated by looping through each line and checking if theyre activated
            for (int i = 0; i < backEndSquares.Count; i++)
            {
                bool isSquareActivated = true;
                foreach (var line in backEndSquares[i])
                {  
                    if (line.IsActivated != true)
                    {
                        //If one or more of the lines isnt activated then the square isnt activated
                        isSquareActivated = false;  
                    }
                }
                if (isSquareActivated == true)
                {
                    squareIndex.Add(i);
                }
            } //This loop is to find the index's of the squares that have been activated

            for (int i = 0; i < backEndSquares.Count; i++)
            {
                //If the given square has just been actived 
                if ((squareIndex.Contains(i)) && (UISquares[i] != Brushes.CornflowerBlue && UISquares[i] != Brushes.Red)) 
                {
                    newSquares.Add(_currentColor);
                }
                //Add any previous colors
                else if(UISquares[i] == Brushes.Red || UISquares[i] == Brushes.CornflowerBlue)
                {
                    newSquares.Add(UISquares[i]);
                }
                else
                {
                    newSquares.Add(Brushes.Transparent);
                }
            }

            UISquares = newSquares;
        }

        private async Task PerformMove(PointModel p1, PointModel p2)
        {
            //Move returns a bool, true if the games ended and false if it hasnt, we can store this value so we know when the game has ended
            _gameEnded = await _gameThread.Move(p1, p2);
        }

        private void ChangeButtonGoes()
        {
            _newGo ^= true; //switch to the opposite bool value
        }
    }
}
