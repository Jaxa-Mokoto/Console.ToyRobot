namespace ToyRobot.BusinessLayer.Services.Interfaces
{
    /// <summary>
    /// The service to implement a given report.
    /// </summary>
    public interface IGameBoardService
    {
        /// <summary>
        /// Validates that the given coordinates are within the set bounds.
        /// </summary>
        /// <param name="XCoordinate">The user's x-coordinate.</param>
        /// <param name="YCoordinate">The user's y-coordinate.</param>
        /// <returns></returns>
        bool isValidCoordinate(int XCoordinate, int YCoordinate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="compassDirection"></param>
        /// <returns></returns>
        bool isValidCompassDirection(string compassDirection);
    }
}