using ToyRobot.BusinessLayer.Helpers;
using ToyRobot.Common.Enums;

namespace ToyRobot.BusinessLayer.Services.Interfaces
{
    /// <summary>
    /// The service to implement a given behaviour.
    /// </summary>
    public interface IRuleService
    {
        /// <summary>
        /// Sets the robot's new place command.
        /// </summary>
        /// <param name="xcoordinate">The x-coordinate.</param>
        /// <param name="ycoordinate">The y-coordinate.</param>
        /// <param name="direction">The compass direction.</param>
        /// <returns>A valid placement with direction and coordinates.</returns>
        string PlaceBehaviour(int xcoordinate, int ycoordinate, CompassDirection direction);

        /// <summary>
        /// Sets the new position for the robot adjusted by 1 unit.
        /// </summary>
        /// <returns>The robot's next position.</returns>
        Position NextMove();

        /// <summary>
        /// Sets the new rotated direction to either the left or right.
        /// </summary>
        /// <param name="rotationDirection">The rotated direction.</param>
        /// <returns>The new rotated direction with the updated compass direction.</returns>
        CompassDirection RotationBehaviour(string rotationDirection);

        /// <summary>
        /// Displays the new report.
        /// </summary>
        /// <returns>The report output.</returns>
        string ReportBehaviour();
    }
}