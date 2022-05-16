namespace ToyRobot.BusinessLayer.Services.Interfaces
{
    /// <summary>
    /// The service to validate given commands.
    /// </summary>
    public interface IGameBoardService
    {
        /// <summary>
        /// Validates that the given coordinates are within the set bounds.
        /// </summary>
        /// <param name="XCoordinate">The user's x-coordinate.</param>
        /// <param name="YCoordinate">The user's y-coordinate.</param>
        /// <returns>A boolean flag indicating if the given coordinates are valid and within range.</returns>
        bool isValidCoordinate(int? XCoordinate, int? YCoordinate);

        /// <summary>
        /// Verifies if the compass direction is valid.
        /// </summary>
        /// <param name="compassDirection">The compass direction.</param>
        /// <returns>A boolean flag indicating if a given compass direction is valid or not.</returns>
        bool isValidCompassDirection(string compassDirection);

        /// <summary>
        /// Verifies if a given place command is the very first.
        /// </summary>
        /// <param name="userCommand">The user's command.</param>
        /// <returns>A boolean flag indicating if the given command is the very first.</returns>>
        bool isValidInitialPlaceCommand(string userCommand);
    }
}