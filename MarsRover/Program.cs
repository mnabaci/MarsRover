using System;
using System.Collections.Generic;
using System.Linq;

using MarsRover.Enums;
using MarsRover.Helpers;
using MarsRover.Interfaces;
using MarsRover.Models;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the plateau's upper-right coordinates (ex. 5 5) :");
            string line = Console.ReadLine();

            Coordinate upperRightCoordinate = MarsRoverCommandHelper.PopulateCoordinate(line);

            if(upperRightCoordinate is default(Coordinate))
            {
                Console.WriteLine("The input is not valid.");
                return;
            }

            // generate the rover and plateau
            Coordinate lowerLeftCoordinate = new Coordinate();
            PlateauBounds plateauBounds = new PlateauBounds(upperRightCoordinate, lowerLeftCoordinate);
            IPlateau plateau = new Plateau(plateauBounds);
            Coordinate roverCurrentPosition = new Coordinate();
            RoverPosition roverPosition = new RoverPosition(roverCurrentPosition, RoverDirectionEnum.North);
            IRover rover = new Rover(plateau, roverPosition);

            while (true)
            {
                Console.Clear();
                Console.WriteLine(string.Format("Plateau's bounds are: Upper-Right = ({0},{1}) Lower-Left = ({2},{3})" + Environment.NewLine,
                    plateau.Bounds.UpperRight.X,
                    plateau.Bounds.UpperRight.Y,
                    plateau.Bounds.LowerLeft.X,
                    plateau.Bounds.LowerLeft.Y));

                Console.Write("Enter the rover's start position (ex. 1 1 N) :");
                line = Console.ReadLine();
                rover.CurrentPosition = MarsRoverCommandHelper.PopulateRoverPosition(line);

                if (rover.CurrentPosition is default(RoverPosition))
                {
                    Console.WriteLine("The input is not valid.");
                    return;
                }

                Console.Write("Enter rover's moving sequence (ex. LMRMRMM) :");
                line = Console.ReadLine();
                IEnumerable<MovingDirectionEnum> movingDirectionList = MarsRoverCommandHelper.PopulateMovingDirectionList(line);

                if(movingDirectionList.Any() == false)
                {
                    Console.WriteLine("The input is not valid.");
                    return;
                }

                foreach (MovingDirectionEnum direction in movingDirectionList)
                    rover.Move(direction);

                Console.WriteLine(string.Format(Environment.NewLine + "Current Position is: {0} {1} {2}", rover.CurrentPosition.Coordinate.X, rover.CurrentPosition.Coordinate.Y, rover.CurrentPosition.Direction));

                Console.Write(Environment.NewLine + "0: Exit \n1: Retry\nSelect :");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.NumPad1) return;
            }
        }
    }
}
