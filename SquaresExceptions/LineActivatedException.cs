using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresExceptions
{
    public class LineActivatedException : Exception
    {
        public LineActivatedException()
        {

        }

        public LineActivatedException(int x1, int y1, int x2, int y2) : base($"Line ({x1},{y1}) ({x2},{y2}) has already been activated") 
        {

        }
    }
}
