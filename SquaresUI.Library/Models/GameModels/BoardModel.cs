using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Models.GameModels
{
    public class BoardModel
    {
        public List<LineModel> Lines { get; set; }
        public List<List<LineModel>> Squares { get; set; }
    }
}
