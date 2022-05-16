namespace ToyRobot.BusinessLayer.Services.Interfaces
{
    /// <summary>
    /// The service to generate the behaviour of the given command(s).
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// Processes the given commands. 
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns></returns>
        string ProcessCommands(string userCommand);
    }
}