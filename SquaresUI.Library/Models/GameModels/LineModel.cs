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

        public override string ToString()
        {
            return $"({Point1.XCoord},{Point1.YCoord}), ({Point2.XCoord},{Point2.YCoord}) Activated : {IsActivated}";
        }
    }
}
