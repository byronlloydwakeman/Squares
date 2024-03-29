﻿using Autofac;
using SquaresExceptions;
using SquaresUI.Library.API;
using SquaresUI.Library.API.Endpoints;
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
                gameThread.InsertPlayerModels(new PlayerModel() { UserName = "Byron", IsGo = true, Score = 0 }, new PlayerModel() { UserName = "Bob", IsGo = false, Score = 0 });
                await gameThread.InsertLogin("byzstorm1103@gmail.com", "Password123");
                gameThread.ShowBoard();

                //bool hasGameEnded = false;

                //while (hasGameEnded == false)
                //{
                //    Console.WriteLine("Enter two points of the line you want");
                //    Console.WriteLine("first x coord: ");
                //    int x1 = Convert.ToInt32(Console.ReadLine());
                //    Console.WriteLine("first y coord: ");
                //    int y1 = Convert.ToInt32(Console.ReadLine());
                //    Console.WriteLine("second x coord: ");
                //    int x2 = Convert.ToInt32(Console.ReadLine());
                //    Console.WriteLine("second y coord: ");
                //    int y2 = Convert.ToInt32(Console.ReadLine());
                //    try
                //    {
                //        hasGameEnded = await gameThread.Move(new PointModel() { XCoord = x1, YCoord = y1 }, new PointModel() { XCoord = x2, YCoord = y2 });
                //    }
                //    catch (InvalidLineException e)
                //    {
                //        Console.WriteLine(e.Message);
                //        hasGameEnded = true;
                //    }
                //    catch (LineActivatedException e)
                //    {
                //        Console.WriteLine(e.Message);
                //        hasGameEnded = true;
                //    }                   
                //}

                //var getHighScores = scope.Resolve<IHighScoreEndpoint>();

                //foreach (var item in await getHighScores.GetHighScores())
                //{
                //    Console.WriteLine(item);
                //}
            }
            Console.ReadKey();
        }
    }
}
