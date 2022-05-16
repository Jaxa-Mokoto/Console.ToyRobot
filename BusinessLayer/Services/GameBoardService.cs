using System;
using ToyRobot.BusinessLayer.Services.Interfaces;
using ToyRobot.Common;
using ToyRobot.Common.Dtos;
using ToyRobot.Common.Enums;
using ToyRobot.Common.Resources;

namespace ToyRobot.BusinessLayer.Services
{
    /// <summary>
    /// The service to validate the game board.
    /// </summary>
    public class GameBoardService : IGameBoardService
    {
        public CommandDto commandDto = new CommandDto();

        /// <summary>
        /// The constructor.
        /// </summary>
        public GameBoardService() { }

        /// <summary>
        /// Validates that the given coordinates are within the set bounds.
        /// </summary>
        /// <param name="XCoordinate">The user's x-coordinate.</param>
        /// <param name="YCoordinate">The user's y-coordinate.</param>
        /// <returns>A boolean flag indicating if the given coordinates are valid and within range.</returns>
        public bool isValidCoordinate(int? XCoordinate, int? YCoordinate)
        {
            var gameBoardDto = new GameBoardDto();
            if (XCoordinate != null && YCoordinate != null)
            {
                if ((XCoordinate <= gameBoardDto.endingRowAndColumn && XCoordinate >= gameBoardDto.startingRowAndColumn)
                        && (YCoordinate <= gameBoardDto.endingRowAndColumn && YCoordinate >= gameBoardDto.startingRowAndColumn))
                {
                    return true;
                }

                else if ((YCoordinate > gameBoardDto.endingRowAndColumn && YCoordinate <= ApplicationConstants.GameBoardMaxOutOfBounds)
                        || (XCoordinate < gameBoardDto.startingRowAndColumn && XCoordinate <= ApplicationConstants.GameBoardMinOutOfBounds))
                {
                    Console.WriteLine(FailureMessages.ToyRobotOutOfBoundsWarning);
                    return false;
                }
                else
                {
                    Console.Write(FailureMessages.ToyRobotOutOfBounds);
                    return false;
                }
            }

            Console.WriteLine(FailureMessages.InvalidPlaceCommand);
            return false;
        }

        /// <summary>
        /// Verifies if the compass direction is valid.
        /// </summary>
        /// <param name="compassDirection">The compass direction.</param>
        /// <returns>A boolean flag indicating if a given compass direction is valid or not.</returns>
        public bool isValidCompassDirection(string compassDirection)
        {
            if (!string.IsNullOrEmpty(compassDirection))
            {
                if (Enum.IsDefined(typeof(CompassDirection), compassDirection))
                {
                    return true;
                }
            }
            Console.WriteLine(FailureMessages.InvalidCompassDirectionCommand);
            return false;
        }

        /// <summary>
        /// Verifies if a given place command is the very first.
        /// </summary>
        /// <param name="userCommand">The user's command.</param>
        /// <returns>A boolean flag indicating if the given command is the very first.</returns>
        public bool isValidInitialPlaceCommand(string userCommand)
        {
            string[] newPlaceCommand = userCommand.Split(new string[] { " ", ", ", "," }, StringSplitOptions.None);

            if (newPlaceCommand.Length == 0)
            {
                Console.Write(FailureMessages.EmptyOrNullCommand);
                return false;
            }

            else if ((!(Enum.IsDefined(typeof(CompassDirection), newPlaceCommand[newPlaceCommand.Length-1]))) && newPlaceCommand.Length != 4)
            {
                Console.WriteLine(FailureMessages.InvalidFirstCommand);
                return false;
            }

            return true;
        }
    }
}