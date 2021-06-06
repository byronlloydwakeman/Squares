using Caliburn.Micro;
using SquaresDesktopUI.HighscoreHelpers;
using SquaresDesktopUI.ViewModels;
using SquaresUI.Library.API;
using SquaresUI.Library.API.Endpoints;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.GameLogic.GoLogic;
using SquaresUI.Library.GameLogic.HighScoreLogic;
using SquaresUI.Library.GameLogic.WinnerLogic;
using SquaresUI.Library.Models;
using SquaresUI.Library.Models.GameModels;
using SquaresUI.Library.Validation.LineValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container)
                .PerRequest<IAPIHelper, APIHelper>()
                .PerRequest<IHighScoreEndpoint, HighScoreEndpoint>()
                .PerRequest<IHighScoreLogic, HighScoreLogic>()
                .PerRequest<ILineValidation, LineValidation>()
                .PerRequest<IOrderBy, OrderBy>();


            _container.Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IGameThread, GameThread>()
                .Singleton<IAuthenticatedUser, AuthenticatedUser>()
                .Singleton<IGoLogic, GoLogic>()
                .Singleton<IWinnerLogic, WinnerLogic>()
                .Singleton<IBoardModel, BoardModel>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
