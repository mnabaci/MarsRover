using System;
using AutoFixture;
using AutoFixture.Xunit2;

using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Tests.Attributes;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        [Theory, CustomAutoData]
        public void PlateauMustCalculateNextPosition(Plateau sut, RoverPosition currentRoverPosition)
        {
            // Act
            RoverPosition nextRoverPosition = sut.CalculateNextPosition(currentRoverPosition, MovingDirectionEnum.Right);

            // Assert
            Assert.NotNull(nextRoverPosition);
            Assert.Equal(RoverDirectionEnum.East, nextRoverPosition.Direction);
            Assert.Equal(currentRoverPosition.Coordinate.X, nextRoverPosition.Coordinate.X);
            Assert.Equal(currentRoverPosition.Coordinate.Y, nextRoverPosition.Coordinate.Y);
        }
    }
}
