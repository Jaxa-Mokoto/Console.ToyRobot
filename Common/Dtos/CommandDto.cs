namespace ToyRobot.Common.Dtos
{
    /// <summary>
    /// The base commands DTO.
    /// </summary>
    public class CommandDto
    {
        /// <summary>
        /// The name of the direction the robot moves in.
        /// </summary>
        public string CompassDirectionName { get; set; }

        /// <summary>
        /// The X coordinate of the place command.
        /// </summary>
        public int PlaceXCoordinate { get; set; }

        /// <summary>
        /// The Y coordinate of the place command.
        /// </summary>
        public int PlaceYCoordinate { get; set; }

        /// <summary>
        /// The flag to identify if the first place command has been called.
        /// </summary>
        public bool isInitialPlaceCommand { get; set; } = true;
    }
}