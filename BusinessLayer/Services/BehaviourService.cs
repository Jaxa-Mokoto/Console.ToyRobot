using System;
using ToyRobot.BusinessLayer.Services.Interfaces;
using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Services
{
    /// <summary>
    /// The service to implement a given behaviour.
    /// </summary>
    public class BehaviourService : IBehaviourService
    {
        public Position Position { get; set; }
        public CompassDirection Direction { get; set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        public BehaviourService() { }

        public void Place(Position position, CompassDirection direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xcoordinate"></param>
        /// <param name="ycoordinate"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public string PlaceBehaviour(int xcoordinate, int ycoordinate, CompassDirection direction)
        {
            Position nextPosition = new Position(xcoordinate, ycoordinate, direction);
            nextPosition.X = xcoordinate;
            nextPosition.Y = ycoordinate;
            nextPosition.Direction = direction;

            if (Position != null)
            {
                nextPosition.Direction = Position.Direction;
            }

            Place(nextPosition, direction);
            return nextPosition.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Position NextMove()
        {
            Position nextPosition = new Position(Position.X, Position.Y, Position.Direction);
            string currentDirection = Enum.GetName(typeof(CompassDirection), nextPosition.Direction);

            switch (currentDirection)
            {
                case nameof(CompassDirection.NORTH):
                    nextPosition.Y = nextPosition.Y + 1;
                    break;

                case nameof(CompassDirection.SOUTH):
                    nextPosition.Y = nextPosition.Y - 1;
                    break;

                case nameof(CompassDirection.WEST):
                nextPosition.X = nextPosition.X - 1;
                    break;

                case nameof(CompassDirection.EAST):
                nextPosition.X = nextPosition.X + 1;
                    break;
            }

            Position.Y = nextPosition.Y;
            Position.X = nextPosition.X;
            Position.Direction = nextPosition.Direction;

            return nextPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotationDirection"></param>
        /// <returns></returns>
        public CompassDirection RotationBehaviour(string rotationDirection)
        {
            int rotationValue = 0;
            CompassDirection newRotationDirection = new CompassDirection();

            switch (rotationDirection)
            {
                case nameof(RotationDirection.LEFT):
                    rotationValue = -1;
                    break;

                case nameof (RotationDirection.RIGHT):
                    rotationValue = 1;
                    break;
            }

            var directions = (CompassDirection[])Enum.GetValues(typeof(CompassDirection));
            var currentDirection = (int)Position.Direction;
            var index = (currentDirection + rotationValue) % directions.Length;

            // clock wise
            if (rotationValue > 0)
            {
                switch (index)
                {
                    case 0:
                        newRotationDirection = CompassDirection.NORTH;
                        break;

                    case 1:
                        newRotationDirection = CompassDirection.EAST;
                        break;

                    case 2:
                        newRotationDirection = CompassDirection.SOUTH;
                        break;

                    case 3:
                        newRotationDirection = CompassDirection.WEST;
                        break;
                }
            }

            // anti-clock wise
            if (rotationValue < 0)
            {
                switch (index)
                {
                    case 0:
                        newRotationDirection = CompassDirection.NORTH;
                        break;

                    case -1:
                        newRotationDirection = CompassDirection.WEST;
                        break;

                    case -2:
                        newRotationDirection = CompassDirection.SOUTH;
                        break;

                    case -3:
                        newRotationDirection = CompassDirection.EAST;
                        break;
                }
            }

            Position.Direction = newRotationDirection;
            return Position.Direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReportBehaviour()
        {
            string reportResult = $"Output: {Position.X}, {Position.Y}, {Position.Direction}";
            Console.WriteLine(reportResult);
            return reportResult;
        }
    }
}