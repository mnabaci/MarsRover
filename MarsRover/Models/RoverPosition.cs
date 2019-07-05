using MarsRover.Enums;

namespace MarsRover.Models
{
    /// <summary>
    /// The rover position
    /// </summary>
    public class RoverPosition
    {
        /// <summary>
        /// Rover's X,Y coordinate
        /// </summary>
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// Rover's facing direction
        /// </summary>
        public RoverDirectionEnum Direction { get; set; }

        /// <summary>
        /// As default, RoverPosition's coordinate is (0,0) and direction is North
        /// </summary>
        public RoverPosition()
        {
            this.Coordinate = new Coordinate(0, 0);
            this.Direction = RoverDirectionEnum.North;
        }

        /// <summary>
        /// Initializes a new instance for the RoverPosition
        /// </summary>
        /// <param name="coordinate">Sets the Rover's position</param>
        /// <param name="direction">Sets the Rover's direction</param>
        public RoverPosition(Coordinate coordinate, RoverDirectionEnum direction)
        {
            this.Coordinate = coordinate;
            this.Direction = direction;
        }
    }
}
