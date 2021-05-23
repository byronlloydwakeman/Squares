using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDataManager.Library.Models
{
    public class HighScoreDBModel
    {
        public string LoggedInUser { get; set; }
        public string UserName { get; set; }
        public int BoardSize { get; set; }
        public DateTime Date { get; set; }
        public int HighScore { get; set; }
    }
}
