using AutoFixture.Kernel;

using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover.Tests
{
    public static class FixtureCustomizations
    {
        public static TypeRelay PlateauConfiguration()
        {
            return new TypeRelay(typeof(IPlateau), typeof(Plateau));
        }
    }
}
