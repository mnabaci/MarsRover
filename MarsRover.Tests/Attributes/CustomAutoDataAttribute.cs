using System;

using AutoFixture;
using AutoFixture.Xunit2;
using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Tests.Attributes
{
    public class CustomAutoDataAttribute : AutoDataAttribute
    {
        public CustomAutoDataAttribute()
            : base(() => new Fixture().Customize(new PlateauCustomization()))
        { }
    }

    public class PlateauCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() =>
            {
                Random random = new Random();
                Coordinate upperRightCoordinate = fixture.Build<Coordinate>()
                .With(x => x.X, random.Next(3, 10))
                .With(x => x.Y, random.Next(3, 10))
                .Create();

                PlateauBounds plateauBounds = new PlateauBounds(upperRightCoordinate, new Coordinate());
                var start = fixture.Create<PlateauBounds>();

                return new Plateau(plateauBounds);
            });

            fixture.Register(() =>
            {
                Coordinate roverCoordinate = new Coordinate();
                RoverPosition roverPosition = fixture.Build<RoverPosition>()
                .With(x => x.Coordinate, roverCoordinate)
                .With(x => x.Direction, RoverDirectionEnum.North)
                .Create();

                return roverPosition;
            });
        }
    }
}
