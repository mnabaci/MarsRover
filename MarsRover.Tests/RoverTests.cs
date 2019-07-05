using AutoFixture;

using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;

using Xunit;

namespace MarsRover.Tests
{
    public class RoverTests
    {

        [Fact]
        public void RoverMustMoveWithValidParameters()
        {
            // Arrange
            Fixture fixture = new Fixture();
            Coordinate currenctCoordinate = fixture.Create<Coordinate>();
            RoverPosition currenctPosition = fixture.Build<RoverPosition>()
                .With(x => x.Coordinate, currenctCoordinate)
                .With(x => x.Direction, RoverDirectionEnum.North)
                .Create();

            fixture.Customizations.Add(FixtureCustomizations.PlateauConfiguration());
            IRover sut = fixture.Build<Rover>()
                .With(x => x.CurrentPosition, currenctPosition)
                .Create();

            // Act
            sut.Move(MovingDirectionEnum.Left);

            // Assert
            Assert.NotNull(sut.CurrentPosition);
            Assert.Equal(RoverDirectionEnum.West, sut.CurrentPosition.Direction);
        }
    }
}
