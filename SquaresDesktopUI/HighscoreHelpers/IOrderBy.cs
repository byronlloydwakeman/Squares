using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresDesktopUI.HighscoreHelpers
{
    public interface IOrderBy
    {
        Task<List<string>> OrderByAlpha();
        Task<List<string>> OrderByOldest();
        Task<List<string>> OrderByNewest();
        Task<List<string>> OrderByScore();
    }
}