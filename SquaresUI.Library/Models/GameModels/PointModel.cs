using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresUI.Library.Models.GameModels
{
    public class PointModel
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public static bool operator ==(PointModel p1, PointModel p2)
        {
            if ((p1.XCoord == p2.XCoord) && (p1.YCoord == p2.YCoord))
            {
                return true;
            }
            else
            {
                return false;  
            }
        }

        public static bool operator !=(PointModel p1, PointModel p2)
        {
            if ((p1.XCoord == p2.XCoord) && (p1.YCoord == p2.YCoord))
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
