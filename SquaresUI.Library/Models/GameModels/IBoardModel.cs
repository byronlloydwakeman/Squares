using System.Collections.Generic;

namespace SquaresUI.Library.Models.GameModels
{
    public interface IBoardModel
    {
        int height { get; }
        int width { get; }
        List<LineModel> Lines { get; set; }
        List<List<LineModel>> Squares { get; set; }
    }
}