using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresDesktopUI.Models
{
    public class HighscoreDisplayModel
    {
        public string LoggedInUser { get; set; }
        public string UserName { get; set; }
        public int BoardSize { get; set; }
        public DateTime Date { get; set; }
        public int HighScore { get; set; }

        public override string ToString()
        {
            return $"LoggedInUser : {LoggedInUser}, UserName : {UserName}, BoardSize : {BoardSize}\nDate : {Date}, HighScore : {HighScore}";
        }
    }
}
