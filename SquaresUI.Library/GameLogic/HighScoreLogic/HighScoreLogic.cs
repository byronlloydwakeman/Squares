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

        //Called by GameThread, when we login _apiHelper has a authenticatedModel field which saves the name and access token, so we dont have to keep manually logging in
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

        public async Task<List<HighScoreUIModel>> ReturnHighscoresByNewest()
        {
            List<HighScoreUIModel> temp = await _highscoreEndpoint.GetHighScores();
            temp.Reverse(); //So its ordered from most recent to oldest
            return temp;
        }

        public async Task<List<HighScoreUIModel>> ReturnHighscoresByOldest()
        {
            List<HighScoreUIModel> temp = await _highscoreEndpoint.GetHighScores();
            return temp;
        }

        public async Task<List<HighScoreUIModel>> ReturnHighscoresByAlpha()
        {
            List<HighScoreUIModel> temp = new List<HighScoreUIModel>();
            List<HighScoreUIModel> highscores = await _highscoreEndpoint.GetHighScores();

            //Get the names of all the highscores into a list, sort it and then rearrange the original list respectively

            List<string> names = new List<string>();

            foreach (var score in highscores)
            {
                names.Add(score.UserName);
            }

            names.Sort();

            //Loop through the new list, when we find the name in the highscores list add it to the temp list
            for (int i = 0; i < names.Count; i++)
            {
                foreach (var score in highscores) //Find the highscore with the given name
                {
                    if (score.UserName == names[i])
                    {
                        temp.Add(score); //As the names are sorted, this means when we add them the highscores should also be sorted
                    }
                }
            }

            return temp;
        }

        public async Task<List<HighScoreUIModel>> ReturnHighscoreByScore()
        {
            List<HighScoreUIModel> temp = new List<HighScoreUIModel>();
            List<HighScoreUIModel> highscores = await _highscoreEndpoint.GetHighScores();

            List<int> scoreList = new List<int>();

            foreach (var item in highscores)
            {
                scoreList.Add(item.HighScore);   
            }

            scoreList.Sort();

            for (int i = 0; i < scoreList.Count; i++)
            {
                foreach (var item in highscores)
                {
                    if (item.HighScore == scoreList[i])
                    {
                        temp.Add(item);
                    }
                }
            }

            temp.Reverse(); //So the start of the list is highest not lowest
            return temp;

        }
    }
}
