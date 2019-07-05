
using MarsRover.Enums;
using MarsRover.Interfaces;

namespace MarsRover.Models
{
    /// <summary>
    /// The plateau
    /// </summary>
    public class Plateau : IPlateau
    {
        /// <summary>
        /// Plateau's bounds
        /// </summary>
        public PlateauBounds Bounds { get; private set; }

        /// <summary>
        /// Initializes a new instance for the plateau
        /// </summary>
        /// <param name="bounds">Sets the plateau's bounds</param>
        public Plateau(PlateauBounds bounds)
        {
            this.Bounds = bounds;
        }

        /// <summary>
        /// Calculates rover's next position with the moving direction
        /// </summary>
        /// <param name="currentPosition">Rover's current position</param>
        /// <param name="direction">Direction that rover want to go</param>
        /// <returns>The rover's new position</returns>
        public RoverPosition CalculateNextPosition(RoverPosition currentPosition, MovingDirectionEnum direction)
        {
            switch (direction)
            {
                case MovingDirectionEnum.Forward:
                    switch (currentPosition.Direction)
                    {
                        case RoverDirectionEnum.North:
                            currentPosition.Coordinate.Y = (currentPosition.Coordinate.Y + 1) > Bounds.UpperRight.Y ? Bounds.UpperRight.Y : currentPosition.Coordinate.Y + 1;
                            break;
                        case RoverDirectionEnum.South:
                            currentPosition.Coordinate.Y = (currentPosition.Coordinate.Y - 1) < Bounds.LowerLeft.Y ? Bounds.LowerLeft.Y : currentPosition.Coordinate.Y - 1;
                            break;
                        case RoverDirectionEnum.East:
                            currentPosition.Coordinate.X = (currentPosition.Coordinate.X + 1) > Bounds.UpperRight.X ? Bounds.UpperRight.X : currentPosition.Coordinate.X + 1;
                            break;
                        case RoverDirectionEnum.West:
                            currentPosition.Coordinate.X = (currentPosition.Coordinate.X - 1) < Bounds.LowerLeft.X ? Bounds.LowerLeft.X : currentPosition.Coordinate.X - 1;
                            break;
                    }
                    break;
                case MovingDirectionEnum.Left:
                    switch (currentPosition.Direction)
                    {
                        case RoverDirectionEnum.North:
                            currentPosition.Direction = RoverDirectionEnum.West;
                            break;
                        case RoverDirectionEnum.South:
                            currentPosition.Direction = RoverDirectionEnum.East;
                            break;
                        case RoverDirectionEnum.East:
                            currentPosition.Direction = RoverDirectionEnum.North;
                            break;
                        case RoverDirectionEnum.West:
                            currentPosition.Direction = RoverDirectionEnum.South;
                            break;
                    }
                    break;
                case MovingDirectionEnum.Right:
                    switch (currentPosition.Direction)
                    {
                        case RoverDirectionEnum.North:
                            currentPosition.Direction = RoverDirectionEnum.East;
                            break;
                        case RoverDirectionEnum.South:
                            currentPosition.Direction = RoverDirectionEnum.West;
                            break;
                        case RoverDirectionEnum.East:
                            currentPosition.Direction = RoverDirectionEnum.South;
                            break;
                        case RoverDirectionEnum.West:
                            currentPosition.Direction = RoverDirectionEnum.North;
                            break;
                    }
                    break;
            }
            return currentPosition;
        }
    }
}
