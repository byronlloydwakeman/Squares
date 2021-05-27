using Autofac;
using SquaresUI.Library.AutoFac;
using SquaresUI.Library.GameLogic;
using SquaresUI.Library.Models.GameModels;
using SquaresUI.Library.Validation;
using SquaresUI.Library.Validation.LineValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SquaresUI.LibraryTests.Validation
{
    public class LineValidationTests
    {
        private ILineValidation _lineValidation;
        private IGameThread _gameThread;

        public LineValidationTests()
        {
            using (ILifetimeScope scope = ContainerConfig.Configure().BeginLifetimeScope())
            {
                _gameThread = scope.Resolve<IGameThread>();
                _lineValidation = scope.Resolve<ILineValidation>();
            }
        }

        [Theory]
        [InlineData(0, 0, 0, 1, true)] //Top
        [InlineData(0, 0, 1, 0, true)] //Right
        [InlineData(1, 1, 1, 0, true)] //Bottom
        [InlineData(1, 1, 0, 1, true)] //Left
        [InlineData(1, 1, 1, 3, false)]
        public void ArePointsAdjacentShouldWork(int x1, int y1, int x2, int y2, bool expected)
        {
            bool actual = _lineValidation.ArePointsAdjacent(new PointModel() { XCoord = x1, YCoord = y1 }, new PointModel() { XCoord = x2, YCoord = y2 });

            Assert.Equal(expected, actual);
        }

        //LineModel == needs to be fixed first
        [Theory]
        [InlineData(0, 0, 1, 0, true)]
        [InlineData(1, 1, 2, 2, false)] //y2
        [InlineData(1, 1, 2, 1, false)] //x2
        public void DoesLineExistShouldWork(int x1, int x2, int y1, int y2, bool expected)
        {
            bool actual = _lineValidation.DoesLineExist(new PointModel() { XCoord = x1, YCoord = y1 }, new PointModel() { XCoord = x2, YCoord = y2 });

            Assert.Equal(expected, actual);
        }
    }
}
