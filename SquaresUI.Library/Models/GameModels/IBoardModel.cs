using System.Collections.Generic;

namespace SquaresUI.Library.Models.GameModels
{
    public interface IBoardModel
    {
        List<LineModel> Lines { get; set; }
        List<List<LineModel>> Squares { get; set; }
    }
}