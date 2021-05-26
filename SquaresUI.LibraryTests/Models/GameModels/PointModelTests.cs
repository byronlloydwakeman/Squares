using SquaresUI.Library.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SquaresUI.LibraryTests.Models.GameModels
{
    public class PointModelTests
    {
        [Theory]
        [InlineData(1, 1, 1, 1, true)]
        [InlineData(1, 1, 1, 2, false)]
        [InlineData(1, 1, 2, 1, false)]
        [InlineData(1, 2, 1, 1, false)]
        [InlineData(2, 1, 1, 1, false)]
        public void ArePointsEqual(int x1, int x2, int y1, int y2, bool expected)
        {
            bool actual = false;
            PointModel p1 = new PointModel() { XCoord = x1, YCoord = y1 };
            PointModel p2 = new PointModel { XCoord = x2, YCoord = y2 };
            if (p1 == p2)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }
    }
}
