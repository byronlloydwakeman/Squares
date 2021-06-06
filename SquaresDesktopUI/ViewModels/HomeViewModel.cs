using Caliburn.Micro;
using SquaresDesktopUI.EventModels;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresDesktopUI.ViewModels
{
    public class HomeViewModel : Screen
    {
        IGameThread _gameThread;
        private IEventAggregator _eventAggregator;
        private string _email;
        private string _password;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                NotifyOfPropertyChange(() => Email);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin
        {
            get
            {
                bool output = false;

                if (Password?.Length > 0 && Email?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public HomeViewModel(IEventAggregator eventAggregator, IGameThread gameThread)
        {
            _gameThread = gameThread;
            _eventAggregator = eventAggregator;
        }

        //Take in the credientials and use the endpoint to check theyre valid
        public async Task Login()
        {
            try
            {
                await _gameThread.InsertLogin(Email, Password);
                await _eventAggregator.PublishOnUIThreadAsync(new EnterPlayerNamesEvent());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        //Displays the RegisterView
        public async Task Register()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new RegisterEvent());
        }
    }

}
