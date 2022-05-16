using System;
using ToyRobot.BusinessLayer.Services;
using ToyRobot.Common.Dtos;
using ToyRobot.Common.Resources;

namespace ToyRobot.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Sets the size of the console window.
            Console.BufferWidth = 138;
            Console.BufferHeight = 160;
            Console.SetWindowSize(Console.BufferWidth, 50);
            Console.WriteLine(DisplayNames.WelcomeBanner);

            GameBoardService gameBoardService = new GameBoardService();
            RuleService behaviourService = new RuleService();
            ToyRobotService commandService = new ToyRobotService(gameBoardService, behaviourService);
            CommandDto commandsDto = new CommandDto();

            var userCommand = string.Empty;

            while (userCommand.ToUpper() != DisplayNames.ExitCommand)
            {
                userCommand = Console.ReadLine().ToUpper();

                if (userCommand == null)
                {
                    continue;
                }

                else
                {
                    commandService.ProcessCommands(userCommand);
                    commandsDto.isInitialPlaceCommand = false;
                }

                if (userCommand == DisplayNames.RestartCommand)
                {
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Environment.Exit(0);
                }
            }
        }
    }
}