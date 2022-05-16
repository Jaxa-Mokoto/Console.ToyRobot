using System;
using ToyRobot.BusinessLayer.Services.Interfaces;
using ToyRobot.Common.Dtos;
using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Services
{
    /// <summary>
    /// The service to generate the behaviour of the given command(s).
    /// </summary>
    public class CommandService : ICommandService
    {
        readonly IGameBoardService _gameBoardService;
        readonly IBehaviourService _behaviourService;

        public CommandDto commandsDto = new CommandDto();

        /// <summary>
        /// The constructor.
        /// </summary>
        public CommandService(IGameBoardService gameBoardService, IBehaviourService behaviourService) 
        {
            _gameBoardService = gameBoardService;
            _behaviourService = behaviourService;

        }

        /// <summary>
        /// Processes the given commands. 
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns></returns>
        public string ProcessCommands (string userCommand)
        {
            if (userCommand.Contains(nameof(Commands.PLACE)))
            {
                string[] newCommand = userCommand.Split(new string[] { " ", ", ", "," }, StringSplitOptions.None);

                if (_gameBoardService.isValidCoordinate(commandsDto.PlaceXCoordinate, commandsDto.PlaceYCoordinate))
                {
                    commandsDto.PlaceXCoordinate = Convert.ToInt32(newCommand[1]);
                    commandsDto.PlaceYCoordinate = Convert.ToInt32(newCommand[2]);
                }
                    
                if (commandsDto.isFirstPlaceCommand)
                {
                    commandsDto.isFirstPlaceCommand = false;
                    commandsDto.CompassDirectionName = newCommand[3];
                    bool isValidCompass =  _gameBoardService.isValidCompassDirection(commandsDto.CompassDirectionName);

                    if (_gameBoardService.isValidCoordinate(commandsDto.PlaceXCoordinate, commandsDto.PlaceYCoordinate) && isValidCompass)
                    {
                        return _behaviourService.PlaceBehaviour(commandsDto.PlaceXCoordinate, commandsDto.PlaceYCoordinate, (CompassDirection)Enum.Parse(typeof(CompassDirection), commandsDto.CompassDirectionName));
                    }

                    Console.WriteLine("Try again"); //(todo)
                }
                else
                {
                    CompassDirection newRotationDirection = new CompassDirection();
                    return _behaviourService.PlaceBehaviour(commandsDto.PlaceXCoordinate, commandsDto.PlaceYCoordinate, newRotationDirection);
                }
            }

            else if (userCommand.Equals(nameof(Commands.MOVE)))
            {
                _behaviourService.NextMove();
            }

            else if (userCommand.Equals(nameof(Commands.LEFT)))
            {
                _behaviourService.RotationBehaviour(nameof(Commands.LEFT));
            }

            else if (userCommand.Equals(nameof(Commands.RIGHT)))
            {
                _behaviourService.RotationBehaviour(nameof(Commands.RIGHT));
            }

            else if (userCommand.Equals(nameof(Commands.REPORT)))
            {
                _behaviourService.ReportBehaviour();
            }

            return null;
        }
    }
}