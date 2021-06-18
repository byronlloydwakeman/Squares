using AutoMapper;
using SquaresDesktopUI.Models;
using SquaresUI.Library.GameLogic.HighScoreLogic;
using SquaresUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDesktopUI.HighscoreHelpers
{
    public class OrderBy : IOrderBy
    {
        private IMapper _mapper;
        private IHighScoreLogic _highScoreLogic;
        public OrderBy(IHighScoreLogic highScoreLogic, IMapper mapper)
        {
            _mapper = mapper;
            _highScoreLogic = highScoreLogic;
        }

        public async Task<List<string>> OrderByNewest()
        {
            List<string> temp = new List<string>();

            var highscoreUIModelList = await _highScoreLogic.ReturnHighscoresByNewest();

            foreach (var item in _mapper.Map<List<HighscoreDisplayModel>>(highscoreUIModelList))  //Convert model list to string list
            {
                temp.Add(item.ToString());
            }

            return temp;
        }

        public async Task<List<string>> OrderByOldest()
        {
            List<string> temp = new List<string>();

            var highscoreUIModelList = await _highScoreLogic.ReturnHighscoresByOldest();

            foreach (var item in _mapper.Map<List<HighscoreDisplayModel>>(highscoreUIModelList))  //Convert model list to string list
            {
                temp.Add(item.ToString());
            }

            return temp;
        }

        public async Task<List<string>> OrderByScore()
        {
            List<string> temp = new List<string>();

            var highscoreUIModelList = await _highScoreLogic.ReturnHighscoreByScore();

            foreach (var item in _mapper.Map<List<HighscoreDisplayModel>>(highscoreUIModelList))
            {
                temp.Add(item.ToString());
            }

            return temp;
        }

        public async Task<List<string>> OrderByAlpha()
        {
            List<string> temp = new List<string>();

            var highscoreUIModelList = await _highScoreLogic.ReturnHighscoresByAlpha();

            foreach (var item in _mapper.Map<List<HighscoreDisplayModel>>(highscoreUIModelList))
            {
                temp.Add(item.ToString());
            }

            return temp;
        }
    }
}
