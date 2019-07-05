using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Interfaces
{
    /// <summary>
    /// The interface for plateau
    /// </summary>
    public interface IPlateau
    {
        /// <summary>
        /// Plateau's bounds
        /// </summary>
        PlateauBounds Bounds { get; }

        /// <summary>
        /// Calculates rover's next position with the moving direction
        /// </summary>
        /// <param name="currentPosition">Rover's current position</param>
        /// <param name="direction">Direction that rover want to go</param>
        /// <returns>The rover's new position</returns>
        RoverPosition CalculateNextPosition(RoverPosition currentPosition, MovingDirectionEnum direction);
    }
}
