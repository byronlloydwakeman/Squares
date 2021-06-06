using Caliburn.Micro;
using SquaresDesktopUI.EventModels;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDesktopUI.ViewModels
{
    public class PlayerViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private IGameThread _gameThread;

        private string _player1Name;
        public string Player1Name
        {
            get { return _player1Name; }
            set 
            { 
                _player1Name = value;
                NotifyOfPropertyChange(() => Player1Name);
                NotifyOfPropertyChange(() => CanEnterPlayerNames);
            }
        }

        private string _player2Name;

        public string Player2Name
        {
            get { return _player2Name; }
            set 
            { 
                _player2Name = value;
                NotifyOfPropertyChange(() => Player2Name);
                NotifyOfPropertyChange(() => CanEnterPlayerNames);
            }
        }




        public bool CanEnterPlayerNames
        {
            get
            {
                if ((Player1Name?.Length > 0) && (Player2Name?.Length > 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public PlayerViewModel(IEventAggregator eventAggregator, IGameThread gameThread)
        {
            _gameThread = gameThread;
            _eventAggregator = eventAggregator;
        }


        public void EnterPlayerNames()
        {
            _gameThread.InsertPlayerModels(new PlayerModel() { UserName = Player1Name, IsGo = true, Score = 0 }, new PlayerModel() { UserName = Player2Name, IsGo = false, Score = 0 });
            _eventAggregator.PublishOnUIThreadAsync(new LogOnEvent());
        }

    }
}
