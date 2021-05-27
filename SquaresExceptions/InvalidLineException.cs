using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresExceptions
{
    public class InvalidLineException : Exception
    {
        public InvalidLineException()
        {

        }

        public InvalidLineException(int x1, int y1, int x2, int y2) : base(string.Format($"Line ({x1},{y1}) : ({x2},{y2}) is not a valid line"))
        {
                
        }
    }
}
