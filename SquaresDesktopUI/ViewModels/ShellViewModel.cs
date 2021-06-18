using Caliburn.Micro;
using SquaresDesktopUI.EventModels;
using SquaresUI.Library.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SquaresDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>, IHandle<EnterPlayerNamesEvent>, IHandle<RegisterEvent>, IHandle<HighscoreEvent>, IHandle<LoginEvent>
    {
        private HomeViewModel _homeViewModel;
        private GameViewModel _gameViewModel;
        private PlayerViewModel _playerViewModel;
        private RegisterViewModel _registerViewModel;
        private HighscoresViewModel _highscoresViewModel;
        private IEventAggregator _eventAggregator;

        public ShellViewModel(HomeViewModel homeViewModel, GameViewModel gameViewModel, PlayerViewModel playerViewModel, 
            IEventAggregator eventAggregator, RegisterViewModel registerViewModel, HighscoresViewModel highscoresViewModel)
        {
            _registerViewModel = registerViewModel;
            _highscoresViewModel = highscoresViewModel;
            _playerViewModel = playerViewModel;
            _eventAggregator = eventAggregator;
            _gameViewModel = gameViewModel;
            _homeViewModel = homeViewModel;

            _eventAggregator.SubscribeOnPublishedThread(this);

            ActivateItemAsync(_homeViewModel);
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_gameViewModel);
        }

        public async Task HandleAsync(EnterPlayerNamesEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_playerViewModel);
        }

        public async Task HandleAsync(RegisterEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_registerViewModel);
        }

        public async Task HandleAsync(HighscoreEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_highscoresViewModel);
        }

        public async Task HandleAsync(LoginEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_homeViewModel);
        }

        public async Task LoginScreen()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new LoginEvent());
        }

        public async Task RegisterScreen()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new RegisterEvent());
        }

        public async Task HighscoresScreen()
        {
            await _eventAggregator.PublishOnUIThreadAsync(new HighscoreEvent());
        }
    }
}
