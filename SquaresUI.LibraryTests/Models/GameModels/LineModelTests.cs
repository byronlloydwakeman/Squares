using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SquaresUI.LibraryTests.Models.GameModels
{
    public class LineModelTests
    {
        [Theory]
        [InlineData(0, 0, 1, 0, 1, 0, 0, 0, true)]
        public void AreLinesEqualShouldWork(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, bool expected)
        {
            LineModel lineModel = new LineModel()
            {
                Point1 = new PointModel(){ XCoord = x1, YCoord = y1},
                Point2 = new PointModel() { XCoord = x2, YCoord = y2}
            };

            LineModel lineModel2 = new LineModel()
            {
                Point1 = new PointModel() { XCoord = x3, YCoord = y3 },
                Point2 = new PointModel() { XCoord = x4, YCoord = y4 }
            };

            bool actual = lineModel == lineModel2;

            Assert.Equal(expected, actual);
        }
    }
}
