namespace ToyRobot.BusinessLayer.Services.Interfaces
{
    /// <summary>
    /// The service to process the given command(s).
    /// </summary>
    public interface IToyRobotService
    {
        /// <summary>
        /// Processes the given commands. 
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns>The processed command with calculated behaviour.</returns>
        string ProcessCommands(string userCommand);
    }
}