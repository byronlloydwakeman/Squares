using Autofac;
using SquaresUI.Library.API;
using SquaresUI.Library.API.Endpoints;
using SquaresUI.Library.AutoFac;
using SquaresUI.Library.Models;
using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic.HighScoreLogic
{
    public class HighScoreLogic : IHighScoreLogic
    {
        private IAPIHelper _apiHelper;
        private IHighScoreEndpoint _highscoreEndpoint;
        private int _boardSize;
        public HighScoreLogic(IAPIHelper apiHelper, IHighScoreEndpoint highScoreEndpoint)
        {
            _apiHelper = apiHelper;
            _highscoreEndpoint = highScoreEndpoint;
        }

        public void InsertBoardSize(int boardSize)
        {
            _boardSize = boardSize;
        }

        public async Task Login(string username, string password)
        {
            await _apiHelper.Login(username, password);
        }

        /// <summary>
        /// Search the database for an entry with the given name
        /// If it does find the highscore and check whether its greater than the current highscore, true if so, false if not
        /// </summary>
        public async Task<bool> IsNewHighScore(PlayerModel player)
        {
            //Try to find the username in the database and see whether its score is greater than this one
            bool exist = false;
            foreach (var item in await _highscoreEndpoint.GetHighScores())
            {
                if (item.UserName == player.UserName) //Does the entry exist?
                {
                    exist = true;
                }
                if ((item.UserName == player.UserName) && (item.HighScore < player.Score))
                {
                    return true;
                }
            }

            //As there may not be an entry yet for this username, check whether it exists or not, if it doesn't that means its a new highscore
            if (exist)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Add new highscore entry into the database, if it already exists it will update it automatically
        /// </summary>
        /// <param name="player"></param>
        public void AddNewHighScore(PlayerModel player)
        {
            //Note board size is hard coded
            _highscoreEndpoint.PostHighScore(new HighScoreUIModel() { UserName = player.UserName, Date = DateTime.Now, BoardSize = _boardSize, HighScore = player.Score});
        }
    }
}
