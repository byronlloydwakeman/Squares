using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.GameLogic.HighScoreLogic
{
    public class HighScoreLogic : IHighScoreLogic
    {
        /// <summary>
        /// Search the database for an entry with the given name
        /// If it does find the highscore and check whether its greater than the current highscore, true if so, false if not
        /// </summary>
        public bool IsNewHighScore(PlayerModel player)
        {
            return false;
        }

        /// <summary>
        /// Add new highscore entry into the database, if it already exists it will update it automatically
        /// </summary>
        /// <param name="player"></param>
        public void AddNewHighScore(PlayerModel player)
        {

        }
    }
}
