namespace MarsRover.Models
{
    /// <summary>
    /// The plateau bounds
    /// </summary>
    public class PlateauBounds
    {
        /// <summary>
        /// Lower-left bound of the plateau
        /// </summary>
        public Coordinate LowerLeft { get; private set; }

        /// <summary>
        /// Upper-right bound of the plateau
        /// </summary>
        public Coordinate UpperRight { get; private set; }

        /// <param name="upperRight">Sets the Upper-right bound of the plateau</param>
        /// <param name="lowerLeft">Sets the Lower-left bound of the plateau</param>
        public PlateauBounds(Coordinate upperRight, Coordinate lowerLeft)
        {
            this.UpperRight = upperRight;
            this.LowerLeft = lowerLeft;
        }
    }
}
