using System;
using ToyRobot.BusinessLayer.Services.Interfaces;
using ToyRobot.Common;
using ToyRobot.Common.Dtos;
using ToyRobot.Common.Resources;
using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Services
{
    /// <summary>
    /// The service to validate the game board.
    /// </summary>
    public class GameBoardService : IGameBoardService
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public GameBoardService(){ }

        /// <summary>
        /// Validates that the given coordinates are within the set bounds.
        /// </summary>
        /// <param name="XCoordinate">The user's x-coordinate.</param>
        /// <param name="YCoordinate">The user's y-coordinate.</param>
        /// <returns></returns>
        public bool isValidCoordinate(int XCoordinate, int YCoordinate)
        {
            var gameBoardDto = new GameBoardDto();

            if (XCoordinate <= gameBoardDto.endingRowAndColumn  && XCoordinate >= gameBoardDto.startingRowAndColumn)
            {
                if (YCoordinate <= gameBoardDto.endingRowAndColumn && YCoordinate >= gameBoardDto.startingRowAndColumn)
                {
                    return true;
                }
            }

            else if ((YCoordinate > gameBoardDto.endingRowAndColumn && YCoordinate <= ApplicationConstants.GameBoardMaxOutOfBounds) 
                    || (XCoordinate < gameBoardDto.startingRowAndColumn && XCoordinate <= ApplicationConstants.GameBoardMinOutOfBounds))
            {
                Console.WriteLine(FailureMessages.ToyRobotOutOfBounds);
                return false;
            }

            Console.WriteLine(FailureMessages.InvalidPlaceCommand);
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compassDirection"></param>
        /// <returns></returns>
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
            return false; //todo
        }
    }
}