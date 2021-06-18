using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Models.GameModels
{
    public class LineModel
    {
        public PointModel Point1 { get; set; }
        public PointModel Point2 { get; set; }
        public bool IsActivated { get; set; }

        public static bool operator == (LineModel l1, LineModel l2)
        {
            if((l1.Point1 == l2.Point1) && (l1.Point2 == l2.Point2))
            {
                return true;
            }
            else if((l1.Point1 == l2.Point2) && (l1.Point2 == l2.Point1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (LineModel l1, LineModel l2)
        {
            if ((l1.Point1 == l2.Point1) && (l1.Point2 == l2.Point2))
            {
                return false;
            }
            else if ((l1.Point1 == l2.Point2) && (l1.Point2 == l2.Point1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
