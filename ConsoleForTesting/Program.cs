using Autofac;
using SquaresUI.Library.API;
using SquaresUI.Library.AutoFac;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.GameLogic.GoLogic;
using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using (ILifetimeScope scope = ContainerConfig.Configure().BeginLifetimeScope())
            {
                var gameThread = scope.Resolve<IGameThread>();
                gameThread.InsertPlayerModels(new PlayerModel() { UserName = "Byron", IsGo = true, Score = 0 }, new PlayerModel() { UserName = "Nathan", IsGo = false, Score = 0 });
                await gameThread.InsertLogin("byzstorm1103@gmail.com", "Password123");
                await gameThread.Move(new PointModel() { XCoord = 0, YCoord = 0 }, new PointModel() { XCoord = 0, YCoord = 1 });
                await gameThread.Move(new PointModel() { XCoord = 0, YCoord = 0 }, new PointModel() { XCoord = 1, YCoord = 0 });
                await gameThread.Move(new PointModel() { XCoord = 0, YCoord = 1 }, new PointModel() { XCoord = 1, YCoord = 1 });
                await gameThread.Move(new PointModel() { XCoord = 1, YCoord = 0 }, new PointModel() { XCoord = 1, YCoord = 1 });
            }
            Console.ReadKey();
        }
    }
}
