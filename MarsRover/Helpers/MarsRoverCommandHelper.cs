using System;
using System.Collections.Generic;
using System.Linq;

using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Helpers
{
    /// <summary>
    /// The mars rover command helper
    /// </summary>
    public static class MarsRoverCommandHelper
    {
        /// <summary>
        /// Populate the coordinate from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The coordinate generated from input. Returns the default value if the input is not valid.</returns>
        public static Coordinate PopulateCoordinate(string input)
        {
            if (input.Length < 3) return default;
            Coordinate coordinate = new Coordinate();

            try
            {
                coordinate.X = int.Parse(input[0].ToString());
                coordinate.Y = int.Parse(input[2].ToString());
            }
            catch (FormatException)
            {
                return default;
            }

            return coordinate;
        }

        /// <summary>
        /// Populate the rover position from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The rover position generated from input. Returns the default value if the input is not valid.</returns>
        public static RoverPosition PopulateRoverPosition(string input)
        {
            if (input.Length < 5) return default;
            RoverPosition roverPosition = new RoverPosition();

            try
            {
                roverPosition.Coordinate.X = int.Parse(input[0].ToString());
                roverPosition.Coordinate.Y = int.Parse(input[2].ToString());
                roverPosition.Direction = PopulateRoverDirection(input[4]);

                if(roverPosition.Direction == RoverDirectionEnum.Undefined) return default;
            }
            catch (FormatException)
            {
                return default;
            }

            return roverPosition;
        }

        /// <summary>
        /// Populate the moving direction list from the input string
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The moving direction list generated from input. Returns an empty list if the input is not valid.</returns>
        public static IEnumerable<MovingDirectionEnum> PopulateMovingDirectionList(string input)
        {
            var movingDirectionList = new List<MovingDirectionEnum>();
            for (int i = 0; i < input.Length; i++)
            {
                movingDirectionList.Add(PopulateMovingDirection(input[i]));
            }

            return movingDirectionList.Any(x => x == MovingDirectionEnum.Undefined) ? new List<MovingDirectionEnum>() : movingDirectionList;
        }

        /// <summary>
        /// Populate rover direction from the input char
        /// </summary>
        /// <param name="input">The input char</param>
        /// <returns>The rover direction generated from input. Returns the undefined value if the input is not valid.</returns>
        static RoverDirectionEnum PopulateRoverDirection(char input)
        {
            switch (input)
            {
                case 'N':
                case 'n':
                    return RoverDirectionEnum.North;
                case 'S':
                case 's':
                    return RoverDirectionEnum.South;
                case 'E':
                case 'e':
                    return RoverDirectionEnum.East;
                case 'W':
                case 'w':
                    return RoverDirectionEnum.West;
                default:
                    return RoverDirectionEnum.Undefined;
            }
        }

        /// <summary>
        /// Populate moving direction from the input char
        /// </summary>
        /// <param name="input">The input char</param>
        /// <returns>The moving direction generated from input. Returns the undefined value if the input is not valid.</returns>
        static MovingDirectionEnum PopulateMovingDirection(char data)
        {
            switch (data)
            {
                case 'M':
                case 'm':
                    return MovingDirectionEnum.Forward;
                case 'L':
                case 'l':
                    return MovingDirectionEnum.Left;
                case 'R':
                case 'r':
                    return MovingDirectionEnum.Right;
                default:
                    return MovingDirectionEnum.Undefined;
            }
        }
    }
}
