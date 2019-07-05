
using MarsRover.Enums;
using MarsRover.Interfaces;

namespace MarsRover.Models
{
    /// <summary>
    /// The rover
    /// </summary>
    public class Rover : IRover
    {
        /// <summary>
        /// Rover's current position
        /// </summary>
        #region CurrentPosition
        private RoverPosition _currentPosition;
        public RoverPosition CurrentPosition
        {
            get
            {
                return _currentPosition;
            }
            set
            {
                // check if the coordinates is overflow
                if (value.Coordinate.X > _plateau.Bounds.UpperRight.X) value.Coordinate.X = _plateau.Bounds.UpperRight.X;
                else if (value.Coordinate.X < _plateau.Bounds.LowerLeft.X) value.Coordinate.X = _plateau.Bounds.LowerLeft.X;

                if (value.Coordinate.Y > _plateau.Bounds.UpperRight.Y) value.Coordinate.Y = _plateau.Bounds.UpperRight.Y;
                else if (value.Coordinate.Y < _plateau.Bounds.LowerLeft.Y) value.Coordinate.Y = _plateau.Bounds.LowerLeft.Y;

                this._currentPosition = value;
            }
        }
        #endregion

        /// <summary>
        /// Plateau that rover moved on
        /// </summary>
        IPlateau _plateau { get; set; }

        /// <summary>
        /// Initializes a new instance for the Rover
        /// </summary>
        /// <param name="plateau">Sets the plateau that rover moved on</param>
        /// <param name="startPosition">Sets the rover's start position</param>
        public Rover(IPlateau plateau, RoverPosition startPosition)
        {
            this._plateau = plateau;
            this.CurrentPosition = startPosition;
        }

        /// <summary>
        /// Rover's current position is seting 0,0 North
        /// </summary>
        /// <param name="plateau">Sets the plateau that rover moved on</param>
        public Rover(IPlateau plateau)
        {
            this._plateau = plateau;
            this.CurrentPosition = new RoverPosition();
        }

        /// <summary>
        /// Moves the rover
        /// </summary>
        /// <param name="direction">Direction that want to go</param>
        public void Move(MovingDirectionEnum direction)
        {
            this.CurrentPosition = this._plateau.CalculateNextPosition(this.CurrentPosition, direction);
        }
    }
}
