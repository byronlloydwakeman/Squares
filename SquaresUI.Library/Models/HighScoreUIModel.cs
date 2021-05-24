using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Models
{
    public class HighScoreUIModel
    {
        public string LoggedInUser { get; set; }
        public string UserName { get; set; }
        public int BoardSize { get; set; }
        public DateTime Date { get; set; }
        public int HighScore { get; set; }
    }
}
