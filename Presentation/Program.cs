using System;
using ToyRobot.BusinessLayer.Services;
using ToyRobot.Common.Resources;

namespace ToyRobot.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.BufferWidth = 138;
            Console.BufferHeight = 160;
            Console.SetWindowSize(Console.BufferWidth, 50);
            Console.WriteLine(DisplayNames.WelcomeBanner);

            GameBoardService gameBoardService = new GameBoardService();
            BehaviourService behaviourService = new BehaviourService();
            CommandService commandService = new CommandService(gameBoardService, behaviourService);

            var userCommand = string.Empty;

            while (userCommand.ToUpper() != DisplayNames.ExitCommand)
            {
                userCommand = Console.ReadLine().ToUpper(); // User inputs value into field.

                if (userCommand == null)
                {
                    continue;
                }

                else
                {
                    commandService.ProcessCommands(userCommand);
                }
            }
        }
    }
}