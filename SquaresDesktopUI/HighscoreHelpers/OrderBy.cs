using SquaresUI.Library.GameLogic.HighScoreLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDesktopUI.HighscoreHelpers
{
    public class OrderBy : IOrderBy
    {
        private IHighScoreLogic _highScoreLogic;
        public OrderBy(IHighScoreLogic highScoreLogic)
        {
            _highScoreLogic = highScoreLogic;
        }

        public async Task<List<string>> OrderByNewest()
        {
            List<string> temp = new List<string>();

            foreach (var item in await _highScoreLogic.ReturnHighscoresByNewest())  //Convert model list to string list
            {
                temp.Add(item.ToString());
            }

            return temp;
        }

        public async Task<List<string>> OrderByOldest()
        {
            List<string> temp = new List<string>();

            foreach (var item in await _highScoreLogic.ReturnHighscoresByOldest())  //Convert model list to string list
            {
                temp.Add(item.ToString());
            }

            return temp;
        }

        public async Task<List<string>> OrderByScore()
        {
            List<string> temp = new List<string>();

            foreach (var item in await _highScoreLogic.ReturnHighscoreByScore())
            {
                temp.Add(item.ToString());
            }

            return temp;
        }

        public async Task<List<string>> OrderByAlpha()
        {
            List<string> temp = new List<string>();

            foreach (var item in await _highScoreLogic.ReturnHighscoresByAlpha())
            {
                temp.Add(item.ToString());
            }

            return temp;
        }
    }
}
