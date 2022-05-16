using System;
using ToyRobot.BusinessLayer.Services.Interfaces;
using ToyRobot.Common.Dtos;
using ToyRobot.Common.Enums;
using ToyRobot.Common.Resources;

namespace ToyRobot.BusinessLayer.Services
{
    /// <summary>
    /// The service to process the given command(s).
    /// </summary>
    public class ToyRobotService : IToyRobotService
    {
        readonly IGameBoardService _gameBoardService;
        readonly IRuleService _behaviourService;

        public CommandDto commandsDto = new CommandDto();
        public string[] newOverallCommand;


        /// <summary>
        /// The constructor.
        /// </summary>
        public ToyRobotService(IGameBoardService gameBoardService, IRuleService behaviourService)
        {
            _gameBoardService = gameBoardService;
            _behaviourService = behaviourService;

        }

        /// <summary>
        /// Processes the given commands. 
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns>The processed command with calculated behaviour.</returns>
        public string ProcessCommands(string userCommand)
        {
            string[] newPlaceCommand = userCommand.Split(new string[] { " ", ", ", "," }, StringSplitOptions.None);
            string Command = newPlaceCommand[0];

            if ((!(Enum.IsDefined(typeof(Commands), Command))))
            {
                Console.WriteLine(FailureMessages.UnknownCommand);
            }

            else if (userCommand.Contains(nameof(Commands.PLACE)))
            {

                if (commandsDto.isInitialPlaceCommand)
                {
                    if (_gameBoardService.isValidInitialPlaceCommand(userCommand))
                    {
                        if ( _gameBoardService.isValidCoordinate(Convert.ToInt32(newPlaceCommand[1]), Convert.ToInt32(newPlaceCommand[2])) &&_gameBoardService.isValidCompassDirection(newPlaceCommand[3]))
                        {
                            commandsDto.PlaceXCoordinate = Convert.ToInt32(newPlaceCommand[1]);
                            commandsDto.PlaceYCoordinate = Convert.ToInt32(newPlaceCommand[2]);
                            commandsDto.CompassDirectionName = newPlaceCommand[3];
                            commandsDto.isInitialPlaceCommand = false;
                            return _behaviourService.PlaceBehaviour(commandsDto.PlaceXCoordinate, commandsDto.PlaceYCoordinate, (CompassDirection)Enum.Parse(typeof(CompassDirection), commandsDto.CompassDirectionName));
                        }
                    }
                }

                else if (!commandsDto.isInitialPlaceCommand)
                {
                    CompassDirection newRotationDirection = new CompassDirection();
                    commandsDto.PlaceXCoordinate = Convert.ToInt32(newPlaceCommand[1]);
                    commandsDto.PlaceYCoordinate = Convert.ToInt32(newPlaceCommand[2]);
                    return _behaviourService.PlaceBehaviour(commandsDto.PlaceXCoordinate, commandsDto.PlaceYCoordinate, newRotationDirection);
                }
            }

            else if (!commandsDto.isInitialPlaceCommand)
            {
                switch (userCommand)
                {
                    case nameof(Commands.MOVE):
                        _behaviourService.NextMove();
                        break;

                    case nameof(Commands.LEFT):
                        _behaviourService.RotationBehaviour(nameof(Commands.LEFT));
                        break;

                    case nameof(Commands.RIGHT):
                        _behaviourService.RotationBehaviour(nameof(Commands.RIGHT));
                        break;

                    case nameof(Commands.REPORT):
                        _behaviourService.ReportBehaviour();
                        break;
                }
            }

            else
            {
                Console.WriteLine(FailureMessages.InvalidFirstCommand);
            }
            return null;
        }
    }
}