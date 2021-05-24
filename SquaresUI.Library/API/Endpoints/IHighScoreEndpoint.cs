using SquaresUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresUI.Library.API.Endpoints
{
    public interface IHighScoreEndpoint
    {
        Task<List<HighScoreUIModel>> GetHighScores();
        Task PostHighScore(HighScoreUIModel highScoreUIModel);
    }
}