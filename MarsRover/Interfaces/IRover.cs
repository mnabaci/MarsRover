using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Interfaces
{
    /// <summary>
    /// The interface for Rover
    /// </summary>
    public interface IRover
    {
        /// <summary>
        /// Rover's current position
        /// </summary>
        RoverPosition CurrentPosition { get; set; }

        /// <summary>
        /// Moves the rover
        /// </summary>
        /// <param name="direction">Direction that want to go</param>
        void Move(MovingDirectionEnum direction);
    }
}
